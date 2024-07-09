var drDocumentDate, ddlLocationId, txtTripsheetNo, txtManualTripsheetNo, dtTripsheetDetails,txtVehicalNo, hdnVehicalNo;

$(document).ready(function () {
    SetPageLoad('Tracking', 'Tripsheet Tracking', '', '', '');
    InitObjects();
});

function InitObjects() {
    drDocumentDate = InitDateRange('drDocumentDate', DateRange.LastWeek,false);
    ddlLocationId = $('#ddlLocationId');
    txtTripsheetNo = $('#txtTripsheetNo');
    txtManualTripsheetNo = $('#txtManualTripsheetNo');
    txtVehicalNo = $('#txtVehicalNo');
    hdnVehicalNo = $('#hdnVehicalNo');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentList },
        { StepName: 'Tripsheet List' }
    ], '');

    VehicleAutoComplete(txtVehicalNo.Id, hdnVehicalNo.Id);

}

function GetDocumentList() {
    var requestData = { locationId: ddlLocationId.val(), fromDate: $.displayDate(drDocumentDate.startDate), toDate: drDocumentDate.endDate, tripsheetNos: txtTripsheetNo.val(), manualTripsheetNos: txtManualTripsheetNo.val(), vehicalNos: txtVehicalNo.val() };
    AjaxRequestWithPostAndJson(trackingUrl + '/GetTripsheetList', JSON.stringify(requestData), function (result) {

        if (dtTripsheetDetails == null)
            dtTripsheetDetails = LoadDataTable('dtTripsheetDetails', false, false, false, null, null, [],
                [
                    { title: 'Tripsheet No', data: 'TripsheetNo' },
                    { title: 'Tripsheet Date', data: 'TripsheetDate' },
                    { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                    { title: 'Start Location', data: 'StartLocation' },
                    { title: 'End Location', data: 'EndLocation' },
                    { title: 'Vehicle No', data: 'VehicleNo' },
                    { title: 'Operational Status', data: 'OperationalStatus' },
                    { title: 'Financial Status', data: 'FinancialStatus' },
                    { title: 'Driver Settlement Status', data: 'DriverSettlementStatus' },
                    { title: 'View', data: 'View' }
                ]);

        dtTripsheetDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.TripsheetNo = "<input type='hidden' value='" + item.TripsheetId + "' id='hdnTripsheetId" + i + "'/>" + item.TripsheetNo;
                item.TripsheetDate = $.displayDate(item.TripsheetDate);
                item.View = '<button id = "btnTripsheetView' + i + '" onclick="return ViewReport(' + item.TripsheetId + ')" class="btn btn-primary btn-xs dt-edit">' +
                    '<span class="glyphicon glyphicon-eye-open"></span>' +
                    '</button>';
            });
            dtTripsheetDetails.dtAddData(result);
        }
    }, ErrorFunction, false);
    return false;
}

function ViewReport(value) {
    ShowViewPrint(tripsheetModuleId, value);
    return false;
}