var txtVendorCode, hdnVendorId, lblVendorName, txtBillNo, txtManualBillNo, lblVendorNameStep2, ddlTransportModeId, drTransactionDate, dtBillList, selectedBillList, totalAmount,
    vendorMasterUrl, vendorPaymentUrl, dtBillDetailsList;

$(document).ready(function () {
    SetPageLoad('Vendor', 'Payment', 'txtVendorName', '', '');

    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtVendorCode = $('#txtVendorCode');
    lblVendorName = $('#lblVendorName');
    lblVendorCode = $('#lblVendorCode');
    hdnVendorId = $('#hdnVendorId');
    ddlVendorServiceId = $('#ddlVendorServiceId');
    txtBillNo = $('#txtBillNo');
    txtManualBillNo = $('#txtManualBillNo');
    ddlTransportModeId = $('#ddlTransportModeId');
    txtVoucherDate = $('#txtVoucherDate');
    lblVendorNameStep2 = $('#lblVendorNameStep2');
    drTransactionDate = InitDateRange('drTransactionDate', DateRange.LastWeek, false);

    ddlVendorServiceId.change();
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetBillListForPayment },
        { StepName: 'Document List For Bill Payment', StepFunction: GetBillDetailsForPayment },
        { StepName: 'Payment Details', StepFunction: GetSubTotalAmount },
        { StepName: 'Vendor Bill Payment', StepFunction: OnSubmit }
    ], 'Vendor Bill Payment');
}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { return IsVendorCodeExist(txtVendorCode, hdnVendorId, lblVendorName); });
    txtVendorCode.blur(OnVendorChange);
}

function GetBillListForPayment() {
    var selectedValues = [];
    $("[id*=chkDocumentType]").each(function () {
        var chkDocumentType = $(this);
        if (chkDocumentType.IsChecked == true)
            selectedValues.push($('#' + chkDocumentType.Id.replace('chkDocumentType', 'hdnCodeId')).val());
    });

    var requestData = { VendorId: hdnVendorId.val(), fromDate: $.displayDate(drTransactionDate.startDate), toDate: $.displayDate(drTransactionDate.endDate), BillNo: txtBillNo.val(), ManualNo: txtManualBillNo.val(), TransportMode: ddlTransportModeId.val(), LocationId: loginLocationId, VendorServiceId: ddlVendorServiceId.val() };
    AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetBillListForPayment', JSON.stringify(requestData), function (result) {
        if (dtBillList == null)
            dtBillList = LoadDataTable('dtBillList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllBill', SelectBill) + "</div></div>", data: "BillId", width: 80 },
                    { title: 'Bill No', data: 'BillNo' },
                    { title: 'Bill Date', data: 'BillDate' },
                    { title: 'Manual No', data: 'ManualBillNo' },
                    { title: 'Paid Amount', data: 'PaidAmount' },
                    { title: 'Pending Amount', data: 'PendAmount' },
                    { title: 'Total Amount', data: 'NetAmount' }
                ]);

        dtBillList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.BillId = SelectAll.GetChk('chkAllBill', 'chkBill' + i, 'Details[' + i + '].IsChecked', SelectBill) +
                    "<input type='hidden' value='" + item.BillId + "' name='Details[" + i + "].BillId' id='hdnBillId" + i + "'/>" +
                    "<label class='label' for='chkBill" + i + "' id='lblBillId" + i + "'></label>";

                item.BillDate = $.displayDate(item.BillDate);
            });

            lblVendorNameStep2.text(txtVendorCode.val() + ' : ' + lblVendorName.text());
            dtBillList.dtAddData(result);
            dtBillList.removeClass('dataTable');
        }
    }, ErrorFunction, false);
    return false;
}

function SelectBill() {
    selectedBillList = [];
    $('[id*="chkDocument"]').each(function () {
        var chkDocument = $(this);
        if (chkDocument.IsChecked) {
            selectedBillList.push($('#' + chkDocument.Id.replace('chkBill', 'hdnBillId')).val());
        }
    });
}

function OnVendorChange() {
    if (hdnVendorId.val() != "") {
        var requestData = { vendorId: hdnVendorId.val() };
        AjaxRequestWithPostAndJson(vendorMasterUrl + '/GetVendorServiceByVendorId', JSON.stringify(requestData), GetVendorServiceListSuccess, ErrorFunction, false);
    }
}

function GetVendorServiceListSuccess(responseData) {
    BindDropDownList('ddlVendorServiceId', responseData, 'Value', 'Name', '', 'Select');
}

