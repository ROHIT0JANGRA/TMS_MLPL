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
        { StepName: 'Document List', StepFunction: ValidateOnSubmit }
    ], 'Handover');
}
function ValidateOnSubmit() {

    
    if ($('#hdnPodCount').val() == 0) {
        isStepValid = false;
        ShowMessage('Please select atleast one POD');
        return false;
    }
}
function ViewAttachment(obj) {
    var hdnDocumentName = $('#' + obj);

    var filePath = '';
   // filePath = '/Storage/' + 'POD/';
    filePath = currentDomain +'Storage/POD/';

    window.open(filePath + hdnDocumentName.val(), "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=100,left=500,width=400,height=300");
    return false;
}

function SelectPod() {
    selectedPodList = [];
    $('[id*="chkPod"]').each(function () {
        var chkPod = $(this);
        if (chkPod.IsChecked)
            selectedPodList.push($('#' + chkPod.Id.replace('chkPod', 'hdnPodId')).val());
    });
    $('#hdnPodCount').val(selectedPodList.length);
}

function GetDocumentList() {
    var FilePaths;
    FilePaths = "";

    DivZip.show();

    var requestData = { locationId: ddlLocationId.val(), fromDate: drDocumentDate.startDate, toDate: drDocumentDate.endDate, documentNo: txtDocumentNo.val(), manualDocumentNo: txtManualDocumentNo.val(), CustomerId: ddlCustomerId.val(), ListType: ddlListType.val() };
    AjaxRequestWithPostAndJson(trackingUrl + '/GetDocketPODList', JSON.stringify(requestData), function (result) {

            if (dtDocketDetails == null)
                dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
                    [
                        { title: SelectAll.GetChkAll('chkPodAll', SelectPod), data: "PodId" },
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
                    item.PodId = "<div class='checkboxer'>" +
                                    SelectAll.GetChk('chkPodAll', 'chkPod' + i, 'DocumentTrackingDetails[' + i + '].IsChecked', SelectPod) +
                                "<input type='hidden' value='" + item.PodId + "' name='DocumentTrackingDetails[" + i + "].PodId' id='hdnPodId" + i + "'/>" +
                                "<label class='control-label' for='chkPod" + i + "' id='lblPodId" + i + "'></label>" +
                                "</div>";
                    item.DocketNo = "<input type='hidden' value='" + item.DocketId + "' id='hdnDocketId" + i + "'/>" + item.DocketNo
                    item.DocketDate =item.DocketDate+
                        "<input type='hidden' value='" + item.DocumentName + "' id='hdnDocumentName" + i + "'/>" +
                        "<input type='hidden' value='" + i + "' id='hdnID" + i + "'/>";

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


                dtDocketDetails.dtAddData(result, null, null, [[11, '10%']]);
                dtDocketDetails.find('tr td:eq(0)').css('max-width', '280px');
            }
        }, ErrorFunction, false);

    return false;
}


