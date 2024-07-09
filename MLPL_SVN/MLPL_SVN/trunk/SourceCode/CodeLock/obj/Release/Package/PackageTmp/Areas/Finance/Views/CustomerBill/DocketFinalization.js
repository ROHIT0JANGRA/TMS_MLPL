var docketNomenclature, docketFinalizationUrl;
$(document).ready(function () {
    SetPageLoad('Customer', docketNomenclature + ' Finalization', '', '', '@Url.Action("Index")');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtCustomerCode = $('#txtCustomerCode');
    ddlFromLocationId = $('#ddlFromLocationId');
    txtDocketNos = $('#txtDocketNos');
    lblCustomerName = $('#lblCustomerName');
    hdnCustomerId = $('#hdnCustomerId');
    lblCustomer = $('#lblCustomer');
    dvCustomer = $('#dvCustomer');
    rdDocketDate = $('#rdDocketDate');
    dvFinalizationDate = $('#dvFinalizationDate');

    drDocketDate = InitDateRange('drDocketDate', DateRange.LastWeek, false);
    InitWizard([
     { StepName: 'Criteria', StepFunction: GetDocketListForFinalization },
     { StepName: 'Finalized', StepFunction: StepValid }
    ]);
}

function AttachEvents() {
    customerScript.CustomerAutoComplete('txtCustomerCode', 'lblCustomerName', 'hdnCustomerId', 'CustomerId', false);
    txtCustomerCode.blur(function () { CheckValidCustomerCode(txtCustomerCode, lblCustomerName, hdnCustomerId, 'CustomerId', 'CustomerId', false); });
}

var customerScript = {
    CustomerAutoComplete: function (txtCodeId, lbltxtNameId, hdnId, entity, allowWalkin) {
        AutoComplete(txtCodeId, customerMasterUrl + '/GetAutoCompleteCustomerListByLocationPaybas', 'customerName', 'l', 'l', 'l', 'd', '', hdnId, lbltxtNameId, '', function () {
            if (entity == 'CustomerId')
                return [{ Key: 'locationId', Value: loginLocationId }, { Key: 'PaybasId', Value: '2' }, { Key: 'allowWalkin', Value: allowWalkin }];
        });
    }
}

function CheckValidCustomerCode(txtCode, txtName, hdnId, fieldName) {
    txtName.val('');
    if (txtCode.val() != '') {
        var requestData = { locationId: loginLocationId, paybasId: '2', customerCode: txtCode.val() };
        AjaxRequestWithPostAndJson(customerMasterUrl + '/GetCustomerByLocationPaybas', JSON.stringify(requestData), function (result) {

            if (result.Value == '') {
                ShowMessage('Invalid ' + fieldName);
                txtCode.focus();
            }
            else {
                hdnId.val(result.CustomerId);
                txtCode.val(result.CustomerCode);
                txtName.val(result.CustomerName);
            }
        }, ErrorFunction, false);
    }
    return false;
}

function GetDocketListForFinalization() {
    if (txtCustomerCode.val() == '')
        hdnCustomerId.val(0);
    var requestData = { locationId: ddlFromLocationId.val(), customerId: hdnCustomerId.val(), fromDate: drDocketDate.startDate, toDate: drDocketDate.endDate, docketNos: txtDocketNos.val() != '' ? txtDocketNos.val() : '' };

    AjaxRequestWithPostAndJson(docketFinalizationUrl + '/GetDocketListForDocketFinalization', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedDocketList = [];
            dtDocketList = LoadDataTable('dtDocketList', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllDocket', SelectDocket), data: "DocketId" },
                  { title: docketNomenclature + ' No', data: 'DocketNo' },
                  { title: 'Origin', data: 'FromLocation' },
                  { title: 'Party Name', data: 'CustomerCode' },
                  { title: docketNomenclature + ' Date', data: 'DocketDate' },
                  { title: 'Freight', data: 'Freight' },
                  { title: 'Sub Total', data: 'SubTotal' },
                  { title: docketNomenclature + ' Total', data: 'GrandTotal' },
                  { title: 'Status', data: 'DocketStatus' }
              ]);

            dtDocketList.fnClearTable();
            $.each(result, function (i, item) {
                item.DocketId = "<div class='checkboxer'>" +
                                    SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'DocketDetails[' + i + '].IsChecked', SelectDocket) +
                                    "<input type='hidden' value='" + item.DocketId + "' name='DocketDetails[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                                    "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>" +
                                    "</div>";
                item.DocketDate = $.displayDate(item.DocketDate);
            });
            dtDocketList.dtAddData(result);
            dvCustomer.showHide(txtDocketNos.val() == '');
            dvFinalizationDate.showHide(!rdDocketDate.IsChecked);
            lblCustomer.text(txtCustomerCode.val() + " : " + lblCustomerName.text());
        }
    }, ErrorFunction, false);
    return false;
}

function SelectDocket() {
    selectedDocketList = []
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        if (chkDocket.IsChecked) {
            selectedDocketList.push($('#' + chkDocket.Id.replace('chkDocket', 'hdnDocketId')).val());
        }
    });
}

function StepValid() {
    if (selectedDocketList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one ' + docketNomenclature);
        return false;
    }
}