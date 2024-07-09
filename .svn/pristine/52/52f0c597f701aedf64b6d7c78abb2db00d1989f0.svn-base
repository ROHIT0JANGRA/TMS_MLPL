var isFinancialUpdate = false, useMultipoint = false, isUseEwayBill = false, ewayBillRequiredAmount = 0, isUsePartDetail = false, isReinvokeContract = false, nextDocketNo, dtDocument, dtInvoice, dtPart, dtTax, minimumFreightDetails, freightRateDb, typeOfPackageList, partNoList, dtCharges1, dtCharges2, chargeCount, totalPackages = 0, totalChargedWeight = 0, weightDecimalPlaces = 3, isLoadStep3 = false, consignorName = '', consigneeName = '', isWalkInConsignorSaveInSystem = false, isWalkInConsigneeSaveInSystem = false, txtPopupGstTinNo = '', isRoundOff = false, isBindAllGstState = false, popup, isBillAllowOnlyOnHqtr = false;
var multipointServiceTypeList = [], holidayCheckList = [], taxList = [], gstSacDetails = [];
var rules = {}, cftInfo = {}, contractKeys = {};
var RateTypes = { Flat: "1", PerGram: "2", PerKG: "3", PerQuintal: "4", PerTon: "5", PerPackage: "6", PerKm: "7", PercentageOfFreight: "8", PercentageOfInvoice: "9", PerLiter: "10", PerQuantity: "11", PerQuantityWeight: "12" };
var gstDetails = { IsGst: true, IsRcm: false, GstRate: 18.00, IsInterState: false, CustomerCode: '', CustomerName: '', WalkingGstTinNo: '', DeclarationDocumentName: '', StateList: [] };
var createTripsheet;
var ruleMasterUrl, isPaymentDetailshow = true, useRoundActualWeight = true, useRoundVolumetricWeight = false, useRoundChargeWeight = false, useRoundUpperChargeWeight = false, isChargeWeightReadOnly = true, useVendorTypewiseVehicleSelection = true
    , isCODApplicableFromContractExclude = false;
var customerwithGST;
var partMasterUrl;
var isVolumetricApplicable, isVolumetricApplicable;

$(document).ready(function () {
    SetPageLoad(docketNomenclature, 'Entry');


    if (loginLocationId == 1 && DocketIdExts == false) {
        ShowMessage("Docket Entry Not Allow At HQTR Location, Please Change Location");
        $('.widget-wrap').hide();
    }
    else if ((LocationHierarchyId == 1 || LocationHierarchyId == 2) && DocketIdExts == false) {
        ShowMessage("Docket Entry Not Allow At Regional Location or Head Office Location, Please Change Location");
        $('.widget-wrap').hide();
    }
    else {
        customerwithGST = "N";

        var request = { moduleId: 1, ruleId: 200 };
        AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(request), function (result) {
            customerwithGST = result;
        }, ErrorFunction, false);


        InitObjects();
        AttachEvents();
        LoadStep1();

        if (hdnDocketId.val() != 0) {
            BindLocation();
        }
    }
});

function BindLocation() {

    IsLocationCodeExist(txtToLocation, hdnToLocationId, GetFieldCaptionByName(docketFieldList, 'ToLocation'));

    if (ddlPaybas.val() == "1") {
        IsLocationCodeExistOwnership($('#hdnFromLocationCode'), hdnFromLocationId, 'Billing Location', true, hdnBillLocationId, txtBillLocation);
    }
    else if (ddlPaybas.val() == "3") {
        IsLocationCodeExistOwnership(txtToLocation, hdnToLocationId, 'Billing Location', true, hdnBillLocationId, txtBillLocation);
    }
}
function InitObjects() {
    /*step 1 object initialization*/dvEntryType = $('#dvEntryType'); divDisplayDocketNo = $('#divDisplayDocketNo'); lblComputerizedEntry = $('#lblComputerizedEntry'); lblManualEntry = $('#lblManualEntry'); dvComputerized = $('#dvComputerized'); dvManual = $('#dvManual'); rdComputerized = $('#rdComputerized'); rdManual = $('#rdManual'); txtDocketNo = $('#txtDocketNo'); hdnDocketId = $('#hdnDocketId'); lblDocketNo = $('#lblDocketNo'); hdnDocketNo = $('#hdnDocketNo'); chkIsOld = $('#chkIsOld'); dvIsOld = $('#dvIsOld'); txtDocketDateTime = $('#txtDocketDateTime'); ddlPaybas = $('#ddlPaybas'); txtCustomerCode = $('#txtCustomerCode'); lblCustomerName = $('#lblCustomerName'); hdnCustomerId = $('#hdnCustomerId'); txtToLocation = $('#txtToLocation'); hdnToLocationId = $('#hdnToLocationId'); hdnVehicleId = $('#hdnVehicleId'); txtVehicleNo = $('#txtVehicleNo'); dvStep1 = $('#dvStep1'); btnStep1 = $('#btnStep1'); hdnUsePreviousHistory = $('#hdnUsePreviousHistory'); hdnIsFinancialUpdate = $('#hdnIsFinancialUpdate');
    /*step 2 object initialization*/dvConsignorType = $('#dvConsignorType'); dvConsignorFromMaster = $('#dvConsignorFromMaster'); dvConsignorWalkin = $('#dvConsignorWalkin'); rdConsignorFromMaster = $('#rdConsignorFromMaster'); rdConsignorWalkin = $('#rdConsignorWalkin'); dvConsignorGst = $('#dvConsignorGst'); hdnConsignorGstId = $('#hdnConsignorGstId'); txtConsignorGstTinNo = $('#txtConsignorGstTinNo'); dvConsignorGroupCode = $('#dvConsignorGroupCode'); ddlConsignorGroupCode = $('#ddlConsignorGroupCode'); hdnConsignorId = $('#hdnConsignorId'); txtConsignorCode = $('#txtConsignorCode'); txtConsignorName = $('#txtConsignorName'); txtConsignorAddressCode = $('#txtConsignorAddressCode'); hdnConsignorAddressId = $('#hdnConsignorAddressId'); txtConsignorAddress1 = $('#txtConsignorAddress1'); txtConsignorAddress2 = $('#txtConsignorAddress2'); hdnConsignorCityId = $('#hdnConsignorCityId '); txtConsignorCity = $('#txtConsignorCity'); txtConsignorPincode = $('#txtConsignorPincode'); txtConsignorMobileNo = $('#txtConsignorMobileNo'); txtConsignorEmailId = $('#txtConsignorEmailId'); dvConsigneeType = $('#dvConsigneeType'); dvConsigneeFromMaster = $('#dvConsigneeFromMaster'); dvConsigneeWalkin = $('#dvConsigneeWalkin'); rdConsigneeFromMaster = $('#rdConsigneeFromMaster'); rdConsigneeWalkin = $('#rdConsigneeWalkin'); dvConsigneeGst = $('#dvConsigneeGst'); hdnConsigneeGstId = $('#hdnConsigneeGstId'); txtConsigneeGstTinNo = $('#txtConsigneeGstTinNo'); dvConsigneeGroupCode = $('#dvConsigneeGroupCode'); ddlConsigneeGroupCode = $('#ddlConsigneeGroupCode'); hdnConsigneeId = $('#hdnConsigneeId'); txtConsigneeCode = $('#txtConsigneeCode'); txtConsigneeName = $('#txtConsigneeName'); txtConsigneeAddressCode = $('#txtConsigneeAddressCode'); hdnConsigneeAddressId = $('#hdnConsigneeAddressId'); txtConsigneeAddress1 = $('#txtConsigneeAddress1'); txtConsigneeAddress2 = $('#txtConsigneeAddress2'); hdnConsigneeCityId = $('#hdnConsigneeCityId '); txtConsigneeCity = $('#txtConsigneeCity'); txtConsigneePincode = $('#txtConsigneePincode'); txtConsigneeMobileNo = $('#txtConsigneeMobileNo'); txtConsigneeEmailId = $('#txtConsigneeEmailId'); ddlMappingBillingPartyId = $('#ddlMappingBillingPartyId'); dvStep2 = $('#dvStep2'); btnStep2 = $('#btnStep2');
    /*step 3 object initialization*/lblBillingPartyCode = $('#lblBillingPartyCode'), lblBillingPartyName = $('#lblBillingPartyName'), hdnBillingPartyId = $('#hdnBillingPartyId'), dvBillingParty = $('#dvBillingParty'), ddlTransportMode = $('#ddlTransportMode'); ddlServiceType = $('#ddlServiceType'); ddlFtlType = $('#ddlFtlType'); ddlPickupDelivery = $('#ddlPickupDelivery'); ddlPackagingType = $('#ddlPackagingType'); ddlProductType = $('#ddlProductType'); ddlBusinessType = $('#ddlBusinessType'); ddlIndustry = $('#ddlIndustry'); ddlLoadType = $('#ddlLoadType'); ddlDivision = $('#ddlDivision'); chkVolumetric = $('#chkVolumetric'); chkPartVolumetric = $('#chkPartVolumetric'); chkOda = $('#chkOda'); chkCod = $('#chkCod'); chkDacc = $('#chkDacc'); chkLocal = $('#chkLocal'); chkPermit = $('#chkPermit'); chkDeferment = $('#chkDeferment'); chkServiceTaxExempted = $('#chkServiceTaxExempted'); txtFromCity = $('#txtFromCity'); txtToCity = $('#txtToCity'); hdnFromCityId = $('#hdnFromCityId'); hdnToCityId = $('#hdnToCityId'); txtRemarks = $('#txtRemarks'); hdnIsLocal = $('#hdnIsLocal'); chkMultiPickup = $('#chkMultiPickup'); chkMultiDelivery = $('#chkMultiDelivery'); txtMotherDocketNo = $('#txtMotherDocketNo'); hdnMotherDocketId = $('#hdnMotherDocketId'); hdnBillingPartyId = $('#hdnBillingPartyId'); dvStep3 = $('#dvStep3'); btnStep3 = $('#btnStep3');
    /*step 4 object initialization*/rdCarrierRisk = $('#rdCarrierRisk'); rdOwnerRisk = $('#rdOwnerRisk'); txtPolicyNo = $('#txtPolicyNo'); txtPolicyDate = $('#txtPolicyDate'); txtModvatCovers = $('#txtModvatCovers'); txtInternalCovers = $('#txtInternalCovers'); txtCustomerReferenceNo = $('#txtCustomerReferenceNo'); txtCustomerReferenceDate = $('#txtCustomerReferenceDate'); txtCustomerGatepassNo = $('#txtCustomerGatepassNo'); txtCustomerDeliveryNo = $('#txtCustomerDeliveryNo'); txtPrivateMark = $('#txtPrivateMark'); txtTPNo = $('#txtTPNo'); txtEntrysheetNo = $('#txtEntrysheetNo'); txtObdNo = $('#txtObdNo'); txtEngineNo = $('#txtEngineNo'); txtModelNo = $('#txtModelNo'); txtGpsNo = $('#txtGpsNo'); txtChassisNo = $('#txtChassisNo'); hdnContractId = $('#hdnContractId'); hdnFreightContractId = $('#hdnFreightContractId'); dvDocument = $('#dvDocument'); dvPermit1 = $('#dvPermit1'); dvPermit2 = $('#dvPermit2'); txtPermitNo = $('#txtPermitNo'); txtPermitDate = $('#txtPermitDate'); txtPermitValidityDate = $('#txtPermitValidityDate'); txtPermitReceivedDate = $('#txtPermitReceivedDate'); ddlPermitReceivedAt = $('#ddlPermitReceivedAt'); dvStep4 = $('#dvStep4'); btnStep4 = $('#btnStep4');
    /*step 5 object initialization*/dvCft = $('#dvCft'); dvInvoice = $('#dvInvoice'); txtCftRatio = $('#txtCftRatio'); hdnCftRatio = $('#hdnCftRatio'); hdnTotalPackages = $('#hdnTotalPackages'); hdnTotalPartQuantity = $('#hdnTotalPartQuantity'); hdnTotalActualWeight = $('#hdnTotalActualWeight'); hdnTotalChargedWeight = $('#hdnTotalChargedWeight'); dvStep5 = $('#dvStep5'); btnStep5 = $('#btnStep5');
    /*step 6 object initialization*/dvFov = $('#dvFov'); divRiskType = $('#divRiskType'); ddlGstPayer = $('#ddlGstPayer'); txtFreight = $('#txtFreight'); txtFreightRate = $('#txtFreightRate'); ddlRateType = $('#ddlRateType'); lblMinimumFreightMessage = $('#lblMinimumFreightMessage'); dvKm = $('#dvKm'); txtKm = $('#txtKm'); txtBillLocation = $('#txtBillLocation'); hdnBillLocationId = $('#hdnBillLocationId'); hdnIsFreightEnaledDisabled = $('#hdnIsFreightEnaledDisabled'); txtEdd = $('#txtEdd'); txtFov = $('#txtFov'); txtFovRate = $('#txtFovRate'); lblSubTotal = $('#lblSubTotal'); hdnSubTotal = $('#hdnSubTotal'); lblTaxTotal = $('#lblTaxTotal'); hdnTaxTotal = $('#hdnTaxTotal'); hdnTaxPercentageTotal = $('#hdnTaxPercentageTotal'); lblGrandTotal = $('#lblGrandTotal'); hdnGrandTotal = $('#hdnGrandTotal'); dvStep6 = $('#dvStep6'); btnReinvokeContract = $('#btnReinvokeContract'); dvReinvokeContract = $('#dvReinvokeContract'); dvPaymentContractParty = $('#dvPaymentContractParty'); txtPaymentCustomerCode = $('#txtPaymentCustomerCode'); lblPaymentCustomerName = $('#lblPaymentCustomerName'); hdnPaymentCustomerId = $('#hdnPaymentCustomerId'); btnSubmit = $('#btnSubmit');
    /*GST initialization*/  dvGstRegister = $('#dvGstRegister'); txtServiceTaxRegisterNo = $('#txtServiceTaxRegisterNo'); txtLocalServiceTaxRegisterNo = $('#txtLocalServiceTaxRegisterNo'); lblGstBillingParty = $('#lblGstBillingParty'); hdnWalkingGstTinNo = $('#hdnWalkingGstTinNo'); hdnWalkinCode = $('#hdnWalkinCode'); hdnIsGst = $('#hdnIsGst'); hdnIsRcm = $('#hdnIsRcm'); ddlGstState = $('#ddlGstState'); hdnGstStateId = $('#hdnGstStateId'); hdnGstTinNo = $('#hdnGstTinNo'); txtPartyGstTinNo = $('#txtPartyGstTinNo'); hdnPartyGstId = $('#hdnPartyGstId'); ddlCompanyGstState = $('#ddlCompanyGstState'); chkIsGst = $('#chkIsGst'); ddlGstServiceType = $('#ddlGstServiceType'); dvddlGstServiceType = $('#dvddlGstServiceType'); hdnGstServiceTypeId = $('#hdnGstServiceTypeId'); hdnGstExemptionDeclarationFileName = $('#hdnGstExemptionDeclarationFileName'); hdnIsGst = $('#hdnIsGst'); lblFromLocation = $('#lblFromLocation'); hdnFromLocationId = $('#hdnFromLocationId'); hdnWalkingGstTinNo = $('#hdnWalkingGstTinNo'); lblGstBillingParty = $('#lblGstBillingParty'); ddlCompanyGstState = $('#ddlCompanyGstState'); hdnCompanyGstStateId = $('#hdnCompanyGstStateId'); hdnCompanyGstTinNo = $('#hdnCompanyGstTinNo'); hdnGstStateId = $('#hdnGstStateId'); lblTransportMode = $('#lblTransportMode'); lblGstSacName = $('#lblGstSacName'); hdnGstSacId = $('#hdnGstSacId'); lblGstServiceType = $('#lblGstServiceType'); hdnGstServiceTypeId = $('#hdnGstServiceTypeId'); rdTransporter = $('#rdTransporter'); rdBillingParty = $('#rdBillingParty'); txtPartyGstTinNo = $('#txtPartyGstTinNo'); txtCompanyGstTinNo = $('#txtCompanyGstTinNo'); hdnPartyGstId = $('#hdnPartyGstId'); hdnCompanyGstId = $('#hdnCompanyGstId'); hdnDeclarationFileName = $('#hdnDeclarationFileName'); txtGstRate = $('#txtGstRate'); txtGstAmount = $('#txtGstAmount'); lblIsRcm = $('#lblIsRcm'); txtGstCharge = $('#txtGstCharge'); lblIsInterState = $('#lblIsInterState'); hdnIsInterState = $('#hdnIsInterState'); dvGstTinNoDetail = $('#dvGstTinNoDetail'); dvRegisterGstDetail = $('#dvRegisterGstDetail');
}

