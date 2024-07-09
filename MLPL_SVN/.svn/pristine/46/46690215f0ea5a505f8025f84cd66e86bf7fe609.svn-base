var docketNomenclature, baseUrl, drDocumentDate, txtDocumentNo, ddlDocumentTypeId, txtManualDocumentNo, dtDocumentDetails, selectedDocumentId = 0;
var thcUrl, prsUrl, drsUrl;

$(document).ready(function () {
    SetPageLoad('Thc', 'Finance Update');
    InitObjects();
});

function InitObjects() {
    
    txtDocumentNo = $('#txtDocumentNo');
    txtManualDocumentNo = $('#txtManualDocumentNo');
    drDocumentDate = InitDateRange('drDocumentDate', DateRange.LastWeek);
    ddlDocumentTypeId = $('#ddlDocumentTypeId');

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetDocumentList },
     { StepName: 'Document List', StepFunction: CheckStepValid }
    ], 'Go To Update');
}

function GetDocumentList() {
    var requestData = {
       
        fromDate: drDocumentDate.startDate,
        toDate: drDocumentDate.endDate,
        documentNo: txtDocumentNo.val(),
        manualDocumentNo: txtManualDocumentNo.val(),
        documentTypeId: ddlDocumentTypeId.val()
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetDocumentListForUpdate', JSON.stringify(requestData), function (result) {
      
            //if (result.length == 1 && !IsObjectNullOrEmpty(result[0].ValidationMassage)) {
            //    isStepValid = false;
            //    ShowMessage(result[0].ValidationMassage);
            //    return false;
            //}
            //else {
                if (dtDocumentDetails == null)
                    dtDocumentDetails = LoadDataTable('dtDocumentDetails', false, false, false, null, null, [],
                        [
                            { title: "Select", data: "DocumentId", width: 80 },
                            { title: 'Document No', data: 'DocumentNo' },
                            { title: 'Manual Document No', data: 'ManualDocumentNo' },
                            { title: 'Document Date', data: 'DocumentDate' },
                            { title: 'Origin', data: 'FromLocationCode' },
                            { title: "Vehicle No", data: 'VehicleNo' }
                        ]);
                dtDocumentDetails.fnClearTable();
            
            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                $.each(result, function (i, item) {
                    item.DocumentId = '<div class="clearfix">' +
                        '<label class="radio">' +
                        '<input type="radio" name=\'Document\' value=\'' + item.DocumentId + '\' onclick="SelectDocument(this.id);" tabindex="0" id="rdDocumentNo' + i + '"/><i></i>' +
                        '<label for="rdDocumentNo' + i + '">' + '' + '</label>' +
                        '<input type=\'hidden\' id=\'hdnDocumentId' + i + '\' value=\'' + item.DocumentId + '\' />' +
                        '</label>' +
                        '</div>';
                    item.DocumentDate = $.displayDate(item.DocumentDate);
                    item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="ddlDocumentTypeId' + i + '" class=" form-control"/>' +
                        '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                });
                dtDocumentDetails.dtAddData(result);
            }
       /* }*/
    }, ErrorFunction, false);
    return false;
    
}

function SelectDocument(rdId) {
    selectedDocumentId = $('#' + rdId).val();
}

function CheckStepValid() {
    
    isStepValid = false;
    if (selectedDocumentId == 0) {
        ShowMessage('Please select at least one Document');
        return false;
    }
    else {
        if (ddlDocumentTypeId.val() == 2) {
            var url = thcUrl + '/' + selectedDocumentId;
            window.location.href = url;
            return false;
        }
        else if (ddlDocumentTypeId.val() == 1) {
            var url = prsUrl + '/' + selectedDocumentId;
            window.location.href = url;
            return false;
        }
        else if (ddlDocumentTypeId.val() == 3) {
            var url = drsUrl + '/' + selectedDocumentId;
            window.location.href = url;
            return false;
        }
        return false;
    }
    return false;
}