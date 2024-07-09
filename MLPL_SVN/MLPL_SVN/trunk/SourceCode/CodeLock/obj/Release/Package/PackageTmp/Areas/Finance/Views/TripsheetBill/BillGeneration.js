//var hdnCustomerId, lblCustomerName, ddlServiceTypeId, ddlPrimaryBillingTypeId, ddlTransactionTypeId, ddlGstServiceTypeId,
//    txtBillDate, txtDueDate, dtTripsheetList, selectedTripsheetList, customerMasterUrl, customerBillGenerationUrl, ddlCustomerGstStateId,
//    lblLocationCode, loginLocationCode, TripsheetTotal, TripsheetNomenclature, gstMasterUrl, ddlCompanyGstStateId, customerContractMasterUrl, customerSupBillUrl;
var txtCustomerCode, hdnCustomerId, txtCustomerCode, drTripsheetDate, ddlFtlTypeId, hdnVehicleId, txtVehicleNo, hdnBillGenerationLocationId, txtBillGenerationLocationCode, hdnBillSubmissionLocationId, txtBillSubmissionLocationCode, hdnBillCollectionLocationId, txtBillCollectionLocationCode, hdnSacId, txtSacCode, txtGstRate, lblIsRcm, txtCustomerGstStateGstTinNo, txtCompanyGstStateGstTinNo,
    ddlCompanyGstStateId, ddlCustomerGstStateId;
var baseUrl, gstMasterUrl, cityMasterUrl;
var dtTripsheetList, selectedTripsheetList;
var allowMandatoryManualBillNo = false;

$(document).ready(function () {
    InitObjects();
    AttachEvents();
    SetPageLoad('Customer', 'Billing', '', '', '');
});

function InitObjects() {
    txtCustomerCode = $('#txtCustomerCode');
    hdnCustomerId = $('#hdnCustomerId');
    lblCustomerName = $('#lblCustomerName');
    ddlFtlTypeId = $('#ddlFtlTypeId');
    hdnVehicleId = $('#hdnVehicleId');
    txtVehicleNo = $('#txtVehicleNo');
    hdnBillGenerationLocationId = $('#hdnBillGenerationLocationId');
    txtBillGenerationLocationCode = $('#txtBillGenerationLocationCode');
    hdnBillSubmissionLocationId = $('#hdnBillSubmissionLocationId');
    txtBillSubmissionLocationCode = $('#txtBillSubmissionLocationCode');
    hdnBillCollectionLocationId = $('#hdnBillCollectionLocationId');
    txtBillCollectionLocationCode = $('#txtBillCollectionLocationCode');
    hdnSacId = $('#hdnSacId');
    txtSacCode = $('#txtSacCode');
    txtGstRate = $('#txtGstRate');
    lblIsRcm = $('#lblIsRcm');
    ddlCustomerGstStateId = $('#ddlCustomerGstStateId');
    ddlCompanyGstStateId = $('#ddlCompanyGstStateId');
    txtCustomerGstStateGstTinNo = $('#txtCustomerGstStateGstTinNo');
    txtCompanyGstStateGstTinNo = $('#txtCompanyGstStateGstTinNo');
    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek, false);

    InitWizard('dvWizard', [
        { StepName: 'Criteria'  },
        { StepName: 'Bill Detail', StepFunction: GetTripsheetList},
        { StepName: 'Tripsheet List For Bill Generation', StepFunction: ValidateOnSubmit }
    ], 'Bill Generate');
}

