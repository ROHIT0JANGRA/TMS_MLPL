
function InitGstObjects() {
    ddlGstState.change(function () {
        SetStateGstTin(ddlGstState, hdnGstStateId, hdnGstTinNo, true, txtPartyGstTinNo, hdnPartyGstId);
        ChangeGSTState();
    }).change();
    ddlCompanyGstState.change(function () {
        GSTOnCompany();
        ChangeGSTState();
        ///SetStateGstTin(ddlCompanyGstState, hdnCompanyGstStateId, hdnCompanyGstTinNo, false, txtCompanyGstTinNo, hdnCompanyGstId);
    }).change();
}

var gstDetails = { IsState: true, IsEdit: false, WalkingGstTinNo: '', DeclarationFileName: '' };

function ChangeGSTState()
{
    var value;
    var value1;

    if (!IsObjectNullOrEmpty(ddlGstState.val()) && !IsObjectNullOrEmpty(ddlCompanyGstState.val())) {

        value = ddlGstState.val().split('~');
        value1 = ddlCompanyGstState.val().split('~');

        if (value[0] != value1[0]) {
            gstDetails.IsInterState = true;
            //gstDetails.IsGst = true;
        }
        else {
            gstDetails.IsInterState = false;
            //gstDetails.IsGst = false;
        }

        hdnIsInterState.val(gstDetails.IsInterState);

        if (gstDetails.IsInterState)
            lblIsInterState.text('Inter State');
        else
            lblIsInterState.text('Intra State');

        CalculateGST();
    }

}

function GSTOnCompany() {

    // ddlGstState
    
    var value;
    var value1;
    //hdnStateCode, hdnGstTin, isCustomer, txtGstTin, hdnGstId

    ChangeGSTState();

    if (!IsObjectNullOrEmpty(ddlCompanyGstState.val())) {

        //value = ddlGstState.val().split('~');
        //value1 = ddlCompanyGstState.val().split('~');

        //if (value[0] != value1[0])
        //{
        //    gstDetails.IsInterState = true;
        //}
        //else
        //{
        //    gstDetails.IsInterState = false;
        //}

        //hdnIsInterState.val(gstDetails.IsInterState);

        //if (gstDetails.IsInterState)
        //    lblIsInterState.text('Inter State');
        //else
        //    lblIsInterState.text('Intra State');

        var stateGst = ddlCompanyGstState.val().split('~');
        hdnCompanyGstStateId.val(stateGst[0]);
        txtCompanyGstTinNo.val(stateGst[1]);
        txtCompanyGstTinNo.readOnly(stateGst[1] != '');
        hdnCompanyGstTinNo.val(stateGst[1]);
        hdnCompanyGstId.val(stateGst[3]);
    }
}

function CalculateGST() {
    if (gstDetails.IsGst) {

        if ($("#ddlGstPayer :selected").text() == "Billing Party")
        {
            lblIsRcm.text('Yes');
            $('#hdnIsRcm').val(true);
        }
        else
        {
            lblIsRcm.text(gstDetails.IsRcm && gstDetails.ApplyGst ? 'Yes' : 'No');
            $('#hdnIsRcm').val(gstDetails.IsRcm && gstDetails.ApplyGst ? true : false);
        }
        CalculateTotal();
    }
}

function ValidateGstDetails() {
    if (gstDetails.IsGst && lblGstBillingParty.text() == '') {
        ShowMessage('Please select GST Billing Party');
        return false;
    }
    if (gstDetails.IsGst && txtCompanyGstTinNo.val() == '') {
        ShowMessage('Please select Company GST State');
        return false;
    }
    if (gstDetails.IsGst && txtPartyGstTinNo.val() == '' && hdnDeclarationFileName.val() == '') {
        ShowMessage('Please complete GST registration');
        return false;
    }
    gstDetails.IsRcm = gstDetails.ApplyGst;
    return true;
}

function OnGstServiceTypeChange() {
    $.each(gstSacDetails, function (i, item) {
        if (item.ServiceTypeId == ddlGstServiceType.val()) {
            hdnGstSacId.val(item.SacId);
            lblGstSacName.text(item.SacName);
           
            hdnGstServiceTypeId.val(item.ServiceTypeId);
            lblGstServiceType.text(item.ServiceType);
            txtGstRate.val(item.GstRate);
            gstDetails.GstRate = item.GstRate;
            gstDetails.IsRcm = item.IsRcm;
            gstDetails.GstSacId = item.SacId;
            gstDetails.GstServiceTypeId = item.ServiceTypeId;

            gstDetails.TransportMode = $("#ddlTransportMode :selected").text();
            SetGstRateAndCategory();
        }
    });
}


