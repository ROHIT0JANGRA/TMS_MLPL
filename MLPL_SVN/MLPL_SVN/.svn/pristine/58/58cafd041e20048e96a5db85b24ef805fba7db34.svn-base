var txtCustomerCode, hdnCustomerId, lblCustomerName, ddlPaybas, dtAccountDetailList, ddlCostCenterTypeId, txtNetPayableAmount, NetPayableAmount, subTotalAmount = 0,
    totalServiceTaxAmount = 0, totalTdsAmount = 0, dtTax, txtDocumentNo, hdnDocumentId, hdnTotalTax, chkRoundOffServiceTax, txtServiceTaxApplicableAmount, txtNarration,
    txtDocumentDetail, docketNomenclature, txtBillAmount, ddlDocumentTypeHeaderId;

$(document).ready(function () {
    SetPageLoad('Supplementry', 'Bill Entry', 'txtCustomerCode', '', '');
    InitObjects();
    AttachEvents();
    InitGrid('dtAccountDetailList', false, 7, InitAccountDetailTable, false);
});

function InitObjects() {
    txtCustomerCode = $('#txtCustomerCode');
    lblCustomerName = $('#lblCustomerName');
    lblCustomerResultName = $('#lblCustomerResultName');
    hdnCustomerId = $('#hdnCustomerId');
    ddlPaybas = $('#ddlPaybas');
    lblSubmissionLocation = $('#lblSubmissionLocation');
    lblCollectionLocation = $('#lblCollectionLocation');
    hdnDocumentId = $('#hdnDocumentId');
    txtDocumentNo = $('#txtDocumentNo');
    chkMultipleCNoteNo = $('#chkMultipleCNoteNo');
    txtServiceTaxApplicableAmount = $('#txtServiceTaxApplicableAmount');
    chkRoundOffServiceTax = $('#chkRoundOffServiceTax');
    chkEnableServiceTax = $('#chkEnableServiceTax');
    hdnTotalTax = $('#hdnTotalTax');
    hdnServiceTaxApplicableAmount = $('#hdnServiceTaxApplicableAmount');
    ddlDocumentTypeHeaderId = $('#ddlDocumentTypeHeaderId');
    txtNarrationHeader = $('#txtNarrationHeader');
    txtBillAmount = $('#txtBillAmount');

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: BillDetail },
     { StepName: 'Bill Details' },
     { StepName: 'Account Details', StepFunction: AccountDetail },
     { StepName: 'Payment Details' }
    ], 'Generate');
}

function AttachEvents() {
    txtCustomerCode.blur(function () { return CheckValidCustomerCode(txtCustomerCode, hdnCustomerId, false); });
    ddlPaybas.change(OnPaybasChange);
    OnPaybasChange();
    $('#rdThc,#rdDocket').change(OnDocumentTypeChange);

    ddlDocumentTypeHeaderId.change(function () {
        $('[id*="txtDetailDocumentCode"]').each(function () {
            var txtDetailDocumentCode = $(this);
            var hdnDetailDocumentId = $('#' + this.id.replace('txtDetailDocumentCode', 'hdnDetailDocumentId'));
            var ddlDocumentTypeDetailId = $('#' + this.id.replace('txtDetailDocumentCode', 'ddlDocumentTypeDetailId'));
            if (ddlDocumentTypeDetailId.val() != ddlDocumentTypeHeaderId.val()) {
                ddlDocumentTypeDetailId.val(ddlDocumentTypeHeaderId.val());
                txtDetailDocumentCode.val('');
                hdnDetailDocumentId.val('');
            }
        });
    });

    txtNarrationHeader.blur(function () {
        $('[id*="txtNarration"]').val(txtNarrationHeader.val());
    });

    chkMultipleCNoteNo.change(DisplayDocument);

    $('#ddlDocumentTypeHeaderId option').eq(0).before($('<option>', { value: 0, text: 'Select Document Type' }));
    ddlDocumentTypeHeaderId.val(0);

    $('#ddlDocumentTypeDetailId0 option').eq(0).before($('<option>', { value: 0, text: 'Select Document Type' }));
    $('[id*="ddlDocumentTypeDetailId"]').val(0);

    txtDocumentNo.blur(function () {
        return CheckValidDocument(txtDocumentNo, hdnDocumentId);
    });

    GetTaxDetails();

    chkEnableServiceTax.change(function () {
        GetTaxDetails();
    });

    chkRoundOffServiceTax.change(function () {
        GetTaxDetails();
    });
}

