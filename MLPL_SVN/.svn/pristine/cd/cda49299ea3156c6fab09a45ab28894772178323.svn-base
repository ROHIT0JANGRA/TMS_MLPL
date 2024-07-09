var drTHCDate, txtTHCNo, txtVehicleNo, ddlArrivalLocation, dtThcDetails, thcUrl, selectedThcId, dvLateArrivalReason, ddlLateArrivalReason, txtActualArrivalDate, lblExpectedArrivalDate;

$(document).ready(function () {
    SetPageLoad('THC', 'Vehicle Arrival', '', '', '');
    InitObjects();
});

function InitObjects() {
    drTHCDate = InitDateRange('drTHCDate', DateRange.LastWeek);
    txtTHCNo = $('#txtTHCNo');
    txtVehicleNo = $('#txtVehicleNo');
    ddlArrivalLocation = $('#ddlArrivalLocation');
    txtDocketNo = $('#txtDocketNo');
    dtThcDetails = LoadDataTable('dtThcDetails', false, false, false, null, null, [],
              [
                  { title: 'THC No', data: 'ThcNo' },
                  { title: 'THC Date', data: 'ThcDateTime' },
                  { title: 'Previous Branch', data: 'FromLocationCode' },
                  { title: 'Route', data: 'RouteName' },
                  { title: 'Vehicle No', data: 'VehicleNo' },
                  { title: 'Departure Date Time', data: 'ActualDepartureDate' },
                  { title: 'Expected Arrival Date Time', data: 'ExpectedArrivalDate' }
              ]);
    ddlLateArrivalReason = $('#ddlLateArrivalReason');
    txtActualArrivalDate = $('#txtActualArrivalDate');
    lblExpectedArrivalDate = $('#lblExpectedArrivalDate');
    dvLateArrivalReason = $('#dvLateArrivalReason');
    txtActualArrivalDate.blur(ShowHideLateArrival);

    InitWizard('dvWizard',[
    { StepName: 'Criteria', StepFunction: GetThcList },
    { StepName: 'THC Details', StepFunction: LoadStep3 },
    { StepName: 'Basic Details', StepFunction: ValidateOnSubmit }
    ], 'Vehicle Arrival');

    $('#txtIncomingSealNo').blur(ValidateSealNo);
}

