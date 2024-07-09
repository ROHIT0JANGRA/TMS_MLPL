var accountMasterUrl, baseUrl;

$(document).ready(function () {
    SetPageLoad('Set Opening Balance', '', '', '', '');
    InitObjects();
    AttachEvents();
});

var rdLocationWise, rdAccountWise, lblCod, hdnCodeIde, hdnCodeId, txtCode, ddlAccountCategoryId, ddlLocationId, ddlAccountId, dvAccount, dvLocation;
function InitObjects() {
    rdAccountWise = $('#rdAccountWise'); rdLocationWise = $('#rdLocationWise'); lblCode = $('#lblCode'); lblName = $('#lblName'); hdnCodeId = $('#hdnCodeId'); txtCode = $('#txtCode'); ddlAccountCategoryId = $('#ddlAccountCategoryId'); ddlLocationId = $('#ddlLocationId'); ddlAccountId = $('#ddlAccountId'); dvAccount = $('#dvAccount'); dvLocation = $('#dvLocation');

    $('#ddlLocationId option').eq(0).before($('<option>', { value: 0, text: 'All' }));
    ddlLocationId. val(0);
}

function AttachEvents() {
    txtCode.blur(function () { return CheckIsValid(txtCode, hdnCodeId); });
    rdAccountWise.change(OnTypeChange);
    rdLocationWise.change(OnTypeChange).check();
    OnTypeChange();
    ddlAccountCategoryId.change(OnAccountCategoryChange);

    InitWizard('dvWizard', [
    { StepName: 'Criteria', StepFunction: GetAccountList },
    { StepName: 'Account Opening Party List', StepFunction: StepValid }
    ], 'Submit');
}
function OnTypeChange() {
    dvAccount.showHide(rdLocationWise.IsChecked);
    dvLocation.showHide(!rdLocationWise.IsChecked);
    txtCode.val('');
    hdnCodeId.val('');
    ddlAccountCategoryId.enable(rdLocationWise.IsChecked);
    if (rdLocationWise.IsChecked) {
        lblCode.text("Location");
        LocationAutoComplete('txtCode', 'hdnCodeId');
        AddRequired(ddlAccountCategoryId, 'Please select Account Category');
        RemoveRequired(txtCode);
        AddRequired(txtCode, 'Please enter Location');
    }
    else {
        lblCode.text("Account");
        AccountAutoComplete('txtCode', 'hdnCodeId');
        RemoveRequired(txtCode);
        AddRequired(txtCode, 'Please enter Account');
        RemoveRequired(ddlAccountCategoryId);
    }

    return false;
}

function CheckIsValid(objName, objHdnId) {
    if (rdLocationWise.IsChecked)
        IsLocationCodeExist(objName, objHdnId, 'Location');
    else
        IsAccountNameExist(objName, objHdnId, lblName, 'Account');
}

function OnAccountCategoryChange() {
    if (ddlAccountCategoryId.val() != "") {
        var requestData = { categoryId: ddlAccountCategoryId.val() };
        AjaxRequestWithPostAndJson(accountMasterUrl + '/GetAccountListByAccountCategoryId', JSON.stringify(requestData), GetAccountListSuccess, ErrorFunction, false);
    }
}

function GetAccountListSuccess(responseData) {
    BindDropDownList('ddlAccountId', responseData, 'Value', 'Name', '0', 'All');
    ddlAccountId.val(0);
}