function AttachEvents() {
    CustomerAutoComplete('txtCustomerCode', 'hdnCustomerId');
    txtCustomerCode.blur(function () {
        IsCustomerCodeExist(txtCustomerCode, hdnCustomerId, lblCustomerName);
        if (hdnCustomerId.val() > 0 && hdnBillGenerationLocationId.val() > 0) {
            GetCustomerGstState();
        }
        else {
            BindDropDownList('ddlCustomerGstStateId', [], null, null, '', 'Select State');
            txtCustomerCode.focus();
        }
    });
    VehicleAutoComplete('txtVehicleNo', 'hdnVehicleId');
    txtVehicleNo.blur(function () { return IsVehicleNoExist(txtVehicleNo, hdnVehicleId); });
    LocationAutoComplete('txtBillGenerationLocationCode', 'hdnBillGenerationLocationId');
    txtBillGenerationLocationCode.blur(function () {
        IsLocationCodeExist(txtBillGenerationLocationCode, hdnBillGenerationLocationId);
        if (hdnBillGenerationLocationId.val() > 0) {
            GetCustomerGstState();
        }
        else {
            BindDropDownList('ddlCustomerGstStateId', [], null, null, '', 'Select State');
            txtBillGenerationLocationCode.focus();
        }
    });
    LocationAutoComplete('txtBillSubmissionLocationCode', 'hdnBillSubmissionLocationId');
    txtBillSubmissionLocationCode.blur(function () {
        IsLocationCodeExist(txtBillSubmissionLocationCode, hdnBillSubmissionLocationId);
        if (hdnBillSubmissionLocationId.val() > 0) {
            GetCompanyGstState()
        }
        else {
            BindDropDownList('ddlCompanyGstStateId', [], null, null, '', 'Select State');
            txtBillSubmissionLocationCode.focus();
        }
    });
    LocationAutoComplete('txtBillCollectionLocationCode', 'hdnBillCollectionLocationId');
    txtBillCollectionLocationCode.blur(function () { return IsLocationCodeExist(txtBillCollectionLocationCode, hdnBillCollectionLocationId); });
    SacAutoComplete('txtSacCode', 'hdnSacId');
    txtSacCode.blur(function () {
        IsSacCodeExist(txtSacCode, hdnSacId);
        if (hdnSacId.val() > 0) {
            var requestData = { id: hdnSacId.val() };
            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetDetailById', JSON.stringify(requestData), function (result) {
                txtGstRate.val(result.GstRate);
                lblIsRcm.text(result.IsRcm ? 'YES' : 'NO');
            }, ErrorFunction, false);
        }
        else {
            txtGstRate.val(0);
            lblIsRcm.text('');
            txtSacCode.focus();
        }
    });
    var requestData = { moduleId: 15, ruleId: 4 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        allowMandatoryManualBillNo = (result == "Y" ? true : false);
    }, ErrorFunction, false);
    if (allowMandatoryManualBillNo)
        AddRequired($('#txtManualBillNo'), 'Please enter Manual BillNo');
    ddlCompanyGstStateId.change(OnCompanyGstStateChange);
    ddlCustomerGstStateId.change(OnCustomerGstStateChange);
}

function GetCustomerGstState() {
    var requestData = { ownerType: 3, ownerId: hdnCustomerId.val(), locationId: hdnBillGenerationLocationId.val() };
    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstStateList', JSON.stringify(requestData), function (responseData) {
        BindDropDownList(ddlCustomerGstStateId.Id, responseData, 'Description', 'Name', '', (responseData.length > 1 ? 'Select Party GST State' : ''));
    }, ErrorFunction, false);
}

function OnCustomerGstStateChange() {
    if (ddlCustomerGstStateId.val() != '' && hdnCustomerId.val() != 1) {
        requestData = { ownerType: 3, ownerId: hdnCustomerId.val(), stateId: ddlCustomerGstStateId.val(), locationId: hdnBillGenerationLocationId.val() };
        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailsByOwnerTypeAndOwnerAndStateAndLocation', JSON.stringify(requestData), function (result) {
            $('#hdnCustomerGstId').val(result.GstId);
            $('#txtCustomerGstStateGstTinNo').val(result.GstTinNo);
        }, ErrorFunction, false);
    }
}

