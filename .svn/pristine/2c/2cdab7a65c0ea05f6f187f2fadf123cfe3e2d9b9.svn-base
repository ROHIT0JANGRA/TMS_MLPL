var txtGrnNos, txtInvoiceNos, drDate, rejectReasonList, dtInspectionList, selectedGrnList;

$(document).ready(function () {
    SetPageLoad('Inspection', '', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtGrnNos = $('#txtGrnNos');
    txtInvoiceNos = $('#txtInvoiceNos');

    drGrnDate = InitDateRange('drGrnDate', DateRange.LastWeek);
    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetInspectionList },
     { StepName: 'Inspection Details', StepFunction: ValidateOnSubmit }
    ], 'Submit');

    AjaxRequestWithPostAndJson(inspectionUrl + '/GetRejectReasonList', JSON.stringify([]), function (result) {
        rejectReasonList = result.Reject;
    }, ErrorFunction, false);

    selectedGrnList = [];

    dtInspectionList = LoadDataTable('dtInspectionList', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllGrn', SelectGrn), data: "GrnId" },
                  { title: 'GRN No', data: 'GrnNo' },
                  { title: 'GRN Date', data: 'GrnDate' },
                  { title: 'Product Name', data: 'ProductName' },
                  { title: 'GRN Quantity', data: 'GrnQuantity' },
                  { title: 'Inspection Quantity', data: 'InspectionQuantity' },
                  { title: 'Approve Quantity', data: 'ApproveQuantity' },
                  { title: 'Repacking Quantity', data: 'RepackingQuantity' },
                  { title: 'Rejected Quantity', data: 'RejectedQuantity' },
                  { title: 'Reject Reason', data: 'RejectReason' },
                  { title: 'Remarks', data: 'Remarks' }
              ]);
}

function GetInspectionList() {
    var requestData = { warehouseId: warehouseId, companyId: companyId, fromDate: drGrnDate.startDate, toDate: drGrnDate.endDate, invoiceNos: txtInvoiceNos.val() != '' ? txtInvoiceNos.val() : '', grnNos: txtGrnNos.val() != '' ? txtGrnNos.val() : '' };

    AjaxRequestWithPostAndJson(inspectionUrl + '/GetInspectionList', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedDocumentList = [];
            dtInspectionList.fnClearTable();
            $.each(result, function (i, item) {
                item.GrnId = "<div class='checkboxer'>" +
                                    SelectAll.GetChk('chkAllGrn', 'chkGrnId' + i, 'Details[' + i + '].IsChecked', SelectGrn) +
                                    "<input type='hidden' value='" + item.GrnId + "' name='Details[" + i + "].GrnId' id='hdnGrnId" + i + "'/>" +
                                    "<label class='control-label' for='chkGrnId" + i + "' id='lblGrnId" + i + "'></label>" +
                                    "</div>";
                item.ProductName = "<label>" + item.ProductName + "</label><input type='hidden' value='" + item.ProductId + "' name='Details[" + i + "].ProductId' id='hdnProductId" + i + "'/>";
                item.GrnQuantity = '<input type="text" name="Details[' + i + '].GrnQuantity" id="txtGrnQuantity' + i + '" value=' + item.GrnQuantity + ' class="textlabel form-control"/>';

                item.ApproveQuantity = '<input type=\'text\' name="Details[' + i + '].ApproveQuantity" id="txtGoodQuantity' + i + '" value="' + item.InspectionQuantity + '"  class=" form-control numeric3"/>' +
                    '<span data-valmsg-for="Details[' + i + '].ApproveQuantity" data-valmsg-replace="true"></span>';
                item.RepackingQuantity = '<input type=\'text\' name="Details[' + i + '].RepackingQuantity" id="txtRepackingQuantity' + i + '" value="0.000" class=" form-control numeric3"/>' +
                     '<span data-valmsg-for="Details[' + i + '].RepackingQuantity" data-valmsg-replace="true"></span>';
                item.RejectedQuantity = '<input type=\'text\' name="Details[' + i + '].RejectQuantity" id="txtRejectQuantity' + i + '" value="0.000"  class=" form-control numeric3"/>' +
                     '<span data-valmsg-for="Details[' + i + '].RejectQuantity" data-valmsg-replace="true"></span>';
                item.RejectReason = "<div class='select'>" +
                                           "<select class='form-control' name='Details[" + i + "].RejectReason' id='ddlRejectReasonId" + i + "' > " + "</select>" +
                                           '<i></i>'
                                       "</div>" +
                                       '<span data-valmsg-for="Details[' + i + '].RejectReason" data-valmsg-replace="true"></span>';
                item.InspectionQuantity = '<input type="text" name="Details[' + i + '].InspectionQuantity" id="txtInspectionQuantity' + i + '" value=' + item.InspectionQuantity + ' class="textlabel form-control"/>' +
                    '<span data-valmsg-for="Details[' + i + '].InspectionQuantity" data-valmsg-replace="true"></span>';
                item.Remarks = '<input type=\'text\' name="Details[' + i + '].Remarks" id="txtRemarks' + i + '" class=" form-control"/>' +
                    '<span data-valmsg-for="Details[' + i + '].Remarks" value=" " data-valmsg-replace="true"></span>';
                item.GrnDate = $.displayDate(item.GrnDate);

            });
            dtInspectionList.dtAddData(result);

            dtInspectionList.find('[id*="txtRemarks"]').each(function () {
                var txtRemarks = $('#' + this.id);
                var ddlRejectReasonId = $('#' + this.id.replace('txtRemarks', 'ddlRejectReasonId'));

                var txtInspectionQuantity = $('#' + this.id.replace('txtRemarks', 'txtInspectionQuantity'));
                var txtRejectQuantity = $('#' + this.id.replace('txtRemarks', 'txtRejectQuantity'));
                var txtRepackingQuantity = $('#' + this.id.replace('txtRemarks', 'txtRepackingQuantity'));
                var txtGoodQuantity = $('#' + this.id.replace('txtRemarks', 'txtGoodQuantity'));
                var txtTotalQuantity = $('#' + this.id.replace('txtRemarks', 'txtTotalQuantity'));

                var inspectionQuantity = parseFloat(txtInspectionQuantity.val());
                var goodQuantity = inspectionQuantity - parseFloat(txtRejectQuantity.val()) - parseFloat(txtRepackingQuantity.val());
                AddRange(txtRepackingQuantity, 'Reapacking Quantity cannot be more than' + inspectionQuantity.toFixed(3), 0, inspectionQuantity);
                AddRange(txtRejectQuantity, 'Rejected Quantity cannot be more than' + inspectionQuantity.toFixed(3), 0, inspectionQuantity);
                AddRange(txtGoodQuantity, 'Approved Quantity cannot be more than' + inspectionQuantity.toFixed(3), 0, inspectionQuantity);

                txtRepackingQuantity.blur(function () { CalculateTotalQuantity(txtRepackingQuantity.Id, 'txtRepackingQuantity') });
                txtRejectQuantity.blur(function () { CalculateTotalQuantity(txtRejectQuantity.Id, 'txtRejectQuantity') });
                txtGoodQuantity.blur(function () { CalculateTotalQuantity(txtGoodQuantity.Id, 'txtGoodQuantity') });

                BindRejectReason(ddlRejectReasonId, rejectReasonList, 'Reject');
            });
        }
    }, ErrorFunction, false);
    return false;
}

