function LocationAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Location';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Location', 'GetAutoCompleteLocationList'), 'locationCode', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}

function LocationAutoCompleteDocketEntry(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Location';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Location', 'GetAutoCompleteLocationListDocketENtry'), 'locationCode', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}

function GetAutoCompleteLocationAllList(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Location';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Location', 'GetAutoCompleteLocationAllList'), 'locationCode', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}


function VehicleAutoCompleteForMaintanance(txtId, hdnId, fieldName, useValidate) {

    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vehicle', 'GetAutoCompleteVehicleForMaintanance'), 'vehicleNo', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}

function VehicleAutoCompleteForStatus(txtId, hdnId, fieldName, useValidate) {

    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vehicle', 'GetAutoCompleteVehicleListForStatus'), 'vehicleNo', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}
function IsLocationCodeExistOwnership(txtObj, hdnObj, fieldName, useValidate, hdnBillLocationId, txtBillLocation) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Location';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { locationCode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Location', 'IsLocationCodeExistOwnership'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnBillLocationId.val('0');
                    txtBillLocation.val('');
                }
                else {
                    hdnBillLocationId.val(result.Value);
                    txtBillLocation.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function IsLocationCodeExist(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Location';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { locationCode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Location', 'IsLocationCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function CityAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'City';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('City', 'GetAutoCompleteCityList'), 'cityName', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}

function IsCityNameExist(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'City';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { cityName: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('City', 'IsCityNameExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function ZoneAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Zone';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Zone', 'GetAutoCompleteZone'), 'zoneName', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}

function IsZoneNameExist(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Zone';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { zoneName: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Zone', 'IsZoneNameExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function BinAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Bins';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Bins', 'GetAutoCompleteList'), 'binCode', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}
function CheckValidBinCodeForPutAway(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Zone';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { binCode: txtObj.val().split(':')[0].trim() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Bins', 'IsBinCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function IsDocumentNoExist(txtDocumentNo, documentTypeId, locationId, documentType, useValidate) {
    if (IsObjectNullOrEmpty(documentType)) documentType = 'Document';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtDocumentNo.val() != "") {
        var requestData = { documentTypeId: documentTypeId, documentNo: txtDocumentNo.val(), locationId: locationId };
        AjaxRequestWithPostAndJson(ReplaceUrl('Dcr', 'IsDocumentNoExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (!result) {
                    ShowMessage('Invalid ' + documentType, txtDocumentNo);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function IsDocumentNoDcrDumptcoExist(txtDocumentNo, documentTypeId, locationId, documentType, useValidate, hdnFromLocationId, lblFromLocation) {
    if (IsObjectNullOrEmpty(documentType)) documentType = 'Document';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtDocumentNo.val() != "") {
        var requestData = { documentTypeId: documentTypeId, documentNo: txtDocumentNo.val(), locationId: locationId };
        AjaxRequestWithPostAndJson(ReplaceUrl('Dcr', 'IsDocumentNoDcrDumptcoExist'), JSON.stringify(requestData), function (result) {

            hdnFromLocationId.val(result.LocationId);
            lblFromLocation.text(result.LocationCode);
            if (result.rMessage != "") {
                txtDocumentNo.val('').focus();
                ShowMessage(result.rMessage, txtDocumentNo);

            }
        }, ErrorFunction, false);
    }
    return false;
}
function IsDocumentNoDcrDumptcoDocketPincodeExist(txtDocumentNo, documentTypeId, locationId, documentType, useValidate, hdnFromLocationId, lblFromLocation) {
    if (IsObjectNullOrEmpty(documentType)) documentType = 'Document';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;

    //if (txtDocumentNo.val() != "") {
    //    if (parseInt(txtDocumentNo.val().trim().length) != 5) {
    //        ShowMessage('Docket length must be 5');
    //        txtDocumentNo.val('');
    //        txtDocumentNo.focus();
    //        return false;
    //    }
    //}
    if (txtDocumentNo.val() != "") {
        var requestData = { documentTypeId: documentTypeId, documentNo: txtDocumentNo.val(), locationId: locationId };
        AjaxRequestWithPostAndJson(ReplaceUrl('Dcr', 'IsDocumentNoDcrDumptcoExist'), JSON.stringify(requestData), function (result) {

            hdnFromLocationId.val(result.LocationId);
            lblFromLocation.text(result.LocationCode);
            if (result.rMessage != "") {
                txtDocumentNo.val('').focus();
                ShowMessage(result.rMessage, txtDocumentNo);

            }
        }, ErrorFunction, false);
    }
    return false;
}


function IsDocumentNoDcrDumptcoDocketExist(txtDocumentNo, documentTypeId, locationId, documentType, useValidate, hdnFromLocationId, lblFromLocation) {
    if (IsObjectNullOrEmpty(documentType)) documentType = 'Document';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;

    var documentNoLength = 7;
    var requestData = { documentTypeId: documentTypeId };
    AjaxRequestWithPostAndJson(ReplaceUrl('Dcr', 'GetDcrNoLength'), JSON.stringify(requestData), function (result) {
        if (!result.IsNullOrEmpty) {
            documentNoLength = result;
        }
    }, ErrorFunction, false);

    if (txtDocumentNo.val() != "") {
        if (parseInt(txtDocumentNo.val().trim().length) != documentNoLength) {
            ShowMessage('Docket length must be ' + documentNoLength);
            txtDocumentNo.val('');
            txtDocumentNo.focus();
            return false;
        }
    }
    if (txtDocumentNo.val() != "") {
        var requestData = { documentTypeId: documentTypeId, documentNo: txtDocumentNo.val(), locationId: locationId };
        AjaxRequestWithPostAndJson(ReplaceUrl('Dcr', 'IsDocumentNoDcrDumptcoExist'), JSON.stringify(requestData), function (result) {

            hdnFromLocationId.val(result.LocationId);
            lblFromLocation.text(result.LocationCode);
            if (result.rMessage != "") {
                txtDocumentNo.val('').focus();
                ShowMessage(result.rMessage, txtDocumentNo);

            }
        }, ErrorFunction, false);
    }
    return false;
}


function IsDocketNoExistByLocation(txtObj, hdnObj, fieldName, useValidate, locationId) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Docket';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (IsObjectNullOrEmpty(locationId)) locationId = loginLocationId;
    if (txtObj.val() != "") {
        var requestData = { docketNo: txtObj.val(), locationId: locationId };
        AjaxRequestWithPostAndJson(ReplaceUrl('Docket', 'IsDocketNoExistByLocation', 'Operation'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function UserAutoCompleteByLocation(txtName, hdnId, fieldName, locationId, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'User Name';
    if (IsObjectNullOrEmpty(locationId)) locationId = loginLocationId;
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;

    AutoComplete(txtName, ReplaceUrl('User', 'GetAutoCompleteUserListByLocationId'), 'userName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'locationId', Value: locationId }];
    });
}

function IsUserNameExistByLocation(txtName, hdnObj, fieldName, locationId,useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'User Name';
    if (IsObjectNullOrEmpty(locationId)) locationId = loginLocationId;
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtName.val() != "") {
        var requestData = { userName: txtName.val(), locationId: locationId };
        AjaxRequestWithPostAndJson(ReplaceUrl('User', 'IsUserNameExistByLocation'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtName);
                    hdnObj.val('');
                }
                else {
                    txtName.val(result.Name);
                    hdnObj.val(result.Value);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function UserAutoComplete(txtName, hdnId, fieldName, userType, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'User Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (IsObjectNullOrEmpty(userType)) userType = 2;
    AutoComplete(txtName, ReplaceUrl('User', 'GetAutoCompleteUserList'), 'userName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'userTypeId', Value: userType }];
    });
}

function UserCodeAutoComplete(txtName, hdnId, fieldName, userType, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'User Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (IsObjectNullOrEmpty(userType)) userType = 2;
    AutoComplete(txtName, ReplaceUrl('User', 'GetAutoCompleteUserCodeList'), 'userName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'userTypeId', Value: userType }];
    });
}

function IsUserNameExist(txtName, hdnObj, fieldName, userType, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'User Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (IsObjectNullOrEmpty(userType)) userType = 2;
    if (txtName.val() != "") {
        var requestData = { userName: txtName.val(), userTypeId: userType };
        AjaxRequestWithPostAndJson(ReplaceUrl('User', 'IsUserNameExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtName);
                    hdnObj.val('');
                }
                else {
                    txtName.val(result.Name);
                    hdnObj.val(result.Value);
                }
        }, ErrorFunction, false);
    }
    return false;
}
function IsUserCodeExist(txtName, hdnObj,lblObj, fieldName, userType, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'User Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (IsObjectNullOrEmpty(userType)) userType = 2;
    if (txtName.val() != "") {
        var requestData = { userName: txtName.val(), userTypeId: userType };
        AjaxRequestWithPostAndJson(ReplaceUrl('User', 'IsUserCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtName);
                    hdnObj.val('');
                    lblObj.text('');
                    txtName.val('');
                }
                else {
                    txtName.val(result.Name);
                    lblObj.text(result.Description);
                    hdnObj.val(result.Value);
                }
        }, ErrorFunction, false);
    }
    return false;
}
function PincodeAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Pin Code';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Pincode', 'GetAutoCompletePincodeList'), 'PinCode', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}
function IsPincodeExist(txtObj, hdnObj, txtToLocation, hdnToLocationId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Pin Code';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { Pincode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Pincode', 'IsPincodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                    txtObj.val('');
                    txtToLocation.val('');
                    hdnToLocationId.val('');
                }
                else {
                    hdnObj.val(result.PincodeId);
                    txtObj.val(result.Pincode);
                    hdnToLocationId.val(result.LocationId);
                    txtToLocation.val(result.LocationName);

                }
        }, ErrorFunction, false);
    }
    return false;
}
function VehicleAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vehicle', 'GetAutoCompleteVehicleList'), 'vehicleNo', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}

function IsVehicleNoExist(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { VehicleNo: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Vehicle', 'IsVehicleNoExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function VehicleAutoCompleteByLocation(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vehicle', 'GetAutoCompleteVehicleListByLocation'), 'vehicleNo', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'locationId', Value: loginLocationId }];
    });
}
function VehicleAutoCompleteByLocationForTripsheet(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vehicle', 'GetAutoCompleteVehicleListByLocationForTripsheet'), 'vehicleNo', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'locationId', Value: loginLocationId }];
    });
}

function VehicleAutoCompleteByLForTripsheetCloser(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vehicle', 'GetAutoCompleteVehicleListByForTripsheetCloser'), 'TripsheetNo', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'TripsheetAction', Value: TripsheetAction }, { Key: 'searchBy', Value: searchBy }, { Key: 'locationId', Value: loginLocationId }];
    });
}


