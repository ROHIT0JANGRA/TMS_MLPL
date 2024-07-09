var txtVendorCode, hdnVendorId, txtVendorName, ddlGstTypeId, dtAccountDetailList, ddlCostCenterTypeId, txtNetPayableAmount, NetPayableAmount, subTotalAmount = 0, totalServiceTaxAmount = 0, totalTdsAmount = 0, docketNomenclature;
var txtBillDateTime, txtBillDueDate, vendorContractMasterUrl, hsnMasterUrl, TdsMasterUrl;
var chkIsCostCenterApplicable, isRegistered = false;
var hdnServiceTaxApplicableAmount, txtGstApplicableAmount, chkTdsWithoutGst, chkRoundOffTds, txtTdsAmount, txtTdsRate, hdnTdsApplicableAmount, hdnTotalTax, txtTdsApplicableAmount, txtSubTotal, txtGrandTotal;
var isState, interState;
var gstDetails = { IsGst: true, IsRcm: false, GstRate: 18.00, IsInterState: 'false', IsState: true, CustomerCode: '', CustomerName: '', WalkingGstTinNo: '', DeclarationDocumentName: '', StateList: [] };
var hdnPaymentLocationId, txtPaymentLocation;
var loginLocationId, loginLocationCode;
$(document).ready(function () {
    SetPageLoad('Other', 'Bill Entry', 'txtVendorCode', '', '');
    InitObjects();
    AttachEvents();
    InitGrid('dtAccountDetailList', false, 16, InitAccountDetailTable, false);
});

function InitObjects() {
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetStep2Detail },
        { StepName: 'Bill Detail' },
        { StepName: 'Account Detail', StepFunction: GetStep4Detail },
        { StepName: 'Tax Details' }
    ], 'Generate');

    txtVendorCode = $('#txtVendorCode');
    txtVendorName = $('#txtVendorName');
    lblVendor = $('#lblVendor');
    hdnVendorId = $('#hdnVendorId');

    txtDocumentNo = $('#txtDocumentNo');
    ddlGstTypeId = $('#ddlGstTypeId');
    ddlVendorGstStateId = $('#ddlVendorGstStateId');
    ddlCompanyGstStateId = $('#ddlCompanyGstStateId');
    lblVendorNameStep2 = $('#lblVendorNameStep2');

    txtNetPayableAmount = $('#txtNetPayableAmount');
    txtOtherDeduction = $('#txtOtherDeduction');
    txtDiscountReceived = $('#txtDiscountReceived');
    txtTotalAmount = $('#txtTotalAmount');
    hdnTotalAccount = $('#hdnTotalAccount');
    chkIsCostCenterApplicable = $('#chkIsCostCenterApplicable');
    ddlCostCenterTypeId = $('#ddlCostCenterTypeId');
    txtCostCenter = $('#txtCostCenter');
    hdnCostCenterId = $('#hdnCostCenterId');

    chkIsGstExempted = $('#chkIsGstExempted');
    ddlGstExemptedCategoryId = $('#ddlGstExemptedCategoryId');
    ddlGstVendorLocationId = $('#ddlGstVendorLocationId');
    ddlGstCompanyLocationId = $('#ddlGstCompanyLocationId');
    ddlGstVendorCityId = $('#ddlGstVendorCityId');
    ddlGstCompanyCityId = $('#ddlGstCompanyCityId');
    txtBillDateTime = $('#txtBillDateTime');
    hdnServiceTaxApplicableAmount = $('#hdnServiceTaxApplicableAmount');
    txtGstApplicableAmount = $('#txtGstApplicableAmount');
    chkTdsWithoutGst = $('#chkTdsWithoutGst');
    chkRoundOffTds = $('#chkRoundOffTds');
    txtTdsAmount = $('#txtTdsAmount');
    txtTdsRate = $('#txtTdsRate');
    hdnTdsApplicableAmount = $('#hdnTdsApplicableAmount');
    hdnTotalTax = $('#hdnTotalTax');
    txtTdsApplicableAmount = $('#txtTdsApplicableAmount');
    txtSubTotal = $('#txtSubTotal');
    txtGrandTotal = $('#txtGrandTotal');
    txtBillDueDate = $('#txtBillDueDate');

    txtBillDateTime.blur(CalculateDueDate);
    txtBillDueDate.blur(CheckValidDueDate);

    ddlTdsSection = $('#ddlTdsSection')

    hdnPaymentLocationId = $('#hdnPaymentLocationId');
    txtPaymentLocation = $('#txtPaymentLocation');
}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { IsVendorCodeExist(txtVendorCode, hdnVendorId, txtVendorName); if (hdnVendorId.val() == 1) txtVendorName.val(''); SetVendorName(); });
    txtVendorCode.blur(function () { return EnableGstInfo(txtVendorCode, hdnVendorId); });
    //ddlGstTypeId.change(function () { return BindGstState(); });
    ddlGstTypeId.disable();
    ddlGstTypeId.append($("<option></option>").val(1).html('Inter-State'));
    ddlGstTypeId.append($("<option></option>").val(0).html('Intra-State'));
    OnCostCenterChange();

    txtDocumentNo.blur(function () {
        CheckDuplicateManualBillNo();
    });

    txtOtherDeduction.change(function () {
        CalculateNetAmount();
    });

    txtDiscountReceived.change(function () {
        CalculateNetAmount();
    });
    ddlVendorGstStateId.change(function () { return BindVendorGstCity(); });
    ddlCompanyGstStateId.change(function () { return BindCompanyGstCity(); });
    //ddlGstVendorLocationId.change(function () { return BindVendorGstCity(); });
    ddlGstVendorCityId.change(function () { return GetGstDetail('Vendor'); });
    //ddlGstCompanyLocationId.change(function () { return BindCompanyGstCity(); });
    ddlGstCompanyCityId.change(function () { return GetGstDetail('Company'); });
    chkIsCostCenterApplicable.change(OnCostCenterChange);
    $('#txtDiscountReceived').blur(CalculateAmount);
    $('#txtOtherDeduction').blur(CalculateAmount);
    $('#ddlCommanCostCenterTypeId').change(SetCommanCostCenterType);
    $('#txtCommanCostCenter').blur(function () { return CheckIsCostCenterValid($('#ddlCommanCostCenterTypeId'), $('#txtCommanCostCenter'), $('#hdnCommanCostCenterId'), $('#lblCommanCostCenter')); });
    $('#txtCommanCostCenter').blur(SetCommanCostCenter);
    txtTdsRate.blur(CalculateAmount);
    hdnPaymentLocationId.val(loginLocationId);
    txtPaymentLocation.val(loginLocationCode);

    LocationAutoComplete('txtPaymentLocation', 'hdnPaymentLocationId');
    txtPaymentLocation.blur(function () { return IsLocationCodeExist(txtPaymentLocation, hdnPaymentLocationId); });
}

