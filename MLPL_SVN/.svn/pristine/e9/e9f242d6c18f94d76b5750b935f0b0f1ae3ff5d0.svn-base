var ruleMasterUrl, useEwayBillDetail;
$(document).ready(function () {
    SetPageLoad('THC', 'Departure', '', '', '');
    InitObjects();
});

function InitObjects() {
    drTHCDate = InitDateRange('drTHCDate', DateRange.LastWeek);
    txtTHCNos = $('#txtTHCNos');
    txtManifestNos = $('#txtManifestNos');
    txtVehicleNos = $('#txtVehicleNos');
    txtDocketNos = $('#txtDocketNos');

    lblVehicleNo = $('#lblVehicleNo');
    lblRouteName = $('#lblRouteName');
    lblThcDate = $('#lblThcDate');
    lblThcNo = $('#lblThcNo');
    txtThcNo = $('#txtThcNo');

    txtVehicleCapacity = $('#txtVehicleCapacity');
    txtWeightLoaded = $('#txtWeightLoaded');
    txtCapacityUtilizationInPercentage = $('#txtCapacityUtilizationInPercentage');
    ddlOverLoadedReasonId = $('#ddlOverLoadedReasonId');
    chkIsOverLoaded = $('#chkIsOverLoaded');

    hdnThcId = $('#hdnThcId');
    hdnRouteId = $('#hdnRouteId');
    hdnStartKm = $('#hdnStartKm');
    hdnTotalManifest = $('#hdnTotalManifest');
    hdnTotalDocket = $('#hdnTotalDocket');
    hdnTotalPackages = $('#hdnTotalPackages');
    hdnTotalActualWeight = $('#hdnTotalActualWeight');

    txtEwayBillIssueDate = $('#txtEwayBillIssueDate');
    txtEwayBillExpiryDate = $('#txtEwayBillExpiryDate');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetThcList },
        { StepName: 'THC List', StepFunction: LoadStep3 },
        { StepName: 'Departure Details' }
    ], 'Vehicle Departure');
    UseEwayBillDetail();
    txtEwayBillIssueDate.blur(function () {
        if (txtEwayBillIssueDate.val() != '' && txtEwayBillExpiryDate.val() != '') {
            if ($.setDateTime(txtEwayBillIssueDate.val()) >= $.setDateTime(txtEwayBillExpiryDate.val())) {
                ShowMessage('Please select EWAY Bill Issue Date less than EWAY Bill Expiry Date ');
                txtEwayBillIssueDate.val('');
                return false;
            }
        }
    });

    txtEwayBillExpiryDate.blur(function () {
        if (txtEwayBillIssueDate.val() != '' && txtEwayBillExpiryDate.val() != '') {
            if ($.setDateTime(txtEwayBillIssueDate.val()) >= $.setDateTime(txtEwayBillExpiryDate.val())) {
                ShowMessage('Please select EWAY Bill Expiry Date greater than EWAY Bill Issue Date ');
                txtEwayBillExpiryDate.val('');
                return false;
            }
        }
    });
}

function UseEwayBillDetail() {
    var requestData = { moduleId: 5, ruleId: 2 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        useEwayBillDetail = result == 'Y' ? true : false;
    }, ErrorFunction, false);
    if (useEwayBillDetail) {
        $('#dvEwayBillDetails').showHide(useEwayBillDetail);
    }
}

