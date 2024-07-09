var drDocumentDate, ddlLocationId, txtTripsheetNo, txtManualTripsheetNo, dtTripsheetDetails, tripsheetUrl, chkTripsheet, ddlTripsheetId;

$(document).ready(function () {
    SetPageLoad('Tripsheet', 'Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    drDocumentDate = InitDateRange('drDocumentDate', DateRange.LastWeek);
    ddlLocationId = $('#ddlLocationId');
    ddlTripsheetId = $('#ddlTripsheetId');
    txtTripsheetNo = $('#txtTripsheetNo');
    txtManualTripsheetNo = $('#txtManualTripsheetNo');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentList },
        { StepName: 'Cancelled Tripsheet List', StepFunction: StepValid },
         { StepName: 'Reason for cancelling tripsheet' }
    ], 'Cancel');
}

function GetDocumentList() {
    
    var requestData = { locationId: ddlLocationId.val(), fromDate: drDocumentDate.startDate, toDate: drDocumentDate.endDate, tripsheetNos: txtTripsheetNo.val(), manualTripsheetNos: txtManualTripsheetNo.val() };
    AjaxRequestWithPostAndJson(tripsheetUrl + '/GetCancelledTripsheetList', JSON.stringify(requestData), function (result) {

        if (dtTripsheetDetails == null)
            dtTripsheetDetails = LoadDataTable('dtTripsheetDetails', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllTripsheet'), data: "TripsheetId" },
                    { title: 'Tripsheet No', data: 'TripsheetNo' },
                    { title: 'Tripsheet Date', data: 'TripsheetDate' },
                    { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                    { title: 'Start Location', data: 'StartLocation' },
                    { title: 'End Location', data: 'EndLocation' },
                    { title: 'Vehicle No', data: 'VehicleNo' },

                ]);

        dtTripsheetDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.TripsheetId = SelectAll.GetChk('chkAllTripsheet', 'chkTripsheet' + i, 'Details[' + i + '].IsChecked') +
                               "<input type='hidden' value='" + item.TripsheetId + "' name='Details[" + i + "].TripsheetId' id='hdnTripsheetId" + i + "'/>" +
                               "<label class='label' for='chkTripsheet" + i + "' id='lblTripsheetId" + i + "'></label>";
                //item.TripsheetId = SelectAll.GetChk('chkAllTripsheet', 'chkTripsheet' + i, 'Details[' + i + '].IsChecked');
                //"<input type='hidden' value='" + item.TripsheetId + "' name='Details[" + i + "].TripsheetId' id='hdnTripsheetId" + i + "'/>" +
                //              "<label class='label' for='chkTripsheet" + i + "' id='lblTripsheetId" + i + "'></label>";
                item.TripsheetDate = $.displayDate(item.TripsheetDate);

            });
            dtTripsheetDetails.dtAddData(result);
        }
    }, ErrorFunction, false);
    return false;
}



function StepValid() {
    var count = 0;
    $('[id*="chkTripsheet"]').each(function () {
        var chkTripsheet = $(this);
        if (chkTripsheet.IsChecked) {
            count = count + 1;
        }
    });
    if (count == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Tripsheet');
        return false;
    }
}