function SetVendorName() {
    txtVendorName.readOnly(hdnVendorId.val() != 1);
    if (hdnVendorId.val() == 1)
        txtVendorName.val('');

}

function EnableGstInfo(txtVendorCode, hdnVendorId) {

    ddlGstTypeId.enable(txtVendorCode.val() != '');
    ddlVendorGstStateId.enable(txtVendorCode.val() != '');
    ddlCompanyGstStateId.enable(txtVendorCode.val() != '');
    ddlGstTypeId.val('').change();
    if (hdnVendorId.val() > 0) {

        var requestData = { vendorId: hdnVendorId.val() };
        AjaxRequestWithPostAndJson(vendorMasterUrl + '/GetById', JSON.stringify(requestData), function (result) {
            if (!IsObjectNullOrEmpty(result.MasterVendorDetail))
                $('#txtPanNo').val(result.MasterVendorDetail.PanNo);
        }, ErrorFunction, false);
    }
    BindGstState();
}

function BindGstState() {
    var requestData = {};

    //if (ddlGstTypeId.val() != '') {
    //    if (ddlGstTypeId.val() == '4') {
    //        requestData.countryId = '1';

    //        AjaxRequestWithPostAndJson(stateMasterUrl + '/GetStateListByCountryId', JSON.stringify(requestData), function (result) {
    //            BindDropDownList(ddlCompanyGstStateId.Id, result, 'Value', 'Name', '', 'Select Company GST State');
    //            BindDropDownList(ddlVendorGstStateId.Id, result, 'Value', 'Name', '', 'Select Vendor GST State');
    //        }, ErrorFunction, false);

    //        requestData.ownerType = '1';
    //        requestData.ownerId = loginCompanyId;

    //        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetStateListByOwnerTypeIdAndOwnerId', JSON.stringify(requestData), function (result) {
    //            BindDropDownList(ddlCompanyGstStateId.Id, result, 'Value', 'Name', '', 'Select Company GST State');
    //        }, ErrorFunction, false);
    //    }
    //    else {
    requestData.ownerType = '1';
    requestData.ownerId = loginCompanyId;

    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetStateListByOwnerTypeIdAndOwnerId', JSON.stringify(requestData), function (result) {
        BindDropDownList(ddlCompanyGstStateId.Id, result, 'Value', 'Name', '', 'Select Company GST State');
    }, ErrorFunction, false);

    requestData.ownerType = '5';
    requestData.ownerId = hdnVendorId.val();

    if (requestData.ownerId != 1) {
        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetStateListByOwnerTypeIdAndOwnerId', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlVendorGstStateId.Id, result, 'Value', 'Name', '', 'Select Vendor GST State');
        }, ErrorFunction, false);
    }
    else {
        requestData.countryId = '1';
        AjaxRequestWithPostAndJson(stateMasterUrl + '/GetStateListByCountryId', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlVendorGstStateId.Id, result, 'Value', 'Name', '', 'Select Vendor GST State');
        }, ErrorFunction, false);
    }
    //    }
    //}
    //else {
    //    ClearDropDownList(ddlCompanyGstStateId.Id, '', 'Select Company GST State');
    //    ClearDropDownList(ddlVendorGstStateId.Id, '', 'Select Vendor GST State');
    //}
    ////hdnGstTypeId.val(ddlGstTypeId.val());
}

