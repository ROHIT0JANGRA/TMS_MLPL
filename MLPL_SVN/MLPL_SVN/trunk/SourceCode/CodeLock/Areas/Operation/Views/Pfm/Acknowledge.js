var dtPfmDetails, dtDocketDetails, docketNomenclature;
$(document).ready(function () {
    SetPageLoad('PFM', 'Generate', 'drPfmDate');

    drPfmDate = InitDateRange('drPfmDate', DateRange.LastWeek);

    dtPfmDetails = LoadDataTable('dtPfmDetails', false, false, false, null, null, [],
        [
            { title: 'PFM No', data: "PfmNo" },
            { title: 'PFM Date', data: "PfmDate" },
            { title: 'From', data: "ForwardFrom" },
            { title: 'To', data: "ForwardTo" },
            { title: 'Manual No', data: "ManualPfmNo" }
        ]);

    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [
            { title: "<div class='clearfix' style='width:80px'><div class='checkbox'>" + SelectAll.GetChkAll('chkAllDocket') + "</div></div>", data: "DocketId", width: 80 },
            { title: docketNomenclature , data: "DocketNo" },
            { title: 'Booking Date', data: "DocketDate" },
            { title: 'Origin', data: "FromLocationCode" },
            { title: 'Destination', data: "ToLocationCode" },
            { title: 'Delivery Date', data: "DeliveryDate" }
        ]);

    InitWizard('dvWizard', [{ StepName: 'Criteria', StepFunction: GetPfmList },
    { StepName: 'PFM List', StepFunction: ValidateStep2 },
    { StepName: 'PFM Details' }], 'Acknowledge PFM');
});

function GetPfmList() {
    var requestData = {
        companyId: loginCompanyId,
        locationId: loginLocationId,
        pfmList: $('#txtPfmNo').val(),
        fromDate: $.displayDate(drPfmDate.startDate),
        toDate: $.displayDate(drPfmDate.endDate)
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetPfmListForAcknowledge', JSON.stringify(requestData), function (responseData) {
        if (responseData.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        dtPfmDetails.fnClearTable();
        if (responseData.length > 0) {
            $.each(responseData, function (i, item) {
                item.PfmNo = '<div class="clearfix">' +
                    '<label class="radio">' +
                    '<input type="radio" name=\'Pfm\' value=\'' + item.PfmId + '\' onclick="GetPfmDetail(this);" tabindex="0" id="chkPfmNo' + i + '"/><i></i>' +
                    '<label id="lblPfmNo' + i + '" for="chkPfmNo' + i + '">' + item.PfmNo + '</label>' +
                    '</label>' +
                    '</div>' +
                "<input type='hidden' value='" + (item.ForwardType ? 'Location' : 'Customer') + "' id='hdnForwardType" + i + "'/>" +
                    "<input type='hidden' value='" + item.ForwardFrom + "' id='hdnForwardFrom" + i + "'/>" +
                    "<input type='hidden' value='" + item.ForwardTo + "' id='hdnForwardTo" + i + "'/>" +
                    "<input type='hidden' value='" + item.CourierName + "' id='hdnCourierName" + i + "'/>" +
                    "<input type='hidden' value='" + item.WayBillNo + "' id='hdnWayBillNo" + i + "'/>" +
                    "<input type='hidden' value='" + item.WayBillDate + "' id='hdnWayBillDate" + i + "'/>" +
                    "<input type='hidden' value='" + item.ManualPfmNo + "' id='hdnManualPfmNo" + i + "'/>" +
                    "<input type='hidden' value='" + item.PfmNo + "' id='hdnPfmNo" + i + "'/>" +
                    "<input type='hidden' value='" + $.displayDate(item.PfmDate) + "' id='hdnPfmDate" + i + "'/>"
                "</div>";
                item.PfmDate = $.displayDate(item.PfmDate);
            });
            dtPfmDetails.dtAddData(responseData);
        }
    }, ErrorFunction, false);
    return false;
}

var selectedPfmId = 0;
function GetPfmDetail(rd) {
    selectedPfmId = rd.value;
    var tr = $(rd).closest('tr');
    $('#hdnPfmId').val(selectedPfmId);
    $('#lblWayBillNo').text(tr.find('[id*="hdnWayBillNo"]').val());
    $('#lblWayBillDate').text($.displayDate(tr.find('[id*="hdnWayBillDate"]').val()));
    $('#lblCourierName').text(tr.find('[id*="hdnCourierName"]').val());
    $('#lblForwardType').text(tr.find('[id*="hdnForwardType"]').val());
    $('#lblForwardFrom').text(tr.find('[id*="hdnForwardFrom"]').val());
    $('#lblForwardTo').text(tr.find('[id*="hdnForwardTo"]').val());
    $('#lblManualPfmNo').text(tr.find('[id*="hdnManualPfmNo"]').val());
    $('#lblPfmNo').text(tr.find('[id*="hdnPfmNo"]').val());
    $('#lblPfmDate').text(tr.find('[id*="hdnPfmDate"]').val());
}

function ValidateStep2() {
    if (selectedPfmId == 0) {
        isStepValid = false;
        ShowMessage('Please select PFM');
        return false;
    }
    else {
        var requestData = { pfmId: selectedPfmId };
        AjaxRequestWithPostAndJson(baseUrl + '/GetPfmDocketListForAcknowledge', JSON.stringify(requestData), GetDocketListSuccess, ErrorFunction, false);
        return false;
    }
}

function GetDocketListSuccess(responseData) {
    if (responseData.length == 0) {
        isStepValid = false;
        ShowMessage('No Record Found');
        return false;
    }
    dtDocketDetails.fnClearTable();
    if (responseData.length > 0) {
        $.each(responseData, function (i, item) {
            item.DocketId = "<label class='checkbox'>" + SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'Details[' + i + '].IsChecked') +
                "<input type='hidden' value='" + item.DocketId + "' name='Details[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label></label>";
            item.DocketNo = item.DocketNo;
            item.DocketDate = $.displayDate(item.DocketDate);
            item.DeliveryDate = $.displayDate(item.DeliveryDate);
        });
        dtDocketDetails.dtAddData(responseData);
    }
}