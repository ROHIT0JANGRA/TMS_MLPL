var thcId, txtManualThcNo, txtSupplierName, txtSupplierMobileNo, txtVendorName;
var ruleMasterUrl, useEwayBillDetail, useAdhocContract, UseBillingatVendorDocumentGeneration, allowEmptyVehicle;
var txtKantaWeight, txtSlipNo, txtReasonForWeightLoss, hdnIsBill;
var txtAdvBalAmount, ddlAdvBalLoc;
var ddlTDSRuleId, txtTDSAmount;
$(document).ready(function () {
    SetPageLoad(thcNomenclature, 'Create', 'ddlTransportModeId', '', '');
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetManifestList },
        { StepName: 'Basic Details', StepFunction: GetActiveContract },
        { StepName: 'Vehicle Information', StepFunction: SetPaymentDetail },
        { StepName: 'Driver Information' },
        { StepName: 'Vehicle Depart Information', StepFunction: GetContractAmount },
        { StepName: 'Payment Details', StepFunction: CalculateOtherCharges }
    ], 'Create ' + thcNomenclature);

    InitObjects();
    AttachEvents();
    // $('#btnSubmit').click(ValidateOnSubmit);
    InitGrid('dtAdvBalPmtDtl', false, 2, InitdtAdvBalPmtDtl);
});



function ValidateOnSubmit() {

    if (!ValidateMultiAdvGrid()) return false;
}


function ValidateMultiAdvGrid() {

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
    if (txtAdvBalAmountCheck1 != 0) {
        ShowMessage("Advance amount not matched with multipule advance.");

        return false;

    }

    return true;
}

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
    drManifestDate = InitDateRange('drManifestDate', DateRange.LastWeek);
    hdnThcId = $("#hdnThcId");
    hdnIsBill = $("#hdnIsBill");
    hdnContractId = $('#hdnContractId');
    hdnMatrixTypeId = $('#hdnMatrixTypeId');
    ddlTransportModeId = $('#ddlTransportModeId');
    ddlRouteId = $('#ddlRouteId');
    hdnBookedById = $('#hdnBookedById');
    txtToLocationCode = $('#txtToLocationCode');
    hdnFromLocationId = $('#hdnFromLocationId');
    hdnToLocationId = $('#hdnToLocationId');
    txtTransitTimeHour = $('#txtTransitTimeHour');
    trToLocation = $('#trToLocation');
    txtManifestNo = $('#txtManifestNo');
    txtTotalManifest = $('#txtTotalManifest');
    ddlVendorTypeId = $('#ddlVendorTypeId');
    ddlVendorId = $('#ddlVendorId');
    chkIsAdhoc = $('#chkIsAdhoc');
    txtThcDateTime = $('#txtThcDateTime');
    chkIsSelectCity = $('#chkIsSelectCity');
    chkIsMultiAdvApply = $('#chkIsMultiAdvApply');
    chkIsFuelApply = $('#chkIsFuelApply');  
    hdnFromCityId = $('#hdnFromCityId');
    txtFromCityName = $('#txtFromCityName');
    hdnToCityId = $('#hdnToCityId');
    txtToCityName = $('#txtToCityName');
    chkIsEmptyVehicle = $('#chkIsEmptyVehicle');
    dvEmptyVehicle = $('#dvEmptyVehicle');
    ddlVehicleId = $('#ddlVehicleId');
    ddlVehicleTypeId = $('#ddlVehicleTypeId');
    ddlFtlTypeId = $('#ddlFtlTypeId');
    txtVehicleNo = $('#txtVehicleNo');
    dvTripsheet = $('#dvTripsheet');
    ddlTripsheetId = $('#ddlTripsheetId');
    txtFirstDriverLicenseNo = $('#txtFirstDriverLicenseNo');
    dtManifestDetails = $('#dtManifestDetails');
    lblScheduleDepartureTime = $('#lblScheduleDepartureTime');
    hdnBalanceAmountLocationId = $('#hdnBalanceAmountLocationId');
    txtBalanceAmountLocationCode = $('#txtBalanceAmountLocationCode');
    hdnAdvanceAmountLocationId = $('#hdnAdvanceAmountLocationId');
    txtAdvanceAmountLocationCode = $('#txtAdvanceAmountLocationCode');
    dvTrainDetail = $('#dvTrainDetail');
    dvFlightDetail = $('#dvFlightDetail');
    dvRoadVehicleDetail = $('#dvRoadVehicleDetail');
    fsDriverDetail = $("#fsDriverDetail");
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
    txtVehicleCapacity = $('#txtVehicleCapacity');
    txtCapacityUtilizationInPercentage = $('#txtCapacityUtilizationInPercentage');
    chkIsOverLoaded = $('#chkIsOverLoaded');
    ddlOverLoadedReasonId = $('#ddlOverLoadedReasonId');
    txtEwayBillIssueDate = $('#txtEwayBillIssueDate');
    txtEwayBillExpiryDate = $('#txtEwayBillExpiryDate');
    txtSlipNo = $('#txtSlipNo');
    txtKantaWeight = $('#txtKantaWeight');
    txtReasonForWeightLoss = $('#txtReasonForWeightLoss');

    txtContractAmount = $('#txtContractAmount');
    txtAdvanceAmount = $('#txtAdvanceAmount');
    hdnSavedAdvanceAmount = $('#hdnSavedAdvanceAmount');
    ddlAirline = $('#ddlAirline');
    ddlFlight = $('#ddlFlight');
    ddlAirport = $('#ddlAirport');
    txtAdvBalAmount = $('#txtAdvBalAmount');
    ddlAdvBalLoc = $('#ddlAdvBalLoc');
    $('#txtWeightLoaded').val(0.000).readOnly();
    $('#txtCapacityUtilizationInPercentage').val(0.00).readOnly();
    hdnFromLocationId.val(loginLocationId);
    hdnThcId.val(thcId);
    txtExpectedDepartureDate = $('#txtExpectedDepartureDate');
    txtManualThcNo = $('#txtManualThcNo');
    txtSupplierName = $('#txtSupplierName');
    txtSupplierMobileNo = $('#txtSupplierMobileNo');
    txtVendorName = $('#txtVendorName');
    ddlFuelVendorId = $("#ddlFuelVendorId");
    txtFuelSlipNo = $("#txtFuelSlipNo");
    ddlFuelType = $("#ddlFuelType");
    txtFuelRate = $("#txtFuelRate");
    txtQty = $("#txtQty");
    txtFuelQty = $("#txtFuelQty");
    txtFuelAmount = $("#txtFuelAmount");
    ddlTDSRuleId = $("#ddlTDSRuleId");
    txtTDSAmount = $("#txtTDSAmount");
    dtManifestDetails = LoadDataTable('dtManifestDetails', false, false, false, null, null, [],
        [
            { title: SelectAll.GetChkAll('chkAllManifest', SelectManifest), data: "ManifestId" },
            { title: 'Manifest No', data: 'ManifestNo' },
            { title: 'Manifest Date', data: 'ManifestDate' },
            { title: 'Origin', data: 'OriginCode' },
            { title: 'Next Location', data: 'DestinationCode' },
            { title: 'Total ' + GetFieldCaptionByName(docketFieldList, 'Docket'), data: 'Docket' },
            { title: 'Packages', data: 'Packages' },
            { title: 'Actual Weight', data: 'ActualWeight' }
        ]);

    dtManifestDetails.find('th:eq(1)').css('width', 100);
    dtManifestDetails.find('th:eq(2)').css('width', 100);
    dtManifestDetails.find('th:eq(3)').css('width', 100);
    dtManifestDetails.find('th:eq(4)').css('width', 100);
    dtManifestDetails.find('th:eq(5)').css('width', 100);
    dtManifestDetails.find('th:eq(6)').css('width', 100);
    dtManifestDetails.find('th:eq(7)').css('width', 100);
    
}

