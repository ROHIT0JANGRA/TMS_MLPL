var hdnStartLocationId;
var startKm;
var currentDate, jsDateFormat;
$(document).ready(function () {
    SetPageLoad('Tripsheet', 'Generate', '', 'Go To List', pageUrl);
    InitWizard('dvWizard', [
        { StepName: 'Tripsheet Details' },
        { StepName: 'Driver Information', StepFunction: GetToCityName },
        { StepName: 'Other Details', StepFunction: ValidateStep3 },
        { StepName: 'Attached Dockets Details' }
    ], 'Generate Tripsheet');

    txtVehicleNo = $('#txtVehicleNo'); hdnVehicleId = $('#hdnVehicleId'); hdnStartLocationId = $('#hdnStartLocationId'); txtEndLocation = $('#txtEndLocation'); hdnEndLocationId = $('#hdnEndLocationId'); ddlCategory = $('#ddlCategory'); ddlVehicleMode = $('#ddlVehicleMode'); ddlRouteId = $('#ddlRouteId'); txtFromCity = $('#txtFromCity'); hdnFromCityId = $('#hdnFromCityId'); txtToCity = $('#txtToCity'); hdnToCityId = $('#hdnToCityId'); chkIsFuelSlipProvided = $('#chkIsFuelSlipProvided'); txtAdvanceAmount = $('#txtAdvanceAmount'); hdnTripRouteId = $('#hdnTripRouteId'); txtTripRouteName = $('#txtTripRouteName'); txtCustomerCode = $('#txtCustomerCode'); hdnCustomerId = $('#hdnCustomerId'); ddlFirstDriverId = $('#ddlFirstDriverId'); ddlSecondDriverId = $('#ddlSecondDriverId'); dtDocketList = $('#dtDocketList'); btnPopup = $('#btnPopup'); btnSubmit = $('#btnSubmit'); chkUseFuelCard = $('#chkUseFuelCard'); chkUseCashCard = $('#chkUseCashCard'); ddlFuelCard = $('#ddlFuelCard'); ddlCashCard = $('#ddlCashCard');
    lblCustomerId = $('#lblCustomerId');
    $('#ddlInternalUsageSubCategory').readOnly();
    ddlVehicleMode.readOnly();
    btnPopup.click(OnPopupClick);
    btnSubmit.click(OnSubmit);

    SetPaymentAmount(0);

    VehicleAutoCompleteByLocationForTripsheet('txtVehicleNo', 'hdnVehicleId');
    txtVehicleNo.blur(function () { IsVehicleNoExistForTripsheet(txtVehicleNo, hdnVehicleId); });

    LocationAutoComplete('txtEndLocation', 'hdnEndLocationId');
    txtEndLocation.blur(function () { IsLocationCodeExist(txtEndLocation, hdnEndLocationId); });

    CityAutoComplete('txtFromCity', 'hdnFromCityId');
    txtFromCity.blur(function () { IsCityNameExist(txtFromCity, hdnFromCityId); });

    CityAutoComplete('txtToCity', 'hdnToCityId');
    txtToCity.blur(function () { IsCityNameExist(txtToCity, hdnToCityId); });

    CustomerAutoComplete('txtCustomerCode', 'hdnCustomerId');
    txtCustomerCode.blur(function () { return IsCustomerCodeExist(txtCustomerCode, hdnCustomerId, lblCustomerId); });

    AutoComplete('txtTripRouteName', appUrl.replace('Controller', 'RouteCityWise').replace('Action', 'GetAutoCompleteList'), 'routeName', 'l', 'l', 'l', '', '', 'hdnTripRouteId', '', '');
    txtTripRouteName.blur(function () { return CheckValidRouteName(txtTripRouteName, hdnTripRouteId); });

    //DropDownChange('ddlFuelCard', function () {
    //    $('#hdnFuelCard').val($(this).val());
    //});

    //DropDownChange('ddlCashCard', function () {
    //    $('#hdnCashCard').val($(this).val());
    //});

    InitGrid('dtFuelSlipDetail', false, 7, InitAutoComplete);

    ddlCategory.change(OnCategoryChange).change();
    txtVehicleNo.blur(OnVehiclechange);
    ddlVehicleMode.change(OnVehicleModeChange);
    ddlRouteId.change(OnRouteChange).change();
    txtTripRouteName.blur(OnTripRouteChange);

    AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Driver').replace('Action', 'GetDriverListByLocation'), JSON.stringify({}), GetSecondDriverListSuccess, ErrorFunction, false);

    $("#chkIsFuelSlipProvided").change(FuelSlipEntry).change();
    txtAdvanceAmount.blur(function () { SetPaymentAmount($(this).val()); });
    ddlFirstDriverId.change(GetFirstDriverDetail);
    ddlSecondDriverId.change(GetSecondDriverDetail);
    //$('#txtStartKm').blur(CheckValidStartKm);

    dtDocketList = LoadDataTable('dtDocketList', false, false, false, null, null, [],
        [
            { title: SelectAll.GetChkAll('chkAllDocket'), data: "DocketId" },
            { title: docketNomenclature, data: 'DocketNo' },
            { title: 'Booking Date', data: 'DocketDate' },
            { title: 'Origin', data: 'FromLocationCode' },
            { title: 'Destination', data: 'ToLocationCode' },
            { title: 'No of Packages', data: 'Packages' },
            { title: 'Actual Weight', data: 'ActualWeight' },
            { title: 'Charged Weight', data: 'ChargeWeight' },
            { title: 'Sub Total', data: 'SubTotal' },
            { title: docketNomenclature + ' Total', data: 'GrandTotal' }
        ], false);

    $('#txtTransitTime').val('00:00').blur(ValidateTransitTime);
    $('#chkIsAdvancePaid').change(AdvancePayment).change();


    GetFromCityName();

    $('.chosen-container').hide();
    //$('#ddlAdvanceCardId').change(GetCashCardAccount);
    //$('#chkIsAdvancePaidByCashCard').click(SetAdvanceByCashCard);

    RegisterValidation();
    SetCashCardPaymentMode(true);
    $('#dvTdsDetails').hide();
});

