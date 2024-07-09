var drDocumentDate, ddlLocationId, txtTripsheetNo, txtManualTripsheetNo, selectedTripsheetId, selectedVoucherId, dtTripsheetList, dtDriverAdvanceList, tripsheetUrl, chkTripsheet, hdnTripsheetId, hdnVoucherId;

$(document).ready(function () {
    SetPageLoad('Tripsheet', 'Advance Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    drDocumentDate = InitDateRange('drDocumentDate', DateRange.LastWeek);
    ddlLocationId = $('#ddlLocationId');
    hdnTripsheetId = $('#hdnTripsheetId');
    hdnVoucherId = $('#hdnVoucherId');
    txtTripsheetNo = $('#txtTripsheetNo');
    txtManualTripsheetNo = $('#txtManualTripsheetNo');
    txtVoucherNo = $('#txtVoucherNo');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetTripsheetList },
        { StepName: 'Tripsheet List', StepFunction: GetDriverAdvanceList },
        { StepName: 'Voucher List', StepFunction: ValidateVoucher },
        { StepName: 'Reason for cancelling tripsheet advance' }
    ], 'Cancel');
}

function GetTripsheetList() {
    var requestData = { locationId: ddlLocationId.val(), fromDate: drDocumentDate.startDate, toDate: drDocumentDate.endDate, tripsheetNos: txtTripsheetNo.val(), manualTripsheetNos: txtManualTripsheetNo.val(), voucherNo: txtVoucherNo.val() };
    AjaxRequestWithPostAndJson(tripsheetUrl + '/GetAdvanceCancelTripsheetList', JSON.stringify(requestData), function (result) {

        if (dtTripsheetList == null)
            dtTripsheetList = LoadDataTable('dtTripsheetList', false, false, false, null, null, [],
                [
                    { title: 'Tripsheet No', data: "TripsheetId" },
                    //{ title: 'Tripsheet No', data: 'TripsheetNo' },
                    { title: 'Tripsheet Date', data: 'TripsheetDate' },
                    { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                    { title: 'Start Location', data: 'StartLocation' },
                    { title: 'End Location', data: 'EndLocation' },
                    { title: 'Vehicle No', data: 'VehicleNo' }

                ]);

        dtTripsheetList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.TripsheetId = '<div class="clearfix">' +
                    '<label class="radio">' +
                    '<input type="radio" name=\'Tripsheet\' value=\'' + item.TripsheetId + '\' onclick="GetTripsheetDetail(this)" tabindex="0" id="chkTripsheetNo' + i + '"/><i></i>' +
                    '<label for="chkTripsheetNo' + i + '">' + item.TripsheetNo + '</label>' +
                    '</label>' +
                    '</div>';
                item.TripsheetDate = $.displayDate(item.TripsheetDate);
            });
            dtTripsheetList.dtAddData(result);
            selectedTripsheetId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

function GetTripsheetDetail(rd) {
    selectedTripsheetId = rd.value;
    hdnTripsheetId.val(rd.value);
}

function GetDriverAdvanceList() {
    isStepValid = selectedTripsheetId != 0;
    if (selectedTripsheetId == 0) {
        ShowMessage('Please select Tripsheet');
        return false;
    }
    var requestData = { TripsheetId: selectedTripsheetId };

    AjaxRequestWithPostAndJson(tripsheetUrl + '/GetAdvanceCancelDriverAdvanceList', JSON.stringify(requestData), function (result) {

        if (dtDriverAdvanceList == null)
            dtDriverAdvanceList = LoadDataTable('dtDriverAdvanceList', false, false, false, null, null, [],
                [
                    { title: 'Voucher No', data: "VoucherId" },
                    { title: 'Payment Date', data: 'AdvanceDate' },
                    { title: 'Amount', data: 'Amount' },
                    { title: 'Paid By', data: 'PaidBy' },
                    { title: 'Place', data: 'Place' }
                ]);

        dtDriverAdvanceList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.VoucherId = '<div class="clearfix">' +
                    '<label class="radio">' +
                    '<input type="radio" name=\'DrivarAdvance\' value=\'' + item.VoucherId + '\' onclick="GetVoucherDetail(this)" tabindex="0" id="chkVoucherNo' + i + '"/><i></i>' +
                    '<label for="chkVoucherNo' + i + '">' + item.VoucherNo + '</label>' +
                    '</label>' +
                    '</div>';
                item.AdvanceDate = $.displayDate(item.AdvanceDate);
            });
            dtDriverAdvanceList.dtAddData(result);
            selectedVoucherId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

function GetVoucherDetail(rd) {
    selectedVoucherId = rd.value;
    hdnVoucherId.val(rd.value);
}

function ValidateVoucher() {
    isStepValid = selectedVoucherId != 0;
    if (selectedVoucherId == 0) {
        ShowMessage('Please select Voucher');
        return false;
    }


}