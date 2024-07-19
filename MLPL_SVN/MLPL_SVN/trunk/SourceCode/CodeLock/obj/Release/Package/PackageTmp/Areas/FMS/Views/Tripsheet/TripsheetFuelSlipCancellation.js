var ddlsearchBy, txtTripsheetNo, dtTripsheetList, dtTripsheetFuelSlipList, drTripsheetDate, TripsheetUrl, selectedTripsheetId, hdnVehicleId, selectedTripsheetList
var txtCancelDate, currentDate, dateTimeFormat;
var selectedTripsheet = 0;
$(document).ready(function () {
    SetPageLoad('Tripsheet', 'Fuel Slip Cancellation', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    ddlsearchBy = $('#ddlsearchBy');
    txtTripsheetNo = $('#txtTripsheetNo');
    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek);
    hdnVehicleId = $('#hdnVehicleId');
    txtCancelDate = $('#txtCancelDate');
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetTripsheetList },
        { StepName: 'Tripsheet List', StepFunction: GetTripsheetFuelSlipList },
        { StepName: 'Tripsheet Fuel Slip List', StepFunction: CheckStepValid }
    ], 'Cancel');

    dtTripsheetList = LoadDataTable('dtTripsheetList', false, false, false, null, null, [],
        [
            { title: "Select", data: "TripsheetId", width: 80 },
            { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
            { title: 'Tripsheet No', data: 'TripsheetNo' },
            { title: 'Tripsheet Date', data: 'TripsheetDate' },
            { title: 'Driver', data: 'FirstDriverName' },
            { title: 'Vehicle No', data: "VehicleNo" }
        ]);

    dtTripsheetFuelSlipList = LoadDataTable('dtTripsheetFuelSlipList', false, false, false, null, null, [],
        [
            { title: SelectAll.GetChkAll('chkAllTripsheet', SelectFuelSlip), data: "TripsheetId" },
            { title: 'Fuel Vendor', data: 'FuelVendorName' },
            { title: 'Slip No', data: 'SlipNo' },
            { title: 'Fuel Slip Date', data: 'FuelSlipDate' },
            { title: 'Quantity', data: 'Quantity' },
            { title: 'Rate', data: 'Rate' },
            { title: 'Amount', data: 'Amount' },
            { title: 'Cancel Date', data: 'CancelDate' },
            { title: 'Cancel Reason', data: 'CancelReason' }
        ]);
}

function AttachEvents() {
    ddlsearchBy.change(SearchByChange);
}

function SearchByChange() {
    txtTripsheetNo.val('');
    hdnVehicleId.val(0);
    if (ddlsearchBy.val() == 3) {
        VehicleAutoComplete('txtTripsheetNo', 'hdnVehicleId');
        txtTripsheetNo.blur(function () { IsVehicleNoExist(txtTripsheetNo, hdnVehicleId); });
    }
    else {
        /* txtTripsheetNo.autocomplete("destroy");*/
        txtTripsheetNo.off('blur');
    }
}

function GetTripsheetList() {
    var requestData = {
        searchBy: ddlsearchBy.val(), TripsheetNo: txtTripsheetNo.val(), fromDate: drTripsheetDate.startDate, toDate: drTripsheetDate.endDate
    };
    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetTripsheetListForTripsheetFuelSlipCancellation', JSON.stringify(requestData), GetTripsheetListSuccess, ErrorFunction, false);
    return false;
}

function GetTripsheetListSuccess(responseData) {
    if (responseData.length == 0) {
        isStepValid = false;
        ShowMessage('No Record Found');
        return false;
    }
    else {
        dtTripsheetList.fnClearTable();
        $.each(responseData, function (i, item) {
            item.TripsheetId = '<div class="clearfix">' +
                '<label class="radio">' +
                '<input type="radio" name=\'Tripsheet\' value=\'' + item.TripsheetId + '\' onclick="SelectTripsheet(this.id);" tabindex="0" id="rdTripsheetNo' + i + '"/><i></i>' +
                '<label for="rdTripsheetNo' + i + '">' + '' + '</label>' +
                '</label>' +
                '</div>';
            item.TripsheetDate = $.displayDate(item.TripsheetDate);
        });
        dtTripsheetList.dtAddData(responseData);
    }
}

