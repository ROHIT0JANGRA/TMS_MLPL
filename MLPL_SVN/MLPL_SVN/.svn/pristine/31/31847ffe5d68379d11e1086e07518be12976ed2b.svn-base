var dtLoadingSheetList, dtDocketList, docketNomenclature, ruleMasterUrl, vendorContractUrl, txtTotalDoorDeliveryBaAmount;
var hdnVendorId;
$(document).ready(function () {
    SetPageLoad('Loading Sheet', 'Update', '', '', '');
    dtDocketList = $('#dtDocketList');
    InitWizard('dvWizard', [{ StepName: 'Criteria', StepFunction: GetLoadingSheetList },
    { StepName: 'Loading Sheet List', StepFunction: ValidateStep2 },
    { StepName: 'Docket List', StepFunction: ValidateStep3 },
    { StepName: 'Manifest Details', StepFunction: ValidateOnSubmit }],
        'Update Loading Sheet');

    drLoadingSheetDate = InitDateRange('drLoadingSheetDate', DateRange.LastWeek);

    dtLoadingSheetList = LoadDataTable('dtLoadingSheetList', false, false, false, null, null, [],
        [
            { title: "Select", data: "LoadingSheetId", width: 80 },
            { title: 'Loading Sheet No', data: "LoadingSheetNo" },
            { title: 'Manual No', data: "ManualLoadingSheetNo" },
            { title: 'Loading Sheet Date', data: "LoadingSheetDate" },
            { title: 'Next Location', data: "NextLocationCode" },
            { title: 'Total ' + docketNomenclature, data: "TotalDocket" },
            { title: 'Total Packages', data: "TotalPackages" },
            { title: 'Total Actual Weight', data: "TotalActualWeight" }
        ]);

    dtDocketList = LoadDataTable('dtDocketList', false, false, false, null, null, [],
        [
            { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllDocket', CountTotalLoading) + "</div>", data: "DocketId", width: 80 },
            { title: docketNomenclature, data: "DocketNo" },
            { title: 'Booking Date', data: "DocketDate" },
            { title: 'Origin', data: "FromLocationCode" },
            { title: 'Destination', data: "ToLocationCode" },
            { title: 'Consignor Name', data: "ConsignorName" },
            { title: 'Consignee Name', data: "ConsigneeName" },
            { title: 'Pay Basis', data: "Paybas" },
            { title: 'Docket Pkt', data: "DocketPackages" },
            { title: 'Scan Pkt', data: "Packages" },
            { title: 'Actual Weight', data: "ActualWeight" },
            { title: 'Charged Weight', data: "ChargedWeight" }
            //{ title: 'BA Rate', data: "KartRate" },
            //{ title: 'BA Amount', data: "KartAmount" },
            //{ title: 'Labour Amount', data: "LabourAmount" },
            //{ title: 'Del. BA Amount', data: "DeliveryKartAmount" },
            //{ title: 'Del. Labour Amount', data: "DeliveryLabourAmount" },
            //{ title: 'Door Del. BA Amount', data: "DoorDeliveryBaAmount" }
        ]);

    lblLoadingSheetNo = $('#lblLoadingSheetNo');
    hdnLoadingSheetId = $('#hdnLoadingSheetId');

    txtTotalPackages = $('#txtTotalPackages');
    txtTotalActualWeight = $('#txtTotalActualWeight');
    txtTotalKartAmount = $('#txtTotalKartAmount');
    txtTotalLabourAmount = $('#txtTotalLabourAmount');

    txtTotalDeliveryKartAmount = $('#txtTotalDeliveryKartAmount');
    txtTotalDeliveryLabourAmount = $('#txtTotalDeliveryLabourAmount');
    txtTotalDoorDeliveryBaAmount = $('#txtTotalDoorDeliveryBaAmount');

    hdnTotalDocket = $('#hdnTotalDocket');
    hdnVendorId = $('#hdnVendorId');
    ddlVendorDumtcoId = $('#ddlVendorDumtcoId');

    LocationAutoComplete('txtNextLocation', 'hdnNextLocation', 'Next Stop');
    $('#txtNextLocation').blur(function () {

        if ($('#txtNextLocation').val() == "") return;

        IsLocationCodeExist($('#txtNextLocation'), $('#hdnNextLocation'), 'Next Stop');
        GetVendorList();
        return false;
    });
    ddlVendorDumtcoId.change(OnVendorDumtcoChange).change();
    //VendorAutoComplete('txtVendorCode', 'hdnVendorId', '', 4);
    //$('#txtVendorCode').blur(function () { IsVendorCodeExist($('#txtVendorCode'), $('#hdnVendorId'), $('#lblVendorName'), '', 4); });
});

function OnVendorDumtcoChange() {
    hdnVendorId.val(ddlVendorDumtcoId.val());
}

function GetVendorList() {
    hdnVendorId.val(0);
    var requestData = { locationId: $('#hdnNextLocation').val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetVendorList', JSON.stringify(requestData), function (responseData) {
        BindDropDownList(ddlVendorDumtcoId.Id, responseData, 'Value', 'Name', '', 'Select Vendor');
    }, ErrorFunction, false);
}

