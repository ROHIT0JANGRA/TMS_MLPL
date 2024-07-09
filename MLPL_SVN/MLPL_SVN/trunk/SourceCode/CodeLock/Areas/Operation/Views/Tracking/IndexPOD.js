var docketModuleId, prsModuleId, lsModuleId, mfModuleId, thcModuleId, drsModuleId, pfmModuleId, tripsheetModuleId, vrModuleId, docketNomenclature,isLocalStorage, localStoragePath, cloudStoragePath;

var ddlDocumentTypeId, drDocumentDate, ddlLocationId, txtDocumentNo, txtManualDocumentNo, dtDocketDetails, dtThcDetails, trackingUrl, dvDocketDetails, dvThcDetails, dtDrsDetails, dvDrsDetails,
    dtPrsDetails, dvPrsDetails, dvLoadingSheetDetails, dtLoadingSheetDetails, dvTripheetDetails, dtTripsheetDetails, dvManifestDetails, dtManifestDetails, dvPfmDetails, dtPfmDetails,
    dvVrDetails, dtVrDetails, dvDocketTalkDetails, dtDocketTalkDetails, hdnlocalStoragePath, hdnFilesPath;


$(document).ready(function () {
    SetPageLoad('Tracking', 'Document Tracking', '', '', '');
    InitObjects();
});

function InitObjects() {
    //ddlDocumentTypeId = $('#ddlDocumentTypeId');
    drDocumentDate = InitDateRangeCalYear('drDocumentDate', DateRange.LastWeek, false);
    ddlLocationId = $('#ddlLocationId');
    txtDocumentNo = $('#txtDocumentNo');
    txtManualDocumentNo = $('#txtManualDocumentNo');
    dvDocketDetails = $('#dvDocketDetails');
    hdnlocalStoragePath = $('#hdnlocalStoragePath');
    hdnFilesPath = $('#hdnFilesPath');
    ddlCustomerId = $('#ddlCustomerId');
    ddlListType = $('#ddlListType');
    DivZip = $('#DivZip');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentList },
        { StepName: 'Document List' }
    ], '');
}

function ViewAttachment(obj) {
    var hdnDocumentName = $('#' + obj);

    var filePath = '';
   // filePath = '/Storage/' + 'POD/';
    filePath = currentDomain +'Storage/POD/';

    window.open(filePath + hdnDocumentName.val(), "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=100,left=500,width=400,height=300");
    return false;
}

function GetDocumentList() {
    var FilePaths;
    FilePaths = "";

    if (ddlListType.val() == 2)
    {
        DivZip.hide();
    }
    else
    {
        DivZip.show();
    }

    var requestData = { locationId: ddlLocationId.val(), fromDate: drDocumentDate.startDate, toDate: drDocumentDate.endDate, documentNo: txtDocumentNo.val(), manualDocumentNo: txtManualDocumentNo.val(), CustomerId: ddlCustomerId.val(), ListType: ddlListType.val() };
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
                        { title: 'Handovered Date', data: 'HandoveredDate' },
                        { title: 'Handovered By', data: 'HandoveredBy' },
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
                    item.DocketDate = $.displayDate(item.DocketDate)+
                        "<input type='hidden' value='" + item.DocumentName + "' id='hdnDocumentName" + i + "'/>" +
                        "<input type='hidden' value='" + i + "' id='hdnID" + i + "'/>";

                    item.Edd = $.displayDate(item.Edd);

                    if (item.DocumentName == "")
                    {
                        item.View = "";
                    }
                    else
                    {
                        item.View = '<a href="#" onclick="return ViewAttachment(\'hdnDocumentName' + i + '\');" class="btckn btn-default btn-sm">' +
                                '<span class="fa fa-download"></span>' +
                            '</a>' +
                             "<input type='hidden' value='" + item.DocumentName + "' id='hdnDocumentName" + i + "'/>";
                    }
                });

                if (ddlListType.val() != 3) {
                    var table = $('#dtDocketDetails').DataTable();
                    table.column(11).visible(false, false);
                    table.column(12).visible(false, false);
                }


                dtDocketDetails.dtAddData(result, null, null, [[11, '10%']]);
                dtDocketDetails.find('tr td:eq(0)').css('max-width', '280px');
            }
        }, ErrorFunction, false);

    return false;
}


