var trackingUrl, customerMasterUrl, billModuleId, mrModuleId, deliveryMrModuleId, vendorBillModuleId, voucherModuleId, creditModuleId, debitModuleId, generalMasterUrl, customerBillType, vendorBllType, drDocumentDate, ddlDocumentTypeId, ddlLocationId, hdnPartyId, txtPartyCode, ddlBillTypeId, txtDocumentNos, txtManualDocumentNos, dvBillDetails, dvMrDetails, dvMrDeliveryBillDetails, dtMrDeliveryBillDetail, dvVoucherDetails, dtBillDetails, dtMrDetails, dtVoucherDetails, dvCreditDebitNoteDetails, dtCreditDebitNoteDetail, ddlPartyType, customerBillFormatMasterUrl, useTransportModeServiceType;
var dtBillPaymentDetails, Storage, LocalStorage, CloudStorage, Path;
var ruleMasterUrl
$(document).ready(function () {
    SetPageLoad('Tracking', 'Finance Document Tracking', '', '', '');
    InitObjects();
});

function InitObjects() {
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentList },
        { StepName: 'Document List' }
    ], '');

    drDocumentDate = InitDateRange('drDocumentDate', DateRange.LastWeek, false);
    ddlLocationId = $('#ddlLocationId');
    ddlDocumentTypeId = $('#ddlDocumentTypeId');
    ddlBillTypeId = $('#ddlBillTypeId');
    txtDocumentNos = $('#txtDocumentNos');
    txtManualDocumentNos = $('#txtManualDocumentNos');
    txtPartyCode = $('#txtPartyCode');
    hdnPartyId = $('#hdnPartyId');
    lblPartyName = $('#lblPartyName');
    dvBillDetails = $('#dvBillDetails');
    dvMrDetails = $('#dvMrDetails');
    dtMrDeliveryBillDetail = $('#dtMrDeliveryBillDetail');
    dvMrDeliveryBillDetails = $('#dvMrDeliveryBillDetails');
    dvVoucherDetails = $('#dvVoucherDetails');
    dtBillPaymentDetails = $('#dtBillPaymentDetails');
    dvCreditDebitNoteDetails = $('#dvCreditDebitNoteDetails');
    ddlPartyType = $('#ddlPartyType');
    $('#ddlPartyType option').eq(0).before($('<option>', { value: 0, text: 'All' }));
    ddlPartyType.val(0);
    ddlDocumentTypeId.change(OnDocumentTypeChange);
    OnDocumentTypeChange();
    ddlPartyType.change(OnPartyTypeChange);
    OnPartyTypeChange();

    $("#" + ddlBillTypeId.Id + " option:first").val(0);
    ddlBillTypeId.val(0);
}

function OnDocumentTypeChange() {
    $('#dvBillType').showHide(ddlDocumentTypeId.val() != mrModuleId && ddlDocumentTypeId.val() != deliveryMrModuleId && ddlDocumentTypeId.val() != voucherModuleId && ddlDocumentTypeId.val() != creditModuleId && ddlDocumentTypeId.val() != debitModuleId);
    $('#dvPartyType').showHide(ddlDocumentTypeId.val() == voucherModuleId);
    txtPartyCode.val('');
    hdnPartyId.val('');
    lblPartyName.text('');
    if (ddlDocumentTypeId.val() == voucherModuleId) {
        $('#lblParty').text("Party");
        txtPartyCode.autocomplete("destroy");
        txtPartyCode.off("blur");
        txtPartyCode.blur(function () { return CheckIsValid(txtPartyCode, hdnPartyId, lblPartyName); });
    }
    else {
        $('#lblParty').text("Billing Party");
        ManageBillingParty(txtPartyCode, hdnPartyId);
    }
    if (ddlDocumentTypeId.val() != "" && (ddlDocumentTypeId.val() == billModuleId || ddlDocumentTypeId.val() == creditModuleId))
        CustomerAutoComplete('txtPartyCode', 'hdnPartyId');
    else if (ddlDocumentTypeId.val() != "" && (ddlDocumentTypeId.val() == vendorBillModuleId || ddlDocumentTypeId.val() == debitModuleId))
        VendorAutoComplete('txtPartyCode', 'hdnPartyId');
    if (ddlDocumentTypeId.val() != "" && ddlDocumentTypeId.val() != mrModuleId && ddlDocumentTypeId.val() != deliveryMrModuleId) {
        var requestData = { codeTypeId: ddlDocumentTypeId.val() == billModuleId ? customerBillType : ddlDocumentTypeId.val() == vendorBillModuleId ? vendorBllType : 0 };
        AjaxRequestWithPostAndJson(generalMasterUrl + '/GetByIdList', JSON.stringify(requestData), GetBillTypeListSuccess, ErrorFunction, false);
    }
}