function GetBillDetailsForPayment() {
    var selectedBillList = [];

    $("[id*=chkBill]").each(function () {
        var chkBill = $(this);
        if (chkBill.IsChecked == true)
            selectedBillList.push($('#' + chkBill.Id.replace('chkBill', 'hdnBillId')).val());
    });

    if (selectedBillList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Document');
        return false;
    }
    var requestData = { billId: selectedBillList.join(',') };
    AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetBillDetailForBillPayment', JSON.stringify(requestData), function (result) {
        if (dtBillDetailsList == null)
            dtBillDetailsList = LoadDataTable('dtBillDetailsList', false, false, false, null, null, [],
                [
                    { title: 'Bill No', data: 'BillNo' },
                    { title: 'Bill Date', data: 'BillDate' },
                    { title: 'Manual Bill No', data: 'ManualBillNo' },
                    { title: 'Paid Amount', data: 'PaidAmount' },
                    { title: 'Pending Amount', data: 'PendAmount' },
                    { title: 'Total Amount', data: 'NetAmount' }
                ]);

        dtBillDetailsList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.BillNo = '<input type=\'text\' name="VendorBillDetails[' + i + '].BillNo" id="txtBillNo' + i + '" value=' + item.BillNo + ' class="form-control textlabel"/>' +
                    '<input type=\'hidden\' name="VendorBillDetails[' + i + '].BillId" id="hdnBillId' + i + '" value=' + item.BillId + ' />';
                item.BillDate = $.displayDate(item.BillDate) + '<input type=\'hidden\' name="VendorBillDetails[' + i + '].BillDate" id="hdnBillDate' + i + '" value=' + $.entryDate(item.BillDate) + '"/>';
                item.ManualBillNo = '<input type=\'text\' name="VendorBillDetails[' + i + '].ManualBillNo" id="txtManualBillNo' + i + '" value=' + item.ManualBillNo + ' class="form-control textlabel"/>';
                var paidAmount = item.PaidAmount;
                item.PaidAmount = '<input type=\'text\' name="VendorBillDetails[' + i + '].PaidAmount" id="txtPaidAmount' + i + '" value=' + item.PendAmount + ' class="form-control numeric2"/>' +
                    '<span data-valmsg-for="VendorBillDetails[' + i + '].PaidAmount" data-valmsg-replace="true"></span>';
                item.PendAmount = '<input type=\'text\' name="VendorBillDetails[' + i + '].PendAmount" id="txtPendAmount' + i + '" value=' + item.PendAmount + ' class="form-control textlabel numeric2"/>' +
                    '<input type=\'hidden\' id="hdnPaidAmount' + i + '" value=' + paidAmount + ' />';
                item.NetAmount = '<input type=\'text\' name="VendorBillDetails[' + i + '].NetAmount" id="txtNetAmount' + i + '" value=' + item.NetAmount + ' class="form-control textlabel numeric2"/>' +
                    "<input type='hidden' value='" + item.NetAmount + "' name='VendorBillDetails[" + i + "].NetAmount' id='hdnNetAmount" + i + "'/>";
            });
            lblVendorCode.text(txtVendorCode.val());
            dtBillDetailsList.dtAddData(result);
            dtBillDetailsList.removeClass('dataTable');

            dtBillDetailsList.find('[id*="txtPaidAmount"]').each(function () {
                var txtPendAmount = $('#' + this.id.replace('txtPaidAmount', 'txtPendAmount'));
                var txtPaidAmount = $('#' + this.id.replace('txtPaidAmount', 'txtPaidAmount'));
                var txtNetAmount = $('#' + this.id.replace('txtPaidAmount', 'txtNetAmount'));
                var PendingAmount = parseFloat(txtPendAmount.val());
                AddRange(txtPaidAmount, 'Paid Amount must be less than or equal to ' + PendingAmount.toFixed(3), 1, PendingAmount);
                txtPaidAmount.blur(CalculatePendingAmount);
            });
            CalculatePendingAmount();
        }
    }, ErrorFunction, false);
    return false;
}

function CalculatePendingAmount() {
    $("[id*=txtPaidAmount]").each(function () {
        var txtPaidAmount = $(this);
        var txtPendAmount = $('#' + this.id.replace('txtPaidAmount', 'txtPendAmount'));
        var hdnPaidAmount = $('#' + this.id.replace('txtPaidAmount', 'hdnPaidAmount'));
        var txtPaidAmount = $('#' + this.id.replace('txtPaidAmount', 'txtPaidAmount'));
        var txtNetAmount = $('#' + this.id.replace('txtPaidAmount', 'txtNetAmount'));
        txtPendAmount.val((parseFloat(txtNetAmount.val()) - parseFloat(hdnPaidAmount.val())) - parseFloat(txtPaidAmount.val()));
    });
}

function GetSubTotalAmount() {
    totalAmount = 0;
    dtBillDetailsList.find('[id*="txtPaidAmount"]').each(function () {
        var txtPaidAmount = $('#' + this.id.replace('txtPaidAmount', 'txtPaidAmount'));
        totalAmount += parseFloat(txtPaidAmount.val());
    });
    SetPaymentPartyTypeAndParty(3, hdnVendorId.val());
    txtPaymentAmountApplicable.val(totalAmount);
}

function OnSubmit() {
    $('#chkIsOnAccount').enable(true);
    if ($('#chkIsOnAccount').IsChecked)
        $('#ddlPaymentBankAccount').enable(true);
}