function OnDocumentTypeChange() {
    txtDocumentNo.val('');
    hdnDocumentId.val('');
}

function OnPaybasChange() {
    txtCustomerCode.val('');
    hdnCustomerId.val('');
    lblCustomerName.text('');
    txtCustomerCode.enable(ddlPaybas.val() != '');
    if (ddlPaybas.val() == 5)
        CustomerAutoComplete('txtCustomerCode', 'hdnCustomerId');
    else
        customerScript.CustomerAutoComplete('txtCustomerCode', 'lblCustomerName', 'hdnCustomerId', 'CustomerId', false);
}

function BillDetail() {
    lblCustomerResultName.text(txtCustomerCode.val() + ':' + lblCustomerName.text());
    lblSubmissionLocation.text(loginLocationCode);
    lblCollectionLocation.text(loginLocationCode);
}

function AccountDetail() {
    $('[id*="txtDetailDocumentCode"]').each(function () {
        var txtDetailDocumentCode = $(this);
        var hdnDetailDocumentId = $('#' + this.id.replace('txtDetailDocumentCode', 'hdnDetailDocumentId'));
        var ddlDocumentTypeDetailId = $('#' + this.id.replace('txtDetailDocumentCode', 'ddlDocumentTypeDetailId'));
        if (ddlDocumentTypeDetailId.val() == 0) {
            txtDetailDocumentCode.val('');
            hdnDetailDocumentId.val(0);
        }
        if (chkMultipleCNoteNo.IsChecked && ddlDocumentTypeDetailId.val() == 0) {
            isStepValid = false;
            ShowMessage("Please select Document Type");
            SetFormFieldFocus(ddlDocumentTypeDetailId.Id);
            return false;
        }

        if (chkMultipleCNoteNo.IsChecked && txtDetailDocumentCode.val() == '') {
            isStepValid = false;
            ShowMessage("Please enter Document Code");
            txtDetailDocumentCode.focus();
            return false;
        }

    });
}

function DisplayDocument() {
    $('#thDocumentTypeIdHeader').showHide(chkMultipleCNoteNo.IsChecked);
    $('#thDocumentIdHeader').showHide(chkMultipleCNoteNo.IsChecked);
    $('td:eq(3)').showHide(chkMultipleCNoteNo.IsChecked);
    $('td:eq(4)').showHide(chkMultipleCNoteNo.IsChecked);
}

function InitAccountDetailTable() {
    $('[id*="txtAccountCode"]').each(function () {
        var txtAccountCode = $(this);
        var hdnAccountId = $('#' + this.id.replace('txtAccountCode', 'hdnAccountId'));
        var lblAccountDescription = $('#' + this.id.replace('txtAccountCode', 'lblAccountDescription'));
        var ddlDocumentTypeDetailId = $('#' + this.id.replace('txtAccountCode', 'ddlDocumentTypeDetailId'));
        var hdnDetailDocumentId = $('#' + this.id.replace('txtAccountCode', 'hdnDetailDocumentId'));
        var txtDetailDocumentCode = $('#' + this.id.replace('txtAccountCode', 'txtDetailDocumentCode'));
        var txtAmount = $('#' + this.id.replace('txtAccountCode', 'txtAmount'));

        GetTotalBillAmount();
        txtAmount.blur(GetTotalBillAmount);
        DisplayDocument();
        if (chkMultipleCNoteNo.IsChecked == false) {
            RemoveRequired(ddlDocumentTypeDetailId);
            RemoveRequired(txtDetailDocumentCode);
        }
        else {
            AddRequired(ddlDocumentTypeDetailId, 'Please select Document Type');
            AddRequired(txtDetailDocumentCode, 'Please enter Document Code');
        }

        ddlDocumentTypeDetailId.change(OnDetailDocumentTypeChange);

        txtDetailDocumentCode.blur(function () {
            return CheckValidDetailDocument(ddlDocumentTypeDetailId, txtDetailDocumentCode, hdnDetailDocumentId);
        });

        function OnDetailDocumentTypeChange() {
            txtDetailDocumentCode.val('');
            hdnDetailDocumentId.val('');
        }

        txtAccountCode.blur(function () {
            return Account.IsAccountCodeExist(txtAccountCode, hdnAccountId,lblAccountDescription);
        });
        Account.AccountAutoComplete(txtAccountCode.Id, hdnAccountId.Id);

        txtAccountCode.blur(function () {
            try {
                CheckDetailAlreadyExist($(this));
            }
            catch (e) {
                $(this).val('');
                $(this).focus();
            }
        });

        txtDetailDocumentCode.blur(function () {
            try {
                CheckDetailAlreadyExist($(this));
            }
            catch (e) {
                $(this).val('');
                $(this).focus();
            }
        });

        ddlDocumentTypeDetailId.change(function () {
            try {
                CheckDetailAlreadyExist($(this));
            }
            catch (e) {
                $(this).val('');
                $(this).val('');
                SetFormFieldFocus($(this).attr('id'));
            }
        });
    });
}

