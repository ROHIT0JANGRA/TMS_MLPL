var txtBillNo, txtManualBillNo, txtCustomerCode, hdnCustomerId, lblCustomerName, drBillDate, dtCustomerBillListForCollection, selectedBillList, customerMasterUrl, billGenerationUrl,
    lblCustomer, totalAmount, hdnTotalAmount, chargeCount, chargeListCount, chargeList, totalChargeAmount, hdnCustomer;
var lblCustomerGroup, rdGroupWise, rdCustomerWise;
var ruleMasterUrl;
$(document).ready(function () {
    InitObjects();
    AttachEvents();

    SetPageLoad('Customer', 'Bill Collection', 'ddlPaybasId', '', '');
    rdGroupWise.click(CollectionTypeChange);
    CollectionTypeChange();

});

function InitObjects() {
    txtCustomerCode = $('#txtCustomerCode'); txtBillNo = $('#txtBillNo'); txtManualBillNo = $('#txtManualBillNo'); lblCustomerName = $('#lblCustomerName'); hdnCustomerId = $('#hdnCustomerId'); ddlPaybasId = $('#ddlPaybasId'); lblCustomer = $('#lblCustomer'); hdnCustomer = $('#hdnCustomer'); hdnCustomerId = $('#hdnCustomerId'); hdnTotalAmount = $('#hdnTotalAmount');
    totalAmount = 0.00;
    rdGroupWise = $('#rdGroupWise');
    rdCustomerWise = $('#rdCustomerWise');
    drBillDate = InitDateRange('drBillDate', DateRange.LastWeek, false);
    ddlCustomerType = $('#ddlCustomerType');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetCustomerBillListForCollection },
        { StepName: 'Collected', StepFunction: GetBillCollectionDetails },
        { StepName: 'Payment Details', StepFunction: EnableReceiptControlsOnSubmit }
    ], 'Bill Collection');
    CollectionTypeChange();
}

function AttachEvents() {
    ddlCustomerType.val(1);
    CustomerAutoCompleteByLocationPaybas('txtCustomerCode', 'hdnCustomerId', loginLocationId, ddlPaybasId.val(), true, '', true, ddlCustomerType.val() == 2 ? false : true);
    txtCustomerCode.blur(function () { return IsCustomerCodeExistByLocationPaybas(txtCustomerCode, hdnCustomerId, lblCustomerName, loginLocationId, ddlPaybasId.val(), true, '', true); });
    AddItemDropDownList(ddlPaybasId, 0, '0', 'All');
    ddlPaybasId.change(OnPaybasChange).change();
    ddlCustomerType.change(OnPaybasChange);

    rdGroupWise.click(CollectionTypeChange); rdCustomerWise.click(CollectionTypeChange);

    var requestData = { moduleId: 15, ruleId: 11 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        $('#dvCustomerType').showHide(result == "Y" ? true : false);
    }, ErrorFunction, false);
}

function OnPaybasChange() {
    txtCustomerCode.val('');
    hdnCustomerId.val('');

    txtCustomerCode.enable(ddlPaybasId.val() != '');
    CustomerAutoCompleteByLocationPaybas('txtCustomerCode', 'hdnCustomerId', loginLocationId, ddlPaybasId.val(), true, '', true, ddlCustomerType.val() == 2 ? false : true);
}

