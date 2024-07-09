var docketNomenclature, drDocketDate, txtDocketNo, txtCancelReason, dtDocketDetails, selectedDocketList, baseUrl;
var txtCancelDate, currentDate, dateTimeFormat;

$(document).ready(function () {
    SetPageLoad(docketNomenclature, 'Cancellation', '', '', '');
    InitObjects();
});

function InitObjects() {
    txtDocketNo = $('#txtDocketNo');
    drDocketDate = InitDateRange('drDocketDate', DateRange.LastWeek);
    txtCancelReason = $('#txtCancelReason');
    txtCancelDate = $('#txtCancelDate');

    InitWizard('dvWizard', [
      { StepName: 'Criteria', StepFunction: GetDocketList },
      { StepName: docketNomenclature + ' List', StepFunction: CheckStepValid }
    ], docketNomenclature + ' Cancel');
}

var errorMessage = '', docketId = '';
function GetDocketList() {
    var requestData = {
        docketNos: txtDocketNo.val(), fromDate: drDocketDate.startDate, toDate: drDocketDate.endDate
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetDocketListForCancellation', JSON.stringify(requestData), function (result) {

        selectedDocketList = [];

        if (dtDocketDetails == null)
            dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllDocket', SelectDocket), data: "DocketId" },
                  { title: docketNomenclature , data: 'DocketNo' },
                  { title: docketNomenclature + ' Date', data: 'DocketDate' },
                  { title: 'EDD', data: 'Edd' },
                  { title: 'Origin', data: 'FromLocation' },
                  { title: 'Destination', data: 'ToLocation' },
                  { title: 'TransportMode', data: 'TransportMode' },
                  { title: "Cancel Reason", data: 'CancelReason' },
                  { title: "Cancel Date", data: 'CancelDate' }
              ]);

        dtDocketDetails.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.DocketId = SelectAll.GetChk('chkAllDocket', 'chkDocket' + i, 'Details[' + i + '].IsChecked', SelectDocket) +
                                "<input type='hidden' value='" + item.DocketId + "' name='Details[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                                "<label class='label' for='chkDocket" + i + "' id='lblDocketId" + i + "'></label>";
                item.DocketNo = item.DocketNo + "<input type='hidden' value='" + item.DocketNo + "' name='Details[" + i + "].DocketNo' id='hdnDocketNo" + i + "'/>";
                item.DocketDate = $.displayDate(item.DocketDate);
                item.Edd = $.displayDate(item.Edd);
                item.CancelReason = '<input type=\'text\' name="Details[' + i + '].CancelReason" id="txtCancelReason' + i + '" class=" form-control" disabled/>' +
                '<span data-valmsg-for="Details[' + i + '].CancelReason" value=" " data-valmsg-replace="true"></span>';
                item.CancelDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='Details[" + i + "].CancelDate'  id='txtCancelDate" + i + "'class='form-control text-datetime' disabled/>" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="Details[' + i + '].CancelDate" data-valmsg-replace="true"></span></div>';

            });
            dtDocketDetails.dtAddData(result);
            $('[id*="txtCancelDate"]').each(function () {
                var txtCancelDate = $(this);
                InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            $('[id*="chkDocket"]').change(function () {
                var chkDocket = $(this);
                var hdnDocketId = $('#' + chkDocket.Id.replace('chkDocket', 'hdnDocketId'));
                var hdnDocketNo = $('#' + chkDocket.Id.replace('chkDocket', 'hdnDocketNo'));
                var txtReason = $('#' + chkDocket.Id.replace('chkDocket', 'txtCancelReason'));
                var txtCancelDate = $('#' + chkDocket.Id.replace('chkDocket', 'txtCancelDate'));
                var requestData = { docketId: hdnDocketId.val() };
                if (chkDocket.IsChecked) {
                    if (errorMessage != '' && docketId == hdnDocketId.val()) {
                        chkDocket.uncheck();
                        ShowMessage(errorMessage + hdnDocketNo.val());
                        return false;
                    }
                    else {
                        AjaxRequestWithPostAndJson(baseUrl + '/IsDocketValidForCancellation', JSON.stringify(requestData), function (result) {
                            if (!result.IsSuccessfull) {
                                errorMessage = result.ErrorMessage;
                                docketId = hdnDocketId.val();
                                chkDocket.uncheck();
                                ShowMessage(errorMessage + hdnDocketNo.val());
                                return false;
                            }
                            else {
                                txtReason.enable(chkDocket.IsChecked).val('');
                                txtCancelDate.enable(chkDocket.IsChecked).val('');
                                if (chkDocket.IsChecked) {
                                    AddRequired(txtReason, 'Enter Cancel Reason');
                                    txtReason.val(txtCancelReason.val());
                                    AddRequired(txtCancelDate, 'Enter Cancel Reason');
                                    txtCancelDate.val(txtCancelReason.val());
                                }
                                else
                                    RemoveRequired(txtReason);
                                    RemoveRequired(txtCancelDate);
                            }
                        }, ErrorFunction, false);
                    }
                }
            });
            txtCancelReason.blur(OnCancelReasonChange);
        }
    }, ErrorFunction, false);
    return false;
}

function OnCancelReasonChange() {
    $('[id*="chkDocket"]').each(function () {
        var chkDocket = $(this);
        var txtReason = $('#' + chkDocket.Id.replace('chkDocket', 'txtCancelReason'));
        if (chkDocket.IsChecked)
            txtReason.val(txtCancelReason.val());
    });
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

function CheckStepValid() {
    if (selectedDocketList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one ' + docketNomenclature);
        return false;
    }
}