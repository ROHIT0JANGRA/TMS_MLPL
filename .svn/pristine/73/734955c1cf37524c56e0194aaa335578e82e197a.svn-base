var hdnVehicleId, txtVehicleNo, hdnJobOrderId, txtJobOrderNo, hdnSpareRequestId, txtSpareRequestNo, dtDetail;
var baseUrl;

$(document).ready(function () {
    SetPageLoad('Tracking', 'Document Tracking', '', '', '');
    InitObjects();
});

function InitObjects() {
    hdnVehicleId = $('#hdnVehicleId');
    txtVehicleNo = $('#txtVehicleNo');
    hdnJobOrderId = $('#hdnJobOrderId');
    txtJobOrderNo = $('#txtJobOrderNo');
    hdnSpareRequestId = $('#hdnSpareRequestId');
    txtSpareRequestNo = $('#txtSpareRequestNo');

    InitWizard('dvWizard', [
     { StepName: 'Issue Slip Detail', StepFunction: GetSpareRequestDetail },
     { StepName: 'SpareRequest Detail' }
    ], 'Generate');
}

function GetSpareRequestDetail() {
    var requestData = { vehicleNo: txtVehicleNo.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetSpareRequestDetailForIssueSlipGenerate', JSON.stringify(requestData), function (result) {

        if (dtDetail == null)
            dtDetail = LoadDataTable('dtDetail', false, false, false, null, null, [],
                  [
                      { title: 'Item', data: 'SkuName' },
                      { title: 'Description', data: 'Description' },
                      { title: 'Quantity In Stock', data: 'StockQuantity' },
                      { title: 'Required Quantity', data: 'SupplierName' },
                      { title: 'Issued Quantity', data: 'View' },
                      { title: 'Unit Price', data: 'View' },
                      { title: 'Total Amount', data: 'View' }
                  ]);

        dtDetail.fnClearTable();

        $.each(result, function (i, item) {
            item.SkuName = "<input type='hidden' value='" + item.SkuId + "' id='hdnSkuId" + i + "'/>" + item.SkuName;
            item.Description = '<input class="form-control" name="Details[' + i + '].Description" id="txtDescription' + i + '" type="text"/>';
            item.StockQuantity = '<input class="form-control textlabel numeric"  id="txtStockQuantity' + i + '" type="text"  value=\'' + item.StockQuantity + '\'/>';
            item.RequiredQuantity = '<input class="form-control textlabel numeric"  id="txtRequiredQuantity' + i + '" type="text"  value=\'' + item.RequiredQuantity + '\'/>';
            item.IssuedQuantity = '<input class="form-control numeric"  id="txtIssuedQuantity' + i + '" type="text"/>';
            item.UnitPrice = '<input class="form-control textlabel numeric2"  id="txtUnitPrice' + i + '" type="text" />';
            item.TotalAmount = '<input class="form-control textlabel numeric2"  id="txtTotalAmount' + i + '" type="text" />';
        });
        dtDetail.dtAddData(result);

    }, ErrorFunction, false);
}