function GetStep2Detail() {
    lblVendorNameStep2.text(txtVendorCode.val() + ' : ' + txtVendorName.val());
    CalculateDueDate();
    CheckValidDueDate();
    SetGstDetail();
    

}
function GetStep4Detail() {
    
    GetTdsDetail();

}
function SetGstDetail() {
    if (ddlVendorGstStateId.val() != ddlCompanyGstStateId.val()) {
        $('#lblIsInterState').text('Yes');
        $('#hdnIsInterState').val(true);
        interState = true;
    }
    else {
        $('#lblIsInterState').text('No');
        $('#hdnIsInterState').val(false);
        interState = false;
    }

    //if (ddlGstTypeId.val() != '4') {
    //	$('#lblIsGstRegistered').text('Yes');
    //	$('#hdnIsGstRegistered').val(1);
    //}
    //else {
    //	$('#lblIsGstRegistered').text('No');
    //	$('#hdnIsGstRegistered').val(0);
    //}

    $('#lblVendorStateName').text($("#ddlVendorGstStateId :selected").text());
    $('#lblCompanyStateName').text($("#ddlCompanyGstStateId :selected").text());

    //$('#ddlGstVendorLocationId').enable($('#hdnIsGstRegistered').val() == 1);
    //$('#ddlGstVendorCityId').enable(hdnVendorId.val() == 1);
}