function GetCompanyGstState() {
    var requestData = { ownerType: 1, ownerId: loginCompanyId, locationId: hdnBillSubmissionLocationId.val() };
    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstStateList', JSON.stringify(requestData), function (responseData) {
        BindDropDownList(ddlCompanyGstStateId.Id, responseData, 'Description', 'Name', '', (responseData.length > 1 ? 'Select Party GST State' : ''));
    }, ErrorFunction, false);
}

function OnCompanyGstStateChange() {
    if (ddlCompanyGstStateId.val() != '') {
        requestData = { ownerType: 1, ownerId: loginCompanyId, stateId: ddlCompanyGstStateId.val(), locationId: hdnBillSubmissionLocationId.val() };
        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailsByOwnerTypeAndOwnerAndStateAndLocation', JSON.stringify(requestData), function (result) {
            $('#hdnCompanyGstId').val(result.GstId);
            $('#txtCompanyGstStateGstTinNo').val(result.GstTinNo);
        }, ErrorFunction, false);
    }
}

function GetTripsheetList() {
    var requestData = { customerId: hdnCustomerId.val(), fromDate: drTripsheetDate.startDate, toDate: drTripsheetDate.endDate, ftlTypeId: ddlFtlTypeId.val() == '' ? 0 : ddlFtlTypeId.val(), vehicleId: txtVehicleNo.val() == '' ? 0 : hdnVehicleId.val(), generationLocationId: hdnBillGenerationLocationId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetTripsheettListForBillGeneration', JSON.stringify(requestData), function (result) {
        selectedTripsheetList = [];

        if (dtTripsheetList == null)
            dtTripsheetList = LoadDataTable('dtTripsheetList', false, false, false, null, null, [],
                [
                    { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllTripsheet', SelectTripsheet) + "</div>", data: "TripsheetId", width: 80 },
                    { title: 'Tripsheet No', data: 'TripsheetNo' },
                    { title: 'AC KM', data: 'AcKm' },
                    { title: 'Non AC KM', data: 'NonAcKm' },
                    { title: 'Empty KM', data: 'EmptyKm' },
                    { title: 'AC', data: 'FixedAcRate' },
                    { title: 'Non AC', data: 'FixedNonAcRate' },
                    { title: 'Empty', data: 'FixedEmptyRate' },
                    { title: 'AC', data: 'VariableAcRate' },
                    { title: 'Non AC', data: 'VariableNonAcRate' },
                    { title: 'Variable', data: 'VariableEmptyRate' },
                    { title: 'Gross Amount', data: 'GrossAmount' },
                    { title: 'GST Amount', data: 'GstAmount' },
                    { title: 'Total Amount', data: 'TotalAmount' }
                ]);

        dtTripsheetList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.TripsheetId = SelectAll.GetChk('chkAllTripsheet', 'chkTripsheet' + i, 'Details[' + i + '].IsChecked', SelectTripsheet) +
                    "<input type='hidden' value='" + item.TripsheetId + "' name='Details[" + i + "].TripsheetId' id='hdnTripsheetId" + i + "'/>" +
                    "<label class='label' for='chkTripsheet" + i + "' id='lblTripsheetId" + i + "'></label>";
                item.AcKm = '<input type=\'text\' name="Details[' + i + '].AcKm" id="txtAcKm' + i + '" value=' + item.AcKm.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.NonAcKm = '<input type=\'text\' name="Details[' + i + '].NonAcKm" id="txtNonAcKm' + i + '" value=' + item.NonAcKm.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.EmptyKm = '<input type=\'text\' name="Details[' + i + '].EmptyKm" id="txtEmptyKm' + i + '" value=' + item.EmptyKm.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.FixedAcRate = '<input type=\'text\' name="Details[' + i + '].FixedAcRate" id="txtFixedAcRate' + i + '" value=' + item.FixedAcRate.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.FixedNonAcRate = '<input type=\'text\' name="Details[' + i + '].FixedNonAcRate" id="txtFixedNonAcRate' + i + '" value=' + item.FixedNonAcRate.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.FixedEmptyRate = '<input type=\'text\' name="Details[' + i + '].FixedEmptyRate" id="txtFixedEmptyRate' + i + '" value=' + item.FixedEmptyRate.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.VariableAcRate = '<input type=\'text\' name="Details[' + i + '].VariableAcRate" id="txtVariableAcRate' + i + '" value=' + item.VariableAcRate.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.VariableNonAcRate = '<input type=\'text\' name="Details[' + i + '].VariableNonAcRate" id="txtVariableNonAcRate' + i + '" value=' + item.VariableNonAcRate.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.VariableEmptyRate = '<input type=\'text\' name="Details[' + i + '].VariableEmptyRate" id="txtVariableEmptyRate' + i + '" value=' + item.VariableEmptyRate.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.GrossAmount = '<input type=\'text\' name="Details[' + i + '].GrossAmount" id="txtGrossAmount' + i + '" value=' + item.GrossAmount.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.GstAmount = '<input type=\'text\' name="Details[' + i + '].GstAmount" id="txtGstAmount' + i + '" value=' + item.GstAmount.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                item.TotalAmount = '<input type=\'text\' name="Details[' + i + '].TotalAmount" id="txtTotalAmount' + i + '" value=' + item.TotalAmount.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
            });
            dtTripsheetList.dtAddData(result);
            dtTripsheetList.removeClass('dataTable')
        }
    }, ErrorFunction, false);
}

