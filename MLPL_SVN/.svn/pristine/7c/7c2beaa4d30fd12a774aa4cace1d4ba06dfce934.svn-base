var ddlMaterialCategoryId, hdnVendorId, txtVendorCode, txtAdvanceAmount;
var vendorMasterUrl, skuMasterUrl;

$(document).ready(function () {
    InitObjects();
    AttachEvents();
    SetPageLoad('Purchase Order', 'Insert', 'txtManualPoNo', '', '');
});

function InitObjects() {
    ddlMaterialCategoryId = $('#ddlMaterialCategoryId');
    hdnVendorId = $('#hdnVendorId');
    txtVendorCode = $('#txtVendorCode');
    txtAdvanceAmount = $('#txtAdvanceAmount');
    lblName = $('#lblName');

    InitGrid('dtDetail', false, 7, InitAutoComplete);

    InitWizard('dvWizard', [
     { StepName: 'Prepare Job Order' },
     { StepName: 'Details' }
    ], 'Generate');
}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { return IsVendorCodeExist(txtVendorCode, hdnVendorId, lblName); });
    txtAdvanceAmount.blur(CalculateBalanceAmount);
}

function InitAutoComplete() {
    $('[id*="hdnSkuId"]').each(function () {
        var hdnSkuId = $(this);
        var txtSkuName = $('#' + this.id.replace('hdnSkuId', 'txtSkuName'));
        var txtQuantity = $('#' + this.id.replace('hdnSkuId', 'txtQuantity'));
        var txtRate = $('#' + this.id.replace('hdnSkuId', 'txtRate'));
        var txtDiscountPercentage = $('#' + this.id.replace('hdnSkuId', 'txtDiscountPercentage'));
        var txtTaxPercentage = $('#' + this.id.replace('hdnSkuId', 'txtTaxPercentage'));

        AutoComplete(txtSkuName.Id, skuMasterUrl + '/GetAutoCompleteListByMaterialCategoryId', 'skuName', 'l', 'l', 'l', 'd', '', hdnSkuId.Id, '', '', '', function () {
            return [{ Key: 'materialCategoryId', Value: ddlMaterialCategoryId.val() }];
        });

        txtSkuName.blur(function () { return IsSkuNameExist(txtSkuName, hdnSkuId); });
        CalculateTotalAmount();
        txtQuantity.blur(CalculateTotalAmount);
        txtRate.blur(CalculateTotalAmount);
        txtDiscountPercentage.blur(CalculateTotalAmount);
        txtTaxPercentage.blur(CalculateTotalAmount);

        txtSkuName.change(function () {
            try {
                IsDetailExist($(this));
            }
            catch (e) {
                $(this).val('');
                $(this).focus();
            }
        });
    });
}

function IsSkuNameExist(txtSkuName, hdnSkuId) {
    if (txtSkuName.val() != "") {
        var requestData = { skuName: txtSkuName.val(), materialCategoryId: ddlMaterialCategoryId.val() };
        AjaxRequestWithPostAndJson(skuMasterUrl + '/IsSkuNameExistForPurchaseOrder', JSON.stringify(requestData), function (result) {
            if (IsObjectNullOrEmpty(result)) {
                ShowMessage("Item is not exist");
                txtSkuName.val('');
                hdnSkuId.val(0);
                txtSkuName.focus();
            }
            else {
                txtSkuName.val(result.Name);
                hdnSkuId.val(result.Value);
            }
        }, ErrorFunction, false);
    }
}

function CalculateTotalAmount() {
    var totalAmount = 0;
    $('[id*="txtTotalAmount"]').each(function () {
        var txtTotalAmount = $(this);
        var txtQuantity = $('#' + this.id.replace('txtTotalAmount', 'txtQuantity'));
        var hdnPendingQuantity = $('#' + this.id.replace('txtTotalAmount', 'hdnPendingQuantity'));
        var txtRate = $('#' + this.id.replace('txtTotalAmount', 'txtRate'));
        var txtDiscountPercentage = $('#' + this.id.replace('txtTotalAmount', 'txtDiscountPercentage'));
        var txtTaxPercentage = $('#' + this.id.replace('txtTotalAmount', 'txtTaxPercentage'));
        var txtTotalAmount = $('#' + this.id.replace('txtTotalAmount', 'txtTotalAmount'));
        hdnPendingQuantity.val(txtQuantity.val());
        var amount = 0, discount = 0, tax = 0;
        if (txtQuantity.val() != '' && txtRate.val() != '')
            amount = parseFloat(txtQuantity.val()) * parseFloat(txtRate.val());
        if (txtDiscountPercentage.val() != '')
            discount = (amount * parseFloat(txtDiscountPercentage.val())) / 100;
        amount = amount - discount;
        if (txtTaxPercentage.val() != '')
            tax = (amount * parseFloat(txtTaxPercentage.val())) / 100;
        txtTotalAmount.val(amount + tax);
        totalAmount = totalAmount + parseFloat(txtTotalAmount.val());
    });
    $('#txtAmount').val(totalAmount);
    AddRange(txtAdvanceAmount, 'Advance Amount must be less than ' + totalAmount, 0, totalAmount);
    $('#txtBalanceAmount').val(totalAmount);
}

function IsDetailExist(obj) {
    if (obj.val() != '') {
        var outertr = obj.closest('tr');
        var outerhdnSkuId = outertr.find('[id*="hdnSkuId"]');

        $('#dtDetail tr:not(:first)').each(function () {
            var innertr = $(this);
            var innerhdnSkuId = innertr.find('[id*="hdnSkuId"]');

            if (innerhdnSkuId.attr('id') != outerhdnSkuId.attr('id') && innerhdnSkuId.val() == outerhdnSkuId.val()) {
                ShowMessage("Item is already exist");
                throw (true);
            }
        });
    }
}

function CalculateBalanceAmount() {
    $('#txtBalanceAmount').val(parseFloat($('#txtAmount').val()) - parseFloat(txtAdvanceAmount.val()));
}

