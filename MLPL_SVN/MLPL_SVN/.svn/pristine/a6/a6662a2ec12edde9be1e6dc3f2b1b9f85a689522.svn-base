var accountGroupUrl, accountUrl;

$(document).ready(function () {
    $('#divvendorandparty').showHide();
    $('#ddlCategory').change(OnCategoryChange); $('#ddlAccountCategory').change(OnAccountCategoryChange);
    AddItemDropDownList($('#ddlPartyType'), 0, "0", "ALL");
    ddlPartyType = $('#ddlPartyType'), hdnPartyId = $('#hdnPartyId'), txtParyCode = $('#txtParyCode'), lblName = $('#lblName');
    AttachEvents();
   
});

function AttachEvents() {

    ddlPartyType.change(OnVendorTypeChange);
    ddlAccountLocation = $('#ddlAccountLocation');
    InitMultiSelect(ddlAccountLocation.Id, true, false, true);
    DropDownChange('ddlAccountLocation', function () {
        $('#hdnAccountLocation').val($(this).val());
    });
}

function OnVendorTypeChange() {

    txtParyCode.val('');
    hdnPartyId.val('');
    lblName.text('');
    $('#divvendorandparty').showHide(ddlPartyType.val() == 4);
    if (ddlPartyType.val() == 4) {
       
        VendorAutoComplete('txtParyCode', 'hdnPartyId', null, ddlPartyType.val());
        AddRequired(txtParyCode, 'Please enter BA Name');
        txtParyCode.blur(function () { return CheckIsValid(txtParyCode, hdnPartyId, lblName); });
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

function OnCategoryChange() {
    if ($('#ddlCategory').val() != "") {
        var requestData = { accountCategoryId: $('#ddlCategory').val() };
        AjaxRequestWithPostAndJson(accountGroupUrl + '/GetAccountGroupListByCategoryId', JSON.stringify(requestData), GetGroupCodeListSuccess, ErrorFunction, false);
    }
}

function OnAccountCategoryChange() {
   
    if ($('#ddlAccountCategory').val() == '7')
        {
        AddRequired($('#ddlMappedAccountId'), "Please select Mapped Account");
        
         }
    else
      { 
        RemoveRequired($('#ddlMappedAccountId'));
        
        }
    if ($('#ddlAccountCategory').val() != "") {
        var requestData = { categoryId: $('#ddlAccountCategory').val() };
        AjaxRequestWithPostAndJson(accountUrl + '/GetAccountListByAccountCategoryId', JSON.stringify(requestData), GetMappedAccountListSuccess, ErrorFunction, false);
    }
    //$('#dvMappedAccount').showHide($('#ddlAccountCategory').val() == '7');
    $("#divNEFTCode").showHide($("#ddlAccountCategory").val() == 6)
    if ($("#ddlAccountCategory").val() == 6) {
        AddRequired($('#txtNEFTCode'), 'Please Enter NEFT Code');

    } else {
        RemoveRequired($('#txtNEFTCode'));
        $("#txtNEFTCode").val('');

    }
}

function GetMappedAccountListSuccess(responseData) {
    BindDropDownList('ddlMappedAccountId', responseData, 'Value', 'Name', '', 'Select Mapped Account');
}

function GetGroupCodeListSuccess(responseData) {
    BindDropDownList('ddlAccountGroup', responseData, 'Value', 'Name', 0, 'Select GroupCode');
}
