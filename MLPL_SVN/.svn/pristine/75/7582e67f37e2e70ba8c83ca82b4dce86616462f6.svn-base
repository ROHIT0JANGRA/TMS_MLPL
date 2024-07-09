var BalancePackages;
var docketNomenclature;
$(document).ready(function () {
    SetPageLoad(manifestNomenclature, 'Generate', 'drDocketDate');

    InitWizard('dvWizard', [{ StepName: 'Criteria', StepFunction: GetDocketList },
    { StepName: docketNomenclature + ' List', StepFunction: ValidateOnStep2 },
    { StepName: manifestNomenclature+' Detail', StepFunction: ValidateOnSubmit }
    ], 'Generate ' + manifestNomenclature);

    hdnNextLocationId = $('#hdnNextLocationId'); txtNextLocationCode = $('#txtNextLocationCode'); hdnFromCityId = $('#hdnFromCityId'); txtFromCityName = $('#txtFromCityName'); hdnToCityId = $('#hdnToCityId'); txtToCityName = $('#txtToCityName'); hdnVendorId = $('#hdnVendorId');
    drDocketDate = InitDateRange('drDocketDate', DateRange.LastWeek);

    ddlTransportModeId = $('#ddlTransportModeId');
    ddlDestinationLocation = $('#ddlDestinationLocation');
    ddlRegion = $('#ddlRegion');
    txtDocketNo = $('#txtDocketNo');
    dtDocketDetails = $('#dtDocketDetails');

    $('#ddlTransportModeId option').eq(0).before($('<option>', { value: 0, text: 'All' }));
    ddlTransportModeId.val(0);

    txtTotalPackages = $('#txtTotalPackages');
    txtTotalBalancePackages = $('#txtTotalBalancePackages');
    txtTotalActualWeight = $('#txtTotalActualWeight'); txtTotalKartAmount = $('#txtTotalKartAmount'); hdnTotalDocket = $('#hdnTotalDocket');

    LocationAutoComplete('txtNextLocationCode', 'hdnNextLocationId');
    CityAutoComplete('txtFromCityName', 'hdnFromCityId');
    CityAutoComplete('txtToCityName', 'hdnToCityId');

    txtNextLocationCode.blur(function () { return IsLocationCodeExist(txtNextLocationCode, hdnNextLocationId, 'Next Stop'); });
    txtFromCityName.blur(function () { return IsCityNameExist(txtFromCityName, hdnFromCityId, 'From City'); });
    txtToCityName.blur(function () { return IsCityNameExist(txtToCityName, hdnToCityId, 'To City'); });

    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [
            { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllDocket', CountTotalLoading) + "</div>", data: "DocketId", width: 80 },
            { title: docketNomenclature , data: "DocketNo" },
            { title: 'From City', data: "FromCityName" },
            { title: 'To City', data: "ToCityName" },
            { title: 'Consignor Name', data: "ConsignorName" },
            { title: 'Consignee Name', data: "ConsigneeName" },
            { title: 'Booking Date', data: "DocketDate" },
            { title: 'Pay Basis', data: "Paybas" },
            //{ title: 'EDD', data: "Edd" },
            { title: 'Packages', data: "Packages" },
            { title: 'Balance Packages', data: "BalancePackages" },
            { title: 'Actual Weight', data: "ActualWeight" },
            { title: 'KART Amount', data: "KartAmount" }
        ]);

    VendorAutoComplete('txtVendorCode', 'hdnVendorId', '', 4);
    $('#txtVendorCode').blur(function () { IsVendorCodeExist($('#txtVendorCode'), $('#hdnVendorId'), $('#lblVendorName'), '', 4); });
});

