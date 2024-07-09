var ddlTripsheetAction, ddlsearchBy, txtTripsheetNo, dtTripsheetDetailList, drTripsheetDate, TripsheetUrl, selectedTripsheetId, fuelMasterUrl, currentDate,
    txtClosingKm, dtThcFieldDetail, dtThcTrackingDetail,  dtAdvanceDetail, dtFuelSlipDetail, dtVehicleLogDetail, dateTimeFormat, categoryId, subCategoryId, currentDateTime, lblCategory, lblSubCategory,
     txtFromCity, txtToCity, hdnFromCityId, hdnToCityId, hdnTripsheetNoId;
var dtOilExpenses, TripsheetAction, searchBy,THCbillGenerated;

$(document).ready(function () {
    SetPageLoad('Tripsheet', 'Close', '', '', '');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetTripsheetList },
        { StepName: 'Tripsheet List', StepFunction: LoadStep3 },
        { StepName: 'Tripsheet Details', StepFunction: RemapKm },
        //{ StepName: 'Vehicle Log Detail' },
        { StepName: 'Oil Expenses' },
        { StepName: 'Enroute Expenses' },
        { StepName: 'Verifying Authorities' }
    ], 'Close');

    InitObjects();
    AttachEvents();
});

function InitObjects() {
    lblCategory = $('#lblCategory');
    lblSubCategory = $('#lblSubCategory');
    ddlTripsheetAction = $('#ddlTripsheetAction');
    ddlsearchBy = $('#ddlsearchBy');
    txtTripsheetNo = $('#txtTripsheetNo');
    dtOilExpenses = $('#dtOilExpenses');
    hdnTripsheetNoId = $('#hdnTripsheetNoId');

    dtTripsheetDetailList = LoadDataTable('dtTripsheetDetailList', false, false, false, null, null, [],
              [
                  { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                  { title: 'Tripsheet No', data: 'TripsheetNo' },
                  { title: 'Tripsheet Date', data: 'TripsheetDate' },
                  { title: 'Driver', data: 'FirstDriverName' },
                  { title: 'Vehicle No', data: 'VehicleNo' }

              ]);
    dtThcFieldDetail = LoadDataTable('dtThcFieldDetail', false, false, false, null, null, [],
    [
        { title: 'Thc No', data: 'ThcNo' },
        { title: 'Thc Date', data: 'ThcDate' },
        { title: 'From Location', data: 'FromLocation' },
        { title: 'To Location', data: 'ToLocation' },
        { title: 'Start Km', data: 'StartKm' },
        { title: 'End Km', data: 'EndKm' },
        { title: 'Total Rum Km', data: 'TotalRumKm' },
        { title: 'Load Type', data: 'LoadType' }
    ]);

    dtThcTrackingDetail = LoadDataTable('dtThcTrackingDetail', false, false, false, null, null, [],
    [
        { title: 'From City', data: 'FromCity' },
        { title: 'To City', data: 'ToCity' },
        { title: 'Dated', data: 'DatedDes' },
        { title: 'Start KM', data: 'StartKM' },
        { title: 'End KM', data: 'EndKM' },
        { title: 'Total Run KM', data: 'TotalRunKM' },
        { title: 'Load Type', data: 'LoadType' },
        { title: 'Customer Name', data: 'CustomerName' },
        { title: 'LR Details', data: 'LRDetails' },
        { title: 'Remark', data: 'Remark' }
    ]);

    dtAdvanceDetail = LoadDataTable('dtAdvanceDetail', false, false, false, null, null, [],
              [
                  { title: 'Place', data: 'Place' },
                  { title: 'Advance Date', data: 'AdvanceDate' },
                  { title: 'Amount', data: 'Amount' },
                  { title: 'Branch Name', data: 'BranchName' },
                  { title: 'Advance Paid By', data: 'PaidBy' }
              ]);

    dtFuelSlipDetail = LoadDataTable('dtFuelSlipDetail', false, false, false, null, null, [],
              [
                  { title: 'Vendor', data: 'FuelVendorName' },
                  { title: 'FuelSlip No.', data: 'SlipNo' },
                  { title: 'FuelSlip Date', data: 'FuelSlipDate' },
                  { title: 'Quantity', data: 'Quantity' },
                  { title: 'Rate', data: 'Rate' },
                  { title: 'Amount', data: 'Amount' }
              ]);

    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek);
    txtClosingKm = $('#txtClosingKm');
    dtVehicleLogDetail = $('#dtVehicleLogDetail');

    RegisterValidation();
}

function AttachEvents() {
    ddlTripsheetAction.change(OnTripsheetActionChange);
    ddlsearchBy.change(TripsheetAutoPopulate);
    OnTripsheetActionChange();
    txtClosingKm.blur(CountTotalKm);
    CountTotalKm();
    InitGrid('dtOilExpenses', false, 11, InitAutoComplete);
    InitGrid('dtThcDetail', false, 8, InitAutoCompleteThcDetail);
    InitGrid('dtRouteExpenses', false, 6, Init);
    InitGrid('dtVehicleLogDetail', false, 11, InitAutoCompleteForVehicleLogDetail);
    AddRequired($('#txtOpCloseDateTime'), 'Please enter Op Close Date');

    TripsheetAutoPopulate();
    VehicleAutoCompleteByLForTripsheetCloser('txtTripsheetNo', 'hdnTripsheetNoId');
}
function TripsheetAutoPopulate()
{
    hdnTripsheetNoId.val('');
    txtTripsheetNo.val('');
    TripsheetAction = ddlTripsheetAction.val();
    searchBy = ddlsearchBy.val();
    hdnTripsheetNoId.val(0);
    VehicleAutoCompleteByLForTripsheetCloser('txtTripsheetNo', 'hdnTripsheetNoId');
}

function OnTripsheetActionChange() {

    $('#divFinCloseDate').showHide(ddlTripsheetAction.val() == 2);
    $('#divOpCloseDate').showHide(ddlTripsheetAction.val() != 3);

    if (ddlTripsheetAction.val() == 3)
    {
        RemoveRequired($('#txtOpCloseDateTime'));
    }

    if (ddlTripsheetAction.val() == 2)
        AddRequired($('#txtFinCloseDateTime'), 'Please select Financial Close Date');
    else
        RemoveRequired($('#txtFinCloseDateTime'));


    TripsheetAutoPopulate();
}

