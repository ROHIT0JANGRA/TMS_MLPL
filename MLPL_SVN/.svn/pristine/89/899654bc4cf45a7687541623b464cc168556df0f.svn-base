var txtCustomerCode, lblCustomerName, hdnCustomerId, txtVendorCode, txtManualBillNo, hdnVendorId, txtBillNo, lblVendorName, dtCustomerBillList, dtVendorBillList, drTransactionDate, vendorMasterUrl, selectedDocumentList, baseUrl;
var dtCustomerBillDetail, dtVendorBillDetail, customerBillList = [], vendorBillList = [];
$(document).ready(function () {
    SetPageLoad('Adjustment', 'Adjustment', 'txtCustomerCode', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtVendorCode = $('#txtVendorCode');
    lblVendorName = $('#lblVendorName');
    hdnVendorId = $('#hdnVendorId');
    hdnCustomerId = $('#hdnCustomerId');
    txtCustomerCode = $('#txtCustomerCode');
    lblCustomerName = $('#lblCustomerName');
    txtBillNo = $('#txtBillNo');
    txtManualBillNo = $('#txtManualBillNo');
    dtCustomerBillList = LoadDataTable('dtCustomerBillList', false, false, false, null, null, [],
        [
            { title: SelectAll.GetChkAll('chkAllCustomerBill', SelectCustomerBill), data: "CustomerBillId" },
            { title: 'Customer Bill No', data: 'CustomerBillNo' },
            { title: 'Customer Bill Date', data: 'CustomerBillDate' },
            { title: 'Customer Name', data: 'CustomerName' },
            { title: 'Bill Amount', data: 'CustomerBillAmount' },
            { title: 'Pending Amount', data: 'CustomerPendingAmount' }
        ]);
    dtVendorBillList = LoadDataTable('dtVendorBillList', false, false, false, null, null, [],
        [
            { title: SelectAll.GetChkAll('chkAllVendorBill', SelectVendorBill), data: "VendorBillId" },
            { title: 'Vendor Bill No', data: 'VendorBillNo' },
            { title: 'Vendor Bill Date', data: 'VendorBillDate' },
            { title: 'Vendor Name', data: 'VendorName' },
            { title: 'Bill Amount', data: 'VendorBillAmount' },
            { title: 'Pending Amount', data: 'VendorPendingAmount' }
        ]);
    dtCustomerBillDetail = LoadDataTable('dtCustomerBillDetail', false, false, false, null, null, [],
        [
            { title: 'Customer Bill No', data: 'CustomerBillNo' },
            { title: 'Customer Bill Date', data: 'CustomerBillDate' },
            { title: 'Customer Name', data: 'CustomerName' },
            { title: 'Bill Amount', data: 'CustomerBillAmount' },
            { title: 'Pending Amount', data: 'CustomerPendingAmount' },
            { title: 'Adjustment Amount', data: 'CustomerAdjustmentAmount' }
        ]);
    dtVendorBillDetail = LoadDataTable('dtVendorBillDetail', false, false, false, null, null, [],
        [
            { title: 'Vendor Bill No', data: 'VendorBillNo' },
            { title: 'Vendor Bill Date', data: 'VendorBillDate' },
            { title: 'Vendor Name', data: 'VendorName' },
            { title: 'Bill Amount', data: 'VendorBillAmount' },
            { title: 'Pending Amount', data: 'VendorPendingAmount' },
            { title: 'Adjustment Amount', data: 'VendorAdjustmentAmount' }
        ]);
    drTransactionDate = InitDateRange('drTransactionDate', DateRange.LastWeek);

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetCustomerBillAndVendorBillList },
        { StepName: 'Document List', StepFunction: ValidStep2 },
        { StepName: 'Bill Details', StepFunction: ValidStep3 }
    ], 'Submit');
}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { return IsVendorCodeExist(txtVendorCode, hdnVendorId, lblVendorName); });
    CustomerAutoComplete('txtCustomerCode', 'hdnCustomerId');
    txtCustomerCode.blur(function () { return IsCustomerCodeExist(txtCustomerCode, hdnCustomerId, lblCustomerName); });
    $('[id*="txtCustomerAdjustmentAmount"]').change(function () {
        CalculateTotalCustomerAdjustmentAmount();
    });
    $('[id*="txtVendorAdjustmentAmount"]').change(function () {
        CalculateTotalVendorAdjustmentAmount();
    });
}

