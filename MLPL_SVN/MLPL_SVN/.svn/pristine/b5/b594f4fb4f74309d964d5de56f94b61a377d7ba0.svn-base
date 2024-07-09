var docketModuleId, prsModuleId, lsModuleId, mfModuleId, thcModuleId, drsModuleId, pfmModuleId, tripsheetModuleId, vrModuleId, docketNomenclature,isLocalStorage, localStoragePath, cloudStoragePath;

var ddlDocumentTypeId, drDocumentDate, ddlLocationId, txtDocumentNo, txtManualDocumentNo, dtDocketDetails, dtThcDetails, trackingUrl, dvDocketDetails, dvThcDetails, dtDrsDetails, dvDrsDetails,
    dtPrsDetails, dvPrsDetails, dvLoadingSheetDetails, dtLoadingSheetDetails, dvTripheetDetails, dtTripsheetDetails, dvManifestDetails, dtManifestDetails, dvPfmDetails, dtPfmDetails,
    dvVrDetails, dtVrDetails, dvDocketTalkDetails, dtDocketTalkDetails;

$(document).ready(function () {
    SetPageLoad('Labour DC', 'Document Tracking', '', '', '');
    InitObjects();

    
});

function InitObjects() {
    ddlLocationId = $('#ddlLocationId'); hdnVendorId = $('#hdnVendorId');
    drDocketDate = InitDateRange('drDocketDate', DateRange.LastWeek, false);

    //dtDocketDetails = $('#dtDocketDetails');
    hdnVendorId.val("0");
    txtManifestsNo = $('#txtManifestsNo');
    txtTotalAmount = $('#txtTotalAmount');
    hdnTotalDocket = $('#hdnTotalDocket');
    lblDocumentName = $('#lblDocumentName');
    ddlDocumentType = $('#ddlDocumentType');
    lblDocumentTypeName = $('#lblDocumentTypeName');
    divTHCType = $('#divTHCType');
    ddlTHCType = $('#ddlTHCType');

    VendorAutoComplete('txtVendorCode', 'hdnVendorId', '', 9);
    $('#txtVendorCode').blur(function () { IsVendorCodeExist($('#txtVendorCode'), $('#hdnVendorId'), $('#lblVendorName'), '', 9); });

    ddlDocumentType.change(OnDocumentTypeChange).change();

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentList },
        { StepName: 'Document List' }
    ], '');
}

function OnTHCTypeChange() {

    if (ddlDocumentType.val() == 3) {
        divTHCType.show();
    }
    else {
        divTHCType.hide();
    }
}
function OnDocumentTypeChange() {
    OnTHCTypeChange();
}

function OpenDocketPrint(docketId) {
    var prmList = [{ Name: "DocketId", Value: docketId }];
    var reportInfo = { PrmList: prmList, Name: 'DocketView', Description: 'Docket View' };
    return ShowReport(reportInfo);
}

function GetDocumentList() {

    var requestData = {
        locationId: ddlLocationId.val(),
        fromDate: $.displayDate(drDocketDate.startDate),
        toDate: $.displayDate(drDocketDate.endDate),
        docketList: txtManifestsNo.val(),
        DocumentType: ddlDocumentType.val(),
        THCType: ddlTHCType.val(),
        VendorId: hdnVendorId.val()
    };
    AjaxRequestWithPostAndJson(trackingUrl, JSON.stringify(requestData), function (result) {
        if (dtDocketDetails == null)
       dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
                    [
                        { title: 'LabourDC No', data: 'LabourDCNo' },
                        { title: 'Date', data: 'LabourDCDate' },
                        { title: 'Location', data: 'LocationCode' },
                        { title: 'Vendor', data: 'VendorCode' },
                        { title: 'Dockets', data: 'TotalManifest' },
                        { title: 'Packages', data: 'TotalPackages' },
                        { title: 'Actual Weight', data: 'TotalActualWeight' },
                        { title: 'Amount', data: 'TotalAmount' },
                        { title: 'Document Type', data: 'DocumentType' },
                        { title: 'Detail', data: 'DocumentDetail' },
                        { title: 'Billed', data: 'isBilled' },
                        { title: 'BILLNO', data: 'BILLNO' },
                        { title: 'LDC Status', data: 'LdcStatus' },
                        { title: 'View', data: 'View' }
                    ]);

       dtDocketDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                $.each(result, function (i, item) {
                    item.LabourDCNo = "<input type='hidden' value='" + item.LabourDCId + "' id='hdnThcId" + i + "'/>" + item.LabourDCNo;
                    item.LabourDCDate = $.displayDate(item.LabourDCDate);
                    item.View = '<button id = "btnLabourView' + i + '" onclick="return ViewPrint(' + item.LabourDCId + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtDocketDetails.dtAddData(result);
            }
        }, ErrorFunction, false);

    return false;
}

function ViewPrint(value) {
    var prmList = [{ Name: "DocketId", Value: value }];
    var reportInfo = { PrmList: prmList, Name: 'TrackPodPfm', Description: 'Track POD/PFM' };
    return ShowReport(reportInfo);
}


