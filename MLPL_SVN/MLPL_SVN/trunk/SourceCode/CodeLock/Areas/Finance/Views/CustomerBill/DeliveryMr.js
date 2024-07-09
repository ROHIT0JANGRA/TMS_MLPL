var rdIsReceiver, rdIsConsignee, chkIsIsPartial, lblDeliverCode, hdnDeliverId, txtDeliverCode, lblDeliverName, txtDocketNos, ddlDocketSuffix, dtDocketList, hdnDeliveryMrChargeList, hdnTotalBillAmount, txtMrDate;
var chargeListCount = 0, chargeCount = 0, isChargesAdded = false, chargeCounter = 0, docketCount = 0, totalBillAmount = 0;

$(document).ready(function () {
    SetPageLoad('Delivery MR', 'Delivery Money Receipt', 'txtDeliverCode', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    rdIsReceiver = $('#rdIsReceiver');
    rdIsConsignee = $('#rdIsConsignee');
    chkIsIsPartial = $('#chkIsIsPartial');
    lblIsDeliveredFromMaster = $('#lblIsDeliveredFromMaster');
    txtMrDate = $('#txtMrDate');
    rdPartyFromMaster = $('#rdPartyFromMaster');
    rdPartyWalkin = $('#rdPartyWalkin');
    lblDeliverCode = $('#lblDeliverCode');
    hdnDeliverId = $('#hdnDeliverId');
    lblDeliverNameLabel = $('#lblDeliverNameLabel');
    txtDeliverCode = $('#txtDeliverCode');
    lblDeliverName = $('#lblDeliverName');
    txtDeliverName = $('#txtDeliverName');
    dvGstTinNo = $('#dvGstTinNo');
    txtGstTinNo = $('#txtGstTinNo');
    txtDocketNos = $('#txtDocketNos');
    ddlDocketSuffix = $('#ddlDocketSuffix');
    lblConsignorName = $('#lblConsignorName');
    lblConsigneeName = $('#lblConsigneeName');
    hdnPartyId = $('#hdnPartyId');
    txtPartyCode = $('#txtPartyCode');
    lblPartyName = $('#lblPartyName');
    txtPartyName = $('#txtPartyName');
    hdnDeliveryMrChargeList = $('#hdnDeliveryMrChargeList');
    hdnTotalBillAmount = $('#hdnTotalBillAmount');
    txtReceiptNetReceivedAmount = $('#txtReceiptNetReceivedAmount');
    dvPartyDetail = $('#dvPartyDetail');
    dvStep1 = $('#dvStep1');
    dvStep2 = $('#dvStep2');
    dvStep3 = $('#dvStep3');
    dvrecept = $('#dvrecept');
    btnStep1 = $('#btnStep1');
    btnStep2 = $('#btnStep2');
    btnSubmit = $('#btnSubmit');
    
    

    ddlDocketSuffix.val('.');
    //InitWizard('dvWizard', [
    //    { StepName: 'Criteria', StepFunction: GetDocketList },
    //    { StepName: 'Docket List', StepFunction: SetReceiptDetail },
    //    { StepName: 'Payment Details' }
    //], 'Generate Delivery Mr');
    $("#dvPartialStep").showHide(chkIsIsPartial.is(":checked"));
}

function AttachEvents() {
    
    chkIsIsPartial.change(IsIsPartialAdvApplyChange);
    rdPartyFromMaster.click(function () { ManageDeliveredParty(rdPartyFromMaster.IsChecked); }).click();
    rdPartyWalkin.click(function () { ManageDeliveredParty(rdPartyFromMaster.IsChecked); });
    rdIsReceiver.click(function () { ManageDeliveredTo(); }).click();
    rdIsConsignee.click(function () { ManageDeliveredTo(); });
    CustomerAutoComplete(txtPartyCode.Id, hdnPartyId.Id, 'Delivered Party');
    txtPartyCode.blur(function () { IsCustomerCodeExist(txtPartyCode, hdnPartyId, lblPartyName, 'Delivered Party'); txtPartyName.val(lblPartyName.text()) });
    btnStep1.click(function () { if (IsStepValid(dvStep1)) GetDocketList(false); });
    btnStep2.click(function () { if (IsStepValid(dvStep2)) SetReceiptDetail(); });
    btnSubmit.click(function () {
        if (IsStepValid(dvStep3)) {
            dvStep3.pointerEvent(false);
            return true;
        }
        else
            return false;
    });
}
function IsIsPartialAdvApplyChange() {
    CalculateNetAmount();
    $("#dvPartialStep").showHide(chkIsIsPartial.is(":checked"));
    if (!chkIsIsPartial.IsChecked) {
        txtDeliverCode.val('');
        lblDeliverName.val('');
        txtDeliverName.val('');
        hdnDeliverId.val('');
        $("#dvrecept").showHide(true);
    }
    else {
         $("#dvrecept").showHide(false);
    }
   
}
function ManageDeliveredTo() {
    txtDeliverCode.val('');
    lblDeliverName.val('');
    txtDeliverName.val('');
    hdnDeliverId.val('');
    txtDeliverCode.off("blur");
    txtDeliverName.autocomplete({ source: [] });
    if (rdIsReceiver.IsChecked) {
        lblDeliverCode.text('Receiver Code');
        lblDeliverNameLabel.text('Receiver Name');
        dvGstTinNo.hide();
        ReceiverAutoCompleteByLocation(txtDeliverCode.Id, hdnDeliverId.Id, loginLocationId, 'Receiver');
        RemoveRequired(txtDeliverCode);
        AddRequired(txtDeliverCode, "Please enter Receiver");
        AddRequired(txtDeliverName, "Please enter Receiver Name");
        txtDeliverCode.blur(function () {
            IsReceiverCodeExistByLocation($(this), hdnDeliverId, lblDeliverName, loginLocationId, 'Receiver');
            txtDeliverName.val(lblDeliverName.text());
        });
    }
    else {
        lblDeliverCode.text('Consignee Code');
        lblDeliverNameLabel.text('Consignee Name');
        dvGstTinNo.show();
        CustomerAutoCompleteByLocation(txtDeliverCode.Id, hdnDeliverId.Id, loginLocationId, 'Consignee');
        ConsigneeAutoComplete(txtDeliverName.Id, hdnDeliverId.Id, 'Consignee', false);
        RemoveRequired(txtDeliverCode);
        AddRequired(txtDeliverCode, "Please enter Consignee");
        AddRequired(txtDeliverName, "Please enter Consignee Name");

        txtDeliverName.blur(function () {
                var requestData = { consigneeName: txtDeliverName.val() };
                AjaxRequestWithPostAndJson(ReplaceUrl('Customer', 'GetConsigneeDetailByName'), JSON.stringify(requestData), function (result) {
                    if (!IsObjectNullOrEmpty(result.ConsigneeGstTinNo)) 
                        txtGstTinNo.val(result.ConsigneeGstTinNo);
                    else
                        txtGstTinNo.val('');
                });
        });
        txtDeliverCode.blur(function () {
            IsCustomerCodeExistByLocation($(this), hdnDeliverId, lblDeliverName, loginLocationId, 'Consignee');
            txtDeliverName.val(lblDeliverName.text());
            GetGstTinNo();
            GetDocketList(true);
        });
    }
    ManageDeliveredParty(rdPartyFromMaster.IsChecked);
}

function GetGstTinNo()
{
    var requestData = { customerId: hdnDeliverId.val() };
    AjaxRequestWithPostAndJson(ReplaceUrl('Customer', 'GetById'), JSON.stringify(requestData), function (result) {
        if (!IsObjectNullOrEmpty(result.MasterCustomerDetail.GstTinNo)) 
            txtGstTinNo.val(result.MasterCustomerDetail.GstTinNo);
        else
            txtGstTinNo.val('');
    });
}


function ManageDeliveredParty(isFromMaster) {
    txtDeliverName.val('');
    txtDeliverCode.readOnly(!isFromMaster);
    txtDeliverCode.val(isFromMaster ? '' : 'Walk-In');
    hdnDeliverId.val(isFromMaster ? '' : '1');
    txtDeliverName.toggleClass("textlabel label-bold", isFromMaster);
}

function GetDocketList(isChange) {
    if (txtDocketNos.val() == '')
        return false;
    else {
        var requestData = { isDeliveredByConsignee: rdIsConsignee.IsChecked, customerId: isChange == true ? hdnPartyId.val() : 0, docketNos: txtDocketNos.val(), docketSuffix: ddlDocketSuffix.val() };
        AjaxRequestWithPostAndJson(billGenerationUrl + '/GetMrDocketList', JSON.stringify(requestData), function (result) {
            if (dtDocketList == null)
                dtDocketList = LoadDataTable('dtDocketList', false, false, false, null, null, [],
                    [
                        { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllDocket', CalculateNetAmount) + "</div>", data: "DocketId", width: 80 },
                        { title: docketNomenclature, data: 'DocketNo', width: '100px' },
                        { title: 'Paybas', data: 'Paybas' },
                        { title: 'Vehicle No', data: 'VehicleNo' },
                        { title: 'Sub Total', data: 'SubTotal' },
                        //{ title: 'New Sub Total', data: 'NewSubTotal' },
                        //{ title: 'Rate Diffrent', data: 'RateDifferent' },
                        { title: 'Total Amount', data: 'TotalAmount' },
                        { title: 'Gst Amount(+)', data: 'TaxTotal' },
                        { title: 'Net Amount', data: 'DocketTotal' },
                        { title: 'Collection Amount', data: 'CollectionAmount' }
                    ]);

            dtDocketList.fnClearTable();
            dvStep2.showHide(result.length > 0);
            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {

                totalBillAmount = 0;
                $.each(result, function (i, item) {
                    totalBillAmount += parseFloat(item.DocketTotal).toFixed(2);
                    subTotal = item.SubTotal;
                    docketTotal = item.DocketTotal;
                    item.DocketId = SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'Details[' + i + '].IsChecked', CalculateNetAmount) +
                        '<input type=\'hidden\' value=' + item.DocketId + ' name="Details[' + i + '].DocketId" id=\'hdnDocketId' + i + '\'/>' +
                        '<input type=\'hidden\' value=' + item.DocketSuffix + ' name="Details[' + i + '].DocketSuffix" id=\'hdnDocketSuffix' + i + '\'/>';
                    item.DocketNo = '<label name="Details[' + i + '].DocketNo" id="lblDocketNo' + i + '" class="label-bold"/>' + item.DocketNo + item.DocketSuffix + '</label>' +
                        '<input type=\'hidden\' value=' + i + '  id=\'hdnRowId' + i + '\'/>' +

                        '<input type=\'hidden\' value=' + item.PaybasId + ' name="Details[' + i + '].PaybasId" id=\'hdnPaybasId' + i + '\'/>';
                    item.Paybas = '<input type=\'text\' name="Details[' + i + '].Paybas" id="txtPaybas' + i + '" value=' + item.Paybas + ' class="form-control textlabel"/>';
                    item.VehicleNo = '<input type=\'text\' name="Details[' + i + '].VehicleNo" id="txtVehicleNo' + i + '" value=' + item.VehicleNo + ' class="form-control textlabel"/>';
                    item.SubTotal = '<input type=\'text\' name="Details[' + i + '].SubTotal" id="txtSubTotal' + i + '" value=' + item.SubTotal + ' class="form-control textlabel numeric2"/>';
                    //item.NewSubTotal = '<div class="input"><input type=\'text\' name="Details[' + i + '].NewSubTotal" id="txtNewSubTotal' + i + '"  data-val="true" data-val-required="Please enter New Subtotal" value=' + (item.PaybasId == 1 ? subTotal : item.NewSubTotal) + ' class="form-control numeric2"' + (item.PaybasId == 1 || item.PaybasId == 2 ? ' readOnly=readOnly' : ' ') + 'onblur=\'CalculateNetAmount();\'/></div>' +
                    //item.NewSubTotal = '<div class="input"><input type=\'text\' name="Details[' + i + '].NewSubTotal" id="txtNewSubTotal' + i + '"  data-val="true" data-val-required="Please enter New Subtotal" value=' + subTotal + ' class="form-control numeric2" onblur=\'CalculateNetAmount();\'/></div>' +
                    //    '<span data-valmsg-for="txtNewSubTotal" data-valmsg-replace="true"></span>';
                    //item.RateDifferent = '<input type=\'text\' name="Details[' + i + '].RateDifferent" id="txtRateDifferent' + i + '" value="0.00" class="form-control textlabel numeric2"/>';
                    item.TotalAmount = '<input type=\'text\' name="Details[' + i + '].TotalAmount" id="txtTotalAmount' + i + '" value="0.00" class="form-control textlabel numeric2"/>';
                    item.TaxTotal = '<input type=\'text\' name="Details[' + i + '].TaxTotal" id="txtTaxTotal' + i + '" value=' + item.TaxTotal + ' class="form-control textlabel numeric2"/>' +
                        '<input type=\'hidden\' value=' + item.TaxRate + ' name="Details[' + i + '].TaxRate" id=\'hdnTaxRate' + i + '\'/>' +
                        '<input type=\'hidden\' value=' + item.IsRcm + ' name="Details[' + i + '].IsRcm" id=\'hdnIsRcm' + i + '\'/>';
                    item.DocketTotal = '<input type=\'text\' name="Details[' + i + '].DocketTotal" id="txtDocketTotal' + i + '" value=' + (item.PaybasId == 2 ? '0.00' : item.DocketTotal) + ' class="form-control textlabel numeric2"/>';
                    item.CollectionAmount = '<input type=\'text\' name="Details[' + i + '].CollectionAmount" id="txtCollectionAmount' + i + '" value=' + (item.PaybasId == 2 ? '0.00' : docketTotal) + ' class="form-control textlabel numeric2"/>';
                });
                dtDocketList.dtAddData(result);
                dtDocketList.removeClass('dataTable');
                
            }
            SetDeliveryParty(result[0]);
            SetDeliveryCharges();
        }, ErrorFunction, false);

        hdnTotalBillAmount.val(totalBillAmount);
        return false;
    }
}

function SetDeliveryParty(objParty) {
    dvPartyDetail.showHide(objParty.IsSameDocketParty);
    lblConsignorName.text(objParty.ConsignorCode + ' : ' + objParty.ConsignorName);
    lblConsigneeName.text(objParty.ConsigneeCode + ' : ' + objParty.ConsigneeName);
    hdnPartyId.val(objParty.ConsigneeId);
    txtPartyCode.val(objParty.ConsigneeCode);
    lblPartyName.text(objParty.ConsigneeName);
    txtPartyName.val(objParty.ConsigneeName);
    if(rdIsReceiver.IsChecked)
        txtGstTinNo.val(objParty.ConsigneeGstTinNo);
}

function SetDeliveryCharges() {
    isSuccessfull = true;
    AjaxRequestWithPostAndJson(billGenerationUrl + '/GetDeliveryCharges', '', function (responseData) {
        chargeList = responseData.OtherChargeList.sort(responseData.OtherChargeList.ChargeCode);
        chargeListCount = responseData.OtherChargeList.length;
        List = responseData.OtherChargeList;
        $.each(chargeList, function (i, item) {
            if (!isChargesAdded) {
                if (chargeCounter == 0)
                    $('#dtDocketList tr:first').find('th:eq(5)').before('<th>' + item.ChargeName + '(' + (item.IsOperator ? '+' : '-') + ')' + '</th>');
                else
                    $('#dtDocketList tr:first').find('th:eq(' + (chargeCounter + 5) + ')').before('<th>' + item.ChargeName + '(' + (item.IsOperator ? '+' : '-') + ')' + '</th>');
                chargeCounter++;
            }
        });
        chargeList.sort(responseData.OtherChargeList.ChargeCode).reverse();
        $.each(chargeList, function (i, item) {
            chargeCount = responseData.OtherChargeList[i].ChargeCode;
            $('#dtDocketList tr:gt(0)').each(function () {
                var tr = $(this);
                var trId = tr.find('[id*="hdnRowId"]').val();
                var chargeDocketId = tr.find('[id*="hdnDocketId"]').val();
                var chargeDocketSuffix = tr.find('[id*="hdnDocketSuffix"]').val();
                tr.find('td:eq(5)').before
                    ('<td><div class="input"><input class="form-control numeric2" data-val="true" data-val-required="Please enter ' + item.ChargeName + '" value= "' + item.ChargeAmount.toFixed(2) + '"' +
                    'name="ChargeList[' + trId + '].txtCharge' + i + '_' + trId + '" id="txtCharge' + i + '_' + trId + '" type="text" onblur=\'CalculateNetAmount();\' /></div>' +
                    '<span data-valmsg-for="txtCharge' + i + '_' + trId + '" data-valmsg-replace="true"></span>' +
                    '<input type="hidden" id="hdnChargeCode' + i + '_' + trId + '" value="' + item.ChargeCode + '"/>' +
                    '<input type="hidden" id="hdnOperator' + i + '_' + trId + '" value="' + (item.IsOperator ? '+' : '-') + '"/>' +
                    '<input type=\'hidden\' value=' + chargeDocketId + ' name="ChargeList[' + trId + '].DocketId" id=\'hdnDocketId' + i + '_' + trId + '\'/>' +
                    '<input type=\'hidden\' value=' + chargeDocketSuffix + ' name="ChargeList[' + trId + '].DocketSuffix" id=\'hdnDocketSuffix' + i + '_' + trId + '\'/>' +
                    '</td>');
            });
        });
        if (chargeList.length > 0)
            isChargesAdded = true;
    }, ErrorFunction, false);
}

function CalculateNetAmount() {
    docketCount = 0;
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var tr = $(this).closest('tr');
        var hdnPaybasId = tr.find('[id*="hdnPaybasId"]');
        var txtSubTotal = tr.find('[id*="txtSubTotal"]');
        var txtRateDifferent = 0.00;
        var txtTotalAmount = tr.find('[id*="txtTotalAmount"]');
        var hdnTaxRate = tr.find('[id*="hdnTaxRate"]');
        var txtNewSubTotal = tr.find('[id*="txtSubTotal"]');
        var txtTaxTotal = tr.find('[id*="txtTaxTotal"]');
        var hdnIsRcm = tr.find('[id*="hdnIsRcm"]');
        var txtDocketTotal = tr.find('[id*="txtDocketTotal"]');
        var txtCollectionAmount = tr.find('[id*="txtCollectionAmount"]');
        var totalCharge = 0.00;

        if (chkDocket.IsChecked) {
            docketCount++;
            tr.find('[id*="txtCharge"]').each(function () {
                var txtCharge = $(this);
                var hdnOperator = $('#' + this.id.replace('txtCharge', 'hdnOperator'));
                if (hdnOperator.val() == '+')
                    totalCharge += parseFloat(txtCharge.val());
                else
                    totalCharge -= parseFloat(txtCharge.val());
            });
        }
        else {
            var tr = $(this).closest('tr');
            tr.find('[id*="txtCharge"]').each(function () {
                var txtCharge = $(this);
                txtCharge.val(0);
            });
            totalCharge = 0;
            txtNewSubTotal.val(txtSubTotal.val());

        }

        if (hdnIsRcm.val() == "true")
            hdnTaxRate.val(0);

        txtRateDifferent = parseFloat(txtNewSubTotal.val()) - parseFloat(txtSubTotal.val());
        //if (parseFloat(txtRateDifferent.val()) < 0)
        //    txtRateDifferent.val(0.00);

        if (hdnPaybasId.val() == 1)
            txtTotalAmount.val(parseFloat(parseFloat(txtRateDifferent) + parseFloat(totalCharge)).toFixed(2));
        else if (hdnPaybasId.val() == 3)
            txtTotalAmount.val(parseFloat(parseFloat(txtNewSubTotal.val()) + parseFloat(totalCharge)).toFixed(2));
        else if (hdnPaybasId.val() == 2)
            txtTotalAmount.val((parseFloat(totalCharge)).toFixed(2));

        txtTaxTotal.val(parseFloat(parseFloat(txtTotalAmount.val()) * parseFloat(hdnTaxRate.val()) / 100).toFixed(2));
        txtDocketTotal.val(parseFloat(txtTotalAmount.val()) + parseFloat(txtTaxTotal.val()));
        if (chkIsIsPartial.IsChecked) {
            txtCollectionAmount.val(0);
            txtCollectionAmount.readOnly(true);
        }
        else
        {
            txtCollectionAmount.val(txtDocketTotal.val());
            txtCollectionAmount.readOnly(false);
        }
        
    });
    CountTotalBillAmount();
}