var cashCardList = []
function ValidateStep3() {
    if (!ValidateTransitTime()) {
        isStepValid = false;
        ShowMessage('Please enter Transit Time');
        $('#txtTransitTime').focus();
        return false;
    }
    BindCashCardList(hdnVehicleId.val(), $('#txtTripsheetDateTime').toDate(), false);
    SetPaymentPartyTypeAndParty(5, ddlFirstDriverId.val());
    //$('#ddlAdvanceCardId').empty();
    //$('#ddlCashCard').find('option:selected').each(function () {
    //    var option = $(this);
    //    cashCardList.push({ Value: option.val(), Text: option.text() });
    //});
    //BindDropDownList('ddlAdvanceCardId', cashCardList, 'Value', 'Text', '', (cashCardList.length > 1 ? 'Select Cash Card' : ''));
}

function GetFromCityName() {
    AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'City').replace('Action', 'GetCityByLocationId'), JSON.stringify({ locationId: hdnStartLocationId.val() }), function (result) {
        $('#txtFromCity').val(result.Name);
        $('#hdnFromCityId').val(result.Value);
    }, ErrorFunction, false);
}

function GetToCityName() {
    //$('#dvFuelCard').showHide(chkUseFuelCard.IsChecked);
    //$('#dvCashCard').showHide(chkUseCashCard.IsChecked);
    //if (chkUseFuelCard.IsChecked)
    //    AddRequired(ddlFuelCard, 'Please select Fuel Card');
    //if (chkUseCashCard.IsChecked)
    //    AddRequired(ddlCashCard, 'Please select Cash Card');
    //if (chkUseFuelCard.IsChecked) {
    //    var requestData = { vehicleId: hdnVehicleId.val(), tripsheetDate: $('#txtTripsheetDateTime').toDate(), isFuelCard: true };
    //    AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Card').replace('Action', 'GetCardListByVehicleId'), JSON.stringify(requestData), GetFuelCardListSuccess, ErrorFunction, false);
    //}

    //if (chkUseCashCard.IsChecked) {
    //    var requestData = { vehicleId: hdnVehicleId.val(), tripsheetDate: $('#txtTripsheetDateTime').toDate(), isFuelCard: false };
    //    AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Card').replace('Action', 'GetCardListByVehicleId'), JSON.stringify(requestData), GetCashCardListSuccess, ErrorFunction, false);
    //}

    AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Rules').replace('Action', 'GetModuleRuleByIdAndRuleId'), JSON.stringify({ moduleId: 101, ruleId: 1 }), function (result) {
        if (result == 'Y')
            $('#txtStartKm').blur(CheckValidStartKm);
        else
            $('#txtStartKm').off();
    }, ErrorFunction, false);


    AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'City').replace('Action', 'GetCityByLocationId'), JSON.stringify({ locationId: hdnEndLocationId.val() }), function (result) {
        $('#txtToCity').val(result.Name);
        $('#hdnToCityId').val(result.Value);
    }, ErrorFunction, false);
}