var dtThcList = null;
function GetThcList() {
    var requestData = { thcNos: txtTHCNos.val().trim(), fromDate: drTHCDate.startDate, toDate: drTHCDate.endDate, manifestNos: txtManifestNos.val().trim(), vehicleNos: txtVehicleNos.val().trim(), docketNos: txtDocketNos.val().trim(), locationId: locationId, companyId: companyId };

    AjaxRequestWithPostAndJson(baseUrl + '/GetThcListForThcDeparture', JSON.stringify(requestData), function (result) {
        if (result.length === 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedThc = [];
            if (dtThcList === null)
                dtThcList = LoadDataTable('dtThcList', false, false, false, null, null, [],
                    [
                        { title: 'THC No', data: 'ThcNo' },
                        { title: 'THC Date', data: 'ThcDate' },
                        { title: 'Previous Location', data: 'FromLocationCode' },
                        { title: 'Next Location', data: 'ToLocationCode' },
                        { title: 'Actual Arrival Date', data: "ActualArrivalDate" },
                        { title: 'Expected Departure Date', data: "ExpectedDepartureDate" }
                    ]);

            dtThcList.fnClearTable();
            $.each(result, function (i, item) {
                item.ThcNo = '<div class="clearfix">' +
                    '<label class="radio">' +
                    '<input type="radio" name=\'Thc\' value=\'' + item.ThcId + '\' onclick="SelectedThcId(this)" tabindex="0" id="chkThcNo' + i + '"/><i></i>' +
                    '<label id="lblThcNo' + i + '" for="chkThcNo' + i + '">' + item.ThcNo + '</label>' +
                    '</label>' +
                    '</div>';
                item.ThcDate = $.displayDate(item.ThcDateTime);
                item.ActualArrivalDate = $.displayDateTime(item.ActualArrivalDate);
                item.ExpectedDepartureDate = $.displayDateTime(item.ExpectedDepartureDate);
                item.ToLocationCode = "<input type='hidden' value='" + item.ToLocationId + "' id='hdnToLocationId" + i + "'/>" +
                    item.ToLocationCode;
            });
            dtThcList.dtAddData(result);
            selectedThcId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

var selectedThcId = 0;
function SelectedThcId(id) {
    selectedThcId = $(id).val();
    var chkThcNo = $(id);
    var hdnToLocationId = $('#' + chkThcNo.Id.replace('chkThcNo', 'hdnToLocationId'));
    $('#hdnToLocationId').val(hdnToLocationId.val());
}
var dtManifestDetails = null;
var currentLoad = {};
function LoadStep3() {
    isStepValid = selectedThcId !== 0;
    if (selectedThcId === 0) {
        ShowMessage('Please select THC');
        return false;
    }

    var requestData = { thcId: selectedThcId };
    AjaxRequestWithPostAndJson(baseUrl + '/GetThcDetailForThcDeparture', JSON.stringify(requestData), function (result) {

        lblVehicleNo.text(result.VehicleNo);
        lblRouteName.text(result.RouteName);
        lblThcDate.text($.displayDate(result.ThcDate));
        txtThcNo.val(result.ThcNo);

        txtVehicleCapacity.val(result.VehicleCapacity * 1000);
        txtWeightLoaded.val(result.TotalActualWeight);
        hdnTotalActualWeight.val(result.TotalActualWeight);
        txtCapacityUtilizationInPercentage.val(result.CapacityUtilization);

        currentLoad.TotalManifest = result.TotalManifest;
        currentLoad.TotalDocket = result.TotalDocket;
        currentLoad.TotalPackages = result.TotalPackages;
        currentLoad.TotalActualWeight = result.TotalActualWeight;

        hdnRouteId.val(result.RouteId);
        hdnThcId.val(result.ThcId);
        hdnStartKm.val(result.StartKm);
        if (dtManifestDetails != null)
        {
            dtManifestDetails.fnClearTable();
        }
        
        if (dtManifestDetails === null)
            
            dtManifestDetails = LoadDataTable('dtManifestDetails', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllManifest', SelectManifest), data: "ManifestId" },
                    { title: 'Manifest No', data: 'ManifestNo' },
                    { title: 'Manifest Date', data: 'ManifestDate' },
                    { title: 'Origin', data: 'OriginCode' },
                    { title: 'Next Location', data: 'DestinationCode' },
                    { title: 'Total ' + docketNomenclature, data: 'Docket' },
                    { title: 'Packages', data: 'Packages' },
                    { title: 'Actual Weight', data: 'ActualWeight' }
                ]);
            if (result.ThcDepartureManifestList.length > 0) {
                
              $.each(result.ThcDepartureManifestList, function (i, item) {
                item.ManifestId = SelectAll.GetChk('chkAllManifest', 'chkManifestId' + i, 'ThcDepartureManifestList[' + i + '].IsChecked', SelectManifest) +
                    "<input type='hidden' value='" + item.ManifestId + "' name='ThcDepartureManifestList[" + i + "].ManifestId' id='hdnManifestId" + i + "'/>" +
                    "<label class='label' for='chkManifestId" + i + "' id='lblManifestId" + i + "'></label>";
                item.ManifestDate = $.displayDate(item.ManifestDate);
                item.Docket = "<input type='text' value='" + item.Docket + "' id='txtDocket" + i + "'class='textlabel' style='text-align: right' disabled/>";
                item.Packages = "<input type='text' value='" + item.Packages + "' id='txtPackages" + i + "'class='textlabel' style='text-align: right' disabled/>";
                item.ActualWeight = "<input type='text' value='" + item.ActualWeight.toFixed(2) + "' id='txtActualWeight" + i + "'class='textlabel' style='text-align: right' disabled/>";
            });
            dtManifestDetails.dtAddData(result.ThcDepartureManifestList);
        }

        CountWeightLoaded();

    }, ErrorFunction, false);

    return false;
}

function SelectManifest() {
    selectedManifestList = [];
    $('[id*="chkManifestId"]').each(function () {
        var chkManifestId = $(this);
        var txtActualWeight = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'txtActualWeight'));
        if (chkManifestId.IsChecked) {
            selectedManifestList.push($('#' + chkManifestId.Id.replace('chkManifestId', 'hdnManifestId')).val());
        }
    });
    CountWeightLoaded();
}

function CountWeightLoaded() {
    var loadedWeight = 0, totalDocket = 0, totalPackages = 0, manifestCount = 0;
    $('[id*="chkManifestId"]').each(function () {
        var chkManifestId = $(this);
        var txtDocket = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'txtDocket'));
        var txtPackages = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'txtPackages'));
        var txtActualWeight = $('#' + chkManifestId.attr('id').replace('chkManifestId', 'txtActualWeight'));
        if (chkManifestId.is(':checked')) {
            manifestCount++;
            loadedWeight = parseFloat(loadedWeight) + parseFloat(txtActualWeight.val());
            totalDocket = parseInt(totalDocket) + parseInt(txtDocket.val());
            totalPackages = parseInt(totalPackages) + parseInt(txtPackages.val());
        }
    });

    hdnTotalManifest.val(parseInt(manifestCount) + currentLoad.TotalManifest);
    txtWeightLoaded.val(currentLoad.TotalActualWeight + loadedWeight);
    hdnTotalDocket.val(currentLoad.TotalDocket + totalDocket);
    hdnTotalPackages.val(currentLoad.TotalPackages + totalPackages);
    hdnTotalActualWeight.val(currentLoad.TotalActualWeight + loadedWeight);

    var vehicleCapacity = parseFloat(txtVehicleCapacity.val());
    if (vehicleCapacity > 0)
        txtCapacityUtilizationInPercentage.val((parseFloat(txtWeightLoaded.val()) * 100 / vehicleCapacity).toFixed(2));
    if (parseFloat(txtCapacityUtilizationInPercentage.val()) > 100)
        chkIsOverLoaded.prop("checked", true);
    else
        chkIsOverLoaded.prop("checked", false);
    ddlOverLoadedReasonId.enable(chkIsOverLoaded.is(':checked'));
    ddlOverLoadedReasonId.val('');
}

