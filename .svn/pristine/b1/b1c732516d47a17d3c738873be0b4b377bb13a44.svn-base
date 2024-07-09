var txtBillNo, txtManualBillNo, txtCustomerCode, hdnCustomerId, lblCustomerName, drBillDate, dtCustomerBillList, selectedBillList, customerMasterUrl, billGenerationUrl, lblCustomer;

$(document).ready(function () {
    SetPageLoad('Customer', 'Bill UnSubmission', '', '', '@Url.Action("Index")');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtCustomerCode = $('#txtCustomerCode');
    txtBillNo = $('#txtBillNo');
    txtManualBillNo = $('#txtManualBillNo');
    lblCustomerName = $('#lblCustomerName');
    hdnCustomerId = $('#hdnCustomerId');
    ddlPaybasId = $('#ddlPaybasId');
    lblCustomer = $('#lblCustomer');
    ddlPaybasId.change(OnPaybasChange);
    OnPaybasChange();

    drBillDate = InitDateRange('drBillDate', DateRange.LastWeek, false);
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetCustomerBillList },
        { StepName: 'Un-Submit', StepFunction: GetBillSubmissionnDetails }
    ], 'Bill Submit');
}

function AttachEvents() {
    CustomerAutoCompleteByLocationPaybas('txtCustomerCode', 'hdnCustomerId', loginLocationId, ddlPaybasId.val(), true);
    txtCustomerCode.blur(function () { return IsCustomerCodeExistByLocationPaybas(txtCustomerCode, hdnCustomerId, lblCustomerName, loginLocationId, ddlPaybasId.val(), true); });
    AddItemDropDownList(ddlPaybasId, 0, '0', 'All');
    ddlPaybasId.change(OnPaybasChange).change();
}

function OnPaybasChange() {
    txtCustomerCode.val('');
    hdnCustomerId.val('');
    lblCustomerName.text('');
    txtCustomerCode.enable(ddlPaybasId.val() != '');
}
function GetCustomerBillList() {
    if (txtBillNo.val() == '' && txtManualBillNo.val() == '' && hdnCustomerId.val() == '') {
        isStepValid = false
        ShowMessage('Please select at least on Criteria');
        return false;
    }
    else {
        if (hdnCustomerId.val() == '')
            hdnCustomerId.val(0);
        var requestData = {
            billNos: txtBillNo.val(), manualBillNos: txtManualBillNo.val(), paybas: ddlPaybasId.val(),
            customerId: hdnCustomerId.val(), fromDate: drBillDate.startDate, toDate: drBillDate.endDate
        };
        AjaxRequestWithPostAndJson(billGenerationUrl + '/GetCustomerBillListForUnSubmission', JSON.stringify(requestData), function (result) {

            selectedBillList = [];

            if (dtCustomerBillList == null)
                dtCustomerBillList = LoadDataTable('dtCustomerBillList', false, false, false, null, null, [],
                  [
                      { title: SelectAll.GetChkAll('chkAllBill', SelectBill), data: "BillId" },
                      { title: 'Billno', data: 'BillNo' },
                      { title: 'Manual Billno', data: 'ManualBillNo' },
                      { title: 'Billing Branch', data: 'GenerationLocationCode' },
                      { title: 'Bill Type', data: 'Paybas' },
                      { title: 'Bill Amount', data: 'BillAmount' },
                      { title: 'Bill Date', data: 'BillDate' },
                      { title: 'Due Date', data: 'DueDate' }
                  ]);

            dtCustomerBillList.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                var customerName;
                $.each(result, function (i, item) {
                    item.BillId = "<div class='checkboxer'>" +
                                    SelectAll.GetChk('chkAllBill', 'chkBill' + i, 'Details[' + i + '].IsChecked', SelectBill) +
                                    "<input type='hidden' value='" + item.BillId + "' name='Details[" + i + "].BillId' id='hdnBillId" + i + "'/>" +
                                    "<label class='label' for='chkBill" + i + "' id='lblBillId" + i + "'></label>" +
                                    "</div>";
                    item.BillDate = $.displayDate(item.BillDate);
                    item.BillAmount = '<input type="text" value=' + item.BillAmount.toFixed(2) + ' class="textlabel" style="text-align: right" disabled/>';
                    item.DueDate = $.displayDate(item.DueDate);
                    customerName = item.CustomerCode;
                });
                lblCustomer.text(customerName);
                dtCustomerBillList.dtAddData(result);
            }
        }, ErrorFunction, false);
        return false;
    }

}

function SelectBill() {
    selectedBillList = []
    $('[id*="chkBill"]').each(function () {
        var chkBill = $(this);
        if (chkBill.IsChecked) {
            selectedBillList.push($('#' + chkBill.Id.replace('chkBill', 'hdnBillId')).val());
        }
    });
}

function GetBillSubmissionnDetails() {
    if (selectedBillList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Bill');
        return false;
    }
}

