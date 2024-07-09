var txtTripsheetNo, txtManualTripsheetNo, dtTripsheetList, drTripsheetDate, txtVehicleNo, hdnVehicleId, ddlDriverId;
var tripsheetUrl, selectedTripsheetId;
//var sizeArr = [[0, '60px'], [1, '100px'], [2, '150px'], [3, '80px'], [4, '80px'], [5, '80px'], [6, '85px']];
//var prevQuantity = 0, prevAmount = 0;
//var trFuelSlip;
var currentDate, jsDateFormat;
$(document).ready(function () {
	SetPageLoad('Trip Sheet', 'Fuel Slip', '', '', '');
	InitObjects();
});

function InitObjects() {
	txtTripsheetNo = $('#txtTripsheetNo');
	txtManualTripsheetNo = $('#txtManualTripsheetNo');
	dtTripsheetList = $('#dtTripsheetList');
	txtVehicleNo = $('#txtVehicleNo');
	hdnVehicleId = $('#hdnVehicleId');
	ddlDriverId = $('#ddlDriverId');
	drTripsheetDate = InitDateRange('drTripsheetDate', DateRange.LastWeek);

	InitGrid('dtFuelSlipDetail', false, 8, InitAutoComplete);

	dtTripsheetList = LoadDataTable('dtTripsheetList', false, false, false, null, null, [],
		[
			{ title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
			{ title: 'Tripsheet No', data: 'TripsheetNo' },
			{ title: 'Tripsheet Date', data: 'TripsheetDate' },
			{ title: 'Vehicle No', data: 'VehicleNo' },
			{ title: 'Driver', data: 'FirstDriverName' }
		]);
	dtPreviousFuelSlipDetails = LoadDataTable('dtPreviousFuelSlipDetails', false, false, false, null, null, [],
		[
			{ title: 'Fuel Slip Type', data: 'FuelSlipType' },
			{ title: 'Fuel Slip No', data: 'SlipNo' },
			{ title: 'Fuel Slip Date', data: 'FuelSlipDate' },
			{ title: 'Vendor Code', data: 'FuelVendorCode' },
			{ title: 'Vendor Name', data: 'FuelVendorName' },
			{ title: 'Quantity', data: 'Quantity' },
			{ title: 'Rate', data: 'Rate' },
			{ title: 'Amount', data: 'Amount' }
		]);

	//dtFuelSlipList = LoadDataTable('dtFuelSlipList', false, false, false, null, null, [],
	//         [
	//             { title: 'Fuel Slip Type', data: 'FuelSlipType' },
	//             { title: 'Fuel Slip No', data: 'SlipNo' },
	//             { title: 'Fuel Slip Date', data: 'FuelSlipDate' },
	//             { title: 'Vendor Code', data: 'FuelVendorCode' },
	//             { title: 'Vendor Name', data: 'FuelVendorName' },
	//             { title: 'Quantity', data: 'Quantity' },
	//             { title: 'Rate', data: 'Rate' },
	//             { title: 'Amount', data: 'Amount' }
	//         ], false);

	//$.each(sizeArr, function (i, item) {
	//    $('#' + 'dtFuelSlipDetail' + ' thead tr th:eq(' + item[0] + ')').css('min-width', item[1]).css('max-width', item[1]);
	//});

	InitWizard('dvWizard', [
		{ StepName: 'Criteria', StepFunction: GetTripsheetList },
		{ StepName: 'Trip Sheet List', StepFunction: LoadStep3 },
		{ StepName: 'Trip Sheet Details' },
		{ StepName: 'Fuel Slip Details' }
	], 'Submit');

	//trFuelSlip = $('#' + 'dtFuelSlipDetail' + ' tbody tr:first');
	VehicleAutoComplete('txtVehicleNo', 'hdnVehicleId');
	txtVehicleNo.blur(function () { IsVehicleNoExist(txtVehicleNo, hdnVehicleId); });
	ddlDriverId.change(GetDriverDetail);
} hdnVehicleId

function InitAutoComplete() {
	$('[id*="hdnFuelVendorId"]').each(function () {
		var hdnFuelVendorId = $(this);
		var txtFuelSlipDate = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtFuelSlipDate'));
		var ddlPaidBy = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'ddlPaidBy'));
		var txtSlipNo = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtSlipNo'));
		var txtFuelVendorCode = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtFuelVendorCode'));
		var lblFuelVendorName = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'lblFuelVendorName'));
		var txtQuantity = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtQuantity'));
		var txtRate = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtRate'));
		var txtAmount = $('#' + hdnFuelVendorId.Id.replace('hdnFuelVendorId', 'txtAmount'));

		InitDateTimePicker(txtFuelSlipDate.Id, false, true, false, currentDate, dateTimeFormat, '', '', false, true, false);
		VendorAutoComplete(txtFuelVendorCode.Id, hdnFuelVendorId.Id, 'Fuel Vendor', 6);
		txtFuelVendorCode.blur(function () { return IsVendorCodeExist(txtFuelVendorCode, hdnFuelVendorId, lblFuelVendorName, 'Fuel Vendor', 6); });
		txtRate.blur(function () {
			txtAmount.val(parseFloat(txtRate.val()) * parseFloat(txtQuantity.val()));
			GetTotalAmountAndQuantity();
		});
		txtRate.blur(GetTotalAmountAndQuantity);
		txtAmount.blur(GetTotalAmountAndQuantity);
		txtQuantity.blur(function () {
			txtAmount.val(parseFloat(txtRate.val()) * parseFloat(txtQuantity.val()));
			GetTotalAmountAndQuantity();
		});

		AddRequired(ddlPaidBy, 'Please select Fuel Slip Type');
		AddRequired(txtSlipNo, 'Please enter Fuel Slip No');
		AddRequired(txtFuelVendorCode, 'Please enter Vendor');
		AddRange(txtAmount, "Please enter Amount", 1);
		ddlPaidBy.change(function () {
			if ($(this).val() == 'CASH') {
				txtQuantity.val(1);
				txtRate.val(1);
				RemoveRange(txtQuantity, "Please enter Quantity");
				RemoveRange(txtRate, "Please enter Rate");
				txtQuantity.val(0);
				txtRate.val(0);
				txtAmount.removeClass('textlabel');
				txtAmount.val(0);
			}
			else {
				AddRange(txtQuantity, "Please enter Quantity", 1);
				AddRange(txtRate, "Please enter rate", 1);
				txtAmount.addClass('textlabel');
			}
			GetTotalAmountAndQuantity();
			//txtQuantity.enable($(this).val() == 'FUEL');
			//txtRate.enable($(this).val() == 'FUEL');
		});
	});
}

