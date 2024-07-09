var txtAdviceNo, drAdviceDate, dtAdviceList, selectedAdviceList, accountsUrl;
var currentDate, dateTimeFormat, cashAccountList, bankAccountList,test;

$(document).ready(function () {
    
    SetPageLoad('Advice', 'Acknowledgement', '', '', '');
    InitObjects();
    
});

function InitObjects() {
    txtAdviceNo = $('#txtAdviceNo');
    drAdviceDate = InitDateRange('drAdviceDate', DateRange.LastWeek, false);
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetAdviceList },
        { StepName: 'Advice List', StepFunction: ValidateOnSubmit }
    ], 'Submit');
}

function GetAdviceList() {
    var requestData = {
        adviceNos: txtAdviceNo.val(), fromDate: drAdviceDate.startDate, toDate: drAdviceDate.endDate
    };
    
    AjaxRequestWithPostAndJson(accountsUrl + '/GetAdviceListForAcknowledgement', JSON.stringify(requestData), function (result) {

        selectedAdviceList = [];

        if (dtAdviceList == null)
            dtAdviceList = LoadDataTable('dtAdviceList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllAdvice', SelectAdvice), data: "AdviceId" },
                    { title: 'Advice No', data: 'AdviceNo' },
                    { title: 'Advice Type', data: 'AdviceType' },
                    { title: 'Advice Date', data: 'AdviceDate' },
                    { title: 'Transaction Type', data: 'TransactionType' },
                    { title: 'Transaction Description', data: 'TransactionDescription' },
                    { title: 'Raised Location', data: 'RaisedLocation' },
                    { title: 'Raised By', data: 'Location' },
                    { title: 'Advice Status', data: 'AdviceStatus' },
                    { title: 'Amount', data: 'Amount' },
                    { title: 'Cheque No', data: 'ChequeNo' },
                    { title: 'Cheque Date', data: 'ChequeDate' },
                    { title: 'Deposite In', data: 'ToAccountId' },
                    { title: 'Deposite Date', data: 'AcknowledgementDate' }
                ]);

        dtAdviceList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            var customerName;
            $.each(result, function (i, item) {
                item.AdviceId = "<div class='checkboxer'>" +
                                SelectAll.GetChk('chkAllAdvice', 'chkAdvice' + i, 'Details[' + i + '].IsChecked', SelectAdvice) +
                                "<input type='hidden' value='" + item.AdviceId + "' name='Details[" + i + "].AdviceId' id='hdnAdviceId" + i + "'/>" +
                                "<label class='label' for='chkAdvice" + i + "' id='lblAdviceId" + i + "'></label>" +
                                "<input type='hidden' value='" + item.PaymentModeId + "' id='hdnPaymentModeId" + i + "'/>" +
                                "</div>";
                item.AdviceDate = $.displayDate(item.AdviceDate);
                item.Amount = '<input type="text" value=' + item.Amount.toFixed(2) + ' class="textlabel" style="text-align: right" disabled/>';
                item.ChequeDate = item.ChequeNo != null ? $.displayDate(item.ChequeDate) : '';
                item.ToAccountId = "<div class='select'>" +
                    "<select class='form-control' name='Details[" + i + "].ToAccountId' id='ddlToAccountId" + i + "' > " + "</select><i></i>" +
                    "</div>" +
                    '<div><span data-valmsg-for="Details[' + i + '].ToAccountId" data-valmsg-replace="true"></span></div>';
                item.AcknowledgementDate = "<input type='text' name='Details[" + i + "].AcknowledgementDate' id='txtAcknowledgementDate" + i + "'class='form-control datepicker'/>" +
                    '<span data-valmsg-for="Details[' + i + '].AcknowledgementDate" data-valmsg-replace="true"></span>';
            });
            dtAdviceList.dtAddData(result,null,null);
            $('[id*="txtAcknowledgementDate"]').each(function () {
                var txtAcknowledgementDate = $(this);
                var hdnPaymentModeId = $('#' + txtAcknowledgementDate.Id.replace('txtAcknowledgementDate', 'hdnPaymentModeId'));
                var ddlToAccountId = $('#' + txtAcknowledgementDate.Id.replace('txtAcknowledgementDate', 'ddlToAccountId'));
                InitDateTimePicker(txtAcknowledgementDate.Id, false, true, false, currentDate, dateTimeFormat, '', '');
                if (hdnPaymentModeId.val() == 1)
                    BindDropDownList(ddlToAccountId.Id, cashAccountList, 'Value', 'Text', '', 'Select Cash Account');
                else
                    BindDropDownList(ddlToAccountId.Id, bankAccountList, 'Value', 'Text', '', 'Select Bank Account');
            });
        }
    }, ErrorFunction, false);
    return false;
}

function SelectAdvice() {
    selectedAdviceList = []
    $('[id*="chkAdvice"]').each(function () {
        var chkAdvice = $(this);
        var ddlToAccountId = $('#' + chkAdvice.Id.replace('chkAdvice', 'ddlToAccountId'));
        var txtAcknowledgementDate = $('#' + chkAdvice.Id.replace('chkAdvice', 'txtAcknowledgementDate'));
        if (chkAdvice.IsChecked) {
            selectedAdviceList.push($('#' + chkAdvice.Id.replace('chkAdvice', 'hdnAdviceId')).val());
            AddRequired(ddlToAccountId, 'Please select Account');
            AddRequired(txtAcknowledgementDate, 'Please select Deposite Date');
        } else {
            RemoveRequired(ddlToAccountId);
            RemoveRequired(txtAcknowledgementDate);
        }
    });
}

function ValidateOnSubmit() {
    if (selectedAdviceList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Advice');
        return false;
    }
}