var dtDocketDetails, txtForwardTo, lblForwardTo, hdnForwardToId, rdLocation, rdCustomer, docketNomenclature;
$(document).ready(function () {
    SetPageLoad('PFM', 'Generate', 'drDocketDate');

    txtForwardTo = $('#txtForwardTo'); hdnForwardToId = $('#hdnForwardToId'); rdLocation = $('#rdLocation'); rdCustomer = $('#rdCustomer');
    lblForwardTo = $('#lblForwardTo');
    drDocketDate = InitDateRange('drDocketDate', DateRange.LastWeek);
  
    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [
            { title:  SelectAll.GetChkAll('chkAllDocket', SelectDocket) + "</div></div>", data: "DocketId", width: 80 },
            { title: docketNomenclature + ' No', data: "DocketNo" },
            { title: 'Booking Date', data: "DocketDate" },
            { title: 'Origin', data: "FromLocationCode" },
            { title: 'Destination', data: "ToLocationCode" },
            { title: 'Delivery Date', data: "DeliveryDate" }
        ]);

    InitWizard('dvWizard', [{ StepName: 'Criteria', StepFunction: GetDocketList },
        { StepName: 'Docket List', StepFunction: ValidateStep },
    { StepName: 'PFM Details', StepFunction: ValidateStep3 }], 'Generate PFM');
    rdLocation.check();
    txtForwardTo.blur(CheckValidForwardTo);
    rdLocation.click(OnChangeForwardTo);
    rdCustomer.click(OnChangeForwardTo);

    rdLocation.click();
});

function OnChangeForwardTo() {
    txtForwardTo.val();
    hdnForwardToId.val(0);
    InitAutoComplete();
}

function CheckValidForwardTo() {
    if (txtForwardTo.val() != '') {
        if (rdLocation.IsChecked)
            IsLocationCodeExist(txtForwardTo, hdnForwardToId, 'Location');
        else
            IsCustomerCodeExist(txtForwardTo, hdnForwardToId, lblForwardTo, 'Customer');
    }
}

function InitAutoComplete() {
    if (rdLocation.IsChecked)
        LocationAutoComplete('txtForwardTo', 'hdnForwardToId');
    else
        CustomerAutoComplete('txtForwardTo', 'hdnForwardToId');
}

function GetDocketList() {
    var requestData = {
        companyId: loginCompanyId,
        locationId: loginLocationId,
        docketList: $('#txtDocketNo').val(),
        fromDate: $.displayDate(drDocketDate.startDate),
        toDate: $.displayDate(drDocketDate.endDate)
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetDocketListForPfm', JSON.stringify(requestData), GetDocketListSuccess, ErrorFunction, false);
    return false;
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
            item.DocketId = "<div class='checkbox'>" + SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'Details[' + i + '].IsChecked', SelectDocket) +
                "<input type='hidden' value='" + item.DocketId + "' name='Details[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>"
            "</div>"
            item.DocketNo = item.DocketNo;
            item.DocketDate = $.displayDate(item.DocketDate);
            item.DeliveryDate = $.displayDate(item.DeliveryDate);
        });
        dtDocketDetails.dtAddData(responseData);
    }
}

var selectedDockets = [];
function SelectDocket() {
    selectedDockets = [];
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        if (chkDocket.IsChecked) {
            selectedDockets.push($('#' + chkDocket.Id.replace('chkDocket', 'hdnDocketId')).val());
        }
    });
}

function ValidateStep() {
    if (selectedDockets.length == 0) {
        isStepValid = false;
        ShowMessage('Please select atleast one ' + docketNomenclature);
        return false;
    }
}

function ValidateStep3() {
    if (rdLocation.IsChecked && hdnForwardToId.val() == loginLocationId) {
        isStepValid = false;
        ShowMessage('Please enter different Location');
        txtForwardTo.val('');
        hdnForwardToId.val(0);
        txtForwardTo.focus();
        return false;
    }
}