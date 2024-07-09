var txtProductCode, hdnProductId, txtProductName, hdnUom, txtBinCode, hdnBinId, lblBinName, ddlWarehouseId, ddlCompanyId, btnSubmit;

$(document).ready(function () {
    SetPageLoad('Stock Register', ' Report', '', '', '');
    hdnProductId = $('#hdnProductId');
    txtProductCode = $('#txtProductCode');
    txtProductName = $('#txtProductName');
    hdnUom = $('#hdnUom');
    txtBinCode = $('#txtBinCode');
    hdnBinId = $('#hdnBinId');
    lblBinName = $('#lblBinName');
    ddlCompanyId = $('#ddlCompanyId');
    ddlWarehouseId = $('#ddlWarehouseId');
    btnSubmit = $('#btnSubmit');
    btnSubmit.click(ViewReport);

    ProductAutoComplete('txtProductCode', 'hdnProductId');
    txtProductCode.blur(function () { return WMS.IsProductCodeExist(txtProductCode, hdnProductId, txtProductName) });

   BinAutoComplete('txtBinCode', 'hdnBinId');
    txtBinCode.blur(function () { return IsBinCodeExist(txtBinCode, hdnBinId, lblBinName) });

    InitMultiSelect(ddlCompanyId.Id, true, true);
    InitMultiSelect(ddlWarehouseId.Id, true, true);

    hdnBinId.val(0);
    hdnProductId.val(0);
});

function ViewReport() {
    var options = $('#ddlWarehouseId option');
    var value = $.map(options, function (option) {
        return option.value;
    });
    var wareHouse = '';
    value.forEach(function (e, index) {
        if (e != '') {
            wareHouse = wareHouse + ',' + e;
        }
    });

    var companyValue = $('#ddlCompanyId option');
    var values = $.map(companyValue, function (option) {
        return option.value;
    });
    var company = '';
    values.forEach(function (e, index) {
        if (e != '') {
            company = company + ',' + e;
        }
    });

    company = company.substr(1);
    wareHouse = wareHouse.substr(1);
    var prmList = [{ Name: "CompanyId", Value: company }, { Name: "WarehouseId", Value: wareHouse },
                   { Name: "ProductId", Value: txtProductCode == '' ? 0 : hdnProductId.val() }, { Name: "BinId", Value: txtBinCode == '' ? 0 : hdnBinId.val() }];
    var reportInfo = { PrmList: prmList, Name: 'WarehouseStock', Description: 'Warehouse Stock Report' };
    return ShowReport(reportInfo);
}