function GetTotalBillAmount() {
    var totalBillAmount = 0, totalCreditAmount = 0;
    $('[id*="txtAmount"]').each(function () {
        var txtAmount = $(this);
        if (txtAmount.val() != '')
            totalBillAmount = totalBillAmount + parseFloat(txtAmount.val());
    });
    txtBillAmount.val(totalBillAmount);
    txtServiceTaxApplicableAmount.val(totalBillAmount);
}

function CheckValidDetailDocument(objDocumentTypeDetailId, objDetailDocumentCode, objDetailDocumentId) {
    if (objDocumentTypeDetailId.val() == 1) {
        CheckValidDocketNo(objDetailDocumentCode, objDetailDocumentId);
    }
    else if (objDocumentTypeDetailId.val() == 5) {
        CheckValidThcCode(objDetailDocumentCode, objDetailDocumentId);
    }
    else {
        objDetailDocumentCode.val('');
        objDetailDocumentId.val('');
    }
}

var Account = {
    IsAccountCodeExist: function (txtAccountCode, hdnAccountId, lblAccountDescription) {
        if (txtAccountCode.val() != '') {
            var requestData = { accountCode: txtAccountCode.val().split(':')[0].trim() };
            AjaxRequestWithPostAndJson(accountMasterUrl + '/IsAccountCodeExist', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Account is not exist');
                    txtAccountCode.focus();
                    txtAccountCode.val('');
                    hdnAccountId.val('');
                    lblAccountDescription.text('');
                }
                else {
                    hdnAccountId.val(result.Value);
                    txtAccountCode.val(result.Name);
                    lblAccountDescription.text(result.Description);
                }
            }, ErrorFunction, false);
        }
        else {
            hdnAccountId.val('');
            lblAccountDescription.text('');
        }
        return false;
    },
    AccountAutoComplete: function (txtAccountCodeId, hdnAccountId) {
        AutoComplete(txtAccountCodeId, accountMasterUrl + '/GetAccountAutoCompleteList', 'accountCode', 'l', 'l', 'l', 'd', '', hdnAccountId, '', '', '');
    }
}

var customerScript = {
    CustomerAutoComplete: function (txtCodeId, lbltxtNameId, hdnId, entity, allowWalkin) {
        AutoComplete(txtCodeId, customerMasterUrl + '/GetAutoCompleteCustomerListByLocationPaybas', 'customerName', 'l', 'l', 'l', 'd', '', hdnId, lbltxtNameId, '', true, function () {
            if (entity == 'CustomerId')
                return [{ Key: 'locationId', Value: loginLocationId }, { Key: 'PaybasId', Value: ddlPaybas.val() }, { Key: 'allowWalkin', Value: allowWalkin }];
        });
    }
}