function CountTotalBillAmount() {
    var totalBillAmount = 0.00;
    $('[id*="chkDocket"]').each(function () {
        if ($(this).IsChecked) {
            var txtCollectionAmount = $('#' + $(this).Id.replace('chkDocket', 'txtCollectionAmount'));
            totalBillAmount += parseFloat(txtCollectionAmount.val());
        }
    });
    hdnTotalBillAmount.val(parseFloat(totalBillAmount).toFixed(2));
}

function SetReceiptDetail() {
    if (docketCount == 0) {
        isStepValid = false;
        ShowMessage('Please select atleast one ' + docketNomenclature);
        return false;
    }
    dvStep3.showHide(docketCount > 0);
    if (chkIsIsPartial.IsChecked)
    {
        $("#dvrecept").showHide(false);
    }
    else
    {
        $("#dvrecept").showHide(true);
    }
        
    
    CountTotalBillAmount();
    var arrChargeList = [];
    $('#dtDocketList > tbody > tr').each(function () {
        var tr = $(this);
        tr.find('[id*="hdnChargeCode"]').each(function () {
            var charge = {};
            charge.ChargeCode = $(this).val();
            charge.DocketId = $('#' + $(this).Id.replace('hdnChargeCode', 'hdnDocketId')).val();
            charge.DocketSuffix = $('#' + $(this).Id.replace('hdnChargeCode', 'hdnDocketSuffix')).val();
            charge.ChargeAmount = $('#' + $(this).Id.replace('hdnChargeCode', 'txtCharge')).val();
            arrChargeList.push(charge);
        });
    });
    hdnDeliveryMrChargeList.val(JSON.stringify(arrChargeList));
    SetReceiptAmount(hdnTotalBillAmount.val(), 0.00);
    txtReceiptNetReceivedAmount.readOnly(false);
    SetReceiptPartyTypeAndParty(2, hdnPartyId.val());
}

function ValidateOnSubmit() {
    if (IsStepValid(dvStep3)) {
        btnSubmit.prop('disabled', true);
        return true;
    }
    else
        return false;
}

