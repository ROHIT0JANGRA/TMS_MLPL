var drJobOrderDate, txtJobOrderNo, ddlJobCardTypeId, dtJobOrderDetails, baseUrl;

$(document).ready(function () {
    SetPageLoad('Job Order', 'Update', '', '', '');
    InitObjects();
});

function InitObjects() {
    drJobOrderDate = InitDateRange('drJobOrderDate', DateRange.LastWeek);
    txtJobOrderNo = $('#txtJobOrderNo');
    ddlJobCardTypeId = $('#ddlJobCardTypeId');

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetJobOrderList },
     { StepName: 'Job Order List' }
    ], '');
}

function GetJobOrderList() {
    var requestData = { fromDate: drJobOrderDate.startDate, toDate: drJobOrderDate.endDate, jobOrderNo: txtJobOrderNo.val(), jobCardType: ddlJobCardTypeId.val() == '' ? 0 : ddlJobCardTypeId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetJobOrderListForUpdate', JSON.stringify(requestData), function (result) {

        if (dtJobOrderDetails == null)
            dtJobOrderDetails = LoadDataTable('dtJobOrderDetails', false, false, false, null, null, [],
                  [
                      { title: 'Job Order No.', data: 'JobOrderNo' },
                      { title: 'Job Order Date', data: 'JobOrderDate' },
                      { title: 'Vehicle No', data: 'VehicleNo' },
                      { title: 'Job Card Type', data: 'CardType' },
                      { title: 'Service Type', data: 'ServiceType' },
                      { title: 'Closure', data: 'Closure' },
                      { title: 'Edit', data: 'Edit' }
                  ]);

        dtJobOrderDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.JobOrderNo = "<input type='hidden' value='" + item.JobOrderId + "' id='hdnJobOrderId" + i + "'/>" +
                                  "<input type='hidden' value='" + item.IsApprove + "' id='hdnIsApprove" + i + "'/>" +
                                  item.JobOrderNo;
                item.JobOrderDate = $.displayDate(item.JobOrderDate);
                item.Closure = "<a href='#' id='lnkClosure" + i + "' onclick='return Update(" + item.JobOrderId + "," + false + ");'>Close</a>";
                item.Edit = "<a href='#' id='lnkUpdation" + i + "' onclick='return Update(" + item.JobOrderId + "," + true + ");'>Edit</a>";
            });
            dtJobOrderDetails.dtAddData(result);
            Init();
        }
    }, ErrorFunction, false);
    return false;
}

function Init() {
    $('[id*="hdnIsApprove"]').each(function () {
        var hdnIsApprove = $(this);
        var lnkClosure = $('#' + this.id.replace('hdnIsApprove', 'lnkClosure'));
        var lnkUpdation = $('#' + this.id.replace('hdnIsApprove', 'lnkUpdation'));
        if (hdnIsApprove.val() == "true")
            lnkUpdation.hide();
        if (hdnIsApprove.val() == "null")
            lnkClosure.hide();
    });
}

function Update(jobOrderId, isUpdate) {
    if (isUpdate) {
        window.location.href = baseUrl + '/Insert/' + jobOrderId;
        return false;
    }
    else if (!isUpdate) {
        window.location.href = baseUrl + '/Close/' + jobOrderId;
        return false;
    }
}