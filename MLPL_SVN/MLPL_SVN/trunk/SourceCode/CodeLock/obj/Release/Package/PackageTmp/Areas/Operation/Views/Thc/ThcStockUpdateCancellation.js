var docketNomenclature, drThcDate, txtThcNo, txtCancelReason, txtManualDrsNo, dtThcStockUpdateDetails, selectedThcStockUpdateList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;
$(document).ready(function () {
    SetPageLoad('THC', 'StockUpdate Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtThcNo = $('#txtThcNo');
    txtManualThcNo = $('#txtManualThcNo');
    drThcDate = InitDateRange('drThcDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetThcStockUpdateList },
        { StepName: 'Thc StockUpdate List', StepFunction: CheckValidStep2 },
        { StepName: 'Thc StockUpdate Detail' }
    ], 'Thc StockUpdate Cancel');
}

function GetThcStockUpdateList() {
    var requestData = {
        thcNo: txtThcNo.val(), fromDate: drThcDate.startDate, toDate: drThcDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetThcListForStockUpdateCancellation', JSON.stringify(requestData), function (result) {

        selectedThcStockUpdateList = 0;

        if (dtThcStockUpdateDetails == null)
            dtThcStockUpdateDetails = LoadDataTable('dtThcStockUpdateDetails', false, false, false, null, null, [],
                [

                    { title: 'Thc No', data: 'ThcNo' },
                    { title: 'Thc Date', data: 'ThcDate' },
                    { title: 'Close Date', data: 'StockUpdateDate' },
                    { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },

                ]);

        dtThcStockUpdateDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.ThcNo = '<div class="clearfix">' +
                    '<label class="radio">' +
                    '<input type="radio" name=\'Thc\' value=\'' + item.ThcId + '\' onclick="SelectThc(this)" tabindex="0" id="chkThcNo' + i + '"/><i></i>' +
                    "<input type='hidden' value='" + item.ThcId + "' name='Details[" + i + "].ThcId' id='hdnThcId" + i + "'/>" +
                    '<label for="chkThcNo' + i + '">' + item.ThcNo
                '</div>';
                item.ThcDate = $.displayDate(item.ThcDate);
                item.StockUpdateDate = $.displayDate(item.StockUpdateDate);

            });
            dtThcStockUpdateDetails.dtAddData(result);
        }
    }, ErrorFunction, false);
    return false;
}
function SelectThc(rd) {
    selectedThcStockUpdateList = rd.value;
    $('#hdnThcId').val(selectedThcStockUpdateList);
}

function CheckValidStep2() {
    if (selectedThcStockUpdateList === 0) {
        isStepValid = false;
        ShowMessage('Please select Thc Stock Update');
        return false;
    }
}