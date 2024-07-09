var txtCustomerCode, ddlPaybasId, hdnCustomerId, lblCustomerName, ddlServiceTypeId, ddlFtlTypeId, ddlPrimaryBillingTypeId, ddlTransactionTypeId, ddlGstServiceTypeId,
    txtBillDate, txtDueDate, drTransactionDate, dtDocketList, selectedDocketList, customerMasterUrl, customerBillGenerationUrl, ddlCustomerGstStateId,
    lblLocationCode, loginLocationCode, docketTotal, docketNomenclature, gstMasterUrl, ddlCompanyGstStateId, customerContractMasterUrl, customerSupBillUrl;
var allowMandatoryManualBillNo = false;
var ddlDocketStatusId, txtPONo;

$(document).ready(function () {
    InitObjects();
    AttachEvents();
    SetPageLoad('Customer', 'Billing', 'ddlGstServiceTypeId', '', '');
});

function InitObjects() {
    txtCustomerCode = $('#txtCustomerCode');
    lblCustomerName = $('#lblCustomerName');
    ddlPrimaryBillingTypeId = $('#ddlPrimaryBillingTypeId');
    ddlPaybasId = $('#ddlPaybasId');
    hdnCustomerId = $('#hdnCustomerId');
    ddlCustomerGstStateId = $('#ddlCustomerGstStateId');
    ddlGstServiceTypeId = $('#ddlGstServiceTypeId');
    ddlTransactionTypeId = $('#ddlTransactionTypeId');
    hdnTransportModeId = $('#hdnTransportModeId');
    hdnGstServiceTypeId = $('#hdnGstServiceTypeId');
    ddlCompanyGstStateId = $('#ddlCompanyGstStateId');
    txtDueDate = $('#txtDueDate');
    txtBillDate = $('#txtBillDate');
    ddlGenerationCityId = $('#ddlGenerationCityId');
    ddlSubmissionCityId = $('#ddlSubmissionCityId');
    drTransactionDate = InitDateRange('drTransactionDate', DateRange.LastWeek, false);
    ddlServiceTypeId = $('#ddlServiceTypeId');
    ddlFtlTypeId = $('#ddlFtlTypeId');
    ddlDocketStatusId = $('#ddlDocketStatusId');
    txtPONo = $('#txtPONo');

    GetCompanyGstState();
    ddlGstServiceTypeId.change(OnGstServiceTypeChange).change();
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetGstDetail },
        { StepName: docketNomenclature + ' List For Bill Generation', StepFunction: GetBillGenerationDetails }
    ], 'Bill Generate');
}

function AttachEvents() {
    ddlPaybasId.change(OnPaybasChange).change();
    CustomerAutoCompleteByLocationPaybas('txtCustomerCode', 'hdnCustomerId', loginLocationId, ddlPaybasId.val(), true);
    txtCustomerCode.blur(function () {
        IsCustomerCodeExistByLocationPaybas(txtCustomerCode, hdnCustomerId, lblCustomerName, loginLocationId, ddlPaybasId.val(), true);
        if (hdnCustomerId.val() > 0) {
            GetCustomerGstState();
            OnGstStateChange();
        }
        else {
            BindDropDownList('ddlCustomerGstStateId', [], null, null, '', 'Select State');
            txtCustomerCode.focus();
        }
    });
    ddlCustomerGstStateId.change(OnGstStateChange);
    ddlCompanyGstStateId.change(OnGstStateChange);
    ddlTransactionTypeId.change(OnTransactionTypeChange);
    txtBillDate.blur(CalculateDueDate);
    txtDueDate.blur(CheckValidDueDate);
    ddlGenerationCityId.change(GetCustomerGstDetailsByOwnerTypeAndOwnerAndStateAndCity);
    ddlSubmissionCityId.change(GetCompanyGstDetailsByOwnerTypeAndOwnerAndStateAndCity);
    ddlServiceTypeId.change(OnServiceTypeChange);
    var requestData = { moduleId: 15, ruleId: 4 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        allowMandatoryManualBillNo = (result == "Y" ? true : false);
    }, ErrorFunction, false);
    if (allowMandatoryManualBillNo)
        AddRequired($('#txtManualBillNo'), 'Please enter Manual BillNo');
}

function OnPaybasChange() {
    txtCustomerCode.val('');
    hdnCustomerId.val('');
    lblCustomerName.text('');
    txtCustomerCode.enable(ddlPaybasId.val() != '');
}

