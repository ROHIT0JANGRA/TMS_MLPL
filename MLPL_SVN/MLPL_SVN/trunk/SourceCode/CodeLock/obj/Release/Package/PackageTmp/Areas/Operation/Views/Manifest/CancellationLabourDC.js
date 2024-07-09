var docketNomenclature, drManifestDate, txtManifestNo, txtCancelReason, txtManualManifestNo, dtManifestDetails, selectedManifestList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;
$(document).ready(function () {
    SetPageLoad('LabourDC', 'Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtLabourDCNo = $('#txtLabourDCNo');
    drManifestDate = InitDateRange('drManifestDate', DateRange.LastWeek);
    dtManifestDetails = $('#dtManifestDetails');

    InitWizard('dvWizard', [
      { StepName: 'Criteria', StepFunction: GetManifestList },
      { StepName: 'Manifest List', StepFunction: CheckStepValid }
    ], 'Cancel LabourDC');
}

function GetManifestList() {
    var requestData = {
        LabourDCNo: txtLabourDCNo.val(), fromDate: drManifestDate.startDate, toDate: drManifestDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetLabourDCListForCancellation', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedManifestList = [];

            dtManifestDetails = LoadDataTable('dtManifestDetails', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllManifest', SelectManifest), data: "LabourDCId" },
                    { title: 'LabourDC No', data: 'LabourDCNo' },
                    { title: 'LabourDC Date', data: 'LabourDCDate' },
                    { title: 'Vendor Code', data: 'VendorCode' },
                    { title: 'Vendor Name', data: 'VendorName' },
                    { title: 'Docket', data: 'TotalManifest' },
                    { title: 'Packages', data: 'TotalPackages' },
                    { title: 'Actual Weight', data: 'TotalActualWeight' },
                    { title: 'Amount', data: 'TotalAmount' },
                    { title: "Cancel Reason", data: 'CancelReason' },
                    { title: "Cancel Date", data: 'CancelDate' }
                ]);

            dtManifestDetails.fnClearTable();
            $.each(result, function (i, item) {
                item.LabourDCId = SelectAll.GetChk('chkAllManifest', 'chkManifest' + i, 'Details[' + i + '].IsLabourDCChecked', SelectManifest) +
                               "<input type='hidden' value='" + item.LabourDCId + "' name='Details[" + i + "].LabourDCId' id='hdnLabourDCId" + i + "'/>" +
                               "<label class='label' for='chkManifest" + i + "' id='lblLabourDCId" + i + "'></label>";
                item.LabourDCDate = $.displayDate(item.LabourDCDate);
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
        ShowMessage('Please select at least one LabourDC');
        return false;
    }
}