function AttachEvents() {
    chkIsOld.change(function () { if (chkIsOld.IsChecked) { txtDocketNo.val(''); txtDocketNo.off("blur"); } else { txtDocketNo.val(''); txtDocketNo.blur(function () { IsDocumentNoExist($(this), 1, loginLocationId, GetFieldCaptionByName(docketFieldList, 'DocketNo')) }); } });
    rdComputerized.click(ManageEntryType);
    rdManual.click(ManageEntryType);
    txtDocketNo.blur(function () {
        ////IsDocumentNoDcrDumptcoDocketExist($(this), 1, loginLocationId, GetFieldCaptionByName(docketFieldList, 'DocketNo'), true, hdnFromLocationId, lblFromLocation)
        IsDocumentNoDcrDumptcoExist($(this), 1, loginLocationId, GetFieldCaptionByName(docketFieldList, 'DocketNo'), true, hdnFromLocationId, lblFromLocation)
    });

    txtDocketDateTime.blur(function () { CheckHoliday(); });
    ddlPaybas.change(ManageParty).change(function () {
        CheckValidCustomerCode(false, false, 'Contract Party');
        ManageMappedBillingParty();
    });

    if (customerwithGST == "Y") {
        docketScript.CustomerAutoCompleteWithGST('txtCustomerCode', 'lblCustomerName', 'hdnCustomerId', 'Contract Party', 'ContractParty', true);
        txtCustomerCode.blur(function () { CheckValidCustomerCodeWithGST(true, true, 'Contract Party'); });
    }
    else {
        docketScript.CustomerAutoComplete('txtCustomerCode', 'lblCustomerName', 'hdnCustomerId', 'Contract Party', 'ContractParty', true);
        txtCustomerCode.blur(function () { CheckValidCustomerCode(true, true, 'Contract Party'); });
    }

    docketScript.CustomerAutoComplete('txtPaymentCustomerCode', 'lblPaymentCustomerName', 'hdnPaymentCustomerId', 'Contract Party', 'Consignor', true);
    txtPaymentCustomerCode.blur(function () {
        CheckValidCustomerCode(true, true, 'Contract Party', 'Consignor')
        if (hdnPaymentCustomerId.val() > 0) {
            var requestData = { CustomerId: hdnPaymentCustomerId.val(), PaybasId: ddlPaybas.val(), DocketDate: $.setDateTime(txtDocketDateTime.val()) };
            AjaxRequestWithPostAndJson(baseUrl + '/GetCustomerContractByCustomerId', JSON.stringify(requestData), function (responseData) {
                if (!responseData.IsNullOrEmpty) {
                    hdnContractId.val(responseData.ContractId);
                    hdnCustomerId.val(hdnPaymentCustomerId.val());
                    ddlGstPayer.change();
                }
            }, ErrorFunction, false);
        }
    });

    LocationAutoCompleteDocketEntry('txtToLocation', 'hdnToLocationId', GetFieldCaptionByName(docketFieldList, 'ToLocation'));
    txtToLocation.blur(function () {

        BindLocation();
        //IsLocationCodeExist(txtToLocation, hdnToLocationId, GetFieldCaptionByName(docketFieldList, 'ToLocation'));

        //if (ddlPaybas.val() == "1")
        //{

        //    IsLocationCodeExistOwnership($('#hdnFromLocationCode'), hdnFromLocationId, 'Billing Location', true, hdnBillLocationId, txtBillLocation);
        //}
        //else if (ddlPaybas.val() == "3") {

        //    IsLocationCodeExistOwnership(txtToLocation, hdnToLocationId, 'Billing Location', true, hdnBillLocationId, txtBillLocation);
        //}
    });
    if (!IsObjectNullOrEmpty(GetUrlValue()["isFinancialUpdate"])) if (GetUrlValue()["isFinancialUpdate"].toBool()) isFinancialUpdate = true;
    hdnIsFinancialUpdate.val(isFinancialUpdate);
    dvStep1.showHide(!isFinancialUpdate);


    btnStep1.click(function () {

        if (hdnDocketId.val() == 0) {
            if (ddlPaybas.val() == 2) {
                if (hdnCustomerId.val() == 1) {
                    ShowMessage("Walkin Customer are not allowed");
                    isStepValid = false;
                    return false;
                }
            }
        }


        if (IsStepValid(dvStep1)) {
            LoadStep2();
        }

    });
    rdConsignorFromMaster.click(ManageConsignorType); rdConsignorWalkin.click(ManageConsignorType);
    rdConsigneeFromMaster.click(ManageConsigneeType); rdConsigneeWalkin.click(ManageConsigneeType);
    docketScript.CustomerAutoComplete('txtConsignorCode', 'txtConsignorName', 'hdnConsignorId', GetFieldCaptionByName(docketFieldList, 'Consignor'), 'Consignor', false);
    docketScript.CustomerAutoComplete('txtConsigneeCode', 'txtConsigneeName', 'hdnConsigneeId', GetFieldCaptionByName(docketFieldList, 'Consignee'), 'Consignee', false);
    txtConsignorCode.blur(function () {
        docketScript.CheckValidCustomerCode(txtConsignorCode, txtConsignorName, hdnConsignorId, 'Consignor', GetFieldCaptionByName(docketFieldList, 'Consignor'), false, true, txtConsignorAddress1, txtConsignorAddress2, hdnConsignorCityId, txtConsignorCity, txtConsignorPincode, txtConsignorMobileNo, txtConsignorEmailId, txtConsignorGstTinNo);
        GetMappedBillingParty();
    });

    txtConsigneeCode.blur(function () {
        docketScript.CheckValidCustomerCode(txtConsigneeCode, txtConsigneeName, hdnConsigneeId, 'Consignee', GetFieldCaptionByName(docketFieldList, 'Consignee'), false, true, txtConsigneeAddress1, txtConsigneeAddress2, hdnConsigneeCityId, txtConsigneeCity, txtConsigneePincode, txtConsigneeMobileNo, txtConsigneeEmailId, txtConsigneeGstTinNo);
        GetMappedBillingParty();
    });
    docketScript.AddressCodeAutoCompleteByCustomer('txtConsignorAddressCode', 'txtConsignorAddressCode', 'hdnConsignorAddressId', GetFieldCaptionByName(docketFieldList, 'Consignor') + ' Address Code', hdnConsignorId);
    txtConsignorAddressCode.blur(function () { docketScript.CheckValidAddressCodeByCustomer(txtConsignorAddressCode, hdnConsignorAddressId, 'Consignor', GetFieldCaptionByName(docketFieldList, 'Consignor'), hdnConsignorId, txtConsignorCode, txtConsignorName, txtConsignorAddress1, txtConsignorAddress2, hdnConsignorCityId, txtConsignorCity, txtConsignorPincode, txtConsignorMobileNo, txtConsignorEmailId, txtConsignorGstTinNo); });
    docketScript.AddressCodeAutoCompleteByCustomer('txtConsigneeAddressCode', 'txtConsigneeAddressCode', 'hdnConsigneeAddressId', GetFieldCaptionByName(docketFieldList, 'Consignee') + ' Address Code', hdnConsigneeId);
    txtConsigneeAddressCode.blur(function () { docketScript.CheckValidAddressCodeByCustomer(txtConsigneeAddressCode, hdnConsigneeAddressId, 'Consignee', GetFieldCaptionByName(docketFieldList, 'Consignee'), hdnConsigneeId, txtConsigneeCode, txtConsigneeName, txtConsigneeAddress1, txtConsigneeAddress2, hdnConsigneeCityId, txtConsigneeCity, txtConsigneePincode, txtConsigneeMobileNo, txtConsigneeEmailId, txtConsigneeGstTinNo); });
    CityAutoComplete('txtConsignorCity', 'hdnConsignorCityId', GetFieldCaptionByName(docketFieldList, 'Consignor') + ' City');
    CityAutoComplete('txtConsigneeCity', 'hdnConsigneeCityId', GetFieldCaptionByName(docketFieldList, 'Consignee') + ' City');
    txtConsignorCity.blur(function () { return IsCityNameExist(txtConsignorCity, hdnConsignorCityId, GetFieldCaptionByName(docketFieldList, 'Consignor') + ' City') });
    txtConsigneeCity.blur(function () { return IsCityNameExist(txtConsigneeCity, hdnConsigneeCityId, GetFieldCaptionByName(docketFieldList, 'Consignee') + ' City') });
    txtConsignorGstTinNo.blur(function () { return GetCustomerDetailByGstTinNo(txtConsignorGstTinNo, txtConsignorCode, txtConsignorName, hdnConsignorId, 'Consignor', GetFieldCaptionByName(docketFieldList, 'Consignor'), false, true, txtConsignorAddress1, txtConsignorAddress2, hdnConsignorCityId, txtConsignorCity, txtConsignorPincode, txtConsignorMobileNo, txtConsignorEmailId, txtConsignorGstTinNo); });
    txtConsigneeGstTinNo.blur(function () { return GetCustomerDetailByGstTinNo(txtConsigneeGstTinNo, txtConsigneeCode, txtConsigneeName, hdnConsigneeId, 'Consignee', GetFieldCaptionByName(docketFieldList, 'Consignee'), false, true, txtConsigneeAddress1, txtConsigneeAddress2, hdnConsigneeCityId, txtConsigneeCity, txtConsigneePincode, txtConsigneeMobileNo, txtConsigneeEmailId, txtConsigneeGstTinNo); });
    btnStep2.click(function () {

        if (ddlPaybas.val() == 2) {
            if (rdConsignorWalkin.IsChecked == true && rdConsigneeWalkin.IsChecked == true) {
                ShowMessage("Consignor & Consignee both should not be Walkin");
                isStepValid = false;
                return false;
            }
        }

        if (IsStepValid(dvStep2)) {
            LoadStep3();
        }
    });

    ddlServiceType.change(ManageFtlType).change(ManageMultipointPickupDelivery);
    CityAutoComplete('txtFromCity', 'hdnFromCityId', 'From City');
    CityAutoComplete('txtToCity', 'hdnToCityId', 'To City');
    txtFromCity.blur(function () { return IsCityNameExist(txtFromCity, hdnFromCityId, 'From City') });
    txtToCity.blur(function () { return IsCityNameExist(txtToCity, hdnToCityId, 'To City') });
    //chkPermit.change(function () { if (chkPermit.IsChecked) EnableStep(3); else DisableStep(3); });
    txtMotherDocketNo.blur(function () { IsDocketNoExistByBillingParty($(this), hdnMotherDocketId, GetFieldCaptionByName(docketFieldList, 'DocketNo'), true, hdnCustomerId.val()) });

    btnStep3.click(function () { if (IsStepValid(dvStep3)) if (chkPermit.IsChecked) LoadStep4(); else LoadStep5(); });
    rdCarrierRisk.check(true);
    btnStep4.click(function () { if (IsStepValid(dvStep4)) LoadStep5(); });

    $('#txtCftRatio').blur(ValidateCftRatio).change(function () { InvoiceCalculation('txtInvoiceAmount') });
    var sizeArr = [[0, '100px'], [1, '160px'], [2, '150px'], [3, '80px'], [4, '80px'], [5, '80px'], [6, '85px'], [7, '100px'], [8, '160px'], [9, '160px'], [12, '100px'], [13, '100px']];
    InitGrid('dtInvoice', false, 99, InitInvoiceTable, false, sizeArr);
    InitPartDataTable();
    btnStep5.click(function () {
        if (IsStepValid(dvStep5))
            LoadStep6();
    });

    dvReinvokeContract.hide();
    dvPaymentContractParty.hide();
    btnReinvokeContract.click(function () { isReinvokeContract = true; LoadStep6(); });
    dvStep6.showHide(isFinancialUpdate);
    LocationAutoComplete('txtBillLocation', 'hdnBillLocationId', 'Billing Location');
    txtBillLocation.blur(function () { IsLocationCodeExist(txtBillLocation, hdnBillLocationId, 'Billing Location'); });
    txtFreightRate.blur(function () { CalculateFreight('Rate'); });
    txtFreight.blur(function () { CalculateFreight(); });
    ddlRateType.change(function () { CalculateFreight('RateType'); });
    ddlGstPayer.change(function () { SetBillingPartyGstTinNo(ddlGstPayer.val()); });
    ddlGstServiceType.change(function () { OnGstServiceTypeChange(); });
    chkIsGst.change(function () { ManageGstExemption(); });
    txtFovRate.blur(function () { CalculateFov(); });
    txtPartyGstTinNo.blur(function () { hdnGstTinNo.val(txtPartyGstTinNo.val()) });
    btnSubmit.click(function () {
        if (IsStepValid(dvStep6))
            if (ValidateOnSubmit())
                return true;
            else
                return false;
        else
            return false;
    });

    var request = { moduleId: 1, ruleId: 57 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(request), function (result) {
        useRoundActualWeight = (result == "N" ? false : true);
    }, ErrorFunction, false);
}



function VendorTypeChange() {
    txtVehicleNo.val('');
    if ($('#ddlVendorTypeId').val() != "1" && $('#ddlVendorTypeId').val() != "") {
        VehicleAutoCompleteByVendorTypeByLocation('txtVehicleNo', 'hdnVehicleId', $('#ddlVendorTypeId'));
        txtVehicleNo.blur(function () {
            IsVehicleNoExistByVendorTypeByLocation(txtVehicleNo, hdnVehicleId, $('#ddlVendorTypeId'));
        });
    }
    else {
        txtVehicleNo.unbind("blur");
        txtVehicleNo.autocomplete("destroy");
    }
}

function LoadStep1() {
    rules.IsLocal = step1Details.IsLocal;
    rules.IsHolidayBooking = step1Details.IsHolidayBooking;
    rules.ConsignorConsigneePartyMappingSetting = step1Details.ConsignorConsigneePartyMappingSetting;
    rules.PartySetting = step1Details.PartySetting;
    nextDocketNo = step1Details.DocumentNo;

    lblComputerizedEntry.showHide(step1Details.IsComputerized); lblManualEntry.showHide(step1Details.IsManual);
    if (step1Details.IsComputerized) rdComputerized.click();
    if (step1Details.IsManual && !step1Details.IsComputerized) rdManual.click();

    divDisplayDocketNo.showHide(hdnDocketId.val() != 0);
    dvEntryType.showHide(hdnDocketId.val() == 0);
    dvComputerized.showHide(hdnDocketId.val() == 0);
    dvIsOld.showHide(false);

    if (hdnDocketId.val() == 0)
        ManageEntryType();
    ManageParty();
    CheckValidCustomerCode(false);

    ddlPaybas.val(2).change();
    hdnUsePreviousHistory.val(step1Details.UsePreviousHistory);
    if (hdnDocketId.val() == 0 || hdnDocketId.val() == '') {
        if (hdnUsePreviousHistory.val() == "true") {
            hdnDocketId.val(step1Details.DocketId);
            $('#hdnIsAdd').val(true);
        }
    }

    $('#hdnUseAddressCode').val(step1Details.UseAddressCode);
    useRoundVolumetricWeight = step1Details.IsRoundVolumetricWeight;
    useRoundChargeWeight = step1Details.IsRoundChargeWeight;
    useRoundUpperChargeWeight = step1Details.IsRoundUpperChargeWeight;
    isChargeWeightReadOnly = step1Details.IsChargeWeightReadOnly;
    useVendorTypewiseVehicleSelection = step1Details.UseVendorTypewiseVehicleSelection;
    if (useVendorTypewiseVehicleSelection) {
        $('#ddlVendorTypeId').change(VendorTypeChange);
    }
    else {
        VehicleAutoCompleteByLocation('txtVehicleNo', 'hdnVehicleId');
        txtVehicleNo.blur(function () { CheckValidVehicleNo(txtVehicleNo, hdnVehicleId); });
    }
    if (useVendorTypewiseVehicleSelection == false) {
        $('#dvVendorType').hide();
    }
    isCODApplicableFromContractExclude = step1Details.IsCODApplicableFromContractExclude;

    if ($('#hdnUseAddressCode').val() == "true") {
        $('#dvConsignorAddressCode').show();
        $('#dvConsignorAddress2').show();
        $('#dvConsigneeAddressCode').show();
        $('#dvConsigneeAddress2').show();
    }
    if (hdnDocketId.val() != 0) GetStep1DetailById();
    if (isFinancialUpdate) LoadStep2();
}

function LoadStep2() {
    var requestData = { CustomerId: hdnCustomerId.val(), PaybasId: ddlPaybas.val(), DocketDate: $.setDateTime(txtDocketDateTime.val()) };
    isSuccessfull = true;

    AjaxRequestWithPostAndJson(baseUrl + '/GetStep2Detail', JSON.stringify(requestData), function (responseData) {
        dvStep2.showHide(responseData.IsSuccessfull && !isFinancialUpdate);


        dvStep1.pointerEvent(!responseData.IsSuccessfull);
        if (!responseData.IsSuccessfull) {
            ShowMessage(responseData.ErrorMessage);
            isStepValid = false;
            return false;
        }
        hdnContractId.val(responseData.ContractId);
        BindDropDownList('ddlConsignorGroupCode', responseData.CustomerGroupList, 'Value', 'Name', '', 'Select Group Code', 'C0001');
        BindDropDownList('ddlConsigneeGroupCode', responseData.CustomerGroupList, 'Value', 'Name', '', 'Select Group Code', 'C0001');
        dvConsignorGroupCode.showHide(responseData.IsWalkInConsignorSaveInSystem);
        dvConsigneeGroupCode.showHide(responseData.IsWalkInConsigneeSaveInSystem);
        dvConsignorGst.showHide(responseData.IsUseGstTinNoInConsignorConsignee);
        dvConsigneeGst.showHide(responseData.IsUseGstTinNoInConsignorConsignee);
        rules.IsWalkInConsignorSaveInSystem = responseData.IsWalkInConsignorSaveInSystem;
        rules.IsWalkInConsigneeSaveInSystem = responseData.IsWalkInConsigneeSaveInSystem;
        dvConsignorType.showHide(!responseData.IsConsignorFromMaster);
        dvConsigneeType.showHide(!responseData.IsConsigneeFromMaster);



        if (responseData.IsConsignorFromMaster)
            rdConsignorFromMaster.check().click();
        else
            ManageDefaultSelection(responseData.ConsignorDefaultSelection, rdConsignorFromMaster, rdConsignorWalkin);


        if (responseData.IsConsigneeFromMaster)
            rdConsigneeFromMaster.check().click();
        else
            ManageDefaultSelection(responseData.ConsigneeDefaultSelection, rdConsigneeFromMaster, rdConsigneeWalkin);
    }, ErrorFunction, false);

    if (hdnDocketId.val() != 0) GetStep2DetailById();
    if (isFinancialUpdate) LoadStep3();

}

function LoadStep3() {
    ManageLocal();
    ManageCustomerSaveInSystem();

    var requestData = {
        ContractId: hdnContractId.val(), PaybasId: ddlPaybas.val(), CustomerId: hdnCustomerId.val(), DocketDate: $.setDateTime(txtDocketDateTime.val()),
        FromLocationId: hdnFromLocationId.val(), ToLocationId: hdnToLocationId.val(), ConsignorId: hdnConsignorId.val(), ConsigneeId: hdnConsigneeId.val(), ConsignorGroupCode: ddlConsignorGroupCode.val(), ConsignorName: txtConsignorName.val(), ConsignorAddress1: txtConsignorAddress1.val(), ConsignorAddress2: txtConsignorAddress2.val(), ConsignorCityId: hdnConsignorCityId.val(), ConsignorPincode: txtConsignorPincode.val(), ConsignorMobileNo: txtConsignorMobileNo.val(), ConsignorEmailId: txtConsignorEmailId.val(), ConsignorGstTinNo: txtConsignorGstTinNo.val(), ConsigneeGroupCode: ddlConsigneeGroupCode.val(), ConsigneeName: txtConsigneeName.val(), ConsigneeAddress1: txtConsigneeAddress1.val(), ConsigneeAddress2: txtConsigneeAddress2.val(), ConsigneeCityId: hdnConsigneeCityId.val(), ConsigneePincode: txtConsigneePincode.val(), ConsigneeMobileNo: txtConsigneeMobileNo.val(), ConsigneeEmailId: txtConsigneeEmailId.val(), ConsigneeGstTinNo: txtConsigneeGstTinNo.val(), MappingBillingPartyId: ddlMappingBillingPartyId.val(),
        IsConsignorConsigneePartyMapping: rules.IsConsignorConsigneePartyMapping, IsConsignorFromMaster: rdConsignorFromMaster.IsChecked, IsConsigneeFromMaster: rdConsigneeFromMaster.IsChecked, IsWalkInConsignorSaveInSystem: isWalkInConsignorSaveInSystem, IsWalkInConsigneeSaveInSystem: isWalkInConsigneeSaveInSystem, EntryBy: loginUserId, CompanyId: loginCompanyId
    };
    isLoadStep3 = true;
    isSuccessfull = true;
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep3Detail', JSON.stringify(requestData), function (responseData) {
        dvStep3.showHide(responseData.IsSuccessfull && !isFinancialUpdate);
        dvStep2.pointerEvent(!responseData.IsSuccessfull);
        if (!responseData.IsSuccessfull && !isFinancialUpdate) {
            ShowMessage(responseData.ErrorMessage);
            isStepValid = false;
            return false;
        }

        hdnContractId.val(responseData.ContractId);

        dvBillingParty.showHide(ddlPaybas.val() == "2" && rules.IsConsignorConsigneePartyMapping);
        if (ddlPaybas.val() == "2" && rules.IsConsignorConsigneePartyMapping) {
            txtCustomerCode.val(responseData.CustomerCode);
            lblCustomerName.text(responseData.CustomerName);
            hdnCustomerId.val(responseData.CustomerId);
            hdnBillingPartyId.val(responseData.CustomerId);
            lblBillingPartyCode.text(responseData.CustomerCode);
            lblBillingPartyName.text(responseData.CustomerName);

        }
        else {
            if (ddlPaybas.val() == '1') {
                if (txtCustomerCode.val() != '') {
                    hdnBillingPartyId.val(hdnCustomerId.val());
                    lblBillingPartyCode.text(txtCustomerCode.val());
                    lblBillingPartyName.text(lblCustomerName.text());

                }
                else {
                    if (rdConsignorFromMaster.IsChecked) {
                        hdnBillingPartyId.val(hdnConsignorId.val());
                        lblBillingPartyCode.text(txtConsignorCode.val());
                        lblBillingPartyName.text(txtConsignorName.val());

                    }
                    else
                        if (!rules.IsWalkInConsignorSaveInSystem) {
                            hdnBillingPartyId.val(hdnConsignorId.val());
                            lblBillingPartyCode.text(txtConsignorCode.val());
                            lblBillingPartyName.text(txtConsignorName.val());

                        }
                        else {
                            hdnBillingPartyId.val(responseData.ConsignorId);
                            lblBillingPartyCode.text(responseData.ConsignorCode);
                            lblBillingPartyName.text(txtConsignorName.val());

                        }
                }
            }
            else if (ddlPaybas.val() == '2') {
                if (txtCustomerCode.val() != '') {
                    hdnBillingPartyId.val(hdnCustomerId.val());
                    lblBillingPartyCode.text(txtCustomerCode.val());
                    lblBillingPartyName.text(lblCustomerName.text());

                }
            }
            else if (ddlPaybas.val() == '3') {
                if (txtCustomerCode.val() != '') {
                    hdnBillingPartyId.val(hdnCustomerId.val());
                    lblBillingPartyCode.text(txtCustomerCode.val());
                    lblBillingPartyName.text(lblCustomerName.text());

                }
                else {
                    if (rdConsigneeFromMaster.IsChecked) {
                        hdnBillingPartyId.val(hdnConsigneeId.val());
                        lblBillingPartyCode.text(txtConsigneeCode.val());
                        lblBillingPartyName.text(txtConsigneeName.val());

                    }
                    else
                        if (!rules.IsWalkInConsignorSaveInSystem) {
                            hdnBillingPartyId.val(hdnConsigneeId.val());
                            lblBillingPartyCode.text(txtConsigneeCode.val());
                            lblBillingPartyName.text(txtConsigneeName.val());

                        }
                        else {
                            hdnBillingPartyId.val(responseData.ConsigneeId);
                            lblBillingPartyCode.text(responseData.ConsigneeCode);
                            lblBillingPartyName.text(txtConsigneeName.val());

                        }
                }
            }
            else if (ddlPaybas.val() == '4')
                if (txtCustomerCode.val() != '') {
                    hdnBillingPartyId.val(hdnCustomerId.val());
                    lblBillingPartyCode.text(txtCustomerCode.val());
                    lblBillingPartyName.text(lblCustomerName.text());

                }
        }

        gstDetails.CustomerId = hdnBillingPartyId.val();
        gstDetails.CustomerCode = lblBillingPartyCode.text();
        gstDetails.CustomerName = lblBillingPartyName.text();
        hdnCustomerId.val(hdnBillingPartyId.val());

        BindDropDownList('ddlTransportMode', responseData.TransportModeList, 'Value', 'Name', '', 'Select Transport Mode');
        BindDropDownList('ddlServiceType', responseData.ServiceTypeList, 'Value', 'Name', '', 'Select Service Type');
        BindDropDownList('ddlFtlType', responseData.FtlTypeList, 'Value', 'Name', '', 'Select FTL Type');
        BindDropDownList('ddlPickupDelivery', responseData.PickupDeliveryList, 'Value', 'Name', '', 'Select Pickup Delivery');
        BindDropDownList('ddlPackagingType', responseData.PackagingTypeList, 'Value', 'Name', '', 'Select ' + GetFieldCaptionByName(docketFieldList, 'PackagingTypeId'));
        BindDropDownList('ddlProductType', responseData.ProductTypeList, 'Value', 'Name', '', 'Select ' + GetFieldCaptionByName(docketFieldList, 'ProductTypeId'));
        BindDropDownList('ddlBusinessType', responseData.BusinessTypeList, 'Value', 'Name', '', 'Select ' + GetFieldCaptionByName(docketFieldList, 'BusinessTypeId'));
        BindDropDownList('ddlIndustry', responseData.IndustryList, 'Value', 'Name', '', 'Select ' + GetFieldCaptionByName(docketFieldList, 'IndustryId'));
        BindDropDownList('ddlLoadType', responseData.LoadTypeList, 'Value', 'Name', '', 'Select ' + GetFieldCaptionByName(docketFieldList, 'LoadTypeId'));
        BindDropDownList('ddlDivision', responseData.DivisionList, 'Value', 'Name', '', 'Select ' + GetFieldCaptionByName(docketFieldList, 'DivisionId'));

        chkPermit.check(responseData.IsPermit);
        txtFromCity.val(responseData.FromCity.Name).focusout(); hdnFromCityId.val(responseData.FromCity.Value);
        txtToCity.val(responseData.ToCity.Name).focusout(); hdnToCityId.val(responseData.ToCity.Value);
        rdCarrierRisk.check(responseData.IsCarrierRisk);

        //if (responseData.IsServiceTaxExempted)
        //    chkServiceTaxExempted.check().disable();

        if (responseData.IsDeferement)
            chkDeferment.check().enable();
        else
            chkDeferment.disable();

        $('#dvOda').showHide(responseData.IsOdaApplicable);
        $('#dvCod').showHide(responseData.IsCodApplicable);
        $('#dvDacc').showHide(responseData.IsDaccApplicable);
        $('#chkOda').check(responseData.IsOdaApplicable);
        if (isCODApplicableFromContractExclude) { $('#chkCod').check(false); }
        else { $('#chkCod').check(responseData.IsCodApplicable); }
        $('#chkDacc').check(responseData.IsDaccApplicable);
        $('#dvVolumetric').showHide(responseData.IsVolumetricApplicable);
        isVolumetricApplicable = responseData.IsVolumetricApplicable;
        isPartVolumetricApplicable = responseData.IsPartVolumetricApplicable
        $('#chkVolumetric').check(responseData.IsVolumetricApplicable).enable(responseData.IsVolumetricEnable);
        $('#dvPartVolumetric').showHide(responseData.IsPartVolumetricApplicable)
        $('#chkPartVolumetric').check(responseData.IsPartVolumetricApplicable).enable(responseData.IsPartVolumetricEnable);

        if (!rules.IsLocal || hdnFromLocationId.val() != hdnToLocationId.val())
            chkLocal.uncheck().disable();

        if (responseData.IndustryId > 0)
            ddlIndustry.val(responseData.IndustryId).disable();

        ManageFtlType();
        $('#dvIsPickupThroughSameVehicle').showHide(responseData.IsUsePickupThroughSameVehicle);
        $('#dvIsDeliveryThroughSameVehicle').showHide(responseData.IsUseDeliveryThroughSameVehicle);


        useMultipoint = responseData.IsMultipoint;
        multipointServiceTypeList = responseData.MultipointServiceTypeRule.split(',');
        ManageMultipointPickupDelivery();

        $('#dvPackagingType').showHide(!responseData.IsPartVolumetricApplicable);
        $('#dvProductType').showHide(!responseData.IsPartVolumetricApplicable);

    }, ErrorFunction, false);

    if (hdnDocketId.val() != 0) GetStep3DetailById();

    if (isFinancialUpdate) LoadStep4();
}

