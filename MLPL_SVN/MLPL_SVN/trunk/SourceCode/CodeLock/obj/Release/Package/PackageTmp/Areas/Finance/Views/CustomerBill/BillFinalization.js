var billFinalizationUrl, dtBillList;
var isbillAllowOnlyOnHqtr = false;
var ruleMasterUrl;

$(document).ready(function () {
    SetPageLoad('Customer', 'Bill Finalization', '', '', '@Url.Action("Index")');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtCustomerCode = $('#txtCustomerCode');
    ddlFromLocationId = $('#ddlFromLocationId');
    txtBillNos = $('#txtBillNos');
    txtManualBillNos = $('#txtManualBillNos');
    lblCustomerName = $('#lblCustomerName');
    hdnCustomerId = $('#hdnCustomerId');
    lblCustomer = $('#lblCustomer');
    ddlPaybasId = $('#ddlPaybasId');
    ddlCustomerType = $('#ddlCustomerType');

    drBillDate = InitDateRange('drBillDate', DateRange.LastWeek, false);

    dtBillList = LoadDataTable('dtBillList', false, false, false, null, null, [],
        [
            { title: SelectAll.GetChkAll('chkAllBill', SelectBill), data: "BillId" },
            { title: 'Bill No', data: 'BillNo' },
            { title: 'Manual Bill No', data: 'ManualBillNo' },
            { title: 'Bill Date', data: 'BillDate' },
            { title: 'Due Date', data: 'DueDate' },
            { title: 'Party Name', data: 'CustomerCode' },
            { title: 'Bill Amount', data: 'BillAmount' },
            { title: 'Collection Location', data: 'BillCollectionLocationCode' }
        ]);

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetBillListForFinalization },
        { StepName: 'Finalized', StepFunction: ValidateOnSubmit }
    ], 'Bill Finalization');
}

function AttachEvents() {
    ddlCustomerType.val(1);
    CustomerAutoCompleteByLocationPaybas('txtCustomerCode', 'hdnCustomerId', loginLocationId, ddlPaybasId.val(), ddlCustomerType.val() == 2 ? false : true);
    txtCustomerCode.blur(function () { return IsCustomerCodeExistByLocationPaybas(txtCustomerCode, hdnCustomerId, lblCustomerName, loginLocationId, ddlPaybasId.val(), true); });
    AddItemDropDownList(ddlPaybasId, 0, '0', 'All');
    ddlPaybasId.change(OnPaybasChange);
    ddlCustomerType.change(OnPaybasChange);
    OnPaybasChange();

    var requestData = { moduleId: 151, ruleId: 1 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        isbillAllowOnlyOnHqtr = (result == "Y" ? true : false);
    }, ErrorFunction, false);
    $('#dvFromLocation').showHide(!isbillAllowOnlyOnHqtr);

    var requestData = { moduleId: 15, ruleId: 11 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        $('#dvCustomerType').showHide(result == "Y" ? true : false);
    }, ErrorFunction, false);
}

function OnPaybasChange() {
    txtCustomerCode.val('');
    hdnCustomerId.val('');
    lblCustomerName.text('');
    txtCustomerCode.enable(ddlPaybasId.val() != '');
    CustomerAutoCompleteByLocationPaybas('txtCustomerCode', 'hdnCustomerId', loginLocationId, ddlPaybasId.val() == 7 ? 2 : ddlPaybasId.val(), true, 'Customer Name',true ,ddlCustomerType.val() == 2 ? false : true);
}

function GetBillListForFinalization() {
    if (txtBillNos.val() == '' && txtCustomerCode.val() == '') {
        isStepValid = false
        ShowMessage('Please select at least on Criteria');
        return false;
    }
    else {
        
        if (txtCustomerCode.val() == '')
            hdnCustomerId.val(0);
        
        
        var requestData = { locationId: isbillAllowOnlyOnHqtr == true ? 1 : ddlFromLocationId.val(), customerId: hdnCustomerId.val(), fromDate: drBillDate.startDate, toDate: drBillDate.endDate, billNos: txtBillNos.val() != '' ? txtBillNos.val() : '', paybas: ddlPaybasId.val(), manualBillNos: txtManualBillNos.val() != '' ? txtManualBillNos.val() : '' };
        
        
        

        AjaxRequestWithPostAndJson(billFinalizationUrl + '/GetBillListForBillFinalization', JSON.stringify(requestData), function (result) {
            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                selectedBillList = [];
                dtBillList.fnClearTable();
                $.each(result, function (i, item) {
                    if (i == 0)
                        lblCustomer.text(item.CustomerCode);
                    if (lblCustomer.text() != item.CustomerCode)
                        $('#dvCustomer').hide();
                    item.BillId = SelectAll.GetChk('chkAllBill', 'chkBillId' + i, 'Details[' + i + '].IsChecked', SelectBill) +
                        "<input type='hidden' value='" + item.BillId + "' name='Details[" + i + "].BillId' id='hdnBillId" + i + "'/>" +
                        "<label class='label' for='chkBillId" + i + "' id='lblBillId" + i + "'></label>" +
                        "<input type='hidden' value='" + item.BillNo + "' name='Details[" + i + "].BillNo' id='hdnBillNo" + i + "'/>" +
                        "<input type='hidden' value='" + item.BillDate + "'  id='hdnBillDate" + i + "'/>" +
                        "<input type='hidden' value='" + item.PaybasId + "' name='Details[" + i + "].PaybasId' id='hdnPaybasId" + i + "'/>";
                    item.BillDate = $.displayDate(item.BillDate);
                    item.DueDate = $.displayDate(item.DueDate);
                    item.BillAmount = item.BillAmount.toFixed(2);
                });
                dtBillList.dtAddData(result, [5]);
            }
        }, ErrorFunction, false);
        return false;
    }
}

function SelectBill() {
    selectedBillList = [];
    $('[id*="chkBillId"]').each(function () {
        if ($(this).IsChecked)
            selectedBillList.push($('#' + this.id.replace('chkBillId', 'hdnBillId')).val());
    });
}

function ValidateOnSubmit() {
    if (selectedBillList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at-least one Bill');
        return false;
    }
    else if (!ValidateModuleDateWithPreviousDocumentDate('dtBillList', 'chkBillId', 'hdnBillDate', 'txtFinalizationDate', 'Finalization Date')) return false;
}
