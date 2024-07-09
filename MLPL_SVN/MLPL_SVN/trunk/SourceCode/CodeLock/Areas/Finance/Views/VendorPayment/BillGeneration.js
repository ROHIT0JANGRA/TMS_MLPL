var txtVendorCode, hdnVendorId, txtVendorName, ddlGstTypeId, ddlVendorGstStateId, ddlCompanyGstStateId, ddlGstServiceTypeId, drTransactionDate, txtManualDocumentNo, chkIsGstExempted, ddlGstExemptedCategoryId, stateMasterUrl, gstMasterUrl, vendorMasterUrl, dtDocumentList, selectedDocumentList, dtDocumentDetailList, ddlGstVendorLocationId, ddlGstCompanyLocationId, ddlGstVendorCityId, ddlGstCompanyCityId, vendorPaymentUrl;
var totalBillAmount = 0, totalContractAmount = 0, chargeListCount = 0, chargeCount = 0, isChargesAdded = false, chargeCounter = 0;
var txtBillDateTime, vendorContractMasterUrl, itemlistIndexPub;
var hdnPaymentLocationId, txtPaymentLocation;
var loginLocationId, loginLocationCode;
var ddlTransportModeId;
$(document).ready(function () {
    SetPageLoad('Vendor', 'Bill Generation', '');
    InitObjects();
    AttachEvents();

});

function InitObjects() {
    txtVendorCode = $('#txtVendorCode'); hdnVendorId = $('#hdnVendorId'); ddlGstTypeId = $('#ddlGstTypeId'); ddlVendorGstStateId = $('#ddlVendorGstStateId'); ddlCompanyGstStateId = $('#ddlCompanyGstStateId'); ddlGstServiceTypeId = $('#ddlGstServiceTypeId'); txtVendorName = $('#txtVendorName'); ddlVendorServiceId = $('#ddlVendorServiceId'); txtDocumentNo = $('#txtDocumentNo'); txtManualDocumentNo = $('#txtManualDocumentNo'); lblVendorNameStep2 = $('#lblVendorNameStep2'); lblVendorNameStep3 = $('#lblVendorNameStep3'); chkDocumentType = $('#chkDocumentType'); chkDocument = $('#chkDocument'); txtBillDueDate = $('#txtBillDueDate'); txtBillAmount = $('#txtBillAmount'); txtContractAmount = $('#txtContractAmount'); hdnVendorChargeList = $('#hdnVendorChargeList'); chkIsGstExempted = $('#chkIsGstExempted'); ddlGstExemptedCategoryId = $('#ddlGstExemptedCategoryId'); ddlGstVendorLocationId = $('#ddlGstVendorLocationId'); ddlGstCompanyLocationId = $('#ddlGstCompanyLocationId'); ddlGstVendorCityId = $('#ddlGstVendorCityId'); ddlGstCompanyCityId = $('#ddlGstCompanyCityId'); ddlTransportModeId = $('#ddlTransportModeId');
    txtBAMappedLocation = $('#txtBAMappedLocation'); hdnBAMappedLocationid = $('#hdnBAMappedLocationid')
    $('input:checkbox').attr('checked', false);
    drTransactionDate = InitDateRange('drTransactionDate', DateRange.LastWeek, false);
    InitWizard('dvWizard', [{ StepName: 'Criteria', StepFunction: GetDocumentListForVehicleHireBillGeneration }, { StepName: 'Document List For Generation', StepFunction: GetDocumentDetailListForBillGeneration }, { StepName: 'Vendor Bill Detail', StepFunction: GetSubTotalAmount }, { StepName: 'Vendor Bill Tax Detail' }], 'Bill Generation');
    txtBillDateTime = $('#txtBillDateTime');
    LocationAutoComplete('txtBAMappedLocation', 'hdnBAMappedLocationid');
    txtBAMappedLocation.blur(function () { IsLocationCodeExist(txtBAMappedLocation, hdnBAMappedLocationid); });
    // txtBillDueDate.readOnly();
    hdnPaymentLocationId = $('#hdnPaymentLocationId');
    txtPaymentLocation = $('#txtPaymentLocation');

}