function LoadStep4() {
    $('#chkPartVolumetric').enable();
    var requestData = { FromCityId: hdnFromCityId.val(), ToCityId: hdnToCityId.val() };
    isSuccessfull = true;
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep4Detail', JSON.stringify(requestData), function (responseData) {
        dvStep4.showHide(responseData.IsSuccessfull && !isFinancialUpdate);
        dvStep3.pointerEvent(!responseData.IsSuccessfull);
        if (!responseData.IsSuccessfull) {
            ShowMessage(responseData.ErrorMessage);
            isStepValid = false;
            return false;
        }

        BindDropDownList('ddlPermitReceivedAt', responseData.PermitReceivedAtList, 'Value', 'Name', '', 'Select Permit Received At');
        ManagePermitDetails();

        if (dtDocument == null)
            dtDocument = LoadDataTable('dtDocument', false, false, false, null, null, [],
                [
                    { title: 'State Name', data: 'StateName' },
                    { title: 'Document Name', data: 'DocumentName' },
                    { title: 'Document Type', data: 'IsInbound' },
                    { title: 'Document No', data: 'DocumentNo' }
                ]);

        dtDocument.fnClearTable();
        dvDocument.showHide(responseData.DocumentList.length > 0);
        if (responseData.DocumentList.length > 0) {
            $.each(responseData.DocumentList, function (i, item) {
                item.IsInbound = item.IsInbound ? 'Inbound' : 'Outbound';
                item.DocumentNo = "<input type='hidden' value='" + item.StateDocumentId + "' name='DocumentList[" + i + "].StateDocumentId' id='hdnStateDocumentId" + i + "'/>" +
                    '<input class="form-control" data-val="true" data-val-required="Please enter Document No" name="DocumentList[' + i + '].DocumentNo" id="txtDocumentNo' + i + '" type="text" />' +
                    '<span data-valmsg-for="DocumentList[' + i + '].DocumentNo" data-valmsg-replace="true"></span><input name="DocumentList[' + i + '].StateId" type="hidden" />'
            });
            dtDocument.dtAddData(responseData.DocumentList);
            $('input[id*="txtDocumentNo"]').each(function () {
                $(this).rules('add', { required: true, messages: { required: "Please enter Document No" } });
            });
        }

    }, ErrorFunction, false);
    if (hdnDocketId.val() != 0) {
        GetStep4DetailById();
    }
    if (isFinancialUpdate) LoadStep5();
}

function LoadStep5() {
    var requestData = { ContractId: hdnContractId.val(), TransportModeId: ddlTransportMode.val(), InvoiceNo: $('#txtWmsInvoiceNo').val() };
    isSuccessfull = true;
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep5Detail', JSON.stringify(requestData), function (responseData) {
        if (responseData.IsUseEwayBill) {
            $('#lblActualWeight').text('Actual Weight/Liter');
            $('#lblChargedWeight').text('Charged Weight/Liter');
        }
        else {
            $('#lblActualWeight').text('Actual Weight');
            $('#lblChargedWeight').text('Charged Weight');
        }
        dvStep5.showHide(responseData.IsSuccessfull && !isFinancialUpdate);
        dvStep3.pointerEvent(!responseData.IsSuccessfull);
        dvStep4.pointerEvent(!responseData.IsSuccessfull);
        if (!responseData.IsSuccessfull) {
            ShowMessage(responseData.ErrorMessage);
            isStepValid = false;
            return false;
        }

        if (chkVolumetric.IsChecked) {
            if (responseData.CftMeasurementType.IsNullOrEmpty) { responseData.CftMeasurementType = 'I'; txtCftRatio.val(0); $('#hdnCftRatio').val(0); }
            cftInfo = {
                CftRatio: chkVolumetric.IsChecked ? responseData.CftRatio : 0,
                CftMeasurementType: responseData.CftMeasurementType,
                VolumetricWeightType: responseData.VolumetricWeightType,
                CftDimension: responseData.CftDimension
            }
            txtCftRatio.val(cftInfo.CftRatio);
            $('#hdnCftRatio').val(cftInfo.CftRatio);
        }

        if (chkPartVolumetric.IsChecked) {
            var requestData = { consignorId: hdnConsignorId.val(), consigneeId: hdnConsigneeId.val() };
            AjaxRequestWithPostAndJson(partMasterUrl + '/GetPartListByConsignorIdAndConsigneeId', JSON.stringify(requestData), function (responsePartNoList) {
                partNoList = responsePartNoList;
            }, ErrorFunction, false);
        }

        dvCft.showHide(chkVolumetric.IsChecked);
        isUsePartDetail = responseData.IsUsePartDetail;
        ewayBillRequiredAmount = responseData.EwayBillRequiredAmount;
        isUseEwayBill = responseData.IsUseEwayBill;
        typeOfPackageList = responseData.TypeOfPackageList;
        ManageInvoiceGrid();
        isBillAllowOnlyOnHqtr = responseData.IsBillAllowOnlyOnHqtr;

        if (responseData.InvoiceList.length > 0) {
            for (var i = 0; i < responseData.InvoiceList.length - 1; i++) {
                var trLast = $('#dtInvoice > tbody > tr:last').attr('data-row-id', '0');
                trLast.find('#btnAdd').click();
            }

            $.each(responseData.InvoiceList, function (i, item) {
                var tr = $('#dtInvoice > tbody > tr:eq(' + i + ')');
                tr.find('[id*="txtInvoiceNo"]').val(item.InvoiceNo);
                tr.find('[id*="txtInvoiceAmount"]').val(item.InvoiceAmount);
                tr.find('[id*="txtInvoiceDate"]').val($.entryDate(item.InvoiceDate));
                tr.find('[id*="txtLength"]').val(item.Length);
                tr.find('[id*="txtBreadth"]').val(item.Breadth);
                tr.find('[id*="txtHeight"]').val(item.Height);
                tr.find('[id*="txtPackages"]').val(item.Packages);
                tr.find('[id*="txtActualWeight"]').val(item.ActualWeight);
                tr.find('[id*="ddlTypeOfPackage"]').val(item.TypeOfPackage);
            });

            InvoiceCalculation('txtInvoiceAmount');
        }
    }, ErrorFunction, false);

    if (ddlPaybas.val() == 2 && hdnDocketId.val() == 0 && loginUserId != 1) {
        var request = { moduleId: 1, ruleId: 54, paybasId: ddlPaybas.val() };
        AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleIdAndPaybasId', JSON.stringify(request), function (result) {
            isPaymentDetailshow = (result == "N" ? false : true);
        }, ErrorFunction, false);
        if (!isPaymentDetailshow) {
            ddlGstPayer.val(4);
            btnStep5.text('Create Docket');
        }
        else
            btnStep5.text('Step 5');
    }

    if (hdnDocketId.val() != 0) GetStep5DetailById();
    if (isFinancialUpdate) LoadStep6();
}

function LoadStep6() {

    var requestData = {
        DocketDate: moment(txtDocketDateTime.val(), 'DD/MM/YYYY HH:mm'),
        ContractId: hdnContractId.val(), TransportModeId: ddlTransportMode.val() != null ? ddlTransportMode.val() : 2, PaybasId: ddlPaybas.val(), ServiceTypeId: ddlServiceType.val() != null ? ddlServiceType.val() : 1,
        BusinessTypeId: ddlBusinessType.val(), ProductTypeId: ddlProductType.val(), PackagingTypeId: ddlPackagingType.val(), FtlTypeId: ddlFtlType.val(),
        FromLocationId: loginLocationId, ToLocationId: hdnToLocationId.val(), FromCityId: hdnFromCityId.val(), ToCityId: hdnToCityId.val(), ConsignorId: hdnConsignorId.val(), ConsigneeId: hdnConsigneeId.val(),
        ActualWeight: $('#lblTotalActualWeight').text(), ChargedWeight: $('#lblTotalChargedWeight').text(), Packages: $('#lblTotalPackages').text(), InvoiceAmount: $('#lblTotalInvoiceAmount').text(),
        IsOda: chkOda.IsChecked, IsCod: chkCod.IsChecked, IsDacc: chkDacc.IsChecked, IsLocal: chkLocal.IsChecked, IsCarrierRisk: rdCarrierRisk.IsChecked, IsDoorDelivery: ddlPickupDelivery.val() == 2 || ddlPickupDelivery.val() == 4 ? true : false, IsBooking: true, IsMultiPickup: chkMultiPickup.IsChecked, IsMultiDelivery: chkMultiDelivery.IsChecked
    };
    isSuccessfull = true;
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep6Detail', JSON.stringify(requestData), function (responseData) {
        dvStep6.showHide(responseData.Keys.IsSuccessfull && isPaymentDetailshow);
        dvStep5.pointerEvent(!responseData.Keys.IsSuccessfull);
        if (!responseData.Keys.IsSuccessfull) {

            ShowMessage(responseData.Keys.ErrorMessage);
            isStepValid = false;
            return false;
        }
        contractKeys = responseData.Keys;
        hdnFreightContractId.val(contractKeys.FreightContractId);
        gstDetails.IsGst = ddlPaybas.val() != 4 ? responseData.IsGst : false;
        //gstDetails.IsGst = false
        isRoundOff = contractKeys.IsRoundOff;
        hdnIsFreightEnaledDisabled.val(contractKeys.IsFreightEnaledDisabled);
        isBindAllGstState = contractKeys.IsBindAllGstState;
        dvFov.showHide(contractKeys.IsFovChargeApplicable);
        divRiskType.showHide(contractKeys.IsFovChargeApplicable);
        BindDropDownList('ddlGstPayer', responseData.ServiceTaxPayerList, 'Value', 'Name', '', 'Select GST Payer');

        //if (responseData.ServiceTaxPayerList.length > 0)
        //    ddlGstPayer.val(contractKeys.DefaultServiceTaxPayer).enable(contractKeys.IsServiceTaxPayerEnabled);

        /*  SetBillingPartyGstTinNo(contractKeys.DefaultServiceTaxPayer);*/
        taxList = responseData.TaxList.sort(ComparerTax);
        minimumFreightDetails = responseData.MinimumFreightDetails;
        var chargeList = responseData.OtherChargeList.sort(ComparerCharge);
        chargeCount = 0;
        SetOtherCharge(chargeList, dtCharges1, true);
        SetOtherCharge(chargeList, dtCharges2, false);
        BindDropDownList('ddlRateType', responseData.RateTypeList, 'Value', 'Name');

        txtFreight.val(contractKeys.Freight);
        txtFreightRate.val(contractKeys.FreightRate);
        $('#lblMinimumFreightMessage').text(contractKeys.MinimumFreightMessage).blur();
        $('#lblTotalPackages').text(contractKeys.MinimumCalculatedPackage);
        $('#hdnTotalChargedWeight').text(contractKeys.MinimumCalculatedPackage);

        $('#lblTotalChargedWeight').text(contractKeys.MinimumCalculatedChargeWeight);
        $('#hdnTotalChargedWeight').text(contractKeys.MinimumCalculatedChargeWeight);

        if (hdnIsFreightEnaledDisabled.val() == "E") {
            txtFreight.readOnly(false);
            txtFreightRate.readOnly(false);
            ddlRateType.enable();
            $('[id*=txtCharge]').each(function () {
                var txtCharge = $(this);
                if (txtCharge.val() > 0) {
                    txtCharge.readOnly(false);
                }
            });
        }
        else if (hdnIsFreightEnaledDisabled.val() == "D") {
            txtFreight.readOnly(true);
            txtFreightRate.readOnly(true);
            ddlRateType.disable();
            $('[id*=txtCharge]').each(function () {
                var txtCharge = $(this);
                if (txtCharge.val() > 0) {
                    if (hdnDocketId.val() == 0)
                        txtCharge.readOnly(true);
                    else
                        txtCharge.readOnly(false);
                }
            });
        }
        else if (hdnIsFreightEnaledDisabled.val() == "C") {
            if (contractKeys.FreightRate > 0) {
                txtFreight.readOnly(true);
                txtFreightRate.readOnly(true);
                ddlRateType.disable();
                $('[id*=txtCharge]').each(function () {
                    var txtCharge = $(this);
                    if (txtCharge.val() > 0) {
                        if (hdnDocketId.val() = 0)
                            txtCharge.readOnly(true);
                        else
                            txtCharge.readOnly(false);
                    }
                });
            }
            else {
                txtFreight.readOnly(false);
                txtFreightRate.readOnly(false);
                ddlRateType.enable();
            }

        }
        freightRateDb = contractKeys.FreightRate;
        ddlRateType.val(contractKeys.RateTypeId == 0 ? $("#ddlRateType option:first").val() : contractKeys.RateTypeId);

        if (ddlPaybas.val() == "2") {
            txtBillLocation.val(contractKeys.BillLocationCode);
            hdnBillLocationId.val(contractKeys.BillLocationId);
            /*txtBillLocation.readOnly(true);*/
        }

        if (isBillAllowOnlyOnHqtr) {
            hdnBillLocationId.val(1);
            txtBillLocation.val('HQTR');
            txtBillLocation.readOnly(true);
        }

        if (isFinancialUpdate)
            txtBillLocation.readOnly(false);

        txtEdd.val(moment(contractKeys.Edd).format('DD/MM/YYYY'));

        if (chkMultiPickup.IsChecked && chkMultiDelivery.IsChecked) {
            txtFreight.val(0).readOnly();
            freightRateDb = 0;
            txtFreightRate.val(0).readOnly();
            ddlRateType.val(1);
            $('#txtRatePerKg').val(0);
            hdnSubTotal.val(0);
        }

        txtFreightRate.blur();
    }, ErrorFunction, false);

    $('#dvGst1').showHide(gstDetails.IsGst);
    $('#dvGst2').showHide(gstDetails.IsGst);
    $('#dvGst3').showHide(gstDetails.IsGst);
    $('#dvGst4').showHide(gstDetails.IsGst);
    $('#dvGst5').showHide(gstDetails.IsGst);
    //ManageFreightRateValidation();
    /*    ddlCompanyGstState.enable(gstDetails.IsGst);*/
    /*   ddlGstState.enable(gstDetails.IsGst);*/

    if (gstDetails.IsGst) {
        hdnIsGst.val(true);
        GetGstRate();
    }

    if (hdnDocketId.val() != 0 && isReinvokeContract == false) GetStep6DetailById();
    txtFreight.val(parseInt(hdnMotherDocketId.val()) > 0 ? 0 : txtFreight.val()).blur();
    txtFreightRate.val(parseInt(hdnMotherDocketId.val()) > 0 ? 0 : txtFreightRate.val());
    $('#lblMinimumFreightMessage').text(parseInt(hdnMotherDocketId.val()) > 0 ? '' : $('#lblMinimumFreightMessage').text());

    if (!isPaymentDetailshow)
        btnSubmit.click();
}

