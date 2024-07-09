var drTripsheetDate, ddlLocationId, hdnVehicleId, txtVehicleNo, txtTripsheetNo, hdnVendorId, txtVendorCode;

$(document).ready(function () {
    SetPageLoad('Fuel Vendor', 'Report', '', '', '');

    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek);
    ddlLocationId = $('#ddlLocationId');
    hdnVehicleId = $('#hdnVehicleId');
    txtVehicleNo = $('#txtVehicleNo');
    txtTripsheetNo = $('#txtTripsheetNo');
    hdnVendorId = $('#hdnVendorId');
    txtVendorCode = $('#txtVendorCode');
    labelName = $('#labelName');

    VehicleAutoComplete('txtVehicleNo', 'hdnVehicleId');
    txtVehicleNo.blur(function () { return IsVehicleNoExist(txtVehicleNo, hdnVehicleId); });

    VendorAutoComplete('txtVendorCode', 'hdnVendorId', '', 6);
    txtVendorCode.blur(function () { IsVendorCodeExist(txtVendorCode, hdnVendorId, labelName, '', 6); });

    btnSubmit = $('#btnSubmit');
    btnSubmit.click(ViewReport);

});

function ViewReport() {
    var prmList = [
        { Name: "FromDate", Value: drTripsheetDate.startDate },
        { Name: "ToDate", Value: drTripsheetDate.endDate },
        { Name: "StartLocationId", Value: ddlLocationId.val() },
        { Name: "TripsheetNo", Value: txtTripsheetNo.val() == '' ? ' ' : txtTripsheetNo.val() },
        { Name: "VehicleId", Value: hdnVehicleId.val() },
        { Name: "VendorId", Value: hdnVendorId.val() }];
    var reportInfo = { PrmList: prmList, Name: 'FuelVendorReport', Description: 'Fuel Vendor Report' };
    return ShowReport(reportInfo);
}