function GetThcList() {

    var thcNo = txtTHCNo.val();
    var vehicleNo = txtVehicleNo.val();
    var arrivalLocation = ddlArrivalLocation.val();
    var docketNo = txtDocketNo.val();
    var requestData = { thcNos: thcNo, fromDate: drTHCDate.startDate, toDate: drTHCDate.endDate, vehicleNos: vehicleNo, arrivalLocations: arrivalLocation, docketNos: docketNo};

    AjaxRequestWithPostAndJson(thcUrl + '/GetThcListForVehicleArrival', JSON.stringify(requestData), function (result) {
        if (result.length === 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            dtThcDetails.fnClearTable();
            $.each(result, function (i, item) {
                item.ThcNo = '<div class="clearfix">' +
                                   '<label class="radio">' +
                                       '<input type="radio" name=\'Thc\' value=\'' + item.ThcId + '\' onclick="GetThcDetail(this)" tabindex="0" id="chkThcNo' + i + '"/><i></i>' +
                                         '<label id="lblThcNo' + i + '" for="chkThcNo' + i + '">' + item.ThcNo + '</label>' +
                                   '</label>' +
                                   "<input type='hidden' value='" + item.ThcSummary.StartKm + "' id='hdnStartKm" + i + "'/>" +
                                   "<input type='hidden' value='" + item.ThcSummary.OutgoingSealNo + "' id='hdnOutgoingSealNo" + i + "'/>" +
                                   "<input type='hidden' value='" + item.ActualDepartureDate + "'  id='hdnActualDepartureDate" + i + "'/>" +
                                   "<input type='hidden' value='" + item.ThcSummary.TotalActualWeight + "'  id='hdnTotalActualWeight" + i + "'/>" +
                                   "<input type='hidden' value='" + item.ThcSummary.TotalDocket + "'  id='hdnTotalDocket" + i + "'/>" +
                                   "<input type='hidden' value='" + item.ThcSummary.TotalPackages + "'  id='hdnTotalPackages" + i + "'/>" +
                               '</div>';
                item.ThcDateTime = $.displayDate(item.ThcDateTime);
                item.ActualDepartureDate = $.displayDateTime(item.ActualDepartureDate);
                item.ExpectedArrivalDate = $.displayDateTime(item.ExpectedArrivalDate);

            });
            dtThcDetails.dtAddData(result);
            selectedThcId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

var thcInfo = {};
function GetThcDetail(rd) {
    selectedThcId = rd.value;
    var tr = $(rd).closest('tr');
    thcInfo.ThcId = selectedThcId;
    thcInfo.ThcNo = tr.find('[id*="lblThcNo"]').text().trim();
    thcInfo.OutgoingSealNo = tr.find('[id*="hdnOutgoingSealNo"]').val().trim();
    thcInfo.StartKm = tr.find('[id*="hdnStartKm"]').val().trim();
    thcInfo.ThcDate = tr.cellData(1);
    thcInfo.Location = tr.cellData(2);
    thcInfo.VehicleNo = tr.cellData(4);
    thcInfo.ADD = tr.cellData(5);
    thcInfo.EAD = tr.cellData(6);
    thcInfo.TotalActualWeight = tr.find('[id*="hdnTotalActualWeight"]').val().trim();
    thcInfo.TotalDocket = tr.find('[id*="hdnTotalDocket"]').val().trim();
    thcInfo.TotalPackages = tr.find('[id*="hdnTotalPackages"]').val().trim();
}

function LoadStep3() {
    isStepValid = selectedThcId !== 0;
    if (selectedThcId === 0) {
        ShowMessage('Please select THC');
        return false;
    }
    $('#lblThcDate').text(thcInfo.ThcDate);
    $('#lblThcNo').text(thcInfo.ThcNo);
    $('#hdnTHCId').val(thcInfo.ThcId);
    $('#lblVehicleNo').text(thcInfo.VehicleNo);
    $('#lblDepartedLocationCode').text(thcInfo.Location);
    $('#lblActualDepartedDate').text(thcInfo.ADD);
    $('#lblExpectedArrivalDate').text(thcInfo.EAD);
    $('#lblStartKM').text(thcInfo.StartKm);
    $('#hdnStartKm').val(thcInfo.StartKm);
    $('#hdnOutgoingSealNo').val(thcInfo.OutgoingSealNo);
    $('#lblTotalActualWeight').text(thcInfo.TotalActualWeight);
    $('#lblTotalDocket').text(thcInfo.TotalDocket);
    $('#lblTotalPackages').text(thcInfo.TotalPackages);
}

function ValidateSealNo() {
    var txtIncomingSealNo = $('#txtIncomingSealNo');
    if (txtIncomingSealNo.val() !== '') {
        var outgoingSealNo = $('#hdnOutgoingSealNo').val();
        var txtIncomingSealReason = $('#txtIncomingSealReason');

        if (txtIncomingSealNo.val() !== outgoingSealNo) {

            ShowConfirm('Incoming Seal No is not matching. Are you want to Continue?',
                function () {
                    $('#dvIncomingSealReason').showHide(true);
                    txtIncomingSealReason.val('');
                    txtIncomingSealReason.focus();
                },
                function () {
                    $('#dvIncomingSealReason').showHide(false);
                    txtIncomingSealNo.val('');
                    txtIncomingSealReason.val('');
                    txtIncomingSealNo.focus();
                });
        }
        else
            $('#dvIncomingSealReason').showHide(false);
    }
}

function ShowHideLateArrival() {
    var isLateArrival = false;
    if (txtActualArrivalDate.val() !== '')
        isLateArrival = $.displayDateToDate(lblExpectedArrivalDate.text()) < txtActualArrivalDate.toDate();

    dvLateArrivalReason.showHide(isLateArrival);

    if (isLateArrival)
        AddRequired(ddlLateArrivalReason, 'Please select Late Arrival Reason');
    else
        RemoveRequired(ddlLateArrivalReason);

    ddlLateArrivalReason.enable(isLateArrival);
    ddlLateArrivalReason.val('');
}

function ValidateOnSubmit() {
    if (!ValidateModuleDateWithPreviousDocumentDate('dtThcDetails', 'chkThcNo', 'hdnActualDepartureDate', 'txtActualArrivalDate', 'Actual Arrival Date')) return false;
}