function GetStep1DetailById() {
    if (hdnUsePreviousHistory.val() == "true" && $('#hdnIsAdd').val() == "true")
        SetPageLoad(docketNomenclature.replace('No', ''), 'Entry');
    else
        SetPageLoad(docketNomenclature.replace('No', ''), 'Update');
    var requestData = { docketId: hdnDocketId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep1DetailById', JSON.stringify(requestData), function (result) {

        if (loginLocationId != result.FromLocationId && DocketIdExts == true) {
            if (loginLocationId != 1 && DocketIdExts == true) {

                ShowMessage(docketNomenclature + ' Origin Location is ' + result.FromLocation + '. Please select valid location');
                $('.widget-wrap').hide();
                return false;
            }
        }
        if (hdnUsePreviousHistory.val() == "true" && $('#hdnIsAdd').val() == "true") {
            lblDocketNo.text('');
            hdnDocketNo.val('');
        }
        else {
            lblDocketNo.text(result.DocketNo);
            hdnDocketNo.val(result.DocketNo);
        }
        txtDocketDateTime.val($.entryDateTime(result.DocketDateTime));
        ddlPaybas.val(result.PaybasId);
        ddlPaybas.change();
        if (hdnUsePreviousHistory.val() == "true" && $('#hdnIsAdd').val() == "true") {
            txtCustomerCode.val('');
            lblCustomerName.text('');
            hdnCustomerId.val(0);
        }
        //else if (result.CustomerId == 1) {
        //    txtCustomerCode.val('');
        //    lblCustomerName.text('');
        //    hdnCustomerId.val(1);
        //}
        else {
            txtCustomerCode.val(result.CustomerCode);
            lblCustomerName.text(result.CustomerName);
            hdnCustomerId.val(result.CustomerId);
        }

        hdnFromLocationId.val(result.FromLocationId);
        lblFromLocation.text(result.FromLocation);
        lblFromLocation.val(result.FromLocation);
        $('#hdnFromLocationCode').val(result.FromLocation);

        hdnToLocationId.val(result.ToLocationId);
        txtToLocation.val(result.ToLocation);
        if (hdnUsePreviousHistory.val() == "true" && $('#hdnIsAdd').val() == "true")
            txtVehicleNo.val('');
        else
            txtVehicleNo.val(result.VehicleNo);
        $('#ddlVendorTypeId').val(result.VendorTypeId);
    }, ErrorFunction, false);

    var requestData = { docketId: hdnDocketId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/CheckManifestStatusAndUnderDrsForUpdate', JSON.stringify(requestData), function (result) {
        var res = result;
        txtToLocation.enable(result);
    }, ErrorFunction, false);
    return false;
}

function GetStep2DetailById() {
    var requestData = { docketId: hdnDocketId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep2DetailById', JSON.stringify(requestData), function (result) {

        if (result.ConsignorId == 1)
            rdConsignorWalkin.check(result.ConsignorId == 1).click();
        else
            rdConsignorFromMaster.check(result.ConsignorId != 1).click();

        hdnConsignorId.val(result.ConsignorId);
        txtConsignorCode.val(result.ConsignorCode);
        txtConsignorName.val(result.ConsignorName);
        hdnConsignorAddressId.val(result.ConsignorAddressId);
        txtConsignorAddressCode.val(result.ConsignorAddressCode);
        txtConsignorAddress1.val(result.ConsignorAddress1);
        txtConsignorAddress2.val(result.ConsignorAddress2);
        hdnConsignorCityId.val(result.ConsignorCityId);
        txtConsignorCity.val(result.ConsignorCity);
        txtConsignorPincode.val(result.ConsignorPincode);
        txtConsignorMobileNo.val(result.ConsignorMobileNo);
        txtConsignorEmailId.val(result.ConsignorEmailId);
        txtConsignorGstTinNo.val(result.ConsignorGstTinNo);

        if (result.ConsigneeId == 1)
            rdConsigneeWalkin.check(result.ConsigneeId == 1).click();
        else
            rdConsigneeFromMaster.check(result.ConsigneeId != 1).click();


        hdnConsigneeId.val(result.ConsigneeId);
        txtConsigneeCode.val(result.ConsigneeCode);
        txtConsigneeName.val(result.ConsigneeName);
        hdnConsigneeAddressId.val(result.ConsigneeAddressId);
        txtConsigneeAddressCode.val(result.ConsigneeAddressCode);
        txtConsigneeAddress1.val(result.ConsigneeAddress1);
        txtConsigneeAddress2.val(result.ConsigneeAddress2);
        hdnConsigneeCityId.val(result.ConsigneeCityId);
        txtConsigneeCity.val(result.ConsigneeCity);
        txtConsigneePincode.val(result.ConsigneePincode);
        txtConsigneeMobileNo.val(result.ConsigneeMobileNo);
        txtConsigneeEmailId.val(result.ConsigneeEmailId);
        txtConsigneeGstTinNo.val(result.ConsigneeGstTinNo);
    }, ErrorFunction, false);
    return false;
}

function GetStep3DetailById() {
    var requestData = { docketId: hdnDocketId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep3DetailById', JSON.stringify(requestData), function (result) {

        if (isFinancialUpdate) {
            hdnCustomerId.val(result.CustomerId);
            hdnBillingPartyId.val(result.CustomerId);
        }
        ddlTransportMode.val(result.TransportModeId);
        ddlServiceType.val(result.ServiceTypeId);
        ddlServiceType.change();
        ddlFtlType.val(result.FtlTypeId);
        ddlPickupDelivery.val(result.PickupDeliveryTypeId);
        hdnFromCityId.val(result.FromCityId);
        txtFromCity.val(result.FromCity);
        hdnToCityId.val(result.ToCityId);
        txtToCity.val(result.ToCity);
        ddlPackagingType.val(result.PackagingTypeId);
        ddlProductType.val(result.ProductTypeId);
        txtRemarks.val(result.Remarks);
        ddlBusinessType.val(result.BusinessTypeId);
        if (isVolumetricApplicable)
            chkVolumetric.enable().check(result.IsVolumetric);
        if (isVolumetricApplicable)
            chkPartVolumetric.enable().check(result.IsPartVolumetric);
        chkOda.check(result.IsOda);
        chkCod.check(result.IsCod);
        chkDacc.check(result.IsDacc);
        //chkLocal.check(result.IsLocal);
        ddlIndustry.val(result.IndustryId);
        ddlLoadType.val(result.LoadTypeId);
        ddlDivision.val(result.DivisionId);
        chkPermit.check(result.IsPermit);
        chkDeferment.check(result.IsDeferment);
        chkMultiPickup.check(result.IsMultiPickup);
        txtMotherDocketNo.val(result.MotherDocketNo);
        hdnBillingPartyId.val(result.CustomerId);
        hdnMotherDocketId.val(result.MotherDocketId)
        chkMultiDelivery.check(result.IsMultiDelivery);
        txtPrivateMark.val(result.PrivateMark);
        ManageMultipointPickupDelivery();
        // $('#dvMultipoint').showHide(useMultipoint);
        $('#chkIsPickupThroughSameVehicle').check(result.IsPickupThroughSameVehicle);
        $('#chkIsDeliveryThroughSameVehicle').check(result.IsDeliveryThroughSameVehicle);
    }, ErrorFunction, false);
    return false;
}

function GetStep4DetailById() {
    var requestData = { docketId: hdnDocketId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep4DetailById', JSON.stringify(requestData), function (result) {

        rdCarrierRisk.check(result.IsCarrierRisk);
        txtPolicyNo.val(result.PolicyNo);
        txtPolicyDate.val($.entryDate(result.PolicyDate));
        txtModvatCovers.val(result.ModvatCovers);
        txtInternalCovers.val(result.InternalCovers);
        txtCustomerReferenceNo.val(result.CustomerReferenceNo);
        txtCustomerReferenceDate.val($.entryDate(result.CustomerReferenceDate));
        txtCustomerGatepassNo.val(result.CustomerGatepassNo);
        txtCustomerDeliveryNo.val(result.CustomerDeliveryNo);
        txtPrivateMark.val(result.PrivateMark);
        txtTPNo.val(result.TPNo);
        txtEntrysheetNo.val(result.EntrysheetNo);
        txtObdNo.val(result.ObdNo);
        txtEngineNo.val(result.EngineNo);
        txtModelNo.val(result.ModelNo);
        txtGpsNo.val(result.GpsNo);
        txtChassisNo.val(result.ChassisNo);
        txtPermitNo.val(result.PermitNo);
        txtPermitDate.val($.entryDate(result.PermitDate));
        txtPermitValidityDate.val($.entryDate(result.PermitValidityDate));
        ddlPermitReceivedAt.val(result.PermitReceivedAt);
        txtPermitReceivedDate.val($.entryDate(result.PermitReceivedDate));
        if (result.DocumentList.length > 0) {
            $.each(result.DocumentList, function (index, value) {
                $('[id*="hdnStateDocumentId"]').each(function () {
                    var hdnStateDocumentId = $(this);
                    var txtDocumentNo = $('#' + this.id.replace('hdnStateDocumentId', 'txtDocumentNo'));
                    if (hdnStateDocumentId.val() == value.StateDocumentId)
                        txtDocumentNo.val(value.DocumentNo);
                });
            });
        }
    }, ErrorFunction, false);
    return false;
}

function GetStep5DetailById() {
    var requestData = { docketId: hdnDocketId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep5DetailById', JSON.stringify(requestData), function (result) {

        txtCftRatio.val(result.CftRatio);
        $('#hdnCftRatio').val(result.CftRatio);
        $('#txtTotalCubic').val(result.TotalCubic);
        if (result.InvoiceList.length > 0) {
            $.each(result.InvoiceList, function (index, value) {
                var hdnInvoiceId = $('#hdnInvoiceId' + index);
                var txtInvoiceNo = $('#txtInvoiceNo' + index);
                var txtInvoiceDate = $('#txtInvoiceDate' + index);
                var ddlTypeOfPackage = $('#ddlTypeOfPackage' + index);
                var txtLength = $('#txtLength' + index);
                var txtBreadth = $('#txtBreadth' + index);
                var txtHeight = $('#txtHeight' + index);
                var txtInvoiceAmount = $('#txtInvoiceAmount' + index);
                var txtPackages = $('#txtPackages' + index);
                var txtVolumetricWeight = $('#txtVolumetricWeight' + index);
                var txtActualWeight = $('#txtActualWeight' + index);
                var txtChargedWeight = $('#txtChargedWeight' + index);
                var txtEwayBillNo = $('#txtEwayBillNo' + index);
                var txtEwayBillIssueDate = $('#txtEwayBillIssueDate' + index);
                var txtEwayBillExpiryDate = $('#txtEwayBillExpiryDate' + index);
                var txtReferenceNo = $('#txtReferenceNo' + index);
                var ddlPartId = $('#ddlPartId' + index);
                var ddlPackingTypeId = $('#ddlPackingTypeId' + index);
                var txtPartQuantity = $('#txtPartQuantity' + index);

                hdnInvoiceId.val(value.InvoiceId);
                txtInvoiceNo.val(value.InvoiceNo);
                txtInvoiceDate.val($.entryDate(value.InvoiceDate));
                txtLength.val(value.Length);
                txtBreadth.val(value.Breadth);
                txtHeight.val(value.Height);
                txtInvoiceAmount.val(value.InvoiceAmount);
                ddlTypeOfPackage.val(value.TypeOfPackage);
                txtEwayBillNo.val(value.EwayBillNo);
                txtEwayBillIssueDate.val($.entryDate(value.EwayBillIssueDate));
                txtEwayBillExpiryDate.val($.entryDate(value.EwayBillExpiryDate));
                txtReferenceNo.val(value.ReferenceNo);
                ddlPartId.val(value.PartId).change();
                ddlPackingTypeId.val(value.PackingTypeId);
                txtPartQuantity.val(value.PartQuantity);
                txtPackages.val(value.Packages);
                txtVolumetricWeight.val(value.VolumetricWeight);
                txtActualWeight.val(value.ActualWeight);
                txtChargedWeight.val(value.ChargedWeight);

                if ((result.InvoiceList.length - 1) > index) {
                    AddGridRow('dtInvoice', false, Init);
                }
                BindEventInvoice(false);
                //InvoiceCalculation('txtInvoiceAmount');
                InitPartDataTable();
                $.each(value.PartList, function (partIndex, partValue) {
                    var hdnPartId = $('#hdnPartId_' + index + '_' + partIndex);
                    var txtPartName = $('#txtPartName_' + index + '_' + partIndex);
                    var lblPartDescription = $('#lblPartDescription_' + index + '_' + partIndex);
                    var txtPartQuantity = $('#txtPartQuantity_' + index + '_' + partIndex);

                    hdnPartId.val(partValue.PartId);
                    txtPartName.val(partValue.PartCode);
                    lblPartDescription.text(partValue.PartName);
                    txtPartQuantity.val(partValue.PartQuantity);

                    if ((value.PartList.length - 1) > index) {
                        AddGridRow('dtPart' + index, false, Init);
                    }
                });
                InvoiceCalculation('txtInvoiceAmount');
            });
        }
    }, ErrorFunction, false);
    return false;
}
function GetStep6DetailById() {
    var requestData = { docketId: hdnDocketId.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetStep6DetailById', JSON.stringify(requestData), function (result) {
        txtFreightRate.readOnly(false);
        ddlRateType.enable();
        dvReinvokeContract.show();
        dvPaymentContractParty.show();
        hdnPaymentCustomerId.val(result.CustomerId);
        txtPaymentCustomerCode.val(result.CustomerCode);
        lblPaymentCustomerName.text(result.CustomerName);
        hdnBillingPartyId.val(result.CustomerId);
        hdnBillLocationId.val(result.BillLocationId);
        txtBillLocation.val(result.BillLocation);
        txtEdd.val($.entryDate(result.Edd));
        ddlGstPayer.val(result.GstPaidById);
        $('#dvRegisterGstDetail').hide();
        $('#divDeclarationFileLink').showHide(result.DeclarationFileName != '');
        ddlGstServiceType.val(result.GstServiceTypeId).change();
        ddlGstState.enable(result.DeclarationFileName == '' || IsObjectNullOrEmpty(result.DeclarationFileName));

        //if (result.DeclarationFileName == '') {
        //    $.each($("#" + ddlGstState.attr('id') + " > option"), function (i, item) {
        //        var value = item.value.split('~');
        //        if ((value[3]) == result.PartyGstId && (value[3]) != undefined) {
        //            SetStateGstTin(ddlGstState, hdnGstStateId, hdnGstTinNo, true, txtPartyGstTinNo, hdnPartyGstId);
        //            ddlGstState.val(item.value).change();
        //        }
        //    });
        //}
        //else {
        //    rdTransporter.check(result.GstPayer);
        //    hdnGstExemptionDeclarationFileName.val(result.DeclarationFileName);
        //    hdnIsRcm.val(result.DeclarationFileName);

        //    if ($("#ddlGstPayer :selected").text() == "Billing Party") {
        //        lblIsRcm.text("Yes");
        //        $('#hdnIsRcm').val(true);
        //    }
        //    else {
        //        lblIsRcm.text(result.DeclarationFileName == "true" ? "Yes" : "No");
        //        $('#hdnIsRcm').val(result.DeclarationFileName == "true" ? true : false);
        //    }
        //}
        //if (hdnBillingPartyId.val() == "1") {
        //    ddlGstState.val(result.GstStateId + "~~0~0");
        //    hdnGstStateId.val(result.GstStateId);
        //}
        //else {
        //    ddlGstState.val(result.GstStateId + '~' + result.GstTinNo + '~' + (result.IsPartyGstStateIsUnionTerritory == true ? 1 : 0) + '~' + result.PartyGstId);
        //    ////alert(result.GstStateId + '~' + result.GstTinNo + '~' + (result.IsPartyGstStateIsUnionTerritory == true ? 1 : 0) + '~' + result.PartyGstId);
        //}
        ////// alert(result.CompanyGstStateId + '~' + result.CompanyGstTinNo + '~' + (result.IsCompanyGstStateIsUnionTerritory == true ? 1 : 0) + '~' + result.CompanyGstId);
        //ddlCompanyGstState.val(result.CompanyGstStateId + '~' + result.CompanyGstTinNo + '~' + (result.IsCompanyGstStateIsUnionTerritory == true ? 1 : 0) + '~' + result.CompanyGstId);
        //hdnCompanyGstStateId.val(result.CompanyGstStateId);
        //ddlCompanyGstState.change();
        //txtGstAmount.val(result.GstAmount);
        //txtGstCharge.val(result.GstCharged);
        //txtPartyGstTinNo.val(result.GstTinNo);
        //hdnGstTinNo.val(result.GstTinNo);
        txtFreightRate.val(result.FreightRate);
        ddlRateType.val(result.RateTypeId);
        txtFreight.val(result.Freight);
        hdnSubTotal.val(result.SubTotal);
        lblSubTotal.text(result.SubTotal);
        hdnTaxTotal.val(result.TaxTotal);
        lblTaxTotal.text(result.TaxTotal);
        hdnGrandTotal.val(result.GrandTotal);
        lblGrandTotal.text(result.GrandTotal);

        if (chkMultiPickup.IsChecked && chkMultiDelivery.IsChecked) {
            txtFreightRate.val(0);
            ddlRateType.val(1);
            txtFreight.val(0).blur();
            hdnSubTotal.val(0);
            lblSubTotal.text(0);
            hdnTaxTotal.val(0);
            lblTaxTotal.text(0);
            hdnGrandTotal.val(0);
            lblGrandTotal.text(0);
        }

        if (result.ChargeList.length > 0) {
            $.each(result.ChargeList, function (index, value) {
                $('[id*="hdnChargeCode"]').each(function () {
                    var hdnChargeCode = $(this);
                    var txtCharge = $('#' + this.id.replace('hdnChargeCode', 'txtCharge'));
                    if (hdnChargeCode.val() == value.ChargeCode)
                        txtCharge.val(value.ChargeAmount);
                });
            });
        }

        if (result.TaxList.length > 0) {
            $.each(result.TaxList, function (index, value) {
                $('[id*="hdnTaxCode"]').each(function () {
                    var hdnTaxCode = $(this);
                    var lblTaxAmount = $('#' + this.id.replace('hdnTaxCode', 'lblTaxAmount'));
                    if (hdnTaxCode.val() == value.TaxCode)
                        lblTaxAmount.text(value.TaxAmount);
                });
            });
        }

        CalculateFreight();
    }, ErrorFunction, false);
    return false;

}
function ManageEntryType() {
    dvComputerized.showHide(rdComputerized.IsChecked);
    dvManual.showHide(rdManual.IsChecked);
    txtDocketNo.enable(rdManual.IsChecked);
    ManageNextDocketNo();
}
function ManageNextDocketNo() {
    if (rdManual.IsChecked) if (nextDocketNo != '') txtDocketNo.val(nextDocketNo); else ShowMessage("Please enter DCR Series for this location");
}
function ManageParty() {
    var paybasId = ddlPaybas.val();
    var partySettingRuleValue = 'D';

    $('#lblCustomerName').text("");
    $('#txtCustomerCode').val("");
    $('#hdnCustomerId').val("0");

    $.each(rules.PartySetting, function (i, item) {
        if (item[0] == paybasId)
            partySettingRuleValue = item[1];
    });
    if (partySettingRuleValue == 'E' || partySettingRuleValue == 'M')
        txtCustomerCode.attr('data-val', true);
    else if (partySettingRuleValue == 'D') {
        txtCustomerCode.attr('data-val', false);

        lblCustomerName.text('');
        hdnCustomerId.val(0);
    }
    if (partySettingRuleValue == 'E' || partySettingRuleValue == 'M')
        txtCustomerCode.enable();
    else if (partySettingRuleValue == 'D')
        txtCustomerCode.disable();

    $.each(rules.ConsignorConsigneePartyMappingSetting, function (j, item) {
        if (item[0] == paybasId)
            rules.IsConsignorConsigneePartyMapping = item[1] == 'Y' ? true : false;
    });

    txtFreightRate.readOnly(paybasId == 4);
    if (paybasId == 4) txtFreightRate.val(0).blur();
}

function ManageLocal() {
    if (rules.IsLocal && loginLocationId == hdnToLocationId.val()) {
        if (!isFinancialUpdate)
            ShowMessage('From Location and To Location are same. Declare this as Local.');
        chkLocal.check();
        //ShowConfirm('From Location and To Location are same. Declare this as Local.', function () { chkLocal.check().disable(); }, function () { chkLocal.uncheck().disable(); });
    }
    else
        chkLocal.uncheck().enable();
}

function ManageFtlType() {
    ddlFtlType.enable(ddlServiceType.val() != '1');
    ddlFtlType.val('');
    if (ddlServiceType.val() == '1') {
        RemoveRequired(ddlFtlType);
    }
    else {
        AddRequired(ddlFtlType, 'Please select FTL Type');
    }
}

