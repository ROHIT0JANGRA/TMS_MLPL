var txtBillNo, txtManualBillNo, txtCustomerCode, hdnCustomerId, lblCustomerName, drBillDate, dtCustomerBillList, selectedBillList, customerMasterUrl, billGenerationUrl, employeeMasterUrl, lblCustomer;
var submittedByUserList, ruleMasterUrl, allowSubmissionDetails;
$(document).ready(function () {
    SetPageLoad('Customer', 'Bill Submission', '', '', '@Url.Action("Index")');
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
    ddlCustomerType = $('#ddlCustomerType');
    ddlPaybasId.change(OnPaybasChange);
    ddlCustomerType.change(OnPaybasChange);
    OnPaybasChange();
   

    drBillDate = InitDateRange('drBillDate', DateRange.LastWeek, false);
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetCustomerBillList },
        { StepName: 'Submitted', StepFunction: ValidateOnSubmit }
    ], 'Bill Submit');
}

function AttachEvents() {
    ddlCustomerType.val(1);
    CustomerAutoCompleteByLocationPaybas('txtCustomerCode', 'hdnCustomerId', loginLocationId, ddlPaybasId.val(), ddlCustomerType.val() == 2 ? false : true);
    txtCustomerCode.blur(function () { return IsCustomerCodeExistByLocationPaybas(txtCustomerCode, hdnCustomerId, lblCustomerName, loginLocationId, ddlPaybasId.val(), true); });
    AddItemDropDownList(ddlPaybasId, 0, '0', 'All');
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
    CustomerAutoCompleteByLocationPaybas('txtCustomerCode', 'hdnCustomerId', loginLocationId, ddlPaybasId.val(), true, 'Customer Name', true, ddlCustomerType.val() == 2 ? false : true);
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
            billNos: txtBillNo.val(), manualBillNos: txtManualBillNo.val(), paybas: ddlPaybasId.val() == '' ? 0 : ddlPaybasId.val(),
            customerId: hdnCustomerId.val(), fromDate: drBillDate.startDate, toDate: drBillDate.endDate
        };
        AjaxRequestWithPostAndJson(billGenerationUrl + '/GetCustomerBillListForSubmission', JSON.stringify(requestData), function (result) {

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
                        { title: 'Due Date', data: 'DueDate' },
                        { title: 'Submitted By', data: 'SubmittedByUserId' },
                        { title: 'Submitted Document', data: 'SubmittedDocumentName' }
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
                                    "<input type='hidden' value='" + item.BillDate + "'  id='hdnBillDate" + i + "'/>" +
                                    "</div>";

                    item.BillDate = $.displayDate(item.BillDate);
                    item.BillAmount = '<input type="text" value=' + item.BillAmount.toFixed(2) + ' class="textlabel" style="text-align: right" disabled/>';
                    item.DueDate = $.displayDate(item.DueDate);
                    item.SubmittedByUserId = "<div class='select' id='dvSubmittedByUser" + i + "'>" +
                    "<select class='form-control' name='Details[" + i + "].SubmittedByUserId' id='ddlSubmittedByUserId" + i + "' > " + "</select><i></i>" +
                    "</div>" +
                    '<span data-valmsg-for="Details[' + i + '].SubmittedByUserId" data-valmsg-replace="true"></span>';
                    item.SubmittedDocumentName = ' <div class="form-group" id="dvSubmittedDocument' + i + '"><div class="input prepend-big-btn"><label class="icon-right" for="prepend-big-btn"><i class="fa fa-download"></i></label>' +
                    '<div class="file-button">Browse' +
                    '<input type="file" name="Details[' + i + '].SubmittedDocumentAttachment"  id="SubmittedDocumentAttachment' + i + '" class="form-control"/>' +
                      '</div>' +
                                '<input class="form-control" type="text" id="prepend-big-btn" readonly="" placeholder="no file selected">' +
                            '</div>' +
                        '</div>';
                    customerName = item.CustomerCode;
                    item.BillNo = "<input type='hidden' value='" + item.BillNo + "' name='Details[" + i + "].BillNo' id='hdnBillNo" + i + "'/>" + item.BillNo;
                });

                lblCustomer.text(customerName);
                dtCustomerBillList.dtAddData(result);

                var requestData = { moduleId: 15, ruleId: 5 };
                AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
                    allowSubmissionDetails = result == 'Y' ? true : false;
                }, ErrorFunction, false);

                $('th:nth-child(9)').showHide(allowSubmissionDetails);
                $('th:nth-child(10)').showHide(allowSubmissionDetails);

                $('[id*="ddlSubmittedByUserId"]').each(function () {
                    var ddlSubmittedByUserId = $(this);
                    var dvSubmittedByUser = $('#' + ddlSubmittedByUserId.Id.replace('ddlSubmittedByUserId', 'dvSubmittedByUser'));
                    var dvSubmittedDocument = $('#' + ddlSubmittedByUserId.Id.replace('ddlSubmittedByUserId', 'dvSubmittedDocument'));
                    BindDropDownList(ddlSubmittedByUserId.Id, submittedByUserList, 'Value', 'Name', '', 'Select User');
                    ddlSubmittedByUserId.disable();

                    dvSubmittedByUser.showHide(allowSubmissionDetails);
                    dvSubmittedDocument.showHide(allowSubmissionDetails);
                });
            }
        }, ErrorFunction, false);
        return false;
    }

}

function SelectBill() {
    selectedBillList = []
    $('[id*="chkBill"]').each(function () {
        var chkBill = $(this);
        var ddlSubmittedByUserId = $('#' + chkBill.Id.replace('chkBill', 'ddlSubmittedByUserId'));
        if (chkBill.IsChecked)
            selectedBillList.push($('#' + chkBill.Id.replace('chkBill', 'hdnBillId')).val());
        ddlSubmittedByUserId.enable(chkBill.IsChecked);

    });
}

function ValidateOnSubmit() {
    if (selectedBillList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Bill');
        return false;
    }
    else if (!ValidateModuleDateWithPreviousDocumentDate('dtCustomerBillList', 'chkBill', 'hdnBillDate', 'txtSubmissionDateTime', 'Submission Date')) return false;
}