function AttachEvents() {
    VendorAutoComplete('txtVendorCode', 'hdnVendorId');
    txtVendorCode.blur(function () { IsVendorCodeExist(txtVendorCode, hdnVendorId, txtVendorName); if (hdnVendorId.val() == 1) txtVendorName.val(''); SetVendorName(); });
    txtVendorCode.blur(function () { return EnableGstInfo(txtVendorCode, hdnVendorId); });
    //ddlGstTypeId.change(function () { return BindGstState(); });
    ddlGstServiceTypeId.change(function () { return GetGstRate(); });
    //ddlVendorGstStateId.change(function () { return BindVendorGstLocation(); });
    //ddlCompanyGstStateId.change(function () { return BindCompanyGstLocation(); });
    //ddlGstVendorLocationId.change(function () { return BindVendorGstCity(); });
    ddlVendorGstStateId.change(function () { return BindVendorGstCity(); });
    ddlCompanyGstStateId.change(function () { return BindCompanyGstCity(); });
    ddlGstVendorCityId.change(function () { return GetGstDetail('Vendor'); });
    ddlGstCompanyCityId.change(function () { return GetGstDetail('Company'); });
    txtBillDateTime.blur(CalculateDueDate);
    $("#divBaloc").showHide();

    $("[id*=chkDocumentType]").each(function () {
        var chkDocumentType = $(this);
        chkDocumentType.change(IsDocumentTypeChange);
    });
    ddlGstTypeId.disable();
    ddlGstTypeId.append($("<option></option>").val(1).html('Inter-State'));
    ddlGstTypeId.append($("<option></option>").val(0).html('Intra-State'));

    LocationAutoComplete('txtPaymentLocation', 'hdnPaymentLocationId');
    txtPaymentLocation.blur(function () { return IsLocationCodeExist(txtPaymentLocation, hdnPaymentLocationId); });
}

function IsDocumentTypeChange() {
    $("#divBaloc").showHide(false);
    $("[id*=chkDocumentType]").each(function () {

        var chkDocumentType = $(this);
        if (chkDocumentType.IsChecked == true) {
            if (parseInt($('#' + chkDocumentType.Id.replace('chkDocumentType', 'hdnCodeId')).val()) == 9) {
                $("#divBaloc").showHide(true);
            }
            else {
                $("#divBaloc").showHide(false);
            }
        }
    });
}

function SetVendorName() {
    txtVendorName.readOnly(hdnVendorId.val() != 1);
    if (hdnVendorId.val() == 1)
        txtVendorName.val('');
}

function GetGstDetail(cityType) {
    var requestData = {};
    if (cityType == 'Vendor') {
        if (ddlGstVendorCityId.val() != '') {
            requestData.ownerType = '5';
            requestData.ownerId = hdnVendorId.val();
            requestData.cityId = ddlGstVendorCityId.val();

            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailByOwnerAndCity', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    $('#txtVendorGstNo').val('');
                    $('#hdnVendorGstId').val(0);
                    $('#txtGstVendorAddress').val('');
                }
                else {
                    $('#txtVendorGstNo').val(result.GstTinNo);
                    $('#hdnVendorGstId').val(result.GstId);
                    $('#txtGstVendorAddress').val(result.Address);
                }
            });
        }
    }
    if (cityType == 'Company') {
        if (ddlGstCompanyCityId.val() != '') {
            requestData.ownerType = '1';
            requestData.ownerId = loginCompanyId;
            requestData.cityId = ddlGstCompanyCityId.val();

            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstDetailByOwnerAndCity', JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    $('#lblCompanyGstinNo').text('NA');
                    $('#hdnCompanyGstId').val(0);
                    $('#lblCompanyGstAddress').text('NA');
                }
                else {
                    $('#lblCompanyGstinNo').text(result.GstTinNo);
                    $('#hdnCompanyGstId').val(result.GstId);
                    $('#lblCompanyGstAddress').text(result.Address);
                }
            });
        }
    }
}

function BindVendorGstCity() {
    if (ddlVendorGstStateId.val() != '') {
        var requestData = {};
        if (hdnVendorId.val() != 1) {
            requestData.ownerType = 5;
            requestData.ownerId = hdnVendorId.val();
            requestData.stateId = ddlVendorGstStateId.val();
            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetCityListByOwnerAndState', JSON.stringify(requestData), function (result) {
                BindDropDownList(ddlGstVendorCityId.Id, result, 'Value', 'Name', '', 'Select City');
            });
        }
        else {
            requestData.stateId = ddlVendorGstStateId.val();
            AjaxRequestWithPostAndJson(cityMasterUrl + '/GetCityListByStateId', JSON.stringify(requestData), function (result) {
                BindDropDownList(ddlGstVendorCityId.Id, result, 'Value', 'Name', '', 'Select City');
            });
        }
        OnGstStateChange();
    }
}

function BindCompanyGstCity() {
    if (ddlCompanyGstStateId.val() != '') {
        var requestData = {};
        requestData.ownerType = 1;
        requestData.ownerId = loginCompanyId;
        requestData.stateId = ddlCompanyGstStateId.val();
        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetCityListByOwnerAndState', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlGstCompanyCityId.Id, result, 'Value', 'Name', '', 'Select City');
        });
        OnGstStateChange();
    }
}

