var drPaymentDate, txtPaymentNo, txtCancelReason, dtVendorBillPaymentList, SelectPayment, baseUrl,selectedAdvList;
var txtCancelDate, currentDate, dateTimeFormat;

$(document).ready(function () {
    SetPageLoad('Vendor', 'Advance payment Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtPaymentNo = $('#txtPaymentNo');
    drPaymentDate = InitDateRange('drPaymentDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetAdvancePaymentList },
     { StepName: 'Advance List', StepFunction: CheckStepValid }
    ], 'Payment Cancel');
}

function GetAdvancePaymentList() {

    var requestData = {
        PaymentNos: txtPaymentNo.val(), fromDate: drPaymentDate.startDate, toDate: drPaymentDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetAdvancePaymentForCancellation', JSON.stringify(requestData), function (result) {

        selectedAdvList = [];
        if (dtVendorBillPaymentList == null)
            dtVendorBillPaymentList = LoadDataTable('dtVendorBillPaymentList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('ChkAllPayment', SelectPayment), data: "PaymentId" },
                    { title: 'Payment No', data: 'PaymentNo' },
                    { title: 'Payment Date', data: 'PaymentDate' },
                    { title: 'Location', data: 'LocationCode' },
                    { title: "Cancel Reason", data: 'CancelReason' },
                    { title: "Cancel Date", data: 'CancelDate' }
                ]);
        dtVendorBillPaymentList.fnClearTable();
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.PaymentId = SelectAll.GetChk('ChkAllPayment', 'ChkPayment' + i, 'Details[' + i + '].IsChecked', SelectPayment) +
                                "<input type='hidden' value='" + item.PaymentId + "' name='Details[" + i + "].PaymentId' id='hdnPaymentId" + i + "'/>" +
                                "<label class='label' for='ChkPayment" + i + "' id='lblPaymentId" + i + "'></label>";
                item.PaymentDate = $.displayDate(item.PaymentDate);
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

            });
            dtVendorBillPaymentList.dtAddData(result);
            $('[id*="txtCancelDate"]').each(function () {
                var txtCancelDate = $(this);
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            $('[id*="ChkPayment"]').change(function () {
                var ChkPayment = $(this);
                var txtReason = $('#' + ChkPayment.Id.replace('ChkPayment', 'txtCancelReason'));
                var txtCancelDate = $('#' + ChkPayment.Id.replace('ChkPayment', 'txtCancelDate'));
                txtReason.enable(ChkPayment.IsChecked).val('');
                txtCancelDate.enable(ChkPayment.IsChecked).val('');
                if (ChkPayment.IsChecked) {
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
    $('[id*="ChkPayment"]').each(function () {
        var ChkPayment = $(this);
        var txtReason = $('#' + ChkPayment.Id.replace('ChkPayment', 'txtCancelReason'));
        if (ChkPayment.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}
function SelectPayment() {
    selectedAdvList = []
    $('[id*="ChkPayment"]').each(function () {
        var ChkPayment = $(this);
        if (ChkPayment.IsChecked) {
            selectedAdvList.push($('#' + ChkPayment.Id.replace('ChkPayment', 'hdnPaymentId')).val());
        }
    });
}
function CheckStepValid() {
    if (selectedAdvList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Payment');
        return false;
    }
}