function AttachEvents() {
    OnPageLoad();
    ddlTransportModeId.change(OnTransportModeChange).change();
    chkIsSelectCity.change(IsSelectCityChange);
    chkIsEmptyVehicle.change(IsEmptyVehicleChange);
    chkIsMultiAdvApply.change(IsMultiAdvApplyChange);
 

    //chkIsAdhoc.uncheck().disable();

    CityAutoComplete('txtFromCityName', 'hdnFromCityId');
    txtFromCityName.blur(function () { IsCityNameExist(txtFromCityName, hdnFromCityId, 'From City'); });
    CityAutoComplete('txtToCityName', 'hdnToCityId');
    txtToCityName.blur(function () { IsCityNameExist(txtToCityName, hdnToCityId, 'To City'); });
    ddlRouteId.change(OnRouteChange);
    ddlAirport.change(GetAirlineList).change();
    ddlAirline.change(GetFlightList).change();
    ddlFlight.change(function () { txtVehicleNo.val($('#' + this.id + ' option:selected').text()); });
    LocationAutoComplete('txtToLocationCode', 'hdnToLocationId', GetFieldCaptionByName(docketFieldList, 'ToLocation'));
    LocationAutoComplete('txtBalanceAmountLocationCode', 'hdnBalanceAmountLocationId', 'Balance Paid At Location');
    LocationAutoComplete('txtAdvanceAmountLocationCode', 'hdnAdvanceAmountLocationId', 'Advance Paid At Location');
    txtToLocationCode.blur(function () { return IsLocationCodeExist(txtToLocationCode, hdnToLocationId, GetFieldCaptionByName(docketFieldList, 'ToLocation')); });
    DriverAutoCompleteByLocation('txtFirstDriverName', 'hdnFirstDriverId', 'First Driver', false);
    DriverAutoCompleteByLocation('txtSecondDriverName', 'hdnSecondDriverId', 'Second Driver', false);
    txtFirstDriverName.blur(function () { IsDriverNameExistByLocation(txtFirstDriverName, hdnFirstDriverId, 'First Driver', false); return GetDriverDetail(hdnFirstDriverId, true) });
    txtSecondDriverName.blur(function () { IsDriverNameExistByLocation(txtSecondDriverName, hdnSecondDriverId, 'Second Driver', false); return GetDriverDetail(hdnSecondDriverId, false) });
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
    txtSecondDriverName.blur(OnDriver2Change);
    chkIsAdhoc.change(CheckMarketContract);
    var requestData = { thcId: hdnThcId.val() == '' ? 0 : hdnThcId.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetChargeList', JSON.stringify(requestData), function (responseData) {
        chargeList = responseData.OtherChargeList.sort(ComparerTax);
        chargeCount = 0;
        GetChargeDetails(chargeList, dtCharges1, true);
        GetChargeDetails(chargeList, dtCharges2, false);
    }, ErrorFunction, false);

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

    var list = ["4", "5", "6", "7", "8", "9", "10", "11", "12", "13"];
    $('#ddlVendorTypeId option').filter(function () {
        return $.inArray(this.value, list) !== -1
    }).remove();
    /* $("#j-forms").submit(function (e) { // note that it's better to use form Id to select form
         ValidateOnSubmit();
         e.preventDefault(); // here you stop submitting form
        
     }) */
    if (hdnThcId.val() != 0) GetStep1DetailById();
    chkIsFuelApply.change(IsFuelApplyChange);
    txtFuelRate.change(CalculateFuelAmount);
    txtFuelAmount.change(CalculateFuelAmount);
    ddlTDSRuleId.change(CalculatedTDSAmount);
    ddlTDSRuleId.val("3");
    txtContractAmount.blur(CalculatedTDSAmount);
}