function SetGstRateAndCategory() {
    if (gstDetails.IsGst) {

        //lblGstBillingParty.text(gstDetails.CustomerCode + ' : ' + gstDetails.CustomerName);
        lblTransportMode.text(gstDetails.TransportMode);

        lblGstSacName.text(gstDetails.GstSacName);
        lblGstServiceType.text(gstDetails.GstServiceType);

        hdnGstSacId.val(gstDetails.GstSacId);
        hdnGstServiceTypeId.val(gstDetails.GstServiceTypeId);
        BindCustomerGstState();
        //rdBillingParty.prop('checked', false);
        //rdTransporter.prop('checked', true);
        //BindGstState();

        //rdBillingParty.prop('checked', true);
        //rdTransporter.prop('checked', false);
        //BindGstState();

        if (gstDetails.IsEdit) {
            if ($('#' + controlIdPrefix + 'hdnGstPayer').val() == 'P') {
                ddlGstPayer.val(3);
                ddlGstState.val('');
                $("#" + ddlGstState.attr('id') + " > option").each(function () {
                    if (this.value.indexOf(hdnGstStateId) != -1)
                        ddlGstState.val(this.value);
                });
            }
            else {
                ddlGstPayer.val(4);
            }
        }
        $('#trBillingPartySelection').hide();
        CalculateGST();
    }

    ShowHideGstDetails();
}

function BindGstState(company) {
    
    var requestData = {};
    requestData.ownerId = ddlGstPayer.val() == '4' ? loginCompanyId : ddlGstPayer.val() == '3' ? gstDetails.CustomerId : ddlGstPayer.val() == '2' ? hdnConsigneeId.val() : hdnConsignorId.val();
    requestData.ownerType = ddlGstPayer.val() == '4' ? '1' : '3';
    requestData.locationId = 0;
    if (company != null && company != undefined) {
        requestData.ownerType = '1';
        requestData.ownerId = loginCompanyId;
    }
    if (requestData.ownerType == '1') {
        SetBillLocation();
        requestData.locationId = hdnBillLocationId.val();
    }

    if (gstDetails.WalkingGstTinNo != '') {
        requestData.ownerId = gstDetails.WalkingGstTinNo;
        requestData.ownerType = '3';
        requestData.locationId = 0;
    }
    gstDetails.GstPayer = requestData.ownerType;

    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstStateList', JSON.stringify(requestData), function (result) {
        // if (requestData.ownerType == '1' && ddlGstPayer.val() == '4') {
        var ddlState = requestData.ownerType == '1' && ddlGstPayer.val() == '4' && company == null && company == undefined ? ddlGstState : requestData.ownerType == '1' ? ddlCompanyGstState : ddlGstState;
        var hdnStateCode = requestData.ownerType == '1' && ddlGstPayer.val() == '4' && company == null && company == undefined ? hdnGstStateId : requestData.ownerType == '1' ? hdnCompanyGstStateId : hdnGstStateId;
        var hdnGstTin = requestData.ownerType == '1' && ddlGstPayer.val() == '4' && company == null && company == undefined ? hdnGstTinNo : requestData.ownerType == '1' ? hdnCompanyGstTinNo : hdnGstTinNo;
        var txtGstTin = requestData.ownerType == '1' && ddlGstPayer.val() == '4' && company == null && company == undefined ? txtPartyGstTinNo : requestData.ownerType == '1' ? txtCompanyGstTinNo : txtPartyGstTinNo;
        var hdnGstId = requestData.ownerType == '1' && ddlGstPayer.val() == '4' && company == null && company == undefined ? hdnPartyGstId : requestData.ownerType == '1' ? hdnCompanyGstId : hdnPartyGstId;
        // }
        //else {
          
        //    var hdnStateCode = requestData.ownerType == '1' ? hdnCompanyGstStateId : hdnGstStateId;
        //    var hdnGstTin = requestData.ownerType == '1' ? hdnCompanyGstTinNo : hdnGstTinNo;
        //    var txtGstTin = requestData.ownerType == '1' ? txtCompanyGstTinNo : txtPartyGstTinNo;
        //    var hdnGstId = requestData.ownerType == '1' ? hdnCompanyGstId : hdnPartyGstId;

        //}

        ddlState.empty();
        if (result.length == 0 && isBindAllGstState == true) {
            var request = {};
            request.ownerId = 1;
            request.ownerType = 3;
            request.locationId = 0;
            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstStateList', JSON.stringify(request), function (resultData) {
                BindDropDownList(ddlState.Id, resultData, 'Value', 'Name', '', 'Select Gst State');
            }, ErrorFunction, false);
        }
        else {
            BindDropDownList(ddlState.Id, result, 'Value', 'Name', '', 'Select Gst State');
        }

        ddlState.refresh();
        //BindDropDownList(ddlState.Id, result, 'Value', 'Name', '', 'Select State');

        SetStateGstTin(ddlState, hdnStateCode, hdnGstTin, requestData.ownerType != '1', txtGstTin, hdnGstId);

        if (requestData.ownerType != '1' && hdnDeclarationFileName.val() == '')
            ShowHideRegisterGst(result.length == 0);

        if (requestData.ownerType != '1') {
            if (ddlGstState.find("option").length == 0) {
                ddlGstPayer.val('4');
                CalculateGST();
            }
        }
    }, ErrorFunction, false);
}

