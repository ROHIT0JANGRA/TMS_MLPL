var docketNomenclature, drDrsDate, txtDrsNo, txtCancelReason, txtManualDrsNo, dtDrsCloseDetails, selectedDrsList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;
$(document).ready(function () {
    SetPageLoad('DRS', 'Close Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtDrsNo = $('#txtDrsNo');
    txtManualDrsNo = $('#txtManualDrsNo');
    drDrsDate = InitDateRange('drDrsDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDrsCloseList },
        { StepName: 'Drs List',StepFunction:CheckValidStep2},
        { StepName: 'Drs Detail'}
    ], 'Drs Cancel');
}

function GetDrsCloseList() {
    var requestData = {
        drsNo: txtDrsNo.val(), fromDate: drDrsDate.startDate, toDate: drDrsDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetDrsListForDrsCloseCancellation', JSON.stringify(requestData), function (result) {

        selectedDrsList = 0;

        if (dtDrsCloseDetails == null)
            dtDrsCloseDetails = LoadDataTable('dtDrsCloseDetails', false, false, false, null, null, [],
                [
                  
                    { title: 'Drs No', data: 'DrsNo' } ,                  
                    { title: 'Drs Date', data: 'DrsDate' },
                    { title: 'Close Date', data: 'UpdateDate' },
                    { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },

                ]);

        dtDrsCloseDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.DrsNo = '<div class="clearfix">' +
                    '<label class="radio">' +
                    '<input type="radio" name=\'Drs\' value=\'' + item.DrsId + '\' onclick="SelectDrs(this)" tabindex="0" id="chkDrsNo' + i + '"/><i></i>' +
                    "<input type='hidden' value='" + item.DrsId + "' name='Details[" + i + "].DrsId' id='hdnDrsId" + i + "'/>" +
                    '<label for="chkDrsNo' + i + '">' + item.DrsNo
                '</div>'; 
                item.DrsDate = $.displayDate(item.DrsDate);
                item.UpdateDate = $.displayDate(item.UpdateDate);

            });
            dtDrsCloseDetails.dtAddData(result);
        }
    }, ErrorFunction, false);
    return false;
}
function SelectDrs(rd) {
    selectedDrsList = rd.value;
    $('#hdnDrsId').val(selectedDrsList);
}

  function CheckValidStep2() {
    if (selectedDrsList === 0 ) {
        isStepValid = false;
        ShowMessage('Please select Drs');
        return false;
    }
}