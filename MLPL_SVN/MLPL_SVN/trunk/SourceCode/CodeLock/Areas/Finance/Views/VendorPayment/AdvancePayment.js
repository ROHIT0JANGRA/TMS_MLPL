var txtVendorCodeHeader, hdnVendorId, txtVendorCode, txtVendorName, txtDocumentNo, txtManualNo, ddlTransportModeId, chkDocumentType, drTransactionDate, lblVendorNameStep2, lblVendorNameStep3, dtDocumentList, selectedDocumentList,
    locationId, vendorMasterUrl, vendorPaymentUrl, dtDocumentDetailsList, SelectedDocumentDetailType, totalAmount = 0.00, lblVendorName;
var tdsRate, tdsAccountId;
$(document).ready(function () {
    SetPageLoad('Vendor', 'Advance Payment', 'txtVendorName', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentListForPayment },
        { StepName: 'Document List', StepFunction: GetDocumentDetailsForPayment },
        { StepName: 'Advance Detail', StepFunction: GetTotalAdvanceAmount },
        { StepName: 'Advance Payment' }
    ], 'Advance Payment');
    txtBAMappedLocation = $('#txtBAMappedLocation'); hdnBAMappedLocationid = $('#hdnBAMappedLocationid')
    txtVendorCode = $('#txtVendorCode');
    txtVendorName = $('#txtVendorName');
    hdnVendorId = $('#hdnVendorId');
    lblVendorName = $('#lblVendorName');
    txtDocumentNo = $('#txtDocumentNo');
    txtManualNo = $('#txtManualNo');
    lblVendorNameStep2 = $('#lblVendorNameStep2');
    lblVendorNameStep3 = $('#lblVendorNameStep3');
    ddlTransportModeId = $('#ddlTransportModeId');
    chkDocumentType = $('#chkDocumentType');
    drTransactionDate = InitDateRange('drTransactionDate', DateRange.LastWeek);
    InitMultiSelect(ddlTransportModeId.Id, true, true, true);
    LocationAutoComplete('txtBAMappedLocation', 'hdnBAMappedLocationid');
    txtBAMappedLocation.blur(function () { IsLocationCodeExist(txtBAMappedLocation, hdnBAMappedLocationid); });
    chkIsTDSApplicable = $('#chkIsTDSApplicable');
    txtPaymentTdsAmount = $('#txtPaymentTdsAmount');
    ddlPaymentTdsAccount = $('#ddlPaymentTdsAccount');
}


function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { return IsVendorCodeExist(txtVendorCode, hdnVendorId, lblVendorName); });
    txtVendorCode.blur(function () {
        if (hdnVendorId.val() > 1) {
            var requestData = { vendorId: hdnVendorId.val() };
            AjaxRequestWithPostAndJson(vendorMasterUrl + '/GetById', JSON.stringify(requestData), function (result) {
                tdsRate = result.MasterVendorDetail.TDSRate;
                tdsAccountId = result.MasterVendorDetail.TdsAccountId;
                ddlPaymentTdsAccount.val(result.MasterVendorDetail.TdsAccountId);
            });
        }
    });
    chkIsTDSApplicable.click(function () {
        OnIsTDSApplicableClick();
    });
    OnIsTDSApplicableClick();
}

function OnIsTDSApplicableClick() {
    txtPaymentTdsAmount.readOnly(true);
    $('#dvTdsDetails').showHide(chkIsTDSApplicable.IsChecked);
}

function GetDocumentListForPayment() {
    var selectedValues = [];
    $("[id*=chkDocumentType]").each(function () {
        var chkDocumentType = $(this);
        if (chkDocumentType.IsChecked == true)
            selectedValues.push($('#' + chkDocumentType.Id.replace('chkDocumentType', 'hdnCodeId')).val());
    });

    var isTDSApplicable = chkIsTDSApplicable.is(":checked") ? 1 : 0;
    var requestData = { VendorId: hdnVendorId.val(), LocationId: locationId, BAMappedLocationid: hdnBAMappedLocationid.val(), fromDate: $.displayDate(drTransactionDate.startDate), toDate: $.displayDate(drTransactionDate.endDate), DocumentNo: txtDocumentNo.val(), ManualNo: txtManualNo.val(), SelectedDocumentType: selectedValues.join(','), IsTDSApplicable: isTDSApplicable };
    //var requestData = { VendorId: hdnVendorId.val(), LocationId: locationId, fromDate: drTransactionDate.startDate, toDate: drTransactionDate.endDate, DocumentNo: txtDocumentNo.val(), ManualNo: txtManualNo.val(), TransportModeIdList: ddlTransportModeId.multiVal() != '' ? ddlTransportModeId.multiVal() : 0, SelectedDocumentType: selectedValues.join(',') };

    AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetDocumentListForAdvancePayment', JSON.stringify(requestData), function (result) {
        if (dtDocumentList == null)
            dtDocumentList = LoadDataTable('dtDocumentList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllDocument', SelectDocument), data: "DocumentId", width: 80 },
                    { title: 'Document No', data: 'DocumentNo' },
                    { title: 'Manual No', data: 'ManualDocumentNo' },
                    { title: 'Document Type', data: 'DocumentType' },
                    { title: 'Vehicle No', data: 'VehicleNo' },
                    { title: 'FTL Type', data: 'FtlType' },
                    { title: 'Document Date', data: 'DocumentDate' },
                    { title: 'Location', data: 'DocumentLocation' },
                    { title: 'Route', data: 'RouteName' }
                ]);

        dtDocumentList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.DocumentId = SelectAll.GetChk('chkAllDocument', 'chkDocument' + i, 'Details[' + i + '].IsChecked', SelectDocument) +
                    "<input type='hidden' value='" + item.DocumentId + "' name='Details[" + i + "].DocumentId' id='hdnDocumentId" + i + "'/>" +
                    "<label class='label' for='chkDocument" + i + "' id='lblDocumentId" + i + "'></label>" +
                    "<input type='hidden' value='" + item.DocumentTypeId + "' name='Details[" + i + "].DocumentType' id='hdnDocumentTypeId" + i + "'/>";

                item.DocumentDate = $.displayDate(item.DocumentDate);
            });
            lblVendorNameStep2.text(txtVendorCode.val() + ' : ' + lblVendorName.text());
            dtDocumentList.dtAddData(result);
        }
    }, ErrorFunction, false);
    return false;
}