function BindVendorGstLocation() {
    if (ddlVendorGstStateId.val() != '') {
        var requestData = {};
        requestData.stateId = ddlVendorGstStateId.val();
        AjaxRequestWithPostAndJson(locationMasterUrl + '/GetLocationListByStateId', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlGstVendorLocationId.Id, result, 'Value', 'Name', '', 'Select Location');
        });
    }
}

function BindCompanyGstLocation() {
    if (ddlCompanyGstStateId.val() != '') {
        var requestData = {};
        requestData.stateId = ddlCompanyGstStateId.val();
        AjaxRequestWithPostAndJson(locationMasterUrl + '/GetLocationListByStateId', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlGstCompanyLocationId.Id, result, 'Value', 'Name', '', 'Select Location');
        });
    }
}

function OnGstStateChange() {
    ddlGstTypeId.enable();
    if (ddlVendorGstStateId.val() != '') {
        if (ddlCompanyGstStateId.val() == ddlVendorGstStateId.val())
            ddlGstTypeId.val(0).disable();
        else
            ddlGstTypeId.val(1).disable();
    }
    if (ddlGstTypeId.val() == 0)
        gstDetails.IsInterState = 'false';
    else
        gstDetails.IsInterState = 'true';
}

function GetGstRate() {
    if (ddlGstServiceTypeId.val() != '') {
        var requestData = {};
        requestData.sacId = ddlGstServiceTypeId.val();
        AjaxRequestWithPostAndJson(sacMasterUrl + '/GetSacDetailById', JSON.stringify(requestData), function (result) {
            if (result.IsRcm)
                $('#lblIsRcmApplicable').text('Yes');
            else
                $('#lblIsRcmApplicable').text('No');

            $('#hdnIsRcmApplicable').val(result.IsRcm);
            txtGstRate.val(result.GstRate);
        }, ErrorFunction, false);
    }
}

function BindGstState() {
    var requestData = {};

    //if (ddlGstTypeId.val() != '') {
    //    if (ddlGstTypeId.val() == '4') {
    //        requestData.countryId = '1';

    //        AjaxRequestWithPostAndJson(stateMasterUrl + '/GetStateListByCountryId', JSON.stringify(requestData), function (result) {
    //            BindDropDownList(ddlCompanyGstStateId.Id, result, 'Value', 'Name', '', 'Select Company GST State');
    //            BindDropDownList(ddlVendorGstStateId.Id, result, 'Value', 'Name', '', 'Select Vendor GST State');
    //        }, ErrorFunction, false);

    //        requestData.ownerType = '1';
    //        requestData.ownerId = loginCompanyId;

    //        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetStateListByOwnerTypeIdAndOwnerId', JSON.stringify(requestData), function (result) {
    //            BindDropDownList(ddlCompanyGstStateId.Id, result, 'Value', 'Name', '', 'Select Company GST State');
    //        }, ErrorFunction, false);
    //    }
    //    else {
    requestData.ownerType = '1';
    requestData.ownerId = loginCompanyId;

    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetStateListByOwnerTypeIdAndOwnerId', JSON.stringify(requestData), function (result) {
        BindDropDownList(ddlCompanyGstStateId.Id, result, 'Value', 'Name', '', 'Select Company GST State');
    }, ErrorFunction, false);

    requestData.ownerType = '5';
    requestData.ownerId = hdnVendorId.val();

    if (requestData.ownerId != 1) {
        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetStateListByOwnerTypeIdAndOwnerId', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlVendorGstStateId.Id, result, 'Value', 'Name', '', 'Select Vendor GST State');
        }, ErrorFunction, false);
    }
    else {
        requestData.countryId = '1';
        AjaxRequestWithPostAndJson(stateMasterUrl + '/GetStateListByCountryId', JSON.stringify(requestData), function (result) {
            BindDropDownList(ddlVendorGstStateId.Id, result, 'Value', 'Name', '', 'Select Vendor GST State');
        }, ErrorFunction, false);
    }
    // }
    //}
    //else {
    //    ClearDropDownList(ddlCompanyGstStateId.Id, '', 'Select Company GST State');
    //    ClearDropDownList(ddlVendorGstStateId.Id, '', 'Select Vendor GST State');
    //}
    ////hdnGstTypeId.val(ddlGstTypeId.val());

}

function EnableGstInfo(txtVendorCode, hdnVendorId) {
    ddlVendorGstStateId.enable(txtVendorCode.val() != '');
    ddlCompanyGstStateId.enable(txtVendorCode.val() != '');
    ddlGstServiceTypeId.enable(txtVendorCode.val() != '');
    ddlGstTypeId.enable(txtVendorCode.val() != '');
    ddlGstTypeId.val('').change();
    BindGstState();
}

