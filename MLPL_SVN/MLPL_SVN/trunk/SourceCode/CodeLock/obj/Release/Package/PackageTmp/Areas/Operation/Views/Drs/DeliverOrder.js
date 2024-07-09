var drDocketDate, txtDocketNo, txtVehicleNo, ddlArrivalLocation, dtDocketList, orderDeliveryUrl, selectedDocketId, selectedInvoiceId, selectedPartId, dtPartList, currentDate, dateTimeFormat, lateDeliveryReasonList, partDeliveryReasonList, unDeliveryReasonList, docketNomenclature;
var chkTakeSignature, txtDeliverPackages, rdSuccess, rdPartial, rdFailure, txtDeliverCodAmount, hdnPackages, selectedPartList = [], totalPartQuantity = 0, totalPartAmount = 0;

$(document).ready(function () {
    SetPageLoad('DRS', 'Order Delivery', '', '', '');
    InitObjects();

});

function InitObjects() {
    drDocketDate = InitDateRange('drDocketDate', DateRange.LastWeek);
    txtDocketNo = $('#txtDocketNo');
    dtDocketList = $('#dtDocketList');
    dtDocketDetails = $('#dtDocketDetails');
    chkTakeSignature = $('#chkTakeSignature');
    txtDeliverPackages = $('#txtDeliverPackages');
    txtDeliverCodAmount = $('#txtDeliverCodAmount');
    $('#lblDeliveryDateTime').addClass('label-bold');
    rdSuccess = $('#rdSuccess').check();
    rdPartial = $('#rdPartial');
    rdFailure = $('#rdFailure');
    rdSuccess.click(DeliverPackages);
    rdPartial.click(DeliverPackages);
    rdFailure.click(DeliverPackages);
    DeliverPackages();
    chkTakeSignature.click(ClickOnTakeSignature);

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocketList },
        { StepName: 'Docket List', StepFunction: GetPartList },
        { StepName: 'Part List', StepFunction: GetDocketPartDetail },
        { StepName: 'Order Detail', StepFunction: ValidateOnSubmit }
    ], 'Order Delivery');

    
}

function DeliverPackages() {
    if (rdSuccess.IsChecked) {
        $('#dvDeliverPackages').showHide(false);
        $('#dvReceiver').showHide(true);
        txtDeliverPackages.val($('#lblPackages').text());
    }
    else if (rdPartial.IsChecked) {
        $('#dvDeliverPackages').showHide(true);
        $('#dvReceiver').showHide(true);
        txtDeliverPackages.val(0);
        txtDeliverPackages.val(txtDeliverPackages.val());
    }
    else if (rdFailure.IsChecked) {
        $('#dvDeliverPackages').showHide(false);
        $('#dvReceiver').showHide(false);
        txtDeliverPackages.val(0);
    }
}

function ClickOnTakeSignature() {
    $('#dvSignature').showHide(chkTakeSignature.IsChecked);
    $('#sig-clearBtn').click();
}