function ManageBillingParty(objName, objHdnId) {
    objName.off("blur");
    if (ddlDocumentTypeId.val() != "" && (ddlDocumentTypeId.val() == billModuleId || ddlDocumentTypeId.val() == mrModuleId || ddlDocumentTypeId.val() == deliveryMrModuleId || ddlDocumentTypeId.val() == creditModuleId))
        objName.blur(function () { IsCustomerCodeExist(objName, objHdnId, lblPartyName); });
    else if (ddlDocumentTypeId.val() != "" && (ddlDocumentTypeId.val() == vendorBillModuleId || ddlDocumentTypeId.val() == debitModuleId))
        objName.blur(function () { IsVendorCodeExist(objName, objHdnId, lblPartyName); });
}

function OnPartyTypeChange() {
    txtPartyCode.val('');
    lblPartyName.text('');
    hdnPartyId.val(0);
    if (ddlPartyType.val() == 1)
        UserAutoComplete('txtPartyCode', 'hdnPartyId');
    if (ddlPartyType.val() == 2)
        CustomerAutoComplete('txtPartyCode', 'hdnPartyId');
    if (ddlPartyType.val() == 3)
        VendorAutoComplete('txtPartyCode', 'hdnPartyId');
    if (ddlPartyType.val() == 5)
        DriverAutoCompleteByLocation('txtPartyCode', 'hdnPartyId');
    if (ddlPartyType.val() == 6)
        VehicleAutoComplete('txtPartyCode', 'hdnPartyId');
    if (ddlPartyType.val() == 8)
        txtPartyCode.autocomplete("destroy");
}

function CheckIsValid(objCode, objHdnId, objLbl) {
    if (ddlPartyType.val() == 1)
        IsUserNameExist(objCode, objHdnId);
    if (ddlPartyType.val() == 2)
        IsCustomerCodeExist(objCode, objHdnId, objLbl);
    if (ddlPartyType.val() == 3)
        IsVendorCodeExist(objCode, objHdnId, objLbl);
    if (ddlPartyType.val() == 5)
        IsDriverNameExistByLocation(objCode, objHdnId);
    if (ddlPartyType.val() == 6)
        IsVehicleNoExist(objCode, objHdnId);
}

function GetBillTypeListSuccess(responseData) {
    BindDropDownList('ddlBillTypeId', responseData, 'Value', 'Name', '', 'Select Bill Type');
}