function IsVehicleNoExistByLocation(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { vehicleNo: txtObj.val(), locationId: loginLocationId };
        AjaxRequestWithPostAndJson(ReplaceUrl('Vehicle', 'IsVehicleNoExistByLocation'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}


function IsVehicleNoExistForTripsheet(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    hdnObj.val(0);
    if (txtObj.val() != "") {
        var requestData = { VehicleNo: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Vehicle', 'IsVehicleNoExistForTripsheet'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val(0);
                    txtObj.val('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function VendorAutoComplete(txtId, hdnId, fieldName, vendorType, useValidate) {

    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vendor';
    if (IsObjectNullOrEmpty(vendorType)) vendorType = '0';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vendor', 'GetAutoCompleteVendorList'), 'vendorCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'vendorTypeId', Value: vendorType }];
    });
}
function VendorAutoCompleteLocationwise(txtId, hdnId, fieldName, vendorType, useValidate) {

    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vendor';
    if (IsObjectNullOrEmpty(vendorType)) vendorType = '0';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vendor', 'GetAutoCompleteVendorListByLocation'), 'vendorCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'vendorTypeId', Value: vendorType }];
    });
}
function VendorAccountAutoComplete(txtId, hdnId, fieldName, vendorType, useValidate) {

    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Account Code';
    if (IsObjectNullOrEmpty(vendorType)) vendorType = '0';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Account', 'GetAutoCompleteVendorAccountList'), 'vendorCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'vendorTypeId', Value: vendorType }];
    });
}

