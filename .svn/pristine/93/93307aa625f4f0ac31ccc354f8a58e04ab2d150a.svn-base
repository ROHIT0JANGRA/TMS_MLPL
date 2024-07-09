var ddlsearchBy, txtTripsheetNo, dtTripsheetDetailList, drTripsheetDate, TripsheetUrl, selectedTripsheetId, txtDriverPayableNetAmount,
    txtDriverReceivableNetAmount, dtExpensesDetails, hdnVehicleId, dtFuelSlipDetail;

$(document).ready(function () {
    SetPageLoad('Tripsheet', 'Driver Settlement', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    ddlsearchBy = $('#ddlsearchBy');
    txtTripsheetNo = $('#txtTripsheetNo');
    dtTripsheetDetailList = $('#dtTripsheetDetailList');
    dtExpensesDetails = $('#dtExpensesDetails');
    drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek);
    txtDriverPayableNetAmount = $('#txtDriverPayableNetAmount');
    txtDriverReceivableNetAmount = $('#txtDriverReceivableNetAmount');
    hdnVehicleId = $('#hdnVehicleId');

    dtTripsheetDetailList = LoadDataTable('dtTripsheetDetailList', false, false, false, null, null, [],
              [
                  { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                  { title: 'Tripsheet No', data: 'TripsheetNo' },
                  { title: 'Tripsheet Date', data: 'TripsheetDate' },
                  { title: 'Driver', data: 'FirstDriverName' }
              ]);

    dtFuelSlipDetail = LoadDataTable('dtFuelSlipDetail', false, false, false, null, null, [],
              [
                  { title: 'Vendor', data: 'FuelVendorName' },
                  { title: 'FuelSlip No.', data: 'SlipNo' },
                  { title: 'FuelSlip Date', data: 'FuelSlipDate' },
                  { title: 'Quantity', data: 'Quantity' },
                  { title: 'Rate', data: 'Rate' },
                  { title: 'Amount', data: 'Amount' }
              ]);

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetTripsheetList },
     { StepName: 'Tripsheet List', StepFunction: LoadStep3 },
     { StepName: 'Driver Settlement Details' }
    ], 'Submit');
}

function AttachEvents() {
    txtDriverPayableNetAmount.blur(CheckValidPayableNetAmount);
    txtDriverPayableNetAmount.blur(GetApplicableAmountForPayable);
    txtDriverReceivableNetAmount.blur(CheckValidReceivableNetAmount);
    txtDriverReceivableNetAmount.blur(GetApplicableAmountForReceivable);
    ddlsearchBy.change(SearchByChange);
    $('#dvTdsDetails').hide();
}

function SearchByChange() {
    txtTripsheetNo.val('');
    hdnVehicleId.val(0);
    if (ddlsearchBy.val() == 3) {
        VehicleAutoComplete('txtTripsheetNo', 'hdnVehicleId');
        txtTripsheetNo.blur(function () { IsVehicleNoExist(txtTripsheetNo, hdnVehicleId); });
    }
    else {
        txtTripsheetNo.autocomplete("destroy");
        txtTripsheetNo.off('blur');
    }
}

function GetTripsheetList() {
    var requestData = {
        searchBy: ddlsearchBy.val(), TripsheetNo: txtTripsheetNo.val(), fromDate: drTripsheetDate.startDate, toDate: drTripsheetDate.endDate
    };
    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetTripsheetListForDriverSettlement', JSON.stringify(requestData), function (result) {
        dtTripsheetDetailList.fnClearTable();
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.ManualTripsheetNo = '<div class="clearfix">' +
                                   '<label class="radio">' +
                                       '<input type="radio" name=\'Tripsheet\' value=\'' + item.TripsheetId + '\' onclick="GetTripsheetDetail(this)" tabindex="0" id="chkManualTripsheetNo' + i + '"/><i></i>' +
                                         '<label for="chkManualTripsheetNo' + i + '">' + item.ManualTripsheetNo + '</label>' +
                                   '</label>' +
                               '</div>';
                item.TripsheetDate = $.displayDate(item.TripsheetDate);
            });
            dtTripsheetDetailList.dtAddData(result);
            selectedTripsheetId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

function GetTripsheetDetail(rd) {
    selectedTripsheetId = rd.value;
}