function GetDocketList() {

    var DocketNo = txtDocketNo.val();

    var requestData = { docketNo: DocketNo, fromDate: drDocketDate.startDate, toDate: drDocketDate.endDate };

    AjaxRequestWithPostAndJson(orderDeliveryUrl + '/GetOrderDeliveryDocketList', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedThc = [];
            dtDocketList = LoadDataTable('dtDocketList', false, false, false, null, null, [],
                [
                    { title: 'Docket No', data: 'DocketNo' },
                    { title: 'Consignee Name', data: 'ConsigneeName' },
                ]);

            dtDocketList.fnClearTable();
            $.each(result, function (i, item) {
                item.DocketNo = '<div class="clearfix">' +
                    '<label class="radio">' +
                    '<input type="radio" name=\'Docket\' value=\'' + item.DocketId + '\' onclick="SelectedDocket(this)" tabindex="0" id="rdDocketNo' + i + '"/><i></i>' +
                    '<label for="rdDocketNo' + i + '">' + item.DocketNo + '</label>' +
                    '</div>';
            });
            dtDocketList.dtAddData(result);
            selectedDocketId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

function SelectedDocket(rd) {
    selectedDocketId = rd.value;
}

function GetPartList() {
    isStepValid = selectedDocketId != 0;
    if (selectedDocketId == 0) {
        ShowMessage('Please select Docket');
        return false;
    }
    var requestData = { docketId: selectedDocketId };

    AjaxRequestWithPostAndJson(orderDeliveryUrl + '/GetOrderDeliveryPartListForDocket', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedThc = [];
            dtPartList = LoadDataTable('dtPartList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllPart', SelectedPart), data: "PartId" },
                    { title: 'Part Name', data: 'PartName' },
                    { title: 'Quantity', data: 'PartQuantity' },
                    { title: 'Part Amount', data: 'PartAmount' },
                    { title: 'IsCod', data: 'IsCod' },
                ]);

            dtPartList.fnClearTable();
            $.each(result, function (i, item) {

                item.PartId = SelectAll.GetChk('chkAllPart', 'chkPart' + i, 'Items[' + i + '].IsChecked', SelectedPart) +
                    "<input type='hidden' value='" + item.DocketId + "' name='Items[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                    "<input type='hidden' value='" + item.InvoiceId + "' name='Items[" + i + "].InvoiceId' id='hdnInvoiceId" + i + "'/>" +
                    "<input type='hidden' value='" + item.PartId + "' name='Items[" + i + "].PartId' id='hdnPartId" + i + "'/>" +
                    "<input type='hidden' value='" + item.IsCod + "' name='Items[" + i + "].IsCod' id='hdnIsCod" + i + "'/>";
                item.PartName = item.PartName + "<input type='hidden' value='" + item.PartName + "' name='Items[" + i + "].PartName' id='hdnPartName" + i + "'/>";
                item.PartQuantity = '<input class="form-control numeric" name="Items[' + i + '].PartQuantity" id="txtPartQuantity' + i + '" type="text" value=\'' + item.PartQuantity + '\'/>' +
                    '<span data-valmsg-for="Items[' + i + '].PartQuantity" data-valmsg-replace="true"></span>' +
                    '<input type=\'hidden\' value=\'' + item.PartQuantity + '\' name=\'Items[' + i + '].Packages\' id=\'hdnPartQuantity' + i + '\' />';

                /*item.PartQuantity = item.PartQuantity + "<input type='hidden' value='" + item.PartQuantity + "' name='Items[" + i + "].PartQuantity' id='hdnPartQuantity" + i + "'/>";*/
                item.PartAmount = item.PartAmount + "<input type='hidden' value='" + item.PartAmount + "' name='Items[" + i + "].PartAmount' id='hdnPartAmount" + i + "'/>";
                item.IsCod = item.IsCod == true ? 'Yes' : 'No';

            });

            dtPartList.dtAddData(result, [],InitDocketTable,[]);
            SelectedPart();
        }
    }, ErrorFunction, false);
    return false;
}

function SelectedPart() {
    selectedPartList = [];
    $('[id*="chkPart"]').each(function () {
        var chkPart = $(this);
        var hdnDocketId = $('#' + chkPart.attr('id').replace('chkPart', 'hdnDocketId'));
        var hdnInvoiceId = $('#' + chkPart.attr('id').replace('chkPart', 'hdnInvoiceId'));
        var hdnPartId = $('#' + chkPart.attr('id').replace('chkPart', 'hdnPartId'));
        var hdnPartName = $('#' + chkPart.attr('id').replace('chkPart', 'hdnPartName'));
        var hdnPartQuantity = $('#' + chkPart.attr('id').replace('chkPart', 'hdnPartQuantity'));
        var hdnPartAmount = $('#' + chkPart.attr('id').replace('chkPart', 'hdnPartAmount'));
        if (hdnPartName.val() == 'FREIGHT CHARGES (BDA)')
            chkPart.check().enable(false);
        if (chkPart.IsChecked) {
            selectedPartList.push({ DocketId: hdnDocketId.val(), InvoiceId: hdnInvoiceId.val(), PartId: hdnPartId.val(), PartQuantity: hdnPartQuantity.val(), PartAmount: hdnPartAmount.val() });
        }
    });

    totalPartQuantity = 0, totalPartAmount = 0;
    $.each(selectedPartList, function (i, item) {
        totalPartQuantity = totalPartQuantity + parseInt(item.PartQuantity);
        totalPartAmount = totalPartAmount + parseFloat(item.PartAmount);
    });

    rdFailure.enable($('#chkAllPart').IsChecked);
}