function IsVendorCodeExist(txtObj, hdnObj, lblObj, fieldName, vendorType, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vendor';
    if (IsObjectNullOrEmpty(vendorType)) vendorType = '0';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { vendorCode: txtObj.val(), vendorTypeId: vendorType };
        AjaxRequestWithPostAndJson(ReplaceUrl('Vendor', 'IsVendorCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                    if (lblObj.is('input:text'))
                        lblObj.val('');
                    else
                        lblObj.text('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    if (lblObj.is('input:text'))
                        lblObj.val(result.Description);
                    else
                        lblObj.text(result.Description);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function VendorAutoCompleteByLocation(txtId, hdnId, fieldName, vendorType, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vendor';
    if (IsObjectNullOrEmpty(vendorType)) vendorType = '0';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vendor', 'GetAutoCompleteVendorListByLocation'), 'vendorCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'vendorTypeId', Value: vendorType }];
    });
}

function IsVendorCodeExistByLocation(txtObj, hdnObj, lblObj, fieldName, vendorType, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vendor';
    if (IsObjectNullOrEmpty(vendorType)) vendorType = '0';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { vendorCode: txtObj.val(), vendorTypeId: vendorType };
        AjaxRequestWithPostAndJson(ReplaceUrl('Vendor', 'IsVendorCodeExistByLocation'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                    lblObj.text('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    lblObj.text(result.Description);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function CompanyAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Company Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Company', 'GetAutoCompleteCompanyList'), 'companyCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function IsCompanyCodeExist(txtObj, hdnObj, lblObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Company Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { companyCode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Company', 'IsCompanyCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val('');
                    lblObj.text('');
                    return true;
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    lblObj.text(result.Description);
                    return false;
                }
        }, ErrorFunction, false);
    }
    return false;
}

function CustomerAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Customer', 'GetAutoCompleteCustomerList'), 'customerCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function IsCustomerCodeExist(txtObj, hdnObj, lblObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { customerCode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Customer', 'IsCustomerCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    lblObj.text('');
                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    lblObj.text(result.Description);
                }
        }, ErrorFunction, false);
    }
    else {
        txtObj.val('');
        lblObj.text('');
        hdnObj.val(0);
    }
}

function IsCustomerCodeExistForOrder(txtObj, hdnObj, lblObj, 
                   txtShipToFrom, txtShipToAddress1, txtShipToAddress2, txtShipToAddress3, txtShipToPincode, txtShipToMobileNo, txtShipToEmailId,
                txtBillToFrom, txtBillToAddress1, txtBillToAddress2, txtBillToAddress3, txtBillToPincode, txtBillToMobileNo, txtBillToEmailId
    ) {
    var fieldName = 'Customer Name';
    var useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { customerCode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Customer', 'IsCustomerCodeExistForOrder'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    lblObj.text('');
                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.CustomerId);
                    txtObj.val(result.CustomerCode);
                    lblObj.text(result.CustomerName);

                    txtShipToFrom.val(result.CustomerName);
                    txtShipToAddress1.val(result.ShipToAddress1);
                    txtShipToAddress2.val(result.ShipToAddress2);
                    txtShipToAddress3.val(result.ShipToAddress3);
                    txtShipToPincode.val(result.ShipToPincode);
                    txtShipToMobileNo.val(result.ShipToMobileNo);
                    txtShipToEmailId.val(result.ShipToEmailId);

                    txtBillToFrom.val(result.CustomerName);
                    txtBillToAddress1.val(result.BillToAddress1);
                    txtBillToAddress2.val(result.BillToAddress2);
                    txtBillToAddress3.val(result.BillToAddress3);
                    txtBillToPincode.val(result.BillToPincode);
                    txtBillToMobileNo.val(result.BillToMobileNo);
                    txtBillToEmailId.val(result.BillToEmailId);

                }
        }, ErrorFunction, false);
    }
    else {
        txtObj.val('');
        lblObj.text('');
        hdnObj.val(0);
    }
}

