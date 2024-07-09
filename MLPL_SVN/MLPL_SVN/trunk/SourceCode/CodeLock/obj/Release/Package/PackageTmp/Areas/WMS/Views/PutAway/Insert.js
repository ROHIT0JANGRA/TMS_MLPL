var dtGrnList, dtProduct, selectedGrnList, grnUrl;
$(document).ready(function () {
    SetPageLoad('Put-Away', 'Entry', 'txtGrnDateTime', '', '');

    drGrnDate = InitDateRange('drGrnDate ', DateRange.LastWeek);

    InitWizard('dvWizard', [
     { StepIndex: 1, StepName: 'Criteria', StepFunction: GetGrnListForPutAway },
     { StepIndex: 2, StepName: 'GRN List', StepFunction: GetGrnDetailsForPutAway },
     { StepIndex: 3, StepName: 'Generate Put Away', StepFunction: ValidateOnSubmit }
    ], 'Generate Put Away');

    $('#txtLabourName').blur(function () { return IsLabourNameExist($(this), $('#hdnLabourId')); });
    LabourAutoComplete('txtLabourName', 'hdnLabourId');

    selectedGrnList = [];

    dtGrnList = LoadDataTable('dtGrnList', false, false, false, null, null, [],
             [
                 { title: SelectAll.GetChkAll('chkGrnAll', SelectGrn), data: "GrnId" },
                 { title: 'GRN No', data: 'GrnNo' },
                 { title: 'GRN Date', data: 'GrnDate' },
                 { title: 'GRN Quantities', data: 'TotalQuantity' },
                 { title: 'Supplier Code', data: 'SupplierCode' },
                 { title: 'Supplier Name', data: 'SupplierName' }
             ]);

    dtProduct = LoadDataTable('dtProduct', false, false, false, null, null, [],
             [
                 { title: SelectAll.GetChkAll('chkProductAll'), data: "SkuId" },
                 { title: 'GRN No', data: 'GrnNo' },
                 { title: 'Sku Code', data: 'SkuCode' },
                 { title: 'Sku Name', data: 'SkuName' },
                 { title: 'Quantity', data: 'Quantity' },
             ]);
});

function SelectGrn() {
    selectedGrnList = [];
    $('[id*="chkGrn"]').each(function () {
        var chkGrn = $(this);
        if (chkGrn.IsChecked)
            selectedGrnList.push($('#' + chkGrn.Id.replace('chkGrn', 'hdnGrnId')).val());
    });
    $('#hdnGrnCount').val(selectedGrnList.length);
}

function GetGrnListForPutAway() {
    var requestData = { CompanyId: companyId, WarehouseId: warehouseId, FromDate: drGrnDate.startDate, ToDate: drGrnDate.endDate, GrnNo: $('#txtGrnNo').val() };
    AjaxRequestWithPostAndJson(grnUrl + '/GetGrnListForPutAway', JSON.stringify(requestData), function (responseData) {
        dtGrnList.fnClearTable();
        if (responseData.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            isStepValid = true;
            $.each(responseData, function (i, item) {
                item.GrnId = "<div class='checkboxer'>" +
                                SelectAll.GetChk('chkGrnAll', 'chkGrn' + i, 'PutAwayGrnCriteriaDetails[' + i + '].IsChecked', SelectGrn) +
                            "<input type='hidden' value='" + item.GrnId + "' name='PutAwayGrnCriteriaDetails[" + i + "].GrnId' id='hdnGrnId" + i + "'/>" +
                            "<label class='control-label' for='chkGrn" + i + "' id='lblGrnId" + i + "'></label>" +
                            "</div>";
                item.GrnDate = $.displayDate(item.GrnDate);
                item.TotalQuantity = "<label class='numeric3' name='PutAwayGrnCriteriaDetails[" + i + "].TotalQuantity' style='text-align: right' id='lblTotalQuantity" + i + "'>" + item.TotalQuantity.toFixed(3) + "</label>"
            });
            dtGrnList.dtAddData(responseData);
        }
    }, ErrorFunction, false);
    return false;
}

function GetGrnDetailsForPutAway() {
    if (selectedGrnList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select GRN');
        return false;
    }
    AjaxRequestWithPostAndJson(grnUrl + '/GetGrnDetailsForPutAway', JSON.stringify(selectedGrnList), function (responseData) {
        dtProduct.fnClearTable();
        if (responseData.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            isStepValid = true;
            $.each(responseData, function (i, item) {
                item.GrnNo = "<input type='hidden' value='" + item.GrnId + "' name='Details[" + i + "].GrnId' id='hdnGrnId" + i + "'/>" +
                            "<label class='control-label'  name='Details[" + i + "].GrnNo' id='GrnNo" + i + "'>" + item.GrnNo + "</label>";
                item.SkuId = "<div class='checkboxer'>" +
                                SelectAll.GetChk('chkProductAll', 'chkProduct' + i, 'Details[' + i + '].IsChecked') +
                            "<input type='hidden' name='Details[" + i + "].IsChecked' value='false'/>" +
                            "<label for='chkProduct" + i + "' id='lblSkuId" + i + "'></label>" +
                            "<input type='hidden' value='" + item.SkuId + "' name='Details[" + i + "].SkuId' id='hdnSkuId" + i + "'/>" +
                            "</div>";
                item.Quantity = "<input type='hidden' value='" + item.Quantity + "' name='Details[" + i + "].Quantity' id='hdnQuantity" + i + "'/>" +
                                '<input type="text" name="Details[' + i + '].GrnQuantity" id="txtGrnQuantity' + i + '" value=' + item.Quantity.toFixed(3) + ' class="textlabel" style="text-align: right"/>';
            });
            dtProduct.dtAddData(responseData);
        }
    }, ErrorFunction, false);
    return false;
}

function ValidateOnSubmit() {
    if (dtProduct.find('.selectrow:checked').length == 0) {
        isStepValid = false;
        ShowMessage('Please select Product');
        return false;
    }
}