function GetDocketList() {
    var requestData = {
        companyId: loginCompanyId,
        locationId: loginLocationId,
        transportModeId: ddlTransportModeId.val(),
        fromCityId: hdnFromCityId.val(),
        toCityId: hdnToCityId.val(),
        fromDate: $.displayDate(drDocketDate.startDate),
        toDate: $.displayDate(drDocketDate.endDate),
        toLocationList: ddlDestinationLocation.val() == null ? '' : ddlDestinationLocation.val().toString(),
        zoneList: ddlRegion.val() == null ? '' : ddlRegion.val().toString(),
        docketList: txtDocketNo.val(),
        vendorId: hdnVendorId.val()
    };
    AjaxRequestWithPostAndJson(baseUrl, JSON.stringify(requestData), GetDocketListSuccess, ErrorFunction, false);
    return false;
}

function GetDocketListSuccess(responseData) {
    if (responseData.length === 0) {
        isStepValid = false;
        ShowMessage('No Record Found');
        return false;
    }

    dtDocketDetails.fnClearTable();
    if (responseData.length > 0) {
        $.each(responseData, function (i, item) {
            item.DocketId = SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'ManifestDocketList[' + i + '].IsChecked', CountTotalLoading) +
                "<input type='hidden' value='" + item.DocketId + "' name='ManifestDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketNo + "' name='ManifestDocketList[" + i + "].DocketNo' id='hdnDocketNo" + i + "'/>" +
                "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>" +
                "<input type='hidden' value='" + item.DocketId + "' name='ManifestDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketDate + "'  id='hdnDocketDate" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketSuffix + "' name='ManifestDocketList[" + i + "].DocketSuffix' id='hdnDocketSuffix" + i + "'/>" +
                "<input type='hidden' value='" + item.FromCityId + "' name='ManifestDocketList[" + i + "].FromCityId' id='hdnFromCityId" + i + "'/>" +
                "<input type='hidden' value='" + item.ToCityId + "' name='ManifestDocketList[" + i + "].ToCityId' id='hdnToCityId" + i + "'/>";
            
            item.DocketNo = item.DocketNo + " " + item.DocketSuffix;
            item.DocketDate = $.displayDateTime(item.DocketDate);
            item.Edd = $.displayDate(item.Edd);
            item.Packages = '<input class="form-control numeric" name="ManifestDocketList[' + i + '].LoadPackages" id="txtLoadPackages' + i + '" type="text" value=\'' + item.Packages + '\'/>' +
                '<span data-valmsg-for="ManifestDocketList[' + i + '].LoadPackages" data-valmsg-replace="true"></span>' +
                '<input type=\'hidden\' value=\'' + item.Packages + '\' name=\'ManifestDocketList[' + i + '].Packages\' id=\'hdnPackages' + i + '\' />';

            item.BalancePackages = '<input class="form-control textlabel numeric" name="ManifestDocketList[' + i + '].BalancePackages" id="txtBalancePackages' + i + '" type="text" value=\'' + 0 + '\'/>' +
                '<span data-valmsg-for="ManifestDocketList[' + i + '].BalancePackages" data-valmsg-replace="true"></span>';

            item.ActualWeight = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LoadActualWeight" id="txtLoadActualWeight' + i + '" type="text"  value=\'' + item.ActualWeight + '\'/>' +
                '<input type=\'hidden\' value=\'' + item.ActualWeight + '\' name=\'ManifestDocketList[' + i + '].ActualWeight\' id=\'hdnActualWeight' + i + '\' />';
            item.KartAmount = '<input class="form-control textlabel numeric3" name="ManifestDocketList[' + i + '].LoadKartAmount" id="txtLoadKartAmount' + i + '" type="text"  value=\'' + item.KartAmount + '\'/>' +
                '<input type=\'hidden\' value=\'' + item.KartAmount + '\' name=\'ManifestDocketList[' + i + '].KartAmount\' id=\'hdnKartAmount' + i + '\' />';
        });
        dtDocketDetails.dtAddData(responseData, [], InitDocketTable);
        CountTotalLoading();
    }
}

