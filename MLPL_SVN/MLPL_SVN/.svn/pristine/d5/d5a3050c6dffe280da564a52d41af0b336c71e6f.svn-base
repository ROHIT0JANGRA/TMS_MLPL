var drPoDate, ddlMaterialCategoryId, hdnVendorId, txtVendorCode, txtPoNo, txtManualPoNo, dtPoList, selectedPoId, dtGrnDetail;
var vendorMasterUrl, baseUrl, purchaseOrderModuleId;

$(document).ready(function () {
    InitObjects();
    AttachEvents();
    SetPageLoad('GRN', 'Generation', 'txtPoNo', '', '');
});

function InitObjects() {
    ddlMaterialCategoryId = $('#ddlMaterialCategoryId');
    hdnVendorId = $('#hdnVendorId');
    txtVendorCode = $('#txtVendorCode');
    txtPoNo = $('#txtPoNo');
    txtManualPoNo = $('#txtManualPoNo');
    lblName = $('#lblName');
    drPoDate = InitDateRange('drPoDate', DateRange.LastWeek);

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetPurchaseOrderList },
     { StepName: 'Purchase Order List', StepFunction: GetPurchaseOrderDetail },
     { StepName: 'Purchase Order Details' }
    ], 'Generate');
}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { return IsVendorCodeExist(txtVendorCode, hdnVendorId, lblName); });
}

function GetPurchaseOrderList() {
    var requestData = {
        fromDate: drPoDate.startDate,
        toDate: drPoDate.endDate,
        materialCategoryId: ddlMaterialCategoryId.val() == '' ? 0 : ddlMaterialCategoryId.val(),
        vendorId: hdnVendorId.val() == '' ? 0 : hdnVendorId.val(),
        poNo: txtPoNo.val(),
        manualPoNo: txtManualPoNo.val(),
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetPurchaseOrderListForGrnInsert', JSON.stringify(requestData), function (result) {

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
        $('#lblPoDate').text($.displayDate(result.PoDate));
        $('#lblVendor').text(result.VendorCode + ' : ' + result.VendorName);
        $('#lblMaterialCategory').text(result.MaterialCategory);

        if (dtGrnDetail == null)
            dtGrnDetail = LoadDataTable('dtGrnDetail', false, false, false, null, null, [],
              [
                  { title: 'Item Name', data: 'SkuName' },
                  { title: 'Quantity', data: 'Quantity' },
                  { title: 'Rate', data: 'Rate' },
                  { title: 'Received Quantity(Till)', data: 'ReceivedQuantity' },
                  { title: 'Received Quantity', data: 'ReceiveQuantity' },
                  { title: 'Pending Quantity', data: 'PendingQuantity' }
              ]);

        dtGrnDetail.fnClearTable();

        $.each(result.Details, function (i, item) {
            item.SkuName = "<input type='hidden' value='" + item.PoId + "' name='Details[" + i + "].PoId' id='hdnPoId" + i + "'/>" +
                           "<input type='hidden' value='" + item.SkuId + "' name='Details[" + i + "].SkuId' id='hdnSkuId" + i + "'/>" + item.SkuName;
            item.Quantity = '<input type="text" name="Details[' + i + '].Quantity" value=' + item.Quantity + ' id="txtQuantity' + i + '" class="textlabel" style="text-align: right" >';
            item.Rate = '<input type="text" name="Details[' + i + '].Rate" value=' + item.Rate.toFixed(2) + ' id="txtRate' + i + '" class="textlabel" style="text-align: right" >';
            item.ReceivedQuantity = '<input type="text" value=' + item.ReceivedQuantity + ' id="txtReceivedQuantity' + i + '" class="textlabel" style="text-align: right" >';
            item.ReceiveQuantity = "<input type='hidden' value='" + item.PendingQuantity + "' id='hdnPendingQuantity" + i + "'/>" +
                                   '<input type="text" name="Details[' + i + '].ReceivedQuantity" value=' + item.PendingQuantity + ' id="txtReceiveQuantity' + i + '" class="form-control numeric">';
            item.PendingQuantity = '<input type="text" name="Details[' + i + '].PendingQuantity" value=0 id="txtPendingQuantity' + i + '" class="textlabel" style="text-align: right">' +
                                    "<input type='hidden' name='Details[" + i + "].TotalAmount' id='hdnTotalAmount" + i + "'/>";
        });
        dtGrnDetail.dtAddData(result.Details);
        Init();

    }, ErrorFunction, false);
    return false;
}

function Init() {
    $('[id*="txtReceiveQuantity"]').each(function () {
        var txtReceiveQuantity = $(this);
        CalculateTotalAmount();
        txtReceiveQuantity.blur(CalculateTotalAmount);
    });
}

function CalculateTotalAmount() {
    var totalAmount = 0;
    $('[id*="txtQuantity"]').each(function () {
        var txtQuantity = $(this);
        var txtReceivedQuantity = $('#' + this.id.replace('txtQuantity', 'txtReceivedQuantity'));
        var txtReceiveQuantity = $('#' + this.id.replace('txtQuantity', 'txtReceiveQuantity'));
        var txtRate = $('#' + this.id.replace('txtQuantity', 'txtRate'));
        var txtPendingQuantity = $('#' + this.id.replace('txtQuantity', 'txtPendingQuantity'));
        var hdnTotalAmount = $('#' + this.id.replace('txtQuantity', 'hdnTotalAmount'));
        var hdnPendingQuantity = $('#' + this.id.replace('txtQuantity', 'hdnPendingQuantity'));
        if (parseFloat(txtReceiveQuantity.val()) > parseFloat(hdnPendingQuantity.val())) {
            ShowMessage('Received Quantity must be leass than ' + hdnPendingQuantity.val());
            txtReceiveQuantity.val(0);
            txtPendingQuantity.val(0);
            hdnTotalAmount.val(0);
            txtReceiveQuantity.focus();
            return false;
        }
        else {
            txtPendingQuantity.val((parseFloat(txtQuantity.val()) - parseFloat(txtReceivedQuantity.val())) - parseInt(txtReceiveQuantity.val()));
            hdnTotalAmount.val(parseFloat(txtRate.val()) * parseFloat(txtReceiveQuantity.val()));
        }
        totalAmount = totalAmount + parseFloat(hdnTotalAmount.val());
    });
    $('#hdnAmount').val(totalAmount);
}