function GetTripsheetList() {
    var requestData = {
        tripsheetAction: ddlTripsheetAction.val(), searchBy: ddlsearchBy.val(), TripsheetNo: txtTripsheetNo.val(),
        fromDate: drTripsheetDate.startDate, toDate: drTripsheetDate.endDate
    };
    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetTripsheetListForClose', JSON.stringify(requestData), function (result) {
        dtTripsheetDetailList.fnClearTable();
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.ManualTripsheetNo = '<div class="clearfix">' +
                                   '<label class="radio">' +
                                       '<input type="radio" name=\'Tripsheet\' value=\'' + item.TripsheetId + '\' onclick="GetTripsheetDetail(this)" tabindex="0" id="chkManualTripsheetNo' + i + '"/><i></i>' +
                                         '<label for="chkManualTripsheetNo' + i + '">' + item.ManualTripsheetNo + '</label>' +
                                   '</label>' +
                               '</div>';
                item.TripsheetDate = $.displayDate(item.TripsheetDate);
            });
            dtTripsheetDetailList.dtAddData(result);
            selectedTripsheetId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

function GetTripsheetDetail(rd) {
    selectedTripsheetId = rd.value;
}

function LoadStep3() {
    isStepValid = selectedTripsheetId != 0;
    if (selectedTripsheetId == 0) {
        ShowMessage('Please select Tripsheet');
        return false;
    }
    $('#hdnTripsheetId').val(selectedTripsheetId);
    var requestData = { TripsheetId: selectedTripsheetId };
    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetById', JSON.stringify(requestData), GetTripsheetDetailSuccess, ErrorFunction, false);
    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetAdvanceDetail', JSON.stringify(requestData), function (result) {
        dtAdvanceDetail.fnClearTable();
        if (result.length == 0) {
            $('#dvAdvanceDetail').hide();
        }
        else {
            $.each(result, function (i, item) {
                item.AdvanceDate = $.displayDate(item.AdvanceDate);

            });
            dtAdvanceDetail.dtAddData(result);
        }
    }, ErrorFunction, false);

    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetFuelSlipDetail', JSON.stringify(requestData), function (result) {
        dtFuelSlipDetail.fnClearTable();
        if (result.length == 0) {
            $('#dvFuelSlipDetail').hide();
        }
        else {
            $.each(result, function (i, item) {
                item.FuelSlipDate = $.displayDate(item.FuelSlipDate);

            });
            dtFuelSlipDetail.dtAddData(result);
        }
    }, ErrorFunction, false);


    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetDetailListForClosureRCM', JSON.stringify(requestData), function (result) {
        ResetTableRow('dtVehicleLogDetail', result.VehicleLogDetail, AssignVehicleLogDetails);
        ResetTableRow('dtRouteExpenses', result.EnRouteExpenses, AssignEnrouteExpenseDetails);
        ResetTableRow('dtOilExpenses', result.OilExpenses, AssignOilExpenseDetails);
        ResetTableRow('dtThcDetail', result.ThcDetail, AssignThcDetails);
        ResetTableRow('dtThcFieldDetail', result.ThcFieldDetail, AssignThcFieldDetails);
        ResetTableRow('dtThcTrackingDetail', result.ThcTrackingDetail, AssignThcTrackingDetails);

        if (THCbillGenerated == "Y") {
            $('#dtThcDetail').find("*").attr("disabled", true);
        }
        else {
            $('#dtThcDetail').find("*").attr("disabled", false);
        }


    }, ErrorFunction, false);

    return false;
}

function AssignVehicleLogDetails(vehicleLogDetails) {
    $('#dtVehicleLogDetail').find('[id*="txtFrom"]').each(function (i) {
        var txtFrom = $(this);
        var txtTo = $('#' + txtFrom.Id.replace('txtFrom', 'txtTo'));
        var txtStartDateTime = $('#' + txtFrom.Id.replace('txtFrom', 'txtStartDateTime'));
        var txtStartKm = $('#' + txtFrom.Id.replace('txtFrom', 'txtStartKm'));
        var txtEndKm = $('#' + txtFrom.Id.replace('txtFrom', 'txtEndKm'));
        var txtKmRun = $('#' + txtFrom.Id.replace('txtFrom', 'txtKmRun'));
        var ddlCategory = $('#' + txtFrom.Id.replace('txtFrom', 'ddlCategory'));
        //var txtProductName = $('#' + txtFrom.Id.replace('txtFrom', 'txtProductName'));
        var ddlProductId = $('#' + txtFrom.Id.replace('txtFrom', 'ddlProductId'));
        var txtEndDateTime = $('#' + txtFrom.Id.replace('txtFrom', 'txtEndDateTime'));
        var txtTransitTime = $('#' + txtFrom.Id.replace('txtFrom', 'txtTransitTime'));
        var txtIdleTime = $('#' + txtFrom.Id.replace('txtFrom', 'txtIdleTime'));

        //if (vehicleLogDetails[i] != null) {

        //    txtFrom.val(vehicleLogDetails[i].From);
        //    txtTo.val(vehicleLogDetails[i].To);

        //    if(txtStartDateTime.val() == "")
        //    {
        //        txtStartDateTime.val($.entryDateTime(vehicleLogDetails[i].StartDateTime));
        //   }

        //    txtStartKm.val(vehicleLogDetails[i].StartKm);
        //    txtEndKm.val(vehicleLogDetails[i].EndKm);
        //    txtKmRun.val(vehicleLogDetails[i].EndKm - vehicleLogDetails[i].StartKm);
        //    ddlCategory.val(vehicleLogDetails[i].Category);
        //    //txtProductName.val(vehicleLogDetails[i].ProductName);
        //    ddlProductId.val(vehicleLogDetails[i].ProductId);

        //    if (txtEndDateTime.val() == "")
        //    {
        //        txtEndDateTime.val($.entryDateTime(vehicleLogDetails[i].EndDateTime));
        //    }

        //    if (txtTransitTime.val() == "") {
        //        txtTransitTime.val(vehicleLogDetails[i].TransitTime);
        //    }

        //    if (txtIdleTime.val() == "") {
        //        txtIdleTime.val(vehicleLogDetails[i].IdleTime);

        //    }

            
            
        //}
    });
}
function AssignEnrouteExpenseDetails(enrouteExpenseDetails) {
    $('#dtRouteExpenses').find('[id*="hdnChargeCode"]').each(function (i) {
        var hdnChargeCode = $(this);
        var txtChargeName = $('#' + hdnChargeCode.Id.replace('hdnChargeCode', 'txtChargeName'));
        var txtSpentAmount = $('#' + hdnChargeCode.Id.replace('hdnChargeCode', 'txtSpentAmount'));
        var txtEnRouteBillNo = $('#' + hdnChargeCode.Id.replace('hdnChargeCode', 'txtEnRouteBillNo'));
        var txtEnRouteExpenseBillDate = $('#' + hdnChargeCode.Id.replace('hdnChargeCode', 'txtEnRouteExpenseBillDate'));
        var txtEnRouteRemarks = $('#' + hdnChargeCode.Id.replace('hdnChargeCode', 'txtEnRouteRemarks'));

        if (enrouteExpenseDetails[i] != null) {
            txtEnRouteRemarks.val(enrouteExpenseDetails[i].Remarks);
            txtEnRouteBillNo.val(enrouteExpenseDetails[i].BillNo);
            hdnChargeCode.val(enrouteExpenseDetails[i].ChargeCode);
            txtChargeName.val(enrouteExpenseDetails[i].ChargeName).blur();
            txtSpentAmount.val(enrouteExpenseDetails[i].SpentAmount);
            txtEnRouteExpenseBillDate.val($.entryDate(enrouteExpenseDetails[i].txtEnRouteExpenseBillDate));
            txtSpentAmount.blur();
        }
    });
}
function AssignOilExpenseDetails(oilExpenseDetails) {
    $('#dtOilExpenses').find('[id*="hdnPetrolPumpId"]').each(function (i) {
        var hdnPetrolPumpId = $(this);
        var txtPetrolPumpName = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtPetrolPumpName'));
        var txtKm = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtKm'));
        var txtBillNo = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtBillNo'));
        var txtBillDate = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtBillDate'));
        var txtFuelQuantity = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtFuelQuantity'));
        var txtFuelRate = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtFuelRate'));
        var txtAmount = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtAmount'));
        var txtApprovedAmount = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtApprovedAmount'));
        var ddlPaidBy = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'ddlPaidBy'));
        var txtRemarks = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtRemarks'));

        if (oilExpenseDetails[i] != null) {
            hdnPetrolPumpId.val(oilExpenseDetails[i].PetrolPumpId);
            txtKm.val(oilExpenseDetails[i].Km);
            txtBillNo.val(oilExpenseDetails[i].BillNo);
            txtBillDate.val($.entryDate(oilExpenseDetails[i].BillDate));
            txtFuelQuantity.val(oilExpenseDetails[i].FuelQuantity);
            txtFuelRate.val(oilExpenseDetails[i].FuelRate);
            txtAmount.val(oilExpenseDetails[i].Amount);
            txtApprovedAmount.val(oilExpenseDetails[i].ApprovedAmount);
            ddlPaidBy.val(oilExpenseDetails[i].PaidBy);
            txtRemarks.val(oilExpenseDetails[i].Remarks);
            txtFuelQuantity.blur();
            txtPetrolPumpName.val(oilExpenseDetails[i].PetrolPumpName).blur();
        }
    });
}

