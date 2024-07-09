var drTripsheetDate, ddlLocationId, hdnVehicleId, txtVehicleNo, txtTripsheetNo, txtDriverName;

$(document).ready(function () {
    SetPageLoad('Driver Advance', 'Report', '', '', '');

    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek);
    ddlLocationId = $('#ddlLocationId');
    hdnVehicleId = $('#hdnVehicleId');
    txtVehicleNo = $('#txtVehicleNo');
    txtTripsheetNo = $('#txtTripsheetNo');
    txtDriverName = $('#txtDriverName');
    hdnDriverId = $('#hdnDriverId');
    VehicleAutoComplete('txtVehicleNo', 'hdnVehicleId');
    txtVehicleNo.blur(function () { return IsVehicleNoExist(txtVehicleNo, hdnVehicleId); });

    btnSubmit = $('#btnSubmit');
    btnSubmit.click(ViewReport);

});

function ViewReport() {
    var prmList = [
        { Name: "FromDate", Value: drTripsheetDate.startDate },
        { Name: "ToDate", Value: drTripsheetDate.endDate },
        { Name: "StartLocationId", Value: ddlLocationId.val() },
        { Name: "TripsheetNo", Value: txtTripsheetNo.val() == '' ? ' ' : txtTripsheetNo.val()},
        { Name: "VehicleId", Value: hdnVehicleId.val() },
        { Name: "DriverName", Value: txtDriverName.val() == '' ? ' ' : txtDriverName.val() }];
    var reportInfo = { PrmList: prmList, Name: 'DriverAdvanceReport', Description: 'Driver Advance Report' };
    return ShowReport(reportInfo);
}