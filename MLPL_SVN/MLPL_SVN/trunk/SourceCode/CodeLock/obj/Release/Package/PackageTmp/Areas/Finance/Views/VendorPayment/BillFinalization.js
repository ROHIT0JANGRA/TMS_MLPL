var ddlLocationId, txtVendorCode, hdnVendorId, txtBillNo, lblVendorName, dtBillList, drTransactionDate, vendorMasterUrl, selectedDocumentList, vendorPaymentUrl;

$(document).ready(function () {
    SetPageLoad('Vendor', 'Bill Finalization', 'txtVendorName', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtVendorCode = $('#txtVendorCode');
    lblVendorName = $('#lblVendorName');
    hdnVendorId = $('#hdnVendorId');
    txtBillNo = $('#txtBillNo');
    ddlLocationId = $('#ddlLocationId');
    dtBillList = $('#dtBillList');
    drTransactionDate = InitDateRange('drTransactionDate', DateRange.LastWeek);

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetDocumentListForFinalization },
     { StepName: 'Document List', StepFunction: ValidStep2 }
    ], 'Bill Finalize');
}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { return IsVendorCodeExist(txtVendorCode, hdnVendorId, lblVendorName); });
}

function CheckValidVendorCode(txtVendorCode, hdnVendorId) {
    if (txtVendorCode.val() != "") {
        var requestData = { vendorName: txtVendorCode.val() };
        AjaxRequestWithPostAndJson(vendorMasterUrl + '/IsVendorCodeExist', JSON.stringify(requestData), function (result) {
            if (result.Value > 0) {
                txtVendorCode.val(result.Name);
                hdnVendorId.val(result.Value);
                txtVendorCode.val(result.Name + ' : ' + result.Description);
            }
            else {
                ShowMessage('Vendor is not exist');
                txtVendorCode.val('');
                hdnVendorId.val('');
                txtVendorCode.focus();
            }
        }, ErrorFunction, false);
    }
    return false;
}

function GetDocumentListForFinalization() {
    var locationId = ddlLocationId.val();
    var vendorId = hdnVendorId.val() == '' ? 0 : hdnVendorId.val();
    var billNo = txtBillNo.val();

    var requestData = { locationId: locationId, vendorId: vendorId, fromDate: drTransactionDate.startDate, toDate: drTransactionDate.endDate, billNo: billNo };

    AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetBillListForBillFinalization', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedDocumentList = [];
            dtBillList = LoadDataTable('dtBillList', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllBill', SelectBill), data: "BillId" },
                  { title: 'Bill No', data: 'BillNo' },
                  { title: 'Vendor Bill Date', data: 'BillDate' },
                  { title: 'Vendor', data: 'VendorName' },
                  { title: 'Total Amount', data: 'GrandTotal' },
                  { title: 'Branch Code', data: 'BranchCode' },
                  { title: 'Bill Type', data: 'BillType' }
              ]);

            dtBillList.fnClearTable();
            $.each(result, function (i, item) {
                item.BillId = "<div class='checkboxer'>" +
                                    SelectAll.GetChk('chkAllBill', 'chkBillId' + i, 'BillDetail[' + i + '].IsChecked', SelectBill) +
                                    "<input type='hidden' value='" + item.BillId + "' name='BillDetail[" + i + "].BillId' id='hdnBillId" + i + "'/>" +
                                    "<label class='label' for='chkBillId" + i + "' id='lblBillId" + i + "'></label>" +
                                    "</div>";
                item.BillDate = $.displayDate(item.BillDate);
            });
            dtBillList.dtAddData(result);
        }
    }, ErrorFunction, false);
    return false;
}

function SelectBill() {
    selectedDocumentList = [];
    $('[id*="chkBillId"]').each(function () {
        var chkBillId = $(this);
        var txtActualWeight = $('#' + chkBillId.attr('id').replace('chkBillId', 'txtActualWeight'));
        if (chkBillId.IsChecked) {
            selectedDocumentList.push($('#' + chkBillId.Id.replace('chkBillId', 'hdnBillId')).val());
        }
    });
}

function ValidStep2() {
    if (selectedDocumentList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Bill');
        return false;
    }
}