function GetCustomerBillListForCollection() {
    if (txtBillNo.val() == '' && txtManualBillNo.val() == '' && ddlPaybasId.val() == '') {
        isStepValid = false
        ShowMessage('Please select Bill Type');
        return false;
    }


    if (txtBillNo.val() == '' && txtManualBillNo.val() == '' && hdnCustomerId.val() == '' && ($('#rdCustomerWise').is(':checked'))) {
        isStepValid = false
        ShowMessage('Please select Billing Party');
        return false;
    }
    else {
        if (hdnCustomerId.val() == '')
            hdnCustomerId.val(0);
        var requestData = {
            billNos: txtBillNo.val(), manualBillNos: txtManualBillNo.val(), paybas: ddlPaybasId.val(),
            customerId: hdnCustomerId.val(), fromDate: drBillDate.startDate, toDate: drBillDate.endDate, customerGroup: $('#ddlCustomerGroup').val()
        };
        AjaxRequestWithPostAndJson(billGenerationUrl + '/GetCustomerBillListForCollection', JSON.stringify(requestData), function (result) {

            selectedBillList = [];

            if (dtCustomerBillListForCollection == null)
                dtCustomerBillListForCollection = LoadDataTable('dtCustomerBillListForCollection', false, false, false, null, null, [],
                    [
                        { title: SelectAll.GetChkAll('chkAllBill', SelectBill), data: "BillId" },
                        { title: 'Bill No', data: 'BillNo' },
                        { title: 'Manual Bill No', data: 'ManualBillNo' },
                        { title: 'Billing Branch', data: 'GenerationLocationCode' },
                        { title: 'Bill Type', data: 'Paybas' },
                        { title: 'Bill Date', data: 'BillDate' },
                        { title: 'Due Date', data: 'DueDate' },
                        { title: 'Bill Amount', data: 'BillAmount', width: 200 },
                        { title: 'Pending Amount', data: 'PendingAmount', width: 200 },
                        { title: 'Bill Adjustment Amount', data: 'CollectionAmount', width: 200 },
                        { title: 'TDS (-)', data: 'TdsAmount', width: 200 },
                        { title: 'Claim Deduction (-)', data: 'Claimdeduction', width: 200 },
                        { title: 'Freight Discount (-)', data: 'FreightDiscount', width: 200 },
                        { title: 'Other Deduction (-)', data: 'OtherDeduction', width: 200 },
                        { title: 'Other Amount (+)', data: 'OtherAmount', width: 200 },
                        { title: 'Collection Amount', data: 'NetReceivedAmount', width: 200 },
                        { title: 'Remarks', data: 'Remarks' },
                    ]);

            dtCustomerBillListForCollection.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                var customerName;
                $.each(result, function (i, item) {
                    var CollectionAmount = item.PendingAmount;
                    item.BillId = SelectAll.GetChk('chkAllBill', 'chkBill' + i, 'MrDetailList[' + i + '].IsChecked', SelectBill) +
                        "<input type='hidden' value='" + item.BillId + "' name='MrDetailList[" + i + "].BillId' id='hdnBillId" + i + "'/>" +
                        "<label class='label' for='chkBill" + i + "' id='lblBillId" + i + "'></label>" +
                        "<input type='hidden' value='" + i + "' name='MrDetailList[" + i + "].BillId' id='hdnRowId" + i + "'/>" +
                        "<input type='hidden' value='" + item.SubmissionDate + "'  id='hdnSubmissionDate" + i + "'/>" +
                        "<input type='hidden' id='hdnPendingAmount" + i + "'  value='" + item.PendingAmount + "'/>";
                    item.BillDate = $.displayDate(item.BillDate);
                    //item.PendingAmount = item.PendingAmount.toFixed(2);
                    item.PendingAmount = '<input type=\'text\' name="MrDetailList[' + i + '].PendingAmount" id="txtPendingAmount' + i + '" value="' + item.PendingAmount + '" class="form-control textlabel numeric2" style="width: 100px;" />';
                    // '<span data-valmsg-for="MrDetailList[' + i + '].TdsAmount" data-valmsg-replace="true"></span>';
                    item.CollectionAmount = '<input type=\'text\' name="MrDetailList[' + i + '].CollectionAmount" id="txtCollectionAmount' + i + '" value="' + CollectionAmount + '" class="form-control numeric2" style="width: 100px;" disabled/>' +
                        '<span data-valmsg-for="MrDetailList[' + i + '].CollectionAmount" data-valmsg-replace="true"></span>';
                    item.BillAmount = '<input type=\'text\' name="MrDetailList[' + i + '].BillAmount" id="txtBillAmount' + i + '" value=' + item.BillAmount + ' class="form-control textlabel numeric2" style="width: 100px;"/>';
                    item.DueDate = $.displayDate(item.DueDate);
                    customerName = item.CustomerName;
                    customerCode = item.CustomerCode;
                    customerId = item.CustomerId;
                    item.TdsAmount = '<input type=\'text\' name="MrDetailList[' + i + '].TdsAmount" id="txtTdsAmount' + i + '"  value="0.00" class="form-control numeric2" style="width: 100px;" disabled/>' +
                        '<span data-valmsg-for="MrDetailList[' + i + '].TdsAmount" data-valmsg-replace="true"></span>';
                    item.Claimdeduction = '<input type=\'text\' name="MrDetailList[' + i + '].Claimdeduction" id="txtClaimdeduction' + i + '" value="0.00" class="form-control numeric2" style="width: 100px;" disabled/>' +
                        '<span data-valmsg-for="MrDetailList[' + i + '].Claimdeduction" data-valmsg-replace="true"></span>';
                    item.FreightDiscount = '<input type=\'text\' name="MrDetailList[' + i + '].FreightDiscount" id="txtFreightDiscount' + i + '" value="0.00" class="form-control numeric2" style="width: 100px;" disabled/>';
                    item.OtherDeduction = '<input type=\'text\' name="MrDetailList[' + i + '].OtherDeduction" id="txtOtherDeduction' + i + '" value="0.00" class="form-control numeric2" style="width: 100px;" disabled/>';
                    item.OtherAmount = '<input type=\'text\' name="MrDetailList[' + i + '].OtherAmount" id="txtOtherAmount' + i + '" value="0.00" class="form-control numeric2" style="width: 100px;" disabled/>';
                    item.NetReceivedAmount = '<input class="form-control textlabel numeric2" value= "0.00" id="txtNetReceivedAmount' + i + '" type="text" name="MrDetailList[' + i + '].NetReceivedAmount" style="width: 100px;" />';
                    item.Remarks = '<input class="form-control" disabled id="txtRemarks' + i + '" type="text" name="MrDetailList[' + i + '].Remarks" />';

                });
                if ($('#rdGroupWise').is(':checked')) {
                    $('#lblParty').text('Customer Group');
                    lblCustomer.text($('#ddlCustomerGroup').find(":selected").text());
                    $('#hdnCustomerGroupName').val($('#ddlCustomerGroup').find(":selected").text());
                }
                else {
                    $('#lblParty').text('Party');
                    lblCustomer.text(customerName);
                    hdnCustomer.val(customerCode);
                    hdnCustomerId.val(customerId);
                }
                dtCustomerBillListForCollection.dtAddData(result);
                $('#dtCustomerBillListForCollection tr:gt(0)').each(function () {
                    var tr = $(this);
                    var trId = tr.find('[id*="hdnRowId"]').val();
                    var txtBillAmount = $('#txtBillAmount' + trId);
                    var txtCollectionAmount = $('#txtCollectionAmount' + trId);
                    var txtNetReceivedAmount = $('#txtNetReceivedAmount' + trId);
                    var txtTdsAmount = $('#txtTdsAmount' + trId);
                    var txtClaimdeduction = $('#txtClaimdeduction' + trId);
                    var txtFreightDiscount = $('#txtFreightDiscount' + trId);
                    var txtOtherDeduction = $('#txtOtherDeduction' + trId);
                    var txtOtherAmount = $('#txtOtherAmount' + trId);
                    txtNetReceivedAmount.readOnly();
                    txtCollectionAmount.blur(CalculateTotalAmount);
                    txtTdsAmount.blur(CalculateTotalAmount);
                    txtClaimdeduction.blur(CalculateTotalAmount);
                    txtFreightDiscount.blur(CalculateTotalAmount);
                    txtOtherDeduction.blur(CalculateTotalAmount);
                    txtOtherAmount.blur(CalculateTotalAmount);
                });
                $('#dtCustomerBillListForCollection td:eq(7)').each(function () { $(this).css('max-width', '90px') });
            }
        }, ErrorFunction, false);
        return false;
    }
}

