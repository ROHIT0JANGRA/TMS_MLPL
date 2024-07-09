var  drOrderDate;
$(document).ready(function () {
    SetPageLoad('Dispatch', 'Insert', 'txtDispatchDateTime', '', '');
        
    drOrderDate = InitDateRange('drOrderDate', DateRange.LastWeek);

    InitWizard('dvWizard',[
     {StepIndex:1,StepName:'Criteria',StepFunction:GetOrderListForDispatch},
     {StepIndex:2,StepName:'Order List',StepFunction:ValidateStep2},
     {StepIndex:3,StepName:'Generate Dispatch'}
    ],'Generate Dispatch');
});

    var selectedOrderId;
var ValidateStep2=function(){
    if(selectedOrderId==0){
        isStepValid=false;
        ShowMessage('Please select Order');
        return false;
    }
    $('#hdnOrderId').val(selectedOrderId);
    GetOrderDetails();
};

var orderList=[];
var dtOrderList;
function GetOrderListForDispatch(){
    var requestData = { companyId: companyId, warehouseId: warehouseId, fromDate : drOrderDate.startDate, toDate : drOrderDate.endDate,
        invoiceNo : $('#txtInvoiceNo').val(),orderNo : $('#txtOrderNo').val()};

    AjaxRequestWithPostAndJson(baseUrl +'/GetOrderListForDispatch', JSON.stringify(requestData), function (result) {

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
                                '<label class="radio">' +
                                    '<input type="radio" name=\'Order\' value=\'' + item.OrderId + '\' onclick="SelectDocument(this.id);SetOrderDetail()" tabindex="0" id="rdOrderNo' + i + '"/><i></i>' +
                                      '<label for="rdOrderNo' + i + '">' + item.OrderNo + '</label>' +
                                       '<input type=\'hidden\' id=\'hdnAsnId' + i + '\' value=\'' + item.Id + '\' />' +
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
var dtProductList ;
function GetOrderDetails(){
    var requestData = { companyId: companyId, warehouseId: warehouseId, id : selectedOrderId};
    AjaxRequestWithPostAndJson(baseUrl+'/GetOrderDetails', JSON.stringify(requestData), function (result) {
            
        if (dtProductList == null)
            dtProductList = LoadDataTable('dtProductList', false, false, false, null, null, [],
              [
                  { title: 'Sku Code', data: 'Product' },
                  { title: 'Sku Name', data: 'ProductName' },
                  { title: 'UOM', data: 'Uom' },
                  { title: 'Order Quantity', data: 'Quantity' },
                  { title: 'Delivered Quantity', data: 'DeliveredQuantity' },
                  { title: '', data: 'SerialNumber' }
              ]);

        dtProductList.fnClearTable();

        $.each(result, function (i, item) {
            item.Product=   '<span>'+item.ProductCode+'</span>'+
                                '<input type=\'hidden\' name="Details[' + i + '].ProductCode" id="hdnProductCode'+i+'" value='+item.ProductCode+' />'+
                                '<input type=\'hidden\' name="Details[' + i + '].ProductId" id="hdnProductId'+i+'" value='+item.ProductId+' />'+
                                '<input type=\'hidden\' name="Details[' + i + '].OrderQuantity" id="hdnQuatity' + i + '" value=' + item.Quantity + ' />';
            item.DeliveredQuantity = '<input type="text" class="form-control numeric3" data-val="true" data-val-required="Please enter Quantity" name="Details[' + i + '].Quantity" id="txtQuantity' + i + '" value=\'0\'  data-val-range="Please enter Quantity greater than zero" data-val-range-max="999999999" data-val-range-min="0.001"/>';
            item.SerialNumber = '<input type=\'hidden\' id="hdnIsSingle' + i + '" value=' + item.IsSingle + ' />' +
                                '<input type=\'hidden\' name="Details[' + i + '].FirstSerialNo" id="hdnFirstSerialNo' + i + '" />' +
                                '<input type=\'hidden\' name="Details[' + i + '].SecondSerialNo" id="hdnSecondSerialNo' + i + '" />' +
                                "<button id = 'btnPopUp" + i + "' class='btn btn-primary btn-xs dt-edit'/>" +
                                '<span class="glyphicon glyphicon-search"></span>' +
                                '</button>';
        });
        dtProductList.dtAddData(result); 
        CheckIsSerialNumber();
        ScanSerialNumber();
    }, ErrorFunction, false);
    return false;
}

function SetOrderDetail(){
    var orderDetails= GetArrayItemByPropery(orderList, 'OrderId', selectedOrderId);
    $('#lblOrderNo').text(orderDetails.OrderNo);
    $('#lblOrderDate').text(orderDetails.OrderDate);
    $('#lblInvoiceNo').text(orderDetails.InvoiceNo);
    $('#lblInvoiceDate').text(orderDetails.InvoiceDate);
}

function CheckIsSerialNumber() {
    $('[id*="btnPopUp"]').each(function () {
        var btnPopUp = $(this);
        var hdnIsSingle = $('#' + btnPopUp.attr('id').replace('btnPopUp', 'hdnIsSingle'));
        var txtQuantity = $('#' + btnPopUp.attr('id').replace('btnPopUp', 'txtQuantity'));
        if (hdnIsSingle.val() == "null") 
            btnPopUp.hide();
        else
            btnPopUp.show();
        txtQuantity.attr('readOnly', false);
    });
}

function ScanSerialNumber() {
    $('[id*="btnPopUp"]').click(function () {
        var btnPopUp = $(this);
        var hdnIsSingle = $('#' + btnPopUp.attr('id').replace('btnPopUp', 'hdnIsSingle'));
        var hdnProductId = $('#' + btnPopUp.attr('id').replace('btnPopUp', 'hdnProductId'));
        var grnId = 0;
        var dispatchId = 0;
        var popup;
            
        popup = window.open("../../WMS/Grn/PopUpMenu?productId=" + hdnProductId.val() + "&rowId=" + btnPopUp.Id + "&isSingle=" + hdnIsSingle.val() + "&grnId=" + grnId + "&dispatchId=" + dispatchId, "Popup", "toolbar=yes,scrollbars=yes,resizable=yes,top=500,left=600,width=1300,height=650");
        popup.focus();
        return false;

    });
}