function ManageMultipointPickupDelivery() {
    var show = useMultipoint;
    $('#dvMultipoint').showHide(useMultipoint);
    if (useMultipoint && hdnDocketId.val() == 0) {
        show = ($.inArray(ddlServiceType.val(), multipointServiceTypeList) != -1);
        $('#dvMultipoint').showHide(show);
    }
    if (!show) {
        chkMultiPickup.uncheck(); chkMultiDelivery.uncheck(); txtMotherDocketNo.val(''); hdnMotherDocketId.val(0);
    }
    chkMultiPickup.enable(show); chkMultiDelivery.enable(show); txtMotherDocketNo.enable(show);

    if (show)
        RemoveRequired(txtMotherDocketNo);
    else
        AddRequired(txtMotherDocketNo, 'Please enter Mother ' + docketNomenclature);

    ManageFreightRateValidation();
}

function ManagePermitDetails() {
    var permitArr = [txtPermitNo, txtPermitDate, txtPermitValidityDate, txtPermitReceivedDate, ddlPermitReceivedAt];
    $.each(permitArr, function (i, item) {
        if (!chkPermit.IsChecked) item.val('').blur();
        item.enable(chkPermit.IsChecked);
    });
    dvPermit1.showHide(chkPermit.IsChecked);
    dvPermit2.showHide(chkPermit.IsChecked);
}

function ManageConsignorConsigneeType(isFromMaster, IsSaveInSystem, arr) {
    $.each(arr, function (i, item) {
        var isTrue = (i == 2) ? isFromMaster : !isFromMaster;
        if (!isTrue) item.val('').blur();
        item.readOnly(!isTrue);
    });

    //arr[0].val('').showHide(true);
    //arr[1].val('').showHide(IsSaveInSystem).showHide(!isFromMaster);
    arr[2].val(isFromMaster ? '' : 'Walk-In');
    arr[3].val('');
    arr[4].val('');
    arr[4].readOnly(!isFromMaster);
    arr[5].val('');
    arr[6].val('');
    arr[7].val('');
    arr[8].val('');
    arr[9].val('');
    arr[10].val('');
    arr[11].val('');
    arr[12].val('');
    arr[13].val('1');

    if (IsSaveInSystem)
        if (!isFromMaster)
            arr[3].blur(function () { return IsCustomerNameExist(arr[3]) });
        else
            arr[3].off();
    else
        arr[3].off();
}

function IsCustomerNameExist(txtId, fieldName) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer Name';
    if (txtId.val() != "") {
        var requestData = { customerName: txtId.val() };
        AjaxRequestWithPostAndJson(ReplaceUrl('Customer', 'IsCustomerNameExist'), JSON.stringify(requestData), function (result) {
            if (!result) {
                ShowMessage(fieldName + ' Already Exist');
                txtId.val('').focus();
            }
        }, ErrorFunction, false);
    }
}

function ManageConsignorType() {
    var consignorArr = [dvConsignorGst, dvConsignorGroupCode, txtConsignorCode, txtConsignorName, txtConsignorAddressCode, txtConsignorAddress1, txtConsignorAddress2, hdnConsignorCityId, txtConsignorCity, txtConsignorPincode, txtConsignorMobileNo, txtConsignorEmailId, txtConsignorGstTinNo, hdnConsignorId];
    ManageConsignorConsigneeType(rdConsignorFromMaster.IsChecked, rules.IsWalkInConsignorSaveInSystem, consignorArr);
}

function ManageConsigneeType() {
    var consigneeArr = [dvConsigneeGst, dvConsigneeGroupCode, txtConsigneeCode, txtConsigneeName, txtConsigneeAddressCode, txtConsigneeAddress1, txtConsigneeAddress2, hdnConsigneeCityId, txtConsigneeCity, txtConsigneePincode, txtConsigneeMobileNo, txtConsigneeEmailId, txtConsigneeGstTinNo, hdnConsigneeId];
    ManageConsignorConsigneeType(rdConsigneeFromMaster.IsChecked, rules.IsWalkInConsigneeSaveInSystem, consigneeArr);
}

function ManageDefaultSelection(defaultSelection, rdFromMaster, rdWalkin) {

    var fromMaster = true;
    if (defaultSelection == 'M')
        fromMaster = true;
    else if (defaultSelection == 'W')
        fromMaster = false;
    else if (defaultSelection == 'P') {
        if (ddlPaybas.val() == '1' || ddlPaybas.val() == '2')
            fromMaster = true;
        else if (ddlPaybas.val() == '3')
            fromMaster = false;
    }

    if (fromMaster) {

        rdFromMaster.check().click();
    }

    else {

        rdWalkin.check().click();
    }

}

function ManageCustomerSaveInSystem() {
    isWalkInConsignorSaveInSystem = rules.IsWalkInConsignorSaveInSystem;
    isWalkInConsigneeSaveInSystem = rules.IsWalkInConsigneeSaveInSystem;
    if (isLoadStep3) {
        if (txtConsignorName.val() == consignorName) {
            isWalkInConsignorSaveInSystem = false;
        }

        if (txtConsigneeName.val() == consigneeName) {
            isWalkInConsigneeSaveInSystem = false;
        }
    }

    if (hdnDocketId.val() != 0)
        if (!isLoadStep3) {
            isWalkInConsignorSaveInSystem = false;
            isWalkInConsigneeSaveInSystem = false;
        }

    consignorName = txtConsignorName.val();
    consigneeName = txtConsigneeName.val();
}

function ManageFreightRateValidation() {
    if (ddlPaybas.val() < 4)
        if (useMultipoint)
            RemoveRange(txtFreightRate);
        else
            AddRange(txtFreightRate, "Please enter Freight Rate", 1);
    else
        RemoveRange(txtFreightRate);
}
function CheckHoliday() {
    if (!rules.IsHolidayBooking) {
        var isHoliday = false;
        if (txtDocketDateTime.val() != '') {
            var docketDate = moment(txtDocketDateTime.val(), 'DD/MM/YYYY HH:mm').startOf('day');
            var item = GetArrayItemByPropery(holidayCheckList, 'Date', docketDate.format('DD/MM/YYYY'));
            if (item == null) {
                var requestData = { locationId: loginLocationId, docketDate: docketDate };
                AjaxRequestWithPostAndJson(customerMasterUrl.replace('Customer', 'HolidayDateWise') + '/IsDateHoliday', JSON.stringify(requestData), function (result) {
                    holidayCheckList.push({ Date: docketDate.format('DD/MM/YYYY'), IsHoliday: result });
                }, ErrorFunction, false);
            } else
                isHoliday = item.IsHoliday;
        }
        if (isHoliday) {
            txtDocketDateTime.val('');
            ShowMessage('Holiday Booking is not allowed');
        }
    }
    return false;
}
function ManageInvoiceGrid() {
    ShowHideInvoiceColumn();
    dvInvoice.showHide(true);
    $('[id*="ddlTypeOfPackage"]').each(function () {
        BindDropDownList($(this).Id, typeOfPackageList, 'PackagingTypeId', 'PackagingType', '', 'Select Package Type');
    });

    $('[id*="ddlPartId"]').each(function () {
        if (partNoList != undefined) {
            BindDropDownList($(this).Id, partNoList, 'Value', 'Name', '', 'Select Part No');
        }
    });

    BindEventInvoice(true);
}
function ShowHideInvoiceColumn(indexArr, indexArrFooter) {

    var indexArr = [2, 3, 4, 5, 10, 11, 12, 13, 14, 15];

    $.each(indexArr, function (i, item) {
        $('#dtInvoice tbody tr td:eq(' + item + ')').showHide(false).find('input,select').enable(false);
        $('#dtInvoice thead tr th:eq(' + item + ')').showHide(false);
        $('#dtInvoice tfoot tr td:eq(' + item + ')').showHide(false);
    });

    var indexArray = [17];
    $.each(indexArray, function (i, item) {
        $('#dtInvoice tbody tr td:eq(' + item + ')').find('input,select').attr('readonly', isChargeWeightReadOnly);
    });

    if (chkVolumetric.IsChecked && !chkPartVolumetric.IsChecked) {
        var indexArr = [2, 3, 4, 5, 15];

        $.each(indexArr, function (i, item) {
            $('#dtInvoice tbody tr td:eq(' + item + ')').showHide(true).find('input,select').enable(true);
            $('#dtInvoice thead tr th:eq(' + item + ')').showHide(true);
            $('#dtInvoice tfoot tr td:eq(' + item + ')').showHide(true);
        });

    }
    if (chkVolumetric.IsChecked && chkPartVolumetric.IsChecked) {
        var indexArr = [10, 11, 12, 13, 14, 15];

        $.each(indexArr, function (i, item) {
            $('#dtInvoice tbody tr td:eq(' + item + ')').showHide(true).find('input,select').enable(true);
            $('#dtInvoice thead tr th:eq(' + item + ')').showHide(true);
            $('#dtInvoice tfoot tr td:eq(' + item + ')').showHide(true);
        });

        //var indexArray = [16, 17];
        //$.each(indexArray, function (i, item) {
        //    $('#dtInvoice tbody tr td:eq(' + item + ')').find('input,select').attr('readonly', true);
        //});
    }


    //indexArr = [3];
    //$.each(indexArr, function (i, item) {
    //    $('#dtInvoice tfoot tr td:eq(' + item + ')').showHide(show);
    //});
    //$('#dtInvoice tfoot tr td:eq(1)').attr('colspan', (show ? 6 : 2));

    var indexArr = [7, 8, 9];
    show = isUseEwayBill;
    $.each(indexArr, function (i, item) {
        $('#dtInvoice tbody tr td:eq(' + item + ')').showHide(show).find('input,select').enable(show);
        $('#dtInvoice thead tr th:eq(' + item + ')').showHide(show);
        $('#dtInvoice tfoot tr td:eq(' + item + ')').showHide(show);
    });


    $('#thPartDetail').showHide(isUsePartDetail);
    $('#tdPartDetail').showHide(isUsePartDetail);
    $('#tfPartDetail').showHide(isUsePartDetail);

}

function ManageTypeOfPackage(obj) {
    var detail = GetArrayItemByPropery(typeOfPackageList, 'PackagingTypeId', obj.val());
    if (detail != null) {
        $('#' + obj.Id.replace('ddlTypeOfPackage', 'txtLength')).val(detail.Length);
        $('#' + obj.Id.replace('ddlTypeOfPackage', 'txtBreadth')).val(detail.Breadth);
        $('#' + obj.Id.replace('ddlTypeOfPackage', 'txtHeight')).val(detail.Height).change();
    }
}

function AddInvoiceRow() {
    AddTableRow('dtInvoice', false);
    BindEventInvoice(false);
    InitPartDataTable();
}

function RemoveInvoiceRow(btn) {
    RemoveTableRow($(btn), false, InitInvoiceTable);
    InvoiceCalculation('txtInvoiceAmount');
}

function AddPartRow(id) {
    AddTableRow(id.closest('table').Id, false);
}

function RemovePartRow(btn) {
    RemoveGridRow($(btn), btn.closest('table').Id, false, InitPartTable);
}

function InitInvoiceTable() {
    dtInvoice = ManageTableAddRemove('dtInvoice', false);
    BindEventInvoice(false);
}