function OnTransactionTypeChange() {
    $('#dvTransactionBilling').showHide(ddlTransactionTypeId.val() == 1);
    $('#ddlGstServiceTypeId').disable();
    txtCustomerCode.enable(ddlTransactionTypeId.val() != 1);
    if (ddlTransactionTypeId.val() == 2)
        ddlPaybasId.val(7);
}
function OnServiceTypeChange() {
    $('#dvFtlType').showHide(ddlServiceTypeId.val() == 2);
    if (ddlServiceTypeId.val() != 2)
        ddlFtlTypeId.val('');
}

function OnGstServiceTypeChange() {
    var gstServiceType = ddlGstServiceTypeId.val().split('~');
    if (!IsObjectNullOrEmpty(gstServiceType)) {
        hdnGstServiceTypeId.val(gstServiceType[0]);
        hdnTransportModeId.val(gstServiceType[1]);
    }
    else {
        hdnGstServiceTypeId.val('');
        hdnTransportModeId.val('');
    }
}


function GetCustomerGstState() {
    ddlPrimaryBillingTypeId.enable();
    var requestData = { ownerType: 3, ownerId: hdnCustomerId.val(), locationId: 0 };
    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstStateList', JSON.stringify(requestData), function (responseData) {
        BindDropDownList(ddlCustomerGstStateId.Id, responseData, 'Description', 'Name', '', (responseData.length > 1 ? 'Select Party GST State' : ''));
    }, ErrorFunction, false);
}

function GetCompanyGstState() {
    var requestData = { ownerType: 1, ownerId: loginCompanyId, locationId: 0 };
    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstStateList', JSON.stringify(requestData), function (responseData) {
        BindDropDownList(ddlCompanyGstStateId.Id, responseData, 'Description', 'Name', '', (responseData.length > 1 ? 'Select Company GST State' : ''));
    }, ErrorFunction, false);

    ddlPrimaryBillingTypeId.append($("<option></option>").val(1).html('Inter-State'));
    ddlPrimaryBillingTypeId.append($("<option></option>").val(0).html('Intra-State'));
}

function OnGstStateChange() {
    ddlPrimaryBillingTypeId.enable();
    if (ddlCustomerGstStateId.val() != '') {
        if (ddlCompanyGstStateId.val() == ddlCustomerGstStateId.val())
            ddlPrimaryBillingTypeId.val(0).disable();
        else
            ddlPrimaryBillingTypeId.val(1).disable();
    }
}

