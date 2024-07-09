var ddlsearchBy, txtTripsheetNo, dtTripsheetDetailList, drTripsheetDate, tripsheetUrl, selectedTripsheetId, txtAdvanceAmount,
    dtExpensesDetails, hdnVehicleId, txtVehicleNo;
$(document).ready(function () {
    SetPageLoad('Expected Driver Advance', 'Driver Advance', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    ddlsearchBy = $('#ddlsearchBy');
    txtTripsheetNo = $('#txtTripsheetNo');
    dtTripsheetDetailList = $('#dtTripsheetDetailList');
    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek);
    txtAdvanceAmount = $('#txtAdvanceAmount');
    hdnVehicleId = $('#hdnVehicleId');
    txtVehicleNo = $('#txtVehicleNo');
    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetTripsheetList },
     { StepName: 'Trip Sheet List', StepFunction: LoadStep3 },
     { StepName: 'Trip Sheet Details' }
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

    ddlsearchBy.change(SearchByChange);
    InitGrid('dtAdvanceDetailList', false, 2, Init, false);

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
    AjaxRequestWithPostAndJson(tripsheetUrl + '/GetTripsheetListForExpectedDriverAdvance', JSON.stringify(requestData), function (result) {
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
    requestData = { tripsheetId: selectedTripsheetId };
    AjaxRequestWithPostAndJson(tripsheetUrl + '/GetExpectedDriverAdvanceDetailById', JSON.stringify(requestData), function (result) {
        if (result.length > 0) {
            $.each(result, function (i, item) {
                var rowId = ($('#dtAdvanceDetailList tbody tr').length - 1);
                var hdnLocationId = $('#hdnLocationId' + rowId);
                var txtLocationCode = $('#txtLocationCode' + rowId);
                var txtAdvanceAmount = $('#txtAdvanceAmount' + rowId);
                var hdnPaidAmount = $('#hdnPaidAmount' + rowId);
                hdnLocationId.val(item.LocationId);
                txtLocationCode.val(item.LocationCode);
                txtAdvanceAmount.val(item.AdvanceAmount);
                hdnPaidAmount.val(item.PaidAmount);
                AddGridRow('dtAdvanceDetailList', false, Init);
            });
        }
    }, ErrorFunction, false);
}

function GetTripsheetDetailSuccess(responseData) {
    $('#hdnCompanyId').val(responseData.CompanyId);
    $('#txtTripSheetNo').val(responseData.TripsheetNo);
    $('#lblTripsheetDate').text($.displayDate(responseData.TripsheetDate));
    $('#hdnTripsheetDate').val($.displayDate(responseData.TripsheetDate));
    $('#lblVehicleNo').text(responseData.VehicleNo);
    $('#txtDriverName').val(responseData.DriverName);
    $('#hdnDriverId').val(responseData.DriverId);
    $('#lblDriverLicenseNo').text(responseData.DriverLicenseNo);
    $('#lblDriverLicenseValidityDate').text($.displayDate(responseData.DriverLicenseValidityDate));
    $('#lblStartLocationCode').text(responseData.StartLocationCode);
    $('#lblEndLocationCode').text(responseData.EndLocationCode);
    $('#lblCategory').text(responseData.Category);
    $('#lblCustomerCode').text(responseData.CustomerCode);
    $('#lblFromCity').text(responseData.FromCity);
    $('#lblToCity').text(responseData.ToCity);
    if (parseFloat(responseData.DriverBalance) == 0)
        $('#txtDriverBalance').val(responseData.DriverBalance);
    else if (parseFloat(responseData.DriverBalance) < 0)
        $('#txtDriverBalance').val(responseData.DriverBalance + " CR");
    else
        $('#txtDriverBalance').val(responseData.DriverBalance + " DR");
    $('#txtPendingAmount').val(responseData.PendingAmount);
}

function Init() {
    $('[id*="txtLocationCode"]').each(function () {
        var txtLocationCode = $(this);
        var hdnLocationId = $('#' + this.Id.replace('txtLocationCode', 'hdnLocationId'));
        var hdnPaidAmount = $('#' + this.Id.replace('txtLocationCode', 'hdnPaidAmount'));
        var txtAdvanceAmount = $('#' + this.Id.replace('txtLocationCode', 'txtAdvanceAmount'));
        LocationAutoComplete(txtLocationCode.Id, hdnLocationId.Id);
        txtLocationCode.blur(function () {
            if (!CheckDuplicateInTable('dtAdvanceDetailList', 'txtLocationCode', 'Location Code', txtLocationCode)) return false;
            return IsLocationCodeExist(txtLocationCode, hdnLocationId);
        });
        if (parseFloat(hdnPaidAmount.val()) > 0) {
            txtLocationCode.disable(true);
            txtAdvanceAmount.disable(true);
        }
    })
}