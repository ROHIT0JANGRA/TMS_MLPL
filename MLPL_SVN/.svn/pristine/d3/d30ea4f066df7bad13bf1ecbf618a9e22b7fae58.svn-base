var ddlPaybasId, ddlTransportModeId, ddlBusinessTypeId, drDRSDate, selectedDocketList, locationMasterUrl, vendorMasterUrl, vehicleMasterUrl, docketNomenclature,
    rdODAOnly, txtDocketNo, txtTotalDocket, vehicleTypeMasterUrl, drsUrl, dtDocketDetails, ddlVendorTypeId, ddlVendorId, ddlVehicleId, ddlVehicleTypeId, ddlFtlTypeId, txtPanNo,
    txtVehicleNo, hdnBalanceAmountLocationId, txtBalanceAmountLocationCode, hdnAdvanceAmountLocationId, txtAdvanceAmountLocationCode, dtCharges, chargeList,
    txtDrsAmount, txtAdvanceAmount, hdnFirstDriverId, txtFirstDriverName, txtFirstDriverMobileNo, txtFirstDriverLicenseNo, txtFirstDriverLicenseIssueBy, txtFirstDriverLicenseValidityDate,
    hdnSecondDriverId, txtSecondDriverLicenseValidityDate, txtSecondDriverName, txtSecondDriverMobileNo, txtSecondDriverLicenseNo, txtSecondDriverLicenseIssueBy;
var driverMasterUrl;
var chkIsDeliveryThroughSameVehicle, hdnDrsId, hdnDrsNo, isDrsClose = false;
var ruleMasterUrl, useEwayBillDetail, useAdhocContract, isPanMandatory;
var txtDrsDate, chkIsAdhoc, hdnMatrixTypeId, hdnContractId, txtContractAmount;
var chkIsSelectCity, hdnFromCityId, txtFromCityName, hdnToCityId, txtToCityName;
var vendorContractUrl;
var useBillingatVendorDocumentGeneration = false;
var dtDocketErrorList;

$(document).ready(function () {
    SetPageLoad(drsNomenclature, 'Create', 'txtDocketNo', '', '');
    InitObjects();
    AttachEvents();
    InitGrid('dtAdvBalPmtDtl', false, 2, InitdtAdvBalPmtDtl);
   
});

function InitdtAdvBalPmtDtl() {

    $('[id*="txtAdvBalAmount"]').each(function () {
        var txtAdvBalAmount = $(this);
        var ddlAdvBalLoc = $('#' + txtAdvBalAmount.attr('id').replace('txtAdvBalAmount', 'ddlAdvBalLoc'));
        txtAdvBalAmount.blur(function () { return CheckAdvAmount(txtAdvBalAmount, txtAdvanceAmount, ddlAdvBalLoc); });
        ddlAdvBalLoc.change(function () { return CheckValidLocation(ddlAdvBalLoc); });
    });

    AutoSuggestAdvAmountonAddRow();
}
function AutoSuggestAdvAmountonAddRow() {

    $('#dtAdvBalPmtDtl tr:last').find('[id*="txtAdvBalAmount"]').val(0);

    var TotAdvAmtTxt1 = parseInt(txtAdvanceAmount.val());
    var txtAdvBalAmountCheck1 = 0;
    $('[id*="txtAdvBalAmount"]').each(function () {
        var tal = parseInt($(this).val())
        if (isNaN(tal)) {
            var tal = 0;
        }
        txtAdvBalAmountCheck1 = tal + parseInt(txtAdvBalAmountCheck1);

    });

    txtAdvBalAmountCheck1 = parseInt(TotAdvAmtTxt1) - parseInt(txtAdvBalAmountCheck1);
    //auto calaulate suggested advance amount
    if (txtAdvBalAmountCheck1 >= 0) {

        $('#dtAdvBalPmtDtl tr:last').find('[id*="txtAdvBalAmount"]').val(txtAdvBalAmountCheck1);

    }
    else {

        $('#dtAdvBalPmtDtl tr:last').find('[id*="txtAdvBalAmount"]').val(0);

    }
}
function CheckAdvAmount(txtAdvBalAmount, txtAdvanceAmount, ddlAdvBalLoc) {

    var TotAdvAmtTxt = parseInt(txtAdvanceAmount.val());
    var txtAdvBalAmountCheck = 0;
    $('[id*="txtAdvBalAmount"]').each(function () {
        txtAdvBalAmountCheck = parseInt($(this).val()) + parseInt(txtAdvBalAmountCheck);

    });
    // alert(txtAdvBalAmountCheck);

    if (TotAdvAmtTxt < txtAdvBalAmountCheck) {

        ShowMessage('Advance amount should not be greater than ' + txtAdvanceAmount.val());
        txtAdvBalAmount.val(0);

    }
    CheckValidLocation(ddlAdvBalLoc);
    return false;
}
function CheckValidLocation(ddlAdvBalLoc) {

    if (!CheckDuplicateDropDownInTable('dtAdvBalPmtDtl', 'ddlAdvBalLoc', 'Location', ddlAdvBalLoc)) { ddlAdvBalLoc.val(''); return false };
    return false;
}
function SetGridAdvBalAmnt() {

    $('#dtAdvBalPmtDtl tbody  tr').each(function (i) {
        var tr = $('#dtAdvBalPmtDtl > tbody > tr:eq(' + i + ')');
        if (i == 0) { tr.find('[id*="txtAdvBalAmount"]').val(txtAdvanceAmount.val()); }

    });

}