var creditDays = 0;
function GetGstDetail() {

    if (ddlTransactionTypeId.val() == 2) {
        var url = customerSupBillUrl + '?customerId=' + hdnCustomerId.val() + '&customerStateId=' + ddlCustomerGstStateId.val() + '&companyStateId=' + ddlCompanyGstStateId.val() + '&payBasId=' + ddlPaybasId.val() + '&submissionId=' + ddlPrimaryBillingTypeId.val();
        window.location.href = url;
        return false;
    }
    else {
        try {
            
            var requestData = {
                customerId: hdnCustomerId.val(), fromDate: drTransactionDate.startDate, toDate: drTransactionDate.endDate, gstServiceTypeId: hdnGstServiceTypeId.val(), customerGstStateId: ddlCustomerGstStateId.val(), companyGstStateId: ddlCompanyGstStateId.val(), paybasId: ddlPaybasId.val(), serviceTypeId: ddlServiceTypeId.val() == '' ? 0 : ddlServiceTypeId.val(),
                ftlTypeId: ddlFtlTypeId.val() == '' ? 0 : ddlFtlTypeId.val(), DocketStatusId: ddlDocketStatusId.val() == '' ? 0 : ddlDocketStatusId.val(), billtypeInterIntra: ddlPrimaryBillingTypeId.val(), PONo: txtPONo.val(), ownerType: 1, ownerId: loginCompanyId

            };
           
            AjaxRequestWithPostAndJson(customerBillGenerationUrl + '/GetDocketListGstForCustomerBillGenerationTriSpeed', JSON.stringify(requestData), function (result) {
                selectedDocketList = [];

                if (dtDocketList == null)
                    dtDocketList = LoadDataTable('dtDocketList', false, false, false, null, null, [],
                        [
                            { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllDocket', SelectDocket) + "</div>", data: "DocketId", width: 80 },
                            { title: docketNomenclature, data: 'DocketNo' },
                            { title: docketNomenclature + ' Date', data: 'DocketDate' },
                            { title: 'From City', data: 'FromCity' },
                            { title: 'To City', data: 'ToCity' },
                            { title: 'Vehicle No', data: 'VehicleNo' },
                            { title: 'Actual Weight', data: 'ActualWeight' },
                            { title: 'Charge Weight', data: 'ChargedWeight' },
                            { title: 'Rate', data: 'FreightRate' },
                            { title: 'Rate Type', data: 'FreightRateType' },
                            { title: 'Freight', data: 'Freight' },
                            { title: 'Docket Charge', data: 'DocketCharge' },
                            { title: 'Sub Total', data: 'SubTotal' },
                            { title: 'GST Amount', data: 'TaxTotal' },
                            { title: docketNomenclature + ' Total', data: 'DocketTotal' }
                        ]);

                dtDocketList.fnClearTable();

                if (result.length == 0) {
                    isStepValid = false;
                    ShowMessage('No Record Found');
                    return false;
                }
                else {
                    $.each(result, function (i, item) {
                        item.DocketId = SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'Details[' + i + '].IsChecked', SelectDocket) +
                            "<input type='hidden' value='" + item.DocketId + "' name='Details[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                            "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>" +
                            "<input type='hidden' value='" + item.DocketNo + "' name='Details[" + i + "].DocketNo' id='hdnDocketNo" + i + "'/>" +
                            "<input type='hidden' value='" + item.DocketDate + "'  id='hdnDocketDate" + i + "'/>" +
                            "<input type='hidden' value='" + item.DocketSuffix + "' name='Details[" + i + "].DocketSuffix' id='hdnDocketSuffix" + i + "'/>";
                        item.DocketDate = $.displayDate(item.DocketDate);
                        //item.FreightRate = '<input type=\'text\' name="Details[' + i + '].FreightRate" id="txtFreightRate' + i + '" value=' + item.FreightRate.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                        //item.Freight = '<input type=\'text\' name="Details[' + i + '].Freight" id="txtFreight' + i + '" value=' + item.Freight.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                        item.SubTotal = '<input type=\'text\' name="Details[' + i + '].SubTotal" id="txtSubTotal' + i + '" value=' + item.SubTotal.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                        item.TaxTotal = '<input type=\'text\' name="Details[' + i + '].TaxTotal" id="txtTaxTotal' + i + '" value=' + item.TaxTotal.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>';
                        item.DocketTotal = '<input type=\'text\' name="Details[' + i + '].DocketTotal" id="txtDocketTotal' + i + '" value=' + item.DocketTotal.toFixed(2) + ' class="textlabel numeric2" style="width: 100px;" readonly="true" tabindex="-1"/>' +
                            "<input type='hidden' value='" + item.Igst + "' name='Details[" + i + "].Igst' id='hdnIgst" + i + "'/>" +
                            "<input type='hidden' value='" + item.Cgst + "' name='Details[" + i + "].Cgst' id='hdnCgst" + i + "'/>" +
                            "<input type='hidden' value='" + item.Sgst + "' name='Details[" + i + "].Sgst' id='hdnSgst" + i + "'/>" +
                            "<input type='hidden' value='" + item.Ugst + "' name='Details[" + i + "].Ugst' id='hdnUgst" + i + "'/>";
                    });
                    dtDocketList.dtAddData(result);
                    dtDocketList.removeClass('dataTable')
                }
            }, ErrorFunction, false);

            var requestData = { customerId: hdnCustomerId.val(), paybasId: ddlPaybasId.val() };
            AjaxRequestWithPostAndJson(customerContractMasterUrl + '/GetCreditDaysByCustomerIdAndPaybasId', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result))
                    creditDays = 0;
                else
                    creditDays = result;
            }, ErrorFunction, false);

            $('#lblCustomer').text(txtCustomerCode.val() + " : " + lblCustomerName.text());
            $('#lblInterState').text(ddlCustomerGstStateId.val() == ddlCompanyGstStateId.val() ? "Intra State" : "Inter State");

            var requestData = { ownerType: 1, ownerId: loginCompanyId, stateId: ddlCompanyGstStateId.val() };
            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailByOwnerAndState', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    $('#hdnBillSubmissionStateId').val(0);
                    $('#lblBillSubmissionState').text('');
                    $('#hdnBillSubmissionCityId').val(0);
                    $('#lblBillSubmissionCity').text('');
                    $('#hdnCompanyGstId').val(0);
                    $('#txtCompanyGstStateGstTinNo').val('');
                    $('#txtSubmissionBillingAddress').val('');
                    $('#hdnBillSubmissionLocationId').val(0);
                    $('#lblBillSubmissionLocationCode').text('');
                }
                else {
                    $('#hdnBillSubmissionStateId').val(result.StateId);
                    $('#lblBillSubmissionState').text(result.StateName);
                    //$('#hdnBillSubmissionCityId').val(result.CityId);
                    //$('#lblBillSubmissionCity').text(result.CityName);
                    //$('#hdnCompanyGstId').val(result.GstId);
                    //$('#lblCompanyGstStateGstTinNo').text(result.GstTinNo);
                    //$('#hdnBillSubmissionLocationId').val(result.LocationId);
                    //$('#lblBillSubmissionLocationCode').text(result.LocationCode);
                    requestData = { ownerType: 1, ownerId: loginCompanyId, stateId: ddlCompanyGstStateId.val() };
                    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetCityListByOwnerAndState', JSON.stringify(requestData), function (result) {
                        BindDropDownList('ddlSubmissionCityId', result, 'Value', 'Name', '', (result.length > 1 ? 'Select' : ''));
                        GetCompanyGstDetailsByOwnerTypeAndOwnerAndStateAndCity();
                    }, ErrorFunction, false);
                }
            }, ErrorFunction, false);
            if (hdnCustomerId.val() == 1) {
                $('#hdnBillGenerationStateId').val(ddlCustomerGstStateId.val());
                $('#lblBillGenerationState').text($("#ddlCustomerGstStateId option:selected").text());
                var requestData = { stateId: ddlCustomerGstStateId.val() };
                AjaxRequestWithPostAndJson(cityMasterUrl + '/GetCityListByStateId', JSON.stringify(requestData), function (result) {
                    BindDropDownList('ddlGenerationCityId', result, 'Value', 'Name', '', 'Select');
                }, ErrorFunction, false);
            }
            else {
                requestData = { ownerType: 3, ownerId: hdnCustomerId.val(), stateId: ddlCustomerGstStateId.val() };
                AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailByOwnerAndState', JSON.stringify(requestData), function (result) {
                    if (IsObjectNullOrEmpty(result)) {

                        $('#hdnBillGenerationStateId').val(0);
                        $('#lblBillGenerationState').text('');
                        $('#hdnBillGenerationCityId').val(0);
                        $('#lblBillGenerationCity').text('');
                        $('#hdnCustomerGstId').val(0);
                        $('#txtCustomerGstStateGstTinNo').val('');
                        $('#txtBillingAddress').val('');
                    }
                    else {
                        $('#hdnBillGenerationStateId').val(result.StateId);
                        $('#lblBillGenerationState').text(result.StateName);
                        //$('#hdnBillGenerationCityId').val(result.CityId);
                        //$('#lblBillGenerationCity').text(result.CityName);
                        //$('#hdnCustomerGstId').val(result.GstId);
                        //$('#lblCustomerGstStateGstTinNo').text(result.GstTinNo);
                        //$('#lblBillingAddress').text(result.Address);
                        requestData = { ownerType: 3, ownerId: hdnCustomerId.val(), stateId: ddlCustomerGstStateId.val() };
                        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetCityListByOwnerAndState', JSON.stringify(requestData), function (result) {
                            BindDropDownList('ddlGenerationCityId', result, 'Value', 'Name', '', (result.length > 1 ? 'Select' : ''));
                            GetCustomerGstDetailsByOwnerTypeAndOwnerAndStateAndCity();
                        }, ErrorFunction, false);
                    }
                }, ErrorFunction, false);
            }
            var requestData = { gstServiceTypeId: hdnGstServiceTypeId.val() };
            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailByGstServiceTypeId', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    $('#lblServiceType').text('');
                    $('#lblSacName').text('');
                    $('#hdnSacId').val(0);
                    $('#txtGstRate').val(0);
                    $('#lblCustomerGstInNo').text('');
                    $('#lblTransporterGstInNo').text('');
                }
                else {
                    $('#lblServiceType').text(result.ServiceType + " - " + result.TransportMode);
                    $('#lblSacName').text(result.SacName);
                    $('#hdnSacId').val(result.SacId);
                    $('#txtGstRate').val(result.GstRate);
                    $('#lblCustomerGstInNo').text($('#txtCustomerGstStateGstTinNo').val());
                    $('#lblTransporterGstInNo').text($('#lblCompanyGstStateGstTinNo').text());
                }
            }, ErrorFunction, false);

            txtBillDate.blur();
            return false;
        } catch (e) { alert(e.message) }
    }
}