function UseEwayBillDetail() {
    var requestData = { moduleId: 5, ruleId: 2 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        useEwayBillDetail = result == 'Y' ? true : false;
    }, ErrorFunction, false);
    if (useEwayBillDetail) {
        $('#dvEwayBillDetails').showHide(useEwayBillDetail);
    }
}
function UseBillingatVendorDocumentGeneration() {
    var requestData = { moduleId: 5, ruleId: 5 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        UseBillingatVendorDocumentGeneration = result == 'Y' ? true : false;
    }, ErrorFunction, false);
    if (UseBillingatVendorDocumentGeneration) {
        $('#dvBillingatVendorDocumentGeneration').showHide(UseBillingatVendorDocumentGeneration);
    }
}
function UseAdhocContract() {
    var requestData = { moduleId: 5, ruleId: 3 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        useAdhocContract = result == 'Y' ? true : false;
    }, ErrorFunction, false);
    if (!useAdhocContract) {
        chkIsAdhoc.uncheck();
        chkIsAdhoc.disable();
    }
}

function AllowEmptyVehicle() {
    var requestData = { moduleId: 5, ruleId: 7 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        allowEmptyVehicle = result == 'Y' ? true : false;
    }, ErrorFunction, false);
    if (!allowEmptyVehicle) {
        chkIsEmptyVehicle.uncheck();
        dvEmptyVehicle.hide();
    }
}

function OnPageLoad() {
    UseEwayBillDetail();
    UseAdhocContract();
    UseBillingatVendorDocumentGeneration();
    AllowEmptyVehicle();
}

