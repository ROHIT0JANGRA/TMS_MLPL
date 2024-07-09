$(document).ready(function () {
    SetPageLoad('Pick', 'Register', '');
    PickDateRange = InitDateRange('drPickDate', DateRange.LastWeek);
    txtPickNo = $('#txtPickNo');
    btnSubmit = $('#btnSubmit');
    btnSubmit.click(OnSubmit);
});

function OnSubmit() {
    var FromDate = moment(PickDateRange.startDate).format("YYYY-MM-DD");
    var ToDate = moment(PickDateRange.endDate).format("YYYY-MM-DD");

    var requestData = { pickNo: txtPickNo.val(), fromDate: FromDate, toDate: ToDate };
    AjaxRequestWithPostAndJson(baseUrl+'/GetRegisterPickDetail', JSON.stringify(requestData), OnPickDetailsSuccess, ErrorFunction, false);
    return false;
}

function OnPickDetailsSuccess(responseData) {
    $('#divCriteria').hide();
    dtPickDetail = LoadDataTable('dtPickDetail', true, true, true, null, null, [],
        [
            { title: 'Pick No', data: "PickNo" },
            { title: 'Pick Date Time', data: "PickDateTime" },
            { title: 'Labor', data: "LaborName" },
            { title: 'Order No', data: "OrderNo" },
            { title: 'Product', data: "ProductCode" },
            { title: 'Quantity', data: "Quantity" },
            { title: 'Location', data: "BinName" },
            { title: 'Location Quantity', data: "LocationQuantity" }
        ]);
    dtPickDetail.fnClearTable()
    if (responseData.length > 0) {
        $.each(responseData, function (i, item) {
            item.PickDateTime = $.displayDateTime(item.PickDateTime);
            if (item.LocationQuantity == 0)
                item.LocationQuantity = '';
            else
                item.LocationQuantity = '<input type="text" value=' + item.LocationQuantity.toFixed(3) + ' class="textlabel" style="text-align: right" disabled/>';
            item.Quantity = '<input type="text" value=' + item.Quantity.toFixed(3) + ' class="textlabel" style="text-align: right" disabled/>';
        });
        dtPickDetail.dtAddData(responseData);
    }
}