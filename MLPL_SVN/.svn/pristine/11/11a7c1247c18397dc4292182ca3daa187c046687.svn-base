var docketNomenclature, drMrDate, txtMrNo, txtCancelReason, dtMrBillList, SelectMr, baseUrl, selectedBillList;
var txtCancelDate, currentDate, dateTimeFormat;

$(document).ready(function () {
    SetPageLoad('Delivery Mr', 'Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtMrNo = $('#txtMrNo');
    drMrDate = InitDateRange('drMrDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetDeliveryMrBillList },
     { StepName: 'Mr List', StepFunction: CheckStepValid }
    ], 'Delivery Mr Cancel');
}

function GetDeliveryMrBillList() {

    var requestData = {
        mrNos: txtMrNo.val(), fromDate: drMrDate.startDate, toDate: drMrDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetDeliveryMrBillListForCancellation', JSON.stringify(requestData), function (result) {

        selectedBillList = [];
        if (dtMrBillList == null)
            dtMrBillList = LoadDataTable('dtMrBillList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllMr', SelectMr), data: "MrId" },
                    { title: 'Mr No', data: 'MrNo' },
                    { title: 'Manual Mr No', data: 'ManualMrNo' },
                    { title: 'Mr Date', data: 'MrDate' },
                    { title: 'Location', data: 'LocationCode' },
                    { title: "Cancel Reason", data: 'CancelReason' },
                    { title: "Cancel Date", data: 'CancelDate' }
                ]);
        dtMrBillList.fnClearTable();
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.MrId = SelectAll.GetChk('chkAllMr', 'chkMr' + i, 'Details[' + i + '].IsChecked', SelectMr) +
                                "<input type='hidden' value='" + item.MrId + "' name='Details[" + i + "].MrId' id='hdnMrId" + i + "'/>" +
                                "<label class='label' for='chkMr" + i + "' id='lblMrId" + i + "'></label>";
                item.MrDate = $.displayDate(item.MrDate);
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

            });
            dtMrBillList.dtAddData(result);
            $('[id*="txtCancelDate"]').each(function () {
                var txtCancelDate = $(this);
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            $('[id*="chkMr"]').change(function () {
                var chkMr = $(this);
                var txtReason = $('#' + chkMr.Id.replace('chkMr', 'txtCancelReason'));
                var txtCancelDate = $('#' + chkMr.Id.replace('chkMr', 'txtCancelDate'));
                txtReason.enable(chkMr.IsChecked).val('');
                txtCancelDate.enable(chkMr.IsChecked).val('');
                if (chkMr.IsChecked) {
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
    $('[id*="chkMr"]').each(function () {
        var chkMr = $(this);
        var txtReason = $('#' + chkMr.Id.replace('chkMr', 'txtCancelReason'));
        if (chkMr.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}
function SelectMr() {
    selectedBillList = []
    $('[id*="chkMr"]').each(function () {
        var chkMr = $(this);
        if (chkMr.IsChecked) {
            selectedBillList.push($('#' + chkMr.Id.replace('chkMr', 'hdnMrId')).val());
        }
    });
}
function CheckStepValid() {
    if (selectedBillList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Mr');
        return false;
    }
}