function IsSelectCityChange() {
    $("#dvSelectCity").showHide(chkIsSelectCity.is(":checked"));
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

function IsEmptyVehicleChange() {
    $("#dvManifestDetail").showHide(!chkIsEmptyVehicle.is(":checked"));
}

function SetToLocation() {
    if (ddlRouteId.val() == 1)
        trToLocation.showHide(true);
    else
        trToLocation.showHide(true);
}

function GetAirlineList() {
    if (!IsObjectNullOrEmpty(ddlAirport.val())) {
        try {
            var requestData = { airportId: ddlAirport.val() };
            AjaxRequestWithPostAndJson(airportUrl + '/GetAirlineList', JSON.stringify(requestData), function (responseData) {
                $("#ddlAirline").html("");
                $.each(responseData, function (i, item) {
                    ddlAirline.append($('<option></option>').val(item.Value).html(item.Name));
                });
                $('#ddlAirline option').eq(0).before($('<option>', { value: 0, text: 'Select Airline' }));
                ddlAirline.val(0);
            }, ErrorFunction, false);
            return false;
        } catch (e) { alert(e.message); return false }
    }
}

function GetFlightList() {
    try {
        var requestData = { airlineId: ddlAirline.val(), dateTime: txtThcDateTime.val() };
        if (ddlAirline.val() != '' && ddlAirline.val() != null) {
            AjaxRequestWithPostAndJson(airportUrl + '/GetFlightList', JSON.stringify(requestData), function (responseData) {
                $("#ddlFlight").html("");
                $.each(responseData, function (i, item) {
                    ddlFlight.append($('<option></option>').val(item.Value).html(item.Name));
                    lblScheduleDepartureTime.text(item.Description.substring(0, 5));
                });
                $('#ddlFlight option').eq(0).before($('<option>', { value: 0, text: 'Select Flight' }));
                ddlFlight.val(0);
            }, ErrorFunction, false);
            return false;
        }
    } catch (e) { alert(e.message); return false }
}

function OnTransportModeChange() {
    if (ddlTransportModeId.val() != "") {
        var requestData = { transportModeId: ddlTransportModeId.val(), locationId: loginLocationId };
        AjaxRequestWithPostAndJson(routeUrl + '/GetRouteListByTransportModeId', JSON.stringify(requestData), GetRouteListSuccess, ErrorFunction, false);
    }
    else {
        ddlRouteId.empty();
        ddlRouteId.prepend("<option selected='selected' value=''> Select Transport Route </option>");
        ddlRouteId.val();
    }

    if (ddlTransportModeId.val() == 3) {
        dvTrainDetail.css("display", "block");
        dvFlightDetail.css("display", "none");
        dvRoadVehicleDetail.css("display", "none");
        //fsDriverDetail.showHide(false);
        //$("div").remove(".wizard-breadcrumb, .form-footer");
        //InitWizard([
        //    { StepName: 'Criteria', StepFunction: GetManifestList },
        //    { StepName: 'Basic Details', StepFunction: GetActiveContract },
        //    { StepName: 'Vehicle Information' },
        //    { StepName: 'Vehicle Depart Information', StepFunction: GetContractAmount },
        //    { StepName: 'Payment Details', StepFunction: CalculateOtherCharges }
        //]);

        DisableStep(3);
    }
    else if (ddlTransportModeId.val() == 1) {
        dvFlightDetail.css("display", "block");
        dvRoadVehicleDetail.css("display", "none");
        dvTrainDetail.css("display", "none");
        //fsDriverDetail.showHide(false);
        //$("div").remove(".wizard-breadcrumb, .form-footer");
        //InitWizard([
        //    { StepName: 'Criteria', StepFunction: GetManifestList },
        //    { StepName: 'Basic Details', StepFunction: GetActiveContract },
        //    { StepName: 'Vehicle Information' },
        //    { StepName: 'Vehicle Depart Information', StepFunction: GetContractAmount },
        //    { StepName: 'Payment Details', StepFunction: CalculateOtherCharges }
        //]);
        DisableStep(3);
    }
    else if (ddlTransportModeId.val() == 2 || ddlTransportModeId.val() == 4) {
        dvRoadVehicleDetail.css("display", "block");
        dvTrainDetail.css("display", "none");
        dvFlightDetail.css("display", "none");
        //fsDriverDetail.showHide(true);
        //$("div").remove(".wizard-breadcrumb, .form-footer");
        //InitWizard([
        //    { StepName: 'Criteria', StepFunction: GetManifestList },
        //    { StepName: 'Basic Details', StepFunction: GetActiveContract },
        //    { StepName: 'Vehicle Information' },
        //    { StepName: 'Driver Information' },
        //    { StepName: 'Vehicle Depart Information', StepFunction: GetContractAmount },
        //    { StepName: 'Payment Details', StepFunction: CalculateOtherCharges }
        //]);
        EnableStep(3);
    }

    $('.road').showHide(ddlTransportModeId.val() == 2);
    //txtCapacityUtilizationInPercentage.showHide(ddlTransportModeId.val() == 2);
    //chkIsOverLoaded.showHide(ddlTransportModeId.val() == 2);
    //ddlOverLoadedReasonId.showHide(ddlTransportModeId.val() == 2);
}

function OnRouteChange() {
    trToLocation.showHide(ddlRouteId.val() == 1);
    if (ddlRouteId.val() == 1) {
        AddRequired(txtToLocationCode, "Please enter Destination Location");
        AddRequired(txtTransitTimeHour, "Please enter Transition Time");
        AddRange(txtTransitTimeHour, "Transition Time must be greater than 0", 1, 256);
    }
    else {
        RemoveRequired(txtToLocationCode);
        RemoveRequired(txtTransitTimeHour);
        RemoveRange(txtTransitTimeHour);
    }
}


function GetRouteListSuccess(responseData) {
    if (responseData.length > 0) {
        BindDropDownList('ddlRouteId', responseData, 'Value', 'Name', '', 'Select Transport Route');
    }
    else {
        ddlRouteId.empty();
        ddlRouteId.prepend("<option selected='selected' value=''> Select Transport Route </option>");
    }
    /*AddItemDropDownList(ddlRouteId, 0, 1, 'Ad hoc');*/
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

function GetManifestList() {

    var transportModeId = ddlTransportModeId.val() != '' ? ddlTransportModeId.val() : '0';
    var routeId = ddlRouteId.val() != '' ? ddlRouteId.val() : '0';
    isSuccessfull = true;
    if (thcId == '') {
        var requestData = { fromDate: drManifestDate.startDate, toDate: drManifestDate.endDate, transportModeId: transportModeId, routeId: routeId, fromLocationId: loginLocationId, toLocationId: hdnToLocationId.val() == '' ? 0 : hdnToLocationId.val() };
        AjaxRequestWithPostAndJson(thcUrl + '/GetManifestList', JSON.stringify(requestData), GetManifestSuccess, ErrorFunction, false);
    }
    else
        GetStep2DetailById();
}

function GetManifestSuccess(result) {
    if (result.length == 0) {
        isStepValid = false;
        if (allowEmptyVehicle) {
            ShowConfirm('Manifest not found for this Transport Mode or Route. Are you want to declare this as Empty Vehicle?',
                function () {
                    chkIsEmptyVehicle.check().disable();
                    RemoveRequired(txtTotalManifest);
                    GotoNextStep();
                },
                function () {
                    chkIsEmptyVehicle.uncheck().enable();
                    AddRequired(txtTotalManifest, 'Manifest Not Available');
                });
        }
        else {
            chkIsEmptyVehicle.uncheck();
            AddRequired(txtTotalManifest, 'Manifest Not Available');
            ShowMessage('Manifest not found for this Transport Mode or Route.');
            return false;
        }
    }
    else {
        selectedManifestList = [];

        dtManifestDetails.fnClearTable();
        $.each(result, function (i, item) {

            item.ManifestId =
                SelectAll.GetChk('chkAllManifest', 'chkManifestId' + i, 'ThcManifestDetailList[' + i + '].IsChecked', SelectManifest) +
                "<input type='hidden' value='" + item.ManifestId + "' name='ThcManifestDetailList[" + i + "].ManifestId' id='hdnManifestId" + i + "'/>" +
                "<label class='label' for='chkManifestId" + i + "' id='lblManifestId" + i + "'></label>" +
                "<input type='hidden' value='" + item.ManifestDate + "'  id='hdnManifestDate" + i + "'/>" +
                "<input type='hidden' value='" + item.IsThc + "'  id='hdnIsThc" + i + "'/>" +
                "<input type='hidden' value='" + item.IsArrived + "'  id='hdnIsArrived" + i + "'/>" +
                "<input type='hidden' value='" + item.IsThcStockUpdateDone + "'  id='hdnIsThcStockUpdateDone" + i + "'/>" +
                "<input type='hidden' value='" + item.IsHold + "'  id='hdnIsHold" + i + "'/>";

            item.ManifestDate = $.displayDateTime(item.ManifestDate);
            item.Docket = "<input type='text' value='" + item.Docket + "' id='txtDocket" + i + "' name='ThcManifestDetailList[" + i + "].Docket' class='textlabel' style='text-align: right' disabled/>";
            item.Packages = "<input type='text' value='" + item.Packages + "' id='txtPackages" + i + "' name='ThcManifestDetailList[" + i + "].Packages' class='textlabel' style='text-align: right' disabled/>";
            item.ActualWeight = "<input type='text' value='" + item.ActualWeight.toFixed(2) + "' id='txtActualWeight" + i + "' name='ThcManifestDetailList[" + i + "].ActualWeight' class='textlabel' style='text-align: right' disabled/>";

        });
        dtManifestDetails.dtAddData(result);
        txtTotalManifest.val(result.length);
        isStepValid = true;
        $('[id*="chkManifestId"]').each(function () {
            var chkManifestId = $(this);
            var hdnIsThc = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'hdnIsThc'));
            var hdnIsArrived = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'hdnIsArrived'));
            var hdnIsThcStockUpdateDone = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'hdnIsThcStockUpdateDone'));
            var isThcArrive = hdnIsArrived.val() == 'true';
            var isThcStockUpdateDone = hdnIsThcStockUpdateDone.val() == 'true';

            chkManifestId.enable(!isThcStockUpdateDone);
            $('#chkAllManifest').enable(!isThcStockUpdateDone);
            if (hdnIsThc.val() == 'true') {
                chkManifestId.check();
                ManageSelectAll('chkAllManifest', 'C', chkManifestId, SelectManifest);
            }

        });
    }
}

