var docketNomenclature, drDrsDate, txtDrsNo, txtCancelReason, txtManualDrsNo, dtDrsDetails, selectedDrsList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;
$(document).ready(function () {
    SetPageLoad('DRS', 'Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtDrsNo = $('#txtDrsNo');
    txtManualDrsNo = $('#txtManualDrsNo');
    drDrsDate = InitDateRange('drDrsDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');
    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetDrsList },
     { StepName: 'Drs List', StepFunction: CheckStepValid }
    ], 'Drs Cancel');
}

function GetDrsList() {
    var requestData = {
        drsNo: txtDrsNo.val(), manualDrsNo: txtManualDrsNo.val(), fromDate: drDrsDate.startDate, toDate: drDrsDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetDrsListForCancellation', JSON.stringify(requestData), function (result) {

        selectedDrsList = [];

        if (dtDrsDetails == null)
            dtDrsDetails = LoadDataTable('dtDrsDetails', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllDrs', SelectDrs), data: "DrsId" },
                  { title: 'Drs No', data: 'DrsNo' },
                  { title: 'Manual Drs No', data: 'ManualDrsNo' },
                  { title: 'Drs Date', data: 'DrsDate' },
                  { title: 'Origin', data: 'LocationCode' },
                  { title: 'Vehicle No', data: 'VehicleNo' },
                  { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                  { title: "Cancel Reason", data: 'CancelReason' },
                  { title: "Cancel Date", data: 'CancelDate' }
              ]);

        dtDrsDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.DrsId = SelectAll.GetChk('chkAllDrs', 'chkDrs' + i, 'Details[' + i + '].IsChecked', SelectDrs) +
                               "<input type='hidden' value='" + item.DrsId + "' name='Details[" + i + "].DrsId' id='hdnDrsbId" + i + "'/>" +
                               "<label class='label' for='chkDrs" + i + "' id='lblDrsId" + i + "'></label>";
                item.DrsDate = $.displayDate(item.DrsDate);
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

            });
            dtDrsDetails.dtAddData(result);
            $('[id*="txtCancelDate"]').each(function () {
                var txtCancelDate = $(this);
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            $('[id*="chkDrs"]').change(function () {
                var chkDrs = $(this);
                var txtReason = $('#' + chkDrs.Id.replace('chkDrs', 'txtCancelReason'));
                var txtCancelDate = $('#' + chkDrs.Id.replace('chkDrs', 'txtCancelDate'));
                txtReason.enable(chkDrs.IsChecked).val('');
                txtCancelDate.enable(chkDrs.IsChecked).val('');
                if (chkDrs.IsChecked) {
                    AddRequired(txtReason, 'Enter Cancel Reason');
                    txtReason.val(txtCancelReason.val());
                    AddRequired(txtCancelDate, 'Enter Cancel Reason');
                    txtCancelDate.val(txtCancelReason.val());
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

function OnCancelReasonChange() {
    $('[id*="chkDrs"]').each(function () {
        var chkDrs = $(this);
        var txtReason = $('#' + chkDrs.Id.replace('chkDrs', 'txtCancelReason'));
        if (chkDrs.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}

function SelectDrs() {
    selectedDrsList = []
    $('[id*="chkDrs"]').each(function () {
        var chkDrs = $(this);
        if (chkDrs.IsChecked) {
            selectedDrsList.push($('#' + chkDrs.Id.replace('chkDrs', 'hdnDrsId')).val());
        }
    });
}

function CheckStepValid() {
    if (selectedDrsList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Drs');
        return false;
    }
}