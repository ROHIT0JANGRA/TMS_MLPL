var dtTripsheetDetailList, drTripsheetDate, tripsheetUrl;

$(document).ready(function () {
    SetPageLoad('Trip Sheet', 'Expected Expense', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    dtTripsheetDetailList = $('#dtTripsheetDetailList');
    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek);

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetTripsheetList },
     { StepName: 'Trip Sheet List' },
    ], 'Submit');
}

function AttachEvents() {
    dtTripsheetDetailList = LoadDataTable('dtTripsheetDetailList', false, false, false, null, null, [],
              [
                  { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                  { title: 'Tripsheet No', data: 'TripsheetNo' },
                  { title: 'Tripsheet Date', data: 'TripsheetDate' },
                  { title: 'Driver', data: 'FirstDriverName' },
                  { title: 'From City', data: 'FromCity' },
                  { title: 'To City', data: 'ToCity' },
                  { title: 'Vehicle No', data: 'VehicleNo' },
                  { title: 'Expected Expense', data: 'ExpectedAmount' }
              ]);
}

function GetTripsheetList() {
    var requestData = {
        fromDate: drTripsheetDate.startDate, toDate: drTripsheetDate.endDate
    };
    AjaxRequestWithPostAndJson(tripsheetUrl + '/GetTripsheetListForExpectedExpense', JSON.stringify(requestData), function (result) {
        dtTripsheetDetailList.fnClearTable();
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.TripsheetDate = $.displayDate(item.TripsheetDate);
                item.ExpectedAmount = '<input class="form-control numeric" name="Details[' + i + '].ExpectedAmount" id="txtExpectedAmount' + i + '" type="text" value=\'' + item.ExpectedAmount + '\'/>' +
                      "<input type='hidden' value='" + item.TripsheetId + "' name='Details[" + i + "].TripsheetId' id='hdnTripsheetId" + i + "'/>";
            });
            dtTripsheetDetailList.dtAddData(result);
        }
    }, ErrorFunction, false);
    return false;
}