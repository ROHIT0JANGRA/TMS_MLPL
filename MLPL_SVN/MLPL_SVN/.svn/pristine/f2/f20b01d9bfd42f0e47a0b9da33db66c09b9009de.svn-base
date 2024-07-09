
var drPickDate;
$(document).ready(function () {
    SetPageLoad('Pick', 'Update', 'txtPickDateTime', '', '');
    drPickDate = InitDateRange('drPickDate', DateRange.LastWeek);

    InitWizard('dvWizard', [
     { StepIndex: 1, StepName: 'Criteria', StepFunction: GetPickListForUpdate },
     { StepIndex: 2, StepName: 'Pick List', StepFunction: ValidateStep2 },
     { StepIndex: 3, StepName: 'Update Pick' }
    ], 'Update Pick');
});

var selectedPickId = 0;
var ValidateStep2 = function () {
    if (selectedPickId == 0) {
        isStepValid = false;
        ShowMessage('Please select Pick');
        return false;
    }
    $('#hdnPickId').val(selectedPickId);
    GetPickDetails();

};

var dtPickList;
function GetPickListForUpdate() {
    var requestData = {
        companyId: companyId, warehouseId: warehouseId, fromDate: drPickDate.startDate, toDate: drPickDate.endDate,
        pickNo: $('#txtPickNo').val(), invoiceNo: $('#txtInvoiceNo').val(), orderNo: $('#txtOrderNo').val()
    };

    AjaxRequestWithPostAndJson(baseUrl + '/GetPickListForUpdate', JSON.stringify(requestData), function (result) {

        if (dtPickList == null)
            dtPickList = LoadDataTable('dtPickList', false, false, false, null, null, [],
              [
                  { title: 'Pick No', data: 'Pick' },
                  { title: 'Pick Date', data: 'PickDate' }
              ]);

        dtPickList.fnClearTable();
        isStepValid = result.length > 0;
        if (result.length == 0) {
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.Pick = '<div class="clearfix">' +
           '<label class="radio">' +
           '<input type="radio" name=\'Document\' value=\'' + item.PickId + '\' onclick="SetPickDetail(this);" tabindex="0" id="rdPickNo' + i + '"/><i></i>' +
           '<label for="rdPickNo' + i + '">' + item.PickNo + '</label>' +
           "<input type='hidden' value='" + item.PickNo + "' id='hdnPickNo" + i + "'/>" +
           '</label>' +
           '</div>';
                item.PickDate = $.displayDate(item.PickDate);
            });
            dtPickList.dtAddData(result);
            selectedPickId = 0;
        }
    }, ErrorFunction, false);
    return false;
}


function SetPickDetail(rd) {
    selectedPickId = rd.value;
    $('#txtPickNumber').val($('#' + rd.Id.replace('rdPickNo', 'hdnPickNo')).val());
}