function SelectTripsheet(rdId) {
    selectedTripsheet = $('#' + rdId).val();
}

function GetTripsheetFuelSlipList() {
    if (selectedTripsheet == 0) {
        isStepValid = false;
        ShowMessage('Please select Tripsheet');
        return false;
    }
    else {
        var requestData = {
            tripsheetId: selectedTripsheet
        };
        AjaxRequestWithPostAndJson(TripsheetUrl + '/GetFuelSlipListForTripsheetFuelSlipCancellation', JSON.stringify(requestData), function (result) {

            selectedTripsheetList = [];
            dtTripsheetFuelSlipList.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                $.each(result, function (i, item) {
                    item.TripsheetId = SelectAll.GetChk('chkAllTripsheet', 'chkTripsheet' + i, 'Details[' + i + '].IsChecked', SelectFuelSlip) +
                        "<input type='hidden' value='" + item.TripsheetId + "' name='Details[" + i + "].TripsheetId' id='hdnTripsheetId" + i + "'/>" +
                        "<input type='hidden' value='" + item.FuelVendorId + "' name='Details[" + i + "].FuelVendorId' id='hdnFuelVendorId" + i + "'/>" +
                        "<input type='hidden' value='" + item.SlipNo + "' name='Details[" + i + "].SlipNo' id='hdnSlipNo" + i + "'/>" +
                        "<input type='hidden' value='" + $.displayDate(item.FuelSlipDate) + "' name='Details[" + i + "].FuelSlipDate' id='hdnFuelSlipDate" + i + "'/>" +
                        "<input type='hidden' value='" + item.Quantity + "' name='Details[" + i + "].Quantity' id='hdnQuantity" + i + "'/>" +
                        "<input type='hidden' value='" + item.Rate + "' name='Details[" + i + "].Rate' id='hdnRate" + i + "'/>" +
                        "<input type='hidden' value='" + item.Amount + "' name='Details[" + i + "].Amount' id='hdnAmount" + i + "'/>" +
                        "<label class='label' for='chkTripsheetId" + i + "' id='lblTripsheetId" + i + "'></label>";
                    item.FuelSlipDate = $.displayDate(item.FuelSlipDate);
                    item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                        '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                    item.CancelDate = "<div class='input'>" +
                        '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                        '</div>' +
                        '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

                });
                dtTripsheetFuelSlipList.dtAddData(result);
                $('[id*="txtCancelDate"]').each(function () {
                    var txtCancelDate = $(this);
                    InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
                });
                $('[id*="chkTripsheet"]').change(function () {
                    var chkTripsheet = $(this);
                    var txtReason = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtCancelReason'));
                    var txtCancelDate = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtCancelDate'));
                    txtReason.enable(chkTripsheet.IsChecked).val('');
                    txtCancelDate.enable(chkTripsheet.IsChecked).val('');
                    if (chkTripsheet.IsChecked) {
                        AddRequired(txtReason, 'Enter Cancel Reason');
                        AddRequired(txtCancelDate, 'Enter Cancel Date');
                    }
                    else {
                        RemoveRequired(txtReason);
                        RemoveRequired(txtCancelDate);
                        txtReason.val('');
                        txtCancelDate.val('');
                    }
                });
            }
        }, ErrorFunction, false);
        return false;
    }
}

function SelectFuelSlip() {
    selectedTripsheetList = []
    $('[id*="chkTripsheet"]').each(function () {
        var chkTripsheet = $(this);
        if (chkTripsheet.IsChecked) {
            selectedTripsheetList.push($('#' + chkTripsheet.Id.replace('chkTripsheet', 'hdnTripsheetId')).val());
        }
    });
}

function CheckStepValid() {
    if (selectedTripsheetList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Tripsheet');
        return false;
    }
}
