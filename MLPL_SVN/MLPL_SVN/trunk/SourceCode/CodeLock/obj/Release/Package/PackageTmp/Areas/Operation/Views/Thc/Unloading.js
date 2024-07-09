
$(document).ready(function () {
    SetPageLoad('Thc', 'Unloading', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    dvCriteria = $('#dvCriteria');
    txtFromCityName = $('#txtFromCityName');
    txtToCityName = $('#txtToCityName');
    hdnFromCityId = $('#hdnFromCityId');
    hdnToCityId = $('#hdnToCityId');
    chkIsMarketVehicle = $('#chkIsMarketVehicle');
    txtDriverName = $('#txtDriverName');
    hdnDriverId = $('#hdnDriverId');
    txtVehicleNo = $('#txtVehicleNo');
    hdnVehicleId = $('#hdnVehicleId');
    ddlWarehouseId = $('#ddlWarehouseId');
    ddlAccountId = $('#ddlAccountId');
    txtRemark = $('#txtRemark');
    txtThcNos = $('#txtThcNos');
    btnGetList = $('#btnGetList');
    btnSubmit = $('#btnSubmit');

    txtTotalPackages = $('#txtTotalPackages');
    txtTotalActualWeight = $('#txtTotalActualWeight');
    txtTotalChargedWeight = $('#txtTotalChargedWeight');
    txtTotalFreight = $('#txtTotalFreight');
    txtTotalPaidAmount = $('#txtTotalPaidAmount');
    txtTotalTopayAmount = $('#txtTotalTopayAmount');
    txtAdvanceFreight = $('#txtAdvanceFreight');
    txtBalanceFreight = $('#txtBalanceFreight');
    txtLoadingCharges = $('#txtLoadingCharges');
    txtUnLoadingCharges = $('#txtUnLoadingCharges');
    txtDeliveryCommission = $('#txtDeliveryCommission');
    txtDoorDelivery = $('#txtDoorDelivery');
    txtKartAmount = $('#txtKartAmount');

    dvUnloadingDocketList = $('#dvUnloadingDocketList');
    dtUnloadingDocketList = LoadDataTable('dtUnloadingDocketList', false, false, false, null, null, [],
        [
            //{ title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllDocket', CalculateNetAmount) + "</div>", data: "DocketId", width: 80 },
            { title: thcNomenclature, data: 'ThcNo', width: '100px' },
            { title: thcNomenclature + ' Date', data: 'ThcDate' },
            { title: docketNomenclature, data: 'DocketNo', width: '100px' },
            { title: docketNomenclature + ' Date', data: 'DocketDate' },
            { title: 'From City', data: 'FromCityName' },
            { title: 'To City', data: 'ToCityName' },
            { title: 'Consignor', data: 'ConsignorName' },
            { title: 'Consignee', data: 'ConsigneeName' },
            { title: 'Transport Mode', data: 'TransportMode' },
            { title: 'Delivery Type', data: 'DeliveryProcess' },
            { title: 'Goods', data: 'ProductType' },
            { title: 'Packages', data: 'Packages' },
            { title: 'ActualWeight', data: 'ActualWeight' },
            { title: 'ChargedWeight', data: 'ChargedWeight' },
            { title: 'PrivateMark', data: 'PrivateMark' },
            { title: 'FreightRate', data: 'FreightRate' },
            { title: 'Freight', data: 'Freight' },
            { title: 'OtherCharges', data: 'OtherCharges' },
            { title: 'GrandTotal', data: 'GrandTotal' }
        ]);
}

function AttachEvents() {
    CityAutoComplete('txtFromCityName', 'hdnFromCityId', 'From City');
    CityAutoComplete('txtToCityName', 'hdnToCityId', 'To City');
    txtFromCityName.blur(function () { return IsCityNameExist(txtFromCityName, hdnFromCityId, 'From City'); });
    txtToCityName.blur(function () { return IsCityNameExist(txtToCityName, hdnToCityId, 'To City'); });
    chkIsMarketVehicle.change(function () { return OnIsMarketVehicleChange(); }).change();
    btnGetList.click(function () { if (IsStepValid(dvCriteria)) GetDocketList(); });
    txtAdvanceFreight.blur(CalculateBalanceFreight);
    txtLoadingCharges.blur(CalculateBalanceFreight);
    txtUnLoadingCharges.blur(CalculateBalanceFreight);
    txtDeliveryCommission.blur(CalculateBalanceFreight);
    txtDoorDelivery.blur(CalculateBalanceFreight);
    txtKartAmount.blur(CalculateBalanceFreight);
}

function OnIsMarketVehicleChange() {
    txtVehicleNo.val('');
    txtDriverName.val('');
    hdnVehicleId.val('');
    hdnDriverId.val('');
    if (!chkIsMarketVehicle.IsChecked) {
        VehicleAutoComplete('txtVehicleNo', 'hdnVehicleId');
        DriverAutoCompleteByLocation('txtDriverName', 'hdnDriverId');
        txtVehicleNo.blur(function () { return IsVehicleNoExist(txtVehicleNo, hdnVehicleId); });
        txtDriverName.blur(function () { return IsDriverNameExistByLocation(txtDriverName, hdnDriverId); });
    }
    else {
        txtVehicleNo.autocomplete({ source: [] });
        txtDriverName.autocomplete({ source: [] });
        txtVehicleNo.off("blur");
        txtDriverName.off("blur");
    }
}

function GetDocketList() {
    var requestData = { thcNos: txtThcNos.val() };
    AjaxRequestWithPostAndJson(ThcUrl + '/GetUnloadingDocketList', JSON.stringify(requestData), function (result) {
        dvUnloadingDocketList.showHide(result.length > 0);
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            dtUnloadingDocketList.fnClearTable();
            var totalContractAmount = 0;
            $.each(result, function (i, item) {
                totalContractAmount += parseFloat(item.DocketTotal).toFixed(2);
                item.DocketNo = '<label name="Details[' + i + '].DocketNo" id="lblDocketNo' + i + '" class="label-bold"/>' + item.DocketNo + item.DocketSuffix + '</label>' +
                    '<input type=\'hidden\' value=' + i + '  id=\'hdnRowId' + i + '\'/>' +
                    '<input type=\'hidden\' value=' + item.PaybasId + ' name="Details[' + i + '].PaybasId" id=\'hdnPaybasId' + i + '\'/>' +
                    '<input type=\'hidden\' value=' + item.DocketId + ' name="Details[' + i + '].DocketId" id=\'hdnDocketId' + i + '\'/>' +
                    '<input type=\'hidden\' value=' + item.DocketSuffix + ' name="Details[' + i + '].DocketSuffix" id=\'hdnDocketSuffix' + i + '\'/>' +
                    '<input type=\'hidden\' value=' + item.ThcId + ' name="Details[' + i + '].ThcId" id=\'hdnThcId' + i + '\'/>';
                item.DocketDate = $.displayDateTime(item.DocketDate);
                item.ThcDate = $.displayDateTime(item.ThcDate);
                item.Packages = "<input type='text' value='" + item.Packages + "' id='txtPackages" + i + "'class='textlabel' style='text-align: right'/>";
                item.ActualWeight = "<input type='text' value='" + item.ActualWeight + "' id='txtActualWeight" + i + "'class='textlabel numeric2' style='text-align: right'/>";
                item.ChargedWeight = "<input type='text' value='" + item.ChargedWeight + "' id='txtChargedWeight" + i + "'class='textlabel numeric2' style='text-align: right'/>";
                item.Freight = "<input type='text' value='" + item.Freight + "' id='txtFreight" + i + "'class='textlabel numeric2' style='text-align: right'/>";
                item.GrandTotal = "<input type='text' value='" + item.GrandTotal + "' id='txtGrandTotal" + i + "'class='textlabel numeric2' style='text-align: right'/>";
                item.DeliveryProcess = "<div class='select'>" +
                    "<select class='form-control' name='UnloadingDocketList[" + i + "].DeliveryProcessId' id='ddlDeliveryProcessId" + i + "' > <option value='1'>By DRS</option><option value='3'>By Delivery MR</option></select><i></i>" +
                    "</div>";
            });
            dtUnloadingDocketList.dtAddData(result);
            dtUnloadingDocketList.removeClass('dataTable');
            var totalPackages = 0, totalActualWeight = 0, totalChargedWeight = 0, totalFreight = 0, totalPaidAmount = 0, totalToPayAmount = 0;
            $('[id*="txtPackages"]').each(function () {
                var txtPackages = $(this);
                var txtActualWeight = $('#' + txtPackages.Id.replace('txtPackages', 'txtActualWeight'));
                var txtChargedWeight = $('#' + txtPackages.Id.replace('txtPackages', 'txtChargedWeight'));
                var txtFreight = $('#' + txtPackages.Id.replace('txtPackages', 'txtFreight'));
                var txtGrandTotal = $('#' + txtPackages.Id.replace('txtPackages', 'txtFreight'));
                var hdnPaybasId = $('#' + txtPackages.Id.replace('txtPackages', 'hdnPaybasId'));
                totalPackages = totalPackages + parseFloat(txtPackages.val());
                totalActualWeight = totalActualWeight + parseFloat(txtActualWeight.val());
                totalChargedWeight = totalChargedWeight + parseFloat(txtChargedWeight.val());
                totalFreight = totalFreight + parseFloat(txtFreight.val());
                if (hdnPaybasId.val() == 1)
                    totalPaidAmount = totalPaidAmount + parseFloat(txtGrandTotal.val());
                if (hdnPaybasId.val() == 3)
                    totalToPayAmount = totalToPayAmount + parseFloat(txtGrandTotal.val());
            });
            txtTotalPackages.val(totalPackages);
            txtTotalActualWeight.val(totalActualWeight);
            txtTotalChargedWeight.val(totalChargedWeight);
            txtTotalFreight.val(totalFreight);
            txtTotalPaidAmount.val(totalPaidAmount);
            txtTotalTopayAmount.val(totalToPayAmount);
            txtBalanceFreight.val(totalFreight - parseFloat(txtAdvanceFreight.val()));
        }
    }, ErrorFunction, false);
    return false;
}

function CalculateBalanceFreight() {
    txtBalanceFreight.val((parseFloat(txtTotalFreight.val()) + (parseFloat(txtLoadingCharges.val()) + parseFloat(txtUnLoadingCharges.val()) + parseFloat(txtDeliveryCommission.val()) + parseFloat(txtDoorDelivery.val()) + parseFloat(txtKartAmount.val()))) - parseFloat(txtAdvanceFreight.val()));
}