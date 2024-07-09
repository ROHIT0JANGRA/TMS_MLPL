var drAdviceDate, txtAdviceNo, txtCancelReason, dtAdviceList, SelectAdvice, baseUrl, selectedAdviceList;
var txtCancelDate, currentDate, dateTimeFormat;

$(document).ready(function () {
    SetPageLoad('Account', 'Advice Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtAdviceNo = $('#txtAdviceNo');
    drAdviceDate = InitDateRange('drAdviceDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GeAdviceList },
     { StepName: 'Advice List', StepFunction: CheckStepValid }
    ], 'Advice Cancel');
}

function GeAdviceList() {

    var requestData = {
        AdviceNos: txtAdviceNo.val(), fromDate: drAdviceDate.startDate, toDate: drAdviceDate.endDate
    };

    AjaxRequestWithPostAndJson(baseUrl + '/GetAdvicerForCancellation', JSON.stringify(requestData), function (result) {

        selectedAdviceList = [];
        if (dtAdviceList == null)
            dtAdviceList = LoadDataTable('dtAdviceList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('ChkAllAdvice', SelectAdvice), data: "AdviceId" },
                    { title: 'Advice No', data: 'AdviceNo' },
                    { title: 'Advice Date', data: 'AdviceDate' },
                    { title: "Cancel Reason", data: 'CancelReason' },
                    { title: "Cancel Date", data: 'CancelDate' }
                ]);
        dtAdviceList.fnClearTable();
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.AdviceId = SelectAll.GetChk('ChkAllAdvice', 'ChkAdvice' + i, 'Details[' + i + '].IsChecked', SelectAdvice) +
                                "<input type='hidden' value='" + item.AdviceId + "' name='Details[" + i + "].AdviceId' id='hdnAdviceId" + i + "'/>" +
                                "<label class='label' for='ChkAdvice" + i + "' id='lblAdviceId" + i + "'></label>";
                item.AdviceDate = $.displayDate(item.AdviceDate);
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

            });
            dtAdviceList.dtAddData(result);
            $('[id*="txtCancelDate"]').each(function () {
                var txtCancelDate = $(this);
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            $('[id*="ChkAdvice"]').change(function () {
                var ChkAdvice = $(this);
                var txtReason = $('#' + ChkAdvice.Id.replace('ChkAdvice', 'txtCancelReason'));
                var txtCancelDate = $('#' + ChkAdvice.Id.replace('ChkAdvice', 'txtCancelDate'));
                txtReason.enable(ChkAdvice.IsChecked).val('');
                txtCancelDate.enable(ChkAdvice.IsChecked).val('');
                if (ChkAdvice.IsChecked) {
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
}
function OnCancelReasonChange() {
    $('[id*="ChkAdvice"]').each(function () {
        var ChkAdvice = $(this);
        var txtReason = $('#' + ChkAdvice.Id.replace('ChkAdvice', 'txtCancelReason'));
        if (ChkAdvice.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}
function SelectAdvice() {
    selectedAdviceList = []
    $('[id*="ChkAdvice"]').each(function () {
        var ChkAdvice = $(this);
        if (ChkAdvice.IsChecked) {
            selectedAdviceList.push($('#' + ChkAdvice.Id.replace('ChkAdvice', 'hdnAdviceId')).val());
        }
    });
}
function CheckStepValid() {
    if (selectedAdviceList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Advice');
        return false;
    }
}