function CheckValidCustomerCode(txtCustomerCode, hdnCustomerId, allowWalkin) {
    if (txtCustomerCode.val() != "") {
        if (ddlPaybas.val() == 5)
            IsCustomerCodeExist(txtCustomerCode, hdnCustomerId, lblCustomerName);
        else {
            var requestData = { customerCode: txtCustomerCode.val() };
            var requestData = { locationId: loginLocationId, paybasId: ddlPaybas.val(), customerCode: txtCustomerCode.val(), allowWalkIn: allowWalkin };
            AjaxRequestWithPostAndJson(customerMasterUrl + '/IsCustomerExistByLocationPaybas', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result.CustomerId) || result.CustomerId == 0) {
                    ShowMessage('Customer is not exist');
                    txtCustomerCode.val('');
                    hdnCustomerId.val('');
                    lblCustomerName.text('');
                    txtCustomerCode.focus();
                }
                else {
                    hdnCustomerId.val(result.CustomerId);
                    txtCustomerCode.val(result.CustomerCode);
                    lblCustomerName.text(result.CustomerName);
                }
            }, ErrorFunction, false);
        }
    }
}

function CheckValidDocument(txtDocumentNo, hdnDocumentId) {
    if (rdDocket.checked == true) {
        CheckValidDocketNo(txtDocumentNo, hdnDocumentId);
    }
    else if (rdThc.checked == true) {
        CheckValidThcCode(txtDocumentNo, hdnDocumentId);
    }
}

function CheckValidDocketNo(txtDocketNo, hdnDocketId) {
    if (txtDocketNo.val() != "") {
        var requestData = { docketNo: txtDocketNo.val() };
        AjaxRequestWithPostAndJson(docketUrl + '/CheckValidDocketNo', JSON.stringify(requestData), function (result) {
            if (IsObjectNullOrEmpty(result)) {
                ShowMessage(docketNomenclature + ' No is not exist');
                txtDocketNo.val('');
                hdnDocketId.val('');
                txtDocketNo.focus();
            }
            else {
                hdnDocketId.val(result.Value);
                txtDocketNo.val(result.Name);
            }
        }, ErrorFunction, false);
    }
}

function CheckValidThcCode(txtThcNo, hdnThcId) {
    if (txtThcNo.val() != "") {
        var requestData = { thcNo: txtThcNo.val() };
        AjaxRequestWithPostAndJson(thcUrl + '/CheckValidThcCode', JSON.stringify(requestData), function (result) {
            if (IsObjectNullOrEmpty(result)) {
                ShowMessage('THC No is not exist');
                txtThcNo.val('');
                hdnThcId.val('');
                txtThcNo.focus();
            }
            else {
                hdnThcId.val(result.Value);
                txtThcNo.val(result.Name);
            }
        }, ErrorFunction, false);
    }
}