function GetLoadingSheetList() {

    if ($('#hdnNextLocation').val() == "0" || $('#hdnNextLocation').val() == "") {
        isStepValid = false;
        ShowMessage('Please select next location');
        return false;
    }

    var length = $('#ddlVendorDumtcoId > option').length;

    if (length > 0) {
        if ($('#ddlVendorDumtcoId').val() == "" || $('#ddlVendorDumtcoId').val() == "0" || $('#hdnVendorId').val() == "0") {
            isStepValid = false;
            ShowMessage('Please select vendor name');
            return false;
        }
    }

    var NLocationId = $('#hdnNextLocation').val();

    if (NLocationId == null || NLocationId == "") {
        $('#hdnNextLocation').val("0");
    }

    var requestData = { fromDate: $.displayDate(drLoadingSheetDate.startDate), toDate: $.displayDate(drLoadingSheetDate.endDate), nextLocationId: $('#hdnNextLocation').val(), locationId: loginLocationId, loadingSheetNo: $('#txtLoadingSheetNo').val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetLoadingSheetListForUpdate', JSON.stringify(requestData), GetLoadingSheetListSuccess, ErrorFunction, false);
    return false;
}

function GetLoadingSheetListSuccess(responseData) {
    if (responseData.length == 0) {
        isStepValid = false;
        ShowMessage('No Record Found');
        return false;
    }

    dtLoadingSheetList.fnClearTable();
    $.each(responseData, function (i, item) {
        item.LoadingSheetId = '<div class="clearfix">' +
            '<label class="radio">' +
            '<input type="radio" name=\'LoadingSheet\' value=\'' + item.LoadingSheetId + '\' onclick="SelectLoadingSheet(this.id);" tabindex="0" id="rdLoadingSheetNo' + i + '"/><i></i>' +
            '<label for="rdLoadingSheetNo' + i + '">' + '' + '</label>' +
            '<input type=\'hidden\' id=\'hdnLoadingSheetDateTime' + i + '\' value=\'' + $.displayDateTime(item.LoadingSheetDateTime) + '\' />' +
            '<input type=\'hidden\' id=\'hdnNextLocationId' + i + '\' value=\'' + item.NextLocationId + '\' />' +
            '</label>' +
            '</div>';
        item.LoadingSheetDate = $.displayDate(item.LoadingSheetDate);
        item.LoadingSheetDateTime = $.displayDateTime(item.LoadingSheetDateTime);
    });
    dtLoadingSheetList.dtAddData(responseData);
}

function SelectLoadingSheet(rdId) {
    selectedLoadingSheetId = $('#' + rdId).val();
    var loadingSheetNo = $('#' + rdId).closest('tr').find("td").eq(1).html();
    var nextLocationCode = $('#' + rdId).closest('tr').find("td").eq(4).html();
    var loadingSheetDateTime = $('#' + rdId.replace('rdLoadingSheetNo', 'hdnLoadingSheetDateTime')).val();
    var nextLocationId = $('#' + rdId.replace('rdLoadingSheetNo', 'hdnNextLocationId')).val();

    $('#hdnLoadingSheetNo').val(loadingSheetNo);
    $('#lblLoadingSheetNo').text(loadingSheetNo);
    $('#hdnLoadingSheetId').val(selectedLoadingSheetId);
    $('#hdnNextLocationId').val(nextLocationId);
    $('#txtNextLocationCode').val(nextLocationCode);
    $('#lblLoadingSheetDateTime').text(loadingSheetDateTime);
    $('#hdnLoadingSheetDateTime').val(loadingSheetDateTime);
}

var selectedLoadingSheetId = 0;
function ValidateStep2() {
    if (selectedLoadingSheetId == 0) {
        isStepValid = false;
        ShowMessage('Please select Loading Sheet');
        return false;
    }
    var requestData = { loadingsheetId: selectedLoadingSheetId, vendorId: hdnVendorId.val() == '' ? 0 : hdnVendorId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetLoadingSheetDetails', JSON.stringify(requestData), GetLoadingSheetDetailsSuccess, ErrorFunction, false);
    return false;
}

function GetLoadingSheetDetailsSuccess(responseData) {
    dtDocketList.fnClearTable();
    if (responseData.IsNullOrEmpty || responseData.ManifestDocketList.length == 0) {
        isStepValid = false;
        ShowMessage('No Record Found');
        return false;
    }
    $.each(responseData.ManifestDocketList, function (i, item) {
        item.DocketNo = '<a href="javascript:void(0)"  id="loginlink" onclick="OnShowBarcodeList(' + item.DocketId + ',\'' + item.DocketNo + '\')">' + item.DocketNo + " " + item.DocketSuffix + '</a> ';;

        item.DocketId = SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'ManifestDocketList[' + i + '].IsChecked', CountTotalLoading) +
            "<input type='hidden' value='" + item.DocketId + "' name='ManifestDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
            "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>" +
        //    "<input type='hidden' value='" + item.DocketId + "' name='ManifestDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
            "<input type='hidden' value='" + item.DocketSuffix + "' name='ManifestDocketList[" + i + "].DocketSuffix' id='hdnDocketSuffix" + i + "'/>" +
            "<input type='hidden' value='" + item.DocketNoBarcode + "' name='ManifestDocketList[" + i + "].DocketNoBarcode' id='hdnDocketNoBarcode" + i + "'/>" +
            "<input type='hidden' value='" + item.DocketNoBarcodeScan + "' name='ManifestDocketList[" + i + "].DocketNoBarcodeScan' id='hdnDocketNoBarcodeScan" + i + "'/>" +
            "<input type='hidden' value='" + item.LastDocketSuffix + "' name='ManifestDocketList[" + i + "].LastDocketSuffix' id='hdnLastDocketSuffix" + i + "'/>";

        item.DocketDate = $.displayDate(item.DocketDate);
        item.Edd = $.displayDate(item.Edd);

        item.DocketPackages = item.Packages;
        item.DocketPackages = '<input class="form-control textlabel" name="ManifestDocketList[' + i + '].DocketPackages" id="txtDocketPackages' + i + '" type="text"  value=\'' + item.DocketPackages + '\'/>';

        item.Packages = 0;
        item.Packages = '<input class="form-control textlabel" name="ManifestDocketList[' + i + '].LoadPackages" id="txtLoadPackages' + i + '" type="text" value=\'' + item.Packages + '\'/>' +
            '<span data-valmsg-for="ManifestDocketList[' + i + '].LoadPackages" data-valmsg-replace="true"></span>' +
            '<input type=\'hidden\' value=\'' + item.Packages + '\' name=\'ManifestDocketList[' + i + '].Packages\' id=\'hdnPackages' + i + '\' />';
        item.ActualWeight = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LoadActualWeight" id="txtLoadActualWeight' + i + '" type="text"  value=\'' + item.ActualWeight + '\'/>' +
            '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LoadKartAmount" id="txtLoadKartAmount' + i + '" type=\'hidden\'  value=\'' + item.KartAmount + '\'/>' +
            '<input type=\'hidden\' value=\'' + item.KartAmount + '\' name=\'ManifestDocketList[' + i + '].KartAmount\' id=\'hdnKartAmount' + i + '\' />' +
            '<input type=\'hidden\' value=\'' + item.VendorId + '\' name=\'ManifestDocketList[' + i + '].VendorId\' id=\'hdnVendorId' + i + '\' />'+
            '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LabourAmount" id="txtLabourAmount' + i + '" type=\'hidden\'  value=\'' + item.LabourAmount + '\'/>'+
            '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].DeliveryKartAmount" id="txtDeliveryKartAmount' + i + '" type=\'hidden\'  value=\'' + item.DeliveryKartAmount + '\'/>' +
            '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].DeliveryLabourAmount" id="txtDeliveryLabourAmount' + i + '" type=\'hidden\'  value=\'' + item.DeliveryLabourAmount + '\'/>'+
            '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].DoorDeliveryBaAmount" id="txtDoorDeliveryBaAmount' + i + '" type=\'hidden\'  value=\'' + item.DoorDeliveryBaAmount + '\'/>'+
            '<input type=\'hidden\' value=\'' + item.ActualWeight + '\' name=\'ManifestDocketList[' + i + '].ActualWeight\' id=\'hdnActualWeight' + i + '\' />';

    //    item.KartAmount = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LoadKartAmount" id="txtLoadKartAmount' + i + '" type="text"  value=\'' + item.KartAmount + '\'/>' +
    //        '<input type=\'hidden\' value=\'' + item.KartAmount + '\' name=\'ManifestDocketList[' + i + '].KartAmount\' id=\'hdnKartAmount' + i + '\' />' +
    //        '<input type=\'hidden\' value=\'' + item.VendorId + '\' name=\'ManifestDocketList[' + i + '].VendorId\' id=\'hdnVendorId' + i + '\' />';

    //    item.LabourAmount = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LabourAmount" id="txtLabourAmount' + i + '" type="text"  value=\'' + item.LabourAmount + '\'/>';

    //    item.DeliveryKartAmount = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].DeliveryKartAmount" id="txtDeliveryKartAmount' + i + '" type="text"  value=\'' + item.DeliveryKartAmount + '\'/>';
    //    item.DeliveryLabourAmount = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].DeliveryLabourAmount" id="txtDeliveryLabourAmount' + i + '" type="text"  value=\'' + item.DeliveryLabourAmount + '\'/>';
    //    item.DoorDeliveryBaAmount = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].DoorDeliveryBaAmount" id="txtDoorDeliveryBaAmount' + i + '" type="text"  value=\'' + item.DoorDeliveryBaAmount + '\'/>';
    });
    dtDocketList.dtAddData(responseData.ManifestDocketList, [], InitDocketTable, []);
   // UseLabourAmount();
    CountTotalLoading();
}

function UseLabourAmount() {
    $('[id*="txtLabourAmount"]').each(function () {
        var txtLabourAmount = $(this);
        var txtDeliveryLabourAmount = $('#' + txtLabourAmount.attr('id').replace('txtLabourAmount', 'txtDeliveryLabourAmount'));

        var request = { moduleId: 4, ruleId: 1 };
        AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(request), function (result) {
            useLabourRate = (result == "N" ? false : true);

            //$('#thLabourAmount').showHide(useLabourRate);
            //$('#thDeliveryLabourAmount').showHide(useLabourRate);
            //$('#thTotalLabourAmount').showHide(useLabourRate);
            //$('#thTotalDeliveryLabourAmount').showHide(useLabourRate);



            //var indexArr = [12,13,14,15,16,17];
            //$.each(indexArr, function (i, item) {
            //    $('#dtDocketList tbody tr td:eq(' + item + ')').showHide(useLabourRate);
            //    $('#dtDocketList thead tr th:eq(' + item + ')').showHide(useLabourRate);
            //    $('#dtDocketList tfoot tr td:eq(' + item + ')').showHide(useLabourRate);
            //});
            //txtLabourAmount.showHide(useLabourRate);
            //txtDeliveryLabourAmount.showHide(useLabourRate);

            //for (var cellIndex = 13; cellIndex <= 17; cellIndex++)
            //{
            //    dtDocketList.find("tbody tr, thead tr, tfoot tr").children(":nth-child(" + cellIndex + ")").hide();
            //}


        }, ErrorFunction, false);
    })
}