function InitAccountDetailTable() {
    $('[id*="txtAccountCode"]').each(function () {
        var txtAccountCode = $(this);
        var lblAccountName = $('#' + this.Id.replace('txtAccountCode', 'lblAccountName'));
        var hdnAccountId = $('#' + this.Id.replace('txtAccountCode', 'hdnAccountId'));
        var chkGstExempted = $('#' + this.Id.replace('txtAccountCode', 'chkGstExempted'));
        var chkTdsExempted = $('#' + this.Id.replace('txtAccountCode', 'chkTdsExempted'));
        var chkIsGoodsProduct = $('#' + this.Id.replace('txtAccountCode', 'chkIsGoodsProduct'));
        var ddlSacId = $('#' + this.Id.replace('txtAccountCode', 'ddlSacId'));
        var txtUnits = $('#' + this.Id.replace('txtAccountCode', 'txtUnits'));
        var txtAmount = $('#' + this.Id.replace('txtAccountCode', 'txtAmount'));
        var lblRcm = $('#' + this.Id.replace('txtAccountCode', 'lblRcm'));
        var hdnIsRcm = $('#' + this.Id.replace('txtAccountCode', 'hdnIsRcm'));
        var txtGstRate = $('#' + this.Id.replace('txtAccountCode', 'txtGstRate'));
        var txtGstAmount = $('#' + this.Id.replace('txtAccountCode', 'txtGstAmount'));
        var txtGstCharged = $('#' + this.Id.replace('txtAccountCode', 'txtGstCharged'));
        var txtTotalAmount = $('#' + this.Id.replace('txtAccountCode', 'txtTotalAmount'));
        var ddlCostCenterTypeId = $('#' + this.Id.replace('txtAccountCode', 'ddlCostCenterTypeId'));
        var hdnCostCenterId = $('#' + this.Id.replace('txtAccountCode', 'hdnCostCenterId'));
        var txtCostCenter = $('#' + this.Id.replace('txtAccountCode', 'txtCostCenter'));
        var lblCostCenter = $('#' + this.Id.replace('txtAccountCode', 'lblCostCenter'));

        txtUnits.readOnly();
        txtGstRate.readOnly();
        txtAccountCode.blur(function () {
            //if (chkIsCostCenterApplicable.IsChecked) {
            //    if (!CheckDuplicateInTable('dtAccountDetailList', 'txtCostCenter',$("option:selected", ddlCostCenterTypeId).text(), txtCostCenter)) return false;
            //}
            //else {
            //if (!CheckDuplicateInTable('dtAccountDetailList', 'txtAccountCode', 'Account Code', txtAccountCode)) return false;
            //}
            Account.IsAccountCodeExist(txtAccountCode, hdnAccountId, lblAccountName);
            try {
                CheckDuplicate($(this));
            }
            catch (e) {
                $(this).val('');
                SetFormFieldFocus($(this).Id);
            }
        });

        txtCostCenter.blur(function () {
            //if (chkIsCostCenterApplicable.IsChecked) {
            //if (!CheckDuplicateInTable('dtAccountDetailList', 'txtCostCenter', $("option:selected", ddlCostCenterTypeId).text(), txtCostCenter)) return false;
            //}
            //else {
            //if (!CheckDuplicateInTable('dtAccountDetailList', 'txtAccountCode', 'Account Code', txtAccountCode)) return false;
            //}
            return Account.IsAccountCodeExist(txtAccountCode, hdnAccountId, lblAccountName);
        });

        Account.AccountAutoComplete(txtAccountCode.Id, hdnAccountId.Id);

        txtCostCenter.blur(function () { return CheckIsCostCenterValid(ddlCostCenterTypeId, txtCostCenter, hdnCostCenterId, lblCostCenter); });
        ddlCostCenterTypeId.change(function () { OnCostCenterTypeChange(ddlCostCenterTypeId, txtCostCenter, hdnCostCenterId); });

        chkIsGoodsProduct.change(function () {
            txtUnits.val(0);
            txtUnits.readOnly(!chkIsGoodsProduct.IsChecked);
            txtGstRate.readOnly(!chkIsGoodsProduct.IsChecked);
            lblRcm.text("No");
            txtGstRate.val(0);
            if (chkIsGoodsProduct.IsChecked) {
                AddRequired(txtUnits, 'Please select Units');
                AddRequired(txtGstRate, 'Please select GST Rate');
                AddRange(txtUnits, 'Please enter Units', 1);
                AddRange(txtGstRate, 'Please enter GST', 0.001);
                var requestData = {};
                AjaxRequestWithPostAndJson(hsnMasterUrl + '/GetHsnList', JSON.stringify(requestData), function (responseData) {
                    if (responseData.length != 0) {
                        BindDropDownList(ddlSacId.Id, responseData, 'Value', 'Name', '', 'Select');
                    }
                }, ErrorFunction, false);
                hdnIsRcm.val(false);
                lblRcm.text("No");
                RemoveRequired(ddlSacId);
                AddRequired(ddlSacId, 'Please select HSN');
            }
            else {
                RemoveRequired(ddlSacId);
                AddRequired(ddlSacId, 'Please select SAC');
                RemoveRequired(txtUnits);
                RemoveRequired(txtGstRate);
                RemoveRange(txtUnits);
                RemoveRange(txtGstRate);
                var requestData = {};
                AjaxRequestWithPostAndJson(gstMasterUrl + '/GetList', JSON.stringify(requestData), function (responseData) {
                    if (responseData.length != 0) {
                        BindDropDownList(ddlSacId.Id, responseData, 'Value', 'Name', '', 'Select');
                    }
                }, ErrorFunction, false);
            }
            CalculateAmount();
        });

        chkGstExempted.change(OnGstExemptedChange);
        chkTdsExempted.change(OnTdsExemptedChange);
        OnGstExemptedChange();
        OnTdsExemptedChange();
        ddlSacId.change(function () {
            try {
                CheckDuplicate($(this));
            }
            catch (e) {
                $(this).val('');
                SetFormFieldFocus($(this).Id);
            }
            if (ddlSacId.val() != '') {
                var requestData = { id: ddlSacId.val() };
                AjaxRequestWithPostAndJson(gstMasterUrl + '/GetDetailById', JSON.stringify(requestData), function (result) {
                    if (result != null) txtGstRate.val(result.GstRate);
                    if (!chkIsGoodsProduct.IsChecked) {
                        lblRcm.text(result.IsRcm == true ? "Yes" : "No");
                        hdnIsRcm.val(result.IsRcm);
                    }
                }, ErrorFunction, false);
                CalculateAmount();
            }
        });
        txtAmount.blur(CalculateAmount);
        txtGstRate.blur(CalculateAmount);
    });
}

function CheckDuplicate(obj) {
    if (obj.val() != '' && !obj.is('[readonly]')) {
        var outertr = obj.closest('tr');
        var outertxtAccountCode = outertr.find('[id*="txtAccountCode"]');
        var outerddlSacId = outertr.find('[id*="ddlSacId"]');
        var outertxtCostCenter = outertr.find('[id*="txtCostCenter"]');
        var outerddlCostCenterTypeId = outertr.find('[id*="ddlCostCenterTypeId"]');

        $('#dtAccountDetailList tr:not(:first)').each(function () {
            var innertr = $(this);
            var innertxtAccountCode = innertr.find('[id*="txtAccountCode"]');
            var innerddlSacId = innertr.find('[id*="ddlSacId"]');
            var innertxtCostCenter = innertr.find('[id*="txtCostCenter"]');
            var innerddlCostCenterTypeId = innertr.find('[id*="ddlCostCenterTypeId"]');

            if (chkIsCostCenterApplicable.IsChecked) {
                if (innertxtAccountCode.attr('id') != outertxtAccountCode.attr('id') &&
                    innertxtAccountCode.val() == outertxtAccountCode.val() &&
                    innertxtCostCenter.val() == outertxtCostCenter.val() &&
                    innerddlCostCenterTypeId.val() == outerddlCostCenterTypeId.val() &&
                    innerddlSacId.val() == outerddlSacId.val()) {
                    ShowMessage("Please remove Duplicate Account Code : " + innertxtAccountCode.val());
                    throw (true);
                }
            }
            else {
                if (innertxtAccountCode.attr('id') != outertxtAccountCode.attr('id') &&
                    innertxtAccountCode.val() == outertxtAccountCode.val() &&
                    innerddlSacId.val() == outerddlSacId.val()) {
                    ShowMessage("Please remove Duplicate Account Code : " + innertxtAccountCode.val());
                    throw (true);
                }
            }
        });
    }
}

