$(document).ready(function () {
    SetPageLoad('Docket', 'Re Calculate', 'drDocketDate');

    InitWizard('dvWizard', [{ StepName: 'Criteria', StepFunction: GetDocketList },
        { StepName:' Docket List', StepFunction: GetRecalculate }
    ],'Re-Calculate');

    hdnNextLocationId = $('#hdnNextLocationId'); txtNextLocationCode = $('#txtNextLocationCode'); hdnFromCityId = $('#hdnFromCityId'); txtFromCityName = $('#txtFromCityName'); hdnToCityId = $('#hdnToCityId'); txtToCityName = $('#txtToCityName');
    drDocketDate = InitDateRange('drDocketDate', DateRange.LastWeek);

    ddlTransportModeId = $('#ddlTransportModeId');
    ddlDestinationLocation = $('#ddlDestinationLocation');
    ddlRegion = $('#ddlRegion');
    txtDocketNo = $('#txtDocketNo');
   // txtPickupID = $('#txtPickupID');
    dtDocketDetails = $('#dtDocketDetails');
    txtCustomerCode = $('#txtCustomerCode');
    lblCustomerName = $('#lblCustomerName');
    hdnCustomerId = $('#hdnCustomerId');
    $('#ddlTransportModeId option').eq(0).before($('<option>', { value: 0, text: 'All' }));
    ddlTransportModeId.val(0);
    hdnCustomerId.val(0);

    txtTotalPackages = $('#txtTotalPackages'); txtTotalActualWeight = $('#txtTotalActualWeight'); hdnTotalDocket = $('#hdnTotalDocket');

    LocationAutoComplete('txtNextLocationCode', 'hdnNextLocationId', 'Next Stop');
    CityAutoComplete('txtFromCityName', 'hdnFromCityId','From City');
    CityAutoComplete('txtToCityName', 'hdnToCityId','To City');

    txtNextLocationCode.blur(function () { return IsLocationCodeExist(txtNextLocationCode, hdnNextLocationId, 'Next Stop'); });
    txtFromCityName.blur(function () { return IsCityNameExist(txtFromCityName, hdnFromCityId, 'From City'); });
    txtToCityName.blur(function () { return IsCityNameExist(txtToCityName, hdnToCityId,'To City'); });

    CustomerAutoComplete('txtCustomerCode', 'hdnCustomerId');

    txtCustomerCode.blur(function () {
        IsCustomerCodeExist(txtCustomerCode, hdnCustomerId, lblCustomerName);
    });

    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [
            { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllDocket', CountTotalLoading) + "</div>", data: "DocketId", width: 80 },
            { title: 'S. No.', data: "SNo", width: 80 },
            { title: 'Docket No', data: "DocketNo" },
            { title: 'Pickup ID', data: "PickupID" },
            { title: 'Booking Date', data: "DocketDate" },
            { title: 'Packages', data: "Packages" },
            { title: 'Actual Weight', data: "ActualWeight" },
            { title: 'Charge Weight', data: "ChargeWeight" },
            { title: 'Freight Rate', data: "FreightRate" },
            { title: 'Freight', data: "Freight" },
            { title: 'Charge Amount', data: "ChargeAmount" },
            { title: 'Sub Total', data: "SubTotal" },
            { title: 'Tax Total', data: "TaxTotal" },
            { title: 'Grand Total', data: "GrandTotal" },
            { title: 'Customer Name', data: "CustomerName" },
            { title: 'From City', data: "FromCity" },
            { title: 'To City', data: "ToCity" },
            { title: 'Origin', data: "FromLocationCode" },
            { title: 'Pay Basis', data: "Paybas" },
            { title: 'EDD', data: "Edd" }

        ]);
});
function GetRecalculate() {
    var docketList="";
    var index = 0;

    isStepValid = false;

    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var hdnDocketId = $('#' + chkDocket.Id.replace('chkDocket', 'hdnDocketId'));

        if (chkDocket.IsChecked) {
            if (index == 0) {
                docketList = hdnDocketId.val();
                index = 1;
            }
            else {
                docketList = docketList +"," + hdnDocketId.val();
            }

        }

    });


    var requestData = {
        docketList: docketList
    };
    ShowLoader();

    AjaxRequestWithPostAndJson(baseUrl + '/GetRecalculate', JSON.stringify(requestData), GetRecalculateSuccess, ErrorFunction, false);


    return false;
}

