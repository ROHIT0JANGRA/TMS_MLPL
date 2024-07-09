var drPoDate, hdnVendorId, txtVendorCode, txtPoNo, txtManualPoNo, dtPoList, selectedPoList, vendorMasterUrl, baseUrl, purchaseOrderModuleId;

$(document).ready(function () {
    SetPageLoad('Purchase Order', 'Approval', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    hdnVendorId = $('#hdnVendorId');
    txtVendorCode = $('#txtVendorCode');
    txtPoNo = $('#txtPoNo');
    txtManualPoNo = $('#txtManualPoNo');
    lblName = $('#lblName');

    drPoDate = InitDateRange('drPoDate', DateRange.LastWeek);
    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetPurchaseOrderList },
     { StepName: 'Purchase Order List', StepFunction: ValidateOnSubmit }
    ], 'Approve');
}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { return IsVendorCodeExist(txtVendorCode, hdnVendorId, lblName); });
}

function GetPurchaseOrderList() {
    var requestData = {
        fromDate: drPoDate.startDate,
        toDate: drPoDate.endDate,
        vendorId: hdnVendorId.val() == '' ? 0 : hdnVendorId.val(),
        poNo: txtPoNo.val(),
        manualPoNo: txtManualPoNo.val(),
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetPurchaseOrderListForApproval', JSON.stringify(requestData), function (result) {

        selectedPoList = [];

        if (dtPoList == null)
            dtPoList = LoadDataTable('dtPoList', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllPo', SelectPo), data: "PoId" },
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
                item.View = '<button id = "btnPrint' + i + '" onclick="return ViewReport(' + item.PoId + ')" class="btn btn-primary btn-xs dt-edit">' +
               '<span class="glyphicon glyphicon-print"></span>' +
                '</button>';
                item.PoId = "<div class='checkboxer'>" +
                                SelectAll.GetChk('chkAllPo', 'chkPo' + i, 'Details[' + i + '].IsChecked', SelectPo) +
                                "<input type='hidden' value='" + item.PoId + "' name='Details[" + i + "].PoId' id='hdnPoId" + i + "'/>" +
                                "<label class='control-label' for='chkPo" + i + "' id='lblPoId" + i + "'></label>" +
                                "</div>";
                item.PoDate = $.displayDate(item.PoDate);
                item.Amount = '<input type="text" value=' + item.Amount.toFixed(2) + ' class="textlabel" style="text-align: right" disabled/>';
                item.AdvanceAmount = '<input type="text" value=' + item.AdvanceAmount.toFixed(2) + ' class="textlabel" style="text-align: right" disabled/>';
            });
            dtPoList.dtAddData(result);
        }
    }, ErrorFunction, false);
    return false;
}

function ViewReport(value) {
    return ShowViewPrint(purchaseOrderModuleId, value);
}

function SelectPo() {
    selectedPoList = []
    $('[id*="chkPo"]').each(function () {
        var chkPo = $(this);
        if (chkPo.IsChecked) {
            selectedPoList.push($('#' + chkPo.Id.replace('chkPo', 'hdnPoId')).val());
        }
    });
}

function ValidateOnSubmit() {
    if (selectedPoList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Purchase Order');
        return false;
    }
}