function CalculateTotalDoorDeliveryBaAmount() {
    var totalDoorDeliveryBaAmount = 0.000;
    $('[id*="txtDoorDeliveryBaAmount"]').each(function () {
        var txtDoorDeliveryBaAmount = $(this);
        var chkDocket = $('#' + txtDoorDeliveryBaAmount.Id.replace('txtDoorDeliveryBaAmount', 'chkDocket'));
        if (chkDocket.IsChecked) {
            totalDoorDeliveryBaAmount += parseFloat(txtDoorDeliveryBaAmount.val());
        }
    })

    txtTotalDoorDeliveryBaAmount.val(totalDoorDeliveryBaAmount.toFixed(2));
}

function InitDocketTable() {
    $('[id*="txtLoadPackages"]').each(function () {
        var txtLoadPackages = $(this);
        var chkDocket = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'chkDocket'));
        var lblActualWeight = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'lblActualWeight'));
        var hdnPackages = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'hdnPackages'));
        var hdnActualWeight = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'hdnActualWeight'));

        txtLoadPackages.blur(function () { OnPackagesChange(txtLoadPackages) });
        chkDocket.change(function () { SelectDocket(chkDocket, txtLoadPackages, lblActualWeight, hdnPackages, hdnActualWeight) }).change();
    });
}

