var txtVendorCode, hdnVendorId, lblVendorName, txtDocumentNo, txtManualBillNo, ddlTransportModeId, drTransactionDate, dtDocumentList, dtDocumentDetailList, selectedDocumentList,
    vendorMasterUrl, docketNomenclature;

$(document).ready(function () {
    SetPageLoad('BA', 'Bill Entry', 'txtVendorName', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtVendorCode = $('#txtVendorCode'); hdnVendorId = $('#hdnVendorId'); lblVendorName = $('#lblVendorName');  ddlVendorServiceId = $('#ddlVendorServiceId'); txtDocumentNo = $('#txtDocumentNo'); lblVendorNameStep2 = $('#lblVendorNameStep2'); lblVendorNameStep3 = $('#lblVendorNameStep3'); chkDocumentType = $('#chkDocumentType'); chkDocument = $('#chkDocument'); txtDueDateTime = $('#txtDueDateTime'); txtBillAmount = $('#txtBillAmount'); hdnVendorChargeList = $('#hdnVendorChargeList'); txtOtherDeduction = $('#txtOtherDeduction'); txtDiscountReceived = $('#txtDiscountReceived'); txtNetPayableAmount = $('#txtNetPayableAmount');
    drTransactionDate = InitDateRange('drTransactionDate', DateRange.LastWeek);
    txtOtherDeduction.val(0);
    txtDiscountReceived.val(0);
    InitWizard('dvWizard', [{ StepName: 'Criteria', StepFunction: GetDocumentListForBaBill }, { StepName: docketNomenclature + ' List', StepFunction: GetDocumentDetailForBillGeneration }, { StepName: 'Payment Detail', StepFunction: CalculateSubTotal }, { StepName: 'Tax Details', StepFunction: CalculateNetAmount }, { StepName: 'Discount Details' }], 'BA Bill Generation');
}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { return IsVendorCodeExist(txtVendorCode, hdnVendorId, lblVendorName); });
    txtOtherDeduction.change(function () { CalculateNetAmount(); });
    txtDiscountReceived.change(function () { CalculateNetAmount(); });
}


function GetDocumentListForBaBill() {
    var requestData = { VendorId: hdnVendorId.val(), FromDate: drTransactionDate.startDate, ToDate: drTransactionDate.endDate, DocumentNo: txtDocumentNo.val() };
    AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetDocumentListForBaBillGeneration', JSON.stringify(requestData), function (result) {
        if (dtDocumentList == null)
            dtDocumentList = LoadDataTable('dtDocumentList', false, false, false, null, null, [],
              [
                  { title: "<div class='clearfix' style='width:80px'><div class='checkboxer'>" + SelectAll.GetChkAll('chkAllDocument', SelectDocument) + "</div></div>", data: "DocketId", width: 80 },
                  { title: docketNomenclature + ' No', data: 'DocketNo' },
                  { title: docketNomenclature + ' Date', data: 'DocketDate' },
                  { title: 'Paybas', data: 'Paybas' },
                  { title: 'Origin', data: 'Origin' },
                  { title: 'Destination', data: 'Destination' },
                  { title: 'Packages', data: 'Packages' },
                  { title: 'Charge Weight', data: 'ChargeWeight' },
                  { title: 'Subtotal', data: 'SubTotal' },
                  { title: 'Basic Freight', data: 'BasicFreight' },
                  { title: 'Rate', data: 'Rate' },
                  { title: 'Contract Amount', data: 'ContractAmount' },
                  { title: 'Rate Type', data: 'RateType' }
              ]);

        dtDocumentList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.DocketId = "<div class='clearfix' style='width:80px'><div class='checkboxer'>" +
                                SelectAll.GetChk('chkAllDocument', 'chkDocument' + i, 'Details[' + i + '].IsChecked', SelectDocument) +
                                "<input type='hidden' value='" + item.DocketId + "' name='Details[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                                "<label class='label' for='chkDocument" + i + "' id='lblDocketId" + i + "'></label>" +
                                "</div></div>";
                item.DocketDate = $.displayDate(item.DocketDate);
            });
            lblVendorNameStep2.text(txtVendorCode.val());
            dtDocumentList.dtAddData(result);
            dtDocumentList.removeClass('dataTable')
        }
    }, ErrorFunction, false);
    return false;
}

