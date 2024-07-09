var selectedDocketList, freight;
$(document).ready(function () {
    SetPageLoad('Dispatch', '', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtVehicleNo = $('#txtVehicleNo');
    hdnVehicleId = $('#hdnVehicleId');
    hdnToLocationId = $('#hdnToLocationId');
    txtToLocationCode = $('#txtToLocationCode');
    hdnDriverId = $('#hdnDriverId');
    txtDriverName = $('#txtDriverName');
    hdnDestinationLocationId = $('#hdnDestinationLocationId');
    txtDestinationLocationCode = $('#txtDestinationLocationCode');
    txtNetPackages = $('#txtNetPackages');
    txtToPay = $('#txtToPay');
    txtTruckFreight = $('#txtTruckFreight');
    txtDisplayPackages = $('#txtDisplayPackages');
    txtDeliveryCommission = $('#txtDeliveryCommission');
    txtAdvanceFreight = $('#txtAdvanceFreight');
    txtTotalActualWeight = $('#txtTotalActualWeight');
    txtDoCharge = $('#txtDoCharge');
    txtLabourCharges = $('#txtLabourCharges');
    txtTotalChargedWeight = $('#txtTotalChargedWeight');
    txtKatAmount = $('#txtKatAmount');
    txtBalanceFreight = $('#txtBalanceFreight');
    txtPrintFreight = $('#txtPrintFreight');
    txtPf = $('#txtPf');
    txtUnloadingCharge = $('#txtUnloadingCharge');
    txtNetFreight = $('#txtNetFreight');
    btnSubmit = $('#btnSubmit');

    dtDocketList = LoadDataTable('dtDocketList', false, false, false, null, null, [],
        [
            { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllDocket', SelectDocket) + "</div>", data: "DocketId", width: 80 },
            { title: 'Origin', data: 'FromLocation' },
            { title: 'Consignor', data: 'ConsignorName' },
            { title: docketNomenclature + ' No', data: 'DocketNo' },
            { title: 'Destination', data: 'ToLocation' },
            { title: 'Package', data: 'Packages' },
            { title: 'Actual Weight', data: 'ActualWeight' },
            { title: 'Charge Weight', data: 'ChargedWeight' },
            { title: 'Goods', data: 'ProductType' },
            { title: 'Net Freight', data: 'Freight' }
        ]);
}

function AttachEvents() {
    LocationAutoComplete('txtToLocationCode', 'hdnToLocationId', 'To');
    txtToLocationCode.blur(function () { return IsLocationCodeExist(txtToLocationCode, hdnToLocationId, 'To'); });
    DriverAutoCompleteByLocation('txtDriverName', 'hdnDriverId', 'From');
    txtDriverName.blur(function () { return IsDriverNameExistByLocation(txtDriverName, hdnDriverId, 'From'); });
    LocationAutoComplete('txtDestinationLocationCode', 'hdnDestinationLocationId', 'To');
    txtDestinationLocationCode.blur(function () { return IsLocationCodeExist(txtDestinationLocationCode, hdnDestinationLocationId, 'To'); });
    VehicleAutoComplete('txtVehicleNo', 'hdnVehicleId');
    txtVehicleNo.blur(function () { return IsVehicleNoExist(txtVehicleNo, hdnVehicleId); });
    btnSubmit.click(ValidateOnSubmit);
    txtAdvanceFreight.blur(CalculateBalanceFreight);
    txtUnloadingCharge.blur(CalculateBalanceFreight);
    txtDeliveryCommission.blur(CalculateBalanceFreight);
    txtKatAmount.blur(CalculateBalanceFreight);
    txtLabourCharges.blur(CalculateBalanceFreight);
    txtDoCharge.blur(CalculateBalanceFreight);
    GetDocketList();
}

function GetDocketList() {
    var requestData = {};
    AjaxRequestWithPostAndJson(ThcUrl + '/GetDispatchDocketList', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedDocketList = [];
            $.each(result, function (i, item) {
                item.DocketNo = '<label name="Details[' + i + '].DocketNo" id="lblDocketNo' + i + '" class="label-bold"/>' + item.DocketNo + item.DocketSuffix + '</label>';
                item.DocketId = SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'Details[' + i + '].IsChecked', SelectDocket) +
                "<input type='hidden' value='" + item.DocketId + "' name='Details[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>" +
                "<input type='hidden' value='" + item.DocketSuffix + "' name='Details[" + i + "].DocketSuffix' id='hdnDocketSuffix" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketSuffix + "'  id='hdnDocketSuffix" + i + "'/>"
                '<input type=\'hidden\' value=' + item.PaybasId + ' id=\'hdnPaybasId' + i + '\'/>' +
                    '<input type=\'hidden\' value=' + item.GrandTotal + ' id=\'hdnGrandTotal' + i + '\'/>';
                item.Packages = "<input type='text' value='" + item.Packages + "' id='txtPackages" + i + "'class='textlabel' style='text-align: right'/>";
                item.ActualWeight = "<input type='text' value='" + item.ActualWeight + "' id='txtActualWeight" + i + "'class='textlabel numeric2' style='text-align: right'/>";
                item.ChargedWeight = "<input type='text' value='" + item.ChargedWeight + "' id='txtChargedWeight" + i + "'class='textlabel numeric2' style='text-align: right'/>";
                item.Freight = "<input type='text' value='" + item.Freight + "' id='txtFreight" + i + "'class='textlabel numeric2' style='text-align: right'/>";
            });
            dtDocketList.dtAddData(result);
            dtDocketList.removeClass('dataTable');
        }
    }, ErrorFunction, false);
    return false;
}