function LoadStep3() {
    var totalAdvanceAmount = 0, totalDieselexpense = 0, totalEnrouteExpense = 0;
    isStepValid = selectedTripsheetId != 0;
    if (selectedTripsheetId == 0) {
        ShowMessage('Please select Tripsheet');
        return false;
    }
    $('#hdnTripsheetId').val(selectedTripsheetId);
    var requestData = { TripsheetId: selectedTripsheetId };
    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetById', JSON.stringify(requestData), GetTripsheetDetailSuccess, ErrorFunction, false);
    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetAdvanceDetail', JSON.stringify(requestData), function (result) {
        if (result.length != 0) {
            $.each(result, function (i, item) {
                totalAdvanceAmount = parseFloat(totalAdvanceAmount) + parseFloat(item.Amount);
            });
            $('#txtTotalAdvance').val(totalAdvanceAmount.toFixed(2));
        }
    }, ErrorFunction, false);

    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetOilExpenseDetailAgaintsCash', JSON.stringify(requestData), function (result) {
        if (result.length != 0) {
            $.each(result, function (i, item) {
                totalDieselexpense = parseFloat(totalDieselexpense) + parseFloat(item.Amount);
            });
            $('#txtDieselExpense').val(totalDieselexpense.toFixed(2));
        }
    }, ErrorFunction, false);

    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetEnRouteExpenseDetail', JSON.stringify(requestData), function (result) {
        if (result.length != 0) {
            $.each(result, function (i, item) {
                totalEnrouteExpense = parseFloat(totalEnrouteExpense) + parseFloat(item.SpentAmount);
            });
            $('#txtEnrouteExpense').val(totalEnrouteExpense.toFixed(2));
        }
    }, ErrorFunction, false);

    AjaxRequestWithPostAndJson(TripsheetUrl + '/GetFuelSlipDetail', JSON.stringify(requestData), function (result) {
        dtFuelSlipDetail.fnClearTable();
        if (result.length == 0) {
            $('#dvFuelSlipDetail').hide();
        }
        else {
            $.each(result, function (i, item) {
                item.FuelSlipDate = $.displayDate(item.FuelSlipDate);

            });
            dtFuelSlipDetail.dtAddData(result);
        }
    }, ErrorFunction, false);

    $('#txtTotalExpenses').val(totalDieselexpense + totalEnrouteExpense);
    $('#txtNetAmount').val(parseFloat($('#txtTotalAdvance').val()) - parseFloat($('#txtTotalExpenses').val()));
    SetPaymentPartyTypeAndParty(5, $('#hdnDriverId').val());
    SetReceiptPartyTypeAndParty(5, $('#hdnDriverId').val());
    if (parseFloat($('#txtNetAmount').val()) == 0) {
        CheckValidPayableNetAmount();
        txtDriverReceivableNetAmount.attr("readOnly", true);
        txtDriverPayableNetAmount.attr("readOnly", true);
        $('#divPaymentDetail').hide();
        $('#divReceiptDetail').hide();
        $('#ddlPaymentMode').disable();
        $('#ddlReceiptMode').disable();
    }
    else if (parseFloat($('#txtNetAmount').val()) > 0) {
        CheckValidReceivableNetAmount();
        txtDriverReceivableNetAmount.attr("readOnly", false);
        txtDriverPayableNetAmount.attr("readOnly", true);
        if (parseFloat(txtDriverReceivableNetAmount.val()) > 0) {
            $('#divPaymentDetail').hide();
            $('#divReceiptDetail').show();
        }
    }
    else if (parseFloat($('#txtNetAmount').val()) < 0) {
        CheckValidPayableNetAmount();
        txtDriverReceivableNetAmount.attr("readOnly", true);
        txtDriverPayableNetAmount.attr("readOnly", false);
        if (parseFloat(txtDriverPayableNetAmount.val()) > 0) {
            $('#divPaymentDetail').show();
            $('#divReceiptDetail').hide();
        }
    }
    else {
        CheckValidPayableNetAmount();
        txtDriverReceivableNetAmount.attr("readOnly", true);
        txtDriverPayableNetAmount.attr("readOnly", true);
        $('#divPaymentDetail').hide();
        $('#divReceiptDetail').hide();
        $('#ddlPaymentMode').disable();
        $('#ddlReceiptMode').disable();
    }
    return false;
}

function GetTripsheetDetailSuccess(responseData) {
    $('#lblTripsheetNo').text(responseData.TripsheetNo);
    $('#hdnTripsheetNo').val(responseData.TripsheetNo);
    $('#lblManualTripsheetNo').text(responseData.ManualTripsheetNo);
    $('#lblTripsheetDate').text($.displayDate(responseData.TripsheetDate));
    $('#lblVehicleNo').text(responseData.VehicleNo);
    $('#lblDriverName').text(responseData.DriverName);
    $('#hdnDriverId').val(responseData.DriverId);
    $('#lblDriverLicenseNo').text(responseData.DriverLicenseNo);
    $('#lblDriverLicenseValidityDate').text($.displayDate(responseData.DriverLicenseValidityDate));
    $('#lblStartLocationCode').text(responseData.StartLocationCode);
    $('#lblEndLocationCode').text(responseData.EndLocationCode);
    $('#lblCategory').text(responseData.Category);
    $('#lblCustomerCode').text(responseData.CustomerCode);
    $('#lblStartKm').text(responseData.StartKm);
    $('#lblEndKm').text(responseData.EndKm);
    $('#hdnEndKm').val(responseData.EndKm);
    $('#lblFinCloseDateTime').text($.displayDate(responseData.FinCloseDateTime));
    $('#hdnVehicleId').val(responseData.VehicleId);
}