function BindCustomerGstState() {
    var requestData = {};
    requestData.ownerId = hdnCustomerId.val();// ddlGstPayer.val() == '4' ? loginCompanyId : ddlGstPayer.val() == '3' ? gstDetails.CustomerId : ddlGstPayer.val() == '2' ? hdnConsigneeId.val() : hdnConsignorId.val();
    requestData.ownerType = '3';
    requestData.locationId = 0;
    gstDetails.GstPayer = '3';

    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstStateList', JSON.stringify(requestData), function (result) {
        // if (requestData.ownerType == '1' && ddlGstPayer.val() == '4') {
        var ddlState = ddlGstState;
        var hdnStateCode = hdnGstStateId;// requestData.ownerType == '1' && ddlGstPayer.val() == '4' && company == null && company == undefined ? hdnGstStateId : requestData.ownerType == '1' ? hdnCompanyGstStateId : hdnGstStateId;
        var hdnGstTin = hdnGstTinNo; // requestData.ownerType == '1' && ddlGstPayer.val() == '4' && company == null && company == undefined ? hdnGstTinNo : requestData.ownerType == '1' ? hdnCompanyGstTinNo : hdnGstTinNo;
        var txtGstTin = txtPartyGstTinNo;// requestData.ownerType == '1' && ddlGstPayer.val() == '4' && company == null && company == undefined ? txtPartyGstTinNo : requestData.ownerType == '1' ? txtCompanyGstTinNo : txtPartyGstTinNo;
        var hdnGstId = hdnPartyGstId;// requestData.ownerType == '1' && ddlGstPayer.val() == '4' && company == null && company == undefined ? hdnPartyGstId : requestData.ownerType == '1' ? hdnCompanyGstId : hdnPartyGstId;

        ddlState.empty();
        if (result.length == 0 && isBindAllGstState == true) {
            var request = {};
            request.ownerId = 1;
            request.ownerType = 3;
            request.locationId = 0;
            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstStateList', JSON.stringify(request), function (resultData) {
                BindDropDownList(ddlState.Id, resultData, 'Value', 'Name', '', 'Select Gst State');
            }, ErrorFunction, false);
        }
        else {
            BindDropDownList(ddlState.Id, result, 'Value', 'Name', '', 'Select Gst State');
        }

        ddlState.refresh();
        //BindDropDownList(ddlState.Id, result, 'Value', 'Name', '', 'Select State');

        SetStateGstTin(ddlState, hdnStateCode, hdnGstTin, requestData.ownerType != '1', txtGstTin, hdnGstId);

        if (requestData.ownerType != '1' && hdnDeclarationFileName.val() == '')
            ShowHideRegisterGst(result.length == 0);

        if (requestData.ownerType != '1') {
            if (ddlGstState.find("option").length == 0) {
                ddlGstPayer.val('4');
                CalculateGST();
            }
        }
    }, ErrorFunction, false);
}


function ShowHideRegisterGst(isRegister) {
    dvGstTinNoDetail.showHide(isRegister);
    dvRegisterGstDetail.showHide(isRegister);
}

function SetStateGstTin(ddlState, hdnStateCode, hdnGstTin, isCustomer, txtGstTin, hdnGstId) {
    if (ddlState.val() == '0' || IsObjectNullOrEmpty(ddlState.val()) || $("#" + ddlState.attr('id') + " > option").length == 0) {
        txtGstTin.val('');
        hdnStateCode.val(0);
        hdnGstTin.val('');
        gstDetails.ApplyGst = false;
        gstDetails.IsState = true;
    }
    else {
        var stateGst = ddlState.val().split('~');
        hdnStateCode.val(stateGst[0]);
        hdnGstTin.val(stateGst[1]);
        txtGstTin.val(stateGst[1]);
        //if (stateGst[1] == '')
        //    SetBillingPartyGstTinNo(ddlGstPayer.val(), true);
        txtGstTin.readOnly(stateGst[1] != '');
        if (isCustomer)
            gstDetails.ApplyGst = true;
        gstDetails.IsState = stateGst[2] == "0";
        hdnGstId.val(stateGst[3]);
    }
    CheckGstInterState();
}