function GetStep1DetailById() {
    var requestData = { thcId: hdnThcId.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetStep1DetailById', JSON.stringify(requestData), function (result) {
        ddlTransportModeId.val(result.TransportModeId);
        OnTransportModeChange();
        ddlRouteId.val(result.RouteId);
        OnRouteChange();
        if (result.RouteId == 1) {
            $('#hdnToLocationId').val(result.ToLocationId);
            txtToLocationCode.val(result.ToLocationCode);
            txtExpectedDepartureDate.val($.entryDateTime(result.ExpectedDepartureDate));
            txtTransitTimeHour.val(result.TransitTimeHour);
        }
    }, ErrorFunction, false);
}

function GetStep2DetailById() {
    var requestData = { thcId: hdnThcId.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetStep2DetailById', JSON.stringify(requestData), function (result) {
        txtManualThcNo.val(result.ManualThcNo);
        txtThcDateTime.val($.entryDateTime(result.ThcDateTime));
        ddlVendorTypeId.val(result.VendorTypeId);
        OnVendorTypeChange();
        ddlVendorId.val(result.VendorId);
        OnVendorChange();
        txtVendorName.val(result.VendorName);
        chkIsAdhoc.check(result.IsAdhoc);
        txtSupplierName.val(result.SupplierName);
        txtSupplierMobileNo.val(result.SupplierMobileNo);
        chkIsSelectCity.check(result.IsSelectCity);
        $("#dvSelectCity").showHide(result.IsSelectCity);
        hdnFromCityId.val(result.FromCityId);
        txtFromCityName.val(result.FromCityName);
        hdnToCityId.val(result.ToCityId);
        txtToCityName.val(result.ToCityName);
        chkIsEmptyVehicle.check(result.IsEmptyVehicle);
        //ddlVendorTypeId.disable();
        //ddlVendorId.disable();
        if (hdnIsBill.val() == "False") {
            ddlVendorTypeId.prop("disabled", false);
            ddlVendorId.prop("disabled", false);
        } else {
            ddlVendorTypeId.prop("disabled", true);
            ddlVendorId.prop("disabled", true);
        }

        $('#txtVendorName').readOnly();
        $('#txtSupplierName').readOnly();
        $('#txtSupplierMobileNo').readOnly();
    }, ErrorFunction, false);
    var transportModeId = ddlTransportModeId.val() != '' ? ddlTransportModeId.val() : '0';
    var routeId = ddlRouteId.val() != '' ? ddlRouteId.val() : '0';

    var requestData = { thcId: thcId == '' ? 0 : thcId, fromDate: drManifestDate.startDate, toDate: drManifestDate.endDate, transportModeId: transportModeId, routeId: routeId, fromLocationId: loginLocationId, toLocationId: hdnToLocationId.val() == '' ? 0 : hdnToLocationId.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetManifestListForUpdateThc', JSON.stringify(requestData), GetManifestSuccess, ErrorFunction, false);
    chkIsAdhoc.check(ddlRouteId.val() == 1).enable(ddlRouteId.val() != 1);
}