function SelectBill() {
    selectedBillList = []
    totalAmount = 0.00;
    $('[id*="chkBill"]').each(function () {
        var chkBill = $(this);
        if (chkBill.IsChecked)
            selectedBillList.push($('#' + chkBill.Id.replace('chkBill', 'hdnBillId')).val());
        var txtPendingAmount = $('#' + chkBill.Id.replace('chkBill', 'txtPendingAmount'));
        var txtBillAmount = $('#' + chkBill.Id.replace('chkBill', 'txtBillAmount'));
        var txtCollectionAmount = $('#' + chkBill.Id.replace('chkBill', 'txtCollectionAmount'));
        var txtTdsAmount = $('#' + chkBill.Id.replace('chkBill', 'txtTdsAmount'));
        var txtClaimdeduction = $('#' + chkBill.Id.replace('chkBill', 'txtClaimdeduction'));
        var txtFreightDiscount = $('#' + chkBill.Id.replace('chkBill', 'txtFreightDiscount'));
        var txtOtherDeduction = $('#' + chkBill.Id.replace('chkBill', 'txtOtherDeduction'));
        var txtOtherAmount = $('#' + chkBill.Id.replace('chkBill', 'txtOtherAmount'));
        var txtNetReceivedAmount = $('#' + chkBill.Id.replace('chkBill', 'txtNetReceivedAmount'));
        var txtRemarks = $('#' + chkBill.Id.replace('chkBill', 'txtRemarks'));
        var hdnRowId = $('#' + chkBill.Id.replace('chkBill', 'hdnRowId'));

        txtTdsAmount.enable(chkBill.IsChecked);
        txtClaimdeduction.enable(chkBill.IsChecked);
        txtFreightDiscount.enable(chkBill.IsChecked);
        txtOtherDeduction.enable(chkBill.IsChecked);
        txtOtherAmount.enable(chkBill.IsChecked);
        txtCollectionAmount.enable(chkBill.IsChecked);
        txtNetReceivedAmount.enable(chkBill.IsChecked);
        txtRemarks.enable(chkBill.IsChecked);
        txtNetReceivedAmount.val(chkBill.IsChecked ? txtCollectionAmount.val() : 0);
        txtTdsAmount.val(chkBill.IsChecked ? txtTdsAmount.val() : 0);
        txtClaimdeduction.val(chkBill.IsChecked ? txtClaimdeduction.val() : 0);
        txtFreightDiscount.val(chkBill.IsChecked ? txtFreightDiscount.val() : 0);
        txtOtherDeduction.val(chkBill.IsChecked ? txtOtherDeduction.val() : 0);
        txtOtherAmount.val(chkBill.IsChecked ? txtOtherAmount.val() : 0);

    });
    CalculateTotalAmount();
}