function ReSetGridAdvBalAmnt() {

    $('#dtAdvBalPmtDtl tbody  tr').each(function (i) {
        var tr = $('#dtAdvBalPmtDtl > tbody > tr:eq(' + i + ')');
        tr.find('[id*="txtAdvBalAmount"]').val(0);
    });

}
function InitObjects() {
    drDRSDate = InitDateRange('drDRSDate', DateRange.LastWeek);
    ddlPaybasId = $('#ddlPaybasId');
    ddlTransportModeId = $('#ddlTransportModeId');
    ddlBusinessTypeId = $('#ddlBusinessTypeId');
    rdODAOnly = $('#rdODAOnly');
    txtDocketNo = $('#txtDocketNo');
    txtTotalDocket = $('#txtTotalDocket');
    ddlVendorTypeId = $('#ddlVendorTypeId');
    ddlVendorId = $('#ddlVendorId');
    hdnBaVendorId = $('#hdnBaVendorId');
    hdnDrsId = $('#hdnDrsId');
    hdnDrsNo = $('#hdnDrsNo');
    ddlVehicleId = $('#ddlVehicleId');
    ddlVehicleTypeId = $('#ddlVehicleTypeId');
    ddlFtlTypeId = $('#ddlFtlTypeId');
    txtPanNo = $('#txtPanNo');
    txtVehicleNo = $('#txtVehicleNo');
    txtDrsAmount = $('#txtDrsAmount');
    txtAdvanceAmount = $('#txtAdvanceAmount');
    hdnFirstDriverId = $('#hdnFirstDriverId');
    txtFirstDriverName = $('#txtFirstDriverName');
    txtFirstDriverMobileNo = $('#txtFirstDriverMobileNo');
    txtFirstDriverLicenseNo = $('#txtFirstDriverLicenseNo');
    txtFirstDriverLicenseIssueBy = $('#txtFirstDriverLicenseIssueBy');
    txtFirstDriverLicenseValidityDate = $('#txtFirstDriverLicenseValidityDate');
    hdnSecondDriverId = $('#hdnSecondDriverId');
    txtSecondDriverName = $('#txtSecondDriverName');
    txtSecondDriverMobileNo = $('#txtSecondDriverMobileNo');
    txtSecondDriverLicenseNo = $('#txtSecondDriverLicenseNo');
    txtSecondDriverLicenseIssueBy = $('#txtSecondDriverLicenseIssueBy');
    txtSecondDriverLicenseValidityDate = $('#txtSecondDriverLicenseValidityDate');
    txtEwayBillIssueDate = $('#txtEwayBillIssueDate');
    txtEwayBillExpiryDate = $('#txtEwayBillExpiryDate');
    chkIsDeliveryThroughSameVehicle = $('#chkIsDeliveryThroughSameVehicle');
    hdnContractId = $('#hdnContractId');
    hdnMatrixTypeId = $('#hdnMatrixTypeId');
    chkIsAdhoc = $('#chkIsAdhoc');
    txtDrsDate = $('#txtDrsDate');
    txtContractAmount = $('#txtContractAmount');
    chkIsSelectCity = $('#chkIsSelectCity');
    hdnFromCityId = $('#hdnFromCityId');
    txtFromCityName = $('#txtFromCityName');
    hdnToCityId = $('#hdnToCityId');
    txtToCityName = $('#txtToCityName');
    txtEwayBillIssueDate = $('#txtEwayBillIssueDate');
    txtEwayBillExpiryDate = $('#txtEwayBillExpiryDate');
    ddlTripsheetId = $('#ddlTripsheetId');
    chkIsMultiAdvApply = $('#chkIsMultiAdvApply');
    hdnDrsId.val(drsId);

    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [
            { title: SelectAll.GetChkAll('chkAllDocket', SelectDocket), data: "DocketId" },
            { title: docketNomenclature, data: 'DocketNo' },
            { title: 'Origin', data: 'FromLocationCode' },
            { title: 'To City', data: 'ToCity' },
            { title: 'Booking Date', data: 'DocketDate' },
            { title: 'Pay Basis', data: 'Paybas' },
            { title: 'Consignor', data: 'ConsignorName' },
            { title: 'Consignee', data: 'ConsigneeName' },
            { title: 'EDD', data: 'DeliveryDate' },
            { title: 'Arrival Date', data: 'ArrivalDate' },
            { title: 'Booked/Arrived/Pending Packages', data: 'ArrivedPackages' },
            { title: 'Actual/Arrived Weight', data: 'ActualWeight' },
            { title: 'Kart Amount', data: 'KartAmount' },
            { title: 'Labour Amount', data: 'LabourAmount' }

        ]);

    hdnBalanceAmountLocationId = $('#hdnBalanceAmountLocationId');
    txtBalanceAmountLocationCode = $('#txtBalanceAmountLocationCode');
    hdnAdvanceAmountLocationId = $('#hdnAdvanceAmountLocationId');
    txtAdvanceAmountLocationCode = $('#txtAdvanceAmountLocationCode');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocketList },
        { StepName: 'Basic Details', StepFunction: GetActiveContract },
        { StepName: 'Vehicle Information' },
        { StepName: 'Driver Information', StepFunction: GetDocketList2 },
        { StepName: 'Vehicle Depart Information', StepFunction: LoadStep5 },
        { StepName: 'Payment Details', StepFunction: CalculateOtherCharges }
    ], 'Create ' + drsNomenclature);
    dtDocketErrorList = LoadDataTable('dtDocketErrorList', false, false, false, null, null, [],
        [
            { title: 'Docket No', data: 'DocketNo' },
            { title: 'Status', data: 'Status' }
        ]);
}