function GetRecalculateSuccess(responseData) {
    dtDocketDetails.showHide(!responseData.length == 0);
    if (responseData.length == 0) {
        isStepValid = false;
        return false;
    }


    if (responseData.length > 0) {
        $.each(responseData, function (i, item) {
            $('[id*="chkDocket"]').each(function () {
                var chkDocket = $(this);
                var hdnDocketId = $('#' + chkDocket.Id.replace('chkDocket', 'hdnDocketId'));
                var lblChargeWeight = $('#' + chkDocket.Id.replace('chkDocket', 'lblChargeWeight'));
                var lblFreightRate = $('#' + chkDocket.Id.replace('chkDocket', 'lblFreightRate'));
                var lblFreight = $('#' + chkDocket.Id.replace('chkDocket', 'lblFreight'));
                var lblChargeAmount = $('#' + chkDocket.Id.replace('chkDocket', 'lblChargeAmount'));
                var lblSubTotal = $('#' + chkDocket.Id.replace('chkDocket', 'lblSubTotal'));
                var lblTaxTotal = $('#' + chkDocket.Id.replace('chkDocket', 'lblTaxTotal'));
                var lblGrandTotal = $('#' + chkDocket.Id.replace('chkDocket', 'lblGrandTotal'));

                if (hdnDocketId.val() == item.DocketId) {
                    lblChargeWeight.text(item.ChargeWeight);
                    lblFreightRate.text(item.FreightRate);
                    lblFreight.text(item.Freight);
                    lblChargeAmount.text(item.ChargeAmount);
                    lblSubTotal.text(item.SubTotal);
                    lblTaxTotal.text(item.TaxTotal);
                    lblGrandTotal.text(item.GrandTotal);
                }
            });
        });
    }
    HideLoader();
}


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
        CustomerId: hdnCustomerId.val(),
        PickupList: ""//txtPickupID.val()
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetDocketListForRecalculate', JSON.stringify(requestData), GetDocketListSuccess, ErrorFunction, false);
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

            item.SNo = "<label class='label' >" + (i + 1); + "</label>";
            item.DocketNo = '<a href="javascript:void(0)"  id="loginlink" onclick="ShowModelPopUp(' + item.DocketId +')">' + item.DocketNo + '</a> ';

            item.DocketId = SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'LoadingSheetDocketList[' + i + '].IsChecked', CountTotalLoading) +
                "<input type='hidden' value='" + item.DocketId + "' name='LoadingSheetDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>" +
                //"<input type='hidden' value='" + item.DocketId + "' name='LoadingSheetDocketList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketDate + "'  id='hdnDocketDate" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketSuffix + "' name='LoadingSheetDocketList[" + i + "].DocketSuffix' id='hdnDocketSuffix" + i + "'/>";
                
            item.DocketDate = $.displayDate(item.DocketDate);
            item.Edd = $.displayDate(item.Edd);
            item.Packages = "<input type='hidden' value='" + item.Packages + "' name='LoadingSheetDocketList[" + i + "].Packages' id='hdnPackages" + i + "'/>" +
                "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].Packages' id='lblPackages" + i + "'>" + item.Packages + "</label>";
            item.ActualWeight = "<input type='hidden' value='" + item.ActualWeight + "' name='LoadingSheetDocketList[" + i + "].ActualWeight' id='hdnActualWeight" + i + "'/>" +
                "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].ActualWeight' id='lblActualWeight" + i + "'>" + item.ActualWeight.toFixed(3); + "</label>";

            item.ChargeWeight = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].ChargeWeight'  id='lblChargeWeight" + i + "'>" + item.ChargeWeight.toFixed(3); + "</label>";

            item.FreightRate = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].FreightRate' id='lblFreightRate" + i + "'>" + item.FreightRate.toFixed(3); + "</label>";
            item.Freight = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].Freight' id='lblFreight" + i + "'>" + item.Freight.toFixed(3); + "</label>";
            item.ChargeAmount = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].ChargeAmount' id='lblChargeAmount" + i + "'>" + item.ChargeAmount.toFixed(3); + "</label>";
            item.SubTotal = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].SubTotal' id='lblSubTotal" + i + "'>" + item.SubTotal.toFixed(3); + "</label>";
            item.TaxTotal = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].TaxTotal' id='lblTaxTotal" + i + "'>" + item.TaxTotal.toFixed(3); + "</label>";
            item.GrandTotal = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].GrandTotal' id='lblGrandTotal" + i + "'>" + item.GrandTotal.toFixed(3); + "</label>";
            item.CustomerName = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].CustomerName' >" + item.CustomerName; + "</label>";
            item.FromCity = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].FromCity' >" + item.FromCity; + "</label>";
            item.ToCity = "<label class='label numeric2' name='LoadingSheetDocketList[" + i + "].ToCity' >" + item.ToCity; + "</label>";


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
        }
    });
    hdnTotalDocket.val(totalDocket);
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