function SelectDocket(chkDocket, txtLoadPackages, lblActualWeight, hdnPackages, hdnActualWeight) {
    if (chkDocket.IsChecked) {
        txtLoadPackages.val(hdnPackages.val());
        lblActualWeight.text(hdnActualWeight.val());
    }
   // txtLoadPackages.enable(chkDocket.IsChecked);
}

function OnPackagesChange(obj) {
    var txtLoadPackages = $(obj);
    txtLoadPackages.val(txtLoadPackages.round());
    var hdnPackages = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'hdnPackages'));

    var packages = hdnPackages.toInt(), loadPackages = txtLoadPackages.toInt();

    if (packages < loadPackages || loadPackages <= 0) {
        loadPackages = packages
        txtLoadPackages.val(loadPackages);
    }
    var txtLoadActualWeight = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'txtLoadActualWeight'));
    var txtLoadKartAmount = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'txtLoadKartAmount'));

    var hdnActualWeight = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'hdnActualWeight'));
    var hdnKartAmount = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'hdnKartAmount'));

    var actualWeight = hdnActualWeight.toFloat();
    var loadActualWeight = loadPackages * actualWeight / packages;

    txtLoadActualWeight.val(loadActualWeight.toFixed(3));
    txtLoadKartAmount.val((loadPackages * parseFloat(hdnKartAmount.val()) / packages).toFixed(2));
    CountTotalLoading();
}