function GetDocumentList() {
    dvBillDetails.hide();
    dvMrDetails.hide();
    dvVoucherDetails.hide();
    dvMrDeliveryBillDetails.hide();
    dvCreditDebitNoteDetails.hide();
    var requestData = { locationId: ddlLocationId.val(), fromDate: $.displayDate(drDocumentDate.startDate), toDate: $.displayDate(drDocumentDate.endDate) , documentNos: txtDocumentNos.val(), manualDocumentNos: txtManualDocumentNos.val(), customerId: hdnPartyId.val() == '' ? 0 : hdnPartyId.val() };
    //if (requestData.manualDocumentNos == '' && requestData.documentNos == '' && requestData.customerId == 0) {
    //    ShowMessage('Please select Billing Party');
    //    isStepValid = false;
    //    return false;
    //}
    if (ddlDocumentTypeId.val() == billModuleId) {
        requestData.billTypeId = ddlBillTypeId.val() == '' ? 0 : ddlBillTypeId.val();
        if (requestData.manualDocumentNos == '' && requestData.documentNos == '' && requestData.billTypeId == 0) {
            ShowMessage('Please select Customer Bill Type');
            isStepValid = false;
            return false;
        }
        if (requestData.billTypeId == 6) {
            AjaxRequestWithPostAndJson(trackingUrl + '/GetDeliveryMrList', JSON.stringify(requestData), function (result) {
                if (dtMrDetails == null)
                    dtMrDetails = LoadDataTable('dtMrDetails', false, false, false, null, null, [],
                        [
                            { title: 'MR No', data: 'MrNo' },
                            { title: 'Manual MR No', data: 'ManualMrNo' },
                            { title: 'MR date', data: 'MrDate' },
                            { title: 'Location', data: 'LocationCode' },
                            { title: 'Party', data: 'CustomerCode' },
                            { title: 'MR Amount', data: 'Amount' },
                            { title: 'View', data: 'View' }
                        ]);

                dtMrDetails.fnClearTable();

                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found');
                    return false;
                }
                else {
                    $.each(result, function (i, item) {
                        item.MrNo = "<input type='hidden' value='" + item.MrId + "' id='hdnMrId" + i + "'/>" + item.MrNo;
                        item.MrDate = $.displayDate(item.MrDate);
                        item.View = '<button id = "btnView' + i + '" onclick="return ViewDeliveryMrReport(' + item.MrId + ',' + deliveryMrModuleId + ',' + item.DocketId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                    });
                    dtMrDetails.dtAddData(result);
                }
                dvMrDetails.show();
            }, ErrorFunction, false);
        }
        else if (requestData.billTypeId == 8) {
            AjaxRequestWithPostAndJson(trackingUrl + '/GetMrList', JSON.stringify(requestData), function (result) {
                if (dtMrDetails == null)
                    dtMrDetails = LoadDataTable('dtMrDetails', false, false, false, null, null, [],
                        [
                            { title: 'MR No', data: 'MrNo' },
                            { title: 'Manual MR No', data: 'ManualMrNo' },
                            { title: 'MR date', data: 'MrDate' },
                            { title: 'Location', data: 'LocationCode' },
                            { title: 'Party', data: 'CustomerCode' },
                            { title: 'MR Amount', data: 'Amount' },
                            { title: 'View', data: 'View' }
                        ]);

                dtMrDetails.fnClearTable();

                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found');
                    return false;
                }
                else {
                    $.each(result, function (i, item) {
                        item.MrNo = "<input type='hidden' value='" + item.MrId + "' id='hdnMrId" + i + "'/>" + item.MrNo;
                        item.MrDate = $.displayDate(item.MrDate);
                        item.View = '<button id = "btnView' + i + '" onclick="return ViewReport(' + item.MrId + ',' + mrModuleId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                    });
                    dtMrDetails.dtAddData(result);
                }
                dvMrDetails.show();
            }, ErrorFunction, false);
        }
        else if (requestData.billTypeId == 10) {
            AjaxRequestWithPostAndJson(trackingUrl + '/GetDeliveryMrCustomerBillList', JSON.stringify(requestData), function (result) {
                if (dtBillDetails == null)
                    dtBillDetails = LoadDataTable('dtMrDeliveryBillDetail', false, false, false, null, null, [],
                        [
                            { title: 'Bill No', data: 'BillNo' },
                            { title: 'Manual Bill No', data: 'ManualBillNo' },
                            { title: 'Bill Date', data: 'BillDate' },
                            { title: 'Bill Type', data: 'BillType' },
                            { title: 'Party', data: 'CustomerCode' },
                            { title: 'Bill Amount', data: 'BillAmount' },
                            { title: 'Submition Location', data: 'SubmissionLocationCode' },
                            { title: 'Finalization Location', data: 'BillFinalizationLocationCode' },
                            { title: 'Collection Location', data: 'CollectionLocationCode' },
                            { title: 'Bill Status', data: 'BillStatus' },
                            { title: 'View', data: 'View' }
                        ]);

                dtBillDetails.fnClearTable();
                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found');
                    return false;
                }
                else {
                    $.each(result, function (i, item) {
                        item.BillNo = "<input type='hidden' value='" + item.BillId + "' id='hdnBillId" + i + "'/>" + item.BillNo;
                        item.BillDate = $.displayDate(item.BillDate);
                        item.BillStatus = item.BillStatus == 0 ? "Bill Cancelled" : item.IsFinalized == 1 && item.BillStatus == 1 ? "Bill Finalized" : item.BillStatus == 1 ? "Bill Generated" : item.BillStatus == 2 ? "Bill Submitted" : item.BillStatus == 3 ? "Bill Collected" : "";
                        item.View = '<button id = "btnView' + i + '" onclick="return ViewBill(' + item.BillId + ', ' + item.PaybasId + ',' + item.CustomerId + ',' + item.PaybasId + ',' + item.TransportModeId + ',' + item.ServiceTypeId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';

                    });
                    dtBillDetails.dtAddData(result);

                }
                dvMrDeliveryBillDetails.show();
            }, ErrorFunction, false);
        }
        else {
            var isDefaultBillView = false;
            var requestUnloadView = { moduleId: 15, ruleId: 10 };
            AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestUnloadView), function (result) {
                isDefaultBillView = result == "Y" ? true : false;
            }, ErrorFunction, false);

            var isMLPLBillView = false;
            var requestUnloadView1 = { moduleId: 15, ruleId: 10 };
            AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestUnloadView1), function (result1) {
                isMLPLBillView = result1 == "Y" ? true : false;
            }, ErrorFunction, false)
            AjaxRequestWithPostAndJson(trackingUrl + '/GetCustomerBillList', JSON.stringify(requestData), function (result) {
                if (dtBillDetails == null)
                    dtBillDetails = LoadDataTable('dtBillDetails', false, false, false, null, null, [],
                        [
                            { title: 'Bill No', data: 'BillNo' },
                            { title: 'Manual Bill No', data: 'ManualBillNo' },
                            { title: 'Bill Date', data: 'BillDate' },
                            { title: 'Bill Type', data: 'BillType' },
                            { title: 'Party', data: 'CustomerCode' },
                            { title: 'Bill Amount', data: 'BillAmount' },
                            { title: 'Submition Location', data: 'SubmissionLocationCode' },
                            { title: 'Finalization Location', data: 'BillFinalizationLocationCode' },
                            { title: 'Collection Location', data: 'CollectionLocationCode' },
                            { title: 'Bill Status', data: 'BillStatus' },
                            { title: 'View', data: 'View' },
                            { title: 'Default View', data: 'DefaultView' },
                            { title: 'MLPL View', data: 'MLPLView' },
                            { title: 'Submission View', data: 'SubmissionView' },
                            { title: 'Acknowledge Customer Bill', data: 'DocumentName' }
                            
                        ]);

                dtBillDetails.fnClearTable();
                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found');
                    return false;
                }
                else {
                    $.each(result, function (i, item) {
                        item.BillNo = "<input type='hidden' value='" + item.BillId + "' id='hdnBillId" + i + "'/><input type='hidden' value='" + item.SubmissionId + "' id='hdnSubmissionId" + i + "'/>" + item.BillNo;
                        item.BillDate = $.displayDate(item.BillDate);
                        item.BillStatus = item.BillStatus == 0 ? "Bill Cancelled" : item.IsFinalized == 1 && item.BillStatus == 1 ? "Bill Finalized" : item.BillStatus == 1 ? "Bill Generated" : item.BillStatus == 2 ? "Bill Submitted" : item.BillStatus == 3 ? "Bill Collected" : "";
                        item.View = '<button id = "btnView' + i + '" onclick="return ViewBill(' + item.BillId + ', ' + item.PaybasId + ',' + item.CustomerId + ',' + item.PaybasId + ',' + item.TransportModeId + ',' + item.ServiceTypeId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                        item.DocumentName = '<a href="#" id="hdnDocumentLink' + i + '" onclick = "return DownloadFormat(this);" >Download Acknowledge Copy </a >' +
                            "<input type='hidden' value='" + item.DocumentName + "' id='hdnDocumentName" + i + "'/>";
                        item.DefaultView = '<button id = "btnDefaultView' + i + '" onclick="return ViewDefaultBill(' + item.BillId + ', ' + item.PaybasId + ',' + item.CustomerId + ',' + item.PaybasId + ',' + item.TransportModeId + ',' + item.ServiceTypeId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                        item.MLPLView = '<button id = "btnMLPLView' + i + '" onclick="return ViewMLPLBill(' + item.BillId + ', ' + item.PaybasId + ',' + item.CustomerId + ',' + item.PaybasId + ',' + item.TransportModeId + ',' + item.ServiceTypeId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                        item.SubmissionView = '<button id = "btnSubmissionView' + i + '" onclick="return ViewSubmissionBill(' + item.SubmissionId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                    });

                    dtBillDetails.dtAddData(result);
                    var requestData1 = { moduleId: 15, ruleId: 10 };
                   
                    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData1), function (result) {
                        $('[id*="btnDefaultView"]').showHide(result == "Y" ? true : false);
                    }, ErrorFunction, false);

                    var requestData2 = { moduleId: 15, ruleId: 10 };
                  
                    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData2), function (result) {
                        $('[id*="btnMLPLView"]').showHide(result == "Y" ? true : false);
                    }, ErrorFunction, false);

                }
                $('[id*="hdnSubmissionId"]').each(function () {
                    var hdnSubmissionId = $(this);
                    var btnSubmissionView = $('#' + hdnSubmissionId.attr('id').replace('hdnSubmissionId', 'btnSubmissionView'));
                    if (hdnSubmissionId.val() === "0") {
                        btnSubmissionView.hide();
                    } else {
                        btnSubmissionView.show();
                    }
                });

                $('[id*="hdnDocumentName"]').each(function () {
                    var hdnDocumentName = $(this);
                    var hdnDocumentLink = $('#' + hdnDocumentName.attr('id').replace('hdnDocumentName', 'hdnDocumentLink'));
                    if (IsObjectNullOrEmpty(hdnDocumentName.val()) || hdnDocumentName.val() === 'null') {
                        hdnDocumentLink.hide();
                    } else {
                        hdnDocumentLink.show();
                    }
                });
                dvBillDetails.show();
            }, ErrorFunction, false);
            if (!isDefaultBillView)
                $('#dtBillDetails td:nth-child(12),th:nth-child(12)').hide();

            if (!isMLPLBillView)
                $('#dtBillDetails td:nth-child(13),th:nth-child(13)').hide()
        }
    }
    else if (ddlDocumentTypeId.val() == vendorBillModuleId) {
        requestData.billTypeId = ddlBillTypeId.val() == '' ? 0 : ddlBillTypeId.val();
        if (requestData.manualDocumentNos == '' && requestData.documentNos == '' && requestData.billTypeId == 0) {
            ShowMessage('Please select Bill Type');
            isStepValid = false;
            return false;
        }
        if (requestData.billTypeId == 6) {
            AjaxRequestWithPostAndJson(trackingUrl + '/GetVendorBillPaymentList', JSON.stringify(requestData), function (result) {
                if (dtBillDetails == null)
                    dtBillDetails = LoadDataTable('dtBillDetails', false, false, false, null, null, [],
                        [
                            { title: 'Payment No', data: 'PaymentNo' },
                            { title: 'Payment date', data: 'PaymentDate' },
                            { title: 'Location', data: 'LocationCode' },
                            { title: 'Bill Type', data: 'BillType' },
                            { title: 'Party Name', data: 'PartyName' },
                            { title: 'Payment Amount', data: 'Amount' },
                            { title: 'View', data: 'View' }
                        ]);

                dtBillDetails.fnClearTable();

                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found');
                    return false;
                }
                else {
                    $.each(result, function (i, item) {
                        item.PaymentNo = "<input type='hidden' value='" + item.PaymentId + "' id='hdnPaymentId" + i + "'/>" + item.PaymentNo;
                        item.PaymentDate = $.displayDate(item.PaymentDate);
                        item.View = '<button id = "btnView' + i + '" onclick="return ViewVendorPaymentBill(' + item.VoucherId + ',' + ddlBillTypeId.val() + ',' + item.BillTypeId + ',' + item.PaymentId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                    });
                    dtBillDetails.dtAddData(result);
                }
                dvBillDetails.show();
            }, ErrorFunction, false);
        }
        else {
            AjaxRequestWithPostAndJson(trackingUrl + '/GetVendorBillList', JSON.stringify(requestData), function (result) {
                if (dtBillDetails == null)
                    dtBillDetails = LoadDataTable('dtBillDetails', false, false, false, null, null, [],
                        [
                            { title: 'Bill No', data: 'BillNo' },
                            { title: 'Bill Date', data: 'BillDate' },
                            { title: 'Vendor Bill No', data: 'VendorBillNo' },
                            { title: 'Location', data: 'LocationCode' },
                            { title: 'Bill Type', data: 'BillType' },
                            { title: 'Party', data: 'VendorCode' },
                            { title: 'Paid Amont', data: 'PaidAmount' },
                            { title: 'Pending Amount', data: 'PendingAmount' },
                            { title: 'Bill Amount', data: 'GrandTotal' },
                            { title: 'View', data: 'View' }
                        ]);

                dtBillDetails.fnClearTable();
                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found');
                    return false;
                }
                else {
                    $.each(result, function (i, item) {
                        item.BillNo = "<input type='hidden' value='" + item.BillId + "' id='hdnBillId" + i + "'/>" + item.BillNo;
                        item.BillDate = $.displayDate(item.BillDateTime);
                        item.View = '<button id = "btnView' + i + '" onclick="return ViewVendorBill(' + item.BillId + ',' + ddlBillTypeId.val() + ',' + item.DocumentTypeId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                    });
                    dtBillDetails.dtAddData(result);
                }
                dvBillDetails.show();
            }, ErrorFunction, false);
        }
    }
    else if (ddlDocumentTypeId.val() == voucherModuleId) {
        if (ddlPartyType.val() > 0 && txtPartyCode.val() == '') {
            ShowMessage('Please select Party');
            isStepValid = false;
            return false;
        }
        else {
            var requestData = {
                locationId: ddlLocationId.val(),
                fromDate: drDocumentDate.startDate,
                toDate: drDocumentDate.endDate,
                documentNo: txtDocumentNos.val(),
                manualDocumentNo: txtManualDocumentNos.val(),
                partyType: ddlPartyType.val(),
                partyName: (ddlPartyType.val() == 2 || ddlPartyType.val() == 3) ? lblPartyName.text() : txtPartyCode
            };
            AjaxRequestWithPostAndJson(trackingUrl + '/GetVoucherList', JSON.stringify(requestData), function (result) {
                if (dtVoucherDetails == null)
                    dtVoucherDetails = LoadDataTable('dtVoucherDetails', false, false, false, null, null, [],
                        [
                            { title: 'Voucher No', data: 'VoucherNo' },
                            { title: 'Manual Voucher No', data: 'ManualVoucherNo' },
                            { title: 'Voucher date', data: 'VoucherDate' },
                            { title: 'Location', data: 'LocationCode' },
                            { title: 'Party Type', data: 'PartyType' },
                            { title: 'Party Name', data: 'PartyName' },
                            { title: 'View', data: 'View' }
                        ]);

                dtVoucherDetails.fnClearTable();

                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found');
                    return false;
                }
                else {
                    $.each(result, function (i, item) {
                        item.VoucherNo = "<input type='hidden' value='" + item.VoucherId + "' id='hdnVoucherId" + i + "'/>" + item.VoucherNo;
                        item.VoucherDate = $.displayDate(item.VoucherDate);
                        item.View = '<button id = "btnView' + i + '" onclick="return ViewVoucherReport(' + item.VoucherId + ',' + voucherModuleId + ',' + item.EntryModuleId + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                    });
                    dtVoucherDetails.dtAddData(result);
                }
                dvVoucherDetails.show();
            }, ErrorFunction, false);
        }
    }
    else if (ddlDocumentTypeId.val() == creditModuleId || ddlDocumentTypeId.val() == debitModuleId) {
        if (ddlPartyType.val() > 0 && txtPartyCode.val() == '') {
            ShowMessage('Please select Party');
            isStepValid = false;
            return false;
        }
        else {
            var requestData = {
                locationId: ddlLocationId.val(),
                fromDate: drDocumentDate.startDate,
                toDate: drDocumentDate.endDate,
                documentNo: txtDocumentNos.val(),
                manualDocumentNo: txtManualDocumentNos.val(),
                partyId: hdnPartyId.val() == '' ? 0 : hdnPartyId.val(),
                noteTypeId: ddlDocumentTypeId.val() == creditModuleId ? 1 : 2
            };
            AjaxRequestWithPostAndJson(trackingUrl + '/GetCreditDebitNoteList', JSON.stringify(requestData), function (result) {
                if (dtCreditDebitNoteDetail == null)
                    dtCreditDebitNoteDetail = LoadDataTable('dtCreditDebitNoteDetail', false, false, false, null, null, [],
                        [
                            { title: ddlDocumentTypeId.val() == creditModuleId ? 'Credit Note No' : 'Debit Note No', data: 'NoteNo' },
                            { title: ddlDocumentTypeId.val() == creditModuleId ? 'Manual Credit Note No' : 'Manual Debit Note No', data: 'ReferenceNumber' },
                            { title: ddlDocumentTypeId.val() == creditModuleId ? 'Credit Note Date' : 'Debit Note Date', data: 'NoteDate' },
                            { title: 'Location', data: 'NoteBranchName' },
                            { title: 'Party Name', data: 'PartyCodeName' },
                            { title: 'Total Amount', data: 'TotalNoteAmount' },
                            { title: 'View', data: 'View' }
                        ]);

                dtCreditDebitNoteDetail.fnClearTable();

                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found');
                    return false;
                }
                else {
                    $.each(result, function (i, item) {
                        item.NoteNo = "<input type='hidden' value='" + item.NoteId + "' id='hdnVoucherId" + i + "'/>" + item.NoteNo;
                        item.NoteDate = $.displayDate(item.NoteDate);
                        item.View = '<button id = "btnView' + i + '" onclick="return ViewReport(' + item.NoteId + ' , ' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                            '<span class="glyphicon glyphicon-eye-open"></span>' +
                            '</button>';
                    });
                    dtCreditDebitNoteDetail.dtAddData(result);
                }
                dvCreditDebitNoteDetails.show();
            }, ErrorFunction, false);
        }
    }
    return false;
}