function SelectDocument() {
    var selectedValues = [];
    $("[id*=chkDocumentType]").each(function () {
        var chkDocumentType = $(this);
        if (chkDocumentType.IsChecked == true)
            selectedValues.push($('#' + chkDocumentType.Id.replace('chkDocumentType', 'hdnCodeId')).val());
    });
}

function ValidateMultiCheckBox(partialId, entityName) {
    var selected = false, firstCheckBox = null;
    $('[id*="' + partialId + '"]').each(function () {
        if (firstCheckBox == null)
            firstCheckBox = $(this);
        if ($(this).is(':checked'))
            selected = true;
    });
    if (!selected) {
        ShowMessage("Please select at-least one " + entityName);
        firstCheckBox.focus();
        return false;
    }
    return true;
}

function GetDocumentDetailsForPayment() {
    selectedDocumentList = [];
    $('[id*="hdnDocumentId"]').each(function () {
        var hdnDocumentId = $(this);
        var chkDocument = $('#' + hdnDocumentId.Id.replace('hdnDocumentId', 'chkDocument'));
        if (chkDocument.IsChecked) {
            selectedDocumentList.push({ 'DocumentId': $('#' + chkDocument.Id.replace('chkDocument', 'hdnDocumentId')).val(), 'DocumentTypeId': parseInt($('#' + chkDocument.Id.replace('chkDocument', 'hdnDocumentTypeId')).val()), BAMappedLocationid: hdnBAMappedLocationid.val() });
        }
    });

    if (selectedDocumentList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Document');
        return false;
    }
    else {
        //alert(selectedDocumentList['DocumentId'].Value);


        AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetDocumentDetailForAdvancePayment', JSON.stringify(selectedDocumentList), function (result) {

            if (dtDocumentDetailsList == null)
                dtDocumentDetailsList = LoadDataTable('dtDocumentDetailsList', false, false, false, null, null, [],
                    [
                        { title: 'Document No', data: 'DocumentNo' },
                        { title: 'Contract Amount (+)', data: 'ContractAmount' },
                        { title: 'Total Advance Amount', data: 'TotalAdvanceAmount' },
                        { title: 'Advance Amount Paid(-)', data: 'AdvanceAmountPaidOthrLoc' },
                        { title: 'Balance Amount', data: 'BalanceAmount' },
                        { title: 'Advance Amount (-)', data: 'AdvanceAmount' },
                        { title: 'Other Amount (+)', data: 'OtherAmount' },
                        { title: 'TDS Amount (-)', data: 'TDSAmount' }
                    ]);

            dtDocumentDetailsList.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                $.each(result, function (i, item) {
                    item.DocumentNo = '<input type=\'text\' name="AdvanceDetails[' + i + '].DocumentNo" id="txtDocumentNo' + i + '" value=' + item.DocumentNo + ' class="form-control textlabel" style="width:300px !important" tabindex="0"/>' +
                        '<input type=\'hidden\' value=' + item.DocumentId + ' name=\'AdvanceDetails[' + i + '].DocumentId\' id=\'hdnDocumentId' + i + '\'/>' +
                        '<input type=\'hidden\' value=' + item.DocumentTypeId + ' name=\'AdvanceDetails[' + i + '].DocumentTypeId\' id=\'hdnDocumentTypeId' + i + '\'/>' +
                        '<input type=\'hidden\' value=' + item.AdvanceAmount + ' id=\'hdnAdvAmount' + i + '\'/>';
                    item.ContractAmount = '<input type=\'text\' name="AdvanceDetails[' + i + '].ContractAmount" id="txtContractAmount' + i + '" value=' + item.ContractAmount + ' class="form-control textlabel numeric2" tabindex="0"/>';
                    item.TotalAdvanceAmount = '<input type=\'text\' name="AdvanceDetails[' + i + '].TotalAdvanceAmount" id="txtTotalAdvanceAmount' + i + '" value=' + item.TotalAdvanceAmount + ' class="form-control textlabel numeric2" tabindex="0"/>';
                    item.AdvanceAmountPaidOthrLoc = '<input type=\'text\' name="AdvanceDetails[' + i + '].AdvanceAmountPaidOthrLoc" id="txtAmountPaidOthrLoc' + i + '" value=' + item.AdvanceAmountPaidOthrLoc + ' class=" form-control textlabel numeric2" tabindex="0"/>';
                    item.BalanceAmount = '<input type=\'text\' name="AdvanceDetails[' + i + '].BalanceAmount" id="txtBalanceAmount' + i + '" value=' + item.BalanceAmount + ' class=" form-control textlabel numeric2" tabindex="0"/>';
                    item.AdvanceAmount = '<input type=\'text\' name="AdvanceDetails[' + i + '].AdvanceAmount" id="txtAdvanceAmount' + i + '" value=' + item.AdvanceAmount + ' class=" form-control numeric2" tabindex="0"/>';
                    item.OtherAmount = '<input type=\'text\' name="AdvanceDetails[' + i + '].OtherAmount" id="txtOtherAmount' + i + '" value=' + item.OtherAmount + ' class=" form-control textlabel numeric2" tabindex="0"/>';
                    item.TDSAmount = '<input type=\'text\' name="AdvanceDetails[' + i + '].TDSAmount" id="txtTDSAmount' + i + '" value=' + item.TDSAmount + ' class=" form-control textlabel numeric2" tabindex="0"/>';
                });
                // txtVendorCode.val(txtVendorCodeHeader.val());
                dtDocumentDetailsList.dtAddData(result, [], InitDocumentDetailTable);
                dtDocumentDetailsList.removeClass('dataTable');
            }
        }, ErrorFunction, false);
        return false;
    }
}