function SelectDocument() {
}

function GetDocumentDetailForBillGeneration() {
    lblVendorNameStep3.text(txtVendorCode.val());
    txtDueDateTime.disable();
    selectedDocumentList = [];
    $('[id*="hdnDocketId"]').each(function () {
        var hdnDocketId = $(this);
        var chkDocument = $('#' + hdnDocketId.Id.replace('hdnDocketId', 'chkDocument'));
        if (chkDocument.IsChecked) {
            selectedDocumentList.push(parseFloat(hdnDocketId.val()));
        }
    });

    if (selectedDocumentList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one ' + docketNomenclature);
        return false;
    }
    else {
        AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetDocumentDetailForBaBillGeneration', JSON.stringify(selectedDocumentList), function (result) {
            if (dtDocumentDetailList == null)
                dtDocumentDetailList = LoadDataTable('dtDocumentDetailList', false, false, false, null, null, [],
                  [
                      { title: docketNomenclature + ' No', data: 'DocketNo' },
                      { title: docketNomenclature + ' Date', data: 'DocketDate' },
                      { title: 'Paybas', data: 'Paybas' },
                      { title: 'Origin', data: 'Origin' },
                      { title: 'Destination', data: 'Destination' },
                      { title: 'Packages', data: 'Packages' },
                      { title: 'Charge Weight', data: 'ChargeWeight' },
                      { title: 'Subtotal', data: 'SubTotal' },
                      { title: 'Basic Freight', data: 'BasicFreight' },
                      { title: 'Rate', data: 'Rate' },
                      { title: 'Contract Amount', data: 'ContractAmount' },
                      { title: 'Rate Type', data: 'RateType' }
                  ]);

            dtDocumentDetailList.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                totalBillAmount = 0;
                $.each(result, function (i, item) {
                    totalBillAmount = totalBillAmount + parseFloat(item.ContractAmount);
                    item.DocketNo = "<input type='hidden' value='" + item.DocketId + "' name='Details[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                                    '<input type=\'text\' name="Details[' + i + '].DocketNo" id="txtDocketNo' + i + '" value=' + item.DocketNo + ' class="form-control textlabel"/>';
                    item.DocketDate = $.displayDate(item.DocketDate);
                    item.ContractAmount = '<input type=\'text\' name="Details[' + i + '].ContractAmount" id="txtContractAmount' + i + '" value=' + item.ContractAmount + ' class="form-control textlabel numeric2"/>';

                });
                dtDocumentDetailList.dtAddData(result);
                dtDocumentDetailList.removeClass('dataTable')
            }
        }, ErrorFunction, false);

        txtBillAmount.val(totalBillAmount);
        return false;
    }
}

function CalculateSubTotal() {
    var subTotalAmount = 0.00;
    $('[id*="txtDocketNo"]').each(function () {
        txtDocketNo = $(this);
        txtContractAmount = $('#' + this.id.replace('txtDocketNo', 'txtContractAmount'));

        subTotalAmount += parseFloat(txtContractAmount.val());
    });
    txtSubTotal.val(subTotalAmount);
    hdnServiceTaxApplicableAmount.val(subTotalAmount);
    hdnTdsApplicableAmount.val(subTotalAmount);
    CalculateServiceTaxDetails();
}

function CalculateNetAmount() {
    txtNetPayableAmount.val(parseFixed(txtGrandTotal.val(), 2) - parseFixed(txtOtherDeduction.val() == '' ? 0 : txtOtherDeduction.val(), 2) - parseFixed(txtDiscountReceived.val() == '' ? 0 : txtDiscountReceived.val(), 2)).blur();
}