function GetCustomerBillAndVendorBillList() {
    $('#txtTotalCustomerAdjustmentAmount').val(0);
    $('#txtTotalVendorAdjustmentAmount').val(0);
    var vendorId = hdnVendorId.val() == '' ? 0 : hdnVendorId.val();
    var customerId = hdnCustomerId.val() == '' ? 0 : hdnCustomerId.val();

    var requestData = { vendorId: vendorId, customerId: customerId, fromDate: drTransactionDate.startDate, toDate: drTransactionDate.endDate, billNos: txtBillNo.val(), manualbillNos: txtManualBillNo.val() };

    AjaxRequestWithPostAndJson(baseUrl + '/GetCustomerBillListForAdjustment', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found For Customer Bill');
            return false;
        }
        else {
            selectedCustomerList = [];
            customerBillList = [];
            dtCustomerBillList.fnClearTable();
            $.each(result, function (i, item) {
                customerBillList.push({ CustomerBillId: item.CustomerBillId, CustomerBillNo: item.CustomerBillNo, CustomerBillDate: item.CustomerBillDate, CustomerName: item.CustomerName, CustomerBillAmount: item.CustomerBillAmount, CustomerPendingAmount: item.CustomerPendingAmount });
                item.CustomerBillId = "<div class='checkboxer'>" +
                    SelectAll.GetChk('chkAllCustomerBill', 'chkCustomerBillId' + i, 'BillDetail[' + i + '].IsChecked', SelectCustomerBill) +
                    "<input type='hidden' value='" + item.CustomerBillId + "' name='BillDetail[" + i + "].CustomerBillId' id='hdnCustomerBillId" + i + "'/>" +
                    "<label class='label' for='chkCustomerBillId" + i + "' id='lblCustomerBillId" + i + "'></label>" +
                    "</div>";
                item.CustomerBillDate = $.displayDate(item.CustomerBillDate);
            });
            dtCustomerBillList.dtAddData(result);
            AjaxRequestWithPostAndJson(baseUrl + '/GetVendorBillListForAdjustment', JSON.stringify(requestData), function (result) {
                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found For Vendor Bill');
                    return false;
                }
                else {
                    selectedVendorList = [];
                    vendorBillList = [];
                    dtVendorBillList.fnClearTable();
                    $.each(result, function (i, item) {
                        vendorBillList.push({ VendorBillId: item.VendorBillId, VendorBillNo: item.VendorBillNo, VendorBillDate: item.VendorBillDate, VendorName: item.VendorName, VendorBillAmount: item.VendorBillAmount, VendorPendingAmount: item.VendorPendingAmount });
                        item.VendorBillId = "<div class='checkboxer'>" +
                            SelectAll.GetChk('chkAllVendorBill', 'chkVendorBillId' + i, 'BillDetail[' + i + '].IsChecked', SelectVendorBill) +
                            "<input type='hidden' value='" + item.VendorBillId + "' name='BillDetail[" + i + "].VendorBillId' id='hdnVendorBillId" + i + "'/>" +
                            "<label class='label' for='chkVendorBillId" + i + "' id='lblVendorBillId" + i + "'></label>" +
                            "</div>";
                        item.VendorBillDate = $.displayDate(item.VendorBillDate);
                    });
                    dtVendorBillList.dtAddData(result);
                }
            }, ErrorFunction, false);
        }
    }, ErrorFunction, false);
    return false;
}

function SelectCustomerBill() {
    selectedCustomerList = [];
    $('[id*="chkCustomerBillId"]').each(function () {
        var chkCustomerBillId = $(this);
        if (chkCustomerBillId.IsChecked) {
            selectedCustomerList.push($('#' + chkCustomerBillId.Id.replace('chkCustomerBillId', 'hdnCustomerBillId')).val());
        }
    });
}

function SelectVendorBill() {
    selectedVendorList = [];
    $('[id*="chkVendorBillId"]').each(function () {
        var chkVendorBillId = $(this);
        if (chkVendorBillId.IsChecked) {
            selectedVendorList.push($('#' + chkVendorBillId.Id.replace('chkVendorBillId', 'hdnVendorBillId')).val());
        }
    });
}