function SelectDocket() {
    var totalPackages = 0, totalActualWeight = 0, totalChargedWeight = 0, totalFreight = 0, totalPaidAmount = 0, totalToPayAmount = 0;
    selectedDocketList = [];
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var txtPackages = $('#' + chkDocket.Id.replace('chkDocket', 'txtPackages'));
        var txtActualWeight = $('#' + chkDocket.Id.replace('chkDocket', 'txtActualWeight'));
        var txtChargedWeight = $('#' + chkDocket.Id.replace('chkDocket', 'txtChargedWeight'));
        var hdnPaybasId = $('#' + chkDocket.Id.replace('chkDocket', 'hdnPaybasId'));
        var hdnGrandTotal = $('#' + chkDocket.Id.replace('chkDocket', 'hdnGrandTotal'));
        var txtFreight = $('#' + chkDocket.Id.replace('chkDocket', 'txtFreight'));
        if (chkDocket.IsChecked) {
            selectedDocketList.push($('#' + chkDocket.Id.replace('chkDocket', 'hdnDocketId')).val());
            totalPackages = totalPackages + parseFloat(txtPackages.val());
            totalActualWeight = totalActualWeight + parseFloat(txtActualWeight.val());
            totalChargedWeight = totalChargedWeight + parseFloat(txtChargedWeight.val());
            totalFreight = totalFreight + parseFloat(txtFreight.val());
            if (hdnPaybasId.val() == 3)
                totalToPayAmount = totalToPayAmount + parseFloat(hdnGrandTotal.val());
        }
    });

    txtNetPackages.val(totalPackages);
    txtTotalActualWeight.val(totalActualWeight);
    txtTotalChargedWeight.val(totalChargedWeight);
    freight = totalFreight;
    txtToPay.val(totalToPayAmount);
    txtBalanceFreight.val(totalFreight - parseFloat(txtAdvanceFreight.val()));
}

function ValidateOnSubmit() {
    if (selectedDocketList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one ' + docketNomenclature);
        return false;
    }
}

function CalculateBalanceFreight() {
    txtBalanceFreight.val((parseFloat(freight) + parseFloat(txtUnloadingCharge.val()) + parseFloat(txtDoCharge.val()) + parseFloat(txtLabourCharges.val())  + parseFloat(txtDeliveryCommission.val()) + parseFloat(txtKatAmount.val())) - parseFloat(txtAdvanceFreight.val()));
}