function GetDocumentListForVehicleHireBillGeneration() {
    var selectedValues = [];

    $("[id*=chkDocumentType]").each(function () {

        var chkDocumentType = $(this);
        if (chkDocumentType.IsChecked == true)
            selectedValues.push($('#' + chkDocumentType.Id.replace('chkDocumentType', 'hdnCodeId')).val());
    });

    var requestData = { VendorId: hdnVendorId.val(), fromDate: drTransactionDate.startDate, toDate: drTransactionDate.endDate, VendorGstStateId: ddlVendorGstStateId.val(), DocumentNo: txtDocumentNo.val(), ManualDocumentNo: txtManualDocumentNo.val(), SelectedDocumentType: selectedValues.join(','), GstServiceTypeId: ddlGstServiceTypeId.val(), BAMappedLocationid: hdnBAMappedLocationid.val(), TransportModeId: ddlTransportModeId.val() };

    AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetDocumentListForVehicleHireBillGeneration', JSON.stringify(requestData), function (result) {
        selectedDocumentList = [];

        if (dtDocumentList == null)
            dtDocumentList = LoadDataTable('dtDocumentList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllDocument', SelectDocument) + "</div></div>", data: "DocumentId", width: 80 },
                    { title: 'Document No', data: 'DocumentNo' },
                    { title: 'Manual No', data: 'ManualDocumentNo' },
                    { title: 'Vendor', data: 'VendorName' },
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
                item.DocumentId =
                    SelectAll.GetChk('chkAllDocument', 'chkDocument' + i, 'DocumentList[' + i + '].IsChecked', SelectDocument) +
                    "<input type='hidden' value='" + item.DocumentId + "' name='DocumentList[" + i + "].DocumentId' id='hdnDocumentId" + i + "'/>" +
                    "<label class='label' for='chkDocument" + i + "' id='lblDocumentId" + i + "'></label>" +
                    "<input type='hidden' value='" + item.DocumentTypeId + "' name='DocumentList[" + i + "].DocumentTypeId' id='hdnDocumentTypeId" + i + "'/>";

                item.DocumentDate = $.displayDate(item.DocumentDate);
            });
            lblVendorNameStep2.text(txtVendorCode.val() + ' : ' + txtVendorName.val());
            txtPanNo.val(result[0].PanNo);
            dtDocumentList.dtAddData(result);
            //dtDocumentList.fnSort([[0, 'asc']]);
            dtDocumentList.removeClass('dataTable');

            //$("[id*=chkDocumentType]").each(function () {

            //    var chkDocumentType = $(this);
            //    if (chkDocumentType.IsChecked == true) {
            //        if (parseInt($('#' + chkDocumentType.Id.replace('chkDocumentType', 'hdnCodeId')).val()) == 13) {
            //            $("#dtDocumentDetailList").find("tbody tr, thead tr").children(":nth-child(" + 5 + ")").hide();
            //        }
            //        else {
            //            $("#dtDocumentDetailList").find("tbody tr, thead tr").children(":nth-child(" + 5 + ")").hide();
            //        }
            //    }
            //});
        }
    }, ErrorFunction, false);
    return false;
}

function SelectDocument() {
    selectedDocumentList = [];
    docketTotal = 0.00;
    $('[id*="chkDocument"]').each(function () {
        var chkDocument = $(this);
        if (chkDocument.IsChecked) {
            selectedDocumentList.push($('#' + chkDocument.Id.replace('chkDocument', 'hdnDocumentId')).val());
        }
    });
}