var BillingState;
function CheckGstInterState() {
    if (gstDetails.IsGst) {
        SetBillLocation();
        var isCheck = false;
        if (gstDetails.BillLocation == null) {
            gstDetails.BillLocation = hdnBillLocationId.val();
            isCheck = true;
        }
        if (gstDetails.BillLocation != hdnBillLocationId.val() || isCheck) {
            gstDetails.BillLocation = hdnBillLocationId.val();
            var requestData = { locationId: hdnBillLocationId.val() == 0 ? 1 : hdnBillLocationId.val() };
            AjaxRequestWithPostAndJson(gstMasterUrl + '/GetStateByLocation', JSON.stringify(requestData), function (result) {
                if (result == 0)
                    ShowMessage('There is some issue while fetching Billing State');
                else {
                    //gstDetails.IsInterState = hdnStateId.val() != result;
                    //hdnIsInterState.val(gstDetails.IsInterState);
                    //lblIsInterState.text(gstDetails.IsInterState ? 'Inter State' : 'Intra State');
                    //CalculateTotal();
                    BillingState = result;
                    BindGstState('company');
                }
            }, ErrorFunction, false);
        }
        //if (BillingState != null && BillingState != undefined) {
        //    //gstDetails.IsInterState = hdnGstStateId.val() != BillingState;
        //    //hdnIsInterState.val(gstDetails.IsInterState);
        //    //if (gstDetails.IsInterState)
        //    //    lblIsInterState.text('Inter State');
        //    //else
        //    //    lblIsInterState.text('Intra State');
        //    CalculateGST();
        //}
    }
}

function SetBillLocation() {
    if (!$('#hdnIsManualBillLocationEntry').val() =='true') {
        if (txtBillLocation.val() == '') {
            if (ddlPaybas.val() == '3') {
                txtBillLocation.val(txtToLocation.val());
                hdnBillLocationId.val(hdnToLocationId.val());
            }
            else {
                txtBillLocation.val(lblFromLocation.text());
                hdnBillLocationId.val(loginLocationId);
            }
        }
    }
}

function RegisterGst() {
    OpenGstRegisterForm();
}

function SetGstPayer() {
    if (hdnDeclarationFileName.val() == '') {
        rdBillingParty.prop('checked', true);
        rdTransporter.prop('checked', false);
        gstDetails.ApplyGst = true;
    }
    else {
        rdBillingParty.prop('checked', false);
        rdTransporter.prop('checked', true);
        gstDetails.ApplyGst = false;
    }
    if ($('#hdnWalkinCode').val() != '')
        gstDetails.CustomerCode = $('#hdnWalkinCode').val();

   // lblGstBillingParty.text(gstDetails.CustomerCode + ' : ' + gstDetails.CustomerName);
}

function ProcessorGstDetails() {
    hdnDeclarationFileName.val(gstDetails.DeclarationFileName);
    hdnWalkingGstTinNo.val(gstDetails.WalkingGstTinNo);
    SetGstPayer();
    if (hdnDeclarationFileName.val() == '') {
        BindCustomerGstState();
        ddlGstState.focus();
    }
    else
        ShowHideRegisterGst(false);
    CalculateGST();
    ddlGstState.enable(!(ddlGstState.find('option').length == 1 && ddlGstState.val() == '')).refresh();
}

function ShowHideGstDetails(showHide) {
    if (showHide == null || showHide == undefined) showHide = gstDetails.IsGst;
    $('[id*="dvGst"]').showHide(showHide);
}

function GetCustomerGstDetail() {
    var requestData = { customerId: hdnCustomerId.val(), cityId: hdnFromCityId.val() };
    AjaxRequestWithPostAndJson(gstMasterUrl + '/GetCustomerGstDetailByCustomerIdAndCityId', JSON.stringify(requestData), function (result) {
        if (!IsObjectNullOrEmpty(result)) {
            ddlGstState.append($('<option></option>').val(result.StateId).html(result.StateName));
            ddlGstState.val(result.StateId);
            dvRegisterGstDetail.showHide(result.StateId == 0);
            txtPartyGstTinNo.val(result.GstTinNo);
        }
        lblTransportMode.text(($("#ddlTransportMode :selected").text()));
    }, ErrorFunction, false);

}




