var hdnAccountId, hdnIsInterState, hdnSacId, hdnIsRcm, hdnServiceTypeId, GstRateUrl, txtManualBillNo, txtBillDate, txtDueDate, hdnPaybasId, hdnCustomerId, customerContractMasterUrl, txtGstRate,
    interState, hdnBillGenerationStateId, hdnBillSubmissionStateId, hdnUgst, hdnCgst, hdnSgst, hdnIgst, hdnUgstPercentage, hdnCgstPercentage, hdnSgstPercentage,
    hdnIgstPercentage, hdnCompanyGstId, isState, hdnPartyGstId, txtTotalAmt, hdnTotalPercentage, btnSubmit;
var allowMandatoryManualBillNo = false;
var serviceTypeId;

$(document).ready(function () {
    SetPageLoad('GST', 'Supp. Bill', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtDueDate = $('#txtDueDate');
    txtBillDate = $('#txtBillDate');
    hdnPaybasId = $('#hdnPaybasId');
    hdnCustomerId = $('#hdnCustomerId');
    hdnBillSubmissionStateId = $('#hdnBillSubmissionStateId');
    hdnBillGenerationStateId = $('#hdnBillGenerationStateId');
    hdnIsInterState = $('#hdnIsInterState');
    hdnUgst = $('#hdnUgst');
    hdnCgst = $('#hdnCgst');
    hdnSgst = $('#hdnSgst');
    hdnIgst = $('#hdnIgst');
    hdnUgstPercentage = $('#hdnUgstPercentage');
    hdnCgstPercentage = $('#hdnCgstPercentage');
    hdnSgstPercentage = $('#hdnSgstPercentage');
    hdnIgstPercentage = $('#hdnIgstPercentage');
    txtManualBillNo = $('#txtManualBillNo');
    txtGstRate = $('#txtGstRate');
    hdnCompanyGstId = $('#hdnCompanyGstId');
    hdnPartyGstId = $('#hdnPartyGstId');
    hdnSacId = $('#hdnSacId');
    txtTotalAmt = $('#txtTotalAmt');
    btnSubmit = $('#btnSubmit');
    txtVehicleNo = $('#txtVehicleNo');
    hdnVehicleId = $('#hdnVehicleId');
    lblVendorName = $('#lblVendorName');
}

function AttachEvents() {
    if (serviceTypeId == 2 || serviceTypeId == 3 || serviceTypeId == 4) {
        InitGrid('dtGstSubBill', false, 12, InitGstBillDetail);
    }
    else if(serviceTypeId == 5) {
        InitGrid('dtGstSubBill', false, 18, InitGstBillDetail);
    }
    else {
        InitGrid('dtGstSubBill', false, 10, InitGstBillDetail);
    }
    var requestData = { moduleId: 15, ruleId: 4 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        allowMandatoryManualBillNo = (result == "Y" ? true : false);
    }, ErrorFunction, false);
    if (allowMandatoryManualBillNo)
        AddRequired($('#txtManualBillNo'), 'Please enter Manual BillNo');
    if (serviceTypeId == 4) {
        VehicleAutoComplete('txtVehicleNo', 'hdnVehicleId');
        txtVehicleNo.blur(function () { IsVehicleNoExist(txtVehicleNo, hdnVehicleId); });
        txtVehicleNo.blur(function () {
            if (hdnVehicleId.val() > 0) {
                var requestData2 = { id: hdnVehicleId.val() };
                AjaxRequestWithPostAndJson(vehicleMasterUrl + '/GetById', JSON.stringify(requestData2), function (result) {
                    lblVendorName.text(result.VendorName);
                }, ErrorFunction, false);
            }
            else {
                lblVendorName.text('');
            }
        });
    }
}

var creditDays = 0;
function InitGstBillDetail() {
    $('[id*="hdnAccountId"]').each(function () {
        var hdnAccountId = $(this);
        var txtAccountCode = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'txtAccountCode'));
        var lblAccountDescription = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'lblAccountDescription'));
        var txtNarration = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'txtNarration'));
        var txtAmount = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'txtAmount'));
        var txtGstRate = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'txtGstRate'));
        var txtGstCharge = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'txtGstCharge'));
        var txtGstAmount = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'txtGstAmount'));
        var txtTotalAmt = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'txtTotalAmt'));
        var hdnSacId = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'hdnSacId'));
        var hdnIsRcm = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'hdnIsRcm'));
        var lblIsRcm = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'lblIsRcm'));
        var ddlSAC = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'ddlSAC'));
        var lblIsRcm = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'lblIsRcm'));
        var hdnServiceTypeId = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'hdnServiceTypeId'));
        var ddlWarehouseId = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'ddlWarehouseId'));
        var ddlVehicleId = $('#' + hdnAccountId.Id.replace('hdnAccountId', 'ddlVehicleId'));

        var requestData = { customerId: hdnCustomerId.val(), paybasId: hdnPaybasId.val() };
        AjaxRequestWithPostAndJson(customerContractMasterUrl + '/GetCreditDaysByCustomerIdAndPaybasId', JSON.stringify(requestData), function (result) {
            creditDays = result;
        }, ErrorFunction, false);
        txtBillDate.blur(CalculateDueDate);

        AccountAutoComplete(txtAccountCode.Id, hdnAccountId.Id);
        txtAccountCode.blur(function () { return IsAccountNameExist(txtAccountCode, hdnAccountId, lblAccountDescription) });

        if (serviceTypeId == 1) {
            txtAccountCode.blur(function () {
                if (!CheckDuplicateInTable('dtGstSubBill', 'txtAccountCode', 'Account Code', txtAccountCode)) return false;
            });
        }
        else if (serviceTypeId == 2) {
            hdnAccountId.val(552);
            txtAccountCode.val('INC0553');
            lblAccountDescription.text('INCOME FROM WAREHOUSE DIVISON');
            ddlWarehouseId.change(function () {
                if (!CheckDuplicateInTable('dtGstSubBill', 'ddlWarehouseId', 'Warehouse', ddlWarehouseId)) return false;
            });
        }
        else if (serviceTypeId == 3) {
            txtAccountCode.change(function () {
                try {
                    CheckDuplicateInTableForRentalProductBilling($(this));
                }
                catch (e) {
                    $(this).val('');
                    SetFormFieldFocus($(this).Id);
                }
            });
            ddlSAC.change(function () {
                try {
                    CheckDuplicateInTableForRentalProductBilling($(this));
                }
                catch (e) {
                    $(this).val('');
                    SetFormFieldFocus($(this).Id);
                }
            });
        }
        if (serviceTypeId == 5) {
            ddlVehicleId.blur(function () {
                if (!CheckDuplicateInTable('dtGstSubBill', 'ddlVehicleId', 'Vehicle', ddlVehicleId)) return false;
            });
        }

        txtAccountCode.blur(function () {
            ddlSAC.val("");
            txtNarration.val("");
            hdnServiceTypeId.val(0);
            txtGstRate.val(0);
            txtAmount.val(0);
            txtGstCharge.val(0);
            txtGstAmount.val(0);
            txtTotalAmt.val(0);
            //ddlSAC.focus();
            IsInterState();
            return false;
        });

        ddlSAC.change(function () {
            txtGstRate.val(0);
            txtAmount.val(0);
            hdnSacId.val(0);
            hdnIsRcm.val(false);
            lblIsRcm.text('NO');
            txtGstCharge.val(0);
            txtGstAmount.val(0);
            txtTotalAmt.val(0);
            //txtNarration.focus();
            return false;
        });

        txtManualBillNo.blur(IsStateOrUnionTerritory);
        btnSubmit.click(CalCulateGstCharge);

        if (txtAmount.val() == '') txtAmount.val(0);
        if (txtGstRate.val() == '') txtGstRate.val(0);
        if (txtGstCharge.val() == '') txtGstCharge.val(0);
        if (txtGstAmount.val() == '') txtGstAmount.val(0);
        if (txtTotalAmt.val() == '') txtTotalAmt.val(0);
        if (lblIsRcm.val() == '') lblIsRcm.text("No");

        ddlSAC.change(GetGstRate);
        txtAmount.blur(GetAmount);
        txtGstRate.blur(GetAmount);

        function GetAmount() {
            if (hdnIsRcm.val() == "true") {
                txtGstAmount.val(txtAmount.toFloat() * txtGstRate.toFloat() / 100);
                txtGstCharge.val(0);
                txtTotalAmt.val(txtAmount.toFloat() + txtGstCharge.toFloat());
                CalCulateGstCharge();
            }
            else {
                txtGstAmount.val(txtAmount.toFloat() * txtGstRate.toFloat() / 100);
                txtGstCharge.val(txtAmount.toFloat() * txtGstRate.toFloat() / 100);
                txtTotalAmt.val(txtAmount.toFloat() + txtGstCharge.toFloat());
                CalCulateGstCharge();
            }
        }
    });
}