function AttachEvents() {
    VendorAutoCompleteLocationwise('txtBaVendorCode', 'hdnBaVendorId', '', 4);
    $('#txtBaVendorCode').blur(function () { IsVendorCodeExist($('#txtBaVendorCode'), $('#hdnBaVendorId'), $('#lblBaVendorName'), '', 4); });
    LocationAutoComplete('txtBalanceAmountLocationCode', 'hdnBalanceAmountLocationId', 'Balance Paid At Location');
    LocationAutoComplete('txtAdvanceAmountLocationCode', 'hdnAdvanceAmountLocationId', 'Advance Paid At Location');
    txtBalanceAmountLocationCode.blur(function () { return IsLocationCodeExist(txtBalanceAmountLocationCode, hdnBalanceAmountLocationId, 'Balance Paid At Location'); });
    txtAdvanceAmountLocationCode.blur(function () { return IsLocationCodeExist(txtAdvanceAmountLocationCode, hdnAdvanceAmountLocationId, 'Advance Paid At Location'); });
    OnOverLoadedChange();
    ddlVendorTypeId.change(OnVendorTypeChange);
    ddlVendorId.change(OnVendorChange);
    ddlVehicleId.change(OnVehicleChange);
    ddlVehicleTypeId.change(OnVehicleTypeChange);
    ddlFtlTypeId.change(GetFtlType);

    OnDriver2Change(); OnAdvanceAmountChange();
    txtAdvanceAmount.blur(OnAdvanceAmountChange);
    txtFirstDriverName.blur(function () { IsDriverNameExistByLocation(txtFirstDriverName, hdnFirstDriverId, 'First Driver', false); return GetDriverDetail(hdnFirstDriverId, true) });
    txtSecondDriverName.blur(function () { IsDriverNameExistByLocation(txtSecondDriverName, hdnSecondDriverId, 'Second Driver', false); return GetDriverDetail(hdnSecondDriverId, false) });
    txtSecondDriverName.blur(OnDriver2Change);

    txtEwayBillIssueDate.blur(function () {
        if (txtEwayBillIssueDate.val() != '' && txtEwayBillExpiryDate.val() != '') {
            if ($.setDateTime(txtEwayBillIssueDate.val()) >= $.setDateTime(txtEwayBillExpiryDate.val())) {
                ShowMessage('Please select EWAY Bill Issue Date less than EWAY Bill Expiry Date ');
                txtEwayBillIssueDate.val('');
                return false;
            }
        }
    });

    txtEwayBillExpiryDate.blur(function () {
        if (txtEwayBillIssueDate.val() != '' && txtEwayBillExpiryDate.val() != '') {
            if ($.setDateTime(txtEwayBillIssueDate.val()) >= $.setDateTime(txtEwayBillExpiryDate.val())) {
                ShowMessage('Please select EWAY Bill Expiry Date greater than EWAY Bill Issue Date ');
                txtEwayBillExpiryDate.val('');
                return false;
            }
        }
    });

    var isSuccessful = true;
    var requestData = { drsId: hdnDrsId.val() == '' ? 0 : hdnDrsId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetChargeList', JSON.stringify(requestData), function (responseData) {
        chargeList = responseData.OtherChargeList.sort(ComparerTax)
        chargeCount = 0;
        GetChargeDetails(chargeList, dtCharges1, true);
        GetChargeDetails(chargeList, dtCharges2, false);
    }, ErrorFunction, false);
    UseEwayBillDetails();
    UseAdhocContract();
    IsPanNoManadory();
    chkIsSelectCity.change(IsSelectCityChange);
    CityAutoComplete('txtFromCityName', 'hdnFromCityId');
    txtFromCityName.blur(function () { IsCityNameExist(txtFromCityName, hdnFromCityId, 'From City'); });
    CityAutoComplete('txtToCityName', 'hdnToCityId');
    txtToCityName.blur(function () { IsCityNameExist(txtToCityName, hdnToCityId, 'To City'); });
    UseBillingatVendorDocumentGeneration();

    var list = ["4", "5", "6", "7", "8", "9", "10", "11", "12", "13"];
    $('ddlVendorTypeId option').filter(function () {
        return $.inArray(this.value, list) !== -1
    }).remove();
    $('#txtDocketNo').on('blur', function () {
        GetDocketList();
    });
    chkIsMultiAdvApply.change(IsMultiAdvApplyChange);
}

function UseEwayBillDetails() {
    var requestData = { moduleId: 6, ruleId: 1 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        useEwayBillDetail = result == 'Y' ? true : false;
    }, ErrorFunction, false);

    $('#dvEwayBillDetails').showHide(useEwayBillDetail);

}

function UseAdhocContract() {
    var requestData = { moduleId: 6, ruleId: 2 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        useAdhocContract = result == 'Y' ? true : false;
    }, ErrorFunction, false);
    if (!useAdhocContract) {
        chkIsAdhoc.uncheck();
        chkIsAdhoc.disable();
    }
}

function UseBillingatVendorDocumentGeneration() {
    var requestData = { moduleId: 6, ruleId: 6 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        useBillingatVendorDocumentGeneration = result == 'Y' ? true : false;
    }, ErrorFunction, false);
    if (useBillingatVendorDocumentGeneration) {
        $('#dvBillingatVendorDocumentGeneration').showHide(useBillingatVendorDocumentGeneration);
    }
}

function IsPanNoManadory() {
    var requestData = { moduleId: 6, ruleId: 5 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        isPanMandatory = result == 'Y' ? true : false;
    }, ErrorFunction, false);
    if (isPanMandatory) {
        AddRequired($('#txtPanNo'), "Please enter Pan No");
    }
    else {
        RemoveRequired($('#txtPanNo'));
    }
}

function IsSelectCityChange() {
    $("#dvSelectCity").showHide(chkIsSelectCity.is(":checked"));
}

function GetDocketList() {

    if (!hdnDrsId.val() > 0) {
        var paybasId = ddlPaybasId.val() != '' ? ddlPaybasId.val() : '0';
        var transportModeId = ddlTransportModeId.val() != '' ? ddlTransportModeId.val() : '0';
        var businessTypeId = ddlBusinessTypeId.val() != '' ? ddlBusinessTypeId.val() : '0';
        var isOda = rdODAOnly.IsChecked;
        var docketNos = txtDocketNo.val();
        var vendorId = hdnBaVendorId.val();

        var requestData = { fromDate: $.displayDate(drDRSDate.startDate), toDate: $.displayDate(drDRSDate.endDate), paybasId: paybasId, transportModeId: transportModeId, busnessTypeId: businessTypeId, isOda: isOda, docketNos: docketNos, vendorId: vendorId, isDeliveryThroughSameVehicle: chkIsDeliveryThroughSameVehicle.IsChecked };
        AjaxRequestWithPostAndJson(drsUrl + '/GetDocketList', JSON.stringify(requestData), GetDocketListSuccess, ErrorFunction, false);
    }
    else
        GetStep2DetailById();
    
}
function GetDocketList2() {

    if (!hdnDrsId.val() > 0) {
        var paybasId = ddlPaybasId.val() != '' ? ddlPaybasId.val() : '0';
        var transportModeId = ddlTransportModeId.val() != '' ? ddlTransportModeId.val() : '0';
        var businessTypeId = ddlBusinessTypeId.val() != '' ? ddlBusinessTypeId.val() : '0';
        var isOda = rdODAOnly.IsChecked;
        var docketNos = txtDocketNo.val();
        var vendorId = hdnBaVendorId.val();

        var requestData = { fromDate: $.displayDate(drDRSDate.startDate), toDate: $.displayDate(drDRSDate.endDate), paybasId: paybasId, transportModeId: transportModeId, busnessTypeId: businessTypeId, isOda: isOda, docketNos: docketNos, vendorId: vendorId, isDeliveryThroughSameVehicle: chkIsDeliveryThroughSameVehicle.IsChecked };
        AjaxRequestWithPostAndJson(drsUrl + '/GetDocketList', JSON.stringify(requestData), GetDocketListSuccess, ErrorFunction, false);
    }
    else
        GetStep2DetailById();
}

