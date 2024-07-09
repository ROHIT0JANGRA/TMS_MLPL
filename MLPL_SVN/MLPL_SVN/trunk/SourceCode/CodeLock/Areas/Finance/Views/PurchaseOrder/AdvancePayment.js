var drPoDate, hdnVendorId, txtVendorCode, txtPoNo, txtManualPoNo, dtPoList, selectedPoId, dtGrnDetail, lblName;
var vendorMasterUrl, baseUrl, purchaseOrderModuleId;

$(document).ready(function () {
    InitObjects();
    AttachEvents();
    SetPageLoad('Purchase Order', 'Advance Payment', '', '', '');
});

function InitObjects() {
    hdnVendorId = $('#hdnVendorId');
    txtVendorCode = $('#txtVendorCode');
    lblName = $('#lblName');
    txtPoNo = $('#txtPoNo');
    txtManualPoNo = $('#txtManualPoNo');
    drPoDate = InitDateRange('drPoDate', DateRange.LastWeek);

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetPurchaseOrderList },
     { StepName: 'Purchase Order List', StepFunction: GetPurchaseOrderDetail },
     { StepName: 'Purchase Order Advance Payment' }
    ], 'Generate');
}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { return IsVendorCodeExist(txtVendorCode, hdnVendorId, lblName); });
    $('#dvTdsDetails').hide();
}


function GetPurchaseOrderList() {
    if (hdnVendorId.val() == '')
        hdnVendorId.val(0);
    var requestData = {
        fromDate: drPoDate.startDate,
        toDate: drPoDate.endDate,
        vendorId: hdnVendorId.val(),
        poNo: txtPoNo.val(),
        manualPoNo: txtManualPoNo.val(),
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetPurchaseOrderListForAdvancePayment', JSON.stringify(requestData), function (result) {

        selectedPoList = [];

        if (dtPoList == null)
            dtPoList = LoadDataTable('dtPoList', false, false, false, null, null, [],
              [
                  { title: 'PO No', data: 'PoNo' },
                  { title: 'PO Date', data: 'PoDate' },
                  { title: 'Vendor', data: 'VendorCode' },
                  { title: 'Manual PO No', data: 'ManualPoNo' },
                  { title: 'Material Category', data: 'MaterialCategory' },
                  { title: 'Total Net Amount', data: 'Amount' },
                  { title: 'Advance Amount', data: 'AdvanceAmount' },
                  { title: 'View', data: 'View' }
              ]);

        dtPoList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                //item.PoNo = '<div class="clearfix">' +
                //               '<div class="radioer">' +
                //                   '<input type="radio" name=\'Po\' value=\'' + item.PoId + '\' onclick="GetPoDetail(this)" tabindex="0" id="chkPoNo' + i + '"/>' +
                //                     '<label for="chkPoNo' + i + '">' + item.PoNo + '</label>' +
                //               '</div>' +
                //           '</div>';
                item.PoNo = '<div class="clearfix">' +
            '<label class="radio">' +
            '<input type="radio" name=\'PurchaseOrder\' value=\'' + item.PoId + '\' onclick="GetPoDetail(this);" tabindex="0" id="rdPoNo' + i + '"/><i></i>' +
            '<label for="rdPoNo' + i + '">' + item.PoNo + '</label>' +
            '<input type=\'hidden\' id=\'hdnPoDate' + i + '\' value=\'' + $.displayDate(item.PoDate) + '\' />' +
            '</label>' +
            '</div>';
                item.View = '<button id = "btnPrint' + i + '" onclick="return ViewReport(' + item.PoId + ')" class="btn btn-primary btn-xs dt-edit">' +
               '<span class="glyphicon glyphicon-print"></span>' +
                '</button>';
                item.PoDate = $.displayDate(item.PoDate);
                item.Amount = '<input type="text" value=' + item.Amount.toFixed(2) + ' class="textlabel" style="text-align: right" disabled/>';
                item.AdvanceAmount = '<input type="text" value=' + item.AdvanceAmount.toFixed(2) + ' class="textlabel" style="text-align: right" disabled/>';
            });
            dtPoList.dtAddData(result);
            selectedPoId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

function ViewReport(value) {
    return ShowViewPrint(purchaseOrderModuleId, value);
}

function GetPoDetail(rd) {
    selectedPoId = rd.value;
}

function GetPurchaseOrderDetail() {
    isStepValid = selectedPoId != 0;
    if (selectedPoId == 0) {
        ShowMessage('Please select Purchase Order');
        return false;
    }
    $('#hdnPoId').val(selectedPoId);
    var requestData = { poId: selectedPoId };
    AjaxRequestWithPostAndJson(baseUrl + '/GetDetailById', JSON.stringify(requestData), function (result) {
        $('#lblPoNo').text(result.PoNo);
        $('#lblVendor').text(result.VendorCode + ' : ' + result.VendorName);
        $('#hdnVendorCode').val(result.VendorCode);
        $('#hdnVendorName').val(result.VendorName);
        $('#txtPoAmount').val(result.Amount);
        $('#txtAdvanceAmount').val(result.AdvanceAmount);
        $('#txtBalanceAmount').val(result.BalanceAmount);
        $('#txtPaymentAmountApplicable').val(result.AdvanceAmount);
        SetPaymentPartyTypeAndParty(3, hdnVendorId.val());
    }, ErrorFunction, false);
    return false;
}