function InitPartTable() {
    $('[id*="txtPartName"]').each(function () {
        var txtPartName = $(this);
        var hdnPartId = $('#' + this.id.replace('txtPartName', 'hdnPartId'));
        var hdnChargeWeightPerQuantity = $('#' + this.id.replace('txtPartName', 'hdnChargeWeightPerQuantity'));
        var txtPartQuantity = $('#' + this.id.replace('txtPartName', 'txtPartQuantity'));
        var lblPartDescription = $('#' + this.id.replace('txtPartName', 'lblPartDescription'));
        var txtChargedWeight = txtPartName.closest('table').closest('tr').find('[id*="txtChargedWeight"]');

        txtPartName.blur(function () {
            if (!CheckDuplicateInTable(txtPartName.closest('table').Id, 'txtPartName', 'Part Name', txtPartName)) return false;
            return partScript.CheckValidPart(txtPartName, hdnPartId, lblPartDescription, hdnConsignorId, hdnConsigneeId, hdnChargeWeightPerQuantity);
        });
        partScript.PartAutoComplete(txtPartName.attr('id'), hdnPartId.attr('id'), hdnConsignorId, hdnConsigneeId);

        txtPartQuantity.blur(function () {
            return partScript.CalculateTotalChargedWeight(txtPartName.closest('table').Id, txtChargedWeight);
        });
    });
}
function InitPartDataTable() {
    $('[id*="dtPart"]').each(function () {
        var tblId = $(this).Id;
        InitGrid(tblId, false, 3, InitPartTable);
    });
}
function BindEventInvoice(reInit) {
    $('input[id*=txtInvoiceDate]').each(function () {
        var tr = $(this).closest('tr');
        var dtPicker = $(this).data("DateTimePicker");
        var txtEwayBillIssueDate = $('#' + this.id.replace('txtInvoiceDate', 'txtEwayBillIssueDate'));
        var txtEwayBillExpiryDate = $('#' + this.id.replace('txtInvoiceDate', 'txtEwayBillExpiryDate'));
        var ddlPartId = $('#' + this.id.replace('txtInvoiceDate', 'ddlPartId'));
        var ddlPackingTypeId = $('#' + this.id.replace('txtInvoiceDate', 'ddlPackingTypeId'));
        var txtPartQuantity = $('#' + this.id.replace('txtInvoiceDate', 'txtPartQuantity'));
        var txtActualWeight = $('#' + this.id.replace('txtInvoiceDate', 'txtActualWeight'));
        var txtVolumetricWeight = $('#' + this.id.replace('txtInvoiceDate', 'txtVolumetricWeight'));
        var txtPartWeight = $('#' + this.id.replace('txtInvoiceDate', 'txtPartWeight'));
        var dtEwayBillIssueDatePicker = txtEwayBillIssueDate.data("DateTimePicker");
        var dtEwayBillExpiryDatePicker = txtEwayBillExpiryDate.data("DateTimePicker");

        if (reInit) {
            if (dtPicker != null) {
                if ($(this).val() != "" && moment(txtDocketDateTime.val(), jsDateTimeFormat) < moment($(this).val(), jsDateFormat)) {
                    $(this).datetimepicker("destroy");
                    InitDateTimePicker($(this).Id, false, true, hdnDocketId.val() != 0 ? false : true, txtDocketDateTime.val(), jsDateFormat, null, txtDocketDateTime.val(), false);
                }
                else {
                    $(this).datetimepicker('maxDate', moment(txtDocketDateTime.val(), jsDateFormat));
                }
            }
            else {
                InitDateTimePicker($(this).Id, false, true, hdnDocketId.val() != 0 ? false : true, txtDocketDateTime.val(), jsDateFormat, null, txtDocketDateTime.val(), false);
            }
            if (dtEwayBillIssueDatePicker != null) {
                if (txtEwayBillIssueDate.val() != "" && moment(txtDocketDateTime.val(), jsDateTimeFormat) < moment(txtEwayBillIssueDate.val(), jsDateFormat)) {
                    txtEwayBillIssueDate.datetimepicker("destroy");
                    InitDateTimePicker(txtEwayBillIssueDate.Id, false, true, false, txtDocketDateTime.val(), jsDateFormat, null, txtDocketDateTime.val(), false);
                }
                else {
                    txtEwayBillIssueDate.datetimepicker('maxDate', moment(txtDocketDateTime.val(), jsDateFormat));
                }
            }
            else {
                InitDateTimePicker(txtEwayBillIssueDate.Id, false, true, false, txtDocketDateTime.val(), jsDateFormat, null, txtDocketDateTime.val(), false);
            }
            if (dtEwayBillExpiryDatePicker != null) {
                if (txtEwayBillExpiryDate.val() != "" && moment(txtDocketDateTime.val(), jsDateTimeFormat) < moment(txtEwayBillExpiryDate.val(), jsDateFormat)) {
                    txtEwayBillExpiryDate.datetimepicker("destroy");
                    InitDateTimePicker(txtEwayBillExpiryDate.Id, true, true, hdnDocketId.val() != 0 ? false : true, txtDocketDateTime.val(), jsDateFormat, null, null, false);
                }
                else {
                    txtEwayBillExpiryDate.datetimepicker();
                }
            }
            else {
                InitDateTimePicker(txtEwayBillExpiryDate.Id, true, true, hdnDocketId.val() != 0 ? false : true, txtDocketDateTime.val(), jsDateFormat, null, null, false);
            }
        }
        else {
            if (dtPicker == null) {
                InitDateTimePicker($(this).Id, false, true, false, txtDocketDateTime.val(), jsDateFormat, null, txtDocketDateTime.val(), false);
            }
            if (dtEwayBillIssueDatePicker == null) {
                InitDateTimePicker(txtEwayBillIssueDate.Id, false, true, hdnDocketId.val() != 0 ? false : true, txtDocketDateTime.val(), jsDateFormat, null, null, false);
            }
            if (dtEwayBillExpiryDatePicker == null) {
                InitDateTimePicker(txtEwayBillExpiryDate.Id, true, true, hdnDocketId.val() != 0 ? false : true, txtDocketDateTime.val(), jsDateFormat, null, null, false);
            }
        }
        if (dtPicker == null) {
            var hdnInvoiceId = tr.find('[id*="hdnInvoiceId"]');
            var txtInvoiceNo = tr.find('[id*="txtInvoiceNo"]');
            var txtInvoiceAmount = tr.find('[id*="txtInvoiceAmount"]');
            var ddlTypeOfPackage = tr.find('[id*="ddlTypeOfPackage"]');
            var txtPackages = tr.find('[id*="txtPackages"]');
            var txtLength = tr.find('[id*="txtLength"]');
            var txtBreadth = tr.find('[id*="txtBreadth"]');
            var txtHeight = tr.find('[id*="txtHeight"]');
            var txtActualWeight = tr.find('[id*="txtActualWeight"]');
            var txtChargedWeight = tr.find('[id*="txtChargedWeight"]');
            var txtVolumetricWeight = tr.find('[id*="txtVolumetricWeight"]');
            var txtEwayBillNo = tr.find('[id*="txtEwayBillNo"]');
            var txtEwayBillIssueDate = tr.find('[id*="txtEwayBillIssueDate"]');
            var txtEwayBillExpiryDate = tr.find('[id*="txtEwayBillExpiryDate"]');
            var ddlPartId = tr.find('[id*="ddlPartId"]');
            var ddlPackingTypeId = tr.find('[id*="ddlPackingTypeId"]');
            var txtPartQuantity = tr.find('[id*="txtPartQuantity"]');
            var txtActualWeight = tr.find('[id*="txtActualWeight"]');
            var txtVolumetricWeight = tr.find('[id*="txtVolumetricWeight"]');

            txtInvoiceAmount.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtPackages.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtLength.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtBreadth.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtHeight.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtActualWeight.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtChargedWeight.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            ddlPartId.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            ddlPackingTypeId.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtPartQuantity.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            ddlTypeOfPackage.change(function () { return ManageTypeOfPackage($(this)); })

            ManageNumeric([txtActualWeight, txtChargedWeight, txtVolumetricWeight]);

            //check invoice no dupliacte
            if (ddlPaybas.val() == "2") {

                txtInvoiceNo.blur(function () {

                    if (!IsInvoiceNoAvailable(hdnInvoiceId, txtInvoiceNo)) {
                        return false;
                    }

                    //if (!CheckDuplicateInTable(txtInvoiceNo.closest('table').Id, 'txtInvoiceNo', 'Invoice No', txtInvoiceNo)) {
                    //    return false;
                    //}
                });

            }

            //end of check duplicate invoice

            txtEwayBillIssueDate.blur(function () {
                if (txtEwayBillNo.val() != '') {
                    if (txtEwayBillIssueDate.val() != '' && txtEwayBillExpiryDate.val() != '') {
                        if ($.setDateTime(txtEwayBillIssueDate.val()) >= $.setDateTime(txtEwayBillExpiryDate.val())) {
                            ShowMessage('Please select EWAY Bill Issue Date less than EWAY Bill Expiry Date ');
                            txtEwayBillIssueDate.val('');
                            return false;
                        }
                    }
                }
            });

            txtEwayBillExpiryDate.blur(function () {
                if (txtEwayBillNo.val() != '') {
                    if (txtEwayBillIssueDate.val() != '' && txtEwayBillExpiryDate.val() != '') {
                        if ($.setDateTime(txtEwayBillIssueDate.val()) >= $.setDateTime(txtEwayBillExpiryDate.val())) {
                            ShowMessage('Please select EWAY Bill Expiry Date greater than EWAY Bill Issue Date ');
                            txtEwayBillExpiryDate.val('');
                            return false;
                        }
                    }
                }
            });

            ddlPartId.change(function () {
                if (!IsObjectNullOrEmpty(ddlPartId.val())) {
                    var requestData = { partId: ddlPartId.val(), consignorId: hdnConsignorId.val(), consigneeId: hdnConsigneeId.val() };
                    AjaxRequestWithPostAndJson(partMasterUrl + '/GetPackingTypeListByPartId', JSON.stringify(requestData), function (responseData) {
                        BindDropDownList(ddlPackingTypeId.Id, responseData, 'Value', 'Name', '', 'Select');
                    }, ErrorFunction, false);
                }
                if (ddlPartId.val() != '' && ddlPackingTypeId.val() != '' && txtPartQuantity.val() != '') {
                    GetPartDetailByPartIdAndPackingTypeId(ddlPartId, ddlPackingTypeId, txtPartQuantity, txtActualWeight, txtVolumetricWeight, txtChargedWeight);
                }

            });

            ddlPackingTypeId.change(function () {
                if (ddlPartId.val() != '' && ddlPackingTypeId.val() != '' && txtPartQuantity.val() != '') {
                    GetPartDetailByPartIdAndPackingTypeId(ddlPartId, ddlPackingTypeId, txtPartQuantity, txtActualWeight, txtVolumetricWeight, txtChargedWeight);
                }
            });

            txtPartQuantity.blur(function () {
                if (ddlPartId.val() != '' && ddlPackingTypeId.val() != '' && txtPartQuantity.val() != '') {
                    GetPartDetailByPartIdAndPackingTypeId(ddlPartId, ddlPackingTypeId, txtPartQuantity, txtActualWeight, txtVolumetricWeight, txtChargedWeight);
                }
            });
        }
        else {
            var hdnInvoiceId = tr.find('[id*="hdnInvoiceId"]');
            var txtInvoiceNo = tr.find('[id*="txtInvoiceNo"]');
            var txtInvoiceAmount = tr.find('[id*="txtInvoiceAmount"]');
            var ddlTypeOfPackage = tr.find('[id*="ddlTypeOfPackage"]');
            var txtPackages = tr.find('[id*="txtPackages"]');
            var txtLength = tr.find('[id*="txtLength"]');
            var txtBreadth = tr.find('[id*="txtBreadth"]');
            var txtHeight = tr.find('[id*="txtHeight"]');
            var txtActualWeight = tr.find('[id*="txtActualWeight"]');
            var txtChargedWeight = tr.find('[id*="txtChargedWeight"]');
            var txtVolumetricWeight = tr.find('[id*="txtVolumetricWeight"]');
            var txtEwayBillNo = tr.find('[id*="txtEwayBillNo"]');
            var txtEwayBillIssueDate = tr.find('[id*="txtEwayBillIssueDate"]');
            var txtEwayBillExpiryDate = tr.find('[id*="txtEwayBillExpiryDate"]');
            var ddlPartId = tr.find('[id*="ddlPartId"]');
            var ddlPackingTypeId = tr.find('[id*="ddlPackingTypeId"]');
            var txtPartQuantity = tr.find('[id*="txtPartQuantity"]');
            var txtActualWeight = tr.find('[id*="txtActualWeight"]');
            var txtVolumetricWeight = tr.find('[id*="txtVolumetricWeight"]');

            txtInvoiceAmount.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtPackages.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtLength.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtBreadth.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtHeight.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtActualWeight.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtChargedWeight.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            ddlPartId.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            ddlPackingTypeId.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            txtPartQuantity.change(function () { InvoiceCalculation('txtInvoiceAmount') });
            ddlTypeOfPackage.change(function () { return ManageTypeOfPackage($(this)); })

            //check invoice no dupliacte
            if (ddlPaybas.val() == "2") {

                txtInvoiceNo.blur(function () {
                    if (!IsInvoiceNoAvailable(hdnInvoiceId, txtInvoiceNo)) {
                        return false;
                    }
                    //if (!CheckDuplicateInTable(txtInvoiceNo.closest('table').Id, 'txtInvoiceNo', 'Invoice No', txtInvoiceNo)) {
                    //    return false;
                    //}
                });

            }

            //end of check duplicate invoice

            txtEwayBillIssueDate.blur(function () {
                if (txtEwayBillNo.val() != '') {
                    if (txtEwayBillIssueDate.val() != '' && txtEwayBillExpiryDate.val() != '') {
                        if ($.setDateTime(txtEwayBillIssueDate.val()) >= $.setDateTime(txtEwayBillExpiryDate.val())) {
                            ShowMessage('Please select EWAY Bill Issue Date less than EWAY Bill Expiry Date ');
                            txtEwayBillIssueDate.val('');
                            return false;
                        }
                    }
                }
            });

            txtEwayBillExpiryDate.blur(function () {
                if (txtEwayBillNo.val() != '') {
                    if (txtEwayBillIssueDate.val() != '' && txtEwayBillExpiryDate.val() != '') {
                        if ($.setDateTime(txtEwayBillIssueDate.val()) >= $.setDateTime(txtEwayBillExpiryDate.val())) {
                            ShowMessage('Please select EWAY Bill Expiry Date greater than EWAY Bill Issue Date ');
                            txtEwayBillExpiryDate.val('');
                            return false;
                        }
                    }
                }
            });

            ddlPartId.change(function () {
                if (!IsObjectNullOrEmpty(ddlPartId.val())) {
                    var requestData = { partId: ddlPartId.val(), consignorId: hdnConsignorId.val(), consigneeId: hdnConsigneeId.val() };
                    AjaxRequestWithPostAndJson(partMasterUrl + '/GetPackingTypeListByPartId', JSON.stringify(requestData), function (responseData) {
                        BindDropDownList(ddlPackingTypeId.Id, responseData, 'Value', 'Name', '', 'Select');
                    }, ErrorFunction, false);
                }
                if (ddlPartId.val() != '' && ddlPackingTypeId.val() != '' && txtPartQuantity.val() != '') {
                    GetPartDetailByPartIdAndPackingTypeId(ddlPartId, ddlPackingTypeId, txtPartQuantity, txtActualWeight, txtVolumetricWeight, txtChargedWeight);
                }

            });

            ddlPackingTypeId.change(function () {
                if (ddlPartId.val() != '' && ddlPackingTypeId.val() != '' && txtPartQuantity.val() != '') {
                    GetPartDetailByPartIdAndPackingTypeId(ddlPartId, ddlPackingTypeId, txtPartQuantity, txtActualWeight, txtVolumetricWeight, txtChargedWeight);
                }
            });

            txtPartQuantity.blur(function () {
                if (ddlPartId.val() != '' && ddlPackingTypeId.val() != '' && txtPartQuantity.val() != '') {
                    GetPartDetailByPartIdAndPackingTypeId(ddlPartId, ddlPackingTypeId, txtPartQuantity, txtActualWeight, txtVolumetricWeight, txtChargedWeight);
                }
            });
        }

        ddlPartId.change(function () {
            if (!IsObjectNullOrEmpty(ddlPartId.val())) {
                var requestData = { partId: ddlPartId.val(), consignorId: hdnConsignorId.val(), consigneeId: hdnConsigneeId.val() };
                AjaxRequestWithPostAndJson(partMasterUrl + '/GetPackingTypeListByPartId', JSON.stringify(requestData), function (responseData) {
                    BindDropDownList(ddlPackingTypeId.Id, responseData, 'Value', 'Name', '', 'Select');
                }, ErrorFunction, false);
            }
            if (ddlPartId.val() != '' && ddlPackingTypeId.val() != '' && txtPartQuantity.val() != '') {
                GetPartDetailByPartIdAndPackingTypeId(ddlPartId, ddlPackingTypeId, txtPartQuantity, txtActualWeight, txtVolumetricWeight, txtChargedWeight);
            }

        });

        ddlPackingTypeId.change(function () {
            if (ddlPartId.val() != '' && ddlPackingTypeId.val() != '' && txtPartQuantity.val() != '') {
                GetPartDetailByPartIdAndPackingTypeId(ddlPartId, ddlPackingTypeId, txtPartQuantity, txtActualWeight, txtVolumetricWeight, txtChargedWeight);
            }
        });

        txtPartQuantity.blur(function () {
            if (ddlPartId.val() != '' && ddlPackingTypeId.val() != '' && txtPartQuantity.val() != '') {
                GetPartDetailByPartIdAndPackingTypeId(ddlPartId, ddlPackingTypeId, txtPartQuantity, txtActualWeight, txtVolumetricWeight, txtChargedWeight);
            }
        });
    });
}
function GetPartDetailByPartIdAndPackingTypeId(partId, packingTypeId, partQty, actualWeight, volumetricWeight, chargedWeight) {
    if (partId.val() != null && packingTypeId.val() != null) {
        var requestData = { partId: partId.val(), packingTypeId: packingTypeId.val(), consignorId: hdnConsignorId.val(), consigneeId: hdnConsigneeId.val() };
        AjaxRequestWithPostAndJson(partMasterUrl + '/GetPartDetailByPartIdAndPackingTypeId', JSON.stringify(requestData), function (responseData) {
            actualWeight.val(parseInt(partQty.val()) * responseData.ActualWeightPerQuantity);
            volumetricWeight.val(parseInt(partQty.val()) * responseData.CubicPerQuantity);
            if (parseFloat(actualWeight.val()) > parseFloat(volumetricWeight.val()))
                chargedWeight.val(actualWeight.val());
            else
                chargedWeight.val(volumetricWeight.val());
            InvoiceCalculation('txtInvoiceAmount');
        }, ErrorFunction, false);
    }
}

function IsInvoiceNoAvailable(objInvoiceId, objInvoiceNo) {
    if (objInvoiceNo.val() != "") {
        var requestData = { docketId: hdnDocketId.val(), invoiceId: objInvoiceId.val() == '' ? 0 : objInvoiceId.val(), invoiceNo: objInvoiceNo.val(), customerId: hdnConsignorId.val() };
        AjaxRequestWithPostAndJson(baseUrl + '/IsInvoiceNoAvailable', JSON.stringify(requestData), function (result) {
            if (result) {
                ShowMessage('Invoice No is already exist');
                objInvoiceNo.val('');
                objInvoiceNo.focus();
            }
        }, ErrorFunction, false);
    }
    return false;
}

function ManageNumeric(objArr) {
    var decimalPlaces = weightDecimalPlaces == 0 ? '' : weightDecimalPlaces;
    $.each(objArr, function (i, item) {
        item.removeAttr('class').attr('class', 'form-control numeric' + decimalPlaces);
        item[0].value = parseInt(0).toFixed(weightDecimalPlaces);
    });
}

function InvoiceCalculation(caller) {
    var isVolumetric = chkVolumetric.IsChecked;
    var totalInvoiceAmount = 0, totalActualWeight = 0, totalVolumetricWeight = 0;
    var totalCubic = 0;
    totalPackages = 0, totalPartQuantity = 0, totalChargedWeight = 0;
    $('#dtInvoice > tbody > tr').each(function () {
        var tr = $(this);
        var txtInvoiceNo = tr.find('[id*="txtInvoiceNo"]');
        var txtInvoiceAmount = tr.find('[id*="txtInvoiceAmount"]');
        var txtPackages = tr.find('[id*="txtPackages"]');
        var txtPartQuantity = tr.find('[id*="txtPartQuantity"]');
        var txtEwayBillNo = tr.find('[id*="txtEwayBillNo"]');
        if (parseInt(txtInvoiceAmount.val()) >= parseInt(ewayBillRequiredAmount)) {
            AddRequired(txtEwayBillNo, 'Please enter EWAY Bill No');
        }
        else {
            RemoveRequired(txtEwayBillNo);
        }
        if (isVolumetric) {
            var txtLength = tr.find('[id*="txtLength"]');
            var txtBreadth = tr.find('[id*="txtBreadth"]');
            var txtHeight = tr.find('[id*="txtHeight"]');
            var txtVolumetricWeight = tr.find('[id*="txtVolumetricWeight"]');
        }
        var txtActualWeight = tr.find('[id*="txtActualWeight"]');
        var txtChargedWeight = tr.find('[id*="txtChargedWeight"]');

        //valueIfZero([txtInvoiceAmount, txtPackages, txtActualWeight, txtChargedWeight])
        //if (isVolumetric)
        //    valueIfZero([txtLength, txtBreadth, txtHeight, txtVolumetricWeight])

        if (txtInvoiceAmount.val() == "") {
            txtInvoiceAmount.val(0);
        }

        var invoiceAmount = parseFloat(txtInvoiceAmount.val());// txtInvoiceAmount.round(2);
        var packages = txtPackages.round(0);
        var partQuantity = txtPartQuantity.round(0);
        var actualWeight = 0;
        var chargedWeight = 0;
        //if (useRoundActualWeight)
        //    actualWeight = Math.ceil(parseFloat(txtActualWeight.val()));
        //else
        //    actualWeight = txtActualWeight.val();
        if (useRoundActualWeight) {
            actualWeight = parseFloat(txtActualWeight.val()).toFixed(weightDecimalPlaces);
        }
        else {
            actualWeight = parseFloat(txtActualWeight.val());
        }

        if (isVolumetric) {
            chargedWeight = actualWeight;
            var length = parseFloat(txtLength.val()), breadth = parseFloat(txtBreadth.val()), height = parseFloat(txtHeight.val());

            var measuretype = "CM";
            switch (cftInfo.CftMeasurementType) {
                case 'I': measuretype = 'Inch'; break;
                case 'C': measuretype = 'CM'; break;
                case 'F': measuretype = 'Feet'; break;
                case 'M': measuretype = 'Meter'; break;
            }

            if (length > cftInfo.CftDimension) {
                ShowMessage("CFT not updated for Length in Mode wise Selection");
                txtLength.val(0);
            }

            if (breadth > cftInfo.CftDimension) {
                ShowMessage("CFT not updated for Breadth in Mode wise Selection");
                txtBreadth.val(0);
            }

            if (height > cftInfo.CftDimension) {
                ShowMessage("CFT not updated for Height in Mode wise Selection");
                txtHeight.val(0);
            }

            var divider;
            switch (cftInfo.CftMeasurementType) {
                case 'I': divider = 1728; break;
                case 'C': divider = 27000; break;
                case 'F': divider = 1; break;
                case 'M': divider = 270; break;
                default: divider = 1; break;
            }

            if (ddlTransportMode.val() == 1) {
                if (cftInfo.CftMeasurementType == "C") {
                    divider = 5000;
                }
            }


            //var cftRatio = $('#txtCftRatio').round(2);
            var cftRatio = $('#txtCftRatio').val();
            var cubic = packages * (length * breadth * height * cftRatio);
            var volumetricWeight = parseFloat((cubic / divider));

            switch (cftInfo.VolumetricWeightType) {
                case 'A': chargedWeight = (chargedWeight < actualWeight ? actualWeight : chargedWeight); break;
                case 'V': chargedWeight = volumetricWeight; break;
                case 'M': chargedWeight = (actualWeight > volumetricWeight ? actualWeight : volumetricWeight); break;
                default: chargedWeight = (chargedWeight < actualWeight ? actualWeight : chargedWeight); break;
            }

            if (useRoundVolumetricWeight) {
                volumetricWeight = parseFloat(volumetricWeight).toFixed(weightDecimalPlaces);
            }
            else {
                volumetricWeight = parseFloat(volumetricWeight);
            }
            txtVolumetricWeight.val(volumetricWeight);
            totalVolumetricWeight += parseFloat(volumetricWeight);
            totalCubic += cubic;
        }
        else {
            if (parseFloat(txtChargedWeight.val()) == 0) {
                chargedWeight = parseFloat(txtActualWeight.val());
            }
            else {
                chargedWeight = parseFloat(txtChargedWeight.val());
            }

            if (parseFloat(txtChargedWeight.val()) < parseFloat(txtActualWeight.val())) {
                chargedWeight = parseFloat(txtActualWeight.val());
            }

        }

        if (useRoundChargeWeight) {
            if (useRoundUpperChargeWeight) {
                chargedWeight = Math.ceil(parseFloat(chargedWeight));
            }
            else { chargedWeight = parseFloat(chargedWeight).toFixed(0); }
        }
        else {
            if (useRoundUpperChargeWeight) {
                chargedWeight = Math.ceil(parseFloat(chargedWeight));
            }
            else { chargedWeight = parseFloat(chargedWeight); }
        }
        txtChargedWeight.val(chargedWeight);

        txtInvoiceAmount.val(invoiceAmount.toFixed(2));
        totalInvoiceAmount += invoiceAmount;
        totalPackages += packages;
        totalPartQuantity += partQuantity;
        totalActualWeight = parseFloat(totalActualWeight) + parseFloat(actualWeight);
        totalChargedWeight = parseFloat(totalChargedWeight) + parseFloat(chargedWeight);
    });

    $('#lblTotalPackages').text(totalPackages);
    $('#lblTotalPartQuantity').text(totalPartQuantity);
    $('#lblTotalInvoiceAmount').text(totalInvoiceAmount.toFixed(2));
    if (isVolumetric) {
        $('#txtTotalCubic').val(totalCubic);
        $('#lblTotalVolumetricWeight').text(totalVolumetricWeight.toFixed(weightDecimalPlaces));
    }
    if (useRoundActualWeight) {
        $('#lblTotalActualWeight').text(totalActualWeight.toFixed(weightDecimalPlaces));
        $('#lblTotalChargedWeight').text(totalChargedWeight.toFixed(weightDecimalPlaces));
    }
    else {
        $('#lblTotalActualWeight').text(totalActualWeight);
        $('#lblTotalChargedWeight').text(totalChargedWeight);
    }

    hdnTotalPackages.val(totalPackages);
    hdnTotalPartQuantity.val(totalPartQuantity);
    hdnTotalActualWeight.val($('#lblTotalActualWeight').text());
    hdnTotalChargedWeight.val($('#lblTotalChargedWeight').text());
}

function valueIfZero(objArr) {
    $.each(objArr, function (i, item) {
        if (item.val() == '')
            item.val(0);
    });
}

function ValidateCftRatio() {
    if (parseFloat($('#txtCftRatio').val()) < cftInfo.CftRatio) {
        $('#txtCftRatio').val(cftInfo.CftRatio);
        $('#hdnCftRatio').val(cftInfo.CftRatio);
    }
}

function Init() {
    return false;
}

function SetOtherCharge(list, dtCharge, isOdd) {

    var tableId = (isOdd ? 'dtCharges1' : 'dtCharges2');
    if (dtCharge != null)
        $('#' + tableId).addClass('dataTable');
    if (dtCharge == null)
        dtCharge = LoadDataTable(tableId, false, false, false, null, null, [],
            [
                { title: 'Charge Name', data: 'ChargeDetail', width: 150 },
                { title: 'Charge', data: 'ChargeAmount', width: 60 }
            ]);
    dtCharge.fnClearTable();

    var newList = [];
    if (list.length > 0) {
        $.each(list, function (i, item) {
            if ((isOdd && (((i + 1) % 2) != 0)) || (!isOdd && (((i + 1) % 2) == 0))) {
                item.ChargeDetail = '<input type="hidden" name="ChargeList[' + chargeCount + '].ChargeCode" id="hdnChargeCode' + i + '" value="' + item.ChargeCode + '"/>' +
                    '<input type="hidden" name="ChargeList[' + chargeCount + '].IsOperator" id="hdnOperator' + i + '" value="' + (item.IsOperator ? '+' : '-') + '"/>' +
                    '<label class="label" id="lblChargeName' + chargeCount + '">' + item.ChargeName + '(' + (item.IsOperator ? '+' : '-') + ')' + '</label>';
                item.ChargeAmount = '<input class="form-control numeric2" data-val="true" data-val-required="Please enter ' + item.ChargeName + '" ' +
                    'name="ChargeList[' + chargeCount + '].ChargeAmount" value="' + item.ChargeAmount.toFixed(2) + '" id="txtCharge' + i + '" type="text" />' +
                    '<span data-valmsg-for="ChargeList[' + chargeCount + '].Charge" data-valmsg-replace="true"></span>'
                newList.push(item);
                chargeCount++;
            }
        });
        dtCharge.dtAddData(newList);
    }
    if (isOdd)
        dtCharges1 = dtCharge;
    else
        dtCharges2 = dtCharge;
    AttachChargeEvent();
}