function GetDocketListSuccess(result) {

    if (result.DrsDocketList.length == 0 && result.ErrorList.length == 0) {
        isStepValid = false;
        ShowMessage('No Record Found');
        return false;
    }
    else {

        selectedDocketList = [];
        dtDocketDetails.fnClearTable();
        dtDocketErrorList.fnClearTable();
        txtTotalDocket.val(result.DrsDocketList.length);
        if (result.DrsDocketList.length > 0) {
            $.each(result.DrsDocketList, function (i, item) {
                item.DocketId =
                    SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'DrsDocketList[' + i + '].IsChecked', SelectDocket) +
                    "<input type='hidden' value='" + item.DocketId + "' name='DrsDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                    "<input type='hidden' value='" + item.DocketNo + "' name='DrsDocketList[" + i + "].DocketNo' id='hdnDocketNo" + i + "'/>" +
                    "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>" +
                    "<input type='hidden' value='" + item.ArrivalDate + "'  id='hdnArrivalDate" + i + "'/>" +
                    "<input type='hidden' value='" + item.UnderDrs + "'  id='hdnUnderDrs" + i + "'/>";

                item.DocketNo = item.DocketNo + item.DocketSuffix;
                item.DocketSuffix = "<input type='hidden' value='" + item.DocketSuffix + "' name='DrsDocketList[" + i + "].DocketSuffix'/>";
                item.DocketId = item.DocketId + item.DocketSuffix;
                item.DocketDate = $.displayDate(item.DocketDate);
                item.ArrivalDate = $.displayDate(item.ArrivalDate);
                if (item.ArrivedPackages == null)
                    item.ArrivedPackages = 0;
                item.DeliveryDate = "<input type='text' value='" + $.displayDate(item.DeliveryDate) + "'name='DrsDocketList[" + i + "].DeliveryDate' class='textlabel'/>";
                item.ArrivedPackages = "<input type='text' value='" + item.BookedPackages + '/' + item.ArrivedPackages + '/' + item.Packages + "' class='textlabel' style='text-align: right'/>" +
                    "<input type='hidden' value='" + item.Packages + "' name='DrsDocketList[" + i + "].Packages' id='hdnArrivedPackages" + i + "'/>";
                if (item.ActualWeight == null)
                    item.ActualWeight = 0;
                item.ActualWeight = "<input type='hidden' value='" + item.BookedActualWeight.toFixed(3) + "' name='DrsDocketList[" + i + "].Packages'  id='hdnActualWeight" + i + "'/>" +
                    "<input type='text' value='" + item.BookedActualWeight.toFixed(3) + '/' + item.ActualWeight.toFixed(3) + "' class='textlabel' style='text-align: right' disabled/>";
                item.KartAmount = '<input class="form-control textlabel numeric3" name="DrsDocketList[' + i + '].KartAmount" id="txtKartAmount' + i + '" type="text"  value=\'' + item.KartAmount + '\'/>';
                item.LabourAmount = '<input class="form-control textlabel numeric3" name="DrsDocketList[' + i + '].LabourAmount" id="txtLabourAmount' + i + '" type="text"  value=\'' + item.LabourAmount + '\'/>';

            });
            dtDocketDetails.dtAddData(result.DrsDocketList);
        }
        else {
            isStepValid = false;
        }
        $('[id*="chkDocket"]').each(function () {
            var chkDocket = $(this);
            chkDocket.enable(!isDrsClose);
            $('#chkAllDocket').enable(!isDrsClose);
            var hdnUnderDrs = $('#' + chkDocket.attr('id').replace('chkDocket', 'hdnUnderDrs'));
            if (hdnUnderDrs.val() == 'true') {
                chkDocket.check();
                ManageSelectAll('chkAllDocket', 'C', chkDocket, SelectDocket);
            }
        });
        $.each(result.ErrorList, function (i, item) {

            item.DocketNo = "<input type='hidden' value='" + item.DocketNo + "'  id='lblIssueDocketNo" + i + "'/>" + item.DocketNo;


        });
        dtDocketErrorList.dtAddData(result.ErrorList);
        dtDocketErrorList.removeClass('dataTable')
        if (result.ErrorList.length > 0) {
            $('#dvErrorList').show();
        } else {
            $('#dvErrorList').hide();
        }
    }

}

function SelectDocket() {
    selectedDocketList = [];
    var totalActualWeight = 0;
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var hdnActualWeight = $('#' + chkDocket.attr('id').replace('chkDocket', 'hdnActualWeight'));
        if (chkDocket.IsChecked) {
            selectedDocketList.push($('#' + chkDocket.Id.replace('chkDocket', 'hdnDocketId')).val());
            totalActualWeight = totalActualWeight + parseFloat(hdnActualWeight.val());
        }
    });
    $('#hdnActualWeight').val(totalActualWeight);
    $('#lblActualWeight').text(totalActualWeight);
    CountWeightLoaded();
}

function CountWeightLoaded() {
    var loadedWeight = 0, docketCount = 0, totalPackages = 0, totalLabourAmount = 0;
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var hdnActualWeight = $('#' + chkDocket.attr('id').replace('chkDocket', 'hdnActualWeight'));
        var hdnArrivedPackages = $('#' + chkDocket.attr('id').replace('chkDocket', 'hdnArrivedPackages'));
        var txtLabourAmount = $('#' + chkDocket.attr('id').replace('chkDocket', 'txtLabourAmount'));

        if (chkDocket.is(':checked')) {
            loadedWeight = parseFloat(loadedWeight) + parseFloat(hdnActualWeight.val());
            totalPackages = parseInt(totalPackages) + parseInt(hdnArrivedPackages.val());
            totalLabourAmount = parseInt(totalLabourAmount) + parseInt(txtLabourAmount.val());
            docketCount = parseInt(docketCount) + 1;
        }
        // txtTotalDocket.val(parseInt(docketCount));
        $('#hdnDocketCount').val(parseInt(docketCount));
        $('#hdnTotalPackages').val(totalPackages);
        $('#hdnTotalActualWeight').val(loadedWeight);
        $('#txtWeightLoaded').val(loadedWeight);
        $('#hdnTotalLabourAmount').val(totalLabourAmount);
        //
        var vehicleCapacity = parseFloat($('#txtVehicleCapacity').val());
        if (vehicleCapacity > 0 && loadedWeight > 0)
            $('#txtCapacityUtilizationInPercentage').val(((loadedWeight * 100) / vehicleCapacity).toFixed(2));
        else
            $('#txtCapacityUtilizationInPercentage').val('0');
        if (parseFloat($('#txtCapacityUtilizationInPercentage').val()) > 100)
            $('#chkIsOverLoaded').prop("checked", true);
        else
            $('#chkIsOverLoaded').prop("checked", false);

        if (parseFloat($('#txtCapacityUtilizationInPercentage').val()) > 105) {
            ShowMessage("Capacity Utilization can not be more than 105% of the weight");
            $('#txtCapacityUtilizationInPercentage').val(0);
            $('#chkIsOverLoaded').uncheck();
            $('#hdnDocketCount').val(0);
            $('#hdnTotalPackages').val(0);
            $('#hdnTotalActualWeight').val(0);
            $('#txtWeightLoaded').val(0);
            $("#chkAllDocket").uncheck();
            $('[id*="chkDocket"]').each(function () {
                var chkdocket = $(this);
                if (chkdocket.is(':checked')) {
                    chkdocket.uncheck();
                }
            });
            return false;
        }
        OnOverLoadedChange();
    });

}

