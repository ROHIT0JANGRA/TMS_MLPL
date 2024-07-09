var baseUrl;
var txtChequeDateCriteria, txtChequeNo, hdnChequeId, lblChequeNo, lblChequeDate, txtChequeAmount, lblIsOnAccount, txtCollectionAmount, txtBalanceAmount, lblPartyCode, lblPartyName;
var lblEntryDate, lblBankName, lblBranchName, ddlBankAccountId, hdnPartyCode, hdnPartyName;
$(document).ready(function () {
    SetPageLoad('Cheque', 'Deposit', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtChequeDateCriteria = $('#txtChequeDateCriteria');
    txtChequeNo = $('#txtChequeNo');
    hdnChequeId = $('#hdnChequeId');
    lblChequeNo = $('#lblChequeNo');
    hdnChequeDate = $('#hdnChequeDate');
    lblChequeDate = $('#lblChequeDate');
    txtChequeAmount = $('#txtChequeAmount');
    lblIsOnAccount = $('#lblIsOnAccount');
    txtCollectionAmount = $('#txtCollectionAmount');
    txtBalanceAmount = $('#txtBalanceAmount');
    lblPartyCode = $('#lblPartyCode');
    lblPartyName = $('#lblPartyName');
    lblEntryDate = $('#lblEntryDate');
    lblBankName = $('#lblBankName');
    lblBranchName = $('#lblBranchName');
    ddlBankAccountId = $('#ddlBankAccountId');
    hdnPartyCode = $('#hdnPartyCode');
    hdnPartyName = $('#hdnPartyName');

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetChequeDetail },
     { StepName: 'Cheque Details' }
    ], 'Deposit Cheque');
}

function GetChequeDetail() {
    var requestData = { chequeDate: txtChequeDateCriteria.val(), chequeNo: txtChequeNo.val() };

    AjaxRequestWithPostAndJson(baseUrl + '/GetChequeDetail', JSON.stringify(requestData), function (result) {
        if (result.ChequeId == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            hdnChequeId.val(result.ChequeId);
            lblChequeNo.text(result.ChequeNo);
            hdnChequeDate.val($.displayDate(result.ChequeDate));
            lblChequeDate.text($.displayDate(result.ChequeDate));
            txtChequeAmount.val(result.ChequeAmount);
            lblIsOnAccount.text(result.IsOnAccount == true ? 'Yes' : 'No');
            txtCollectionAmount.val(result.CollectionAmount);
            txtBalanceAmount.val(result.BalanceAmount);
            lblPartyCode.text(result.PartyCode);
            hdnPartyCode.val(result.PartyCode);
            lblPartyName.text(result.PartyName);
            hdnPartyName.val(result.PartyName);
            lblEntryDate.text($.displayDate(result.EntryDate));
            lblBankName.text(result.BankName);
            lblBranchName.text(result.BranchName);
        }
    }, ErrorFunction, false);
    return false;
}