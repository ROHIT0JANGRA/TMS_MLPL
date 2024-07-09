var ddlLocationId, hdnVendorId, chkDocumentType, dtDocumentList, selectedDocumentList, baseUrl, dtDocumentDetailsList;

$(document).ready(function () {
    SetPageLoad('Vendor', 'Document Approval', '', '', '');
    InitObjects();
});

function InitObjects() {

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentListForApproval },
        { StepName: 'Document List', StepFunction: ValidateOnSubmit }
    ], 'Submit');

    ddlLocationId = $('#ddlLocationId');
    chkDocumentType = $('#chkDocumentType');
}

function GetDocumentListForApproval() {
    var selectedValues = [];
    $("[id*=chkDocumentType]").each(function () {
        var chkDocumentType = $(this);
        if (chkDocumentType.IsChecked == true)
            selectedValues.push($('#' + chkDocumentType.Id.replace('chkDocumentType', 'hdnCodeId')).val());
    });

    var requestData = { locationId: ddlLocationId.val(), SelectedDocumentType: selectedValues.join(',') };

    AjaxRequestWithPostAndJson(baseUrl + '/GetDocumentListForApproval', JSON.stringify(requestData), function (result) {
        if (dtDocumentList == null)
            dtDocumentList = LoadDataTable('dtDocumentList', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllDocument', SelectDocument), data: "DocumentId", width: 80 },
                    { title: 'Document Type', data: 'DocumentType' },
                    { title: 'Document No', data: 'DocumentNo' },
                    { title: 'Document Date', data: 'DocumentDate' },
                    { title: 'Contract Amount', data: 'ContractAmount' },
                    { title: 'Action', data: 'Action' },
                    { title: 'Approved Amount', data: 'ApprovedAmount' }
                ]);

        dtDocumentList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedDocumentList = [];
            $.each(result, function (i, item) {
                item.DocumentId = SelectAll.GetChk('chkAllDocument', 'chkDocument' + i, 'Details[' + i + '].IsChecked', SelectDocument) +
                    "<input type='hidden' value='" + item.DocumentId + "' name='Details[" + i + "].DocumentId' id='hdnDocumentId" + i + "'/>" +
                    "<label class='label' for='chkDocument" + i + "' id='lblDocumentId" + i + "'></label>" +
                    "<input type='hidden' value='" + item.DocumentTypeId + "' name='Details[" + i + "].DocumentTypeId' id='hdnDocumentTypeId" + i + "'/>";
                item.DocumentDate = $.displayDate(item.DocumentDate);
                item.ApprovedAmount = '<input class="form-control numeric" name="Details[' + i + '].ApprovedAmount" id="txtApprovedAmount' + i + '" type="text" value=\'' + item.ApprovedAmount + '\'/>';
                item.Action = '<div class="inline-group">' +
                            '<label class="radio">' +
                                '<input checked="checked" id="rdApproved' + i + '" name="Details[' + i + '].IsApproved" type="radio" value="true" class="ea-triggers-bound">' +
                                '<i></i>' +
                                '<label for="rdApproved' + i + '">Approve</label>'+
                '</label>' +
                '<label class="radio">' +
                    '<input id="rdRejected' + i + '" name="Details[' + i + '].IsApproved" type="radio" value="false" class="ea-triggers-bound">' +
                    '<i></i>' +
                    '<label for="rdRejected' + i + '">Reject</label>' +
                '</label>' +
            '</div>';
            });
            dtDocumentList.dtAddData(result, [], InitDocumentTable);
        }
    }, ErrorFunction, false);
}

function InitDocumentTable() {
    $('[id*="rdApproved"]').each(function () {
        var rdApproved = $(this);
        var rdRejected = $('#' + this.id.replace('rdApproved', 'rdRejected'));
        var txtApprovedAmount = $('#' + this.id.replace('rdApproved', 'txtApprovedAmount'));
        txtApprovedAmount.readOnly(true);
        rdRejected.click(function () { txtApprovedAmount.readOnly(!rdApproved.IsChecked); });
        rdApproved.click(function () { txtApprovedAmount.readOnly(!rdApproved.IsChecked); });
    });
}

function SelectDocument() {
    selectedDocumentList = [];
    $('[id*="chkDocument"]').each(function () {
        var chkDocument = $(this);
        var rdApproved = $('#' + this.id.replace('chkDocument', 'rdApproved'));
        var txtApprovedAmount = $('#' + this.id.replace('chkDocument', 'txtApprovedAmount'));
        if (chkDocument.IsChecked) {
            selectedDocumentList.push($('#' + chkDocument.Id.replace('chkDocument', 'hdnDocumentId')).val());
            txtApprovedAmount.readOnly(!rdApproved.IsChecked);
        }
        else
            txtApprovedAmount.readOnly(true);
    });
}

function ValidateOnSubmit() {
    if (selectedDocumentList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Document');
        return false;
    }
}