function GetStep3DetailById() {
    var requestData = { thcId: hdnThcId.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetStep3DetailById', JSON.stringify(requestData), function (result) {
        if (result.TransportModeId == 3) {
            $('#txtTrainNo').val(result.TrainNo);
            $('#txtTrainName').val(result.TrainName);
        }
        if (result.TransportModeId == 1) {
            $('#ddlAirport').val(result.AirportId).change();
            $('#ddlAirline').val(result.AirlineId).change();
            $('#ddlFlight').val(result.FlightId);
            $('#txtAwbNo').val(result.AwbNo);
        }
        ddlVehicleId.val(result.VehicleId);
        // OnVehicleChange();
        txtVehicleNo.val(result.VehicleNo).change();
        ddlTripsheetId.val(result.TripsheetId);
        ddlVehicleTypeId.val(result.VehicleTypeId).change();
        // OnVehicleTypeChange();
        ddlFtlTypeId.val(result.FtlTypeId);
        $('#txtRegistrationDate').val($.entryDate(result.RegistrationDate));
        $('#txtPermitValidityDate').val($.entryDate(result.PermitValidityDate));
        $('#txtInsuranceValidityDate').val($.entryDate(result.InsuranceValidityDate));
        $('#txtFitnessValidityDate').val($.entryDate(result.FitnessValidityDate));
        $('#txtEngineNo').val(result.EngineNo);
        $('#txtChassisNo').val(result.ChassisNo);
        $('#txtRcBookNo').val(result.RcBookNo);
        $('#txtEwayBillNo').val(result.EwayBillNo);
        $('#txtEwayBillIssueDate').val($.entryDate(result.EwayBillIssueDate));
        $('#txtEwayBillExpiryDate').val($.entryDate(result.EwayBillExpiryDate));

    }, ErrorFunction, false);
}
function GetStep4DetailById() {
    var requestData = { thcId: hdnThcId.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetStep4DetailById', JSON.stringify(requestData), function (result) {
        txtFirstDriverName.val(result.FirstDriverName);
        txtFirstDriverMobileNo.val(result.FirstDriverMobileNo);
        txtFirstDriverLicenseNo.val(result.FirstDriverLicenseNo);
        txtFirstDriverLicenseIssueBy.val(result.FirstDriverLicenseIssueBy);
        txtFirstDriverLicenseValidityDate.val($.entryDate(result.FirstDriverLicenseValidityDate));
        txtSecondDriverName.val(result.SecondDriverName);
        OnDriver2Change();
        txtSecondDriverMobileNo.val(result.SecondDriverMobileNo);
        txtSecondDriverLicenseNo.val(result.SecondDriverLicenseNo);
        txtSecondDriverLicenseIssueBy.val(result.SecondDriverLicenseIssueBy);
        txtSecondDriverLicenseValidityDate.val($.entryDate(result.SecondDriverLicenseValidityDate));


    }, ErrorFunction, false);
    if (hdnThcId.val() != 0) GetStep5DetailById();
}
function GetStep5DetailById() {
    var requestData = { thcId: hdnThcId.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetStep5DetailById', JSON.stringify(requestData), function (result) {
        $('#txtStartKM').val(result.StartKm);
        $('#txtOutgoingSealNo').val(result.OutgoingSealNo);
        $('#txtOutgoingRemark').val(result.OutgoingRemark);
        chkIsOverLoaded.check(result.IsOverLoaded);
        ddlOverLoadedReasonId.val(result.OverLoadedReasonId);
        CountWeightLoaded();
    }, ErrorFunction, false);
}
function Init() {
    return false;
}
function GetStep6DetailById() {

    

    var requestData = { thcId: hdnThcId.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetStep6DetailById', JSON.stringify(requestData), function (result) {
        txtContractAmount.val(result.ContractAmount);
        txtAdvanceAmount.val(result.AdvanceAmount);
        txtKantaWeight.val(result.KantaWeight);
        txtSlipNo.val(result.SlipNo);
        txtReasonForWeightLoss.val(result.ReasonForWeightLoss);
        chkIsFuelApply.prop("checked", result.IsFuelApply);
        chkIsMultiAdvApply.prop("checked", result.IsMultiAdvApply).change();
        $('#ddlFuelVendorId').val(result.FuelVendorId);
        $('#txtFuelSlipNo').val(result.FuelSlipNo);
        $('#txtFuelSlipDate').val($.entryDate(result.FuelSlipDate));
        $('#txtFuelRate').val(result.Rate);
        $('#txtFuelQty').val(result.Quantity);
        $('#txtFuelAmount').val(result.Amount);
        $('#ddlFuelType').val(result.FuelTypeId);
        OnAdvanceAmountChange();
        //OnAdvanceAmountChangeforfuel();
        $('#txtBalanceAmountLocationCode').val(result.BalanceLocationCode);
        $('#txtAdvanceAmountLocationCode').val(result.AdvanceLocationCode);
        $('#hdnAdvanceAmountLocationId').val(result.AdvanceLocationId);
        //  $('#hdnOtherAmount').val(result.OtherAmount);
        $('#chkIsFuelApply').check(result.IsFuelApply);
        if (result.IsFuelApply) {
            $('#divfuel').show();
        } else {
            $('#divfuel').hide();
        }
    }, ErrorFunction, false);
    AjaxRequestWithPostAndJson(thcUrl + '/GetMultiAdvanceDetail', JSON.stringify(requestData), function (result) {

        $.each(result, function (index, value) {
            var txtAdvBalAmount = $('#txtAdvBalAmount' + index);
            var ddlAdvBalLoc = $('#ddlAdvBalLoc' + index);

            txtAdvBalAmount.val(value.AdvBalAmount);
            ddlAdvBalLoc.val(value.AdvBalLoc);

            if ((result.length - 1) > index) {
                AddGridRow('dtAdvBalPmtDtl', false, InitdtAdvBalPmtDtl);
            }
        });
    }, ErrorFunction, false);
}

function SelectManifest() {
    selectedManifestList = [];
    var totalActualWeight = 0
    $('[id*="chkManifestId"]').each(function () {
        var chkManifestId = $(this);
        var txtActualWeight = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'txtActualWeight'));
        if (chkManifestId.IsChecked) {
            selectedManifestList.push($('#' + chkManifestId.Id.replace('chkManifestId', 'hdnManifestId')).val());
            var hdnIsHold = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'hdnIsHold'));
            if (hdnIsHold.val() == 'true') {
                ShowMessage('Manifest contain Hold docket.Please remove hold docket from Manifest.');
                chkManifestId.prop('checked', false);
                chkManifestId.disable();
            }
            totalActualWeight = totalActualWeight + parseFloat(txtActualWeight.val());
        }

    });
    $('#hdnActualWeight').val(totalActualWeight);
    $('#lblActualWeight').text(totalActualWeight);



    CountWeightLoaded();
}

function CountWeightLoaded() {
    var loadedWeight = 0, totalDocket = 0, totalPackages = 0, manifestCount = 0;
    $('[id*="chkManifestId"]').each(function () {
        var chkManifestId = $(this);
        var txtDocket = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'txtDocket'));
        var txtPackages = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'txtPackages'));
        var txtActualWeight = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'txtActualWeight'));
        if (chkManifestId.is(':checked')) {
            manifestCount++;
            loadedWeight = parseFloat(loadedWeight) + parseFloat(txtActualWeight.val());
            totalDocket = parseInt(totalDocket) + parseInt(txtDocket.val());
            totalPackages = parseInt(totalPackages) + parseInt(txtPackages.val());
        }
        $('#hdnTotalManifest').val(manifestCount);
        $('#hdnManifestCount').val(parseInt(manifestCount));
        $('#txtWeightLoaded').val(loadedWeight);
        $('#hdnTotalDocket').val(totalDocket);
        $('#hdnTotalPackages').val(totalPackages);
        $('#hdnTotalActualWeight').val(loadedWeight);

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