function ViewReport(value, moduleId) {
    return ShowViewPrint(moduleId, value);
}

function ViewDeliveryMrReport(value, moduleId, docketId) {
    var prmList = [{ Name: "MrId", Value: value },
    { Name: "DocketId", Value: docketId }];
    var reportInfo = { PrmList: prmList, Name: 'MRGatePassViewPrint', Description: 'Delivery MR View' };
    return ShowReport(reportInfo);
}

function ViewBill(value, billType, customerId, paybasId, transportModeId, serviceTypeId) {
    var billFormat = 'CustomerBillView';
    var requestData = { customerId: customerId, paybasId: paybasId, transportModeId: transportModeId, serviceTypeId: serviceTypeId };
    AjaxRequestWithPostAndJson(customerBillFormatMasterUrl + '/GetBillFormatByCustomerId', JSON.stringify(requestData), function (result) {
        if (!IsObjectNullOrEmpty(result))
            billFormat = result.Name;
    }, ErrorFunction, false);

    var prmList = [{ Name: "BillId", Value: value }];
    if (billType == 7) {
        var reportInfo = { PrmList: prmList, Name: 'CustomerSuppBillDetailView', Description: 'Supplementary Bill View' };
        return ShowReport(reportInfo);
    }
    else if (billType == 9) {
        var prmList = [{ Name: "TripsheetBillId", Value: value }];
        var reportInfo = { PrmList: prmList, Name: 'CustomerBillViewforLongHall', Description: 'Trip Bill View' };
        return ShowReport(reportInfo);
    }
    else {

        var reportInfo = { PrmList: prmList, Name: billFormat, Description: 'Customer Bill View' };
        return ShowReport(reportInfo);

    }
}

