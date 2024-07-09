var docketNomenclature, drManifestDate, txtManifestNo, txtCancelReason, txtManualManifestNo, dtManifestDetails, selectedManifestList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;
$(document).ready(function () {
    SetPageLoad('Manifest', 'Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtManifestNo = $('#txtManifestNo');
    txtManualManifestNo = $('#txtManualManifestNo');
    drManifestDate = InitDateRange('drManifestDate', DateRange.LastWeek);
    dtManifestDetails = $('#dtManifestDetails');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
      { StepName: 'Criteria', StepFunction: GetManifestList },
      { StepName: 'Manifest List', StepFunction: CheckStepValid }
    ], 'Manifest Cancel');
}

function GetManifestList() {
    var requestData = {
        manifestNos: txtManifestNo.val(), manualManifestNos: txtManualManifestNo.val(), fromDate: drManifestDate.startDate, toDate: drManifestDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetManifestListForCancellation', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedManifestList = [];

            dtManifestDetails = LoadDataTable('dtManifestDetails', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllManifest', SelectManifest), data: "ManifestId" },
                    { title: 'Manifest No', data: 'ManifestNo' },
                    { title: 'Manual Manifest No', data: 'ManualManifestNo' },
                    { title: 'Manifest Date', data: 'ManifestDate' },
                    { title: 'Origin', data: 'LocationCode' },
                    { title: 'Destination', data: 'NextLocationCode' },
                    { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                    { title: "Cancel Reason", data: 'CancelReason' },
                    { title: "Cancel Date", data: 'CancelDate' }
                ]);

            dtManifestDetails.fnClearTable();
            $.each(result, function (i, item) {
                item.ManifestId = SelectAll.GetChk('chkAllManifest', 'chkManifest' + i, 'Details[' + i + '].IsChecked', SelectManifest) +
                               "<input type='hidden' value='" + item.ManifestId + "' name='Details[" + i + "].ManifestId' id='hdnManifestbId" + i + "'/>" +
                               "<label class='label' for='chkManifest" + i + "' id='lblManifestId" + i + "'></label>";
                item.ManifestDate = $.displayDate(item.ManifestDate);
                item.CancelReason = '<div class=\'input\'><input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/></div>' +
                    '<div><span class="field-validation-valid" data-valmsg-for="Details[' + i + '].CancelReason" data-valmsg-replace="true"></span></div>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';
            });
            dtManifestDetails.dtAddData(result);

            $("[id*='chkManifest']").each(function () {
                var tr = $(this).closest('tr');
                var txtCancelDate = tr.find('[id*="txtCancelDate"]');
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });


            $('[id*="chkManifest"]').change(function () {
                var chkManifest = $(this);
                var txtReason = $('#' + chkManifest.Id.replace('chkManifest', 'txtCancelReason'));
                 var txtCancelDate = $('#' + chkManifest.Id.replace('chkManifest', 'txtCancelDate'));
                txtReason.enable(chkManifest.IsChecked).val('');
                 txtCancelDate.enable(chkManifest.IsChecked).val('');
                if (chkManifest.IsChecked) {
                    AddRequired(txtReason, 'Enter Cancel Reason');
                    AddRequired(txtCancelDate, 'Enter Cancel Reason');
                }
                else {
                    RemoveRequired(txtReason);
                    RemoveRequired(txtCancelDate);
                }
            });



        }
    }, ErrorFunction, false);
    return false;
}

function OnCancelReasonChange() {
    $('[id*="chkManifest"]').each(function () {
        var chkManifest = $(this);
        var txtReason = $('#' + chkManifest.Id.replace('chkManifest', 'txtCancelReason'));
        if (chkManifest.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}

function SelectManifest() {
    selectedManifestList = []
    $('[id*="chkManifest"]').each(function () {
        var chkManifest = $(this);
        if (chkManifest.IsChecked) {
            selectedManifestList.push($('#' + chkManifest.Id.replace('chkManifest', 'hdnManifestId')).val());
        }
    });
}

function CheckStepValid() {
    if (selectedManifestList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Manifest');
        return false;
    }
}