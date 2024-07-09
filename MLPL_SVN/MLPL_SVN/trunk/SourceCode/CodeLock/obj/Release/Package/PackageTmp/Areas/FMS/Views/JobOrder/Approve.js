var drJobOrderDate, txtJobOrderNo, ddlJobCardType, dtJobOrderDetails, baseUrl, selectedJobOrderList;

$(document).ready(function () {
    SetPageLoad('Job Order', 'Approval', '', '', '');
    InitObjects();
});

function InitObjects() {
    drJobOrderDate = InitDateRange('drJobOrderDate', DateRange.LastWeek);
    txtJobOrderNo = $('#txtJobOrderNo');
    ddlJobCardType = $('#ddlJobCardType');
    $('#ddlJobCardType option').eq(0).before($('<option>', { value: 0, text: 'Select' }));
    ddlJobCardType.val(0);

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetJobOrderList },
     { StepName: 'Job Order List', StepFunction: ValidStep2 }
    ], 'Approve');
}

function GetJobOrderList() {
    var requestData = { fromDate: drJobOrderDate.startDate, toDate: drJobOrderDate.endDate, jobOrderNo: txtJobOrderNo.val(), jobCardType: ddlJobCardType.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetJobOrderListForApprove', JSON.stringify(requestData), function (result) {
        selectedJobOrderList = [];
        if (dtJobOrderDetails == null)
            dtJobOrderDetails = LoadDataTable('dtJobOrderDetails', false, false, false, null, null, [],
                  [
                      { title: 'Job Order No', data: 'JobOrderNo' },
                      { title: 'Job Order date', data: 'JobOrderDate' },
                      { title: 'Vehicle No', data: 'VehicleNo' },
                      { title: 'Job Card Type', data: 'CardType' },
                      { title: 'Service Type', data: 'ServiceType' },
                      { title: 'Amount', data: 'TotalEstimatedCost' },
                      { title: 'Approve', data: 'Approve' },
                      { title: 'Reject', data: 'Reject' },
                      { title: 'Remarks', data: 'Remarks' }
                  ]);

        dtJobOrderDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.JobOrderDate = $.displayDate(item.JobOrderDate);
                item.TotalEstimatedCost = '<input class="form-control textlabel numeric2"  id="txtTotalEstimatedCost' + i + '" type="text"  value=\'' + item.TotalEstimatedCost.toFixed(2) + '\'/>';
                item.Approve = '<label class="checkbox"><input type="checkbox" id="chkIsApprove' + i + '" name="Details[' + i + '].IsApprove" onclick="OnApproveChange(this)" value="true" /> ' +
                               '<input type="hidden" name="Details[' + i + '].JobOrderId" id="hdnJobOrderId' + i + '" value = ' + item.JobOrderId + ' />' + '<i></i> </label> ';
                item.Reject = '<label class="checkbox"><input type="checkbox" id="chkIsReject' + i + '" name="Details[' + i + '].IsReject" onclick="OnRejectChange(this)" value="true" /> ' +
                              '<input type="hidden" value = ' + item.JobOrderId + ' />' + '<i></i> </label> ';
                item.Remarks = '<input class="form-control" name="Details[' + i + '].Remarks" id="txtRemarks' + i + '" type="text"/>';
            });
            dtJobOrderDetails.dtAddData(result);
        }
    }, ErrorFunction, false);
    return false;
}

function OnApproveChange(obj) {
    var chkIsApprove = $('#' + obj.Id);
    var chkIsReject = $('#' + obj.id.replace('chkIsApprove', 'chkIsReject'));
    chkIsReject.uncheck(chkIsApprove.IsChecked)
}

function OnRejectChange(obj) {
    var chkIsReject = $('#' + obj.Id);
    var chkIsApprove = $('#' + obj.id.replace('chkIsReject', 'chkIsApprove'));
    chkIsApprove.uncheck(chkIsReject.IsChecked)
}

function ValidStep2() {
    selectedJobOrderList = [];
    $('[id*="chkIsApprove"]').each(function () {
        var chkIsApprove = $(this);
        var chkIsReject = $('#' + this.id.replace('chkIsApprove', 'chkIsReject'));
        var hdnJobOrderId = $('#' + this.id.replace('chkIsApprove', 'hdnJobOrderId'));
        if (chkIsApprove.IsChecked || chkIsReject.IsChecked) {
            selectedJobOrderList.push($('#' + chkIsApprove.Id.replace('chkIsApprove', 'hdnJobOrderId')).val());
        }
    });
    if (selectedJobOrderList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Job Order');
        return false;
    }
}