function OnGstExemptedChange() {
    var isGst = false;
    $('[id*="chkGstExempted"]').each(function () {
        var chkGstExempted = $(this);
        if (!chkGstExempted.IsChecked)
            isGst = true;
    });
    CalculateAmount();
}

function OnTdsExemptedChange() {
    var isTds = false;
    $('[id*="chkTdsExempted"]').each(function () {
        var chkTdsExempted = $(this);
        if (!chkTdsExempted.IsChecked)
            isTds = true;
    });
    CalculateAmount();
}

function CalculateAmount() {
    var isTdsExempted = false, isGstExempted = false;
    var subTotal = 0, totalGstAmount = 0, totalGstRate = 0, totalBillAmount = 0;
    $('[id*="txtAmount"]').each(function () {
        var txtAmount = $(this);
        var txtGstRate = $('#' + this.Id.replace('txtAmount', 'txtGstRate'));
        var hdnIsRcm = $('#' + this.Id.replace('txtAmount', 'hdnIsRcm'));
        var txtGstAmount = $('#' + this.Id.replace('txtAmount', 'txtGstAmount'));
        var txtTotalAmount = $('#' + this.Id.replace('txtAmount', 'txtTotalAmount'));
        var chkTdsExempted = $('#' + this.Id.replace('txtAmount', 'chkTdsExempted'));
        var chkGstExempted = $('#' + this.Id.replace('txtAmount', 'chkGstExempted'));
        var chkIsGoodsProduct = $('#' + this.Id.replace('txtAmount', 'chkIsGoodsProduct'));
        if (txtAmount.val() != '') {
            subTotal = subTotal + parseFloat(txtAmount.val());
            if (hdnIsRcm.val() == "False" || hdnIsRcm.val() == "false") {
                txtGstAmount.val(((parseFloat(txtAmount.val()) * parseFloat(txtGstRate.val())) / 100));
                totalGstRate = totalGstRate + parseFloat(txtGstRate.val());
            }
            else
                txtGstAmount.val(0);
            if (!chkIsGoodsProduct.IsChecked)
                txtGstAmount.val(0);
            totalGstAmount = totalGstAmount + parseFloat(txtGstAmount.val());
            if (chkGstExempted.IsChecked)
                txtTotalAmount.val(parseFloat(txtAmount.val()));
            else
                txtTotalAmount.val(parseFloat(txtAmount.val()) + parseFloat(txtGstAmount.val()));
            totalBillAmount = totalBillAmount + parseFloat(txtTotalAmount.val());
        }
        if (chkTdsExempted.IsChecked)
            isTdsExempted = true;
    });
    $('#txtSubTotal').val(subTotal);
    $('#txtTotal').val((totalBillAmount));
    $('#txtBillAmount').val(subTotal);
    $('#txtGstTotal').val(totalGstAmount);
    $('#hdnGstRate').val(totalGstRate);
    if (totalGstAmount != 0) {
        if (interState) {
            $('#txtIgst').val(totalGstAmount);
            $('#txtSgst').val(0);
            $('#txtCgst').val(0);
            $('#txtUgst').val(0);
            $('#hdnIgstPercentage').val(totalGstRate);
            $('#hdnSgstPercentage').val(0);
            $('#hdnCgstPercentage').val(0);
            $('#hdnUgstPercentage').val(0);
        }
        else if (isState) {
            $('#txtIgst').val(0);
            $('#txtSgst').val(totalGstAmount / 2);
            $('#txtCgst').val(totalGstAmount / 2);
            $('#txtUgst').val(0);
            $('#hdnIgstPercentage').val(0);
            $('#hdnSgstPercentage').val(totalGstRate / 0);
            $('#hdnCgstPercentage').val(totalGstRate / 0);
            $('#hdnUgstPercentage').val(0);
        }
        else if (!isState) {
            $('#txtIgst').val(0);
            $('#txtUgst').val(totalGstAmount / 2);
            $('#txtCgst').val(totalGstAmount / 2);
            $('#txtSgst').val(0);
            $('#hdnIgstPercentage').val(0);
            $('#hdnUgstPercentage').val(totalGstRate / 2);
            $('#hdnCgstPercentage').val(totalGstRate / 2);
            $('#hdnSgstPercentage').val(0);
        }
    }
    $('#txtTdsAmount').val((parseFloat($('#txtSubTotal').val()) * parseFloat($('#txtTdsRate').val())) / 100);
    if (!isTdsExempted)
        $('#txtNetPayableAmount').val(Math.round(totalBillAmount) - parseFloat(txtDiscountReceived.val()) - parseFloat(txtOtherDeduction.val()) - parseFloat($('#txtTdsAmount').val()));
    else
        $('#txtNetPayableAmount').val(Math.round(totalBillAmount) - parseFloat(txtDiscountReceived.val()) - parseFloat(txtOtherDeduction.val()));
}