function ValidStep2() {
    if (selectedCustomerList.length == 0 && selectedVendorList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Customer Bill and Vendor Bill');
        return false;
    }
    else if (selectedCustomerList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Customer Bill');
        return false;
    }
    else if (selectedVendorList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Vendor Bill');
        return false;
    }
    else {
        var selectedCustBillDetail = [];
        $.each(customerBillList, function (i, item) {
            if (selectedCustomerList.includes(item.CustomerBillId.toString())) {
                selectedCustBillDetail.push({ CustomerBillId: item.CustomerBillId, CustomerBillNo: item.CustomerBillNo, CustomerBillDate: item.CustomerBillDate, CustomerName: item.CustomerName, CustomerBillAmount: item.CustomerBillAmount, CustomerPendingAmount: item.CustomerPendingAmount, CustomerAdjustmentAmount: 0 });
            }
        });
        dtCustomerBillDetail.fnClearTable();
        $.each(selectedCustBillDetail, function (i, item) {
            item.CustomerAdjustmentAmount = "<input type='text' value='" + item.CustomerAdjustmentAmount + "' name='CustomerAdjustmentDetails[" + i + "].CustomerAdjustmentAmount' class='form-control numeric' id='txtCustomerAdjustmentAmount" + i + "'/>" +
                "<input type='hidden' value='" + item.CustomerPendingAmount + "' id='hdnCustomerPendingAmount" + i + "'/>" +
                "<input type='hidden' value='" + item.CustomerBillId + "' name='CustomerAdjustmentDetails[" + i + "].CustomerBillId' id='hdnCustomerBillId" + i + "'/>";
            item.CustomerBillDate = $.displayDate(item.CustomerBillDate);
        });
        dtCustomerBillDetail.dtAddData(selectedCustBillDetail, [], InitCustomerBillTable);

        var selectedVdrBillDetail = [];
        $.each(vendorBillList, function (i, item) {
            if (selectedVendorList.includes(item.VendorBillId.toString())) {
                selectedVdrBillDetail.push({ VendorBillId: item.VendorBillId, VendorBillNo: item.VendorBillNo, VendorBillDate: item.VendorBillDate, VendorName: item.VendorName, VendorBillAmount: item.VendorBillAmount, VendorPendingAmount: item.VendorPendingAmount, VendorAdjustmentAmount: 0 });
            }
        });
        dtVendorBillDetail.fnClearTable();
        $.each(selectedVdrBillDetail, function (i, item) {
            item.VendorAdjustmentAmount = "<input type='text' value='" + item.VendorAdjustmentAmount + "' name='VendorAdjustmentDetails[" + i + "].VendorAdjustmentAmount' class='form-control numeric' id='txtVendorAdjustmentAmount" + i + "'/>" +
                "<input type='hidden' value='" + item.VendorPendingAmount + "' id='hdnVendorPendingAmount" + i + "'/>" +
                "<input type='hidden' value='" + item.VendorBillId + "' name='VendorAdjustmentDetails[" + i + "].VendorBillId' id='hdnVendorBillId" + i + "'/>";
            item.VendorBillDate = $.displayDate(item.VendorBillDate);
        });
        dtVendorBillDetail.dtAddData(selectedVdrBillDetail, [], InitVendorBillTable);
    }
}

function InitCustomerBillTable() {
    $('[id*="txtCustomerAdjustmentAmount"]').change(function () {
        CalculateTotalCustomerAdjustmentAmount();
    });
    $('[id*="txtCustomerAdjustmentAmount"]').blur(function () {
        var txtCustomerAdjustmentAmount = $(this);
        var hdnCustomerPendingAmount = $('#' + txtCustomerAdjustmentAmount.Id.replace('txtCustomerAdjustmentAmount', 'hdnCustomerPendingAmount'));

        if (parseFloat(hdnCustomerPendingAmount.val()) < parseFloat(txtCustomerAdjustmentAmount.val())) {
            ShowMessage('Adjustment Amount must be less than and equal to Pending Amount');
            txtCustomerAdjustmentAmount.val(0).change();
            isStepValid = false;
            return false;
        }
    });
}

function InitVendorBillTable() {
    $('[id*="txtVendorAdjustmentAmount"]').change(function () {
        CalculateTotalVendorAdjustmentAmount();
    });
    $('[id*="txtVendorAdjustmentAmount"]').blur(function () {
        var txtVendorAdjustmentAmount = $(this);
        var hdnVendorPendingAmount = $('#' + txtVendorAdjustmentAmount.Id.replace('txtVendorAdjustmentAmount', 'hdnVendorPendingAmount'));

        if (parseFloat(hdnVendorPendingAmount.val()) < parseFloat(txtVendorAdjustmentAmount.val())) {
            ShowMessage('Adjustment Amount must be less than and equal to Pending Amount');
            txtVendorAdjustmentAmount.val(0).change();
            isStepValid = false;
            return false;
        }
    });
}

function CalculateTotalCustomerAdjustmentAmount() {
    var totalCustomerAdjustmentAmount = 0;
    $('[id*="txtCustomerAdjustmentAmount"]').each(function () {
        var txtCustomerAdjustmentAmount = $(this);
        totalCustomerAdjustmentAmount = totalCustomerAdjustmentAmount + parseFloat(txtCustomerAdjustmentAmount.val());
    });
    $('#txtTotalCustomerAdjustmentAmount').val(totalCustomerAdjustmentAmount);
}

function CalculateTotalVendorAdjustmentAmount() {
    var totalVendorAdjustmentAmount = 0;
    $('[id*="txtVendorAdjustmentAmount"]').each(function () {
        var txtVendorAdjustmentAmount = $(this);
        totalVendorAdjustmentAmount = totalVendorAdjustmentAmount + parseFloat(txtVendorAdjustmentAmount.val());
    });
    $('#txtTotalVendorAdjustmentAmount').val(totalVendorAdjustmentAmount);
}

function ValidStep3() {
    if (parseFloat($('#txtTotalCustomerAdjustmentAmount').val()) != parseFloat($('#txtTotalVendorAdjustmentAmount').val())) {
        ShowMessage('Customer Adjustment Amount must be equal to Vendor Adjustment Amount');
        isStepValid = false;
        return false;
    }
}
