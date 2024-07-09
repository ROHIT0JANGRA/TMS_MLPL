var ddlsearchBy, txtTripsheetNo, dtTripsheetDetailList, drTripsheetDate, tripsheetUrl, selectedTripsheetId, txtAdvanceAmount,
    dtExpensesDetails, hdnVehicleId, txtVehicleNo, ddlDriverId, hdnCardTillDate, hdnCardVehicleId, driverId = 0;
var dtAdvanceDetail;
$(document).ready(function () {
    SetPageLoad('Trip Sheet', 'Driver Advance', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    ddlsearchBy = $('#ddlsearchBy');
    txtTripsheetNo = $('#txtTripsheetNo');
    dtTripsheetDetailList = $('#dtTripsheetDetailList');
    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek, false);
    txtAdvanceAmount = $('#txtAdvanceAmount');
    hdnVehicleId = $('#hdnVehicleId');
    txtVehicleNo = $('#txtVehicleNo');
    ddlDriverId = $('#ddlDriverId');
    hdnCardTillDate = $('#hdnCardTillDate');
    hdnCardVehicleId = $('#hdnCardTillDate');
    dtAdvanceDetail = $('#dtAdvanceDetail'); 

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetTripsheetList },
     { StepName: 'Trip Sheet List', StepFunction: LoadStep3 },
     { StepName: 'Driver Advance Details' }
    ], 'Submit');
}

function AttachEvents() {
    txtAdvanceAmount.blur(function () { SetPaymentAmount($(this).val()); });
    dtTripsheetDetailList = LoadDataTable('dtTripsheetDetailList', false, false, false, null, null, [],
              [
                  { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                  { title: 'Tripsheet No', data: 'TripsheetNo' },
                  { title: 'Tripsheet Date', data: 'TripsheetDate' },
                  { title: 'Driver', data: 'FirstDriverName' },
                  { title: 'Vehicle No', data: 'VehicleNo' }
              ]);
    //$('#chkIsAdvancePaidByCashCard').click(SetAdvanceByCashCard);
    $('#ddlAdvanceCardId').change(GetCashCardAccount);
    ddlsearchBy.change(SearchByChange);
    ddlDriverId.change(GetDriverDetail);
}

function SearchByChange() {
    txtTripsheetNo.val('');
    hdnVehicleId.val(0);
    if (ddlsearchBy.val() == 3) {
        VehicleAutoComplete('txtTripsheetNo', 'hdnVehicleId');
        txtTripsheetNo.blur(function () { IsVehicleNoExist(txtTripsheetNo, hdnVehicleId); });
    }
    else {
        txtTripsheetNo.autocomplete("destroy");
        txtTripsheetNo.off('blur');
    }
}

function GetTripsheetList() {
    var requestData = {
        searchBy: ddlsearchBy.val(), tripsheetNo: txtTripsheetNo.val(), fromDate: drTripsheetDate.startDate, toDate: drTripsheetDate.endDate
    };
    AjaxRequestWithPostAndJson(tripsheetUrl + '/GetTripsheetListForDriverAdvance', JSON.stringify(requestData), function (result) {
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
        ShowMessage('Please select THC');
        return false;
    }
    $('#hdnTripsheetId').val(selectedTripsheetId);
    var requestData = { TripsheetId: selectedTripsheetId };
    AjaxRequestWithPostAndJson(tripsheetUrl + '/GetById', JSON.stringify(requestData), GetTripsheetDetailSuccess, ErrorFunction, false);
    AjaxRequestWithPostAndJson(tripsheetUrl + '/GetAdvanceDetail', JSON.stringify(requestData), function (result) {


        dtAdvanceDetail = LoadDataTable('dtAdvanceDetail', false, false, false, null, null, [],
              [
                  { title: 'Place', data: 'Place' },
                  { title: 'Advance Date', data: 'AdvanceDate' },
                  { title: 'Amount', data: 'Amount' },
                  { title: 'Branch Name', data: 'BranchName' },
                  { title: 'Advance Paid By', data: 'PaidBy' }
              ]);;
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
        AddRange($("#txtAdvanceAmount"), "Advance Amount greater than 1", 1);
        SetPaymentPartyTypeAndParty(5, driverId);
    }, ErrorFunction, false);
}

function GetTripsheetDetailSuccess(responseData) {
    $('#hdnCompanyId').val(responseData.CompanyId);
    $('#txtTripSheetNo').val(responseData.TripsheetNo);
    $('#lblTripsheetDate').text($.displayDate(responseData.TripsheetDate));
    $('#hdnTripsheetDate').val($.entryDateTime(responseData.TripsheetDate));
    $('#hdnVehicle').val(responseData.VehicleId);
    $('#lblVehicleNo').text(responseData.VehicleNo);
    var requestData = { vehicleId: responseData.VehicleId };
    AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Driver').replace('Action', 'GetDriverListByTripSheetRule'), JSON.stringify(requestData), GetFirstDriverListSuccess, ErrorFunction, false);
    if (responseData.DriverId > 0) {
        $('#txtDriverName').val(responseData.DriverName);
        $('#ddlDriverId').val(responseData.DriverId);
        $('#lblDriverLicenseNo').text(responseData.DriverLicenseNo);
        $('#lblDriverLicenseValidityDate').text($.displayDate(responseData.DriverLicenseValidityDate));
        if (parseFloat(responseData.DriverBalance) == 0)
            $('#txtDriverBalance').val(responseData.DriverBalance);
        else if (parseFloat(responseData.DriverBalance) < 0)
            $('#txtDriverBalance').val(responseData.DriverBalance + " CR");
        else
            $('#txtDriverBalance').val(responseData.DriverBalance + " DR");
        $('#dvDriverName').show();
	driverId = responseData.DriverId;
    }
    else {
        $('#txtDriverName').val('');
        $('#ddlDriverId').val('');
        $('#lblDriverLicenseNo').text('');
        $('#lblDriverLicenseValidityDate').text('');
        $('#divDriverInfo').show();
	driverId = 1;
    }
    $('#lblStartLocationCode').text(responseData.StartLocationCode);
    $('#lblEndLocationCode').text(responseData.EndLocationCode);
    $('#lblCategory').text(responseData.Category);
    $('#lblCustomerCode').text(responseData.CustomerCode);
    $('#lblFromCity').text(responseData.FromCity);
    $('#lblToCity').text(responseData.ToCity);
    $('#txtPendingAmount').val(responseData.PendingAmount);

    //BindCashCardList(responseData.VehicleId, $('#hdnTripsheetDate').toDate(), false);
}

function GetFirstDriverListSuccess(responseData) {
    BindDropDownList('ddlDriverId', responseData, 'Value', 'Name', '', 'Select');
}

function GetDriverDetail() {
    if (ddlDriverId.val() != '') {
        var requestData = { driverId: ddlDriverId.val() };
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Driver').replace('Action', 'GetById'), JSON.stringify(requestData), function (result) {
            $('#txtDriverName').val(result.DriverName);
            $('#lblDriverLicenseNo').text(result.LicenseNo);
            $('#lblDriverLicenseValidityDate').text($.displayDate(result.LicenseValidityDate));
            if (parseFloat(result.BalanceAmount) == 0)
                $('#txtDriverBalance').val(result.BalanceAmount);
            else if (parseFloat(result.BalanceAmount) < 0)
                $('#txtDriverBalance').val(result.BalanceAmount + " CR");
            else
                $('#txtDriverBalance').val(result.BalanceAmount + " DR");
        }, ErrorFunction, false);
    }
    else {
        $('#txtDriverName').val('');
        $('#lblDriverLicenseNo').text('');
        $('#lblDriverLicenseValidityDate').text('');
        $('#txtDriverBalance').val(0);
    }
}

