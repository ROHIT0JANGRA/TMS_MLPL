
    var  drOrderDate,baseUrl;
$(document).ready(function () {
    SetPageLoad('Pick', 'Insert', 'txtPickDateTime', '', '');

    drOrderDate = InitDateRange('drOrderDate', DateRange.LastWeek);

    InitWizard('dvWizard',[
     {StepIndex:1,StepName:'Criteria',StepFunction:GetOrderListForPick},
     {StepIndex:2,StepName:'Order List',StepFunction:ValidateStep2},
     {StepIndex:3,StepName:'Generate Pick'}
    ],'Generate Pick');
});


    var dtOrderList;
var ValidateStep2=function(){
    if(selectedOrderId==0){
        isStepValid=false;
        ShowMessage('Please select Order');
        return false;
    }
    $('#hdnOrderId').val(selectedOrderId);
    GetOrderDetails();
};
var orderList = [];
var selectedOrderId;
function GetOrderListForPick(){
    var requestData = { companyId: companyId, warehouseId: warehouseId, fromDate : drOrderDate.startDate, toDate : drOrderDate.endDate,
        invoiceNo : $('#txtInvoiceNo').val(), orderNo : $('#txtOrderNo').val()};

    AjaxRequestWithPostAndJson(baseUrl + '/GetOrderListForPick', JSON.stringify(requestData), function (result) {

        if (dtOrderList == null)
            dtOrderList = LoadDataTable('dtOrderList', false, false, false, null, null, [],
              [
                  { title: 'Order No', data: 'Order' },
                  { title: 'Order Date', data: 'OrderDate' },
                  { title: 'Invoice No', data: 'InvoiceNo' },
                  { title: 'Invoice Date', data: 'InvoiceDate' }
              ]);

        dtOrderList.fnClearTable();

        if (result.length == 0) {
            isStepValid=false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.Order =  '<div class="clearfix">'+
                                '<label class="radio">'+
                                    '<input type="radio" name=\'Order\' value=\'' + item.OrderId + '\' onclick="SelectDocument(this.id);SetOrderDetail()" tabindex="0" id="chkOrderNo' + i + '"/><i></i>' +
                                      '<label for="chkOrderNo' + i + '">' + item.OrderNo + '</label>' +
                                       '<input type=\'hidden\' id=\'hdnOrderId' + i + '\' value=\'' + item.OrderId + '\' />' +
                                '</label>' +
                            '</div>';
              
                item.OrderDate = $.displayDate(item.OrderDate);
                item.InvoiceDate =$.displayDate(item.InvoiceDate);
            });
            dtOrderList.dtAddData(result);
            orderList = result;
            selectedOrderId=0;
        }
    }, ErrorFunction, false);
    return false;
}
function SelectDocument(rdId) {
    selectedOrderId = $('#' + rdId).val();
}

function SetOrderDetail() {
    var orderDetails = GetArrayItemByPropery(orderList, 'OrderId', selectedOrderId);
    $('#lblOrderNo').text(orderDetails.OrderNo);
    $('#lblOrderDate').text(orderDetails.OrderDate);
    $('#lblInvoiceNo').text(orderDetails.InvoiceNo);
    $('#lblInvoiceDate').text(orderDetails.InvoiceDate);
}
var dtProductList;
function GetOrderDetails(){
    var requestData = { companyId: companyId, warehouseId: warehouseId, id: selectedOrderId };
    AjaxRequestWithPostAndJson(baseUrl + '/GetOrderDetails', JSON.stringify(requestData), function (result) {

        if (dtProductList == null)
            dtProductList = LoadDataTable('dtProductList', false, false, false, null, null, [],
              [
                  { title: 'Sku Code', data: 'SkuCode' },
                  { title: 'Sku Name', data: 'SkuName' },
                  { title: 'UOM', data: 'Uom' },
                  { title: 'Order Quantity', data: 'Quantity' },
                  { title: 'Pick Quantity', data: 'PickQuantity' }
              ]);

        dtProductList.fnClearTable();

        $.each(result, function (i, item) {
            item.SkuCode = '<span>' + item.SkuCode + '</span>' +
                                '<input type=\'hidden\' name="PickDetails[' + i + '].SkuCode" id="hdnSkuCode' + i + '" value=' + item.SkuCode + ' />' +
                                '<input type=\'hidden\' name="PickDetails[' + i + '].SkuId" id="hdnSkuId' + i + '" value=' + item.SkuId + ' />';
            item.Quantity = '<span>' + item.Quantity + '</span>' +
                                '<input type=\'hidden\' name="PickDetails[' + i + '].Quantity" id="hdnQuantity' + i + '" value=' + item.Quantity + ' />';
            item.PickQuantity = '<input type="text" class="form-control numeric3" data-val="true" data-val-required="Please enter Quantity" name="PickDetails[' + i + '].PickQuantity" id="txtPickQuantity' + i + '" value=\'0\'  data-val-range="Please enter Quantity greater than zero" data-val-range-max="999999999" data-val-range-min="0.001"/>' +
                                  '<span data-valmsg-for="PickDetails[' + i + '].PickQuantity" data-valmsg-replace="true"></span>';

        });
        dtProductList.dtAddData(result);
            
    }, ErrorFunction, false);
    return false;
}