function CustomerAutoCompleteByLocation(txtId, hdnId, locationId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Customer', 'GetAutoCompleteCustomerListByLocation'), 'customerCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'locationId', Value: locationId }];
    });
}

function IsCustomerCodeExistByLocation(txtObj, hdnObj, lblObj, locationId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { customerCode: txtObj.val(), locationId: locationId };
        AjaxRequestWithPostAndJson(ReplaceUrl('Customer', 'IsCustomerCodeExistByLocation'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    lblObj.text('');
                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    lblObj.text(result.Description);
                }
        }, ErrorFunction, false);
    }
}


function CustomerAutoCompleteByLocationPaybas(txtId, hdnId, locationId, paybasId, allowWalkIn, fieldName, useValidate, isGstTypeCustomer) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (IsObjectNullOrEmpty(allowWalkIn)) allowWalkIn = true;
    if (IsObjectNullOrEmpty(isGstTypeCustomer)) isGstTypeCustomer = true;
    AutoComplete(txtId, ReplaceUrl('Customer', 'GetAutoCompleteCustomerListByLocationPaybas'), 'customerName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'locationId', Value: locationId }, { Key: 'paybasId', Value: paybasId == '' ? 0 : paybasId }, { Key: 'allowWalkIn', Value: allowWalkIn }, { Key: 'isGstTypeCustomer', Value: isGstTypeCustomer }];
    });
}

function IsCustomerCodeExistByLocationPaybas(txtObj, hdnObj, lblObj, locationId, paybasId, allowWalkIn, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (IsObjectNullOrEmpty(allowWalkIn)) allowWalkIn = true;
    if (txtObj.val() != "") {
        var requestData = { customerCode: txtObj.val(), locationId: locationId, paybasId: paybasId, allowWalkIn: allowWalkIn };
        AjaxRequestWithPostAndJson(ReplaceUrl('Customer', 'IsCustomerExistByLocationPaybas'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    lblObj.text('');
                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.CustomerId);
                    txtObj.val(result.CustomerCode);
                    lblObj.text(result.CustomerName);
                }
        }, ErrorFunction, false);
    }
}


function ConsigneeAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Consignee Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Customer', 'GetAutocompleteConsigneeList'), 'consigneeName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function StateAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'State Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('State', 'GetAutoCompleteStateList'), 'stateName', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}

function IsStateNameExist(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'State Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { stateName: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('State', 'IsStateNameExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}


function ProductAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Product Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Product', 'GetAutoCompleteProductList'), 'productCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function IsProductCodeExist(txtObj, hdnObj, lblObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Product Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { productCode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Product', 'IsProductCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val(0);
                    lblObj.text('');
                }
                else {
                    hdnObj.val(result.ProductId);
                    txtObj.val(result.ProductCode);
                    lblObj.text(result.ProductName);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function SupplierAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Supplier';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Supplier', 'GetAutoCompleteList'), 'supplierCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function IsSupplierCodeExist(txtObj, hdnObj, lblObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Supplier';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { SupplierCode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Supplier', 'IsSupplierCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);

                    hdnObj.val(0);
                    lblObj.text('');
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    lblObj.text(result.Description);
                }
        }, ErrorFunction, false);
    }
    return false;
}

//function BinAutoComplete(txtId, hdnId, fieldName, useValidate) {
//    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Bin Code';
//    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
//    AutoComplete(txtId, ReplaceUrl('Bins', 'GetAutoCompleteList'), 'binCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
//}

function IsBinCodeExist(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Bin Code';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { binCode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Bins', 'IsBinCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);

                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name + ' : ' + result.Description);
                }
        }, ErrorFunction, false);
    }
}
function LabourAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Labour';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Labour', 'GetAutoCompleteList'), 'labourName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function IsLabourNameExist(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Labour';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { labourName: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Labour', 'IsLabourNameExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);

                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function DriverAutoCompleteByLocation(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Driver';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Driver', 'GetAutoCompleteDriverListByLocation'), 'driverName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function DriverCodeAutoCompleteByLocation(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Driver';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Driver', 'GetAutoCompleteDriverCodeListByLocation'), 'driverName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}




function DriverAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Driver';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Driver', 'GetAutoCompleteDriverList'), 'driverName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function IsDriverNameExistByLocation(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Driver';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { driverName: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Driver', 'IsDriverNameExistByLocation'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);

                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}
function IsDriverCodeExistByLocation(txtObj, hdnObj, lblObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Driver';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { driverName: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Driver', 'IsDriverCodeExistByLocation'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    lblObj.text('');
                    hdnObj.val(0);
                                       
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    lblObj.text(result.Description);
                }
        }, ErrorFunction, false);
    }
    return false;
}




function IsDriverNameExist(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Driver';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { driverName: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Driver', 'IsDriverNameExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);

                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}


function WarehouseAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Warehouse Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Warehouse', 'GetAutoCompleteList'), 'warehouseName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function IsWarehouseNameExist(txtObj, hdnObj, lblObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Warehouse Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { warehouseName: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Warehouse', 'IsWarehouseNameExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);

                    hdnObj.val(0);
                    lblObj.text('');
                    return true;
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    lblObj.text(result.Description);
                    return false;
                }
        }, ErrorFunction, false);
    }
    return false;
}

function AccountAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Account Code';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Account', 'GetAccountAutoCompleteList'), 'accountCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function IsAccountNameExist(txtObj, hdnObj, lblObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Account Code';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    
    if (txtObj.val() != "") {
        var requestData = { accountCode: txtObj.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Account', 'IsAccountCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);

                    hdnObj.val(0);
                    lblObj.text('');
                    return true;
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    lblObj.text(result.Description);
                    return false;
                }
        }, ErrorFunction, false);
    }
    return false;
}

function ReceiverAutoCompleteByLocation(txtName, hdnId, locationId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Receiver Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtName, ReplaceUrl('Receiver', 'GetAutoCompleteReceiverListByLocation'), 'receiverCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'locationId', Value: locationId }];
    });
}

function IsReceiverCodeExistByLocation(txtName, hdnObj, lblObj, locationId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Receiver Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtName.val() != "") {
        var requestData = { receiverCode: txtName.val(), locationId: locationId };
        AjaxRequestWithPostAndJson(ReplaceUrl('Receiver', 'IsReceiverCodeExistByLocation'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtName);
                    hdnObj.val('');
                    lblObj.text('');
                }
                else {
                    txtName.val(result.Name);
                    hdnObj.val(result.Value);
                    lblObj.text(result.Description);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function VehicleAutoCompleteListForJobOrder(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vehicle', 'GetAutoCompleteListForJobOrder'), 'vehicleNo', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'locationId', Value: loginLocationId }];
    });
}