function CalculateFreight(caller) {
    var freightRate = parseFloat(txtFreightRate.val());
    var freight = parseFloat(txtFreight.val());
    var chargedWeight = parseFloat($('#lblTotalChargedWeight').text()),
        packages = parseFloat($('#lblTotalPackages').text()),
        partQuantity = parseFloat($('#lblTotalPartQuantity').text());
    $('#dvKm').showHide(ddlRateType.val() == 7);
    if (caller == 'RateType')
        txtKm.val(0);
    if (caller == 'Rate' || caller == 'RateType' || caller == 'Km') {
        freight = CalculateRate(ddlRateType.val(), freightRate, packages, chargedWeight, parseInt(txtKm.val()), 0, 0, partQuantity);
    } else {
        switch (ddlRateType.val()) {
            case RateTypes.Flat: freightRate = freight; break;//Flat
            case RateTypes.PerGram: freightRate = freight / (1000 * chargedWeight); break;//Per Gram
            case RateTypes.PerKG: freightRate = freight / chargedWeight; break;//Per KG
            case RateTypes.PerQuintal: freightRate = freight * 100 / chargedWeight; break;//Per Quintal
            case RateTypes.PerTon: freightRate = freight * 1000 / chargedWeight; break;//Per Ton
            case RateTypes.PerPackage: freightRate = freight / packages; break;//Per Package
            case RateTypes.PerKm: freightRate = freight * txtKm.val(); break;//Per KM
            case RateTypes.PerLiter: freightRate = freight / chargedWeight; break;//Per Liter
            case RateTypes.PerQuantity: freightRate = freight / partQuantity; break;//Per Liter
            case RateTypes.PerQuantityWeight: freightRate = freight / chargedWeight; break;//Per Liter
            default: freightRate = 0; break;
        }
    }


    txtFreight.val(freight);
    txtFreightRate.val(freightRate);
    $('#txtRatePerKg').val(freightRate / chargedWeight);
    //CalculateMinimumFreight();
    CalculateTotal();
}

function AttachChargeEvent() {
    $('[id*=txtCharge]').each(function () {
        var txtCharge = $(this);
        txtCharge.blur(CalculateTotal);
    });
}

function CalculateTotal() {
    var freight = parseFloat(txtFreight.val());
    var fov = parseFloat(txtFov.val());
    var subTotal = freight + fov;

    $('[id*=hdnChargeCode]').each(function () {
        var hdnChargeCode = $(this);
        var hdnOperator = $('#' + this.id.replace('hdnChargeCode', 'hdnOperator'));
        var txtCharge = $('#' + this.id.replace('hdnChargeCode', 'txtCharge'));
        subTotal += (hdnOperator.val() == "+" ? 1 : -1) * parseFloat(txtCharge.val());
    });

    //subTotal = subTotal + fov;
    hdnSubTotal.val(subTotal);

    var serviceTax = 0, totalTax = 0;
    var taxPercentageTotal = 0;
    //if (!gstDetails.IsGst)
    //    $.each(taxList, function (i, item) {
    //        if (chkServiceTaxExempted.IsChecked || ddlGstPayer.val() != 4)
    //            item.TaxAmount = item.ActualTaxPercentage = 0;
    //        else if (subTotal > item.ExceedAmount) {
    //            var taxPercentage = item.TaxPercentage * (100 - item.RebatePercentage) / 100;
    //            item.TaxAmount = (item.BaseOn == 1 ? subTotal : serviceTax) * taxPercentage / 100;
    //            serviceTaxPercentageTotal += (item.BaseOn == 1 ? taxPercentage : (item.TaxAmount * 100 / subTotal));
    //            item.TaxAmount = item.TaxAmount.toFixed(2);
    //            if (item.TaxCode == 1)
    //                serviceTax = item.TaxAmount;
    //            totalTax += parseFloat(item.TaxAmount);
    //            item.ActualTaxPercentage = taxPercentage;
    //        }
    //        else
    //            item.TaxAmount = item.ActualTaxPercentage = 0;
    //    });
    //if (gstDetails.IsGst) {
    //    taxPercentageTotal = gstDetails.GstRate;
    //    totalTax = parseFloat(hdnSubTotal.val()) * gstDetails.GstRate / 100;
    //    txtGstAmount.val(totalTax);

    //    if ($("#ddlGstPayer :selected").text() == "Billing Party") {
    //        totalTax = taxPercentageTotal = 0;
    //        $.each(taxList, function (i, item) {
    //            item.TaxAmount = item.ActualTaxPercentage = 0;
    //        });
    //    }
    //    else {
    //        if (gstDetails.IsRcm && gstDetails.ApplyGst) {
    //            totalTax = taxPercentageTotal = 0;
    //            $.each(taxList, function (i, item) {
    //                item.TaxAmount = item.ActualTaxPercentage = 0;
    //            });
    //        }
    //        else {
    //            $.each(taxList, function (i, item) {
    //                if (gstDetails.IsInterState && item.TaxName == 'IGST') {
    //                    item.TaxAmount = totalTax;
    //                    item.ActualTaxPercentage = gstDetails.GstRate;
    //                }
    //                else if (!gstDetails.IsInterState) {
    //                    //if ((gstDetails.IsState && item.TaxName == 'SGST') || (!gstDetails.IsState && item.TaxName == 'UGST') || item.TaxName == 'CGST') {
    //                    if (item.TaxName == 'SGST' || item.TaxName == 'CGST') {
    //                        item.TaxAmount = totalTax / 2;
    //                        item.ActualTaxPercentage = gstDetails.GstRate / 2;
    //                    }
    //                    else
    //                        item.TaxAmount = item.ActualTaxPercentage = 0;
    //                }
    //                else
    //                    item.TaxAmount = item.ActualTaxPercentage = 0;
    //            });
    //        }
    //    }

    //    txtGstCharge.val(totalTax);
    //}

    hdnTaxPercentageTotal.val(taxPercentageTotal);

    /*    var grandTotal = subTotal + totalTax;*/
    var grandTotal = subTotal;

    lblSubTotal.text(subTotal.toFixed(2));
    hdnSubTotal.val(lblSubTotal.text());

    //lblTaxTotal.text(totalTax.toFixed(2));
    //hdnTaxTotal.val(lblTaxTotal.text());

    if (isRoundOff)
        lblGrandTotal.text(grandTotal.toFixed(0));
    else
        lblGrandTotal.text(grandTotal.toFixed(2));

    hdnGrandTotal.val(lblGrandTotal.text());

    //    if (dtTax == null)
    //        dtTax = LoadDataTable('dtTax', false, false, false, null, null, [],
    //            [
    //                { title: 'Tax Code', data: 'TaxCode', hidden: true },
    //                { title: 'Tax Name', data: 'TaxDetail' },
    //                { title: 'Tax Amount', data: 'TaxAmount' }
    //            ]);
    //    else {
    //        $('#dtTax').addClass('dataTable');
    //        dtTax.fnClearTable();
    //    }
    //    if (taxList.length > 0) {
    //        $.each(taxList, function (i, item) {
    //            item.TaxDetail = '<input type="hidden" name="TaxList[' + i + '].TaxCode" id="hdnTaxCode' + i + '" value="' + item.TaxCode + '"/>' +
    //                '<input type="hidden" name="TaxList[' + i + '].TaxAmount" id="hdnTaxAmount' + i + '" value="' + parseFloat(item.TaxAmount).toFixed(2) + '"/>' +
    //                '<label class="label" id="lblTaxName' + i + '">' + item.TaxName + '</label>' +
    //                '<input type="hidden" name="TaxList[' + i + '].TaxPercentage" id="hdnTaxPercentage' + i + '" value="' + item.ActualTaxPercentage + '"/>';
    //            item.TaxAmount = '<label class=\'align-right\' style=\'width:100%\' id="lblTaxAmount' + i + '">' + parseFloat(item.TaxAmount).toFixed(2) + '</label>';
    //        });
    //        dtTax.dtAddData(taxList);
    //        $('#dtTax').DataTable().column(0).visible(false);
    //    }
}

function CalculateMinimumFreight() {
    if (!IsObjectNullOrEmpty(minimumFreightDetails)) {
        if (minimumFreightDetails.UseMinimumFreightTypeBaseWise)
            CalculateMinimumFreightBaseWise();
        else
            CalculateMinimumFreightPercentWise();
    }
}

function CalculateMinimumFreightBaseWise() {
    var minFreight = 0;
    var minimumFreightRate = minimumFreightDetails.MinimumFreightRate;
    var minimumFreightRateType = minimumFreightDetails.MinimumFreightRateType;
    var freighRate = txtFreightRate.toFloat();

    if (minimumFreightRateType == RateTypes.Flat) {
        minFreight = minimumFreightRate;
    }
    else if (minimumFreightRateType == RateTypes.PerPackage) {
        if (totalPackages < minimumFreightRate)
            totalPackages = minimumFreightRate;
        minFreight = totalPackages * freighRate;
    }
    else if (minimumFreightRateType == RateTypes.PerKG || minimumFreightRateType == RateTypes.PerGram || minimumFreightRateType == RateTypes.PerTon || minimumFreightRateType == RateTypes.PerKm || minimumFreightRateType == RateTypes.PerLiter) {
        var totalChargedWeightTemp = GetWeightByType(minimumFreightRateType, totalChargedWeight);
        if (totalChargedWeightTemp < minimumFreightRate)
            totalChargedWeightTemp = minimumFreightRate;
        minFreight = $.toRound(totalChargedWeightTemp * freighRate, 2);
        totalChargedWeight = totalChargedWeightTemp;
    }
    //$('#lblMinimumFreightMessage').text('');

    if (txtFreight.toFloat() < minFreight) {
        txtFreight.val(minFreight.toFixed(2));
        $('#lblMinimumFreightMessage').text("Minimum Freight in " + GetRateTypeName(minimumFreightRateType) + " is applied.").blur();
    }

    //if (txtFreight.toFloat() < minimumFreightDetails.MinimumFreightRate) {
    //    $('#lblMinimumFreightMessage').text("Minimum Freight is applied.");
    //    ddlRateType.val(RateTypes.Flat);
    //    txtFreight.val(minimumFreightDetails.MinimumFreightRate.toFixed(2));
    //}

    //$('#lblTotalPackages').text(totalPackages);
    //$('#lblTotalChargedWeight').text(totalChargedWeight);

    return true;
}

function CalculateMinimumFreightPercentWise() {
    var freightRate = txtFreightRate.toFloat();

    if (minimumFreightDetails.UseFreightRateLimit) {
        var minFreightLowerLimit = minimumFreightDetails.MimimumFreightLowerLimit;
        var minFreightUpperLimit = minimumFreightDetails.MimimumFreightUpperLimit;

        var lowerLimit = $.toRound(freightRateDb * minFreightLowerLimit / 100, 2);
        var upperLimit = $.toRound(freightRateDb * minFreightUpperLimit / 100, 2);

        if (freightRate < lowerLimit) {
            ShowMessage("Freight Rate Lower Limit Reached. Lower Freight Rate Applied.");
            txtFreightRate.val(lowerLimit);
        }

        if (freightRate > upperLimit) {
            ShowMessage("Freight Rate Upper Limit Reached. Upper Freight Rate Applied.");
            txtFreightRate.val(upperLimit);
        }

        //txtFreightRate.blur();

        var freight = txtFreight.round(2);
        if (freight < minimumFreightDetails.MinimumFreight) {
            ShowMessage("Minimum Freight in Flat applied");
            txtFreight.val(minimumFreightDetails.MinimumFreight);
        }
    }
    return true;
}

function GetRateTypeName(rateType) {
    var rateTypeDescription = '';
    switch (rateType) {
        case RateTypes.Flat: rateTypeDescription = 'Flat'; break;
        case RateTypes.PerGram: rateTypeDescription = 'Per Gram'; break;
        case RateTypes.PerKG: rateTypeDescription = 'Per KG'; break;
        case RateTypes.PerTon: rateTypeDescription = 'Per Ton'; break;
        case RateTypes.PerPackage: rateTypeDescription = 'Per Package'; break;
        case RateTypes.PerKm: rateTypeDescription = 'Per KM'; break;
        case RateTypes.PerLiter: rateTypeDescription = 'Per Liter'; break;
    }
    return rateTypeDescription;
}

function GetWeightByType(weightType, weight) {
    switch (weightType) {
        case RateTypes.PerGram: weight = weight * 1000; break;
        case RateTypes.PerKG:
        case RateTypes.PerLiter: weight = weight; break;
        case RateTypes.PerQuintal: weight = $.toRound(weight / 100, 2); break;
        case RateTypes.PerTon: weight = weight / 1000; break;
        default: newWeight = weight; break;
    }
    return weight;
}

function CalculateRate(rateTypeId, rate, packages, chargedWeight, km, freight, invoiceAmount, partQuantity) {
    var amount = 0;
    switch (rateTypeId) {
        case RateTypes.Flat: amount = rate; break;//Flat
        case RateTypes.PerGram:
        case RateTypes.PerKG:
        case RateTypes.PerQuintal:
        case RateTypes.PerTon:
        case RateTypes.PerLiter: amount = rate * GetWeightByType(rateTypeId, chargedWeight); break;//Per TON
        case RateTypes.PerPackage: amount = rate * packages; break;//Per Package
        case RateTypes.PerKm: amount = rate * km; break;//Per KM
        case RateTypes.PercentageOfFreight: amount = rate * freight / 100; break;// % of Freight
        case RateTypes.PercentageOfInvoice: amount = rate * invoiceAmount / 100; break;// % of Invoice
        case RateTypes.PerQuantity: amount = rate * partQuantity; break;//Per Quantity
        case RateTypes.PerQuantityWeight: amount = rate * GetWeightByType(rateTypeId, chargedWeight); break;//Per Quantity Weight
        default: freight = 0; break;
    }

    return amount;
}

function CalculateFov() {
    var fovCharge = 0;
    var fovRate = txtFovRate.round(2);
    var totalInvoiceAmount = parseFloat($('#lblTotalInvoiceAmount').text());

    if (hdnFovRateType.val() == "%")
        fovCharge = totalInvoiceAmount * fovRate / 100;
    else
        fovCharge = fovRate;
    fovCharge = $.toRound(fovCharge, 2);
    txtFov.val(fovCharge);
}

function CheckValidCustomerCode(showErrorMessage, allowWalkIn, fieldName, entity) {
    if (IsObjectNullOrEmpty(entity)) entity = 'ContractParty';
    return docketScript.CheckValidCustomerCode(txtCustomerCode, lblCustomerName, hdnCustomerId, entity, fieldName, showErrorMessage, allowWalkIn)
}
function CheckValidCustomerCodeWithGST(showErrorMessage, allowWalkIn, fieldName) {
    return docketScript.CheckValidCustomerCodeWithGST(txtCustomerCode, lblCustomerName, hdnCustomerId, 'ContractParty', fieldName, showErrorMessage, allowWalkIn)
}
function GetGstRate() {
    if (!IsObjectNullOrEmpty(ddlTransportMode.val())) {
        var requestData = { transportModeId: ddlTransportMode.val() };
        AjaxRequestWithPostAndJson(gstMasterUrl + '/GetGstServiceAndSacCategoryByTransportModeId', JSON.stringify(requestData), function (result) {
            if (!IsObjectNullOrEmpty(result)) {
                gstSacDetails = result;
                BindDropDownList('ddlGstServiceType', result, 'ServiceTypeId', 'ServiceType', '', '');
                // BindGstState();
               /* BindCustomerGstState();*/
                dvddlGstServiceType.showHide(result.length > 1);
                lblGstServiceType.showHide(result.length == 1);
                ddlGstServiceType.change();
            }
        }, ErrorFunction, false);
    }
}

function OpenGstRegisterForm() {
    if (txtBillLocation.val() == '') {
        ShowMessage('Please select Billing Location');
        txtBillLocation.focus();
        return false;
    }


    $.ajax({
        type: "POST",
        url: gstMasterUrl + '/GstRegistrationPartialView',
        data: '{customerId: "' + hdnBillingPartyId.val() + '",customerCode:"' + lblBillingPartyCode.text() + '",customerName:"' + lblBillingPartyName.text() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            bootbox.dialog({
                title: "Gst Registration",
                message: response,
                buttons: {
                    success: {
                        label: "Registration",
                        className: "btn-success",
                        callback: function () {
                            if (!$("#k-forms").valid()) { return false; }
                            else {
                                var requestData = new FormData();
                                var fileUpload = $("#fuDocumentAttachment").get(0);
                                var files = fileUpload.files;

                                //if (files.length > 0) { requestData.append("GstAttachment", files[0]); }
                                //else {
                                //    ShowMessage( 'Please select file to upload.');
                                //    return false;
                                //}
                                if (files.length > 0) {
                                    var extension = files[0].type.split('/')[1].toUpperCase();
                                    if (extension != "PNG" && extension != "JPG" && extension != "GIF" && extension != "JPEG") {
                                        ShowMessage('Invalid image file format.');
                                        return false;
                                    }
                                }
                                requestData.append("GstDeclarationAttachment", files[0]);
                                requestData.append("IsGstRegistered", rdIsGstRegisteredYes.IsChecked);
                                requestData.append("OwnerType", 3);
                                requestData.append("OwnerId", hdnBillingPartyId.val());
                                requestData.append("StateId", hdnGstStateId.val());
                                requestData.append("CityId", hdnGstCityId.val());
                                requestData.append("Address", txtGstAddress.val());
                                requestData.append("ProvisionalId", txtGstProvisionalId.val());
                                requestData.append("GstTinNo", txtPartyGstTinNo.val());


                                $.ajax({
                                    url: gstMasterUrl + '/GstRegister',
                                    type: "POST", processData: false,
                                    data: requestData,
                                    dataType: 'json',
                                    contentType: false,
                                    success: function (response) {
                                        if (response != null || response != '') {
                                            DemoCallBack.show(response);
                                            SetGstRateAndCategory();
                                        }
                                    },
                                    error: function (er) { }

                                });
                            }
                        }
                    }
                }
            });
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });

    return false;
}

function ViewOldFinancialDetail() {
    $.ajax({
        type: "POST",
        url: baseUrl + '/_DocketFinanceVerification',
        data: '{docketId: "' + hdnDocketId.val() + '",isFinancialUpdate:"' + true + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            bootbox.dialog({
                title: docketNomenclature + " Old Financial Detail",
                message: response
            });
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });

    return false;
}

