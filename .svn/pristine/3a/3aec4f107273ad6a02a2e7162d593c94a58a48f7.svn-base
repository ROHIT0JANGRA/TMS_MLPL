var drVoucherDate, txtVoucherNo, txtCancelReason, dtVoucherList, SelectVoucher, baseUrl, selectedVoucherList;
var txtCancelDate, currentDate, dateTimeFormat;

$(document).ready(function () {
    SetPageLoad('Account', 'Voucher Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtVoucherNo = $('#txtVoucherNo');
    drVoucherDate = InitDateRange('drVoucherDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GeVoucherList },
     { StepName: 'Voucher List', StepFunction: CheckStepValid }
    ], 'Voucher Cancel');
}

function GeVoucherList() {

    var requestData = {
        VoucherNos: txtVoucherNo.val(), fromDate: drVoucherDate.startDate, toDate: drVoucherDate.endDate
    };
    
    AjaxRequestWithPostAndJson(baseUrl + '/GetVoucherForCancellation', JSON.stringify(requestData), function (result) {

        selectedVoucherList = [];
        if (dtVoucherList == null)
            dtVoucherList = LoadDataTable('dtVoucherList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('ChkAllVoucher', SelectVoucher), data: "VoucherId" },
                    { title: 'Voucher No', data: 'VoucherNo' },
                    { title: 'Voucher Date', data: 'VoucherDate' },
                    { title: "Cancel Reason", data: 'CancelReason' },
                    { title: "Cancel Date", data: 'CancelDate' }
                ]);
        dtVoucherList.fnClearTable();
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.VoucherId = SelectAll.GetChk('ChkAllVoucher', 'ChkVoucher' + i, 'Details[' + i + '].IsChecked', SelectVoucher) +
                                "<input type='hidden' value='" + item.VoucherId + "' name='Details[" + i + "].VoucherId' id='hdnVoucherId" + i + "'/>" +
                                "<label class='label' for='ChkVoucher" + i + "' id='lblVoucherId" + i + "'></label>";
                item.VoucherDate = $.displayDate(item.VoucherDate);
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

            });
            dtVoucherList.dtAddData(result);
            $('[id*="txtCancelDate"]').each(function () {
                var txtCancelDate = $(this);
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            $('[id*="ChkVoucher"]').change(function () {
                var ChkVoucher = $(this);
                var txtReason = $('#' + ChkVoucher.Id.replace('ChkVoucher', 'txtCancelReason'));
                var txtCancelDate = $('#' + ChkVoucher.Id.replace('ChkVoucher', 'txtCancelDate'));
                txtReason.enable(ChkVoucher.IsChecked).val('');
                txtCancelDate.enable(ChkVoucher.IsChecked).val('');
                if (ChkVoucher.IsChecked) {
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
    $('[id*="ChkVoucher"]').each(function () {
        var ChkVoucher = $(this);
        var txtReason = $('#' + ChkVoucher.Id.replace('ChkVoucher', 'txtCancelReason'));
        if (ChkVoucher.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}
function SelectVoucher() {
    selectedVoucherList = []
    $('[id*="ChkVoucher"]').each(function () {
        var ChkVoucher = $(this);
        if (ChkVoucher.IsChecked) {
            selectedVoucherList.push($('#' + ChkVoucher.Id.replace('ChkVoucher', 'hdnVoucherId')).val());
        }
    });
}
function CheckStepValid() {
    if (selectedVoucherList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Voucher');
        return false;
    }
}