function InitDocketTable() {
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var txtLoadPackages = $('#' + chkDocket.Id.replace('chkDocket', 'txtLoadPackages'));
        var txtBalancePackages = $('#' + chkDocket.Id.replace('chkDocket', 'txtBalancePackages'));
        var txtLoadActualWeight = $('#' + chkDocket.Id.replace('chkDocket', 'txtLoadActualWeight'));
        var hdnPackages = $('#' + chkDocket.Id.replace('chkDocket', 'hdnPackages'));
        var hdnActualWeight = $('#' + chkDocket.Id.replace('chkDocket', 'hdnActualWeight'));
        var hdnBalancePackages = $('#' + chkDocket.Id.replace('chkDocket', 'hdnBalancePackages'));

        txtLoadPackages.blur(function () { OnPackagesChange(txtLoadPackages); });
        chkDocket.change(function () {
            if (!chkDocket.IsChecked) {
                txtLoadPackages.val(hdnPackages.val());
                txtLoadActualWeight.val(hdnActualWeight.val());
                
            }
            txtLoadPackages.enable(chkDocket.IsChecked);
        }).change();
    });
}


function OnPackagesChange(obj) {
    var txtLoadPackages = $(obj);
    txtLoadPackages.val(txtLoadPackages.round());
    var hdnPackages = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'hdnPackages'));


    if (hdnPackages.toInt() < txtLoadPackages.toInt())
        txtLoadPackages.val(hdnPackages.val());
    var txtLoadActualWeight = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'txtLoadActualWeight'));
    var txtLoadKartAmount = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'txtLoadKartAmount'));

    var hdnActualWeight = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'hdnActualWeight'));
    var hdnKartAmount = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'hdnKartAmount'));

    txtLoadActualWeight.val((parseFloat(txtLoadPackages.val()) * parseFloat(hdnActualWeight.val()) / parseFloat(hdnPackages.val())).toFixed(3));
    txtLoadKartAmount.val((parseFloat(txtLoadPackages.val()) * parseFloat(hdnKartAmount.val()) / parseFloat(hdnPackages.val())).toFixed(2));
    CountTotalLoading();
}

function CountTotalLoading() {
    var totalDocket = 0; totalPackages = 0, totalBalancePackages = 0, totalActualWeight = 0.000, totalKartAmount = 0.00;
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var txtLoadPackages = $('#' + chkDocket.Id.replace('chkDocket', 'txtLoadPackages'));
        var hdnPackages = $('#' + chkDocket.Id.replace('chkDocket', 'hdnPackages'));
        var txtBalancePackages = $('#' + chkDocket.Id.replace('chkDocket', 'txtBalancePackages'));
        if (chkDocket.IsChecked) {
            var txtLoadActualWeight = $('#' + chkDocket.Id.replace('chkDocket', 'txtLoadActualWeight'));
            var txtLoadKartAmount = $('#' + chkDocket.Id.replace('chkDocket', 'txtLoadKartAmount'));
            totalDocket++;
            totalPackages += parseInt(txtLoadPackages.val());
            totalActualWeight += parseFloat(txtLoadActualWeight.val());
            totalKartAmount += parseFloat(txtLoadKartAmount.val());
            txtBalancePackages.val(parseFloat(hdnPackages.val() - parseFloat(txtLoadPackages.val())));
            totalBalancePackages += parseInt(txtBalancePackages.val());
        }
    });
    hdnTotalDocket.val(totalDocket);
    txtTotalPackages.val(totalPackages);
    txtTotalBalancePackages.val(totalBalancePackages);
    txtTotalActualWeight.val(totalActualWeight.toFixed(3));
    txtTotalKartAmount.val(totalKartAmount.toFixed(2));
}

function ValidateOnStep2() {
    if (hdnTotalDocket.toInt() === 0) {
        isStepValid = false;
        ShowMessage('Please select atleast one ' + docketNomenclature);
        return false;
    }
}

function ValidateOnSubmit() {
    if (!ValidateModuleDateWithPreviousDocumentDate('dtDocketDetails', 'chkDocket', 'hdnDocketDate', 'txtManifestDateTime', manifestNomenclature+' Date')) return false;
}