function GetDocumentDetailListForBillGeneration() {
    lblVendorNameStep3.text(txtVendorCode.val() + ' : ' + txtVendorName.val());
    var itemlistIndex = 0;
    selectedDocumentList = [];
    $('[id*="hdnDocumentId"]').each(function () {
        var hdnDocumentId = $(this);
        var chkDocument = $('#' + hdnDocumentId.Id.replace('hdnDocumentId', 'chkDocument'));
        if (chkDocument.IsChecked) {
            selectedDocumentList.push({ 'VendorId': hdnVendorId.val(), 'DocumentId': $('#' + chkDocument.Id.replace('chkDocument', 'hdnDocumentId')).val(), 'DocumentTypeId': parseInt($('#' + chkDocument.Id.replace('chkDocument', 'hdnDocumentTypeId')).val()) });
            itemlistIndex = parseInt($('#' + chkDocument.Id.replace('chkDocument', 'hdnDocumentTypeId')).val());
        }
    });
    itemlistIndexPub = itemlistIndex;
    if (selectedDocumentList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Document');
        return false;
    }
    else {
        CalculateDueDate();
        AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetDocumentDetailForVehicleHireBillGeneration', JSON.stringify(selectedDocumentList), function (result) {
            if (dtDocumentDetailList == null)
                if (itemlistIndex != 13) {
                    dtDocumentDetailList = LoadDataTable('dtDocumentDetailList', false, false, false, null, null, [],
                        [
                            { title: SelectAll.GetChkAll('chkAllDocumentDetail', SelectDocumentDetail) + "</div></div>", data: "DocumentId", width: 80 },
                            { title: 'Document No', data: 'DocumentNo' },
                            { title: 'Contract Amount(+)', data: 'ContractAmount' },
                            { title: 'Advance Amount(-)', data: 'AdvanceAmount' },
                            { title: 'Other Amount(+)', data: 'OtherAmount' },
                            { title: 'Balance Amount', data: 'BalanceAmount' },
                            { title: 'Net Amount', data: 'NetAmount' }
                        ]);

                    dtDocumentDetailList.fnClearTable();

                    if (result.length == 0) {
                        isStepValid = false;
                        ShowMessage('No Record Found');
                        return false;
                    }
                    else {

                        totalBillAmount = 0;
                        totalContractAmount = 0;
                        $.each(result, function (i, item) {

                            totalBillAmount += parseFloat(item.BalanceAmount);
                            totalContractAmount += parseFloat(item.ContractAmount);

                            item.DocumentId =
                                SelectAll.GetChk('chkAllDocumentDetail', 'chkDocumentDetail' + i, 'Details[' + i + '].IsChecked', SelectDocumentDetail) +
                                "<input type='hidden' value='" + item.DocumentId + "' name='Details[" + i + "].DocumentId' id='hdnDocumentId" + i + "'/>" +
                                "<label class='label' for='chkDocumentDetail" + i + "' id='lblDocumentDetailId" + i + "'></label>" +
                                "<input type='hidden' value='" + item.DocumentTypeId + "' name='Details[" + i + "].DocumentTypeId' id='hdnDocumentTypeId" + i + "'/>";

                            item.DocumentNo = '<label name="Details[' + i + '].DocumentNo" id="lblDocumentNo' + i + '" class="label-bold"/>' + item.DocumentNo + '</label>' +
                                '<input type=\'hidden\' value=' + i + '  id=\'hdnRowId' + i + '\'/>';
                            item.ContractAmount = '<input type=\'text\' name="Details[' + i + '].ContractAmount" id="txtContractAmount' + i + '" value=' + item.ContractAmount + ' class="form-control textlabel numeric2"/>';
                            item.AdvanceAmount = '<input type=\'text\' name="Details[' + i + '].AdvanceAmount" id="txtAdvanceAmount' + i + '" value=' + item.AdvanceAmount + ' class="form-control textlabel numeric2"/>';
                            item.OtherAmount = '<input type=\'text\' name="Details[' + i + '].OtherAmount" id="txtOtherAmount' + i + '" value=' + item.OtherAmount + ' class="form-control textlabel numeric2"/>';
                            item.NetAmount = '<input type=\'text\' name="Details[' + i + '].NetAmount" id="txtNetAmount' + i + '" value=' + item.BalanceAmount + ' class="form-control textlabel numeric2"/>';
                            item.BalanceAmount = '<input type=\'text\' name="Details[' + i + '].BalanceAmount" id="txtBalanceAmount' + i + '" value=' + item.BalanceAmount + ' class="form-control textlabel numeric2"/>';
                        });
                        dtDocumentDetailList.dtAddData(result);
                    }
                }
                else {
                dtDocumentDetailList = LoadDataTable('dtDocumentDetailList', false, false, false, null, null, [],
                    [
                        { title: SelectAll.GetChkAll('chkAllDocumentDetail', SelectDocumentDetail) + "</div></div>", data: "DocumentId", width: 80 },
                        { title: 'Document No', data: 'DocumentNo' },
                        { title: 'FuelSlip Date', data: 'FuelSlipDate' },
                        { title: 'FuelSlip No', data: 'FuelSlipNo' },
                        { title: 'Vehicle No', data: 'VehicleNo', width: '100px' },
                        { title: 'Qty', data: 'FuelQty' },
                        { title: 'Rate', data: 'FuelRate' },
                        { title: 'Balance Amount', data: 'BalanceAmount' },
                        { title: 'Net Amount', data: 'NetAmount' }
                    ]);

            dtDocumentDetailList.fnClearTable();

                    if (result.length == 0) {
                        isStepValid = false;
                        ShowMessage('No Record Found');
                        return false;
                    }
                    else {

                        totalBillAmount = 0;
                        totalContractAmount = 0;
                        $.each(result, function (i, item) {

                            totalBillAmount += parseFloat(item.BalanceAmount);
                            totalContractAmount += parseFloat(item.ContractAmount);

                            item.DocumentId =
                                SelectAll.GetChk('chkAllDocumentDetail', 'chkDocumentDetail' + i, 'Details[' + i + '].IsChecked', SelectDocumentDetail) +
                                "<input type='hidden' value='" + item.DocumentId + "' name='Details[" + i + "].DocumentId' id='hdnDocumentId" + i + "'/>" +
                                "<label class='label' for='chkDocumentDetail" + i + "' id='lblDocumentDetailId" + i + "'></label>" +
                                "<input type='hidden' value='" + item.DocumentTypeId + "' name='Details[" + i + "].DocumentTypeId' id='hdnDocumentTypeId" + i + "'/>";

                            item.DocumentNo = '<label name="Details[' + i + '].DocumentNo" id="lblDocumentNo' + i + '" class="label-bold"/>' + item.DocumentNo + '</label>' +
                                '<input type=\'hidden\' value=' + i + '  id=\'hdnRowId' + i + '\'/>';
                            //item.FuelSlipDate = '<input type=\'text\' name="Details[' + i + '].FuelSlipDate" id="txtFuelSlipDate' + i + '" value=' + item.FuelSlipDate + ' class="form-control textlabel"/>';
                            item.FuelSlipNo = '<input type=\'text\' name="Details[' + i + '].FuelSlipNo" id="txtFuelSlipNo' + i + '" value="' + item.FuelSlipNo + '" class="form-control textlabel"/>';
                            item.VehicleNo = '<input type=\'text\' name="Details[' + i + '].VehicleNo" id="txtVehicleNo' + i + '" value=' + item.VehicleNo + ' class="form-control textlabel"/>';
                            item.FuelQty = '<input type=\'text\' name="Details[' + i + '].FuelQty" id="txtFuelQty' + i + '" value=' + item.FuelQty + ' class="form-control textlabel"/>';
                            item.FuelRate = '<input type=\'text\' name="Details[' + i + '].FuelRate" id="txtFuelRate' + i + '" value=' + item.FuelRate + ' class="form-control textlabel"/>';
                            //item.DocumentNo = '<label name="Details[' + i + '].DocumentNo" id="lblDocumentNo' + i + '" class="label-bold"/>' + item.DocumentNo + '</label>' +
                            //    '<input type=\'hidden\' value=' + i + '  id=\'hdnRowId' + i + '\'/>' +
                            //    '<input type=\'hidden\' value=' + item.DocumentId + ' name="Details[' + i + '].DocumentId" id=\'hdnDocumentId' + i + '\'/>' +
                            //    '<input type=\'hidden\' value=' + item.DocumentTypeId + ' name="Details[' + i + '].DocumentTypeId" id=\'hdnDocumentTypeId' + i + '\'/>';

                            item.NetAmount = '<input type=\'text\' name="Details[' + i + '].NetAmount" id="txtNetAmount' + i + '" value=' + item.BalanceAmount + ' class="form-control textlabel numeric2"/>';
                            item.BalanceAmount = '<input type=\'text\' name="Details[' + i + '].BalanceAmount" id="txtBalanceAmount' + i + '" value=' + item.BalanceAmount + ' class="form-control textlabel numeric2"/>';
                        });
                        dtDocumentDetailList.dtAddData(result);
                    }
                    DisableDocumentDetail();
                //var table = $('#dtDocumentDetailList').DataTable();

                //if (itemlistIndex != 13) {
                //    DisableDocumentDetail();
                //    table.column(2).visible(false, false);
                //    table.column(3).visible(false, false);
                //    table.column(4).visible(false, false);
                //    table.column(5).visible(false, false);
                //    table.column(6).visible(false, false);
                //}
                //else {
                //    table.column(7).visible(false, false);
                //    table.column(8).visible(false, false);
                //    table.column(9).visible(false, false);
                //}
                //table.columns.adjust().draw(false);// adjust column sizing and redraw
                dtDocumentDetailList.removeClass('dataTable');
            }
            SetGstDetail();
            if (itemlistIndex != 13)
                SetOtherCharges();
        }, ErrorFunction, false);

        if (itemlistIndex == 13) {
            txtBillAmount.val(0);
            txtContractAmount.val(0);
        }
        else {
            txtBillAmount.val(totalBillAmount);
            txtContractAmount.val(totalContractAmount);
        }
        var loginLocationCode = $("#hdnPaymentLocationCode").val();
        $("#txtPaymentLocation").val(loginLocationCode);
        return false;
    }
}