function LoadStep5() {
    if (selectedDocketList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one ' + docketNomenclature);
        return false;
    }
    else if (!ValidateModuleDateWithPreviousDocumentDate('dtDocketDetails', 'chkDocket', 'hdnArrivalDate', 'txtDrsDate', drsNomenclature + ' Date')) return false;
    else if ($('#chkIsOverLoaded').is(':checked') && $('#ddlOverLoadedReasonId').val() == "") {
        ShowMessage("Please select OverLoad Reason");
        SetFormFieldFocus('ddlOverLoadedReasonId');

    }
    else if (!chkIsAdhoc.IsChecked) {
        var requestData = { contractId: hdnContractId.val(), matrixTypeId: hdnMatrixTypeId.val(), transportModeId: ddlTransportModeId.val() == '' ? 0 : ddlTransportModeId.val(), routeId: 0, fromCityId: hdnFromCityId.val() == '' ? 0 : hdnFromCityId.val(), toCityId: hdnToCityId.val() == '' ? 0 : hdnToCityId.val(), ftlTypeId: ddlFtlTypeId.val(), vehicleId: ddlVehicleId.val(), totalWeight: $('#txtWeightLoaded').val() };
        AjaxRequestWithPostAndJson(vendorContractUrl + '/GetVendorContractAmount', JSON.stringify(requestData), function (result) {
            txtContractAmount.val(result.ContractAmount);
            txtContractAmount.readOnly(parseFloat(result.ContractAmount) > 0);
            //isStepValid = false;
            if ((result.ContractAmount == 0 || result.ContractAmount == undefined) && useAdhocContract) {
                ShowConfirm('Contract Rate is not exist. Do you want Adhoc Contract?', function () {
                    chkIsAdhoc.check();
                    GotoNextStep();
                },
                    function () {
                        chkIsAdhoc.uncheck();
                    });
            }
            else if ((result.ContractAmount == 0 || result.ContractAmount == undefined)) {
                ShowMessage('Contract Rate is not exist');
                isStepValid = false;
                return false;
            }
            else {
                isStepValid = true;
            }
        }, ErrorFunction, false);
    }
    if (hdnDrsId.val() != 0) GetStep6DetailById();
}

function OnOverLoadedChange() {
    if ($('#chkIsOverLoaded').is(':checked'))
        $('#ddlOverLoadedReasonId').attr("disabled", false);
    else
        $('#ddlOverLoadedReasonId').attr("disabled", true);
    $('#ddlOverLoadedReasonId').val('');
}

function OnVendorTypeChange() {
    if (ddlVendorTypeId.val() == 1)
        $('#divMarketVendorDetail').show();
    else
        $('#divMarketVendorDetail').hide();
    if (ddlVendorTypeId.val() == '3')
        DisableStep(5);
    else
        EnableStep(5);
    var requestData = { vendorTypeId: ddlVendorTypeId.val() };
    AjaxRequestWithPostAndJson(vendorMasterUrl + '/GetVendorListByVendorTypeId', JSON.stringify(requestData), GetVendorNameListSuccess, ErrorFunction, false);

}

function GetVendorNameListSuccess(responseData) {
    BindDropDownList('ddlVendorId', responseData, 'Value', 'Name', '', 'Select Vendor');
}

function OnVendorChange() {
    if (ddlVendorId.val() != "") {
        if (ddlVendorId.val() == 1) {
            $('#divMarketVendorDetail').show();
            $('#divVehicleNo').show();
        }
        else {
            $('#divMarketVendorDetail').hide();
            $('#divVehicleNo').hide();
            $('#txtVendorName').val($("#ddlVendorId option:selected").text());
        }
        var requestData = { vendorId: ddlVendorId.val() };
        AjaxRequestWithPostAndJson(vehicleMasterUrl + '/GetVehicleListByVendorId', JSON.stringify(requestData), GetVehicleListSuccess, ErrorFunction, false);
    }
}

function GetVehicleListSuccess(responseData) {
    BindDropDownList('ddlVehicleId', responseData, 'Value', 'Name', '', 'Select Vehicle');

    if (ddlVendorTypeId.val() != 1 && ddlVendorTypeId.val() != 3)
        ddlVehicleId.append($("<option></option>").val('1').html('Market Vehicle')).val('');
}

function OnVehicleChange() {
    if (ddlVehicleId.val() != '' && ddlVehicleId.val() != null) {
        if (ddlVehicleId.val() != 1) {
            txtVehicleNo.attr('readonly', true);
            txtVehicleNo.val($('#ddlVehicleId :selected').text());
            var requestData = { id: ddlVehicleId.val() };
            AjaxRequestWithPostAndJson(vehicleMasterUrl + '/GetById', JSON.stringify(requestData), OnVehicleDetailSuccess, ErrorFunction, false);
            var requestData = { vehicleId: ddlVehicleId.val() };
            AjaxRequestWithPostAndJson(driverMasterUrl + '/GetDriverDetailByVehicleId', JSON.stringify(requestData), OnDriverDetailSuccess, ErrorFunction, false);
            var requestData = { vehicleId: ddlVehicleId.val(), documentDateTime: txtDrsDate.toDate() };
            AjaxRequestWithPostAndJson(vehicleMasterUrl + '/GetTripsheetByVehicleId', JSON.stringify(requestData), function (result) {
                if (!IsObjectNullOrEmpty(result))
                    BindDropDownList('ddlTripsheetId', result, 'Value', 'Name', '', 'Select Tripsheet');
            }, ErrorFunction, false);
            ResetVehicleDetail(true);
            return false;
        }
        else {
            txtVehicleNo.removeAttr('readonly');
            ResetVehicleDetail(false);
        }
    }
    else {
        txtVehicleNo.attr('readonly', true);
        ResetVehicleDetail(false);
    }
}

