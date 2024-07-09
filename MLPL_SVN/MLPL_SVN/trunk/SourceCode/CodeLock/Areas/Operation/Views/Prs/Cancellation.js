var docketNomenclature, drPrsDate, txtPrsNo, txtCancelReason, txtManualPrsNo, dtPrsDetails, selectedPrsList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;

$(document).ready(function () {
    SetPageLoad('PRS', 'Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtPrsNo = $('#txtPrsNo');
    txtManualPrsNo = $('#txtManualPrsNo');
    drPrsDate = InitDateRange('drPrsDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
    { StepName: 'Criteria', StepFunction: GetPrsList },
    { StepName: 'PRS List', StepFunction: CheckStepValid }
    ], 'PRS Cancel');
}

function GetPrsList() {
    var requestData = {
        prsNo: txtPrsNo.val(), manualPrsNo: txtManualPrsNo.val(), fromDate: drPrsDate.startDate, toDate: drPrsDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetPrsListForCancellation', JSON.stringify(requestData), function (result) {

        selectedPrsList = [];

        if (dtPrsDetails == null)
            dtPrsDetails = LoadDataTable('dtPrsDetails', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllPrs', SelectPrs), data: "PrsId" },
                  { title: 'PRS No', data: 'PrsNo' },
                  { title: 'Manual PRS No', data: 'ManualPrsNo' },
                  { title: 'PRS Date', data: 'PrsDate' },
                  { title: 'Location', data: 'LocationCode' },
                  { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                  { title: "Cancel Reason", data: 'CancelReason' },
                  { title: "Cancel Date", data: 'CancelDate' }
              ]);

        dtPrsDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.PrsId = SelectAll.GetChk('chkAllPrs', 'chkPrs' + i, 'Details[' + i + '].IsChecked', SelectPrs) +
                               "<input type='hidden' value='" + item.PrsId + "' name='Details[" + i + "].PrsId' id='hdnPrsbId" + i + "'/>" +
                               "<label class='label' for='chkPrs" + i + "' id='lblPrsId" + i + "'></label>";
                item.PrsDate = $.displayDate(item.PrsDate);
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

            });
            dtPrsDetails.dtAddData(result);
            $('[id*="txtCancelDate"]').each(function () {
                var txtCancelDate = $(this);
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            $('[id*="chkPrs"]').change(function () {
                var chkPrs = $(this);
                var txtReason = $('#' + chkPrs.Id.replace('chkPrs', 'txtCancelReason'));
                var txtCancelDate = $('#' + chkPrs.Id.replace('chkPrs', 'txtCancelDate'));
                txtReason.enable(chkPrs.IsChecked).val('');
                txtCancelDate.enable(chkPrs.IsChecked).val('');
                if (chkPrs.IsChecked) {
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
    $('[id*="chkPrs"]').each(function () {
        var chkPrs = $(this);
        var txtReason = $('#' + chkPrs.Id.replace('chkPrs', 'txtCancelReason'));
        if (chkPrs.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}

function SelectPrs() {
    selectedPrsList = []
    $('[id*="chkPrs"]').each(function () {
        var chkPrs = $(this);
        if (chkPrs.IsChecked) {
            selectedPrsList.push($('#' + chkPrs.Id.replace('chkPrs', 'hdnPrsId')).val());
        }
    });
}

function CheckStepValid() {
    if (selectedPrsList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one PRS');
        return false;
    }
}