//function GetFuelCardListSuccess(responseData) {
//    BindDropDownList('ddlFuelCard', responseData, 'Value', 'Name');
//    if (responseData.length == 1) {
//        $('#ddlFuelCard').find('option:first').attr('selected', 'selected'); //$('#ddlFuelCard').val([responseData[0].Value]).trigger("chosen:updated");
//        $('#hdnFuelCard').val($('#ddlFuelCard').val());
//    }
//}

//function GetCashCardListSuccess(responseData) {
//    BindDropDownList('ddlCashCard', responseData, 'Value', 'Name');
//    if (responseData.length == 1) {
//        $('#ddlCashCard').find('option:first').attr('selected', 'selected'); //$('#ddlCashCard').val([responseData[0].Value]).trigger("chosen:updated");
//        $('#hdnCashCard').val($('#ddlCashCard').val());
//    }
//}

function OnCategoryChange() {
    hdnCustomerId.val('');
    txtCustomerCode.val('');
    $('#divCustomer').showHide(ddlCategory.val() == 1 || ddlCategory.val() == 3);
    $('#divSubCategoryForExternalUsage').showHide(ddlCategory.val() == 1 || ddlCategory.val() == 3);
    $('#divSubCategoryForInternalUsage').showHide(ddlCategory.val() == 2);
}

function OnVehiclechange() {
    SetValueForFirstDriver();
    SetValueForSecondDriver();
    if (txtVehicleNo.val() != '') {
        var requestData = { vehicleId: hdnVehicleId.val() };
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Vendor').replace('Action', 'GetVenderTypeByVehicleId'), JSON.stringify(requestData), GetVendorTypeListSuccess, ErrorFunction, false);
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Driver').replace('Action', 'GetDriverListByTripSheetRule'), JSON.stringify(requestData), GetFirstDriverListSuccess, ErrorFunction, false);
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Vehicle').replace('Action', 'GetStartKmByVehicleId'), JSON.stringify(requestData), function (result) {
            $('#txtStartKm').val(result);
            startKm = result;
        }, ErrorFunction, false);
        requestData = { vehicleNo: txtVehicleNo.val() };
        AjaxRequestWithPostAndJson(pageUrl + '/GetDocketListByVehicleNo', JSON.stringify(requestData), function (result) {
            dtDocketList.fnClearTable();
            if (result.length > 0) {
                $.each(result, function (i, item) {
                    item.DocketId =
                        SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'DocketDetails[' + i + '].IsChecked') +
                        "<input type='hidden' value='" + item.DocketId + "' name='DocketDetails[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                        "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>";

                    item.DocketDate = $.displayDate(item.DocketDate);
                    item.Packages = "<input type='text' value='" + item.Packages + "' class='textlabel' style='text-align: right'/>";
                    item.ActualWeight = "<input type='text' value='" + item.ActualWeight + "' class='textlabel' style='text-align: right'/>";
                    item.ChargeWeight = "<input type='text' value='" + item.ChargeWeight + "' class='textlabel' style='text-align: right'/>";
                    item.SubTotal = "<input type='text' value='" + item.SubTotal + "' class='textlabel' style='text-align: right'/>";
                    item.GrandTotal = "<input type='text' value='" + item.GrandTotal + "' class='textlabel' style='text-align: right'/>";
                });
            }

            dtDocketList.dtAddData(result);

        }, ErrorFunction, false);
    }
}