var WMS = {

    IsSkuCodeOnCreateOrderExist: function (txtSkuCode, hdnSkuId, txtSkuName, txtAvailableQuantity, txtUnitPrice) {
        if (txtSkuCode.val() != "") {
            var requestData = { skuCode: txtSkuCode.val().split(':')[0].trim() };
            AjaxRequestWithPostAndJson(ReplaceUrl('Sku', 'IsSkuCodeExist'), JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    hdnSkuId.val(0);
                    txtSkuCode.val('');
                    txtSkuName.val('');
                    txtAvailableQuantity.val('');
                    txtUnitPrice.val('');
                    ShowMessage('Invalid Sku');
                    txtSkuCode.focus();
                    return false;
                }
                else {
                    
                    hdnSkuId.val(result.SkuId);

                    if (txtSkuName != null && txtSkuName != undefined) {
                        txtSkuCode.val(result.SkuCode);
                        txtSkuName.val(result.SkuName);
                    }
                    else
                        txtSkuCode.val(result.SkuCode + ":" + result.SkuName);
                   
                    if (txtAvailableQuantity != null && txtAvailableQuantity != undefined)
                        txtAvailableQuantity.val(result.AvailableQuantity);

                    if (txtUnitPrice != null && txtUnitPrice != undefined)
                        txtUnitPrice.val(result.UnitPrice);

                }
            }, ErrorFunction, false);
        }
        return false;
    },



    IsProductCodeExist: function (txtProductCode, hdnProductId, txtProductName, txtUom, hdnIsSingle, hdnUomQuantity) {
        if (txtProductCode.val() != "") {
            var requestData = { productCode: txtProductCode.val().split(':')[0].trim() };
            AjaxRequestWithPostAndJson(ReplaceUrl('Product', 'IsProductCodeExist'), JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    hdnProductId.val(0);
                    txtProductCode.val('');
                    txtProductName.val('');
                    txtUom.val('');
                    hdnIsSingle.val('');
                    hdnUomQuantity.val('');
                    ShowMessage('Invalid Product');
                    txtProductCode.focus();
                    return false;
                }
                else {
                    hdnProductId.val(result.ProductId);
                    if (txtProductName != null && txtProductName != undefined) {
                        txtProductCode.val(result.ProductCode);
                        txtProductName.val(result.ProductName);
                    }
                    else
                        txtProductCode.val(result.ProductCode + ":" + result.ProductName);
                    if (txtUom != null && txtUom != undefined)
                        txtUom.val(result.UnitsOfMeasurement);
                    if (hdnIsSingle != null && hdnIsSingle != undefined)
                        hdnIsSingle.val(result.IsSingle == null ? '' : result.IsSingle);
                    if (hdnUomQuantity != null && hdnUomQuantity != undefined)
                        hdnUomQuantity.val(result.UomQuantity == null ? '' : result.UomQuantity);
                }
            }, ErrorFunction, false);
        }
        return false;
    },
    ProductAutoComplete: function (txtId, hdnId, fieldName, useValidate) {
        if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Product Name';
        if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
        AutoComplete(txtId, ReplaceUrl('Product', 'GetAutoCompleteProductList'), 'productCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
    },

    SkuAutoComplete: function (txtId, hdnId, fieldName, useValidate) {
        if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Sku Description';
        if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
        AutoComplete(txtId, ReplaceUrl('Sku', 'GetAutoCompleteSkuList'), 'skuCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
    },

    IsSkuCodeExist: function (txtSkuCode, hdnSkuId, txtSkuName, txtUom, txtManufacturingDate,txtUnitPrice, hdnIsSingle, hdnUomQuantity) {
        if (txtSkuCode.val() != "") {
            var requestData = { skuCode: txtSkuCode.val().split(':')[0].trim() };
            AjaxRequestWithPostAndJson(ReplaceUrl('Sku', 'IsSkuCodeExist'), JSON.stringify(requestData), function (result) {
                if (IsObjectNullOrEmpty(result)) {
                    hdnSkuId.val(0);
                    txtSkuCode.val('');
                    txtSkuName.val('');
                    txtUom.val('');
                    txtManufacturingDate.val('');
                    txtUnitPrice.val('');
                    hdnIsSingle.val('');
                    hdnUomQuantity.val('');
                    ShowMessage('Invalid Sku');
                    txtSkuCode.focus();
                    return false;
                }
                else {
                    hdnSkuId.val(result.SkuId);
                    if (txtSkuName != null && txtSkuName != undefined) {
                        txtSkuCode.val(result.SkuCode);
                        txtSkuName.val(result.SkuName);
                    }
                    else
                        txtSkuCode.val(result.SkuCode + ":" + result.SkuName);
                    if (txtUom != null && txtUom != undefined)
                        txtUom.val(result.UnitsOfMeasurement);
                    if (txtManufacturingDate != null && txtManufacturingDate != undefined)
                        txtManufacturingDate.val($.entryDate(result.ManufacturingDate));
                    if (txtUnitPrice != null && txtUnitPrice != undefined)
                        txtUnitPrice.val(result.UnitPrice);
                    if (hdnIsSingle != null && hdnIsSingle != undefined)
                        hdnIsSingle.val(result.IsSingle == null ? '' : result.IsSingle);
                    if (hdnUomQuantity != null && hdnUomQuantity != undefined)
                        hdnUomQuantity.val(result.UomQuantity == null ? '' : result.UomQuantity);

                }
            }, ErrorFunction, false);
        }
        return false;
    },

    IsSupplierCodeExist: function (txtObj, hdnObj, lblObj, fieldName, useValidate) {
        if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Supplier';
        if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
        if (txtObj.val() != "") {
            var requestData = { supplierCode: txtObj.val().split(':')[0].trim() };
            AjaxRequestWithPostAndJson(ReplaceUrl('Supplier', 'IsSupplierCodeExist'), JSON.stringify(requestData), function (result) {
                if (useValidate)
                    if (IsObjectNullOrEmpty(result)) {
                        ShowMessage('Invalid ' + fieldName, txtObj);
                        hdnObj.val('');
                        lblObj.text('');
                    }
                    else {
                        hdnObj.val(result.Value);
                        txtObj.val(result.Name);
                        lblObj.text(result.Description);
                    }
            }, ErrorFunction, false);
        }
        return false;
    }

}

function GetAutoCompleteUserListByRoleId(txtName, hdnId, fieldName, roleId, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'User Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtName, ReplaceUrl('User', 'GetAutoCompleteUserListByRoleId'), 'userName', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'roleId', Value: roleId }];
    });
}