function AssignThcDetails(thcDetail) {


    $('#dtThcDetail').find('[id*="hdnFromCityId"]').each(function (i) {
        var hdnFromCityId = $(this);
        var txtFromCity = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtFromCity'));
        var hdnToCityId = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'hdnToCityId'));
        var txtToCity = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtToCity'));
        var txtThcNo = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtThcNo'));
        var txtThcDate = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtThcDate'));
        var txtFreightAmount = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtFreightAmount'));
        var txtLabourCharge = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtLabourCharge'));
        var txtOtherCharge = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtOtherCharge'));
        var txtTotalAmt = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtTotalAmt'));

        if (thcDetail[i] != null) {
            hdnFromCityId.val(thcDetail[i].FromCityId);
            hdnToCityId.val(thcDetail[i].ToCityId);
            txtFromCity.val(thcDetail[i].FromCity);
            txtToCity.val(thcDetail[i].ToCity);
            txtThcNo.val(thcDetail[i].ThcNo);
            txtThcDate.val($.entryDate(thcDetail[i].ThcDate));
            txtFreightAmount.val(thcDetail[i].FreightAmount);
            txtLabourCharge.val(thcDetail[i].LabourCharge);
            txtOtherCharge.val(thcDetail[i].OtherCharge);
            txtTotalAmt.val(thcDetail[i].TotalAmount);
        }
    });
}

function AssignThcTrackingDetails(thcTrackingDetail) {
    dtThcTrackingDetail.fnClearTable();

    if (thcTrackingDetail.length == 0) {
        $('#dvThcTrackingDetail').hide();
    }
    else {
        $.each(thcTrackingDetail, function (i, item) {

            if (item.StartKM == 0)
                item.StartKM = "";

            if (item.EndKM == 0)
                item.EndKM = "";
        });

        dtThcTrackingDetail.dtAddData(thcTrackingDetail);
    }
}

function AssignThcFieldDetails(thcFieldDetail) {
    dtThcFieldDetail.fnClearTable();

    if (thcFieldDetail.length == 0) {
        $('#dvThcFieldDetail').hide();
    }
    else {
        $.each(thcFieldDetail, function (i, item) {

            item.ThcDate = $.displayDate(item.ThcDate);

        });
        dtThcFieldDetail.dtAddData(thcFieldDetail);
    }
}