var dtPickDetail;
function GetPickDetails() {
    //divStep2.find("div,input,select,textarea,button").prop("disabled", true);
    //btnStep2.hide();
    //divStep3.show();
    //btnStep3.show();
    var requestData = { companyId: companyId, warehouseId: warehouseId, id: selectedPickId };
    AjaxRequestWithPostAndJson(baseUrl + '/GetPickDetails', JSON.stringify(requestData), function (result) {

        if (dtPickDetail == null)
            dtPickDetail = LoadDataTable('dtPickDetail', false, false, false, null, null, [],
              [
                  { title: 'Order No', data: 'OrderId' },
                  { title: 'SKU Code', data: 'SkuCode' },
                  { title: 'SKU Name', data: 'SkuName' },
                  { title: 'Order Quantity', data: 'OrderQuantity' },
                  { title: 'Batch Number', data: 'BatchNumber' },
                  { title: 'Lot Date', data: 'ManufactureDate' },
                  { title: 'Expiry Date', data: 'ExpiryDate' },
                  { title: 'Self Life', data: 'SelfLife' },
                  { title: 'Pending Quantity', data: 'PendingQuantity' },
                  { title: 'Suggested Location', data: 'SuggestedLocations' },
                  { title: 'Detail', data: 'LocationDetail' },
                  { title: 'Total Pick Quantity', data: 'TotalQuantity' }
              ]);

        dtPickDetail.fnClearTable();

        $.each(result, function (i, item) {
           $('#txtOrderId').val(item.OrderId);
            item.OrderId = "<input type='hidden' value='" + item.OrderId + "' name='PickDetails[" + i + "].OrderId' id='hdnOrderId" + i + "'/>" +
                         "<input type='hidden' value='" + item.SkuId + "' name='PickDetails[" + i + "].SkuId' id='hdnSkuId" + i + "'/>" +
                         "<input type='hidden' value='" + item.OrderQuantity + "' name='PickDetails[" + i + "].OrderQuantity' id='hdnOrderQuantity" + i + "'/>" +
                         "<input type='hidden' value='" + item.PendingQuantity + "' name='PickDetails[" + i + "].PendingQuantity' id='hdnPendingQuantity" + i + "'/>" +
                         "<span>" + item.OrderNo + "</span>";
            item.TotalQuantity = '<input type="text" name="PickDetails[' + i + '].TotalQuantity" id="txtTotalQuantity' + i + '" value = 0.000 class="textlabel" disabled/>';

            item.ManufactureDate = item.ManufactureDate == null ? '' : $.displayDate(item.ManufactureDate);
            item.ExpiryDate = item.ExpiryDate == null ? '' : $.displayDate(item.ExpiryDate);
            item.LocationDetail = '<table id="dtlPickBin' + i + '" class="innerTable" style="width: 300px !important;">' +
                   '<thead class="display-none"><th>Bin Code' +
                    "<input type='hidden' value='" + item.SkuId + "' name='PickDetails[" + i + "].SkuId' id='hdnSkuId_dtPickBin" + i + "'_0'/>" +
                    '</th><th>Quantity</th><th></th><th></th></thead>' +
                    '<tbody>' +
                        '<tr class="innerRow">' +
                            '<td>' +
                                '<input type="text" placeholder="Bin Code" name="PickDetails[' + i + '].PickBin[0].BinCode" id="txtBinCode_dtPickBin' + i + '_0" class="form-control form-control-grid"/>' +
                              '<span data-valmsg-for="PickDetails[' + i + '].PickBin[0].BinCode" data-valmsg-replace="true"></span>' +
                                '<input type="hidden" name="PickDetails[' + i + '].PickBin[0].BinId" id="hdnBinId_dtPickBin' + i + '_0" class="form-control" />' +
                            '</td>' +
                            '<td>' +
                                '<input type="text" name="PickDetails[' + i + '].PickBin[0].Quantity" id="txtQuantity_dtPickBin' + i + '_0" class="form-control numeric3 form-control-grid"/>' +
                                '<input type="hidden" name="PickDetails[' + i + '].PickBin[0].Quantity" id="hdnQuantity_dtPickBin' + i + '_0" class="form-control" />' +
                                '<span data-valmsg-for="PickDetails[' + i + '].PickBin[0].Quantity" data-valmsg-replace="true"></span>' +
                            '</td>' +
                            '<td width="70px"></td>' +
                            '</tr></tbody>' +
                '</table>'
                +
             '<span data-valmsg-for="PickDetails[' + i + '].TotalQuantity" data-valmsg-replace="true"></span>';

        });
        dtPickDetail.dtAddData(result);

        dtPickDetail.find('[id*="txtTotalQuantity"]').each(function () {
            var hdnPendingQuantity = $('#' + this.id.replace('txtTotalQuantity', 'hdnPendingQuantity'));
            var txtTotalQuantity = $('#' + this.id.replace('txtTotalQuantity', 'txtTotalQuantity'));
            var orderQuantity = parseFloat(hdnPendingQuantity.val());
            AddRange(txtTotalQuantity, 'Total Quantity must be ' + orderQuantity.toFixed(3), orderQuantity, orderQuantity)
        });


        $('[id*="dtlPickBin"]').each(function () {
            var tblId = $(this).Id;
            InitGrid(tblId, false, 2, InitBinTable);
        });

    }, ErrorFunction, false);
    return false;
}