function GetAccountList() {
    var accountCategoryId = 0, accountId = 0, locationId = 0;
    locationId = ddlLocationId.val() != '' ? ddlLocationId.val() : 0;
    accountCategoryId = ddlAccountCategoryId.val() != '' ? ddlAccountCategoryId.val() : 0;
    accountId = ddlAccountId.val() != '' ? ddlAccountId.val() : 0;

    if (hdnCodeId == null)
    {
        hdnCodeId = 0;
    }
    if (locationId == null) {
        locationId = 0;
    }
    if (accountCategoryId == null) {
        accountCategoryId = 0;
    }
    if (accountId == null) {
        accountId = 0;
    }

    var requestData = { isLocationWise: rdLocationWise.IsChecked, id: hdnCodeId.val(), accountCategoryId: accountCategoryId, accountId: accountId, locationId: locationId };
    
    AjaxRequestWithPostAndJson(baseUrl + '/GetAll', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedAccountList = [];

            dtAccountOpeningList = LoadDataTable('dtAccountOpeningList', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllAccount'), data: "AccountId" },
                  { title: 'Location', data: 'LocationCode' },
                  { title: 'Account Code', data: 'AccountCode' },
                  { title: 'Account Description', data: 'AccountDescription' },
                  { title: 'Credit Amount', data: 'CreditAmount', width: '150' },
                  { title: 'Debit Amount', data: 'DebitAmount', width: '150' }
              ]);

            dtAccountOpeningList.fnClearTable();
            $.each(result, function (i, item) {
                item.AccountId = SelectAll.GetChk('chkAllAccount', 'chkAccount' + i, 'Details[' + i + '].IsChecked') +
                    "<input type='hidden' value='" + item.AccountId + "' name='Details[" + i + "].AccountId' id='hdnAccountId" + i + "'/>" +
                    "<label class='label' for='chkAccount" + i + "' id='lblAccountId" + i + "'></label>" +
                    "<input type='hidden' value='" + item.LocationId + "' name='Details[" + i + "].LocationId' id='hdnLocationId" + i + "'/>";
                    item.CreditAmount = '<input class="form-control numeric2" name="Details[' + i + '].CreditAmount" id="txtCreditAmount' + i + '" type="text" value=\'' + item.CreditAmount + '\'/>'+
                            '<span data-valmsg-for="Details[' + i + '].CreditAmount" data-valmsg-replace="true"></span>';
                item.DebitAmount = '<input class="form-control numeric2" name="Details[' + i + '].DebitAmount" id="txtDebitAmount' + i + '" type="text" value=\'' + item.DebitAmount + '\'/>' +
                            '<span data-valmsg-for="Details[' + i + '].DebitAmount" data-valmsg-replace="true"></span>';
            });
            dtAccountOpeningList.dtAddData(result, [], InitAccountTable);
        }
    }, ErrorFunction, false);
    return false;
}

function InitAccountTable() {
    $('[id*="chkAccount"]').each(function () {
        var chkAccount = $(this);
        var txtCreditAmount = $('#' + chkAccount.Id.replace('chkAccount', 'txtCreditAmount'));
        var txtDebitAmount = $('#' + chkAccount.Id.replace('chkAccount', 'txtDebitAmount'));

        chkAccount.change(function () { SelectAccount(chkAccount, txtCreditAmount, txtDebitAmount) }).change();
        txtCreditAmount.blur(function () {
            if (txtCreditAmount.val() > 0)
                txtDebitAmount.val(0);
        });
        txtDebitAmount.blur(function () {
            if (txtDebitAmount.val() > 0)
                txtCreditAmount.val(0);
        });
    });
}

function SelectAccount(chkAccount, txtCreditAmount, txtDebitAmount) {
    txtCreditAmount.enable(chkAccount.IsChecked);
    txtDebitAmount.enable(chkAccount.IsChecked);
}

function OnAmountChange(objCreditAmount, objDebitAmount) {
    if (objCreditAmount.val() > 0)
        objDebitAmount.val(0);
    if (objDebitAmount.val() > 0)
        objCreditAmount.val(0);
}

function StepValid() {
    selectedAccountList = [];
    $('[id*="chkAccount"]').each(function () {
        var chkAccount = $(this);
        if (chkAccount.IsChecked) {
            selectedAccountList.push($('#' + chkAccount.Id.replace('chkAccount', 'hdnAccountId')).val());
        }
    });

    if (selectedAccountList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Account');
        return false;
    }
}