function GetTripsheetDetailSuccess(responseData) {
    $('#lblTripsheetNo').text(responseData.TripsheetNo);
    $('#hdnTripsheetNo').val(responseData.TripsheetNo);
    $('#lblManualTripsheetNo').text(responseData.ManualTripsheetNo);
    $('#lblTripsheetDate').text($.displayDateTime(responseData.TripsheetDate));
    $('#lblVehicleType').text(responseData.VehicleType);
    $('#lblStartLocationCode').text(responseData.StartLocationCode);
    $('#lblEndLocationCode').text(responseData.EndLocationCode);
    $('#lblCategory').text(responseData.Category);
    $('#lblSubCategory').text(responseData.SubCategory);
    $('#lblExternalUsageCategory').text(responseData.ExternalUsageCategory);
    $('#lblFromCity').text(responseData.FromCity);
    $('#lblToCity').text(responseData.ToCity);

    if (responseData.Route == null) {
        $('#lblRoute').text("Not Applicable");
    }
    else {
        $('#lblRoute').text(responseData.Route);
    }
    $('#lblVehicleMode').text(responseData.VehicleMode);
    $('#hdnVehicleId').val(responseData.VehicleId);
    $('#lblVehicleNo').text(responseData.VehicleNo);
    $('#lblDriverName').text(responseData.DriverName);
    $('#lblDriverLicenseNo').text(responseData.DriverLicenseNo);
    $('#lblDriverLicenseValidityDate').text($.displayDate(responseData.DriverLicenseValidityDate));
    $('#lblStartKm').text(responseData.StartKm);
    $('#hdnStartKm').val(responseData.StartKm);
    $('#txtStartKm0').val(responseData.StartKm);
    $('#hdnTripsheetDate').val($.entryDate(responseData.TripsheetDate));

    if (responseData.OpCloseDateTime != null) {
        $('#txtOpCloseDateTime').val($.entryDateTime(responseData.OpCloseDateTime)).readOnly();
        AddRequired($('#txtFinCloseDateTime'), 'Please enter Financial Close Date');
    }
    else {
        $('#txtOpCloseDateTime').val('').readOnly(false);
        RemoveRequired($('#txtFinCloseDateTime'));
    }
    RegisterValidation();

    if (responseData.EndKm != null && responseData.EndKm > 0)
    {
        if(ddlTripsheetAction.val() != 1)
        {
            $('#txtClosingKm').val(responseData.EndKm).readOnly();
        }
    }


    $('#txtPreparedBy').val(responseData.PreparedBy);
    $('#txtCheckedBy').val(responseData.CheckedBy);
    $('#txtApprovedBy').val(responseData.ApprovedBy);
    $('#txtAuditedBy').val(responseData.AuditedBy);
    categoryId = responseData.CategoryId;
    subCategoryId = responseData.SubCategoryId;
    //InitAutoCompleteForVehicleLogDetail();
    CountTotalKm();
    if (responseData.ExternalUsageCategory == '')
        isMilkRun = false;
    if (responseData.Category == "Enternal Usage" && responseData.ExternalUsageCategory == "Long Haul")
        $('#dtThcDetail').show();
    else
        $('#dtThcDetail').hide();
    THCbillGenerated = responseData.THCbillGenerated;

}

//var isMilkRun = true;
//function ShowHideVehicleLogDetail(navigation) {
//    ShowHideStep('dvWizard', 4, navigation, isMilkRun);    
//    return false;
//}

function CountTotalKm() {
    if (txtClosingKm.val() != '') {
        if (parseInt(txtClosingKm.val()) == 0)
            $('#lblTotalKm').text(0);
        else {
            var totalKm = parseFloat(txtClosingKm.val()) - parseFloat($('#hdnStartKm').val());

            if (categoryId == 1 && subCategoryId == 2) {
                var lastEndKm = 0;
                $('[id*="txtEndKm"]').each(function () {
                    if (parseFloat($(this).val()) > lastEndKm)
                        lastEndKm = parseFloat($(this).val());
                });
                if (lastEndKm > parseFloat(txtClosingKm.val()))
                    txtClosingKm.val(lastEndKm);
            }

            $('#lblTotalKm').text(totalKm);
            $('#dvVehicleLogDetail').showHide((categoryId != 2 && subCategoryId == 2 && totalKm > 0));
            $('#dvVehicleLog').showHide((categoryId != 2 && subCategoryId == 2 && totalKm > 0));
            $('#txtFrom0').focus();
        }
    }
}

function InitAutoComplete() {
    $('[id*="hdnPetrolPumpId"]').each(function () {
        var hdnPetrolPumpId = $(this);
        var txtPetrolPumpName = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtPetrolPumpName'));
        var txtFuelQuantity = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtFuelQuantity'));
        var txtFuelRate = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtFuelRate'));
        var txtAmount = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtAmount'));
        var txtApprovedAmount = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtApprovedAmount'));
        var txtBillDate = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtBillDate'));
        var ddlPaidBy = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'ddlPaidBy'));
        var ddlCardId = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'ddlCardId'));
        var divCardDetail = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'divCardDetail'));
        InitDateTimePicker(txtBillDate.Id, false, true, false, currentDate, jsDateFormat, '', '');
        txtApprovedAmount.blur(CheckApprovedAmountIsValid);
        txtFuelRate.blur(GetAmount).blur(GetTotalAmountAndQuantity);
        txtFuelQuantity.blur(GetAmount);
        txtAmount.blur(GetTotalAmountAndQuantity);
        txtFuelQuantity.blur(GetTotalAmountAndQuantity);
        txtApprovedAmount.blur(GetTotalAmountAndQuantity);
        ddlPaidBy.change(OnPaidByChange);
        ddlCardId.change(function () { CheckCardSufficientBalance(ddlCardId, txtAmount); });

        AutoComplete(txtPetrolPumpName.Id, fuelMasterUrl + '/GetAutoCompleteList', 'fuelBrandName', 'l', 'l', 'l', '', '', hdnPetrolPumpId.Id, '', '');
        txtPetrolPumpName.blur(function () { return CheckValidPetrolPump(txtPetrolPumpName, hdnPetrolPumpId); }).blur();

        function GetAmount() {
            if (txtFuelRate.val() != '' && txtFuelQuantity.val() != '')
                txtAmount.val(parseFloat(txtFuelRate.val()) * parseFloat(txtFuelQuantity.val()));
            CheckCardSufficientBalance(ddlCardId, txtAmount);
        }

        function CheckApprovedAmountIsValid() {
            if (parseFloat(txtApprovedAmount.val()) > parseFloat(txtAmount.val())) {
                ShowMessage('Approved Amount is less than or equal to Amount');
                txtApprovedAmount.val('');
                return false;
            }
        }

        function OnPaidByChange() {
            var isCard = ddlPaidBy.val() == 2 || ddlPaidBy.val() == 3;
            ddlCardId.enable(isCard);
            if (isCard)
                AddRequired(ddlCardId, 'Please select Card');
            else
                RemoveRequired(ddlCardId);
            // divCardDetail.showHide(isCard);
            if (isCard) {
                var requestData = { tripsheetId: selectedTripsheetId, isFuelCard: ddlPaidBy.val() == 2 ? true : false };
                AjaxRequestWithPostAndJson(TripsheetUrl + '/GetCardListByTripsheetId', JSON.stringify(requestData), function (responseData) {
                    BindDropDownList(ddlCardId.Id, responseData, 'Value', 'Name', '', 'Select Card');
                }, ErrorFunction, false);
            }
        }


    });
}

