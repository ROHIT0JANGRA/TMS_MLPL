var companyId, warehouseId, baseUrl, drAsnDate, selectedAsnId = 0, dtProductList, dtAsnList;
var ddlSupplierType, txtSupplierCode, hdnSupplierCode, labelSupplierCode, lblSupplierCode;
$(document).ready(function () {
    SetPageLoad('GRN', 'Insert', 'txtGrnDateTime');
    txtSupplierCode = $('#txtSupplierCode');
    hdnSupplierCode = $('#hdnSupplierIdHeader');
    ddlSupplierType = $('#ddlSupplierType');
    hdnGrnId = $('#hdnGrnId');
    hdnAsnId = $('#hdnAsnId');
    lblName = $('#lblName');
    ddlGatepassInNo = $('#ddlGatepassInNo');
    ddlGatepassInNo.change(GetDockNumber);
    labelSupplierCode = $('#labelSupplierCode');
    lblSupplierCode = $('#lblSupplierCode');
    ddlSupplierType.change(OnSupplierTypeChange).change();
    txtSupplierCode.blur(function () { return CheckIsValid(txtSupplierCode, hdnSupplierCode, lblName) });
    drAsnDate = InitDateRange('drAsnDate', DateRange.LastWeek);

    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetAsnListForGrn },
     { StepName: 'ASN List', StepFunction: ValidateStep2 },
     { StepName: 'Generate GRN' }
    ], 'Generate GRN');
});

function OnSupplierTypeChange() {
    txtSupplierCode.val('');
    hdnSupplierCode.val('');
    lblName.text('');
    if (ddlSupplierType.val() == 1) {
        labelSupplierCode.text("Supplier");
        lblSupplierCode.text("Supplier");
        SupplierAutoComplete('txtSupplierCode', 'hdnSupplierCode');
    }
    else {
        labelSupplierCode.text("Customer");
        lblSupplierCode.text("Supplier");
        CustomerAutoComplete('txtSupplierCode', 'hdnSupplierCode');
    }
}

function CheckIsValid(txtSupplierCode, hdnSupplierCode, lblName) {
    if (ddlSupplierType.val() == 1)
        IsSupplierCodeExist(txtSupplierCode, hdnSupplierCode, lblName);
    else
        IsCustomerCodeExist(txtSupplierCode, hdnSupplierCode, lblName)
}

function GetAsnListForGrn() {
    var requestData = {
        CompanyId: companyId, WarehouseId: warehouseId, FromDate: drAsnDate.startDate, ToDate: drAsnDate.endDate,
        SupplierType: ddlSupplierType.val(),
        SupplierId: hdnSupplierCode.val(), PoNo: $('#txtPoNo').val(), InvoiceNo: $('#txtInvoiceNo').val(), AsnNo: $('#txtAsnNo').val()
    };
    AjaxRequestWithPostAndJson(baseUrl + '/GetListForGrn', JSON.stringify(requestData), function (result) {

        if (dtAsnList == null)
            dtAsnList = LoadDataTable('dtAsnList', false, false, false, null, null, [],
              [
                  { title: 'ASN No', data: 'Asn' },
                  { title: 'ASN Date', data: 'AsnDate' },
                  //{ title: 'Invoice No', data: 'InvoiceNo' },
                  //{ title: 'Invoice Date', data: 'InvoiceDate' },
                  { title: 'PO No', data: 'PoNo' },
                  { title: 'PO Date', data: 'PoDate' },
                  { title: 'Supplier', data: 'Supplier' }
              ]);

        dtAsnList.fnClearTable();

        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.Asn = '<div class="clearfix">' +
                                '<label class="radio">' +
                                    '<input type="radio" name=\'asn\' value=\'' + item.AsnId + '\' onclick="SelectDocument(this.id);" tabindex="0" id="chkAsnNo' + i + '"/><i></i>' +
                                    '<label for="chkAsnNo' + i + '">' + item.AsnNo + '</label>' +
                                     '<input type=\'hidden\' id=\'hdnAsnId' + i + '\' value=\'' + item.AsnId + '\' />' +
                                '</label>' +
                            '</div>';

                item.AsnDate = $.displayDate(item.AsnDate);
                //item.InvoiceDate = $.displayDate(item.InvoiceDate);
                item.PoDate = $.displayDate(item.PoDate);
                item.Supplier = item.SupplierCode;
            });
            dtAsnList.dtAddData(result);
            selectedAsnId = 0;
        }
    }, ErrorFunction, false);
    return false;
}
function SelectDocument(rdId) {
    selectedAsnId = $('#' + rdId).val();
}


var ValidateStep2 = function () {
    if (selectedAsnId == 0) {
        isStepValid = false;
        ShowMessage('Please select ASN');
        return false;
    }
    else
        GetAsnDetails();
};


