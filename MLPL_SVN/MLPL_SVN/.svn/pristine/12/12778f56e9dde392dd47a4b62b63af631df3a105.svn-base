var txtGrnNos, txtRepackingNos, drDate, rejectReasonList, dtRepackingList;
$(document).ready(function () {
    SetPageLoad('Repacking', 'Insert', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtGrnNos = $('#txtGrnNos');
    txtRepackingNos = $('#txtRepackingNos');

    drGrnDate = InitDateRange('drGrnDate', DateRange.LastWeek);
    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetRepackingList },
     { StepName: 'Repacking Details', StepFunction: ValidateOnSubmit }
    ], 'Submit');

    AjaxRequestWithPostAndJson(RepackingUrl + '/GetRejectReasonList', JSON.stringify([]), function (result) {
        rejectReasonList = result.Reject;
    }, ErrorFunction, false);

}

function GetRepackingList() {
    var requestData = { warehouseId: warehouseId, companyId: companyId, fromDate: drGrnDate.startDate, toDate: drGrnDate.endDate, RepackingNos: txtRepackingNos.val() != '' ? txtRepackingNos.val() : '', grnNos: txtGrnNos.val() != '' ? txtGrnNos.val() : '' };

    AjaxRequestWithPostAndJson(RepackingUrl + '/GetRepackingList', JSON.stringify(requestData), function (result) {

        dtRepackingList = LoadDataTable('dtRepackingList', false, false, false, null, null, [],
                  [
                      { title: SelectAll.GetChkAll('chkAllGrn', null), data: "GrnId" },
                      { title: 'GRN No', data: 'GrnNo' },
                      { title: 'Product Name', data: 'ProductName' },
                      { title: 'GRN Quantity', data: 'GrnQuantity' },
                      { title: 'Repacking Quantity', data: 'RepackingQuantity' },
                      { title: 'Approve Quantity', data: 'ApproveQuantity' },
                      { title: 'Rejected Quantity', data: 'RejectedQuantity' },
                      { title: 'Reject Reason', data: 'RejectReason' },
                      { title: 'Remarks', data: 'Remarks' }
                  ]);
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedDocumentList = [];
            dtRepackingList.fnClearTable();
            $.each(result, function (i, item) {
                item.GrnId = "<div class='checkboxer'>" +
                                    SelectAll.GetChk('chkAllGrn', 'chkGrnId' + i, 'Details[' + i + '].IsChecked', null) +
                                    "<input type='hidden' value='" + item.GrnId + "' name='Details[" + i + "].GrnId' id='hdnGrnId" + i + "'/>" +
                                    "<label class='control-label' for='chkGrnId" + i + "' id='lblGrnId" + i + "'></label>" +
                                    "<input type='hidden' value='" + item.InspectionId + "' name='Details[" + i + "].InspectionId' id='hdnInspectionId" + i + "'/>" +
                                    "</div>";
                item.ProductName = "<label>" + item.ProductName + "</label><input type='hidden' value='" + item.ProductId + "' name='Details[" + i + "].ProductId' id='hdnProductId" + i + "'/>";
                item.GrnQuantity = '<input type="text" name="Details[' + i + '].GrnQuantity" id="txtGrnQuantity' + i + '" value=' + item.GrnQuantity + ' class="textlabel form-control"/>';

                item.ApproveQuantity = '<input type=\'text\' name="Details[' + i + '].ApproveQuantity" id="txtGoodQuantity' + i + '" value="' + item.RepackingQuantity + '"  class=" form-control numeric3"/>' +
                    '<span data-valmsg-for="Details[' + i + '].ApproveQuantity" data-valmsg-replace="true"></span>';
                item.RejectedQuantity = '<input type=\'text\' name="Details[' + i + '].RejectQuantity" id="txtRejectQuantity' + i + '" value="0.000"  class=" form-control numeric3"/>' +
                     '<span data-valmsg-for="Details[' + i + '].RejectQuantity" data-valmsg-replace="true"></span>';
                item.RejectReason = "<div class='select'>" +
                                           "<select class='form-control' name='Details[" + i + "].RejectReason' id='ddlRejectReasonId" + i + "' > " + "</select>" +
                                       "</div>" +
                                       '<span data-valmsg-for="Details[' + i + '].RejectReason" data-valmsg-replace="true"></span>';
                item.RepackingQuantity = '<input type="text" name="Details[' + i + '].RepackingQuantity" id="txtRepackingQuantity' + i + '" value=' + item.RepackingQuantity + ' class="textlabel form-control"/>' +
                    '<span data-valmsg-for="Details[' + i + '].RepackingQuantity" data-valmsg-replace="true"></span>';
                item.Remarks = '<input type=\'text\' name="Details[' + i + '].Remarks" id="txtRemarks' + i + '" class=" form-control"/>' +
                    '<span data-valmsg-for="Details[' + i + '].Remarks" value=" " data-valmsg-replace="true"></span>';

            });
            dtRepackingList.dtAddData(result);

            dtRepackingList.find('[id*="txtRemarks"]').each(function () {
                var txtRemarks = $('#' + this.id);
                var ddlRejectReasonId = $('#' + this.id.replace('txtRemarks', 'ddlRejectReasonId'));

                var txtRepackingQuantity = $('#' + this.id.replace('txtRemarks', 'txtRepackingQuantity'));
                var txtRejectQuantity = $('#' + this.id.replace('txtRemarks', 'txtRejectQuantity'));
                var txtGoodQuantity = $('#' + this.id.replace('txtRemarks', 'txtGoodQuantity'));
                var txtTotalQuantity = $('#' + this.id.replace('txtRemarks', 'txtTotalQuantity'));

                var RepackingQuantity = parseFloat(txtRepackingQuantity.val());
                var goodQuantity = RepackingQuantity - parseFloat(txtRejectQuantity.val()) - parseFloat(txtRepackingQuantity.val());
                AddRange(txtRejectQuantity, 'Rejected Quantity cannot be more than' + RepackingQuantity.toFixed(3), 0, RepackingQuantity);
                AddRange(txtGoodQuantity, 'Approved Quantity cannot be more than' + RepackingQuantity.toFixed(3), 0, RepackingQuantity);

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
    var txtRepackingQuantity = $('#' + objId.replace(callerId, 'txtRepackingQuantity'));
    var txtRejectQuantity = $('#' + objId.replace(callerId, 'txtRejectQuantity'));
    var txtGoodQuantity = $('#' + objId.replace(callerId, 'txtGoodQuantity'));
    var ddlRejectReasonId = $('#' + objId.replace(callerId, 'ddlRejectReasonId'));

    var goodQuantity = parseFloat(txtGoodQuantity.val());
    var rejectQuantity = parseFloat(txtRejectQuantity.val());
    var repackingQuantity = parseFloat(txtRepackingQuantity.val());

    var totalQuantity = parseFloat(txtGoodQuantity.val()) + rejectQuantity;
    if (parseFloat($('#' + objId).val()) > repackingQuantity)
        $('#' + objId).val(repackingQuantity);

    goodQuantity = parseFloat(txtGoodQuantity.val());
    rejectQuantity = parseFloat(txtRejectQuantity.val());

    if (objId.indexOf('txtRejectQuantity') == -1)
        txtRejectQuantity.val(repackingQuantity - goodQuantity);
    else if (objId.indexOf('txtGoodQuantity') == -1)
        txtGoodQuantity.val(repackingQuantity - rejectQuantity);

    rejectQuantity = parseFloat(txtRejectQuantity.val());
    if (rejectQuantity == 0)
        ddlRejectReasonId.val('').disable();
    else
        ddlRejectReasonId.enable();
}

function ValidateOnSubmit() {

}