function ValidateTotalQuantity(txtQuantity) {
    var tbl = $(txtQuantity).closest('table');
    var txtTotalQuantity = tbl.closest('tr').find('[id *= "txtTotalQuantity"]');
    var hdnPendingQuantity = tbl.closest('tr').find('[id *= "hdnPendingQuantity"]');
    var totalQuantity = 0;
    $('#' + tbl.Id).find('[id*="txtQuantity"]').each(function () {
        totalQuantity += $(this).round(3);
    });
    if (totalQuantity > hdnPendingQuantity.val()) {
        AddRange(txtQuantity, 'Please enter Quantity less than or equal to ' + hdnPendingQuantity.val(), 1, hdnPendingQuantity.toFloat());
        txtQuantity.val(0);
    }
    totalQuantity = 0;
    $('#' + tbl.Id).find('[id*="txtQuantity"]').each(function () {
        totalQuantity += $(this).round(3);
    });
    txtTotalQuantity.val(totalQuantity.toFixed(3));
}

function InitBinTable(tblId) {
    $('#' + tblId).find('[id*="txtBinCode"]').each(function () {
        var txtBinCode = $(this);
        var hdnBinId = $('#' + this.id.replace('txtBinCode', 'hdnBinId'));
        var hdnQuantity = $('#' + this.id.replace('txtBinCode', 'hdnQuantity'));
        var txtQuantity = $('#' + this.id.replace('txtBinCode', 'txtQuantity'));
        var hdnSkuId = $('#' + (this.id.split("_").slice(0, 2).join("_")).replace('txtBinCode', 'hdnSkuId'));

        txtBinCode.blur(function () {
            //if (!CheckDuplicateInTable($(this).closest('table').Id, 'txtBinCode', 'Bin Code', txtBinCode)) return false;
            if (txtBinCode.val() != "") {
                IsBinCodeExist(txtBinCode, hdnBinId);
                var requestData = { skuId: hdnSkuId.val(), binId: hdnBinId.val() };
                AjaxRequestWithPostAndJson(ReplaceUrl('Bins', 'IsBinNameAvailableBySku'), JSON.stringify(requestData), function (responseData) {
                    if (IsObjectNullOrEmpty(responseData)) {
                        ShowMessage("Invalid Bin For This Sku");
                        hdnBinId.val(0);
                        txtBinCode.val("");
                    }
                    else {
                        hdnBinId.val(responseData[0].BindId);
                        txtBinCode.val(responseData[0].BinCode);
                        hdnQuantity.val(responseData[0].AvailableQuantity);
                        if (!CheckDuplicateInTable(txtBinCode.closest('table').Id, 'txtBinCode', 'Bin Code', txtBinCode)) return false;
                    }
                }, ErrorFunction, false);
            }

        });
        BinAutoComplete(txtBinCode.Id, hdnBinId.Id);
        AddRequired(txtBinCode, 'Please enter Bin Code');

        var tbl = txtQuantity.closest('table');
        var hdnPendingQuantity = tbl.closest('tr').find('[id *= "hdnPendingQuantity"]');
        RemoveRange(txtQuantity);
        AddRange(txtQuantity, 'Please enter Quantity less than or equal to ' + hdnPendingQuantity.val(), 1, hdnPendingQuantity.toFloat());

        txtQuantity.blur(function () {
            if (parseFloat(hdnQuantity.val()) < parseFloat(txtQuantity.val()))
                ShowMessage("Invalid Quantity For This Bin");
            ValidateTotalQuantity($(this))
        });
    });
}