function GetDocketPartDetail() {
    if (selectedPartList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select atleast one Part');
        return false;
    }

    var requestData = { docketId: selectedDocketId };

    AjaxRequestWithPostAndJson(orderDeliveryUrl + '/GetOrderDeliveryDocketPartDetail', JSON.stringify(requestData), function (result) {
        if (IsObjectNullOrEmpty(result)) {
            ShowMessage('Something Wrong. Please try again');
            return false;
        }

        $('#hdnDocketId').val(selectedDocketId);
        $('#hdnDocketSuffix').val(result.DocketSuffix);
        $('#hdnInvoiceId').val(selectedInvoiceId);
        $('#hdnPartId').val(selectedPartId);
        $('#lblConsigneeName').text(result.ConsigneeName);
        $('#lblDocketNo').text(result.DocketNo);
        $('#lblConsigneeAddress1').text(result.ConsigneeAddress1);
        $('#lblTotalPartQuantity').text(totalPartQuantity);
        $('#lblTotalPartAmount').text(totalPartAmount);
        $('#lblConsigneeMobileNo').text(result.ConsigneeMobileNo);
        $('#hdnTotalPartQuantity').val(totalPartQuantity);
        $('#hdnTotalPartAmount').val(totalPartAmount);

    }, ErrorFunction, false);
    return false;
}

function ValidateOnSubmit() {
    $('[id*="chkPart"]').each(function () {
        var chkPart = $(this);
        chkPart.enable();
    })


    if ($('#chkAllPart').IsChecked && rdSuccess.IsChecked)
        $('#hdnOrderDeliveryStatusId').val(1);
    else if (!$('#chkAllPart').IsChecked && rdSuccess.IsChecked)
        $('#hdnOrderDeliveryStatusId').val(2);
    else if ($('#chkAllPart').IsChecked && rdFailure.IsChecked)
        $('#hdnOrderDeliveryStatusId').val(3);
    return false;
}

function SubmitSignature() {
    var canvas = document.getElementById("sig-canvas");
    var sigText = document.getElementById("sig-dataUrl");
    var dataUrl = canvas.toDataURL();
    sigText.value = dataUrl;
}


function InitDocketTable() {
    $('[id*="txtPartQuantity"]').each(function () {
        var txtPartQuantity = $(this);
        var chkPart = $('#' + txtPartQuantity.Id.replace('txtPartQuantity', 'chkPart'));
        var hdnPartQuantity = $('#' + txtPartQuantity.Id.replace('txtPartQuantity', 'hdnPartQuantity'));

        txtPartQuantity.blur(function () { OnPartQuantityChange(txtPartQuantity) });
        chkPart.change(function () { SelectDocket(chkPart, txtPartQuantity, hdnPartQuantity) }).change();
    });
}
function OnPartQuantityChange(obj) {
    var txtPartQuantity = $(obj);
    txtPartQuantity.val(txtPartQuantity.round());
    var hdnPartQuantity = $('#' + txtPartQuantity.attr('id').replace('txtPartQuantity', 'hdnPartQuantity'));
    var partQuantity = hdnPartQuantity.toInt(), loadPartQuantity = txtPartQuantity.toInt();

    if (partQuantity < loadPartQuantity || partQuantity <= 0) {
        loadPartQuantity = partQuantity
        txtPartQuantity.val(loadPartQuantity);
    }
    
}
function SelectDocket(chkPart, txtPartQuantity, hdnPartQuantity) {
    if (chkPart.IsChecked) {
        txtPartQuantity.val(hdnPartQuantity.val());
    }
    txtPartQuantity.enable(chkPart.IsChecked);
}