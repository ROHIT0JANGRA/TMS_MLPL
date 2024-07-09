var dtLoadingSheetList, dtDocketList, docketNomenclature;
$(document).ready(function () {
    SetPageLoad('Loading Sheet', 'Update', '', '', '');

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
            { title: 'Pay Basis', data: "Paybas" },
            { title: 'Packages', data: "Packages" },
            { title: 'Actual Weight', data: "ActualWeight" },
            { title: 'Charged Weight', data: "ChargedWeight" },
            { title: 'BA Rate', data: "KartRate" },
            { title: 'BA Amount', data: "KartAmount" },
            { title: 'Labour Amount', data: "LabourAmount" }
        ]);

    lblLoadingSheetNo = $('#lblLoadingSheetNo');
    hdnLoadingSheetId = $('#hdnLoadingSheetId');

    txtTotalPackages = $('#txtTotalPackages'); 
    txtTotalActualWeight = $('#txtTotalActualWeight');
    txtTotalKartAmount = $('#txtTotalKartAmount');
    txtTotalLabourAmount = $('#txtTotalLabourAmount');
    hdnTotalDocket = $('#hdnTotalDocket');
    hdnVendorId = $('#hdnVendorId');

    LocationAutoComplete('txtNextLocation', 'hdnNextLocation', 'Next Stop');
    $('#txtNextLocation').blur(function () { return IsLocationCodeExist($('#txtNextLocation'), $('#hdnNextLocation'), 'Next Stop'); });

    VendorAutoComplete('txtVendorCode', 'hdnVendorId', '', 4);
    $('#txtVendorCode').blur(function () { IsVendorCodeExist($('#txtVendorCode'), $('#hdnVendorId'), $('#lblVendorName'), '', 4); });
});

function GetLoadingSheetList() {
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
        item.DocketId = SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'ManifestDocketList[' + i + '].IsChecked', CountTotalLoading) +
            "<input type='hidden' value='" + item.DocketId + "' name='ManifestDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
            "<input type='hidden' value='" + item.DocketNo + "' name='ManifestDocketList[" + i + "].DocketNo' id='hdnDocketNo" + i + "'/>" +
            "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>" +
            "<input type='hidden' value='" + item.DocketId + "' name='ManifestDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
            "<input type='hidden' value='" + item.DocketSuffix + "' name='ManifestDocketList[" + i + "].DocketSuffix' id='hdnDocketSuffix" + i + "'/>";

        item.DocketNo = item.DocketNo + " " + item.DocketSuffix;
        item.DocketDate = $.displayDate(item.DocketDate);
        item.Edd = $.displayDate(item.Edd);
        item.Packages = '<input class="form-control numeric" name="ManifestDocketList[' + i + '].LoadPackages" id="txtLoadPackages' + i + '" type="text" value=\'' + item.Packages + '\'/>' +
            '<span data-valmsg-for="ManifestDocketList[' + i + '].LoadPackages" data-valmsg-replace="true"></span>' +
            '<input type=\'hidden\' value=\'' + item.Packages + '\' name=\'ManifestDocketList[' + i + '].Packages\' id=\'hdnPackages' + i + '\' />';
        item.ActualWeight = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LoadActualWeight" id="txtLoadActualWeight' + i + '" type="text"  value=\'' + item.ActualWeight + '\'/>' +
            '<input type=\'hidden\' value=\'' + item.ActualWeight + '\' name=\'ManifestDocketList[' + i + '].ActualWeight\' id=\'hdnActualWeight' + i + '\' />';

        item.KartAmount = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LoadKartAmount" id="txtLoadKartAmount' + i + '" type="text"  value=\'' + item.KartAmount + '\'/>' +
            '<input type=\'hidden\' value=\'' + item.KartAmount + '\' name=\'ManifestDocketList[' + i + '].KartAmount\' id=\'hdnKartAmount' + i + '\' />'   +
            '<input type=\'hidden\' value=\'' + item.VendorId + '\' name=\'ManifestDocketList[' + i + '].VendorId\' id=\'hdnVendorId' + i + '\' />';

        item.LabourAmount = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LabourAmount" id="txtLabourAmount' + i + '" type="text"  value=\'' + item.LabourAmount + '\'/>';

    });
    dtDocketList.dtAddData(responseData.ManifestDocketList, [], InitDocketTable);
    CountTotalLoading();
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
    txtLoadPackages.enable(chkDocket.IsChecked);
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

    $('[id*="txtLoadPackages"]').each(function () {
        var txtLoadPackages = $(this);
        var chkDocket = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'chkDocket'));
        if (chkDocket.IsChecked) {
            var txtLoadActualWeight = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'txtLoadActualWeight'));
            var txtLoadKartAmount = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'txtLoadKartAmount'));
            var txtLabourAmount = $('#' + txtLoadPackages.Id.replace('txtLoadPackages', 'txtLabourAmount'));

            totalDocket++;
            totalPackages += parseInt(txtLoadPackages.val());
            totalActualWeight += parseFloat(txtLoadActualWeight.val());
            totalKartAmount += parseFloat(txtLoadKartAmount.val());
            totalLabourAmount += parseFloat(txtLabourAmount.val());
        }
    });
    hdnTotalDocket.val(totalDocket)
    txtTotalPackages.val(totalPackages);
    txtTotalActualWeight.val(totalActualWeight.toFixed(3));
    txtTotalKartAmount.val(totalKartAmount.toFixed(2));
    txtTotalLabourAmount.val(totalLabourAmount.toFixed(2));

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