function GetVendorTypeListSuccess(responseData) {
    BindDropDownList('ddlVehicleMode', responseData, 'Value', 'Name');
    OnVehicleModeChange();
}

function GetFirstDriverListSuccess(responseData) {
    BindDropDownList('ddlFirstDriverId', responseData, 'Value', 'Name', '', 'Select');
}

function GetSecondDriverListSuccess(responseData) {
    BindDropDownList('ddlSecondDriverId', responseData, 'Value', 'Name', '', 'Select');
}

function OnVehicleModeChange() {
    if (ddlVehicleMode.val() == 3) {
        $('#divDriverInfo').show();
        $('#divFuelSlipProvided').show();
        $('#divPaymentDetails').show();
        $('#divPaymentDetail').show();
        AddRequired($('#ddlFirstDriverId'), "Please select Driver");
    }
    else {
        $('#divDriverInfo').hide();
        $('#divFuelSlipProvided').hide();
        $('#divPaymentDetails').hide();
        $('#divPaymentDetail').hide();
        RemoveRequired($('#ddlFirstDriverId'));
    }
    FuelSlipEntry();
    AdvancePayment();
}

function OnRouteChange() {
    $('#txtTransitTime').val('00:00');
    $('#hdnFromCityId').val('');
    $('#hdnToCityId').val('');
    $('#txtTransitTime').readOnly(false);
    if (ddlRouteId.val() == 1) {
        $('#divCityWise').show();
        $('#divRouteWise').hide();
    }
    else if (ddlRouteId.val() == 2) {
        $('#divCityWise').hide();
        $('#divRouteWise').show();
    }
}

function OnSubmit() {
    if (ddlCategory.val() == 1 || ddlCategory.val() == 3)
        $('#hdnSubCategory').val($('#ddlExternalUsageSubCategory').val());
    else if (ddlCategory.val() == 2)
        $('#hdnSubCategory').val($('#ddlInternalUsageSubCategory').val());
    else
        $('#hdnSubCategory').val(0);
}

function CheckValidRouteName(objRoute, objHdnRouteId) {
    if (objRoute.val() != "") {
        var requestData = { routeName: objRoute.val() };

        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'RouteCityWise').replace('Action', 'IsRouteNameExist'), JSON.stringify(requestData), function (result) {
            if (!IsObjectNullOrEmpty(result)) {
                objRoute.val(result.Name);
                objHdnRouteId.val(result.Value);
            }
            else {
                ShowMessage('Route is not exist');
                objRoute.val('');
                objHdnRouteId.val('');
                objRoute.focus();
            }
        }, ErrorFunction, false);
    }
    return false;
}

function GetFirstDriverDetail() {
    if (ddlFirstDriverId.val() != '') {
        var requestData = { driverId: ddlFirstDriverId.val() };
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Driver').replace('Action', 'GetById'), JSON.stringify(requestData), GetFirstDriverDetailSuccess, ErrorFunction, false);
    }
    else
        SetValueForFirstDriver();
}

