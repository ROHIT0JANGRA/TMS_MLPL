var docketModuleId, prsModuleId, lsModuleId, mfModuleId, thcModuleId, drsModuleId, pfmModuleId, tripsheetModuleId, vrModuleId, docketNomenclature,isLocalStorage, localStoragePath, cloudStoragePath;

var ddlDocumentTypeId, drDocumentDate, ddlLocationId, txtDocumentNo, txtManualDocumentNo, dtDocketDetails, dtThcDetails, trackingUrl, dvDocketDetails, dvThcDetails, dtDrsDetails, dvDrsDetails,
    dtPrsDetails, dvPrsDetails, dvLoadingSheetDetails, dtLoadingSheetDetails, dvTripheetDetails, dtTripsheetDetails, dvManifestDetails, dtManifestDetails, dvPfmDetails, dtPfmDetails,
    dvVrDetails, dtVrDetails, dvDocketTalkDetails, dtDocketTalkDetails;

$(document).ready(function () {
    SetPageLoad('Tracking', 'Document Tracking', '', '', '');
    InitObjects();
});

function InitObjects() {
    drDocumentDate = InitDateRange('drDocumentDate', DateRange.LastWeek, false);
    ddlLocationId = $('#ddlLocationId');
    txtDocumentNo = $('#txtDocumentNo');
    txtManualDocumentNo = $('#txtManualDocumentNo');
    dvDocketDetails = $('#dvDocketDetails');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentList },
        { StepName: 'Document List' }
    ], '');
}

function ViewAttachment(DocumentName) {
    var FPath = filePath + 'POD/' + DocumentName;
    alert(FPath);

    window.open(FPath, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=100,left=500,width=400,height=300");
    return false;
}

function GetDocumentList() {
    var requestData = { locationId: ddlLocationId.val(), fromDate: drDocumentDate.startDate, toDate: drDocumentDate.endDate, documentNo: txtDocumentNo.val(), manualDocumentNo: txtManualDocumentNo.val() };
    AjaxRequestWithPostAndJson(trackingUrl + '/GetDocketPODList', JSON.stringify(requestData), function (result) {

        if (dtDocketDetails == null)
            dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
                [
                    { title: docketNomenclature, data: 'DocketNo' },
                    { title: 'Booking Date', data: 'DocketDate' },
                    { title: 'EDD', data: 'Edd' },
                    { title: 'Origin', data: 'FromLocation' },
                    { title: 'Destination', data: 'ToLocation' },
                    { title: 'From', data: 'FromCity' },
                    { title: 'To', data: 'ToCity' },
                    { title: 'Mode', data: 'TransportMode' },
                    { title: 'Paybas', data: 'Paybas' },
                    { title: 'Consignor Name', data: 'ConsignorName' },
                    { title: 'Consignee Name', data: 'ConsigneeName' },
                    { title: 'View', data: 'View' }
                ]);

        dtDocketDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            dvDocketDetails.show();
            $.each(result, function (i, item) {
                item.DocketNo = "<input type='hidden' value='" + item.DocketId + "' id='hdnDocketId" + i + "'/>" + item.DocketNo
                item.DocketDate = $.displayDate(item.DocketDate) +
                    "<input type='hidden' value='" + item.DocumentName + "' id='hdnDocumentName" + i + "'/>";
                item.Edd = $.displayDate(item.Edd);

                item.View = "<a href='#' id='lnkDocketId" + i + "' onclick='return ViewAttachment('" + item.DocumentName + "');'>View</a>";
            });
            dtDocketDetails.dtAddData(result);
        }
    }, ErrorFunction, false);

    return false;
}