var docketScript = {
    CustomerAutoCompleteWithGST: function (txtCodeId, lbltxtNameId, hdnId, fieldName, entity, allowWalkin) {
        if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer';
        AutoComplete(txtCodeId, ReplaceUrl('Customer', 'GetAutoCompleteCustomerListByLocationPaybasWithGST'), 'customerName', 'l', 'l', 'l', 'd', '', hdnId, lbltxtNameId, fieldName, true, function () {
            if (entity == 'Consignor')
                return [{ Key: 'locationId', Value: 0 }, { Key: 'PaybasId', Value: 0 }, { Key: 'allowWalkin', Value: allowWalkin }];
            else if (entity == 'Consignee')
                return [{ Key: 'locationId', Value: 0 }, { Key: 'PaybasId', Value: 0 }, { Key: 'allowWalkin', Value: allowWalkin }];
            else
                return [{ Key: 'locationId', Value: loginLocationId }, { Key: 'PaybasId', Value: ddlPaybas.val() }, { Key: 'allowWalkin', Value: allowWalkin }];
        });
    },
    CheckValidCustomerCodeWithGST: function (txtCode, lbltxtName, hdnId, entity, fieldName, showErrorMessage, allowWalkIn, txtAddress1, txtAddress2, hdnCityId, txtCity, txtPincode, txtMobileNo, txtEmailId, txtPartyGstTinNo) {

        if (!txtCode.prop('readOnly')) {
            if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer';

            if (txtCode.val() != '' && txtCode.IsEnabled && ddlPaybas.val() != '') {
                var requestData = { locationId: entity == 'Consignor' ? 0 : entity == 'Consignee' ? 0 : 0, paybasId: ((entity == 'Consignor' || entity == 'Consignee') ? 0 : ddlPaybas.val()), customerCode: txtCode.val(), allowWalkIn: allowWalkIn };
                AjaxRequestWithPostAndJson(customerMasterUrl + '/IsCustomerExistByLocationPaybasWithGST', JSON.stringify(requestData), function (result) {
                    if (result.CustomerId == '') {
                        txtCode.val('').focus();
                        hdnId.val('');
                        if (lbltxtName.Id.substring(0, 3) == 'lbl')
                            lbltxtName.text('');
                        else
                            lbltxtName.val('');
                        if (showErrorMessage)
                            AddRequired(txtCode, 'Invalid ' + fieldName);
                    }
                    else {
                        hdnId.val(result.CustomerId);
                        txtCode.val(result.CustomerCode);
                        if (lbltxtName.Id.substring(0, 3) == 'lbl')
                            lbltxtName.text(result.CustomerName == null ? '' : result.CustomerName);
                        else
                            lbltxtName.val(result.CustomerName);
                        if (txtAddress1 != null && txtAddress1 != undefined)
                            txtAddress1.val(result.Address1);
                        //if (txtAddress2 != null && txtAddress2 != undefined)
                        //    txtAddress2.val(result.Address2);
                        if (hdnCityId != null && hdnCityId != undefined)
                            hdnCityId.val(result.CityId);
                        if (txtCity != null && txtCity != undefined)
                            txtCity.val(result.CityName);
                        //if (txtPincode != null && txtPincode != undefined)
                        //    txtPincode.val(result.Pincode);
                        //if (txtMobileNo != null && txtMobileNo != undefined)
                        //    txtMobileNo.val(result.MobileNo);
                        //if (txtEmailId != null && txtEmailId != undefined)
                        //    txtEmailId.val(result.EmailId);
                        if (txtPartyGstTinNo != null && txtPartyGstTinNo != undefined)
                            txtPartyGstTinNo.val(result.GstTinNo);
                    }
                }, ErrorFunction, false);
            }
        }
        return false;
    },
    AddressCodeAutoCompleteByCustomer: function (txtCodeId, lbltxtNameId, hdnId, fieldName, customerId) {
        AutoComplete(txtCodeId, customerAddressUrl + '/GetAutoCompleteListByCustomerId', 'addressCode', 'l', 'l', 'l', 'd', '', hdnId, lbltxtNameId, fieldName, true, function () {
            return [{ Key: 'customerId', Value: customerId.val() }];
        });
    },
    CustomerAutoComplete: function (txtCodeId, lbltxtNameId, hdnId, fieldName, entity, allowWalkin) {
        if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer';
        AutoComplete(txtCodeId, ReplaceUrl('Customer', 'GetAutoCompleteCustomerListByLocationPaybas'), 'customerName', 'l', 'l', 'l', 'd', '', hdnId, lbltxtNameId, fieldName, true, function () {
            if (entity == 'Consignor')
                return [{ Key: 'locationId', Value: 0 }, { Key: 'PaybasId', Value: 0 }, { Key: 'allowWalkin', Value: allowWalkin }];
            else if (entity == 'Consignee')
                return [{ Key: 'locationId', Value: 0 }, { Key: 'PaybasId', Value: 0 }, { Key: 'allowWalkin', Value: allowWalkin }];
            else
                return [{ Key: 'locationId', Value: loginLocationId }, { Key: 'PaybasId', Value: ddlPaybas.val() }, { Key: 'allowWalkin', Value: allowWalkin }];
        });
    },
    CheckValidCustomerCode: function (txtCode, lbltxtName, hdnId, entity, fieldName, showErrorMessage, allowWalkIn, txtAddress1, txtAddress2, hdnCityId, txtCity, txtPincode, txtMobileNo, txtEmailId, txtPartyGstTinNo) {
        if (!txtCode.prop('readOnly')) {
            if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Customer';

            if (txtCode.val() != '' && txtCode.IsEnabled && ddlPaybas.val() != '') {
                var requestData = { locationId: entity == 'Consignor' ? 0 : entity == 'Consignee' ? 0 : 0, paybasId: ((entity == 'Consignor' || entity == 'Consignee') ? 0 : ddlPaybas.val()), customerCode: txtCode.val(), allowWalkIn: allowWalkIn };
                AjaxRequestWithPostAndJson(customerMasterUrl + '/IsCustomerExistByLocationPaybas', JSON.stringify(requestData), function (result) {
                    if (result.CustomerId == '') {
                        txtCode.val('').focus();
                        hdnId.val('');
                        if (lbltxtName.Id.substring(0, 3) == 'lbl')
                            lbltxtName.text('');
                        else
                            lbltxtName.val('');
                        if (showErrorMessage)
                            AddRequired(txtCode, 'Invalid ' + fieldName);
                    }
                    else {
                        hdnId.val(result.CustomerId);
                        txtCode.val(result.CustomerCode);
                        if (lbltxtName.Id.substring(0, 3) == 'lbl')
                            lbltxtName.text(result.CustomerName == null ? '' : result.CustomerName);
                        else
                            lbltxtName.val(result.CustomerName);
                        if (txtAddress1 != null && txtAddress1 != undefined)
                            txtAddress1.val(result.Address1);
                        //if (txtAddress2 != null && txtAddress2 != undefined)
                        //    txtAddress2.val(result.Address2);
                        if (hdnCityId != null && hdnCityId != undefined)
                            hdnCityId.val(result.CityId);
                        if (txtCity != null && txtCity != undefined)
                            txtCity.val(result.CityName);
                        //if (txtPincode != null && txtPincode != undefined)
                        //    txtPincode.val(result.Pincode);
                        //if (txtMobileNo != null && txtMobileNo != undefined)
                        //    txtMobileNo.val(result.MobileNo);
                        //if (txtEmailId != null && txtEmailId != undefined)
                        //    txtEmailId.val(result.EmailId);
                        if (txtPartyGstTinNo != null && txtPartyGstTinNo != undefined)
                            txtPartyGstTinNo.val(result.GstTinNo);
                    }
                }, ErrorFunction, false);
            }
        }
        return false;
    },
    AddressCodeAutoCompleteByCustomer: function (txtCodeId, lbltxtNameId, hdnId, fieldName, customerId) {
        AutoComplete(txtCodeId, customerAddressUrl + '/GetAutoCompleteListByCustomerId', 'addressCode', 'l', 'l', 'l', 'd', '', hdnId, lbltxtNameId, fieldName, true, function () {
            return [{ Key: 'customerId', Value: customerId.val() }];
        });
    },
    CheckValidAddressCodeByCustomer: function (objAddressCode, objHdnAddressId, field, fieldName, objCustomerId, objCustomerCode, objCustomerName, objAddress1, objAddress2, objCityId, objCityName, objPinCode, objMobileNo, objEmailId, objGstTinNo) {
        if (objAddressCode.val() != '') {
            var requestData = { customerId: objCustomerId.val(), addressCode: objAddressCode.val().split(':')[0].trim() };
            AjaxRequestWithPostAndJson(customerAddressUrl + '/CheckValidAddressCodeByCustomerId', JSON.stringify(requestData), function (result) {
                if (result.AddressId > 0) {
                    objAddressCode.val(result.AddressCode + ' : ' + result.AddressCode);
                    objHdnAddressId.val(result.AddressId);
                    objAddress1.val(result.Address1);
                    objAddress2.val(result.Address2);
                    objCityId.val(result.CityId);
                    objCityName.val(result.CityName);
                    objPinCode.val(result.Pincode);
                    objMobileNo.val(result.MobileNo);
                    objEmailId.val(result.EmailId);
                    //objGstTinNo.val(result.GstTinNo);
                }
                else {
                    objAddressCode.val('').focus();
                    objHdnAddressId.val('');
                    AddRequired(objAddressCode, 'Invalid ' + fieldName + ' Address Code');
                    docketScript.CheckValidCustomerCode(objCustomerCode, objCustomerName, objCustomerId, field, fieldName, false, true, objAddress1, objAddress2, objCityId, objCityName, objPinCode, objMobileNo, objEmailId, objGstTinNo);
                }
            }, ErrorFunction, false);
        }
        else
            docketScript.CheckValidCustomerCode(objCustomerCode, objCustomerName, objCustomerId, field, fieldName, false, true, objAddress1, objAddress2, objCityId, objCityName, objPinCode, objMobileNo, objEmailId, objGstTinNo);
        return false;
    }
}

var partScript = {
    PartAutoComplete: function (txtId, hdnId, hdnConsignor, hdnConsignee) {
        AutoComplete(txtId, ReplaceUrl('Product', 'GetPartAutoCompleteList'), 'productName', 'v', 'l', 'l', 'd', '', hdnId, '', '', true, function () {
            return [{ Key: 'companyId', Value: loginCompanyId }, { Key: 'consignorId', Value: hdnConsignor.val() }, { Key: 'consigneeId', Value: hdnConsignee.val() }];
        });
    },
    CheckValidPart: function (txtPartName, hdnPartId, lblPartDescription, hdnConsignor, hdnConsignee, hdnChargeWeightPerQuantity) {
        if (txtPartName.val() != '') {
            var requestData = { companyId: loginCompanyId, productName: txtPartName.val().trim(), consignorId: hdnConsignor.val(), consigneeId: hdnConsignee.val() };
            AjaxRequestWithPostAndJson(ReplaceUrl('Product', 'IsPartCodeExist'), JSON.stringify(requestData), function (result) {
                if (




                    (result)) {
                    ShowMessage('Invalid Part');
                    hdnPartId.val('');
                    txtPartName.val('');
                    lblPartDescription.text('');
                    txtPartName.focus();
                    return false;
                }
                else {
                    hdnPartId.val(result.ProductId);
                    txtPartName.val(result.ProductCode);
                    lblPartDescription.text(result.ProductName);
                    hdnChargeWeightPerQuantity.val(parseFloat(result.ChargeWeight) / parseFloat(result.UomQuantity));
                }

            }, ErrorFunction, false);
        }
        return false;
    },

    CalculateTotalChargedWeight: function (tableId, txtChargedWeight) {
        var totalPartChargedWeight = 0;
        $('#' + tableId + ' tr:not(:first)').each(function () {
            var hdnChargeWeightPerQuantity = $(this).find('[id*="hdnChargeWeightPerQuantity"]');
            var txtPartQuantity = $(this).find('[id*="txtPartQuantity"]');
            if (txtPartQuantity.length > 0) {
                totalPartChargedWeight += (parseFloat(hdnChargeWeightPerQuantity.val()) * parseFloat(txtPartQuantity.val()));
            }
        });
        txtChargedWeight.val(totalPartChargedWeight.toFixed(3)).change();
        return false;
    }
}

function ValidateDocketDetails() {
    if (ddlPaybas.val() == '2' && ddlServiceType.val() == '2' && isPaymentDetailshow) {
        if (txtFreight.toFloat() == 0 && parseInt(hdnMotherDocketId.val()) == 0) {
            ShowMessage('Freight Amount is Zero. Cannot Enter ' + docketNomenclature);
            return false;
        }
        if (txtFreightRate.toFloat() == 0 && parseInt(hdnMotherDocketId.val()) == 0) {
            ShowMessage('Freight Rate is Zero. Cannot Enter ' + docketNomenclature);
            return false;
        }
    }
    if (ddlPaybas.val() == '4') {
        if (txtFreightRate.toFloat() == 0 && parseInt(hdnMotherDocketId.val()) == 0) {
            ShowMessage('Freight Rate Must be Zero for FOC ' + docketNomenclature);
            return false;
        }
        if (txtFreight.toFloat() == 0 && parseInt(hdnMotherDocketId.val()) == 0) {
            ShowMessage('Freight Amount Must be Zero for FOC ' + docketNomenclature);
            return false;
        }
    }
    else {
        if (chkMultiPickup.IsChecked == false && chkMultiDelivery.IsChecked == false && isPaymentDetailshow) {
            if (txtFreightRate.toFloat() == 0 && parseInt(hdnMotherDocketId.val()) == 0) {
                ShowMessage('Freight Rate is Zero. Cannot Enter ' + docketNomenclature);
                return false;
            }
            if (txtFreight.toFloat() == 0 && parseInt(hdnMotherDocketId.val()) == 0) {
                ShowMessage('Freight Amount is Zero. Cannot Enter ' + docketNomenclature);
                return false;
            }
        }
    }
    return true;
}


function ValidateOnSubmit() {
    //ddlGstPayer.enable();
    ddlRateType.enable();
    $('#chkLocal').enable(true);
    $('#chkVolumetric').enable(true);
    $('#chkPartVolumetric').enable(true);

    if (!ValidateDocketDetails()) {

        isStepValid = false;
        return false;
    }
    if (hdnGstTinNo.val() == "") {
        hdnGstTinNo.val(txtPartyGstTinNo.val());
    }

    //if (isPaymentDetailshow && !ValidateGstDetails()) {
    //    isStepValid = false;
    //    return false;
    //}

    dvStep6.pointerEvent(false);
    return true;
}


function OpenGstVerificationForm(isConsignor) {
    //if (isConsignor) {
    //    if (txtConsignorGstTinNo.val() == '') {
    //        ShowMessage('Please enter GST Tin No.');
    //        txtConsignorGstTinNo.focus();
    //        return false;
    //    }
    //}
    //else {
    //    if (txtConsigneeGstTinNo.val() == '') {
    //        ShowMessage('Please enter GST Tin No.');
    //        txtConsigneeGstTinNo.focus();
    //        return false;
    //    }
    //}

    popup = window.open("https://services.gst.gov.in/services/searchtp", "Popup", "width=700,height=500");
    if (popup != null && !popup.closed) {
        //  txtPopupGstTinNo = popup.document.getElementById("for_gstin");
        popup.focus();
    } else {
        ShowMessage("Popup has been closed.");
    }
    return false;
}


function GetCustomerDetailByGstTinNo(txtGst, txtCode, lbltxtName, hdnId, entity, fieldName, showErrorMessage, allowWalkIn, txtAddress1, txtAddress2, hdnCityId, txtCity, txtPincode, txtMobileNo, txtEmailId, txtPartyGstTinNo) {
    if (txtGst.val() != '') {
        //var requestData = { locationId: entity == 'Consignor' ? loginLocationId : entity == 'Consignee' ? hdnToLocationId.val() : loginLocationId, paybasId: ((entity == 'Consignor' || entity == 'Consignee') ? 0 : ddlPaybas.val()), gstTinNo: txtGst.val(), allowWalkIn: allowWalkIn };
        var requestData = { locationId: 0, paybasId: 0, gstTinNo: txtGst.val(), allowWalkIn: allowWalkIn };
        AjaxRequestWithPostAndJson(baseUrl + '/GetCustomerDetailByGstTinNo', JSON.stringify(requestData), function (result) {
            if (IsObjectNullOrEmpty(result)) {
                txtCode.val('Walk-In');
                hdnId.val('1');
                if (lbltxtName.Id.substring(0, 3) == 'lbl')
                    lbltxtName.text('');
                else
                    lbltxtName.val('');
                if (showErrorMessage)
                    AddRequired(txtCode, 'Invalid ' + fieldName);

                txtAddress1.val('');
                txtAddress2.val('');
                hdnCityId.val('');
                txtCity.val('');
                txtMobileNo.val('');
                txtEmailId.val('');
                txtPincode.val('');
                txtPartyGstTinNo.val(txtGst.val());
                //ShowMessage("Please enter valid GST Tin No");
                //txtGst.val('').focus();
            }
            else {
                hdnId.val(result.CustomerId);
                txtCode.val(result.CustomerCode);
                if (lbltxtName.Id.substring(0, 3) == 'lbl')
                    lbltxtName.text(result.CustomerName == null ? '' : result.CustomerName);
                else
                    lbltxtName.val(result.CustomerName);
                if (txtAddress1 != null && txtAddress1 != undefined)
                    txtAddress1.val(result.Address1);
                if (txtAddress2 != null && txtAddress2 != undefined)
                    txtAddress2.val(result.Address2);
                if (hdnCityId != null && hdnCityId != undefined)
                    hdnCityId.val(result.CityId);
                if (txtCity != null && txtCity != undefined)
                    txtCity.val(result.CityName);
                if (txtPincode != null && txtPincode != undefined)
                    txtPincode.val(result.Pincode);
                if (txtMobileNo != null && txtMobileNo != undefined)
                    txtMobileNo.val(result.MobileNo);
                if (txtEmailId != null && txtEmailId != undefined)
                    txtEmailId.val(result.EmailId);
                if (txtPartyGstTinNo != null && txtPartyGstTinNo != undefined)
                    txtPartyGstTinNo.val(result.GstTinNo);
            }
        }, ErrorFunction, false);
    }

}

function SetBillingPartyGstTinNo(taxPayer, isWalkIn) {
    if (IsObjectNullOrEmpty(isWalkIn)) isWalkIn = false;
    if (taxPayer == 1) {
        lblGstBillingParty.text(txtConsignorCode.val() + ' : ' + txtConsignorName.val());
        txtPartyGstTinNo.val(txtConsignorGstTinNo.val());
    }
    else if (taxPayer == 2) {
        lblGstBillingParty.text(txtConsigneeCode.val() + ' : ' + txtConsigneeName.val());
        txtPartyGstTinNo.val(txtConsigneeGstTinNo.val());
    }
    else if (taxPayer == 3) {
        if (isFinancialUpdate) {
            lblGstBillingParty.text(txtPaymentCustomerCode.val() + ' : ' + lblPaymentCustomerName.text());
        }
        else {
            if (hdnBillingPartyId.val() == "1" && ddlPaybas.val() == "1") {
                lblGstBillingParty.text(txtConsignorCode.val() + ' : ' + txtConsignorName.val());
                txtPartyGstTinNo.val(txtConsignorGstTinNo.val());
            }
            else if (hdnBillingPartyId.val() == "1" && ddlPaybas.val() == "3") {
                lblGstBillingParty.text(txtConsigneeCode.val() + ' : ' + txtConsigneeName.val());
                txtPartyGstTinNo.val(txtConsigneeGstTinNo.val());
            }
            else if (hdnBillingPartyId.val() == hdnConsignorId.val()) {
                lblGstBillingParty.text(txtConsignorCode.val() + ' : ' + txtConsignorName.val());
                txtPartyGstTinNo.val(txtConsignorGstTinNo.val());
            }
            else if (hdnBillingPartyId.val() == hdnConsigneeId.val()) {
                lblGstBillingParty.text(txtConsigneeCode.val() + ' : ' + txtConsigneeName.val());
                txtPartyGstTinNo.val(txtConsigneeGstTinNo.val());
            }
        }
    }
    else if (taxPayer == 4) {
        lblGstBillingParty.text(loginCompanyCode + ' : ' + loginCompanyName);
        txtPartyGstTinNo.val(txtCompanyGstTinNo.val());
    }
    else {
        lblGstBillingParty.text('');
        txtPartyGstTinNo.val('');
    }

    if (!isWalkIn)
        BindCustomerGstState();


    BindGstState('company');
}

function ManageGstExemption() {
    $('#dvDeclarationDocumentDetail').showHide(chkIsGst.IsChecked);
    txtPartyGstTinNo.val('').enable(!chkIsGst.IsChecked);
}

function CheckValidVehicleNo(txtVehicleNo, hdnVehicleId) {
    if (createTripsheet == "True")
        IsVehicleNoExistForTripsheet(txtVehicleNo, hdnVehicleId);
    else
        IsVehicleNoExistByLocation(txtVehicleNo, hdnVehicleId, 'Vehicle No');
}
function IsDocketNoExistByBillingParty(txtObj, hdnObj, fieldName, useValidate, billingPartyId) {
    if (IsObjectNullOrEmpty(fieldName)) fieldName = 'Docket';
    if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
    if (txtObj.val() != "") {
        var requestData = { docketNo: txtObj.val(), billingPartyId: billingPartyId };
        AjaxRequestWithPostAndJson(ReplaceUrl('Docket', 'IsDocketNoExistByBillingParty', 'Operation'), JSON.stringify(requestData), function (result) {
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

function GetMappedBillingParty() {
    var requestData = {
        consignorId: hdnConsignorId.val(),
        consigneeId: hdnConsigneeId.val()
    };

    AjaxRequestWithPostAndJson(baseUrl + '/GetMappedBillingParty', JSON.stringify(requestData), function (result) {
        if (result != null && result.length > 0) {
            BindDropDownList('ddlMappingBillingPartyId', result, 'Value', 'Name', '', 'Select Billing Party');
        }
        else {
            BindDropDownList('ddlMappingBillingPartyId', [], 'Value', 'Name', '', 'Select Billing Party');
        }
    }, ErrorFunction, false);
}

function ManageMappedBillingParty() {
    if (ddlPaybas.val() == "2") {
        $('#dvMappingBillingParty').show();
        AddRequired($('#ddlMappingBillingPartyId'), "Please select Billing Party");
    }
    else {
        $('#dvMappingBillingParty').hide();
        RemoveRequired($('#ddlMappingBillingPartyId'));
    }
}