function OnDriverDetailSuccess(responseData) {
    if (!IsObjectNullOrEmpty(responseData)) {
        hdnFirstDriverId.val(responseData.DriverId);
        txtFirstDriverName.val(responseData.DriverName);
        txtFirstDriverMobileNo.val(responseData.MobileNo);
        txtFirstDriverLicenseNo.val(responseData.LicenseNo);
        txtFirstDriverLicenseIssueBy.val(responseData.LicenseIssueBy);
        txtFirstDriverLicenseValidityDate.val($.entryDate(responseData.LicenseValidityDate));
    }
    else {
        hdnFirstDriverId.val(0);
        txtFirstDriverName.val('');
        txtFirstDriverMobileNo.val('');
        txtFirstDriverLicenseNo.val('');
        txtFirstDriverLicenseIssueBy.val('');
        txtFirstDriverLicenseValidityDate.val('');
    }
}

function ResetVehicleDetail(isEnable) {
    txtVehicleNo.readOnly(isEnable);
    ddlVehicleTypeId.enable(!isEnable);
    $('#ddlFtlTypeId').enable(!isEnable);
    $('#txtEngineNo').readOnly(isEnable);
    $('#txtChassisNo').readOnly(isEnable);
    $('#txtRcBookNo').readOnly(isEnable);
    $('#txtRegistrationDate').readOnly(isEnable);
    $('#txtPermitValidityDate').readOnly(isEnable);
    $('#txtInsuranceValidityDate').readOnly(isEnable);
    $('#txtFitnessValidityDate').readOnly(isEnable);

    if (!isEnable) {
        txtVehicleNo.val('');
        txtVehicleNo.val('');
        $('#txtRegistrationDate').val('');
        $('#txtPermitValidityDate').val('');
        ddlVehicleTypeId.val('');
        $('#ddlFtlTypeId').val('');
        $('#txtEngineNo').val('');
        $('#txtChassisNo').val('');
        $('#txtRcBookNo').val('');
        $('#txtInsuranceValidityDate').val('');
        $('#txtFitnessValidityDate').val('');
    }
}

function OnVehicleDetailSuccess(responseData) {
    $('#hdnVehicleTypeId').val(responseData.VehicleTypeId);
    ddlVehicleTypeId.val(responseData.VehicleTypeId);
    $('#txtRegistrationDate').val($.entryDate(responseData.MasterVehicleDetail.RegistrationDate));
    $('#hdnFtlTypeId').val(responseData.FtlTypeId);
    $('#ddlFtlTypeId').val(responseData.FtlTypeId);
    $('#txtEngineNo').val(responseData.MasterVehicleDetail.EngineNo);
    $('#txtChassisNo').val(responseData.MasterVehicleDetail.ChasisNo);
    $('#txtRcBookNo').val(responseData.MasterVehicleDetail.RcBookNo);
    $('#txtPermitValidityDate').val($.entryDate(responseData.MasterVehicleDetail.PermitValidityDate));
    $('#txtInsuranceValidityDate').val($.entryDate(responseData.MasterVehicleDetail.InsuranceValidityDate));
    $('#txtFitnessValidityDate').val($.entryDate(responseData.MasterVehicleDetail.FitnessCertificateDate));
    $('#txtVehicleCapacity').val(responseData.Capacity * 1000);
    if (ddlVehicleTypeId != 1) {
        $('#txtVehicleCapacity').readOnly();
    }
}

function OnVehicleTypeChange() {
    if (ddlVehicleTypeId.val() != "") {
        $('#hdnVehicleTypeId').val(ddlVehicleTypeId.val());
        var requestData = { id: ddlVehicleTypeId.val() };
        AjaxRequestWithPostAndJson(vehicleTypeMasterUrl + '/GetById', JSON.stringify(requestData), GetVehicleCapacitySuccess, ErrorFunction, false);
    }
}

function GetVehicleCapacitySuccess(responseData) {
    $('#txtVehicleCapacity').val(responseData.Capacity * 1000);
}

function GetFtlType() {
    if (ddlFtlTypeId.val() != "")
        $('#hdnFtlTypeId').val(ddlFtlTypeId.val());
}

var dtCharges1, dtCharges2, chargeCount;
function GetChargeDetails(list, dtCharge, isOdd) {

    var tableId = (isOdd ? 'dtCharges1' : 'dtCharges2');
    if (dtCharge != null)
        $('#' + tableId).addClass('dataTable');

    if (dtCharge == null)
        dtCharge = LoadDataTable(tableId, false, false, false, null, null, [],
            [
                { title: 'Charge Name', data: 'ChargeDetail', width: 150 },
                { title: 'Charge', data: 'ChargeAmount', width: 60 }
            ]);
    dtCharge.fnClearTable();

    var newList = [];
    if (chargeList.length > 0) {
        $.each(chargeList, function (i, item) {
            if ((isOdd && (((i + 1) % 2) != 0)) || (!isOdd && (((i + 1) % 2) == 0))) {
                item.ChargeDetail = '<input type="hidden" name="ChargeList[' + chargeCount + '].ChargeCode" id="hdnChargeCode' + chargeCount + '" value="' + item.ChargeCode + '"/>' +
                    '<input type="hidden" name="ChargeList[' + chargeCount + '].IsOperator" id="hdnOperator' + chargeCount + '" value="' + (item.IsOperator ? '+' : '-') + '"/>' +
                    '<label class="label" id="lblChargeName' + chargeCount + '">' + item.ChargeName + '(' + (item.IsOperator ? '+' : '-') + ')' + '</label>';
                item.ChargeAmount = '<input class="form-control numeric2" data-val="true" data-val-required="Please enter ' + item.ChargeName + '" ' +
                    'name="ChargeList[' + chargeCount + '].ChargeAmount" value="' + item.ChargeAmount.toFixed(2) + '" id="txtCharge' + chargeCount + '" type="text" />' +
                    '<span data-valmsg-for="ChargeList[' + chargeCount + '].Charge" data-valmsg-replace="true"></span>'
                newList.push(item);
                chargeCount++;
            }
        });
        dtCharge.dtAddData(newList);
    }
    if (isOdd)
        dtCharges1 = dtCharge;
    else
        dtCharges2 = dtCharge;
}