function GetTotalAmountAndQuantity() {
	var totalAmount = 0, totalQuantity = 0;
	$('[id*="txtPreviousQuantity"]').each(function () {
		var txtPreviousQuantity = $(this);
		var txtPreviousAmount = $('#' + txtPreviousQuantity.Id.replace('txtPreviousQuantity', 'txtPreviousAmount'));
		totalAmount = totalAmount + parseFloat(txtPreviousAmount.val());
		totalQuantity = totalQuantity + parseFloat(txtPreviousQuantity.val());
	});
	$('[id*="txtQuantity"]').each(function () {
		var txtQuantity = $(this);
		var ddlPaidBy = $('#' + txtQuantity.Id.replace('txtQuantity', 'ddlPaidBy'));
		var txtRate = $('#' + txtQuantity.Id.replace('txtQuantity', 'txtRate'));
		var txtAmount = $('#' + txtQuantity.Id.replace('txtQuantity', 'txtAmount'));
		if (txtRate.val() != '' && txtQuantity.val() != '') {
			if (ddlPaidBy.val() == 'FUEL')
				txtAmount.val(parseFloat(txtRate.val()) * parseFloat(txtQuantity.val()));
			totalAmount = totalAmount + parseFloat(txtAmount.val());
			totalQuantity = totalQuantity + parseFloat(txtQuantity.val());
		}
	});
	$('#txtTotalQuantity').val(totalQuantity);
	$('#txtTotalAmount').val(totalAmount);
}


function GetTripsheetList() {
	var requestData = { manualTripsheetNo: txtManualTripsheetNo.val(), tripsheetNo: txtTripsheetNo.val(), fromDate: drTripsheetDate.startDate, toDate: drTripsheetDate.endDate, vehicleNo: txtVehicleNo.val() };

	AjaxRequestWithPostAndJson(tripsheetUrl + '/GetTripsheetListForFuelSlip', JSON.stringify(requestData), function (result) {
		dtTripsheetList.fnClearTable();
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
			dtTripsheetList.dtAddData(result);
			selectedTripsheetId = 0;
		}
	}, ErrorFunction, false);
	return false;
}

function GetTripsheetDetail(rd) {
	selectedTripsheetId = rd.value;
}

