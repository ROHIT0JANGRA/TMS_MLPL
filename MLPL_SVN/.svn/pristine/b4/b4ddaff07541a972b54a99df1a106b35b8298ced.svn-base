var thcId, txtManualThcNo, txtSupplierName, txtSupplierMobileNo, txtVendorName;
var ruleMasterUrl, useEwayBillDetail, useAdhocContract;
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
});

function InitObjects() {
    drManifestDate = InitDateRange('drManifestDate', DateRange.LastWeek);
    hdnThcId = $("#hdnThcId");
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
    hdnFromCityId = $('#hdnFromCityId');
    txtFromCityName = $('#txtFromCityName');
    hdnToCityId = $('#hdnToCityId');
    txtToCityName = $('#txtToCityName');
    chkIsEmptyVehicle = $('#chkIsEmptyVehicle');
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

    txtContractAmount = $('#txtContractAmount');
    txtAdvanceAmount = $('#txtAdvanceAmount');
    ddlAirline = $('#ddlAirline');
    ddlFlight = $('#ddlFlight');
    ddlAirport = $('#ddlAirport');

    $('#txtWeightLoaded').val(0.000).readOnly();
    $('#txtCapacityUtilizationInPercentage').val(0.00).readOnly();
    hdnFromLocationId.val(loginLocationId);
    hdnThcId.val(thcId);
    txtExpectedDepartureDate = $('#txtExpectedDepartureDate');
    txtManualThcNo = $('#txtManualThcNo');
    txtSupplierName = $('#txtSupplierName');
    txtSupplierMobileNo = $('#txtSupplierMobileNo');
    txtVendorName = $('#txtVendorName');
    dtManifestDetails = LoadDataTable('dtManifestDetails', false, false, false, null, null, [],
        [
            { title: SelectAll.GetChkAll('chkAllManifest', SelectManifest), data: "ManifestId" },
            { title: 'Manifest No', data: 'ManifestNo' },
            { title: 'Manifest Date', data: 'ManifestDate' },
            { title: 'Origin', data: 'OriginCode' },
            { title: 'Next Location', data: 'DestinationCode' },
            { title: 'Total ' + GetFieldCaptionByName(docketFieldList, 'Docket'), data: 'Docket' },
            { title: 'Packages', data: 'Packages' },
            { title: 'Actual Weight', data: 'ActualWeight' },
            { title: 'Vendor Weight', data: 'VendorWeight' }
        ]);

    dtManifestDetails.find('th:eq(1)').css('width', 100);
    dtManifestDetails.find('th:eq(2)').css('width', 100);
    dtManifestDetails.find('th:eq(3)').css('width', 100);
    dtManifestDetails.find('th:eq(4)').css('width', 100);
    dtManifestDetails.find('th:eq(5)').css('width', 100);
    dtManifestDetails.find('th:eq(6)').css('width', 100);
    dtManifestDetails.find('th:eq(7)').css('width', 100);
    dtManifestDetails.find('th:eq(8)').css('width', 100);
    dtManifestDetails.find('th:eq(9)').css('width', 100);
}