function CheckDuplicateInTableForRentalProductBilling(obj) {
    if (obj.val() != '') {
        var outertr = obj.closest('tr');
        var outertxtAccountCode = outertr.find('[id*="txtAccountCode"]');
        var outerddlSAC = outertr.find('[id*="ddlSAC"]');

        $('#dtGstSubBill tr:not(:first)').each(function () {
            var innertr = $(this);
            var innertxtAccountCode = innertr.find('[id*="txtAccountCode"]');
            var innerddlSAC = innertr.find('[id*="ddlSAC"]');

            if (innertxtAccountCode.attr('id') != outertxtAccountCode.attr('id') &&
                innertxtAccountCode.val() == outertxtAccountCode.val() &&
                innerddlSAC.val() == outerddlSAC.val()) {
                ShowMessage("Remove Duplicate");
                throw (true);
            }
        });
    }
}

function IsStateOrUnionTerritory() {
    if (hdnCompanyGstId.val() != '') {
        var requestData = { stateId: hdnCompanyGstId.val() };
        AjaxRequestWithPostAndJson(UnionMasterUrl + '/CheckIsStateOrUnionTerritory', JSON.stringify(requestData), function (result) {
            isState = result;
        }, ErrorFunction, false);
    }
}

function CalculateDueDate() {
    if (txtBillDate.val() != '') {
        var days = parseInt(creditDays);
        var dueDate = $.setDateTime(txtBillDate.val()).add(creditDays, 'd');
        txtDueDate.val($.entryDate(dueDate));
    }
}