function CalculateDueDate() {
    if (txtBillDate.val() != '') {
        var days = parseInt(creditDays);
        var dueDate = $.setDateTime(txtBillDate.val()).add(creditDays, 'd');
        txtDueDate.val($.entryDate(dueDate));
    }
}

function CheckValidDueDate() {
    if ($.setDateTime(txtDueDate.val()) < $.setDateTime(txtBillDate.val())) {
        ShowMessage('Please select Due Date greater than Or equal to Bill Date');
        txtDueDate.val('');
        return false;
    }
}

function SelectDocket() {
    selectedDocketList = [];
    var subTotal = 0, gstTotal = 0, total = 0, totalIgst = 0, totalCgst = 0, totalSgst = 0, totalUgst = 0;
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var txtTaxTotal = $('#' + chkDocket.Id.replace('chkDocket', 'txtTaxTotal'));
        var txtSubTotal = $('#' + chkDocket.Id.replace('chkDocket', 'txtSubTotal'));
        var txtDocketTotal = $('#' + chkDocket.Id.replace('chkDocket', 'txtDocketTotal'));
        var hdnIgst = $('#' + chkDocket.Id.replace('chkDocket', 'hdnIgst'));
        var hdnCgst = $('#' + chkDocket.Id.replace('chkDocket', 'hdnCgst'));
        var hdnSgst = $('#' + chkDocket.Id.replace('chkDocket', 'hdnSgst'));
        var hdnUgst = $('#' + chkDocket.Id.replace('chkDocket', 'hdnUgst'));
        if (chkDocket.IsChecked) {
            selectedDocketList.push($('#' + chkDocket.Id.replace('chkDocket', 'hdnDocketId')).val());
            gstTotal = gstTotal + parseFloat(txtTaxTotal.val());
            subTotal = subTotal + parseFloat(txtSubTotal.val());
            total = total + parseFloat(txtDocketTotal.val());
            totalIgst = totalIgst + parseFloat(hdnIgst.val());
            totalCgst = totalCgst + parseFloat(hdnCgst.val());
            totalSgst = totalSgst + parseFloat(hdnSgst.val());
            totalUgst = totalUgst + parseFloat(hdnUgst.val());
        }
    });

    totalCgst = totalCgst.toFixed(2);
    totalIgst = totalIgst.toFixed(2);
    totalSgst = totalSgst.toFixed(2);
    totalUgst = totalUgst.toFixed(2);
    gstTotal = gstTotal.toFixed(2);
    total = total.toFixed(2);

    $('#lblGstTotal').text(gstTotal);
    $('#hdnGstTotal').val(gstTotal);
    $('#lblSubTotal').text(subTotal.toFixed(2));
    $('#hdnSubTotal').val(subTotal);
    $('#lblTotal').text(total);
    $('#hdnTotal').val(total);

    $('#lblSgst').text(totalSgst);
    $('#hdnSgst').val(totalSgst);

    $('#lblUgst').text(totalUgst);
    $('#hdnUgst').val(totalUgst);

    $('#lblCgst').text(totalCgst);
    $('#hdnCgst').val(totalCgst);

    $('#lblIgst').text(totalIgst);
    $('#hdnIgst').val(totalIgst);
}

