var docketModuleId  ;

var ddlDocumentTypeId, dtDocketDetails, ddlLocationId, txtDocumentNo, txtManualDocumentNo;


$(document).ready(function () {
    SetPageLoad('Docket', 'Change Status', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtDocumentNo = $('#txtDocumentNo');
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentList },
        { StepName: 'Document List' }
    ], 'Submit');
}

function GetDocumentList() {
    var requestData = { documentNo: txtDocumentNo.val()};
    AjaxRequestWithPostAndJson(trackingUrl + '/GetDocketListForChangeStatus', JSON.stringify(requestData), function (result) {

            if (dtDocketDetails == null)
                dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
                    [
                        { title: docketNomenclature, data: 'DocketNo' },
                        { title: 'Booking Date', data: 'DocketDate' },
                        { title: 'Origin', data: 'FromLocation' },
                        { title: 'Destination', data: 'ToLocation' },
                        { title: 'Mode', data: 'TransportMode' },
                        { title: 'Paybas', data: 'Paybas' },
                        { title: 'Docket Status', data: 'DocketStatus' }
                    ]);

            dtDocketDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                $.each(result, function (i, item) {
                    item.DocketNo = "<input type='hidden' name='DocumentTrackingDetails[" + i + "].DocketId' value='" + item.DocketId + "' id='hdnDocketId" + i + "'/>" + item.DocketNo
                    item.DocketDate = $.displayDate(item.DocketDate);

                });
                dtDocketDetails.dtAddData(result);
            }
        }, ErrorFunction, false);

    return false;
}