function CheckIsCostCenterValid(objCostCenterType, objName, objHdnId, objLbl) {
    switch (objCostCenterType.val()) {
        case "1":
            IsCustomerCodeExist(objName, objHdnId, objLbl);
            break;
        case "2":
            IsVendorCodeExist(objName, objHdnId, objLbl);
            break;
        case "3":
            IsUserNameExist(objName, objHdnId);
            break;
        case "4":
            IsVehicleNoExist(objName, objHdnId);
            break;
        case "5":
            IsDocketNoExist(objName, objHdnId);
            break;
        case "6":
            IsDriverNameExistByLocation(objName, objHdnId);
            break;
        case "7":
            IsLocationCodeExist(objName, objHdnId, 'Location');
            break;
        case "8":
            IsTripsheetNoExist(objName, objHdnId);
            break;
        case "9":
            IsThcNoExist(objName, objHdnId);
            break;
    }
}

function IsDocketNoExist(txtDocketNo, hdnDocketId) {
    if (txtDocketNo.val() != '') {
        var requestData = { docketNo: txtDocketNo.val() };
        AjaxRequestWithPostAndJson(docketUrl + '/CheckValidDocketNo', JSON.stringify(requestData), function (result) {
            if (result.Value > 0) {
                hdnDocketId.val(result.Value);
                txtDocketNo.val(result.Name);
            }
            else {
                ShowMessage(docketNomenclature + ' is not exist');
                txtDocketNo.val('');
                hdnDocketId.val('');
                txtDocketNo.focus();
            }
        }, ErrorFunction, false);
    }
}

function IsTripsheetNoExist(txtTripsheetNo, hdnTripsheetId) {
    if (txtTripsheetNo.val() != '') {
        var requestData = { tripsheetNo: txtTripsheetNo.val() };
        AjaxRequestWithPostAndJson(tripsheetUrl + '/CheckValidTripsheetNo', JSON.stringify(requestData), function (result) {
            if (result.Value > 0) {
                hdnTripsheetId.val(result.Value);
                txtTripsheetNo.val(result.Name);
            }
            else {
                ShowMessage('Tripsheet is not exist');
                txtTripsheetNo.val('');
                hdnTripsheetId.val('');
                txtTripsheetNo.focus();
            }
        }, ErrorFunction, false);
    }
}

function IsThcNoExist(txtThcNo, hdnThcId) {
    if (txtThcNo.val() != '') {
        var requestData = { thcNo: txtThcNo.val() };
        AjaxRequestWithPostAndJson(thcUrl + '/CheckValidThcCode', JSON.stringify(requestData), function (result) {
            if (result.Value > 0) {
                hdnThcId.val(result.Value);
                txtThcNo.val(result.Name);
            }
            else {
                ShowMessage('THC is not exist');
                txtThcNo.val('');
                hdnThcId.val('');
                txtThcNo.focus();
            }
        }, ErrorFunction, false);
    }
}

function OnCostCenterTypeChange(ddlCostCenterType, txtCostCenterCode, hdnCostCenter) {
    txtCostCenterCode.val('');
    hdnCostCenter.val('');
    if (ddlCostCenterType.val() == 1)
        CustomerAutoComplete(txtCostCenterCode.Id, hdnCostCenter.Id)
    else if (ddlCostCenterType.val() == 2)
        VendorAutoComplete(txtCostCenterCode.Id, hdnCostCenter.Id);
    else if (ddlCostCenterType.val() == 3)
        UserAutoComplete(txtCostCenterCode.Id, hdnCostCenter.Id);
    else if (ddlCostCenterType.val() == 4)
        VehicleAutoComplete(txtCostCenterCode.Id, hdnCostCenter.Id);
    else if (ddlCostCenterType.val() == 5)
        txtCostCenterCode.autocomplete("destroy");
    else if (ddlCostCenterType.val() == 6)
        DriverAutoCompleteByLocation(txtCostCenterCode.Id, hdnCostCenter.Id);
    else if (ddlCostCenterType.val() == 7)
        LocationAutoComplete(txtCostCenterCode.Id, hdnCostCenter.Id);
    else if (ddlCostCenterType.val() == 8)
        txtCostCenterCode.autocomplete("destroy");
    else if (ddlCostCenterType.val() == 9)
        txtCostCenterCode.autocomplete("destroy");
}