function GetTaxDetails() {
    isSuccessfull = true;
    AjaxRequestWithPostAndJson(accountMasterUrl + '/GetTaxDetails', '', function (responseData) {
        taxList = responseData.sort(ComparerTax);
        if (dtTax == null)
            dtTax = LoadDataTable('dtTax', false, false, false, null, null, [],
              [
                  { title: 'Tax Code', data: 'TaxCode', hidden: true },
                  { title: 'Tax Name', data: 'TaxDetail' },
                  { title: 'Tax Percentage', data: 'TaxPercentage' },
                  { title: 'Tax Amount', data: 'TaxAmount' }
              ]);
        else {
            $('#dtTax').addClass('dataTable');
            dtTax.fnClearTable();
        }

        var totalTax = 0.00, serviceTax = 0.00;
        if (chkEnableServiceTax.IsChecked) {
            if (taxList.length > 0) {
                var serviceTaxApplicableAmount = parseFloat(txtServiceTaxApplicableAmount.val());
                $.each(taxList, function (i, item) {
                    var taxPercentage = item.TaxPercentage * (100 - item.RebatePercentage) / 100;
                    item.TaxAmount = (item.BaseOn == 1 ? serviceTaxApplicableAmount : serviceTax) * item.TaxPercentage / 100;
                    item.TaxAmount = item.TaxAmount.toFixed(2);
                    if (item.TaxCode == 1)
                        serviceTax = item.TaxAmount;
                    if (chkRoundOffServiceTax.IsChecked)
                        totalTax += parseFloat(parseFloat(item.TaxAmount).toFixed(0));
                    else
                        totalTax += parseFloat(parseFloat(item.TaxAmount).toFixed(2));

                });
                hdnTotalTax.val(totalTax);
            }
        }
        else
            hdnTotalTax.val(0);


        if (taxList.length > 0) {
            $.each(taxList, function (i, item) {
                item.TaxDetail = '<input type="hidden" name="TaxList[' + i + '].TaxCode" id="hdnTaxCode' + i + '" value="' + item.TaxCode + '"/>' +
                     '<input type="hidden" name="TaxList[' + i + '].TaxAmount" id="hdnTaxAmount' + i + '" value="' + parseFloat(item.TaxAmount).toFixed(2) + '"/>' +
                     '<input type="hidden" name="TaxList[' + i + '].BaseOn" id="hdnBaseOn' + i + '" value="' + item.BaseOn + '"/>' +
                     '<label class="label" d="lblTaxName' + i + '">' + item.TaxName + '</label>';
                if (chkEnableServiceTax.IsChecked) item.TaxPercentage = '<input type="text" class="form-control textlabel numeric2" name=\'TaxList[' + i + '].TaxPercentage\' style=\'width:100%\' id=\'txtTaxPercentage' + i + '\' value=' + parseFloat(item.TaxPercentage).toFixed(2) + ' />';
                else item.TaxPercentage = '<input type="text" class="form-control textlabel numeric2" name=\'TaxList[' + i + '].TaxPercentage\'  id=\'txtTaxPercentage' + i + '\' value=\'0.00\' />';
                if (chkRoundOffServiceTax.IsChecked) item.TaxAmount = '<input type="text" class="form-control numeric2" name="TaxList[' + i + '].TaxAmount" id="txtTaxAmount' + i + '" value="' + parseFixed(parseFixed(item.TaxAmount, 0), 2) + '"/>';
                else item.TaxAmount = '<input type="text" class="form-control textlabel numeric2" name="TaxList[' + i + '].TaxAmount" id="txtTaxAmount' + i + '" value="' + parseFixed(item.TaxAmount, 2) + '"/>';
            });
            dtTax.dtAddData(taxList);
            $('#dtTax').DataTable().column(0).visible(false);
        }
    });
}

function CheckDetailAlreadyExist(obj) {
    if (obj.val() != '' && obj.val() != 0 && !obj.is('[readonly]')) {
        var outertr = obj.closest('tr');
        var outertxtAccountCode = outertr.find('[id*="txtAccountCode"]');
        var outertxtDetailDocumentCode = outertr.find('[id*="txtDetailDocumentCode"]');
        var outerddlDocumentTypeDetailId = outertr.find('[id*="ddlDocumentTypeDetailId"]');

        $('#dtAccountDetailList tr:not(:first)').each(function () {
            var innertr = $(this);
            var innertxtAccountCode = innertr.find('[id*="txtAccountCode"]');
            var innertxtDetailDocumentCode = innertr.find('[id*="txtDetailDocumentCode"]');
            var innerddlDocumentTypeDetailId = innertr.find('[id*="ddlDocumentTypeDetailId"]');

            if (chkMultipleCNoteNo.IsChecked) {
                if (innertxtAccountCode.attr('id') != outertxtAccountCode.attr('id') && innertxtAccountCode.val() == outertxtAccountCode.val() && innertxtDetailDocumentCode.val() == outertxtDetailDocumentCode.val() &&
                        innerddlDocumentTypeDetailId.val() == outerddlDocumentTypeDetailId.val()) {
                    ShowMessage("Account Detail is already exist");
                    throw (true);
                }
            }
            else {
                if (innertxtAccountCode.attr('id') != outertxtAccountCode.attr('id') && innertxtAccountCode.val() == outertxtAccountCode.val()) {
                    ShowMessage("Account Detail is already exist");
                    throw (true);
                }
            }
        });
    }
}