function LoadStep3() {
	isStepValid = selectedTripsheetId != 0;
	if (selectedTripsheetId == 0) {
		ShowMessage('Please select Trip Sheet');
		return false;
	}
	$('#hdnTripsheetId').val(selectedTripsheetId);
	var requestData = { TripsheetId: selectedTripsheetId, addRow: true };
	AjaxRequestWithPostAndJson(tripsheetUrl + '/GetById', JSON.stringify(requestData), GetTripsheetDetailSuccess, ErrorFunction, false);
	AjaxRequestWithPostAndJson(tripsheetUrl + '/GetFuelSlipDetailByTripsheetId', JSON.stringify(requestData), function (result) {
		dtPreviousFuelSlipDetails.fnClearTable();
		if (result.length == 0) {
			$('#dvPreviousFuelSlipDetails').hide();
			$('#dvPreviousFuelSlipDetail').hide();
		}
		else {
			$.each(result, function (i, item) {
				item.FuelSlipDate = $.displayDate(item.FuelSlipDate);
				item.Rate = '<input class="form-control numeric textlabel input-small" id="txtPreviousRate' + i + '" type="text" value=\'' + item.Rate + '\'/>';
				item.Quantity = '<input class="form-control numeric textlabel" id="txtPreviousQuantity' + i + '" type="text" value=\'' + item.Quantity + '\'/>';
				item.Amount = '<input class="form-control numeric textlabel" id="txtPreviousAmount' + i + '" type="text" value=\'' + item.Amount + '\'/>';
			});
			dtPreviousFuelSlipDetails.dtAddData(result);
		}
		GetTotalAmountAndQuantity();
		//dtFuelSlipList.fnClearTable();
		//$('#dvFuelSlipDetail').hide();
		//$.each(result, function (i, item) {
		//    item.FuelSlipDate = $.displayDate(item.FuelSlipDate);
		//});
		//dtFuelSlipList.dtAddData(result, [3, 4, 5], null, sizeArr);
		//$('#' + 'dtFuelSlipList tbody tr:first').showHide(result.length > 0);
		//$('#' + 'dtFuelSlipList' + ' tbody').append(trFuelSlip);
		//prevQuantity = 0; prevAmount = 0;
		//$.each(result, function (i, item) {
		//    prevQuantity += item.Quantity;
		//    prevAmount += item.Amount;
		//});
		//GetTotalAmountAndQuantity();
		//AddRequired($("#txtSlipNo0"), "Please enter Fuel Slip No.");
		//AddRequired($("#txtFuelSlipDate0"), "Please select Fuel Slip Date");
		//AddRequired($("#txtFuelVendorCode0"), "Please select Fuel Vendor");
		//AddRange($("#txtAmount0"), "Please enter Amount", 1);
	}, ErrorFunction, false);
}

function GetTripsheetDetailSuccess(responseData) {
	$('#hdnCompanyId').val(responseData.CompanyId);
	$('#hdnTripsheetNo').val(responseData.TripsheetNo);
	$('#lblTripsheetNo').text(responseData.TripsheetNo);
	$('#lblTripsheetDate').text($.displayDate(responseData.TripsheetDate));
	$('#hdnTripsheetDate').val($.displayDate(responseData.TripsheetDate));
	$('#hdnVehicle').val(responseData.VehicleId);
	$('#lblVehicleNo').text(responseData.VehicleNo);
	var requestData = { vehicleId: responseData.VehicleId };
	AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Driver').replace('Action', 'GetDriverListByTripSheetRule'), JSON.stringify(requestData), GetFirstDriverListSuccess, ErrorFunction, false);
	if (responseData.DriverId > 0) {
		$('#txtDriverName').val(responseData.DriverName);
		$('#ddlDriverId').val(responseData.DriverId);
		$('#lblDriverLicenseNo').text(responseData.DriverLicenseNo);
		$('#lblDriverLicenseValidityDate').text($.displayDate(responseData.DriverLicenseValidityDate));
		if (parseFloat(responseData.DriverBalance) == 0)
			$('#txtDriverBalance').val(responseData.DriverBalance);
		else if (parseFloat(responseData.DriverBalance) < 0)
			$('#txtDriverBalance').val(responseData.DriverBalance + " CR");
		else
			$('#txtDriverBalance').val(responseData.DriverBalance + " DR");
		$('#dvDriverName').show();
	}
	else {
		$('#txtDriverName').val('');
		$('#ddlDriverId').val('');
		$('#lblDriverLicenseNo').text('');
		$('#lblDriverLicenseValidityDate').text('');
		$('#divDriverInfo').show();
	}
	$('#lblStartLocationCode').text(responseData.StartLocationCode);
	$('#lblEndLocationCode').text(responseData.EndLocationCode);
	$('#lblCategory').text(responseData.Category);
	$('#lblCustomerCode').text(responseData.CustomerCode);
}

function GetFirstDriverListSuccess(responseData) {
	BindDropDownList('ddlDriverId', responseData, 'Value', 'Name', '', 'Select');
}

function GetDriverDetail() {
	if (ddlDriverId.val() != '') {
		var requestData = { driverId: ddlDriverId.val() };
		AjaxRequestWithPostAndJson(appUrl.replace('Controller', 'Driver').replace('Action', 'GetById'), JSON.stringify(requestData), function (result) {
			$('#txtDriverName').val(result.DriverName);
			$('#lblDriverLicenseNo').text(result.LicenseNo);
			$('#lblDriverLicenseValidityDate').text($.displayDate(result.LicenseValidityDate));
			if (parseFloat(result.BalanceAmount) == 0)
				$('#txtDriverBalance').val(result.BalanceAmount);
			else if (parseFloat(result.BalanceAmount) < 0)
				$('#txtDriverBalance').val(result.BalanceAmount + " CR");
			else
				$('#txtDriverBalance').val(result.BalanceAmount + " DR");
		}, ErrorFunction, false);
	}
	else {
		$('#txtDriverName').val('');
		$('#lblDriverLicenseNo').text('');
		$('#lblDriverLicenseValidityDate').text('');
		$('#txtDriverBalance').val(0);
	}
}