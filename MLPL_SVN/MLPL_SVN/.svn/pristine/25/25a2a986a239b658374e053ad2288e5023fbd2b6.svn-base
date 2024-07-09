$(document).ready(function () {
    SetPageLoad(loadingSheetNomenclature, 'Generate', 'drDocketDate');

    InitWizard('dvWizard', [{ StepName: 'Criteria', StepFunction: GetDocketList },
        { StepName: docketNomenclature + ' List', StepFunction: ValidateStep2 },
        { StepName: loadingSheetNomenclature+' Detail', StepFunction: ValidateOnSubmit }
    ],'Generate '+loadingSheetNomenclature);

    hdnNextLocationId = $('#hdnNextLocationId'); txtNextLocationCode = $('#txtNextLocationCode'); hdnFromCityId = $('#hdnFromCityId'); txtFromCityName = $('#txtFromCityName'); hdnToCityId = $('#hdnToCityId'); txtToCityName = $('#txtToCityName');
    drDocketDate = InitDateRange('drDocketDate', DateRange.LastWeek);

    ddlTransportModeId = $('#ddlTransportModeId');
    ddlDestinationLocation = $('#ddlDestinationLocation');
    ddlRegion = $('#ddlRegion');
    txtDocketNo = $('#txtDocketNo');
    dtDocketDetails = $('#dtDocketDetails');

    $('#ddlTransportModeId option').eq(0).before($('<option>', { value: 0, text: 'All' }));
    ddlTransportModeId.val(0);

    txtTotalPackages = $('#txtTotalPackages'); txtTotalActualWeight = $('#txtTotalActualWeight'); hdnTotalDocket = $('#hdnTotalDocket');

    LocationAutoComplete('txtNextLocationCode', 'hdnNextLocationId', 'Next Stop');
    CityAutoComplete('txtFromCityName', 'hdnFromCityId','From City');
    CityAutoComplete('txtToCityName', 'hdnToCityId','To City');

    txtNextLocationCode.blur(function () { return IsLocationCodeExist(txtNextLocationCode, hdnNextLocationId, 'Next Stop'); });
    txtFromCityName.blur(function () { return IsCityNameExist(txtFromCityName, hdnFromCityId, 'From City'); });
    txtToCityName.blur(function () { return IsCityNameExist(txtToCityName, hdnToCityId,'To City'); });

    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [
            { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllDocket', CountTotalLoading) + "</div>", data: "DocketId", width: 80 },
            { title: docketNomenclature , data: "DocketNo" },
            { title: 'Booking Date', data: "DocketDate" },
            { title: 'Origin', data: "FromLocationCode" },
            { title: 'Destination', data: "ToLocationCode" },
            { title: 'ConsignorName', data: "ConsignorName" },
            { title: 'ConsigneeName', data: "ConsigneeName" },
            { title: 'Pay Basis', data: "Paybas" },
            { title: 'EDD', data: "Edd" },
            { title: 'Packages', data: "Packages" },
            { title: 'Actual Weight', data: "ActualWeight" }

        ]);
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
        docketList: txtDocketNo.val()
    };
    AjaxRequestWithPostAndJson(baseUrl, JSON.stringify(requestData), GetDocketListSuccess, ErrorFunction, false);
    return false;
}

function GetDocketListSuccess(responseData) {
    dtDocketDetails.showHide(!responseData.length == 0);
    if (responseData.length == 0) {
        isStepValid = false;
        ShowMessage('No Record Found');
        return false;
    }
    dtDocketDetails.fnClearTable();
    if (responseData.length > 0) {
        $.each(responseData, function (i, item) {
            item.DocketId = SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'LoadingSheetDocketList[' + i + '].IsChecked', CountTotalLoading) +
                "<input type='hidden' value='" + item.DocketId + "' name='LoadingSheetDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>" +
                "<input type='hidden' value='" + item.DocketId + "' name='LoadingSheetDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketDate + "'  id='hdnDocketDate" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketSuffix + "' name='LoadingSheetDocketList[" + i + "].DocketSuffix' id='hdnDocketSuffix" + i + "'/>";
                
            item.DocketNo = item.DocketNo + " " + item.DocketSuffix;
            item.DocketDate = $.displayDateTime(item.DocketDate);
            item.Edd = $.displayDate(item.Edd);
            item.Packages = "<input type='hidden' value='" + item.Packages + "' name='LoadingSheetDocketList[" + i + "].Packages' id='hdnPackages" + i + "'/>" +
                "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].Packages' id='lblPackages" + i + "'>" + item.Packages + "</label>";
            item.ActualWeight = "<input type='hidden' value='" + item.ActualWeight + "' name='LoadingSheetDocketList[" + i + "].ActualWeight' id='hdnActualWeight" + i + "'/>" +
                "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].ActualWeight' id='lblActualWeight" + i + "'>" + item.ActualWeight.toFixed(3); + "</label>";

        });
        dtDocketDetails.dtAddData(responseData);
        CountTotalLoading();
    }
}

function CountTotalLoading() {
    var totalDocket = 0; totalPackages = 0, totalActualWeight = 0.000;
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var lblPackages = $('#' + chkDocket.Id.replace('chkDocket', 'lblPackages'));
        var lblActualWeight = $('#' + chkDocket.Id.replace('chkDocket', 'lblActualWeight'));

        if (chkDocket.IsChecked) {
            totalDocket++;
            totalPackages += parseInt(lblPackages.text());
            totalActualWeight += parseFloat(lblActualWeight.text());
        }
    });
    hdnTotalDocket.val(totalDocket);
    txtTotalPackages.val(totalPackages);
    txtTotalActualWeight.val(totalActualWeight.toFixed(3));
}

function ValidateStep2()
{
    if (hdnTotalDocket.toInt() == 0) {
        isStepValid = false;
        ShowMessage('Please select atleast one ' + docketNomenclature);
        return false;
    }
}

function ValidateOnSubmit() {
    if (!ValidateModuleDateWithPreviousDocumentDate('dtDocketDetails', 'chkDocket', 'hdnDocketDate', 'txtLoadingSheetDateTime', loadingSheetNomenclature +' Date')) return false;
}