function ViewDefaultBill(value, billType, customerId, paybasId, transportModeId, serviceTypeId) {

    var prmList = [{ Name: "BillId", Value: value }];
    var reportInfo = { PrmList: prmList, Name: 'CustomerBillView5', Description: 'Customer Bill View' };
    return ShowReport(reportInfo);

}
function ViewMLPLBill(value, billType, customerId, paybasId, transportModeId, serviceTypeId) {

    var prmList = [{ Name: "BillId", Value: value }];
    var reportInfo = { PrmList: prmList, Name: 'CustomerBillView1', Description: 'MLPL Bill View' };
    return ShowReport(reportInfo);

}

function ViewSubmissionBill(value) {

    var prmList = [{ Name: "SubmissionId", Value: value }];
    var reportInfo = { PrmList: prmList, Name: 'CustomerBillSubmissionViewPrint', Description: 'Customer Bill Submission View Print' };
    return ShowReport(reportInfo);

}

function ViewVendorBill(value, billType, documentTypeId) {
    var prmList = [{ Name: "BillId", Value: value }];
    if (documentTypeId == 13) {
        var reportInfo = { PrmList: prmList, Name: 'VendorFuelBillDetailViewPrint', Description: 'Vendor Bill Detail View' };
        return ShowReport(reportInfo);
    }
    if (billType == 2) {
        var reportInfo = { PrmList: prmList, Name: 'VendorOtherBillView', Description: 'Vendor Bill Detail View' };
        return ShowReport(reportInfo);
    }
    else if (billType == 5) {
        var reportInfo = { PrmList: prmList, Name: 'VendorTplBillView', Description: 'Vendor Bill Detail View' };
        return ShowReport(reportInfo);
    }
    else {
        var reportInfo = { PrmList: prmList, Name: 'VendorBillDetailViewPrint', Description: 'Vendor Bill Detail View' };
        return ShowReport(reportInfo);
    }
}