function GetBillGenerationDetails() {
    if (selectedDocketList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one ' + docketNomenclature);
        return false;
    }
    else if (!ValidateModuleDateWithPreviousDocumentDate('dtDocketList', 'chkDocket', 'hdnDocketDate', 'txtBillDate', 'Bill Date')) return false;
}

function GetCustomerGstDetailsByOwnerTypeAndOwnerAndStateAndCity() {
    if (ddlGenerationCityId.val() != '' && hdnCustomerId.val() != 1) {
        requestData = { ownerType: 3, ownerId: hdnCustomerId.val(), stateId: ddlCustomerGstStateId.val(), cityId: ddlGenerationCityId.val() };
        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailsByOwnerTypeAndOwnerAndStateAndCity', JSON.stringify(requestData), function (result) {
            $('#hdnCustomerGstId').val(result.GstId);
            $('#txtCustomerGstStateGstTinNo').val(result.GstTinNo);
            $('#txtBillingAddress').val(result.Address);
            $('#txtCustomerGstStateGstTinNo').readOnly(true);
            $('#txtBillingAddress').readOnly(true);
        }, ErrorFunction, false);
    }
}

function GetCompanyGstDetailsByOwnerTypeAndOwnerAndStateAndCity() {
    if (ddlSubmissionCityId.val() != '') {
        requestData = { ownerType: 1, ownerId: loginCompanyId, stateId: ddlCompanyGstStateId.val(), cityId: ddlSubmissionCityId.val() };
        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailsByOwnerTypeAndOwnerAndStateAndCity', JSON.stringify(requestData), function (result) {
            $('#hdnCompanyGstId').val(result.GstId);
            $('#txtCompanyGstStateGstTinNo').val(result.GstTinNo);
            $('#txtSubmissionBillingAddress').val(result.Address);
            $('#txtCompanyGstStateGstTinNo').readOnly(true);
            $('#txtSubmissionBillingAddress').readOnly(true);
        }, ErrorFunction, false);
    }
}