var Account = {
    IsAccountCodeExist: function (txtAccountCode, hdnAccountId, lblAccountName) {
        if (txtAccountCode.val() != '') {
            var requestData = { accountCode: txtAccountCode.val().split(':')[0].trim() };
            AjaxRequestWithPostAndJson(accountMasterUrl + '/IsAccountCodeExist', JSON.stringify(requestData), function (result) {
                if (result.Value > 0) {
                    hdnAccountId.val(result.Value);
                    txtAccountCode.val(result.Name);
                    lblAccountName.text(result.Description);
                }
                else {
                    ShowMessage('Account is not exist');
                    txtAccountCode.focus();
                    txtAccountCode.val('');
                    hdnAccountId.val('');
                    lblAccountName.text('');
                }
            }, ErrorFunction, false);
        }
        return false;
    },
    AccountAutoComplete: function (txtAccountCodeId, hdnAccountId) {
        AutoComplete(txtAccountCodeId, accountMasterUrl + '/GetAccountAutoCompleteList', 'accountCode', 'l', 'l', 'l', 'd', '', hdnAccountId, '', '', true, '');
    }
}



function CalculateNetAmount() {
    txtNetPayableAmount.val(parseFixed(txtGrandTotal.val(), 2) - parseFixed(txtOtherDeduction.val(), 2) - parseFixed(txtDiscountReceived.val(), 2)).blur();
}

function CalculateDueDate() {
    var creditDays;
    if (txtBillDateTime.val() != '') {
        var requestData = { vendorId: hdnVendorId.val() };
        AjaxRequestWithPostAndJson(vendorContractMasterUrl + '/GetCreditDaysByVendorId', JSON.stringify(requestData), function (result) {
            creditDays = result;
        }, ErrorFunction, false);
        var dueDate = $.setDateTime(txtBillDateTime.val()).add(creditDays, 'd');
        txtBillDueDate.val($.entryDate(dueDate));
    }
}

function CheckValidDueDate() {
    if ($.setDateTime(txtBillDueDate.val()) < $.setDateTime(txtBillDateTime.val())) {
        ShowMessage('Please select Due Date greater than Or equal to Bill Date');
        txtBillDueDate.val('');
        return false;
    }
}

function BindVendorGstLocation() {
    if (ddlVendorGstStateId.val() != '') {
        var requestData = {};
        requestData.stateId = ddlVendorGstStateId.val();
        AjaxRequestWithPostAndJson(locationMasterUrl + '/GetLocationListByStateId', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlGstVendorLocationId.Id, result, 'Value', 'Name', '', 'Select Location');
        });
    }
}

function BindVendorGstCity() {
    if (ddlVendorGstStateId.val() != '') {
        var requestData = {};
        if (hdnVendorId.val() != 1) {
            requestData.ownerType = 5;
            requestData.ownerId = hdnVendorId.val();
            requestData.stateId = ddlVendorGstStateId.val();
            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetCityListByOwnerAndState', JSON.stringify(requestData), function (result) {
                BindDropDownList(ddlGstVendorCityId.Id, result, 'Value', 'Name', '', 'Select City');
            });
        }
        else {
            requestData.stateId = ddlVendorGstStateId.val();
            AjaxRequestWithPostAndJson(cityMasterUrl + '/GetCityListByStateId', JSON.stringify(requestData), function (result) {
                BindDropDownList(ddlGstVendorCityId.Id, result, 'Value', 'Name', '', 'Select City');
            });
        }
        OnGstStateChange();
    }
}

function BindCompanyGstLocation() {
    if (ddlCompanyGstStateId.val() != '') {
        var requestData = {};
        requestData.stateId = ddlCompanyGstStateId.val();
        AjaxRequestWithPostAndJson(locationMasterUrl + '/GetLocationListByStateId', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlGstCompanyLocationId.Id, result, 'Value', 'Name', '', 'Select Location');
        });
        AjaxRequestWithPostAndJson(stateMasterUrl + '/CheckStateOrUnionTerritory', JSON.stringify(requestData), function (result) {
            isState = result;
        }, ErrorFunction, false);
    }
}

function BindCompanyGstCity() {
    if (ddlCompanyGstStateId.val() != '') {
        var requestData = {};
        requestData.ownerType = 1;
        requestData.ownerId = loginCompanyId;
        requestData.stateId = ddlCompanyGstStateId.val();
        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetCityListByOwnerAndState', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlGstCompanyCityId.Id, result, 'Value', 'Name', '', 'Select City');
        });
        AjaxRequestWithPostAndJson(stateMasterUrl + '/CheckStateOrUnionTerritory', JSON.stringify(requestData), function (result) {
            isState = result;
        }, ErrorFunction, false);
        OnGstStateChange();
    }
}

function OnGstStateChange() {
    ddlGstTypeId.enable();
    if (ddlVendorGstStateId.val() != '') {
        if (ddlCompanyGstStateId.val() == ddlVendorGstStateId.val())
            ddlGstTypeId.val(0).disable();
        else
            ddlGstTypeId.val(1).disable();
    }
    if (ddlGstTypeId.val() == 0)
        interState = false;
    else
        interState = true;
}