function GetAsnDetails() {
    var requestData = { AsnId: selectedAsnId, WarehouseId: warehouseId, CompanyId: companyId };
    AjaxRequestWithPostAndJson(baseUrl + '/GetAsn', JSON.stringify(requestData), function (result) {
        if (!IsObjectNullOrEmpty(result)) {
            $('#hdnAsnId').val(result.AsnId); $('#lblAsnNo').text(result.AsnNo); $('#hdnAsnNo').val(result.AsnNo);
            $('#hdnInvoiceNo').val(result.InvoiceNo); $('#lblInvoiceNo').text(result.InvoiceNo);
            //$('#hdnInvoiceDate').val($.displayDate(result.InvoiceDate)); $('#lblInvoiceDate').text($.displayDate(result.InvoiceDate));
            $('#hdnPoNo').val(result.PoNo); $('#lblPoNo').text(result.PoNo);
            $('#hdnPoDate').val($.displayDate(result.PoDate)); $('#lblPoDate').text($.displayDate(result.PoDate));
            $('#hdnSupplierId').val(result.SupplierId);
            $('#hdnSupplierType').val(result.SupplierType);
            $('#hdnSupplierCode').val(result.SupplierCode);
            $('#lblSupplierCode').text(result.SupplierCode);
            GetAsnProductDetails(result.Details);
        }

    }, ErrorFunction, false);
    return false;
}

function GetAsnProductDetails(productDetails) {
    if (dtProductList == null)
        dtProductList = LoadDataTable('dtProductList', false, false, false, null, null, [],
          [
              { title: 'Sku Code', data: 'SkuCode' },
              { title: 'Sku Name', data: 'SkuName' },
              { title: 'UOM', data: 'Uom' },
              { title: 'ASN Quantity', data: 'DocumentQuantity' },
              { title: 'Received Quantity', data: 'Quantity' },
              { title: 'Short Quantity', data: 'ShortQuantity' },
              { title: 'Excess Quantity', data: 'ExcessQuantity' },
              { title: '', data: 'SerialNumber' },
              { title: 'Send for Inspection', data: 'InspectionStatus' },
              { title: 'Inspection Quantity', data: 'InspectionQuantity' }
          ]);

    dtProductList.fnClearTable();

    $.each(productDetails, function (i, item) {
        item.SkuCode = '<span>' + item.SkuCode + '</span>' +
                            '<input type=\'hidden\' name="Details[' + i + '].SkuCode" id="hdnProductCode' + i + '" value=' + item.SkuCode + ' />' +
                            '<input type=\'hidden\' name="Details[' + i + '].SkuId" id="hdnProductId' + i + '" value=' + item.SkuId + ' />';
        item.SkuName = '<input type="text" class="form-control textlabel"  value=' + item.SkuName + ' name="Details[' + i + '].SkuName" id="txtSkuName' + i + '" />' +
                              '<span data-valmsg-for="Details[' + i + '].SkuName"></span>';
        item.DocumentQuantity = '<span>' + item.Quantity + '</span>' +
                            '<input type=\'hidden\' name="Details[' + i + '].DocumentQuantity" id="hdnDocumentQuantity' + i + '" value=' + item.Quantity + ' />';
        item.Quantity = '<input type="text" class="form-control numeric3" data-val="true" data-val-required="Please enter Quantity" value=' + item.Quantity + ' name="Details[' + i + '].Quantity" id="txtQuantity' + i + '" value=\'0\'  data-val-range="Please enter Quantity greater than zero" data-val-range-max="999999999" data-val-range-min="0.001"/>' +
                              '<span data-valmsg-for="Details[' + i + '].Quantity" data-valmsg-replace="true"></span>';
        item.ShortQuantity = '<label id="lblShortQuantity' + i + '" class="text-label numeric3">0</label>';
        item.ExcessQuantity = '<label id="lblExcessQuantity' + i + '" class="text-label numeric3">0</label>';
        item.SerialNumber = '<input type=\'hidden\' id="hdnIsSingle' + i + '" value=' + item.IsSingle + ' />' +
                            '<input type=\'hidden\' name="Details[' + i + '].FirstSerialNo" id="hdnFirstSerialNo' + i + '" />' +
                            '<input type=\'hidden\' name="Details[' + i + '].SecondSerialNo" id="hdnSecondSerialNo' + i + '" />' +
                             '<input type=\'hidden\' name="Details[' + i + '].Packages" id="hdnPackages' + i + '" value=' + item.Packages + ' />' +
                            "<button id = 'btnPopUp" + i + "' class='btn btn-primary btn-xs dt-edit'/>" +
                            '<span class="glyphicon glyphicon-search"></span>' +
                            '</button>';
        item.InspectionStatus = "<div class='checkboxer'>" +
                           SelectAll.GetChk(null, 'chkInspectionStatus' + i, 'Details[' + i + '].InspectionStatus', SetInspectionQuantity) +
                            "<input type='hidden' name='Details[" + i + "].InspectionStatus' id='hdnInspectionStatus" + i + "' value='false'/>" +
                           "<label class='control-label' for='chkInspectionStatus" + i + "' id='lblInspectionStatus" + i + "'></label>" +
                           "</div>";
        item.InspectionQuantity = '<input type="text" class="form-control numeric3" disabled data-val="true" data-val-required="Please enter Inspection Quantity" name="Details[' + i + '].InspectionQuantity" id="txtInspectionQuantity' + i + '" value=\'0\' />' +
                             '<span data-valmsg-for="Details[' + i + '].InspectionQuantity" data-valmsg-replace="true"></span>';
    });
    dtProductList.dtAddData(productDetails);
    dtProductList.find('tr').each(function () { $(this).find('td:eq(7)').hide() });
    dtProductList.find('th:eq(7)').hide();
    dtProductList.find('[id*="hdnProductCode"]').each(function () {
        var txtInspectionQuantity = $('#' + this.id.replace('hdnProductCode', 'txtInspectionQuantity'));
        var txtQuantity = $('#' + this.id.replace('hdnProductCode', 'txtQuantity'));
        var grnQuantity = parseFloat(txtQuantity.val());

        var lblShortQuantity = $('#' + this.id.replace('hdnProductCode', 'lblShortQuantity'));
        var lblExcessQuantity = $('#' + this.id.replace('hdnProductCode', 'lblExcessQuantity'));
        var hdnDocumentQuantity = $('#' + this.id.replace('hdnProductCode', 'hdnDocumentQuantity'));


        txtQuantity.blur(function () {
            var quantity = hdnDocumentQuantity.toFloat() - txtQuantity.toFloat();
            lblShortQuantity.text(0);
            lblExcessQuantity.text(0);

            if (quantity > 0)
                lblShortQuantity.text(quantity);
            else if (quantity < 0)
                lblExcessQuantity.text(quantity * -1);
            if (txtInspectionQuantity.toFloat() > txtQuantity.toFloat())
                txtInspectionQuantity.val(txtQuantity.val());
            RemoveRange(txtInspectionQuantity);
            AddRange(txtInspectionQuantity, 'Please enter Inspection Quantity less than or equal to Received Quantity ' + txtQuantity.toFloat().toFixed(3), 0, txtQuantity.toFloat());
        });
    });

    CheckIsSerialNumber();
    ScanSerialNumber();
}

