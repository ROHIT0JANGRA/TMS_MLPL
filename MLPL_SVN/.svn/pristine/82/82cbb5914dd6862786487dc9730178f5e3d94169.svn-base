var hdnMappingId, txtConsignorCode, lblConsignor, hdnConsignorId, hdnConsignorId, txtConsigneeCode, lblConsignee, hdnBillingPartyId, txtBillingPartyCode, lblBillingParty, hdnConsignorName, hdnConsigneeName, hdnBillingPartyName, baseUrl;

function InitObjects() {
    hdnMappingId = $('#hdnMappingId');
    hdnConsignorId = $('#hdnConsignorId');
    txtConsignorCode = $('#txtConsignorCode');
    lblConsignor = $('#lblConsignor');
    hdnConsigneeId = $('#hdnConsigneeId');
    txtConsigneeCode = $('#txtConsigneeCode');
    lblConsignee = $('#lblConsignee');
    hdnBillingPartyId = $('#hdnBillingPartyId');
    txtBillingPartyCode = $('#txtBillingPartyCode');
    lblBillingParty = $('#lblBillingParty');
    hdnConsignorName = $('#hdnConsignorName');
    hdnConsigneeName = $('#hdnConsigneeName');
    hdnBillingPartyName = $('#hdnBillingPartyName');
    btnSubmit = $('#btnSubmit');
}

function AttachEvents() {
    AutoComplete('txtConsignorCode', customerMasterUrl + '/GetAutoCompleteCustomerList', 'customerCode', 'l', 'l', 'l', 'd', '', 'hdnConsignorId', '', '');
    txtConsignorCode.blur(function () {  IsCustomerCodeExist(txtConsignorCode, hdnConsignorId, lblConsignor); IsMappingAvailable(txtConsignorCode, hdnConsignorId); });
   // txtConsignorCode.blur(function () { return  });

    AutoComplete('txtConsigneeCode', customerMasterUrl + '/GetAutoCompleteCustomerList', 'customerCode', 'l', 'l', 'l', 'd', '', 'hdnConsigneeId', '', '');
    txtConsigneeCode.blur(function () {  IsCustomerCodeExist(txtConsigneeCode, hdnConsigneeId, lblConsignee); IsMappingAvailable(txtConsigneeCode, hdnConsigneeId); });
   // txtConsigneeCode.blur(function () { return  });

    AutoComplete('txtBillingPartyCode', customerMasterUrl + '/GetAutoCompleteCustomerList', 'customerCode', 'l', 'l', 'l', 'd', '', 'hdnBillingPartyId', '', '');
    txtBillingPartyCode.blur(function () {  IsCustomerCodeExist(txtBillingPartyCode, hdnBillingPartyId, lblBillingParty); IsMappingAvailable(txtBillingPartyCode, hdnBillingPartyId); });
    //txtBillingPartyCode.blur(function () { return  });

}

function IsMappingAvailable(objName, objHdnId) {
    if (txtConsignorCode.val() != "" && txtConsigneeCode.val() != "" && txtBillingPartyCode.val() != "") {
        var requestData = { mappingId: hdnMappingId.val(), consignorId: hdnConsignorId.val(), consigneeId: hdnConsigneeId.val(), billingPartyId: hdnBillingPartyId.val() };
        AjaxRequestWithPostAndJson(baseUrl + '/IsMappingAvailable', JSON.stringify(requestData), function (result) {
            if (result) {
                ShowMessage('Mapping is already exist');
                objName.val('');
                objHdnId.val('');
                return false;
            }
        }, ErrorFunction, false);
    }
}