function SetValueForFirstDriver() {
    $('#txtFirstDriverName').val('');
    $('#txtFirstDriverLicenseNo').val('');
    $('#txtFirstDriverLicenseValidityDate').val('');
    $('#txtFirstDriverMobileNo').val('');
    $('#txtFirstDriverLicenseIssueBy').val('');
    $('#txtFirstDriverName').readOnly(false);
    $('#txtFirstDriverLicenseNo').readOnly(false);
    $('#txtFirstDriverLicenseValidityDate').readOnly(false);
    $('#txtFirstDriverMobileNo').readOnly(false);
    $('#txtFirstDriverLicenseIssueBy').readOnly(false);
}

function GetFirstDriverDetailSuccess(responseData) {
    $('#txtFirstDriverName').val(responseData.DriverName);
    $('#txtFirstDriverLicenseNo').val(responseData.LicenseNo);
    $('#txtFirstDriverLicenseValidityDate').val($.entryDate(responseData.LicenseValidityDate));
    $('#txtFirstDriverMobileNo').val(responseData.MobileNo);
    $('#txtFirstDriverLicenseIssueBy').val(responseData.LicenseIssueBy);
    $('#txtFirstDriverName').readOnly();
    $('#txtFirstDriverLicenseNo').readOnly();
    $('#txtFirstDriverLicenseValidityDate').readOnly();
    $('#txtFirstDriverMobileNo').readOnly();
    $('#txtFirstDriverLicenseIssueBy').readOnly();
    if (responseData.BalanceAmount > 0)
        $('#lblDriverBalance').text(responseData.BalanceAmount + ' Dr');
    else if (responseData.BalanceAmount < 0)
        $('#lblDriverBalance').text((responseData.BalanceAmount * -1) + ' Cr');
    else
        $('#lblDriverBalance').text(responseData.BalanceAmount + ' Dr');
    $('#hdnDriverBalance').val(responseData.BalanceAmount)
}

function GetSecondDriverDetail() {
    if (ddlSecondDriverId.val() != '') {
        if (ddlSecondDriverId.val() == ddlFirstDriverId.val()) {
            ddlSecondDriverId.val('0');
            SetValueForSecondDriver();
            return false;
        }
        var requestData = { driverId: ddlSecondDriverId.val() };
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Driver').replace('Action', 'GetById'), JSON.stringify(requestData), GetSecondDriverDetailSuccess, ErrorFunction, false);
    }
    else
        SetValueForSecondDriver();
}

function SetValueForSecondDriver() {
    $('#txtSecondDriverName').val('');
    $('#txtSecondDriverLicenseNo').val('');
    $('#txtSecondDriverLicenseValidityDate').val('');
    $('#txtSecondDriverMobileNo').val('');
    $('#txtSecondDriverLicenseIssueBy').val('');
    $('#txtSecondDriverName').readOnly(false);
    $('#txtSecondDriverLicenseNo').readOnly(false);
    $('#txtSecondDriverLicenseValidityDate').readOnly(false);
    $('#txtSecondDriverMobileNo').readOnly(false);
    $('#txtSecondDriverLicenseIssueBy').readOnly(false);
}

function GetSecondDriverDetailSuccess(responseData) {
    $('#txtSecondDriverName').val(responseData.DriverName);
    $('#txtSecondDriverLicenseNo').val(responseData.LicenseNo);
    $('#txtSecondDriverLicenseValidityDate').val($.entryDate(responseData.LicenseValidityDate));
    $('#txtSecondDriverMobileNo').val(responseData.MobileNo);
    $('#txtSecondDriverLicenseIssueBy').val(responseData.LicenseIssueBy);
    $('#txtSecondDriverName').readOnly();
    $('#txtSecondDriverLicenseNo').readOnly();
    $('#txtSecondDriverLicenseValidityDate').readOnly();
    $('#txtSecondDriverMobileNo').readOnly();
    $('#txtSecondDriverLicenseIssueBy').readOnly();
}

function OnTripRouteChange() {
    $('#txtTransitTime').val('');
    $('#hdnFromCityId').val('');
    $('#hdnToCityId').val('');
    $('#txtTransitTime').readOnly(false);
    if (txtTripRouteName.val() != '') {
        var requestData = { routeId: hdnTripRouteId.val() };
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'RouteCityWise').replace('Action', 'GetTransitTime'), JSON.stringify(requestData), GetTransitTimeSuccess, ErrorFunction, false);
    }
}