function CheckCardSufficientBalance(ddlCardId, txtAmount) {
    if (ddlCardId.val() != '' && ddlCardId.val() != null) {
        var requestData = { cardId: ddlCardId.val() };
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Card').replace('Action', 'CheckCardSufficientBalance'), JSON.stringify(requestData), function (balanceAmount) {
            if (parseFloat(txtAmount.val()) > balanceAmount) {
                ShowMessage('Not Sufficient Balance In Cash Card');
                ddlCardId.val('');
            }
        }, ErrorFunction, false);
    }
}

function CheckValidPetrolPump(txtPetrolPumpNameCode, hdnPetrolPumpId) {
    var isValidPetrolPump = false;
    if (txtPetrolPumpNameCode.val() != "") {
        var requestData = { fuelBrandName: txtPetrolPumpNameCode.val().split(':')[0].trim() };
        AjaxRequestWithPostAndJson(fuelMasterUrl + '/CheckValidFuelBrandName', JSON.stringify(requestData), function (result) {
            if (!IsObjectNullOrEmpty(result)) {
                txtPetrolPumpNameCode.val(result.Name);
                hdnPetrolPumpId.val(result.Value);
                isValidPetrolPump = result.Value > 0;
            }
            else {
                ShowMessage('Petrol Pump is not exist');
                txtPetrolPumpNameCode.val('');
                hdnPetrolPumpId.val('');
                txtPetrolPumpNameCode.focus();
                isValidPetrolPump = false;
            }

        }, ErrorFunction, false);
    }
    ManageOilExpense(hdnPetrolPumpId, isValidPetrolPump);
    return false;
}
function ManageOilExpense(hdnPetrolPumpId, isValidPetrolPump) {
    var txtKm = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtKm'));
    var txtBillNo = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtBillNo'));
    var txtBillDate = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtBillDate'));
    var txtFuelQuantity = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtFuelQuantity'));
    var txtFuelRate = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtFuelRate'));
    var txtAmount = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtAmount'));
    var txtApprovedAmount = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'txtApprovedAmount'));
    var ddlPaidBy = $('#' + hdnPetrolPumpId.Id.replace('hdnPetrolPumpId', 'ddlPaidBy'));

    if (!isValidPetrolPump) {
        txtKm.val(0); txtBillNo.val(''); txtBillDate.val(''); txtFuelQuantity.val(0); txtFuelRate.val(0).blur(); txtApprovedAmount.val(0); txtAmount.blur(); ddlPaidBy.val(0);
    }
    txtKm.enable(isValidPetrolPump); txtBillNo.enable(isValidPetrolPump); txtBillDate.enable(isValidPetrolPump);
    txtFuelQuantity.enable(isValidPetrolPump); txtFuelRate.enable(isValidPetrolPump); txtApprovedAmount.enable(isValidPetrolPump); ddlPaidBy.enable(isValidPetrolPump);

    if (isValidPetrolPump) {
        var startKm = parseFloat($('#lblStartKm').text());
        var closeKm = parseFloat($('#txtClosingKm').val());
        RemoveRange(txtKm);
        AddRange(txtKm, 'Please enter KM between ' + startKm + ' and ' + closeKm, startKm, closeKm);
        AddRequired(txtBillNo, 'Please enter Bill No');
        AddRequired(txtBillDate, 'Please enter Bill Date');
        AddRange(txtFuelQuantity, 'Please enter Fuel Quantity', 1, 999999);
        AddRange(txtFuelRate, 'Please enter Fuel Rate', 1, 999999);
        AddRange(txtApprovedAmount, 'Please enter Approved Amount', 1, 999999);
        AddRequired(ddlPaidBy, 'Please enter Paid By');
        txtKm.focus();
    }
    else {
        RemoveRequired(txtKm);
        RemoveRequired(txtBillNo);
        RemoveRequired(txtBillDate);
        RemoveRange(txtFuelQuantity);
        RemoveRange(txtFuelRate);
        RemoveRange(txtApprovedAmount);
        RemoveRequired(ddlPaidBy);
    }
}
function GetTotalAmountAndQuantity() {
    var totalAmount = 0, totalQuantity = 0, totalApprovedAmount = 0;
    $('[id*="txtFuelQuantity"]').each(function () {
        var txtFuelQuantity = $(this);
        var txtAmount = $('#' + txtFuelQuantity.Id.replace('txtFuelQuantity', 'txtAmount'));
        var txtApprovedAmount = $('#' + txtFuelQuantity.Id.replace('txtFuelQuantity', 'txtApprovedAmount'));
        var ddlCardId = $('#' + txtFuelQuantity.Id.replace('txtFuelQuantity', 'ddlCardId'));

        if (txtAmount.val() != '' && txtFuelQuantity.val() != '') {
            totalAmount = totalAmount + parseFloat(txtAmount.val());
            totalQuantity = totalQuantity + parseFloat(txtFuelQuantity.val());
        }
        if (txtApprovedAmount.val() != '') {
            totalApprovedAmount = totalApprovedAmount + parseFloat(txtApprovedAmount.val());
        }
        CheckCardSufficientBalance(ddlCardId, txtAmount);
    });
    $('#txtTotalQuantity').val(totalQuantity);
    $('#txtTotalAmount').val(totalAmount);
    $('#txtTotalApprovedAmount').val(totalApprovedAmount);
}

function Init() {
    $('[id*="txtSpentAmount"]').each(function () {
        var txtSpentAmount = $(this);
        var txtStanderdAmount = $('#' + txtSpentAmount.Id.replace('txtSpentAmount', 'txtStanderdAmount'));
        var txtEnRouteExpenseBillDate = $('#' + txtSpentAmount.Id.replace('txtSpentAmount', 'txtEnRouteExpenseBillDate'));
        var txtChargeName = $('#' + txtSpentAmount.Id.replace('txtSpentAmount', 'txtChargeName'));
        var hdnChargeCode = $('#' + txtSpentAmount.Id.replace('txtSpentAmount', 'hdnChargeCode'));
        InitDateTimePicker(txtEnRouteExpenseBillDate.Id, false, true, false, currentDate, jsDateFormat, '', '');
        AutoComplete(txtChargeName.Id, TripsheetUrl + '/GetAutoCompleteChargeList', 'chargeName', 'l', 'l', 'l', 'd', '', 'hdnChargeCode', '', '');
        txtChargeName.blur(function () {
            return IsChargeNameExist(txtChargeName, hdnChargeCode, txtStanderdAmount);
        }).blur(GetTotalAmount);
        //txtSpentAmount.blur(GetTotalAmount);
        txtSpentAmount.blur(function () {

            if (txtStanderdAmount.val() == "")
            {
                txtStanderdAmount.val(0);
            }

            //if ($('#lblRoute').text() != "Not Applicable")
            //{
            //    if (parseFloat(txtSpentAmount.val()) > parseFloat(txtStanderdAmount.val())) {
            //        ShowMessage('Spent amount should be equal or less than standerd amount');
            //        txtSpentAmount.val(0);
            //    }
            //}

            GetTotalAmount();
        });

        //txtStanderdAmount.blur(GetTotalAmount);
    });
}