function CountTotalLoading() {
    var totalDocket = 0; totalPackages = 0, totalActualWeight = 0.000, totalKartAmount = 0.00;
    var totalLabourAmount = 0.000;
    var totalDeliveryKartAmount = 0.000;
    var totalDeliveryLabourAmount = 0.000;



    $('[id*="txtLoadPackages"]').each(function () {
        var txtLoadPackages = $(this);
        var chkDocket = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'chkDocket'));
        if (chkDocket.IsChecked) {
            var txtLoadActualWeight = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'txtLoadActualWeight'));
            //var txtLoadKartAmount = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'txtLoadKartAmount'));
            //var txtLabourAmount = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'txtLabourAmount'));

            //var txtDeliveryKartAmount = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'txtDeliveryKartAmount'));
            //var txtDeliveryLabourAmount = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'txtDeliveryLabourAmount'));

            totalDocket++;
            totalPackages += parseInt(txtLoadPackages.val());
            totalActualWeight += parseFloat(txtLoadActualWeight.val());
            //totalKartAmount += parseFloat(txtLoadKartAmount.val());
            //totalLabourAmount += parseFloat(txtLabourAmount.val());

            //totalDeliveryKartAmount += parseFloat(txtDeliveryKartAmount.val());
            //totalDeliveryLabourAmount += parseFloat(txtDeliveryLabourAmount.val());
        }
    });

    hdnTotalDocket.val(totalDocket)
    txtTotalPackages.val(totalPackages);
    txtTotalActualWeight.val(totalActualWeight.toFixed(3));
    //txtTotalKartAmount.val(totalKartAmount.toFixed(2));
    //txtTotalLabourAmount.val(totalLabourAmount.toFixed(2));

    //txtTotalDeliveryKartAmount.val(totalDeliveryKartAmount.toFixed(2));
    //txtTotalDeliveryLabourAmount.val(totalDeliveryLabourAmount.toFixed(2));
    CalculateTotalDoorDeliveryBaAmount();
}

function ValidateStep3() {
    if (hdnTotalDocket.toInt() == 0) {
        isStepValid = false;
        ShowMessage('Please select atleast one ' + docketNomenclature);
        return false;
    }

}

function ValidateOnSubmit() {
    if (!ValidateModuleDateWithPreviousModuleDate('lblLoadingSheetDateTime', 'txtManifestDateTime', 'Manifest Date'))
        return false;
}