function GetTransitTimeSuccess(responseData) {
    $('#txtTransit').val(responseData.Transit).readOnly();
    $('#hdnFromCityId').val(responseData.FromCityId);
    $('#hdnToCityId').val(responseData.ToCityId)
}

function InitAutoComplete() {
    $('[id*="hdnFuelVendorId"]').each(function () {
        var hdnFuelVendorId = $(this);
        var txtFuelVendorCode = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtFuelVendorCode'));
        var lblFuelVendorName = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'lblFuelVendorName'));
        var txtQuantity = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtQuantity'));
        var txtRate = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtRate'));
        var txtAmount = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtAmount'));
        txtRate.blur(GetAmount);
        txtQuantity.blur(GetAmount);
        txtAmount.blur(GetTotalAmountAndQuantity);
        txtQuantity.blur(GetTotalAmountAndQuantity);
        //InitDateTimePicker(txtFuelSlipDate.Id, false, true, false, currentDate, jsDateFormat, '', '');
        VendorAutoComplete(txtFuelVendorCode.Id, hdnFuelVendorId.Id, 'Fuel Vendor', 6);
        txtFuelVendorCode.blur(function () { return IsVendorCodeExist(txtFuelVendorCode, hdnFuelVendorId, lblFuelVendorName, 'Fuel Vendor', 6); });

        function GetAmount() {
            if (txtRate.val() != '' && txtQuantity.val() != '')
                txtAmount.val(parseFloat(txtRate.val()) * parseFloat(txtQuantity.val()));
        }
    });
}

function GetTotalAmountAndQuantity() {
    var totalAmount = 0, totalQuantity = 0;
    $('[id*="txtQuantity"]').each(function () {
        var txtQuantity = $(this);
        var txtAmount = $('#' + txtQuantity.Id.replace('txtQuantity', 'txtAmount'));
        if (txtAmount.val() != '' && txtQuantity.val() != '') {
            totalAmount = totalAmount + parseFloat(txtAmount.val());
            totalQuantity = totalQuantity + parseFloat(txtQuantity.val());
        }
    });
    $('#txtTotalQuantity').val(totalQuantity);
    $('#txtTotalAmount').val(totalAmount);
}

function CheckValidVendorCode(txtVendorCode, hdnVendorId) {
    if (txtVendorCode.val() != "") {
        var requestData = { vendorName: txtVendorCode.val().split(':')[0].trim() };
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Vendor').replace('Action', 'CheckValidVendorName'), JSON.stringify(requestData), function (result) {
            if (result.Value > 0) {
                txtVendorCode.val(result.Name);
                hdnVendorId.val(result.Value);
                txtVendorCode.val(result.Name + ' : ' + result.Description);
            }
            else {
                ShowMessage('Vendor is not exist');
                txtVendorCode.val('');
                hdnVendorId.val('');
                txtVendorCode.focus();
            }
        }, ErrorFunction, false);
    }
    return false;
}

function FuelSlipEntry() {
    $('#divFuelSlipDetail').showHide(chkIsFuelSlipProvided.IsChecked && ddlVehicleMode.val() == 3);
    $('[id*="hdnFuelVendorId"]').each(function () {
        var hdnFuelVendorId = $(this);
        var txtSlipNo = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtSlipNo'));
        var txtFuelVendor = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtFuelVendor'));
        var txtQuantity = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtQuantity'));
        var txtRate = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtRate'));
        var txtAmount = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtAmount'));
        var txtFuelSlipDate = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtFuelSlipDate'));
        if (chkIsFuelSlipProvided.IsChecked && ddlVehicleMode.val() == 3) {
            AddRequired(txtSlipNo, "Please enter Fuel Slip No");
            AddRequired(txtFuelVendor, "Please enter Fuel Vendor");
            AddRequired(txtFuelSlipDate, "Please select Fuel Slip Date");
            AddRange(txtQuantity, "Please enter Quantity", 1);
            AddRange(txtRate, "Please enter Rate", 0.01);
            AddRange(txtAmount, "Please enter Amount", 0.01);
        }
        else {
            RemoveRequired(txtSlipNo);
            RemoveRequired(txtFuelVendor);
            RemoveRequired(txtFuelSlipDate);
            RemoveRange(txtQuantity);
            RemoveRange(txtRate);
            RemoveRange(txtAmount);
        }
    });
}