function InitDocumentDetailTable() {
    $('[id*="txtAdvanceAmount"]').each(function () {
        var txtAdvanceAmount = $(this);
        var hdnAdvAmount = $('#' + txtAdvanceAmount.Id.replace('txtAdvanceAmount', 'hdnAdvAmount'));
        var txtTDSAmount = $('#' + txtAdvanceAmount.Id.replace('txtAdvanceAmount', 'txtTDSAmount'));

        txtAdvanceAmount.blur(function () {
            if (parseFloat(txtAdvanceAmount.val()) > parseFloat(hdnAdvAmount.val())) {
                ShowMessage('Advance Amount is less than or equal to ' + hdnAdvAmount.val());
                txtAdvanceAmount.val(0);
                txtTDSAmount.val(0);
                isStepValid = false;
                return false;
            }
            else if (parseFloat(txtAdvanceAmount.val()) == 0) {
                ShowMessage('Please enter Advance Amount');
                isStepValid = false;
                txtAdvanceAmount.val(0);
                txtTDSAmount.val(0);
                return false;
            }
            else {
                if (chkIsTDSApplicable.IsChecked) {
                    txtTDSAmount.val((parseFloat(txtAdvanceAmount.val()) * tdsRate) / 100);
                }
                else {
                    txtTDSAmount.val(0);
                }
            }
        });
    });
}



function GetTotalAdvanceAmount() {
    totalAmount = 0.00;
    totalTdsAmount = 0.00;
    var isAdvanceAmountValid = true;
    $('[id*="txtAdvanceAmount"]').each(function () {
        var txtAdvanceAmount = $(this);
        var hdnAdvAmount = $('#' + txtAdvanceAmount.Id.replace('txtAdvanceAmount', 'hdnAdvAmount'));
        if (parseFloat(txtAdvanceAmount.val()) > parseFloat(hdnAdvAmount.val())) {
            isAdvanceAmountValid = false;
        }
        else if (parseFloat(txtAdvanceAmount.val()) == 0) {
            isAdvanceAmountValid = false;
        }
    });
    if (!isAdvanceAmountValid) {
        isStepValid = false;
        return false;
    }
    else {
        $('[id*="txtAdvanceAmount"]').each(function () {
            var txtAdvanceAmount = $(this);
            var txtTDSAmount = $('#' + txtAdvanceAmount.Id.replace('txtAdvanceAmount', 'txtTDSAmount'));
            totalAmount += parseFloat(txtAdvanceAmount.val());
            totalTdsAmount += parseFloat(txtTDSAmount.val());
        });
        SetPaymentPartyTypeAndParty(3, hdnVendorId.val());
        /*txtPaymentAmountApplicable.val(totalAmount.toFixed(2)).blur();*/
        txtPaymentAmountApplicable.val((totalAmount - totalTdsAmount).toFixed(2)).blur();
        txtPaymentTdsAmount.val(totalTdsAmount).blur();
    }
}