function GetBillCollectionDetails() {
    if (selectedBillList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Bill');
        return false;
    }
    else if (!ValidateModuleDateWithPreviousDocumentDate('dtCustomerBillListForCollection', 'chkBill', 'hdnSubmissionDate', 'txtCollectionDateTime', 'Collection Date')) return false;
    SetReceiptPartyTypeAndParty(2, hdnCustomerId.val());
}


function CalculateTotalAmount() {
    var totalAmount = 0.00, totalTdsAmount = 0.00, totalBillsAmount = 0.00;
    var totalBillAmount = 0, totalPendingAmount = 0, totalCollectionAmount = 0, totalNetReceivedAmount = 0;
    $('[id*="chkBill"]').each(function () {
        var chkBill = $(this);
        var txtBillAmount = $('#' + chkBill.Id.replace('chkBill', 'txtBillAmount'));
        var hdnPendingAmount = $('#' + chkBill.Id.replace('chkBill', 'hdnPendingAmount'));
        var txtPendingAmount = $('#' + chkBill.Id.replace('chkBill', 'txtPendingAmount'));
        var txtCollectionAmount = $('#' + chkBill.Id.replace('chkBill', 'txtCollectionAmount'));
        var txtClaimdeduction = $('#' + chkBill.Id.replace('chkBill', 'txtClaimdeduction'));
        var txtFreightDiscount = $('#' + chkBill.Id.replace('chkBill', 'txtFreightDiscount'));
        var txtOtherDeduction = $('#' + chkBill.Id.replace('chkBill', 'txtOtherDeduction'));
        var txtOtherAmount = $('#' + chkBill.Id.replace('chkBill', 'txtOtherAmount'));
        var txtTdsAmount = $('#' + chkBill.Id.replace('chkBill', 'txtTdsAmount'));
        var txtNetReceivedAmount = $('#' + chkBill.Id.replace('chkBill', 'txtNetReceivedAmount'));
        var hdnRowId = $('#' + chkBill.Id.replace('chkBill', 'hdnRowId'));

        if (chkBill.IsChecked) {
            if (txtCollectionAmount.toFloat() > hdnPendingAmount.toFloat()) {
                txtCollectionAmount.val(hdnPendingAmount.val());
            }

            totalTdsAmount += parseFloat(txtTdsAmount.val());
            totalAmount = txtOtherAmount.toFloat() - (txtTdsAmount.toFloat() + txtFreightDiscount.toFloat() + txtOtherDeduction.toFloat() + txtClaimdeduction.toFloat());
            totalBillsAmount += totalAmount;
            txtPendingAmount.val(hdnPendingAmount.val() - txtCollectionAmount.toFloat());//totalAmount + txtOtherAmount.toFloat()

            if (txtPendingAmount.val() < 0) {
                ShowMessage('Collection Amount Should not been Grater Than Balance Amount');
                chkBill.uncheck();
                $('#chkAllBill').uncheck();
                SelectBill();
            }

            if ((txtCollectionAmount.toFloat() + totalAmount) < 0) {
                ShowMessage('Collection Amount Should not been Less Than Bill Adjustment Amount');
                chkBill.uncheck();
                $('#chkAllBill').uncheck();
                SelectBill();
            }

            //if (txtCollectionAmount.toFloat() + totalAmount < 0) {
            //    chkBill.uncheck();
            //    $('#chkAllBill').uncheck();
            //    SelectBill();
            //}
            txtNetReceivedAmount.val(txtCollectionAmount.toFloat() + totalAmount);//totalAmount.toFixed(2)
        }
        else {
            txtCollectionAmount.val(hdnPendingAmount.val());
            txtPendingAmount.val(hdnPendingAmount.val());
            txtTdsAmount.val(0);
            txtClaimdeduction.val(0);
            txtFreightDiscount.val(0);
            txtOtherDeduction.val(0);
            txtOtherAmount.val(0);
        }
        totalBillAmount = totalBillAmount + parseFloat(txtBillAmount.val());
        totalPendingAmount = totalPendingAmount + parseFloat(txtPendingAmount.val());
        totalCollectionAmount = totalCollectionAmount + parseFloat(txtCollectionAmount.val());
        totalNetReceivedAmount = totalNetReceivedAmount + parseFloat(txtNetReceivedAmount.val());
    });
    hdnTotalAmount.val(totalNetReceivedAmount);
    SetReceiptAmount(totalNetReceivedAmount, totalTdsAmount, totalNetReceivedAmount == 0 && totalTdsAmount > 0);
    $('#txtTotalBillAmount').val(Math.round(totalBillAmount));
    $('#txtTotalPendingAmount').val(Math.round(totalPendingAmount));
    $('#txtTotalCollectionAmount').val(Math.round(totalCollectionAmount));
    $('#txtTotalNetReceivedAmount').val(Math.round(totalNetReceivedAmount));
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


function Comparer(a, b, fieldName) {
    var fieldName = 'ChargeName';
    if (a[fieldName] > b[fieldName])
        return 1;
    else if (a[fieldName] < b[fieldName])
        return -1;
    else return 0;
}

function ComparerCharge(a, b) {
    var fieldName = 'ChargeName';
    return Comparer(a, b, fieldName);
}

function ComparerTax(a, b) {
    var fieldName = 'TaxName';
    return Comparer(a, b, fieldName);
}

function CollectionTypeChange() {
    if ($('#rdGroupWise').is(':checked')) {
        $('#dvCustomerGroup').show();
        $('#dvCriteriaCustomerCode').hide();
        lblCustomerName.text('');
    }
    else {
        $('#dvCustomerGroup').hide();
        $('#dvCriteriaCustomerCode').show();
    }
}