function BindRejectReason(ddl, list, caption) {
    BindDropDownList(ddl.Id, list, 'CodeId', 'CodeDescription', '', caption + ' Reason')
    ddl.val('');
}

function CalculateTotalQuantity(objId, callerId) {
    var txtInspectionQuantity = $('#' + objId.replace(callerId, 'txtInspectionQuantity'));
    var txtRejectQuantity = $('#' + objId.replace(callerId, 'txtRejectQuantity'));
    var txtRepackingQuantity = $('#' + objId.replace(callerId, 'txtRepackingQuantity'));
    var txtGoodQuantity = $('#' + objId.replace(callerId, 'txtGoodQuantity'));
    var ddlRejectReasonId = $('#' + objId.replace(callerId, 'ddlRejectReasonId'));

    var inspectionQuantity = parseFloat(txtInspectionQuantity.val());
    var goodQuantity = parseFloat(txtGoodQuantity.val());
    var rejectQuantity = parseFloat(txtRejectQuantity.val());
    var repackingQuantity = parseFloat(txtRepackingQuantity.val());

    var totalQuantity = parseFloat(txtGoodQuantity.val()) + rejectQuantity + repackingQuantity;
    if (totalQuantity > inspectionQuantity)
        $('#' + objId).val(0);
    else {
        if (objId.indexOf('txtRepackingQuantity') == -1 && objId.indexOf('txtRejectQuantity') == -1)
            txtRepackingQuantity.val(inspectionQuantity - rejectQuantity - goodQuantity);
        else if (objId.indexOf('txtGoodQuantity') == -1 && objId.indexOf('txtRejectQuantity') == -1)
            txtRejectQuantity.val(inspectionQuantity - repackingQuantity - goodQuantity);
        else if (objId.indexOf('txtRepackingQuantity') == -1 && objId.indexOf('txtGoodQuantity') == -1)
            txtGoodQuantity.val(inspectionQuantity - rejectQuantity - repackingQuantity);
    }
    rejectQuantity = parseFloat(txtRejectQuantity.val());
    if (rejectQuantity == 0)
        ddlRejectReasonId.val('').disable();
    else
        ddlRejectReasonId.enable();
}

function SelectGrn() {
    selectedGrnList = []
    $('[id*="chkGrnId"]').each(function () {
        var chkGrnId = $(this);
        if (chkGrnId.IsChecked) {
            selectedGrnList.push($('#' + chkGrnId.Id.replace('chkGrnId', 'hdnGrnId')).val());
        }
    });
}

function ValidateOnSubmit() {
    if (selectedGrnList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one GRN');
        return false;
    }
}