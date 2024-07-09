var accountGroupUrl, accountUrl, savedAccountLocation;

$(document).ready(function () {
    ddlPartyType = $('#ddlPartyType'), hdnPartyId = $('#hdnPartyId'), txtParyCode = $('#txtParyCode'), lblName = $('#lblName');
    $('#divvendorandparty').showHide();
    OnVendorTypeChange();
   
    $('#dvMappedAccount').showHide($('#ddlAccountCategory').val() == '7');
    AddItemDropDownList($('#ddlPartyType'), 0, "0", "ALL");
    
    AttachEvents();
});

function AttachEvents() {
    InitMultiSelect(ddlAccountLocation.Id, true, false, true);
    $('#ddlCategory').change(OnCategoryChange); $('#ddlAccountCategory').change(OnAccountCategoryChange); //OnAccountCategoryChange();
    ddlPartyType.change(OnVendorTypeChange);
   
    $('#ddlPartyType option:not(:selected)').prop("disabled", true);
    var savedAccountLocation = [];
    var selectedValue = $('#hdnSavedAccountLocation').val();
    $('#hdnAccountLocation').val(selectedValue);
    if (selectedValue != "") {
        selectedValue = selectedValue.split(',');
        $("#ddlAccountLocation").val(selectedValue).trigger('change');
        savedAccountLocation = selectedValue;
    }
    DropDownChange('ddlAccountLocation', function () {
        $('#hdnAccountLocation').val($(this).val());
    });
    $("#ddlAccountCategory").change(AccountCategoryChange);
    AccountCategoryChange();
}

function OnVendorTypeChange() {
    lblName.text('');
    
    $('#divvendorandparty').showHide(ddlPartyType.val() == 4);
    if (ddlPartyType.val() == 4) {
        VendorAutoComplete('txtParyCode', 'hdnPartyId', null, ddlPartyType.val())
         AddRequired(txtParyCode, 'Please enter BA Name');
        CheckIsValid(txtParyCode, hdnPartyId, lblName)
        txtParyCode.blur(function () { return CheckIsValid(txtParyCode, hdnPartyId, lblName); });
    }
    
}

function OnCategoryChange() {
    if ($('#ddlCategory').val() != "") {
        var requestData = { accountCategoryId: $('#ddlCategory').val() };
        AjaxRequestWithPostAndJson(accountGroupUrl +'/GetAccountGroupListByCategoryId', JSON.stringify(requestData), GetGroupCodeListSuccess, ErrorFunction, false);
    }
}


function CheckIsValid() {
    
    if (ddlPartyType.val() == 4) {
        IsVendorCodeExist(txtParyCode, hdnPartyId, lblName);
        if (hdnPartyId.val() == 1) {
            ShowMessage('Vendor is not exist');
            txtParyCode.val('');
            hdnPartyId.val('');
            txtParyCode.focus();
        }

    }

}

function OnAccountCategoryChange() {
    if ($('#ddlAccountCategory').val() == '7')
        AddRequired($('#ddlMappedAccountId'), "Please select Mapped Account");
    else
        RemoveRequired($('#ddlMappedAccountId'));

    if ($('#ddlAccountCategory').val() != "") {
        var requestData = { categoryId: $('#ddlAccountCategory').val() };
        AjaxRequestWithPostAndJson(accountUrl +'/GetAccountListByAccountCategoryId', JSON.stringify(requestData), GetMappedAccountListSuccess, ErrorFunction, false);
    }
    $('#dvMappedAccount').showHide($('#ddlAccountCategory').val() == '7');

}

function GetMappedAccountListSuccess(responseData) {
    BindDropDownList('ddlMappedAccountId', responseData, 'Value', 'Name', '', 'Select Mapped Account');
}

function GetGroupCodeListSuccess(responseData) {
    BindDropDownList('ddlAccountGroup', responseData, 'Value', 'Name', 0, 'Select GroupCode');
}
function AccountCategoryChange() {
    $("#divNEFTCode").showHide($("#ddlAccountCategory").val() == 6)
    if ($("#ddlAccountCategory").val() == 6) {
        AddRequired($('#txtNEFTCode'), 'Please Enter NEFT Code');

    } else {
        RemoveRequired($('#txtNEFTCode'));
        $("#txtNEFTCode").val('');

    }
}