function SelectDocumentDetail() {
    selectedDocumentDetailList = [];
    totalBillAmount = 0;
    totalContractAmount = 0;

    $('[id*="chkDocumentDetail"]').each(function () {
        var chkDocumentDetail = $(this);
        if (chkDocumentDetail.IsChecked) {
            if (itemlistIndexPub != 13) {
                var txtContractAmount = $('#' + chkDocumentDetail.Id.replace('chkDocumentDetail', 'txtContractAmount'));
                var txtBalanceAmount = $('#' + chkDocumentDetail.Id.replace('chkDocumentDetail', 'txtBalanceAmount'));
                totalBillAmount += parseFloat(txtBalanceAmount.val());
                totalContractAmount += parseFloat(txtContractAmount.val());
            }
            else {
                var txtBalanceAmount = $('#' + chkDocumentDetail.Id.replace('chkDocumentDetail', 'txtBalanceAmount'));
                totalBillAmount += parseFloat(txtBalanceAmount.val());
            }
        }
    });

    txtBillAmount.val(totalBillAmount);
    txtContractAmount.val(totalContractAmount);

}

function SetGstDetail() {
    $('#lblGstServiceTypeCode').text($("#ddlGstServiceTypeId :selected").text());

    if (ddlVendorGstStateId.val() == ddlCompanyGstStateId.val()) {

        $('#lblIsInterState').text('Yes');
        $('#hdnIsInterState').val(true);
    }
    else {

        $('#lblIsInterState').text('No');
        $('#hdnIsInterState').val(false);
    }

    //if (ddlGstTypeId.val() == 3) {
    //    $('#lblIsInterState').text('Yes');
    //    $('#hdnIsInterState').val(true);
    //    gstDetails.IsInterState = $('#hdnIsInterState').val();

    //}
    //else if (ddlGstTypeId.val() == 1)
    //{
    //    $('#lblIsInterState').text('No');
    //    $('#hdnIsInterState').val(false);
    //    gstDetails.IsInterState = $('#hdnIsInterState').val();
    //}
    //else {
    //    $('#lblIsInterState').text('No');
    //    $('#hdnIsInterState').val(false);
    //    gstDetails.IsInterState = "";

    //}

    //if (ddlGstTypeId.val() != '4') {
    //    $('#lblIsGstRegistered').text('Yes');
    //    $('#hdnIsGstRegistered').val(1);
    //}
    //else {
    //    $('#lblIsGstRegistered').text('No');
    //    $('#hdnIsGstRegistered').val(0);
    //}

    $('#lblVendorStateName').text($("#ddlVendorGstStateId :selected").text());
    $('#lblCompanyStateName').text($("#ddlCompanyGstStateId :selected").text());

    //$('#ddlGstVendorLocationId').enable($('#hdnIsGstRegistered').val() == 1);
    //$('#ddlGstVendorCityId').enable(hdnVendorId.val() == 1);
    //$('#ddlGstCompanyLocationId').enable($('#hdnIsGstRegistered').val() == 1);
    //$('#ddlGstCompanyCityId').enable(false);

}

