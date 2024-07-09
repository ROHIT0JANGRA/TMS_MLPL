var docketNomenclature, drCreditDebitNoteDate, txtCreditDebitNoteNo, txtCancelReason, txtManualCreditDebitNoteNo, dtCreditDebitNoteDetails, selectedCreditDebitNoteList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;
$(document).ready(function () {
    SetPageLoad('Credit/Debit Note', 'Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtNoteNo = $('#txtNoteNo');
    drCreditDebitNoteDate = InitDateRange('drCreditDebitNoteDate', DateRange.LastWeek);
    dtCreditDebitNoteDetails = $('#dtCreditDebitNoteDetails');

    InitWizard('dvWizard', [
      { StepName: 'Criteria', StepFunction: GetCreditDebitNoteList },
      { StepName: 'Credit/Debit Note List', StepFunction: CheckStepValid }
    ], 'Cancel Credit/Debit Note');
}

function GetCreditDebitNoteList() {
    var requestData = {
        NoteNo: txtNoteNo.val(), fromDate: drCreditDebitNoteDate.startDate, toDate: drCreditDebitNoteDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetCreditDebitNoteListForCancellation', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedCreditDebitNoteList = [];

            dtCreditDebitNoteDetails = LoadDataTable('dtCreditDebitNoteDetails', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllCreditDebitNote', SelectCreditDebitNote), data: "NoteId" },
                    { title: 'Note No', data: 'NoteNo' },
                    { title: 'Note Date', data: 'NoteDate' },
                    { title: 'Note Type', data: 'NoteTypeDes' },
                    { title: 'Party Name', data: 'PartyCodeName' },
                    { title: 'Bill Amount', data: 'SubTotalNoteAmount' },
                    { title: 'Gst Amount', data: 'GstNoteAmount' },
                    { title: 'Total Amount', data: 'TotalNoteAmount' },
                    { title: "Cancel Reason", data: 'CancelReason' },
                    { title: "Cancel Date", data: 'CancelDate' }
                ]);

            dtCreditDebitNoteDetails.fnClearTable();
            $.each(result, function (i, item) {
                item.NoteId = SelectAll.GetChk('chkAllCreditDebitNote', 'chkCreditDebitNote' + i, 'Details[' + i + '].IsChecked', SelectCreditDebitNote) +
                               "<input type='hidden' value='" + item.NoteId + "' name='Details[" + i + "].NoteId' id='hdnNoteId" + i + "'/>" +
                               "<label class='label' for='chkCreditDebitNote" + i + "' id='lblNoteId" + i + "'></label>";
                item.NoteDate = $.displayDate(item.NoteDate);
                item.CancelReason = '<div class=\'input\'><input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/></div>' +
                    '<div><span class="field-validation-valid" data-valmsg-for="Details[' + i + '].CancelReason" data-valmsg-replace="true"></span></div>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';
            });
            dtCreditDebitNoteDetails.dtAddData(result);

            $("[id*='chkCreditDebitNote']").each(function () {
                var tr = $(this).closest('tr');
                var txtCancelDate = tr.find('[id*="txtCancelDate"]');
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });


            $('[id*="chkCreditDebitNote"]').change(function () {
                var chkCreditDebitNote = $(this);
                var txtReason = $('#' + chkCreditDebitNote.Id.replace('chkCreditDebitNote', 'txtCancelReason'));
                 var txtCancelDate = $('#' + chkCreditDebitNote.Id.replace('chkCreditDebitNote', 'txtCancelDate'));
                txtReason.enable(chkCreditDebitNote.IsChecked).val('');
                 txtCancelDate.enable(chkCreditDebitNote.IsChecked).val('');
                if (chkCreditDebitNote.IsChecked) {
                    AddRequired(txtReason, 'Enter Cancel Reason');
                    AddRequired(txtCancelDate, 'Enter Cancel Reason');
                }
                else {
                    RemoveRequired(txtReason);
                    RemoveRequired(txtCancelDate);
                }
            });



        }
    }, ErrorFunction, false);
    return false;
}

function OnCancelReasonChange() {
    $('[id*="chkCreditDebitNote"]').each(function () {
        var chkCreditDebitNote = $(this);
        var txtReason = $('#' + chkCreditDebitNote.Id.replace('chkCreditDebitNote', 'txtCancelReason'));
        if (chkCreditDebitNote.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}

function SelectCreditDebitNote() {
    selectedCreditDebitNoteList = []
    $('[id*="chkCreditDebitNote"]').each(function () {
        var chkCreditDebitNote = $(this);
        if (chkCreditDebitNote.IsChecked) {
            selectedCreditDebitNoteList.push($('#' + chkCreditDebitNote.Id.replace('chkCreditDebitNote', 'hdnCreditDebitNoteId')).val());
        }
    });
}

function CheckStepValid() {
    if (selectedCreditDebitNoteList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Credit/Debit Note');
        return false;
    }
}