function IsChargeNameExist(objCharge, objHdnChargeCode, objStanderdAmount) {
    var isValidCharge = false;
    if (objCharge.val() != "") {
        var requestData = { chargeName: objCharge.val(), TripsheetId: $('#hdnTripsheetId').val() };
        AjaxRequestWithPostAndJson(TripsheetUrl + '/IsChargeNameExistTripSheet', JSON.stringify(requestData), function (result) {
            if (!IsObjectNullOrEmpty(result)) {
                objCharge.val(result.Name);
                objHdnChargeCode.val(result.Value);
                objStanderdAmount.val(result.Description);
            }
            else {
                ShowMessage('Charge is not exist');
                objCharge.val('');
                objHdnChargeCode.val('');
                objStanderdAmount.val('0');
                objCharge.focus();
            }
            isValidCharge = result.Value > 0;
        }, ErrorFunction, false);
    }
    ManageEnrouteExpense(objCharge, isValidCharge);
    return false;
}

function ManageEnrouteExpense(txtChargeName, isValidCharge) {
    var txtSpentAmount = $('#' + txtChargeName.Id.replace('txtChargeName', 'txtSpentAmount'));
    var txtEnRouteBillNo = $('#' + txtChargeName.Id.replace('txtChargeName', 'txtEnRouteBillNo'));
    var txtEnRouteExpenseBillDate = $('#' + txtChargeName.Id.replace('txtChargeName', 'txtEnRouteExpenseBillDate'));

    if (!isValidCharge) {
        txtSpentAmount.val(0); txtEnRouteBillNo.val(''); txtEnRouteExpenseBillDate.val('');
    }
    txtSpentAmount.enable(isValidCharge);
    txtEnRouteBillNo.enable(isValidCharge);
    txtEnRouteExpenseBillDate.enable(isValidCharge);
    if (isValidCharge) {
        AddRange(txtSpentAmount, 'Please enter Spent Amount', 1, 999999);
        AddRequired(txtEnRouteBillNo, 'Please enter Bill No');
        AddRequired(txtEnRouteExpenseBillDate, 'Please enter Bill Date');
        txtSpentAmount.focus();
    }
    else {
        RemoveRange(txtSpentAmount);
        RemoveRequired(txtEnRouteBillNo);
        RemoveRequired(txtEnRouteExpenseBillDate);
    }
}

function GetTotalAmount() {
    var totalSpentAmount = 0, totalStanderdAmount = 0;
    $('[id*="txtSpentAmount"]').each(function () {
        var txtSpentAmount = $(this);
        var txtStanderdAmount = $('#' + txtSpentAmount.Id.replace('txtSpentAmount', 'txtStanderdAmount'));
        if (txtSpentAmount.val() != '') {
            totalSpentAmount = totalSpentAmount + parseFloat(txtSpentAmount.val());
        }
        if (txtStanderdAmount.val() != '') {
            totalStanderdAmount = totalStanderdAmount + parseFloat(txtStanderdAmount.val());
        }
    });
    $('#txtTotalAmountSpent').val(totalSpentAmount);
    $('#txtTotalStanderdAmount').val(totalStanderdAmount);
}