function AttachEvents() {
    OnPageLoad();
    ddlTransportModeId.change(OnTransportModeChange);
    chkIsSelectCity.change(IsSelectCityChange);
    chkIsEmptyVehicle.change(IsEmptyVehicleChange);
    chkIsAdhoc.uncheck().disable();

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

function OnPageLoad() {
    if (hdnThcId.val() != 0) GetStep1DetailById();
    UseEwayBillDetail();
    UseAdhocContract();
}

function IsSelectCityChange() {
    $("#dvSelectCity").showHide(chkIsSelectCity.is(":checked"));
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
    if (ddlAirport.val() != '') {
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
    AddItemDropDownList(ddlRouteId, 0, 1, 'Ad hoc');
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
                "<input type='hidden' value='" + item.IsHold + "'  id='hdnIsHold" + i + "'/>";

            item.ManifestDate = $.displayDateTime(item.ManifestDate);
            item.Docket = "<input type='text' value='" + item.Docket + "' id='txtDocket" + i + "' name='ThcManifestDetailList[" + i + "].Docket' class='textlabel' style='text-align: right' disabled/>";
            item.Packages = "<input type='text' value='" + item.Packages + "' id='txtPackages" + i + "' name='ThcManifestDetailList[" + i + "].Packages' class='textlabel' style='text-align: right' disabled/>";
            item.ActualWeight = "<input type='text' value='" + item.ActualWeight.toFixed(2) + "' id='txtActualWeight" + i + "' name='ThcManifestDetailList[" + i + "].ActualWeight' class='form-control' style='text-align: right' />";
           // item.VendorWeight = "<input type='text' value='" + item.ActualWeight + "' id='txtVendorWeight" + i + "' name='ThcManifestDetailList[" + i + "].VendorWeight' class='textlabel'  />";
            //item.VendorWeight = "<input type='text' value='" + item.ActualWeight.toFixed(2) + "' id='txtVendorWeight" + i + "' name='ThcManifestDetailList[" + i + "].VendorWeight' class='textlabel' style='text-align: right' disabled/>";
        });
        dtManifestDetails.dtAddData(result);
        txtTotalManifest.val(result.length);
        isStepValid = true;
        $('[id*="chkManifestId"]').each(function () {
            var chkManifestId = $(this);
            var hdnIsThc = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'hdnIsThc'));
            var hdnIsArrived = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'hdnIsArrived'));
            var isThcArrive = hdnIsArrived.val() == 'true';

            chkManifestId.enable(!isThcArrive);
            $('#chkAllManifest').enable(!isThcArrive);
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
        ddlVendorTypeId.disable();
        ddlVendorId.disable();
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
        // ddlTripsheetId.val(result.TripsheetId);
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
function GetStep6DetailById() {
    var requestData = { thcId: hdnThcId.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetStep6DetailById', JSON.stringify(requestData), function (result) {
        txtContractAmount.val(result.ContractAmount);
        txtAdvanceAmount.val(result.AdvanceAmount);
        OnAdvanceAmountChange();
        $('#txtBalanceAmountLocationCode').val(result.BalanceLocationCode);
        $('#txtAdvanceAmountLocationCode').val(result.AdvanceLocationCode);
        //  $('#hdnOtherAmount').val(result.OtherAmount);
    }, ErrorFunction, false);
}

function SelectManifest() {
    selectedManifestList = [];

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
        }

    });
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
    var TotalWeight = 0, Weight=0;

    $('[id*="chkManifestId"]').each(function () {
        var chkManifestId = $(this);
        var txtVendorWeight = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'txtVendorWeight'));

        if (txtVendorWeight.val() == "")
        {
            Weight = 0;
        }
        else
        {
            Weight = parseFloat(txtVendorWeight.val());
        }

        if (chkManifestId.is(":checked") == true) {
            TotalWeight = parseFloat(TotalWeight) + parseFloat(Weight)
        }
    });

    $('#txtWeightLoaded').val(TotalWeight)

    

    if (!chkIsAdhoc.IsChecked) {

        hdnMatrixTypeId.val(0);

        if (chkIsSelectCity.is(":checked")== true) {
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

    dvTripsheet.showHide(ddlVendorTypeId.val() == 3);
    if (ddlVendorTypeId.val() == '3')
        DisableStep(5);
    else
        EnableStep(5);
    if (ddlVendorTypeId.val() == '3')
        DisableStep(6);
    else
        EnableStep(6);
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
    if (ddlVendorTypeId.val() != 1)
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
    if (txtAdvanceAmount.val() > 0) {
        txtAdvanceAmountLocationCode.readOnly(false);
    }
    else {
        txtAdvanceAmountLocationCode.val('');
        txtAdvanceAmountLocationCode.readOnly();
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
        if (ddlTripsheetId.val() != '')
            DisableStep(5);
        else
            EnableStep(5);
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
                //ShowConfirm('Contract is not exist. Do you want Adhoc Contract?', function () {
                //    chkIsAdhoc.check();
                //    GotoNextStep();
                //},
                //    function () {
                //        chkIsAdhoc.uncheck();
                //    });
                ShowMessage('Contract is not exist');
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
    chkIsAdhoc.enable();
    chkIsEmptyVehicle.enable();
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