function GetGstDetail(cityType) {
    var requestData = {};
    if (cityType == 'Vendor') {
        if (ddlGstVendorCityId.val() != '') {
            requestData.ownerType = '5';
            requestData.ownerId = hdnVendorId.val();
            requestData.cityId = ddlGstVendorCityId.val();

            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailByOwnerAndCity', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    $('#txtVendorGstNo').val('');
                    $('#hdnVendorGstId').val(0);
                    $('#txtGstVendorAddress').val('');
                    //isRegistered = false;
                }
                else {
                    $('#txtVendorGstNo').val(result.GstTinNo);
                    $('#hdnVendorGstId').val(result.GstId);
                    $('#txtGstVendorAddress').val(result.Address);
                    //isRegistered = true;
                }
            });
        }
    }
    if (cityType == 'Company') {
        if (ddlGstCompanyCityId.val() != '') {
            requestData.ownerType = '1';
            requestData.ownerId = loginCompanyId;
            requestData.cityId = ddlGstCompanyCityId.val();

            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailByOwnerAndCity', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    $('#lblCompanyGstinNo').text('NA');
                    $('#hdnCompanyGstId').val(0);
                    $('#lblCompanyGstAddress').text('NA');
                }
                else {
                    $('#lblCompanyGstinNo').text(result.GstTinNo);
                    $('#hdnCompanyGstId').val(result.GstId);
                    $('#lblCompanyGstAddress').text(result.Address);
                }
            });
        }
    }
}

function OnCostCenterChange() {
    $('#thCostCenterType').showHide(chkIsCostCenterApplicable.IsChecked);
    $('#thCostCenter').showHide(chkIsCostCenterApplicable.IsChecked);
    $('#thCostCenterName').showHide(chkIsCostCenterApplicable.IsChecked);
    $('#ftCostCenterType').showHide(chkIsCostCenterApplicable.IsChecked);
    $('#ftCostCenter').showHide(chkIsCostCenterApplicable.IsChecked);
    $('#ftCostCenterName').showHide(chkIsCostCenterApplicable.IsChecked);
    $('[id*="ddlCostCenterTypeId"]').each(function () {
        var ddlCostCenterTypeId = $(this);
        var hdnCostCenterId = $('#' + this.Id.replace('ddlCostCenterTypeId', 'hdnCostCenterId'));
        var txtCostCenter = $('#' + this.Id.replace('ddlCostCenterTypeId', 'txtCostCenter'));
        var tdCostCenterType = $('#' + this.Id.replace('ddlCostCenterTypeId', 'tdCostCenterType'));
        var tdCostCenter = $('#' + this.Id.replace('ddlCostCenterTypeId', 'tdCostCenter'));
        var tdCostCenterName = $('#' + this.Id.replace('ddlCostCenterTypeId', 'tdCostCenterName'));
        ddlCostCenterTypeId.enable(chkIsCostCenterApplicable.IsChecked);
        txtCostCenter.enable(chkIsCostCenterApplicable.IsChecked);
        tdCostCenterType.showHide(chkIsCostCenterApplicable.IsChecked);
        tdCostCenter.showHide(chkIsCostCenterApplicable.IsChecked);
        tdCostCenterName.showHide(chkIsCostCenterApplicable.IsChecked);
    });
}

function SetCommanCostCenterType() {
    $('[id*="ddlCostCenterTypeId"]').val($('#ddlCommanCostCenterTypeId').val());
    $('[id*="ddlCostCenterTypeId"]').change();
    OnCostCenterTypeChange($('#ddlCommanCostCenterTypeId'), $('#txtCommanCostCenter'), $('#hdnCommanCostCenterId'));
}

function SetCommanCostCenter() {
    $('[id*="txtCostCenter"]').val($('#txtCommanCostCenter').val());
    $('[id*="hdnCostCenterId"]').val($('#hdnCommanCostCenterId').val());
    $('[id*="lblCostCenter"]').text($('#lblCommanCostCenter').text());
}
function GetTdsDetail() {
    var requestData = { vendorId: hdnVendorId.val() };
    AjaxRequestWithPostAndJson(vendorMasterUrl + '/GetById', JSON.stringify(requestData), function(result) {
        if (IsObjectNullOrEmpty(result)) {
            $('#txtTdsRate').val('');
            $('#ddlTdsSection').val('');
        }
        else {
            $('#txtTdsRate').val(result.MasterVendorDetail.TDSRate);
            $('#ddlTdsSection').val(result.MasterVendorDetail.TdsAccountId);
        }
    });
}

function CheckDuplicateManualBillNo() {
    var requestData = { vendorId: hdnVendorId.val(), manualBillNo: txtDocumentNo.val() };
    AjaxRequestWithPostAndJson(vendorPaymentUrl + '/IsOtherManualBillNoExist', JSON.stringify(requestData), function (result) {
        if (!IsObjectNullOrEmpty(result)) {
            txtDocumentNo.val('');
            txtDocumentNo.focus();
            ShowMessage("Bill No. already Exist");
            return false;
        }
    });
}