function InitAutoCompleteForVehicleLogDetail() {
    var lastEndKm = parseFloat($('#lblStartKm').text());
    var lastDateObj = $('#hdnTripsheetDate');
    var txtTotalRunKm = $('#txtTotalRunKm');

    $('[id*="ddlProductId"]').each(function () {
        var ddlProductId = $(this);
        var txtFrom = $('#' + ddlProductId.Id.replace('ddlProductId', 'txtFrom'));
        var txtProductName = $('#' + ddlProductId.Id.replace('ddlProductId', 'txtProductName'));
        var lblProductDesc = $('#' + ddlProductId.Id.replace('ddlProductId', 'lblProductDesc'));
        var txtStartDateTime = $('#' + ddlProductId.Id.replace('ddlProductId', 'txtStartDateTime'));
        var txtStartKm = $('#' + ddlProductId.Id.replace('ddlProductId', 'txtStartKm'));
        var txtEndDateTime = $('#' + ddlProductId.Id.replace('ddlProductId', 'txtEndDateTime'));
        var txtEndKm = $('#' + ddlProductId.Id.replace('ddlProductId', 'txtEndKm'));
        var txtKmRun = $('#' + ddlProductId.Id.replace('ddlProductId', 'txtKmRun'));
        var txtTransitTime = $('#' + ddlProductId.Id.replace('ddlProductId', 'txtTransitTime'));
        var txtIdleTime = $('#' + ddlProductId.Id.replace('ddlProductId', 'txtIdleTime'));

        txtFrom.blur(function () { ManageVehicleLogDetails(txtFrom) });

        if (txtStartDateTime.data("DateTimePicker") == null)
        {
            InitDateTimePicker(txtStartDateTime.Id, false, true, true, lastDateObj.val(), jsDateTimeFormat, lastDateObj.val(), $('#txtOpCloseDateTime').val());
        }
        //else
        //{
        //    if (txtStartDateTime.val() == "")
        //    {
        //        InitDateTimePicker(txtStartDateTime.Id, false, true, false, currentDate, jsDateFormat, '', '', true, false);
        //    }
        //}
        //txtStartDateTime.datetimepicker('minDate', moment(lastDateObj.val(), jsDateTimeFormat));

        if (txtEndDateTime.data("DateTimePicker") == null)
            InitDateTimePicker(txtEndDateTime.Id, true, true, true, currentDateTime, dateTimeFormat, false, currentDateTime);
        //else
        //{
        //    if (txtEndDateTime.val() == "")
        //    {
        //        InitDateTimePicker(txtEndDateTime.Id, true, true, false, currentDate, jsDateFormat, '', '', true, false);
        //    }
        //}
        //txtStartDateTime.datetimepicker('minDate', moment(lastDateObj.val(), jsDateTimeFormat));
        txtEndKm.blur(GetKmRun);
        txtEndKm.blur(CheckEndKmIsValid);
        txtEndDateTime.blur(function () { CalculateTransitTime(txtStartDateTime, txtEndDateTime, lastDateObj); });
        txtStartDateTime.blur(function () { CalculateTransitTime(txtStartDateTime, txtEndDateTime, lastDateObj); }).blur(CalculateIdleTime);

        //txtProductName.blur(function () { return IsProductCodeExist(txtProductName, hdnProductId, lblProductDesc); });
        //ProductAutoComplete(txtProductName.Id, hdnProductId.Id);

        txtStartKm.val(lastEndKm);
        lastEndKm = parseFloat(txtEndKm.val());
        lastDateObj = txtEndDateTime;

        function GetKmRun() {
            var TotalRunKm, KmRun;
            TotalRunKm = 0;
            KmRun = 0;

            if (txtTotalRunKm.val() != "")
            {
                TotalRunKm = parseInt(txtTotalRunKm.val())
            }
            if (txtKmRun.val() != "")
            {
                KmRun = parseInt(txtKmRun.val())
            }

            TotalRunKm = TotalRunKm - KmRun;
            TotalRunKm = TotalRunKm + (parseInt(txtEndKm.val()) - parseInt(txtStartKm.val()));

            txtKmRun.val(parseInt(txtEndKm.val()) - parseInt(txtStartKm.val()));
            txtTotalRunKm.val(TotalRunKm);


            var txtprevStartKm = txtEndKm.parents('tr').next().find('[id*="txtStartKm"]');
            txtprevStartKm.val(txtEndKm.val());
        }

        function CheckEndKmIsValid() {
            if (parseInt(txtClosingKm.val()) == 0 || txtClosingKm.val() == '') {
                ShowMessage('Please enter Closing KM. Reading first');
                txtEndKm.val('');
                txtClosingKm.focus();
                return false;
            }
            //else if ((parseInt(txtEndKm.val()) > parseInt(txtClosingKm.val())) && parseInt(txtEndKm.val()) != 0) {
            //    ShowMessage('End KM Should be Less than or equal to Closing KM. Reading');
            //    txtEndKm.val('');
            //    txtEndKm.focus();
            //    return false;
            //}
            //else if ((parseInt(txtEndKm.val()) < parseInt(txtStartKm.val())) && parseInt(txtEndKm.val()) != 0) {
            //    ShowMessage('End KM Should be Greater than Start KM');
            //    txtEndKm.val('');
            //    txtEndKm.focus();
            //    return false;
            //}
        }

        function CalculateTransitTime(txtStartDateTime, txtEndDateTime) {
            var previousEndDateTimeObj = txtStartDateTime.closest('tr').prev().find('[id*="txtEndDateTime"]');
            var startDateFrom, startDateTo;


            if (previousEndDateTimeObj.length > 0)
                startDateFrom = $.setDateTime(previousEndDateTimeObj.val());
            else
                startDateFrom = $.displayDateTimeToDate($('#lblTripsheetDate').text());

            if (txtStartDateTime.val() != '' && txtEndDateTime.val() != '') {
                var startDate = $.setDateTime(txtStartDateTime.val());
                var endDate = $.setDateTime(txtEndDateTime.val());
                var previousEndDateTime = null;
                if (startDate >= endDate) {
                    ShowMessage('End Date Time Should be Greater than Start Date Time');
                    txtEndDateTime.val('');
                    txtEndDateTime.focus();
                    return false;
                }
                if (previousEndDateTime != null)
                    if (startDate < previousEndDateTime) {
                        ShowMessage('Start Date Time Should be Greater than Last Location End Date Time');
                        txtStartDateTime.val('');
                        txtStartDateTime.focus();
                        return false;
                    }

                var ms = endDate.diff(startDate);
                var d = moment.duration(ms);
                var transitTime = Math.floor(d.asHours()) + moment.utc(ms).format(":mm");
                txtTransitTime.val(transitTime);
            }
            //RemapStartDateTime(txtStartDateTime, startDateFrom, tripCloseDate); 
            //RemapStartEndDateTime(txtStartDateTime, txtEndDateTime);
        }

        function CalculateIdleTime() {
            var txtprevEndDateTime = txtStartDateTime.parents('tr').prev().find('[id*="txtEndDateTime"]');
            var txtprevIdleTime = txtStartDateTime.parents('tr').prev().find('[id*="txtIdleTime"]');
            if (txtStartDateTime.val() != '' && txtprevEndDateTime.val() != '') {
                var ms = txtStartDateTime.toDateTime().diff(txtprevEndDateTime.toDateTime());
                var d = moment.duration(ms);
                var idleTime = Math.floor(d.asHours()) + moment.utc(ms).format(":mm");
                txtprevIdleTime.val(idleTime);
            }
        }
    });
}

function ManageVehicleLogDetails(txtFrom) {
    var txtTo = $('#' + txtFrom.Id.replace('txtFrom', 'txtTo'));
    var txtStartDateTime = $('#' + txtFrom.Id.replace('txtFrom', 'txtStartDateTime'));
    var txtStartKm = $('#' + txtFrom.Id.replace('txtFrom', 'txtStartKm'));
    var txtEndKm = $('#' + txtFrom.Id.replace('txtFrom', 'txtEndKm'));
    var ddlCategory = $('#' + txtFrom.Id.replace('txtFrom', 'ddlCategory'));
    var ddlProductId = $('#' + txtFrom.Id.replace('txtFrom', 'ddlProductId'));
    var txtEndDateTime = $('#' + txtFrom.Id.replace('txtFrom', 'txtEndDateTime'));
    var allowEntry = txtFrom.val().trim().length > 0
    if (!allowEntry) {
        txtTo.val(''); txtStartDateTime.val(''); txtEndKm.val(0); ddlCategory.val(0); ddlProductId.val('').blur(); txtEndDateTime.val('');
    }
    txtTo.enable(allowEntry); txtStartDateTime.enable(allowEntry); txtEndKm.enable(allowEntry); ddlCategory.enable(allowEntry); ddlProductId.enable(allowEntry); txtEndDateTime.enable(allowEntry);

    if (allowEntry) {
        var startKm = parseFloat(txtStartKm.val());
        var closeKm = parseFloat($('#txtClosingKm').val());
        AddRequired(txtTo, 'Please enter To');
        AddRange(txtEndKm, 'Please enter KM between ' + startKm + ' and ' + closeKm, startKm, closeKm);
        AddRequired(txtStartDateTime, 'Please enter Start DateTime');
        AddRequired(ddlCategory, 'Please select Category');
        AddRequired(ddlProductId, 'Please enter Product');
        AddRequired(txtEndDateTime, 'Please enter End DateTime');
        txtTo.focus();
    }
    else {
        RemoveRequired(txtTo);
        RemoveRange(txtEndKm);
        RemoveRequired(txtStartDateTime);
        RemoveRequired(ddlCategory);
        RemoveRequired(ddlProductId);
        RemoveRequired(txtEndDateTime);
        RemoveRange(txtEndDateTime);
    }
    //RemapStartEndDateTime(txtStartDateTime, txtEndDateTime);
}