function AdvancePayment() {
    var isAdvance = $('#chkIsAdvancePaid').IsChecked && ddlVehicleMode.val() == 3;
    $('#dvAdvanceDetails').showHide(isAdvance);
    //$('#dvIsAdvancePaidByCashCard').showHide(isAdvance && cashCardList.length > 0);
    $('#txtAdvancePlace').enable(isAdvance);
    $('#txtAdvanceDate').enable(isAdvance);
    $('#txtAdvancePaidBy').enable(isAdvance);
    $('#txtAdvanceAmount').enable(isAdvance);
    //SetAdvanceByCashCard();
    if (isAdvance) {
        AddRequired($('#txtAdvanceDate'), "Please select Advance Date");
        AddRange($('#txtAdvanceAmount'), "Please enter Advance Amount", 1, 9999999);
    }
}

//function SetAdvanceByCashCard() {
//    var chkIsAdvancePaidByCashCard = $('#chkIsAdvancePaidByCashCard');
//    if (!chkIsAdvancePaidByCashCard.IsChecked)
//        $('#ddlAdvanceCardId').val('');
//    $('#ddlAdvanceCardId').enable(chkIsAdvancePaidByCashCard.IsChecked).change();
//    SetCashCardPaymentMode(chkIsAdvancePaidByCashCard.IsChecked);
//}

function GetCashCardAccount() {
    //if ($('#ddlAdvanceCardId').val() != '' && $('#ddlAdvanceCardId').val() != null) {
    //    var requestData = { cardId: $('#ddlAdvanceCardId').val() };
    //    AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Card').replace('Action', 'CheckCardSufficientBalance'), JSON.stringify(requestData), function (balanceAmount) {
    //        if (parseFloat(txtAdvanceAmount.val()) > balanceAmount) {
    //            ShowMessage('Not Sufficient Balance In Cash Card');
    //            $('#ddlAdvanceCardId').val('');
    //        }
    //        else {
    //            AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Card').replace('Action', 'GetCashCardAccount'), JSON.stringify(requestData), function (responseData) {
    //                if (responseData != null) {
    //                    BindCashCardList(responseData.Value, responseData.Name)
    //                }
    //            }, ErrorFunction, false);
    //        }
    //    }, ErrorFunction, false);
    //}
}

function CheckValidStartKm() {
    if (parseInt($('#txtStartKm').val()) < parseInt(startKm)) {
        ShowMessage('StartKm is greater than ' + startKm);
        $('#txtStartKm').val('');
        return false;
    }
}

function GetChecklist() {
    $('.modal').modal('show');
    return false;
}

function OnPopupClick() {
    $('.modal').modal('hide');
    return false;
}


function ValidateTransitTime() {
    var arr = $('#txtTransitTime').val().replace(' ', ':').split(':');
    var hour = parseFloat(arr[0]);
    var min = parseFloat(arr[1]);
    if (isNaN(hour) || parseInt(hour) > 999)
        hour = 0;
    if (isNaN(min) || parseInt(min) > 59)
        min = 0;
    hour = (hour < 10) ? "0" + hour : hour;
    min = (min < 10) ? "0" + min : min;
    $('#hdnTransitTimeHour').val(hour);
    $('#hdnTransitTimeMin').val(min);
    $('#txtTransitTime').val(hour + ":" + min);
    return hour > 0 || min > 0
}