function GetGstRate() {
    var hdnService = 0;
    $('[id*="ddlSAC"]').each(function () {
        var ddlSAC = $(this);
        var hdnServiceTypeId = $('#' + ddlSAC.Id.replace('ddlSAC', 'hdnServiceTypeId'));
        var hdnSacId = $('#' + ddlSAC.Id.replace('ddlSAC', 'hdnSacId'));
        var txtGstRate = $('#' + ddlSAC.Id.replace('ddlSAC', 'txtGstRate'));
        var hdnIsRcm = $('#' + ddlSAC.Id.replace('ddlSAC', 'hdnIsRcm'));
        var lblIsRcm = $('#' + ddlSAC.Id.replace('ddlSAC', 'lblIsRcm'));

        hdnService = (ddlSAC.val());
        hdnServiceTypeId.val(hdnService);

        if (ddlSAC.val() != "") {
            var requestData = { gstServiceIdId: hdnServiceTypeId.val() };
            AjaxRequestWithPostAndJson(GstRateUrl + '/GetGstRate', JSON.stringify(requestData), function (result) {
                if (result.SacId != "") {
                    hdnSacId.val(result.GstSacId);
                    txtGstRate.val(result.GstRate);
                    lblIsRcm.text(result.IsRcm == true ? "YES" : "NO");
                    hdnIsRcm.val(result.IsRcm)
                }
                else {
                    ShowMessage('SAC Not Exist');
                    hdnSacId.val('');
                    txtGstRate.val('');
                    hdnIsRcm.val('');
                    lblIsRcm.text('');
                    ddlSAC.focus();
                }
            }, ErrorFunction, false);
        }
        else {
            hdnIsRcm.val(false);
            lblIsRcm.text("NO");
        }
    });
}

function IsInterState() {
    if (hdnBillSubmissionStateId.val() == hdnBillGenerationStateId.val()) {
        interState = false;
        $('#hdnIsInterState').val('Intra State');
        IsStateOrUnionTerritory();
    }
    else if (hdnBillGenerationStateId.val() != hdnBillSubmissionStateId.val()) {
        interState = true;
        $('#hdnIsInterState').val('Inter State');
        IsStateOrUnionTerritory();
    }
    else
        $('#lblIsInterState').val('');
}

function CalCulateGstCharge() {
    var taxTotal = 0;
    $('[id*="ddlSAC"]').each(function () {
        var ddlSAC = $(this);
        var txtGstCharge = $('#' + ddlSAC.Id.replace('ddlSAC', 'txtGstCharge'));
        var txtGstRate = $('#' + ddlSAC.Id.replace('ddlSAC', 'txtGstRate'));
        var hdnIsRcm = $('#' + ddlSAC.Id.replace('ddlSAC', 'hdnIsRcm'));
        var igst = cgst = sgst = ugst = 0.00;
        var igstPercentage = cgstPercentage = sgstPercentage = ugstPercentage = 0;
        if (hdnIsRcm.val() == "false") {
            if (hdnCompanyGstId.val() != '' && hdnPartyGstId.val() != '' && hdnSacId.val() != '') {
                taxTotal = taxTotal + parseFloat(txtGstCharge.val());
                if (interState) {
                    igst = taxTotal;
                    igstPercentage = txtGstRate.val();
                }
                else if (isState) {
                    sgst = taxTotal / 2;
                    cgst = taxTotal / 2;
                    sgstPercentage = txtGstRate.val() / 2;
                    cgstPercentage = txtGstRate.val() / 2;

                }
                else if (!isState) {
                    ugst = taxTotal / 2;
                    cgst = taxTotal / 2;
                    ugstPercentage = txtGstRate.val() / 2;
                    cgstPercentage = txtGstRate.val() / 2;
                }
            }
            else {
            }
        }
        hdnIgst.val(igst);
        hdnSgst.val(sgst);
        hdnCgst.val(cgst);
        hdnUgst.val(ugst);
        hdnIgstPercentage.val(igstPercentage);
        hdnSgstPercentage.val(sgstPercentage);
        hdnCgstPercentage.val(cgstPercentage);
        hdnUgstPercentage.val(ugstPercentage);
    });
}