function GetContractAmount() {
    isSuccessfull = true;
    isStepValid = true;
    if (!chkIsEmptyVehicle.is(":checked")) {
        if (selectedManifestList.length == 0) {
            isStepValid = false;
            ShowMessage('Please select at least one Manifest');
            return false;
        }
        if (ValidateModuleDateWithPreviousDocumentDate('dtManifestDetails', 'chkManifestId', 'hdnManifestDate', 'txtThcDateTime', thcNomenclature + ' Date')) {
            if ($('#chkIsOverLoaded').is(':checked') && $('#ddlOverLoadedReasonId').val() == "") {
                isStepValid = false;
                ShowMessage("Please select Over Load Reason");
                SetFormFieldFocus('ddlOverLoadedReasonId');
                return false;
            }
        }
    }
    if (!chkIsAdhoc.IsChecked) {

        hdnMatrixTypeId.val(0);

        if (chkIsSelectCity.is(":checked") == true) {
            hdnMatrixTypeId.val(2);
        }

        var requestData = { contractId: hdnContractId.val(), matrixTypeId: hdnMatrixTypeId.val(), transportModeId: ddlTransportModeId.val(), routeId: ddlRouteId.val(), fromCityId: hdnFromCityId.val() == '' ? 0 : hdnFromCityId.val(), toCityId: hdnToCityId.val() == '' ? 0 : hdnToCityId.val(), ftlTypeId: ddlFtlTypeId.val(), vehicleId: ddlVehicleId.val(), totalWeight: $('#txtWeightLoaded').val() };
        AjaxRequestWithPostAndJson(vendorContractUrl + '/GetVendorContractAmount', JSON.stringify(requestData), function (result) {
            if (result.IsUseRouteContractAmount)
                txtContractAmount.blur(CheckValidContractAmount);
            else
                txtContractAmount.off("blur");

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
    CalculatedTDSAmount();
    if (hdnThcId.val() != 0) GetStep6DetailById();
};

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

    dvTripsheet.showHide(false);

    if (ddlVendorTypeId.val() == 2 || ddlVendorTypeId.val() == 3) {
        dvTripsheet.showHide(true);
    }

    //if (ddlVendorTypeId.val() == '3')
    //    DisableStep(5);
    //else
    //    EnableStep(5);
    //if (ddlVendorTypeId.val() == '3')
    //    DisableStep(6);
    //else
    //    EnableStep(6);

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
    CheckMarketContract();

}

function GetVehicleListSuccess(responseData) {
    BindDropDownList('ddlVehicleId', responseData, 'Value', 'Name', '', 'Select Vehicle');
    if (ddlVendorTypeId.val() != 1 && ddlVendorTypeId.val() != 3)
        ddlVehicleId.append($("<option></option>").val('1').html('Market Vehicle'));
}

function OnVehicleChange() {
    if (ddlVehicleId.val() != '' && ddlVehicleId.val() != null) {
        if (ddlVehicleId.val() != 1) {
            txtVehicleNo.readOnly();
            txtVehicleNo.val($('#ddlVehicleId :selected').text());
            var requestData = { id: ddlVehicleId.val() };
            AjaxRequestWithPostAndJson(vehicleMasterUrl + '/GetById', JSON.stringify(requestData), OnVehicleDetailSuccess, ErrorFunction, false);
            var requestData = { vehicleId: ddlVehicleId.val() };
            AjaxRequestWithPostAndJson(driverMasterUrl + '/GetDriverDetailByVehicleId', JSON.stringify(requestData), OnDriverDetailSuccess, ErrorFunction, false);
            var requestData = { vehicleId: ddlVehicleId.val(), documentDateTime: txtThcDateTime.toDate() };
            AjaxRequestWithPostAndJson(vehicleMasterUrl + '/GetTripsheetByVehicleId', JSON.stringify(requestData), function (result) {
                if (!IsObjectNullOrEmpty(result))
                    BindDropDownList('ddlTripsheetId', result, 'Value', 'Name', '', 'Select Tripsheet');
            }, ErrorFunction, false);
            ResetVehicleDetail(true);
            return false;
        }
        else {
            txtVehicleNo.readOnly(false);
            ResetVehicleDetail(false);
        }
    }
    else {
        txtVehicleNo.readOnly();
        ResetVehicleDetail(false);
    }
}




function OnDriver2Change() {
    if (txtSecondDriverName.val() != "") {
        txtSecondDriverMobileNo.readOnly(false);
        txtSecondDriverLicenseNo.readOnly(false);
        txtSecondDriverLicenseIssueBy.readOnly(false);
        txtSecondDriverLicenseValidityDate.readOnly(false);
    }
    else {
        txtSecondDriverMobileNo.readOnly();
        txtSecondDriverLicenseNo.readOnly();
        txtSecondDriverLicenseIssueBy.readOnly();
        txtSecondDriverLicenseValidityDate.readOnly();
    }
}

function OnAdvanceAmountChange() {
    if (txtAdvanceAmount.val() >= 0) {

        chkIsMultiAdvApply.enable();
        chkIsFuelApply.enable();
        if (!chkIsMultiAdvApply.IsChecked) {
            txtAdvanceAmountLocationCode.readOnly(false);
        }
        else {
            txtAdvanceAmountLocationCode.val('');
            txtAdvanceAmountLocationCode.readOnly();
        }
    }
    else {
        txtAdvanceAmountLocationCode.val('');
        txtAdvanceAmountLocationCode.readOnly();
        chkIsMultiAdvApply.uncheck();
        chkIsMultiAdvApply.disable();
        chkIsFuelApply.uncheck();
        chkIsFuelApply.disable();
        IsMultiAdvApplyChange();
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
        $('ddlVehicleTypeId').val('');
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
    $('#ddlVehicleTypeId').val(responseData.VehicleTypeId);
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

function OnDriverDetailSuccess(responseData) {
    if (!IsObjectNullOrEmpty(responseData)) {
        txtFirstDriverName.val(responseData.DriverName);
        txtFirstDriverMobileNo.val(responseData.MobileNo);
        txtFirstDriverLicenseNo.val(responseData.LicenseNo);
        txtFirstDriverLicenseIssueBy.val(responseData.LicenseIssueBy);
        txtFirstDriverLicenseValidityDate.val($.entryDate(responseData.LicenseValidityDate));
    }
    else {
        txtFirstDriverName.val('');
        txtFirstDriverMobileNo.val('');
        txtFirstDriverLicenseNo.val('');
        txtFirstDriverLicenseIssueBy.val('');
        txtFirstDriverLicenseValidityDate.val('');
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

function SetPaymentDetail() {
    if (ddlVendorTypeId.val() == '3')
        if (ddlTripsheetId.val() != '' && ddlTripsheetId.val() != null)
            DisableStep(5);
        else
            EnableStep(5);
    if (hdnIsBill.val() == 'False')
        EnableStep(5);
    else
        DisableStep(5);
    if (hdnThcId.val() != 0) GetStep4DetailById();
}

function GetActiveContract() {

    if (!chkIsAdhoc.IsChecked) {

        hdnContractId.val(0);
        hdnMatrixTypeId.val(0);
        isSuccessfull = true;
        var requestData = { vendorId: ddlVendorId.val(), documentDate: txtThcDateTime.toDate() };
        AjaxRequestWithPostAndJson(vendorContractUrl + '/GetActiveVendorContract', JSON.stringify(requestData), function (result) {
            if (IsObjectNullOrEmpty(result)) {

                hdnContractId.val(0);
                hdnMatrixTypeId.val(0);
            } else {

                hdnContractId.val(result.ContractId);
                hdnMatrixTypeId.val(result.ThcMatrixTypeId);
            }

            if (hdnContractId.val() == 0 && !useAdhocContract) {

                ShowMessage('Contract is not exist');
                isStepValid = false;
                return false;
            }
            else if (hdnContractId.val() == 0) {

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


    if (hdnThcId.val() != 0) GetStep3DetailById();
}

function CheckMarketContract() {
    if (ddlVendorId.val() == 1)
        if (!chkIsAdhoc.IsChecked)
            chkIsAdhoc.check();
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

    //if (hdnThcId.val() != 0) GetStep6DetailById();
    $('[id*="chkManifestId"]').each(function () {
        var chkManifestId = $(this);
        var hdnIsThc = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'hdnIsThc'));
        var hdnIsArrived = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'hdnIsArrived'));
        var isThcArrive = hdnIsArrived.val() == 'true';
        chkManifestId.enable(true);
        $('#chkAllManifest').enable(true);
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
    $('#hdnOtherAmount').val(otherAmount);
    chkIsAdhoc.enable(isStepValid);
    chkIsEmptyVehicle.enable(isStepValid);
    txtAdvanceAmount.readOnly(isStepValid);
}

function CheckValidContractAmount() {
    if (ddlRouteId.val() != 1 && parseFloat(txtContractAmount.val()) != 0) {
        var requestData = { routeId: ddlRouteId.val(), contractAmount: txtContractAmount.val() };
        AjaxRequestWithPostAndJson(routeUrl + '/CheckValidContractAmount', JSON.stringify(requestData), function (result) {
            if (!result) {
                ShowMessage('Contract Amount Not Valid For This Route');
                txtContractAmount.val(0);
                txtContractAmount.focus();
                return false;
            }
        }, ErrorFunction, false);
    }
}

function IsFuelApplyChange() {
    if (chkIsFuelApply.is(":checked")) {
        txtAdvanceAmount.readOnly();
        hdnSavedAdvanceAmount.val(txtAdvanceAmount.val());
        $('#divfuel').show();
        AddRequired(ddlFuelVendorId, "Please select Fuel Vendor");
        AddRequired(txtFuelSlipNo, "Please enter Fuel SlipNo");
        AddRequired(ddlFuelType, "Please select Fuel Type");
        AddRange(txtFuelRate, "Please enter a value between 1 to 999999", 1, 999999);
    }
    else {
        txtAdvanceAmount.readOnly(false);
        txtAdvanceAmount.val(hdnSavedAdvanceAmount.val());
        $('#divfuel').hide();
        RemoveRequired(ddlFuelVendorId);
        RemoveRequired(txtFuelRate);
        RemoveRequired(txtFuelSlipNo);
        RemoveRequired(ddlFuelType);
        txtFuelAmount.val(0);
        txtFuelRate.val(0);
    }
}

function CalculateFuelAmount() {
    var fuelRate = parseFloat(txtFuelRate.val());
    var fuelAmount = parseFloat(txtFuelAmount.val());
    var savedAdvanceAmount = parseFloat(hdnSavedAdvanceAmount.val());

    if ((savedAdvanceAmount - fuelAmount) > 0) {
        txtAdvanceAmount.val(savedAdvanceAmount - fuelAmount);
    }
    else {
        txtFuelAmount.val(0);
        txtAdvanceAmount.val(savedAdvanceAmount);
        ShowMessage('Fuel Amount should not be greater than Advance Amount : ' + txtAdvanceAmount.val());
    }

    if (!isNaN(fuelRate) && !isNaN(fuelAmount)) {
        var qty = fuelAmount / fuelRate; // Corrected calculation
        txtFuelQty.val(qty.toFixed(2));
    } else {
        txtFuelQty.val("0");
    }
}

function CalculatedTDSAmount() {
    var calculatedTDSAmount = 0;
    var requestData = { vendorId: ddlVendorId.val() };
    AjaxRequestWithPostAndJson(vendorMasterUrl + '/GetById', JSON.stringify(requestData), function (result) {
        if (result.MasterVendorDetail.IsTDSApplicable === true) {
            $('#divTDSRule').show();
            var tdsRate = result.MasterVendorDetail.TDSRate || 0;
            if (ddlTDSRuleId.val() === "1" || ddlTDSRuleId.val() === "3") {
                calculatedTDSAmount = (tdsRate * (txtContractAmount.val())) / 100;
            }
            $("#txtTDSAmount").val(calculatedTDSAmount.toFixed(2));
        }
        else {
            $('#divTDSRule').hide();
        }
    });
}
