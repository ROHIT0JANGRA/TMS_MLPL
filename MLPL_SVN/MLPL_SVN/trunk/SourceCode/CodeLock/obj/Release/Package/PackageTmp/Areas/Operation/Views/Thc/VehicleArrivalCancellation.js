var docketNomenclature, drThcDate, txtThcNo, txtCancelReason, txtManualThcNo, dtThcDetails, selectedThcList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;

$(document).ready(function () {
    SetPageLoad('Thc', 'Vehicle Arrival Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtThcNo = $('#txtThcNo');
    txtManualThcNo = $('#txtManualThcNo');
    drThcDate = InitDateRange('drThcDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetThcList },
        { StepName: 'Thc List', StepFunction: CheckStepValid }
    ], 'Thc Cancel');
}

function GetThcList() {
    var requestData = {
        thcNo: txtThcNo.val(), manualThcNo: txtManualThcNo.val(), fromDate: drThcDate.startDate, toDate: drThcDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetThcListForVehicleArrivalCancellation', JSON.stringify(requestData), function (result) {

        selectedThcList = [];

        if (dtThcDetails == null)
            dtThcDetails = LoadDataTable('dtThcDetails', false, false, false, null, null, [],
                [
                    { title: SelectAll.GetChkAll('chkAllThc', SelectThc), data: "ThcId" },
                    { title: 'Thc No', data: 'ThcNo' },
                    { title: 'Manual Thc No', data: 'ManualThcNo' },
                    { title: 'Thc Date', data: 'ThcDate' },
                    { title: 'Origin', data: 'LocationCode' },
                    { title: 'Destination', data: 'ToLocationCode' },
                    { title: 'Total Manifest', data: 'TotalManifest' },
                    { title: "Cancel Reason", data: 'CancelReason' },
                    { title: "Cancel Date", data: 'CancelDate' }
                ]);

        dtThcDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.ThcId = SelectAll.GetChk('chkAllThc', 'chkThc' + i, 'Details[' + i + '].IsChecked', SelectThc) +
                    "<input type='hidden' value='" + item.ThcId + "' name='Details[" + i + "].ThcId' id='hdnThcbId" + i + "'/>" +
                    "<input type='hidden' value='" + item.FromLocationId + "' name='Details[" + i + "].FromLocationId' id='hdnFromLocationId" + i + "'/>" +
                    "<input type='hidden' value='" + item.ToLocationId + "' name='Details[" + i + "].ToLocationId' id='hdnToLocationId" + i + "'/>" +
                    "<label class='label' for='chkThc" + i + "' id='lblThcId" + i + "'></label>";
                item.ThcDate = $.displayDate(item.ThcDate);
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                    '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                    "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                    '</div>' +
                    '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

            });
            dtThcDetails.dtAddData(result);
            $('[id*="txtCancelDate"]').each(function () {
                var txtCancelDate = $(this);

                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            $('[id*="chkThc"]').change(function () {
                var chkThc = $(this);
                var txtReason = $('#' + chkThc.Id.replace('chkThc', 'txtCancelReason'));
                var txtCancelDate = $('#' + chkThc.Id.replace('chkThc', 'txtCancelDate'));
                txtReason.enable(chkThc.IsChecked).val('');
                txtCancelDate.enable(chkThc.IsChecked).val('');
                if (chkThc.IsChecked) {
                    AddRequired(txtReason, 'Enter Cancel Reason');
                    txtReason.val(txtCancelReason.val());
                    AddRequired(txtCancelDate, 'Enter Cancel Reason');
                    txtCancelDate.val(txtCancelReason.val());
                }
                else
                    RemoveRequired(txtReason);
                RemoveRequired(txtCancelDate);
            });
            txtCancelReason.blur(OnCancelReasonChange);
        }
    }, ErrorFunction, false);
    return false;
}

function OnCancelReasonChange() {
    $('[id*="chkThc"]').each(function () {
        var chkThc = $(this);
        var txtReason = $('#' + chkThc.Id.replace('chkThc', 'txtCancelReason'));
        if (chkThc.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
}

function SelectThc() {
    selectedThcList = []
    $('[id*="chkThc"]').each(function () {
        var chkThc = $(this);
        if (chkThc.IsChecked) {
            selectedThcList.push($('#' + chkThc.Id.replace('chkThc', 'hdnThcId')).val());
        }
    });
}

function CheckStepValid() {
    if (selectedThcList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Thc');
        return false;
    }
}