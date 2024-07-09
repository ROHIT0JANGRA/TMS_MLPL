var ddlsearchBy, txtTripsheetNo, dtTripsheetDetailList, drTripsheetDate, TripsheetUrl, ddlTripsheetAction, selectedTripsheetId, hdnVehicleId, selectedTripsheetList
var txtCancelReason
var txtCancelDate, currentDate, dateTimeFormat;
$(document).ready(function () {
    SetPageLoad('Tripsheet', 'Tripsheet Settlement Cancellation', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    ddlsearchBy = $('#ddlsearchBy');
    txtTripsheetNo = $('#txtTripsheetNo');
    /* dtTripsheetDetailList = $('#dtTripsheetDetailList');*/
    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek);
    hdnVehicleId = $('#hdnVehicleId');
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');
    ddlTripsheetAction = $('#ddlTripsheetAction');
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetTripsheetList },
        { StepName: 'Tripsheet List', StepFunction: CheckStepValid }
    ], 'Tripsheet Settlement Cancel');
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
        searchBy: ddlsearchBy.val(), TripsheetNo: txtTripsheetNo.val(), fromDate: drTripsheetDate.startDate, toDate: drTripsheetDate.endDate, tripsheetAction: ddlTripsheetAction.val()
    };
    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetTripsheetListForTripsheetSettlementCancellation', JSON.stringify(requestData), function (result) {

        selectedTripsheetList = [];

        if (dtTripsheetDetailList == null)
            dtTripsheetDetailList = LoadDataTable('dtTripsheetDetailList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllTripsheet', SelectTripsheet), data: "TripsheetId" },
                    { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                    { title: 'Tripsheet No', data: 'TripsheetNo' },
                    { title: 'Tripsheet Date', data: 'TripsheetDate' },
                    { title: 'Driver', data: 'FirstDriverName' },
                    { title: 'Cancel Date', data: 'CancelDate' },
                    { title: 'Cancel Reason', data: 'CancelReason' }
                ]);

        dtTripsheetDetailList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.TripsheetId = SelectAll.GetChk('chkAllTripsheet', 'chkTripsheet' + i, 'Details[' + i + '].IsChecked', SelectTripsheet) +
                    "<input type='hidden' value='" + item.TripsheetId + "' name='Details[" + i + "].TripsheetId' id='hdnTripsheetId" + i + "'/>" +
                    "<label class='label' for='chkTripsheetId" + i + "' id='lblTripsheetId" + i + "'></label>" +
                    "<label class='label' for='chkTripsheetId" + i + "' id='lblManualTripsheetNo" + i + "'></label>" +
                    "<label class='label' for='chkTripsheetId" + i + "' id='lblTripsheetNo" + i + "'></label>";
                item.TripsheetDate = $.displayDate(item.TripsheetDate);
                item.FirstDriverName = '<input type=\'text\' name="Details[' + i + '].FirstDriverName" id="lblFirstDriverName' + i + '" value="' + item.FirstDriverName + '" class="form-control textlabel numeric2" style="width: 100px;" />';
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                    '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                    "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                    '</div>' +
                    '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

            });
            dtTripsheetDetailList.dtAddData(result);
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
                    txtReason.val(txtCancelReason.val());
                    AddRequired(txtCancelDate, 'Enter Cancel Date');
                    txtCancelDate.val(txtCancelDate.val());
                }
                else
                    RemoveRequired(txtReason);
                RemoveRequired(txtCancelDate);
            });
            txtCancelReason.blur(OnCancelReasonChange);
        }
    }, ErrorFunction, false);
    return false;
}

function SelectTripsheet() {
    selectedTripsheetList = []
    $('[id*="chkTripsheet"]').each(function () {
        var chkTripsheet = $(this);
        if (chkTripsheet.IsChecked) {
            selectedTripsheetList.push($('#' + chkTripsheet.Id.replace('chkTripsheet', 'hdnTripsheetId')).val());
        }
    });
}
function OnCancelReasonChange() {
    $('[id*="chkTripsheet"]').each(function () {
        var chkTripsheet = $(this);
        var txtReason = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtCancelReason'));
        if (chkTripsheet.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}
function CheckStepValid() {
    if (selectedTripsheetList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Tripsheet');
        return false;
    }
}
