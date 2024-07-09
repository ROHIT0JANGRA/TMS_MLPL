var MntncLst = [];
$(document).ready(function () {


    dtDetails1 = $('#dtDetails1');
   

});


function GetVehicleMaintananceHistory(obj) {
   
    
    if (obj != '') {


        var requestData = { VehicleNo: obj };

        AjaxRequestWithPostAndJson(baseUrl + '/GetMetnatancList', JSON.stringify(requestData), function (result) {

            MntncLst = result.MntncLst;

            GetVehMaintencDtl(MntncLst, dtDetails1)

        }, ErrorFunction, false);
        return false;


    }
}
function GetVehMaintencDtl(list, dtDetails1) {

    if ($.fn.DataTable.isDataTable('#dtDetails1')) {
        $('#dtDetails1').DataTable().destroy();
    }
    $('#dtDetails1 tbody').empty();

    // $('#dtDetails1').addClass('dataTable');
    //dtDetails1.fnClearTable();


    dtDetails1 = LoadDataTable('dtDetails1', false, false, false, null, null, [],
        [

            { title: 'Status', data: 'StatusNm', width: 30 },
            { title: 'Date', data: 'CurrDate', width: 30 },
            { title: 'Expctd Date', data: 'ExpectdDate', width: 30 },
            { title: 'Remarks', data: 'Remarks', width: 30 },
            { title: 'Spare Parts', data: 'SpareParts', width: 30 },
            { title: 'Expense Amount', data: 'ExpenseAmount', width: 30 },
            { title: 'View Document', data: 'DocumentName', width: 30 },


        ]);


    if (list.length > 0) {
        $.each(list, function (i, item) {


            item.StatusNm = '<label class=\'align-right\' style=\'width:100%\' id="lblVehicleStatus' + i + '">' + item.StatusNm + '</label>';
            item.CurrDate = '<label class=\'align-right\' style=\'width:100%\' id="lblCurrDate' + i + '">' + $.entryDate(item.CurrDate) + '</label>';
            item.ExpectdDate = '<label class=\'align-right\' style=\'width:100%\' id="lblExpectdDate' + i + '">' + $.entryDate(item.ExpectdDate) + '</label>';
            item.Remarks = '<label class=\'align-right\' style=\'width:100%\' id="lblRemarks' + i + '">' + item.Remarks + '</label>';
            item.SpareParts = '<label class=\'align-right\' style=\'width:100%\' id="lblSpareParts' + i + '">' + item.SpareParts + '</label>';
            item.ExpenseAmount = '<label class=\'align-right\' style=\'width:100%\' id="lblExpenseAmount' + i + '">' + item.ExpenseAmount + '</label>';
            item.DocumentName = item.DocumentName == null ? '' : '<a href="#" onclick="return ViewAttachment(\'hdnDocumentName' + i + '\');" class="btckn btn-default btn-sm">' +
                                '<span class="fa fa-download"></span>' +
                            '</a>' +
                    "<input type='hidden' value='" + item.DocumentName + "' id='hdnDocumentName" + i + "'/>";
        });
        dtDetails1.dtAddData(list);
        //$('#dtDetails1').DataTable();
    }
}


function ViewAttachment(obj) {
    var hdnDocumentName = $('#' + obj);

    var filePath = '';
    filePath = currentDomain + 'Storage/VehicleMaintenance/';
    window.open(filePath + hdnDocumentName.val(), "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=100,left=500,width=400,height=300");
    return false;
}