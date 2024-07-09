var txtBillNo, txtManualBillNo, txtCustomerCode, hdnCustomerId, lblCustomerName, drBillDate, dtCustomerBillList, selectedBillList, customerMasterUrl, billGenerationUrl, lblCustomer;

$(document).ready(function () {
    SetPageLoad('Customer', 'Bill Cancellation', '', '', '');
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
    $('#ddlPaybasId option').eq(0).before($('<option>', { value: 0, text: 'Select Bill Type' }));
    $("#ddlPaybasId").append('<option value="5">General Billing</option>');
    ddlPaybasId.val(0);
    ddlPaybasId.change(OnPaybasChange);
    OnPaybasChange();

    drBillDate = InitDateRange('drBillDate', DateRange.LastWeek, false);
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetCustomerBillList },
        { StepName: 'Bill List', StepFunction: ValidateOnSubmit }
    ], 'Cancel');
}

function AttachEvents() {
    customerScript.CustomerAutoComplete('txtCustomerCode', 'lblCustomerName', 'hdnCustomerId', 'CustomerId', true);
    txtCustomerCode.blur(function () { return CheckValidCustomerCode(txtCustomerCode, hdnCustomerId, true); });
}

function OnPaybasChange() {
    txtCustomerCode.val('');
    hdnCustomerId.val('');
    lblCustomerName.text('');
    txtCustomerCode.enable(ddlPaybasId.val() != 0);
    if (ddlPaybasId.val() == 5)
        CustomerAutoComplete('txtCustomerCode', 'hdnCustomerId');
    else
        customerScript.CustomerAutoComplete('txtCustomerCode', 'lblCustomerName', 'hdnCustomerId', 'CustomerId', false);
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
        AjaxRequestWithPostAndJson(billGenerationUrl + '/GetCustomerBillListForCancellation', JSON.stringify(requestData), function (result) {

            selectedBillList = [];

            if (dtCustomerBillList == null)
                dtCustomerBillList = LoadDataTable('dtCustomerBillList', false, false, false, null, null, [],
                    [
                        { title: SelectAll.GetChkAll('chkAllBill', SelectBill), data: "BillId" },
                        { title: 'Billno', data: 'BillNo' },
                        { title: 'Manual Billno', data: 'ManualBillNo' },
                        { title: 'Billing Branch', data: 'GenerationLocationCode' },
                        { title: 'Bill Type', data: 'Paybas' },
                        { title: 'Bill Date', data: 'BillDate' }
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

function ValidateOnSubmit() {
    if (selectedBillList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Bill');
        return false;
    }
    else if (!ValidateModuleDateWithPreviousDocumentDate('dtCustomerBillList', 'chkBill', 'hdnBillDate', 'txtSubmissionDateTime', 'Submission Date')) return false;
}

var customerScript = {
    CustomerAutoComplete: function (txtCodeId, lbltxtNameId, hdnId, entity, allowWalkin) {
        AutoComplete(txtCodeId, customerMasterUrl + '/GetAutoCompleteCustomerListByLocationPaybas', 'customerName', 'l', 'l', 'l', 'd', '', hdnId, lbltxtNameId, '', true, function () {
            if (entity == 'CustomerId')
                return [{ Key: 'locationId', Value: loginLocationId }, { Key: 'PaybasId', Value: ddlPaybasId.val() }, { Key: 'allowWalkin', Value: allowWalkin }];
        });
    }
}


function CheckValidCustomerCode(txtCustomerCode, hdnCustomerId, allowWalkin) {
    if (txtCustomerCode.val() != "") {
        if (ddlPaybasId.val() == 5)
            IsCustomerCodeExist(txtCustomerCode, hdnCustomerId, lblCustomerName);
        else {
            var requestData = { customerCode: txtCustomerCode.val() };
            var requestData = { locationId: loginLocationId, paybasId: ddlPaybasId.val(), customerCode: txtCustomerCode.val(), allowWalkIn: allowWalkin };
            AjaxRequestWithPostAndJson(customerMasterUrl + '/IsCustomerExistByLocationPaybas', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result.CustomerId) || result.CustomerId == 0) {
                    ShowMessage('Customer is not exist');
                    txtCustomerCode.val('');
                    hdnCustomerId.val('');
                    lblCustomerName.text('');
                    txtCustomerCode.focus();
                }
                else {
                    hdnCustomerId.val(result.CustomerId);
                    txtCustomerCode.val(result.CustomerCode);
                    lblCustomerName.text(result.CustomerName);
                }
            }, ErrorFunction, false);
        }
    }
}