function OnDriver2Change() {
    if (txtSecondDriverName.val() != "") {
        txtSecondDriverMobileNo.attr('readonly', false);
        txtSecondDriverLicenseNo.attr('readonly', false);
        txtSecondDriverLicenseIssueBy.attr('readonly', false);
        txtSecondDriverLicenseValidityDate.attr('readonly', false);
    }
    else {
        txtSecondDriverMobileNo.attr('readonly', true);
        txtSecondDriverMobileNo.attr('tabindex', -1);
        txtSecondDriverLicenseNo.attr('readonly', true);
        txtSecondDriverLicenseNo.attr('tabindex', -1);
        txtSecondDriverLicenseIssueBy.attr('readonly', true);
        txtSecondDriverLicenseIssueBy.attr('tabindex', -1);
        txtSecondDriverLicenseValidityDate.attr('readonly', true);
        txtSecondDriverLicenseValidityDate.attr('tabindex', -1);
    }
}

function OnAdvanceAmountChange() {
    if (txtAdvanceAmount.val() > 0) {
        txtAdvanceAmountLocationCode.attr('readonly', false);
    }
    else {
        txtAdvanceAmountLocationCode.val('');
        txtAdvanceAmountLocationCode.attr('readonly', false);
    }
}

function CalculateOtherCharges() {
    var otherAmount = 0;
    $('[id*="hdnOperator"]').each(function () {
        var hdnOperator = $(this);
        var txtCharge = $('#' + this.id.replace('hdnOperator', 'txtCharge'));
        if (hdnOperator.val() == '+')
            otherAmount = otherAmount + parseFloat(txtCharge.val());
        else
            otherAmount = otherAmount - parseFloat(txtCharge.val());
    });
    $('#hdnOtherAmount').val(otherAmount);
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        chkDocket.enable(true);
        $('#chkAllDocket').enable(true);
    });

    var totalAdvanceAmount = 0;
    if (chkIsMultiAdvApply.IsChecked) {
        $('[id*="txtAdvBalAmount"]').each(function () {
            var txtAdvBalAmount = $(this);
            totalAdvanceAmount = totalAdvanceAmount + parseInt(txtAdvBalAmount.val());
        });
        if (totalAdvanceAmount == parseInt($('#txtAdvanceAmount').val()))
            isStepValid = true;
        else {
            ShowMessage('Total Multi Advance Amount is must equel to Advance Amount ');
            isStepValid = false;
            return false;
        }
    }
    chkIsAdhoc.enable();
}

function GetDriverDetail(objDriverId, isFirstDriver) {
    if (objDriverId.val() != 0) {
        var requestData = { driverId: objDriverId.val() };
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Driver').replace('Action', 'GetById'), JSON.stringify(requestData), function (responseData) {
            if (isFirstDriver) driver = 'First'; else driver = 'Second';
            $('#txt' + driver + 'DriverName').val(responseData.DriverName);
            $('#txt' + driver + 'DriverLicenseNo').val(responseData.LicenseNo);
            $('#txt' + driver + 'DriverLicenseValidityDate').val($.entryDate(responseData.LicenseValidityDate));
            $('#txt' + driver + 'DriverMobileNo').val(responseData.MobileNo);
            $('#txt' + driver + 'DriverLicenseIssueBy').val(responseData.LicenseIssueBy);
            //$('#txt' + driver + 'DriverName').readOnly();
            $('#txt' + driver + 'DriverLicenseNo').readOnly();
            $('#txt' + driver + 'DriverLicenseValidityDate').readOnly();
            $('#txt' + driver + 'DriverMobileNo').readOnly();
            $('#txt' + driver + 'DriverLicenseIssueBy').readOnly();
        }, ErrorFunction, false);
    }
    else
        SetValueForDriver(isFirstDriver);
}