function ViewVoucherReport(value, moduleId, entryModuleId) {
    /* if (entryModuleId == 6) {
         
         var prmList = [{ Name: "VoucherId", Value: value }];
         var reportInfo = { PrmList: prmList, Name: 'VehicleHireBillAdvancePaymentView', Description: 'Vendor Bill Detail View' };
         return ShowReport(reportInfo);
     }
     else if (entryModuleId == 6 || entryModuleId == 7) {
     
         var prmList = [{ Name: "VoucherId", Value: value }];
         var reportInfo = { PrmList: prmList, Name: 'VehicleHireBillPaymentView', Description: 'Vendor Bill Detail View' };
         return ShowReport(reportInfo);
     }
     else if (entryModuleId == 13) {
         
         var prmList = [{ Name: "VoucherId", Value: value }];
         var reportInfo = { PrmList: prmList, Name: 'CreditDebitVoucherView', Description: 'Vendor Bill Detail View' };
         return ShowReport(reportInfo);
     }
     else
         
         return ShowViewPrint(moduleId, value);
         */
    var prmList = [{ Name: "VoucherId", Value: value }];
    var reportInfo = { PrmList: prmList, Name: 'VoucherDetailView', Description: 'Voucher View' };
    return ShowReport(reportInfo);
}
function ViewVendorPaymentBill(value, billType, BillTypeId, paymentId) {
    var prmList = [{ Name: "VoucherId", Value: value }];
    if (billType == 6 && BillTypeId == 5) {
        var prmList = [{ Name: "VoucherId", Value: value }];
        var reportInfo = { PrmList: prmList, Name: 'VehicleHireBillAdvancePaymentView', Description: 'Vendor Bill Detail View' };
        return ShowReport(reportInfo);
    }
    else {
        var prmList = [{ Name: "VendorBillPaymentId", Value: paymentId }];
        var reportInfo = { PrmList: prmList, Name: 'VendorBillPaymentView', Description: 'Vendor Bill Detail View' };
        return ShowReport(reportInfo);
    }

}
function DownloadFormat(objLink) {
    var hdnDocumentLink = objLink;
    var hdnDocumentName = $('#' + hdnDocumentLink.id.replace('hdnDocumentLink', 'hdnDocumentName'));
    var filePath = '';
    if (Storage == 'True')
        filePath = LocalStorage;
    else
        filePath = CloudStorage;
    filePath = PodUrl + 'Storage/POD/';
    /*window.location = filePath + hdnDocumentName.val();*/


    var a = document.createElement('a');
    a.href = filePath + hdnDocumentName.val();
    a.download = hdnDocumentName.val();
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);

    return false;
}