function SetOtherCharges() {
    isSuccessfull = true;
    AjaxRequestWithPostAndJson(vendorPaymentUrl + '/GetBillCharges', '', function (responseData) {
        chargeList = responseData.OtherChargeList.sort(ComparerTax);
        chargeListCount = responseData.OtherChargeList.length;
        List = responseData.OtherChargeList;
        $.each(chargeList, function (i, item) {
            if (!isChargesAdded) {
                if (chargeCounter == 0)
                    $('#dtDocumentDetailList tr:first').find('th:eq(5)').before('<th>' + item.ChargeName + '(' + (item.IsOperator ? '+' : '-') + ')' + '</th>');
                else
                    $('#dtDocumentDetailList tr:first').find('th:eq(' + (chargeCounter + 5) + ')').before('<th>' + item.ChargeName + '(' + (item.IsOperator ? '+' : '-') + ')' + '</th>');
                chargeCounter++;
            }
        });
        chargeList.sort(ComparerTax).reverse();
        $.each(chargeList, function (i, item) {
            chargeCount = responseData.OtherChargeList[i].ChargeCode;
            $('#dtDocumentDetailList tr:gt(0)').each(function () {
                var tr = $(this);
                var trId = tr.find('[id*="hdnRowId"]').val();
                var chargeDocumentId = tr.find('[id*="hdnDocumentId"]').val();
                var chargeDocumentTypeId = tr.find('[id*="hdnDocumentTypeId"]').val();
                tr.find('td:eq(5)').before
                    ('<td><input class="form-control numeric2" data-val="true" data-val-required="Please enter ' + item.ChargeName + '" value= "' + item.ChargeAmount.toFixed(2) + '"' +
                        'name="ChargeList[' + trId + '].txtCharge' + i + '_' + trId + '" id="txtCharge' + i + '_' + trId + '" type="text" onblur=\'CalculateNetAmount(this,"' + trId + '");\' />' +
                        '<span data-valmsg-for="txtCharge' + i + '_' + trId + '" data-valmsg-replace="true"></span>' +
                        '<input type="hidden" id="hdnChargeCode' + i + '_' + trId + '" value="' + item.ChargeCode + '"/>' +
                        '<input type="hidden" id="hdnOperator' + i + '_' + trId + '" value="' + (item.IsOperator ? '+' : '-') + '"/>' +
                        '<input type=\'hidden\' value=' + chargeDocumentId + ' name="ChargeList[' + trId + '].DocumentId" id=\'hdnDocumentId' + i + '_' + trId + '\'/>' +
                        '<input type=\'hidden\' value=' + chargeDocumentTypeId + ' name="ChargeList[' + trId + '].DocumentTypeId" id=\'hdnDocumentTypeId' + i + '_' + trId + '\'/>' +
                        '</td>');
            });
        });
        if (chargeList.length > 0)
            isChargesAdded = true;
    }, ErrorFunction, false);
}