function RemapKm() {
    dtOilExpenses.find('[id*="txtPetrolPumpName"]').each(function () {
        if ($(this).val() != '')
            ManageOilExpense($('#' + this.id.replace('txtPetrolPumpName', 'hdnPetrolPumpId')), true);
    });

    dtVehicleLogDetail.find('[id*="txtFrom"]').each(function () {
        if ($(this).val() != '')
            ManageVehicleLogDetails($(this), true);
    });
}

function RemapStartDateTime(txtStartDateTime, startDateFrom, startDateTo) {
    RemoveRange(txtStartDateTime);
    AddRange(txtStartDateTime, 'Please enter Start Date Time between ' + $.displayDateTime(startDateFrom) + ' and ' + $.displayDateTime(startDateTo), startDateFrom, startDateTo);
}


function RemapEndDateTime(txtEndDateTime, endDateFrom, endDateTo) {
    RemoveRange(txtEndDateTime);
    AddRange(txtEndDateTime, 'Please enter End Date Time between ' + $.displayDateTime(endDateFrom) + ' and ' + $.displayDateTime(endDateTo), endDateFrom, endDateTo);
}

function RemapStartEndDateTime(txtStartDateTime, txtEndDateTime) {
    var tripCloseDate = $.setDateTime($('#txtOpCloseDateTime').val());

    var previousEndDateTimeObj = txtStartDateTime.closest('tr').prev().find('[id*="txtEndDateTime"]');
    var startDateFrom = (previousEndDateTimeObj.length > 0) ? $.setDateTime(previousEndDateTimeObj.val()) : startDateFrom = $.displayDateTimeToDate($('#lblTripsheetDate').text());

    txtStartDateTime.datetimepicker('minDate', startDateFrom);
    txtStartDateTime.datetimepicker('maxDate', tripCloseDate);

    if (txtEndDateTime.val() != '') {
        var endDateFrom = $.setDateTime(txtStartDateTime.val());
        if (endDateFrom < tripCloseDate)
            endDateFrom = endDateFrom.add('m', 1);;
        txtEndDateTime.datetimepicker('minDate', endDateFrom);
        txtEndDateTime.datetimepicker('maxDate', tripCloseDate);
    }
}

function InitAutoCompleteThcDetail() {

    $('[id*="hdnFromCityId"]').each(function () {
        var hdnFromCityId = $(this);

        var txtFromCity = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtFromCity'));
        var txtToCity = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtToCity'));
        var hdnToCityId = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'hdnToCityId'));
        var txtThcNo = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtThcNo'));
        var txtThcDate = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtThcDate'));
        var txtFreightAmount = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtFreightAmount'));
        var txtLabourCharge = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtLabourCharge'));
        var txtOtherCharge = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtOtherCharge'));
        var txtTotalAmt = $('#' + hdnFromCityId.Id.replace('hdnFromCityId', 'txtTotalAmt'));

        var dtPicker = txtThcDate.data("DateTimePicker");

        if (dtPicker == null) {
            InitDateTimePicker(txtThcDate.Id, false, true, false, currentDate, jsDateFormat, '', '');
        }

        CityAutoComplete(txtFromCity.Id, hdnFromCityId.Id);
        txtFromCity.blur(function () { return IsCityNameExist(txtFromCity, hdnFromCityId, 'City') });

        CityAutoComplete(txtToCity.Id, hdnToCityId.Id);
        txtToCity.blur(function () { return IsCityNameExist(txtToCity, hdnToCityId, 'City') });

        txtThcNo.blur(function () {
            if (!CheckDuplicateInTable('dtThcDetail', 'txtThcNo', 'Thc No', txtThcNo)) return false;
        });

        txtFromCity.blur(function () {
            if (!CheckDuplicateInTable('dtThcDetail', 'txtFromCity', 'From City', txtFromCity)) return false;
        });

        txtToCity.blur(function () {
            if (txtFromCity.val().toUpperCase() == txtToCity.val().toUpperCase()) {
                txtToCity.val('');
                txtToCity.focus();
                return false;
            }
        });

        if (txtFreightAmount.val() == '') txtFreightAmount.val(0);
        if (txtLabourCharge.val() == '') txtLabourCharge.val(0);
        if (txtOtherCharge.val() == '') txtOtherCharge.val(0);

        txtFreightAmount.blur(GetTotal).blur(GetTotalThcAmount);
        txtLabourCharge.blur(GetTotal).blur(GetTotalThcAmount);
        txtOtherCharge.blur(GetTotal).blur(GetTotalThcAmount);

        function GetTotal() {
            txtTotalAmt.val(txtFreightAmount.toFloat() + txtLabourCharge.toFloat() + txtOtherCharge.toFloat());
        }
    });
}

function GetTotalThcAmount() {
    var totalFreightAmount = 0, TotalLabourCharge = 0, TotalOtherCharge = 0, TotalAmount = 0, total = 0;
    $('[id*="txtFreightAmount"]').each(function () {
        var txtFreightAmount = $(this);
        var txtLabourCharge = $('#' + txtFreightAmount.Id.replace('txtFreightAmount', 'txtLabourCharge'));
        var txtOtherCharge = $('#' + txtFreightAmount.Id.replace('txtFreightAmount', 'txtOtherCharge'));
        var txtTotalAmt = $('#' + txtFreightAmount.Id.replace('txtFreightAmount', 'txtTotalAmt'));
        totalFreightAmount = totalFreightAmount + parseFloat(txtFreightAmount.val());
        TotalLabourCharge = TotalLabourCharge + parseFloat(txtLabourCharge.val());
        TotalOtherCharge = TotalOtherCharge + parseFloat(txtOtherCharge.val());
        TotalAmount = TotalAmount + parseFloat(txtTotalAmt.val());
    });

    $('#txtTotalFreightAmount').val(totalFreightAmount);
    $('#txtTotalLabourCharge').val(TotalLabourCharge);
    $('#txtTotalOtherCharge').val(TotalOtherCharge);
    $('#txtTotalAmount').val(TotalAmount);
}