//function SetAdvanceByCashCard() {
//    var chkIsAdvancePaidByCashCard = $('#chkIsAdvancePaidByCashCard');
//    $('#ddlAdvanceCardId').empty();
//    if (!chkIsAdvancePaidByCashCard.IsChecked)
//        $('#ddlAdvanceCardId').val('');
//    else {
//        var requestData = { tripsheetId: $('#hdnTripsheetId').val(), isFuelCard: false };
//        AjaxRequestWithPostAndJson(tripsheetUrl + '/GetCardListByTripsheetId', JSON.stringify(requestData), function (responseData) {
//            if (responseData != null) {
//                BindDropDownList('ddlAdvanceCardId', responseData, 'Value', 'Name', '', 'Select');
//            }
//        }, ErrorFunction, false);
//    }
//    $('#ddlAdvanceCardId').enable(chkIsAdvancePaidByCashCard.IsChecked).change();
//    SetCashCardPaymentMode(chkIsAdvancePaidByCashCard.IsChecked);
//}

function GetCashCardAccount() {
    if ($('#ddlAdvanceCardId').val() != '' && $('#ddlAdvanceCardId').val() != null) {
        var requestData = { cardId: $('#ddlAdvanceCardId').val() };
        AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Card').replace('Action', 'GetCashCardAccount'), JSON.stringify(requestData), function (responseData) {
            if (responseData != null) {
                BindCashCardList(responseData.Value, responseData.Name);
            }
        }, ErrorFunction, false);
    }
}