function CalculateNetAmount(obj, trId) {
    var totalCharge = 0.00;
    var tr = $(obj).closest('tr');
    tr.find('[id*="txtCharge"]').each(function () {
        var txtCharge = $(this);
        var hdnOperator = $('#' + this.id.replace('txtCharge', 'hdnOperator'));
        if (hdnOperator.val() == '+')
            totalCharge += parseFloat(txtCharge.val());
        else
            totalCharge -= parseFloat(txtCharge.val());
    });
    var txtNetAmount = tr.find('[id*="txtNetAmount"]');
    var txtBalanceAmount = tr.find('[id*="txtBalanceAmount"]');
    txtNetAmount.val(parseFloat(parseFloat(txtBalanceAmount.val()) + parseFloat(totalCharge)).toFixed(2));
    CountTotalBillAmount();
}

function CountTotalBillAmount() {
    var totalBillAmount = 0.00;
    $('[id*="txtNetAmount"]').each(function () {
        totalBillAmount += parseFloat($(this).val());
    });
    if (itemlistIndexPub != 13) {
        txtBillAmount.val(parseFloat(totalBillAmount).toFixed(2));
    }
}


function GetSubTotalAmount() {
    var arrChargeList = [];
    $('#dtDocumentDetailList > tbody > tr').each(function () {
        var tr = $(this);
        tr.find('[id*="hdnChargeCode"]').each(function () {
            var charge = {};
            charge.ChargeCode = $(this).val();
            charge.DocumentId = $('#' + $(this).Id.replace('hdnChargeCode', 'hdnDocumentId')).val();
            charge.DocumentTypeId = $('#' + $(this).Id.replace('hdnChargeCode', 'hdnDocumentTypeId')).val();
            charge.ChargeAmount = $('#' + $(this).Id.replace('hdnChargeCode', 'txtCharge')).val();
            arrChargeList.push(charge);
        });
    });
    hdnVendorChargeList.val(JSON.stringify(arrChargeList));
    CountTotalBillAmount();
    txtSubTotal.val(txtBillAmount.val());
    hdnServiceTaxApplicableAmount.val(txtBillAmount.val());
    //hdnTdsApplicableAmount.val(txtBillAmount.val());
    var totalAdvanceAmount = 0;
    $('[id*="txtAdvanceAmount"]').each(function () {
        var txtAdvanceAmount = $(this);
        totalAdvanceAmount = totalAdvanceAmount + parseFloat(txtAdvanceAmount.val());
    });
    
    //if (itemlistIndexPub != 13)
    //    hdnTdsApplicableAmount.val(txtContractAmount.val());
    if (itemlistIndexPub != 13) {
        hdnTdsApplicableAmount.val(parseFloat(txtBillAmount.val()) + totalAdvanceAmount);
        hdnServiceTaxApplicableAmount.val(parseFloat(txtBillAmount.val()) + totalAdvanceAmount);
    }
    else 
        hdnTdsApplicableAmount.val(txtBillAmount.val());
    GetTaxDetails();
}

function CalculateDueDate() {

    var creditDays;
    if (txtBillDateTime.val() != '') {
        var requestData = { vendorId: hdnVendorId.val() };
        AjaxRequestWithPostAndJson(vendorContractMasterUrl + '/GetCreditDaysByVendorId', JSON.stringify(requestData), function (result) {
            creditDays = result;
        }, ErrorFunction, false);
        var dueDate = $.setDateTime(txtBillDateTime.val()).add(creditDays, 'd');
        $('#txtBillDueDate').val($.entryDate(dueDate));
    }

}

function DisableDocumentDetail() {
    $('[id*="chkDocumentDetail"]').each(function () {
        var chkDocumentDetail = $(this);
        chkDocumentDetail.attr("checked", true);
        chkDocumentDetail.disable();
    });
    $("#chkAllDocumentDetail").attr("checked", true);
    $("#chkAllDocumentDetail").disable();
}

function SetGSTCalculationType() {
    alert(11);
    /* alert(gstDetails.IsInterState);
     gstDetails.IsInterState = $('#hdnIsInterState').val();
     alert(gstDetails.IsInterState);
     alert(12);*/
}