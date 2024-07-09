var docketNomenclature, drLoadingSheetDate, txtCancelReason, txtLoadingSheetNo, txtManualLoadingSheetNo, dtLoadingSheetDetails, selectedLoadingSheetList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;
$(document).ready(function () {
    SetPageLoad('Loading Sheet', 'Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtLoadingSheetNo = $('#txtLoadingSheetNo');
    txtManualLoadingSheetNo = $('#txtManualLoadingSheetNo');
    drLoadingSheetDate = InitDateRange('drLoadingSheetDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
    { StepName: 'Criteria', StepFunction: GetLoadingSheetList },
    { StepName: 'Loading Sheet List', StepFunction: CheckStepValid }
    ], 'Loading Sheet Cancel');
}

function GetLoadingSheetList() {
    var requestData = {
        loadingSheetNo: txtLoadingSheetNo.val(), manualLoadingSheetNo: txtManualLoadingSheetNo.val(), fromDate: drLoadingSheetDate.startDate, toDate: drLoadingSheetDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetLoadingSheetListForCancellation', JSON.stringify(requestData), function (result) {

        selectedLoadingSheetList = [];

        if (dtLoadingSheetDetails == null)
            dtLoadingSheetDetails = LoadDataTable('dtLoadingSheetDetails', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllLoadingSheet', SelectLoadingSheet), data: "LoadingSheetId" },
                  { title: 'LS No', data: 'LoadingSheetNo' },
                  { title: 'Manual LS No', data: 'ManualLoadingSheetNo' },
                  { title: 'LS Date', data: 'LoadingSheetDate' },
                  { title: 'Origin', data: 'LocationCode' },
                  { title: 'Destination', data: 'NextLocationCode' },
                  { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                  { title: "Cancel Reason", data: 'CancelReason' },
                  { title: "Cancel Date", data: 'CancelDate' }
              ]);

        dtLoadingSheetDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.LoadingSheetId = "<div class='checkboxer'>" +
                                SelectAll.GetChk('chkAllLoadingSheet', 'chkLoadingSheet' + i, 'Details[' + i + '].IsChecked', SelectLoadingSheet) +
                                "<input type='hidden' value='" + item.LoadingSheetId + "' name='Details[" + i + "].LoadingSheetId' id='hdnLoadingSheetbId" + i + "'/>" +
                                "<label class='label' for='chkLoadingSheet" + i + "' id='lblLoadingSheetId" + i + "'></label>" +
                                "</div>";
                item.LoadingSheetDate = $.displayDate(item.LoadingSheetDate);
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';
            });
            dtLoadingSheetDetails.dtAddData(result);
            $('[id*="txtCancelDate"]').each(function () {
                var txtCancelDate = $(this);
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            $('[id*="chkLoadingSheet"]').change(function () {
                var chkLoadingSheet = $(this);
                var txtReason = $('#' + chkLoadingSheet.Id.replace('chkLoadingSheet', 'txtCancelReason'));
                var txtCancelDate = $('#' + chkLoadingSheet.Id.replace('chkLoadingSheet', 'txtCancelDate'));
                txtReason.enable(chkLoadingSheet.IsChecked).val('');
                txtCancelDate.enable(chkLoadingSheet.IsChecked).val('');
                if (chkLoadingSheet.IsChecked) {
                    AddRequired(txtReason, 'Enter Cancel Reason');
                    txtReason.val(txtCancelReason.val());
                    AddRequired(txtCancelDate, 'Enter Cancel Reason');
                    txtCancelDate.val(txtCancelReason.val());
                }
                else {
                    RemoveRequired(txtReason);
                    RemoveRequired(txtCancelDate);
                }
            });
            txtCancelReason.blur(OnCancelReasonChange);
        }
    }, ErrorFunction, false);
    return false;
}

function OnCancelReasonChange() {
    $('[id*="chkLoadingSheet"]').each(function () {
        var chkLoadingSheet = $(this);
        var txtReason = $('#' + chkLoadingSheet.Id.replace('chkLoadingSheet', 'txtCancelReason'));
        if (chkLoadingSheet.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}

function SelectLoadingSheet() {
    selectedLoadingSheetList = []
    $('[id*="chkLoadingSheet"]').each(function () {
        var chkLoadingSheet = $(this);
        if (chkLoadingSheet.IsChecked) {
            selectedLoadingSheetList.push($('#' + chkLoadingSheet.Id.replace('chkLoadingSheet', 'hdnLoadingSheetId')).val());
        }
    });
}

function CheckStepValid() {
    if (selectedLoadingSheetList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one LoadingSheet');
        return false;
    }
}