function SelectTripsheet() {
    selectedTripsheetList = [];
    var subTotal = 0, gstTotal = 0, total = 0;
    $('[id*="chkTripsheet"]').each(function () {
        var chkTripsheet = $(this);
        var txtAcKm = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtAcKm'));
        var txtNonAcKm = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtNonAcKm'));
        var txtEmptyKm = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtEmptyKm'));
        var txtFixedAcRate = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtFixedAcRate'));
        var txtFixedNonAcRate = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtFixedNonAcRate'));
        var txtFixedEmptyRate = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtFixedEmptyRate'));
        var txtVariableAcRate = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtVariableAcRate'));
        var txtVariableNonAcRate = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtVariableNonAcRate'));
        var txtVariableEmptyRate = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtVariableEmptyRate'));
        var txtGrossAmount = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtGrossAmount'));
        var txtGstAmount = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtGstAmount'));
        var txtTotalAmount = $('#' + chkTripsheet.Id.replace('chkTripsheet', 'txtTotalAmount'));
        if (chkTripsheet.IsChecked) {
            selectedTripsheetList.push($('#' + chkTripsheet.Id.replace('chkTripsheet', 'hdnTripsheetId')).val());
            txtGrossAmount.val(parseFloat(txtFixedAcRate.val()) + parseFloat(txtFixedNonAcRate.val()) + parseFloat(txtFixedEmptyRate.val()) + parseFloat(txtVariableAcRate.val()) + parseFloat(txtVariableNonAcRate.val()) + parseFloat(txtVariableEmptyRate.val()));
            subTotal = subTotal + parseFloat(txtGrossAmount.val());
            if (lblIsRcm.text() == 'NO')
                txtGstAmount.val(((parseFloat(txtGrossAmount.val()) * parseFloat(txtGstRate.val())) / 100));
            else
                txtGstAmount.val(0);
            gstTotal = gstTotal + parseFloat(txtGstAmount.val());
            txtTotalAmount.val(parseFloat(txtGrossAmount.val()) + parseFloat(txtGstAmount.val()));
            total = total + parseFloat(txtTotalAmount.val());
        }
    });

    $('#lblSubTotal').text(subTotal.toFixed(2));
    $('#hdnSubTotal').val(subTotal);

    gstTotal = gstTotal.toFixed(2);
    $('#lblGstTotal').text(gstTotal);
    $('#hdnGstTotal').val(gstTotal);

    total = total.toFixed(2);
    $('#lblTotal').text(total);
    $('#hdnTotal').val(total);
}

function ValidateOnSubmit() {
    if (selectedTripsheetList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Tripsheet');
        return false;
    }
}