function InitBinTable()
{ }

function CheckIsSerialNumber() {
    $('[id*="btnPopUp"]').each(function () {
        var btnPopUp = $(this);
        var hdnIsSingle = $('#' + btnPopUp.attr('id').replace('btnPopUp', 'hdnIsSingle'));
        var txtQuantity = $('#' + btnPopUp.attr('id').replace('btnPopUp', 'txtQuantity'));
        if (hdnIsSingle.val() == "null")
            btnPopUp.hide();
        else
            btnPopUp.show();
        txtQuantity.attr('readOnly', false);
    });
}

function ScanSerialNumber() {
    $('[id*="btnPopUp"]').click(function () {
        var btnPopUp = $(this);
        var hdnIsSingle = $('#' + btnPopUp.attr('id').replace('btnPopUp', 'hdnIsSingle'));
        var hdnProductId = $('#' + btnPopUp.attr('id').replace('btnPopUp', 'hdnProductId'));
        var popup;

        popup = window.open("../../WMS/Grn/ScanSerialNumber?productId=" + hdnProductId.val() + "&rowId=" + btnPopUp.Id + "&isSingle=" + hdnIsSingle.val() + "&grnId=" + hdnGrnId.val(), "Popup", "toolbar=yes,scrollbars=yes,resizable=yes,top=500,left=600,width=1300,height=650");
        popup.focus();
        return false;

    });
}

function SetInspectionQuantity() {
    $('[id*="chkInspectionStatus"]').each(function () {
        var chkInspectionStatus = $(this);
        var txtInspectionQuantity = $('#' + chkInspectionStatus.Id.replace('chkInspectionStatus', 'txtInspectionQuantity'));
        txtInspectionQuantity.enable(chkInspectionStatus.IsChecked).val(0);
    });
}

function CalculateQuantity() {
    $('[id*="hdnProductId"]').each(function () {
        var hdnProductId = $(this);
        var txtQuantity = $('#' + hdnProductId.Id.replace('hdnProductId', 'txtQuantity'));
        var txtInspectionQuantity = $('#' + hdnProductId.Id.replace('hdnProductId', 'txtInspectionQuantity'));
        var txtCrossDockQuantity = $('#' + hdnProductId.Id.replace('hdnProductId', 'txtCrossDockQuantity'));
    });


}

function GetDockNumber() {
    var requestData = { GatepassInId: ddlGatepassInNo.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetDockNumberFromGatePassIn', JSON.stringify(requestData), function (result) {
        if (!IsObjectNullOrEmpty(result)) {
            $('#lblDockNumber').text(result[0].DockNo);
        }

    }, ErrorFunction, false);
    return false;
}