function GetApplicableAmountForPayable() {
    $('#txtAmountApplicable').val(txtDriverPayableNetAmount.val());
}

function GetApplicableAmountForReceivable() {
    $('#txtAmountApplicable').val(txtDriverReceivableNetAmount.val());
}

function CheckValidPayableNetAmount() {
    var netAmount = parseFloat($('#txtNetAmount').val());
    if (netAmount < 0) netAmount = netAmount * -1;
    if (parseFloat(txtDriverPayableNetAmount.val()) != 0 && txtDriverPayableNetAmount.val() != '' && parseFloat(txtDriverPayableNetAmount.val()) > netAmount) {
            ShowMessage('Payable Amount should be less than or equal to Net Amount');
            txtDriverPayableNetAmount(0);
            txtDriverPayableNetAmount.focus();
            return false;
    }
    $('#hdnDriverBalanceAmount').val(netAmount - parseFloat(txtDriverPayableNetAmount.val() == '' ? 0 : txtDriverPayableNetAmount.val()));
    $('#hdnDriverBalanceDrCr').val(netAmount > 0 ? 'CR' : 'DR');
    $('#txtDriverBalanceAmount').val(netAmount - parseFloat(txtDriverPayableNetAmount.val()) + ' ' + (netAmount > 0 ? 'CR' : 'DR'));
    SetPaymentAmount(parseFloat(txtDriverPayableNetAmount.val()));
    SetReceiptAmount(0);
    SetPaymentAndReceiptMode();
}

function CheckValidReceivableNetAmount() {
    var netAmount = parseFloat($('#txtNetAmount').val());
    if (netAmount < 0) netAmount = netAmount * -1;
    if (parseFloat(txtDriverReceivableNetAmount.val()) != 0 && txtDriverReceivableNetAmount.val() != '' && parseFloat(txtDriverReceivableNetAmount.val()) > netAmount) {
            ShowMessage('Receivable Amount should be less than or equal to Net Amount');
            txtDriverReceivableNetAmount.val(0);
            txtDriverReceivableNetAmount.focus();
            return false;
    }
    $('#hdnDriverBalanceAmount').val(netAmount - parseFloat(txtDriverReceivableNetAmount.val() == '' ? 0 : txtDriverReceivableNetAmount.val()));
    $('#hdnDriverBalanceDrCr').val(netAmount < 0 ? 'CR' : 'DR');
    $('#txtDriverBalanceAmount').val(netAmount - parseFloat(txtDriverReceivableNetAmount.val() == '' ? 0 : txtDriverReceivableNetAmount.val()) + ' ' + (netAmount < 0 ? 'CR' : 'DR'));
    SetReceiptAmount(parseFloat(txtDriverReceivableNetAmount.val()));
    SetPaymentAmount(0);
    SetPaymentAndReceiptMode();
}

function SetPaymentAndReceiptMode() {
    if (parseFloat($('#txtNetAmount').val()) == 0) {
        txtDriverReceivableNetAmount.attr("readOnly", true);
        txtDriverPayableNetAmount.attr("readOnly", true);
        $('#divPaymentDetail').hide();
        $('#divReceiptDetail').hide();
        $('#ddlPaymentMode').disable();
        $('#ddlReceiptMode').disable();
    }
    else if (parseFloat($('#txtNetAmount').val()) > 0) {
        txtDriverReceivableNetAmount.attr("readOnly", false);
        txtDriverPayableNetAmount.attr("readOnly", true);
        if (parseFloat(txtDriverReceivableNetAmount.val()) > 0) {
            $('#divPaymentDetail').hide();
            $('#divReceiptDetail').show();
        }
        else {
            txtDriverReceivableNetAmount.attr("readOnly", false);
            txtDriverPayableNetAmount.attr("readOnly", true);
            $('#divPaymentDetail').hide();
            $('#divReceiptDetail').hide();
            $('#ddlPaymentMode').disable();
            $('#ddlReceiptMode').disable();
        }
    }
    else if (parseFloat($('#txtNetAmount').val()) < 0) {
        txtDriverReceivableNetAmount.attr("readOnly", true);
        txtDriverPayableNetAmount.attr("readOnly", false);
        if (parseFloat(txtDriverPayableNetAmount.val()) > 0) {
            $('#divPaymentDetail').show();
            $('#divReceiptDetail').hide();
        }
        else {
            txtDriverReceivableNetAmount.attr("readOnly", true);
            txtDriverPayableNetAmount.attr("readOnly", false);
            $('#divPaymentDetail').hide();
            $('#divReceiptDetail').hide();
            $('#ddlPaymentMode').disable();
            $('#ddlReceiptMode').disable();
        }
    }
    else {
        txtDriverReceivableNetAmount.attr("readOnly", true);
        txtDriverPayableNetAmount.attr("readOnly", true);
        $('#divPaymentDetail').hide();
        $('#divReceiptDetail').hide();
        $('#ddlPaymentMode').disable();
        $('#ddlReceiptMode').disable();
    }
}