function IsUserNameExistByRoleId(txtName, hdnObj, fieldName, ddlRoleId, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'User Name';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtName.val() != "") {
        var requestData = { userName: txtName.val(), roleId: ddlRoleId.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('User', 'IsUserNameExistByRoleId'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtName);
                    hdnObj.val('');
                }
                else {
                    txtName.val(result.Name);
                    hdnObj.val(result.Value);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function SacAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'SAC Code';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Gst', 'GetAutoCompleteSacList'), 'sacCode', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate);
}

function IsSacCodeExist(txtObj, hdnObj, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'SAC Code';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { sacCode: txtObj.val().split(':')[0].trim() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Gst', 'IsSacCodeExist'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);

                    hdnObj.val(0);
                    return true;
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                    return false;
                }
        }, ErrorFunction, false);
    }
    return false;
}

function VehicleAutoCompleteByVendorTypeByLocation(txtId, hdnId, ddlVendorTypeId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Vehicle', 'GetVehicleListByVendorTypeByLocation'), 'vehicleNo', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'vendorTypeId', Value: ddlVendorTypeId.val() }];
    });
}

function IsVehicleNoExistByVendorTypeByLocation(txtObj, hdnObj,vendorTypeId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Vehicle No';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { vehicleNo: txtObj.val(), vendorTypeId: vendorTypeId.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Vehicle', 'IsVehicleNoExistByVendorTypeByLocation'), JSON.stringify(requestData), function (result) {
            if (useValidate)
                if (IsObjectNullOrEmpty(result)) {
                    ShowMessage('Invalid ' + fieldName, txtObj);
                    hdnObj.val(0);
                }
                else {
                    hdnObj.val(result.Value);
                    txtObj.val(result.Name);
                }
        }, ErrorFunction, false);
    }
    return false;
}

function GstTinNoAutoComplete(txtId, hdnId, fieldName, useValidate, paybasId) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'GstTinNo';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Customer', 'GetAutoCompleteGstTinNo'), 'gstTinNo', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function() {
        return [{ Key: 'paybasId', Value: paybasId == '' ? 0 : paybasId }];
    });
}
function PanNoAndMobileNoAutoComplete(txtId, hdnId, fieldName, useValidate) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'PanNo';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Customer', 'GetAutoCompletePanNoAndMobileNo'), 'panNo', 'l', 'l', 'l', '', '', hdnId, '', fieldName, useValidate);
}

function MobileNoAutoComplete(txtId, hdnId, fieldName, useValidate, paybasId) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'MobileNo';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Customer', 'GetAutoCompleteMobileNo'), 'mobileNo', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function() {
    return [{ Key: 'paybasId', Value: paybasId == '' ? 0 : paybasId }];
    });
}
function PanNoAutoComplete(txtId, hdnId, fieldName, useValidate, paybasId) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'PanNo';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    AutoComplete(txtId, ReplaceUrl('Customer', 'GetAutoCompletePanNo'), 'panNo', 'l', 'l', 'l', 'd', '', hdnId, '', fieldName, useValidate, function () {
        return [{ Key: 'paybasId', Value: paybasId == '' ? 0 : paybasId }];
    });
}