function SetValueForDriver(isFirstDriver) {
    if (isFirstDriver) driver = 'First'; else driver = 'Second';
    //$('#txt' + driver + 'DriverName').val('');
    $('#txt' + driver + 'DriverLicenseNo').val('');
    $('#txt' + driver + 'DriverLicenseValidityDate').val('');
    $('#txt' + driver + 'DriverMobileNo').val('');
    $('#txt' + driver + 'DriverLicenseIssueBy').val('');
    $('#txt' + driver + 'DriverName').readOnly(false);
    $('#txt' + driver + 'DriverLicenseNo').readOnly(false);
    $('#txt' + driver + 'DriverLicenseValidityDate').readOnly(false);
    $('#txt' + driver + 'DriverMobileNo').readOnly(false);
    $('#txt' + driver + 'DriverLicenseIssueBy').readOnly(false);
}
function GetStep2DetailById() {
    var requestData = { drsId: hdnDrsId.val() };
    AjaxRequestWithPostAndJson(drsUrl + '/GetStep2DetailById', JSON.stringify(requestData), function (result) {
        isDrsClose = result.IsDrsClose;
        $('#ManualDrsNo').val(result.ManualDrsNo);
        $('#hdnDrsNo').val(result.DrsNo);
        $('#txtDrsDate').val($.entryDateTime(result.DrsDate));
        ddlVendorTypeId.val(result.VendorTypeId).change();
        ddlVendorId.val(result.VendorId).change();
        $('#txtVendorName').val(result.VendorName);
        $('#txtSupplierName').val(result.SupplierName);
        $('#txtSupplierMobileNo').val(result.SupplierMobileNo);
        $('#chkIsAdhoc').check(result.IsAdhoc);
        ddlVendorTypeId.disable();
        ddlVendorId.disable();
        $('#txtVendorName').readOnly();
        $('#txtSupplierName').readOnly();
        $('#txtSupplierMobileNo').readOnly();
        chkIsSelectCity.check(result.IsSelectCity);
        $("#dvSelectCity").showHide(result.IsSelectCity);
        hdnFromCityId.val(result.FromCityId);
        txtFromCityName.val(result.FromCityName);
        hdnToCityId.val(result.ToCityId);
        txtToCityName.val(result.ToCityName);
    }, ErrorFunction, false);

    var drsId = hdnDrsId.val() == '' ? 0 : hdnDrsId.val();
    var paybasId = ddlPaybasId.val() != '' ? ddlPaybasId.val() : '0';
    var transportModeId = ddlTransportModeId.val() != '' ? ddlTransportModeId.val() : '0';
    var businessTypeId = ddlBusinessTypeId.val() != '' ? ddlBusinessTypeId.val() : '0';
    var isOda = rdODAOnly.IsChecked;
    var docketNos = txtDocketNo.val();
    var vendorId = hdnBaVendorId.val();

    var requestData = { drsId: drsId, fromDate: drDRSDate.startDate, toDate: drDRSDate.endDate, paybasId: paybasId, transportModeId: transportModeId, busnessTypeId: businessTypeId, isOda: isOda, docketNos: docketNos, vendorId: vendorId, isDeliveryThroughSameVehicle: chkIsDeliveryThroughSameVehicle.IsChecked };
    AjaxRequestWithPostAndJson(drsUrl + '/GetDocketListForUpdateDrs', JSON.stringify(requestData), GetDocketListSuccess, ErrorFunction, false);

    //if (hdnDrsId.val() != 0) GetStep3DetailById();
}
function GetStep3DetailById() {
    var requestData = { drsId: hdnDrsId.val() };
    AjaxRequestWithPostAndJson(drsUrl + '/GetStep3DetailById', JSON.stringify(requestData), function (result) {
        ddlVehicleId.val(result.VehicleId);
        txtVehicleNo.val(result.VehicleNo).change();
        ddlVehicleTypeId.val(result.VehicleTypeId).change();
        ddlFtlTypeId.val(result.FtlTypeId).change();
        $('#txtRegistrationDate').val($.entryDate(result.RegistrationDate));
        $('#txtEngineNo').val(result.EngineNo);
        $('#txtChassisNo').val(result.ChassisNo);
        $('#txtRcBookNo').val(result.RcBookNo);
        $('#txtPermitValidityDate').val($.entryDate(result.PermitValidityDate));
        $('#txtInsuranceValidityDate').val($.entryDate(result.InsuranceValidityDate));
        $('#txtFitnessValidityDate').val($.entryDate(result.FitnessValidityDate));
        $('#txtEwayBillNo').val(result.EwayBillNo);
        txtEwayBillIssueDate.val($.entryDate(result.EwayBillIssueDate));
        txtEwayBillExpiryDate.val($.entryDate(result.EwayBillExpiryDate));

    }, ErrorFunction, false);
    if (hdnDrsId.val() != 0) GetStep4DetailById();
}
function GetStep4DetailById() {
    var requestData = { drsId: hdnDrsId.val() };
    AjaxRequestWithPostAndJson(drsUrl + '/GetStep4DetailById', JSON.stringify(requestData), function (result) {
        $('#txtFirstDriverName').val(result.FirstDriverName);
        $('#txtFirstDriverMobileNo').val(result.FirstDriverMobileNo);
        txtFirstDriverLicenseNo.val(result.FirstDriverLicenseNo);
        $('#txtFirstDriverLicenseIssueBy').val(result.FirstDriverLicenseIssueBy);
        $('#txtFirstDriverLicenseValidityDate').val($.entryDate(result.FirstDriverLicenseValidityDate));
        txtSecondDriverName.val(result.SecondDriverName);
        txtSecondDriverMobileNo.val(result.SecondDriverMobileNo);
        txtSecondDriverLicenseNo.val(result.SecondDriverLicenseNo);
        txtSecondDriverLicenseIssueBy.val(result.SecondDriverLicenseIssueBy);
        txtSecondDriverLicenseValidityDate.val($.entryDate(result.SecondDriverLicenseValidityDate));
    }, ErrorFunction, false);
    if (hdnDrsId.val() != 0) GetStep5DetailById();
}
function GetStep5DetailById() {
    var requestData = { drsId: hdnDrsId.val() };
    AjaxRequestWithPostAndJson(drsUrl + '/GetStep5DetailById', JSON.stringify(requestData), function (result) {
        $('#txtStartKm').val(result.StartKm);
        $('#txtEndKm').val(result.EndKm);
        // $('#txtVehicleCapacity').val(result.VehicleCapacity);
        //$('#txtWeightLoaded').val(result.WeightLoaded);
        // $('#txtCapacityUtilizationInPercentage').val(result.CapacityUtilization);
        $('#txtOutgoingRemark').val(result.OutgoingRemark);
        $('#chkIsOverLoaded').check(result.IsOverLoaded);
        $('#ddlOverLoadedReasonId').val(result.OverLoadedReasonId);
        CountWeightLoaded();
    }, ErrorFunction, false);

}
function GetStep6DetailById() {
    var requestData = { drsId: hdnDrsId.val() };
    AjaxRequestWithPostAndJson(drsUrl + '/GetStep6DetailById', JSON.stringify(requestData), function (result) {
        $('#txtDrsAmount').val(result.ContractAmount);
        txtAdvanceAmount.val(result.AdvanceAmount);
        OnAdvanceAmountChange();
        $('#txtBalanceAmountLocationCode').val(result.BalanceLocationCode);
        $('#txtAdvanceAmountLocationCode').val(result.AdvanceLocationCode);
        hdnBalanceAmountLocationId.val(result.BalanceLocationId);
        hdnAdvanceAmountLocationId.val(result.AdvanceLocationId);
    }, ErrorFunction, false);
}

function GetActiveContract() {
    if (!chkIsAdhoc.IsChecked) {
        hdnContractId.val(0);
        hdnMatrixTypeId.val(0);
        isSuccessfull = true;
        var requestData = { vendorId: ddlVendorId.val(), documentDate: txtDrsDate.toDate() };
        AjaxRequestWithPostAndJson(vendorContractUrl + '/GetActiveVendorContract', JSON.stringify(requestData), function (result) {
            if (IsObjectNullOrEmpty(result)) {
                hdnContractId.val(0);
                hdnMatrixTypeId.val(0);
            } else {
                hdnContractId.val(result.ContractId);
                hdnMatrixTypeId.val(result.DrsMatrixTypeId);
            }

            if (hdnContractId.val() == 0 && !useAdhocContract) {
                ShowMessage('Contract is not exist');
                isStepValid = false;
                return false;
            } else if (hdnContractId.val() == 0) {
                ShowConfirm('Contract is not exist. Do you want Adhoc Contract?', function () {
                    chkIsAdhoc.check();
                    GotoNextStep();
                },
                    function () {
                        chkIsAdhoc.uncheck();
                    });
                isStepValid = false;
                return false;
            } else {
                isStepValid = true;
            }
        }, ErrorFunction, false);
    } else {
        hdnContractId.val(0);
        hdnMatrixTypeId.val(0);
        isStepValid = true;
    }
    if (hdnDrsId.val() != 0) GetStep3DetailById();
}
function IsMultiAdvApplyChange() {
    $("#divtabmultiadv").showHide(chkIsMultiAdvApply.is(":checked"));
    if (!chkIsMultiAdvApply.IsChecked) {
        txtAdvanceAmountLocationCode.readOnly(false);
        ReSetGridAdvBalAmnt()

    }
    else {
        txtAdvanceAmountLocationCode.val('');
        txtAdvanceAmountLocationCode.readOnly();
        SetGridAdvBalAmnt()
    }
}