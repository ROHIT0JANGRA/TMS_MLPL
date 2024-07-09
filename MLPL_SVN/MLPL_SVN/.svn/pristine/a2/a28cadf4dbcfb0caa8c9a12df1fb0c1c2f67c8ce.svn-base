var BalancePackages;
var docketNomenclature;
$(document).ready(function () {
    SetPageLoad('Labour DC', 'Generate', 'drDocketDate');

    InitWizard('dvWizard', [{ StepName: 'Criteria', StepFunction: GetManifestList },
    { StepName: 'Document List', StepFunction: ValidateOnStep2 }
    ], 'Generate ');

    ddlLocationId = $('#ddlLocationId'); hdnVendorId = $('#hdnVendorId');
    drDocketDate = InitDateRange('drDocketDate', DateRange.LastWeek, false);

    dtDocketDetails = $('#dtDocketDetails');
    dtThcDetails = $('#dtThcDetails');
    txtManifestsNo = $('#txtManifestsNo'); 
    txtTotalAmount = $('#txtTotalAmount'); 
    hdnTotalDocket = $('#hdnTotalDocket');
    lblDocumentName = $('#lblDocumentName');
    ddlDocumentType = $('#ddlDocumentType');
    lblDocumentTypeName = $('#lblDocumentTypeName');
    txtThcTotalAmount = $('#txtThcTotalAmount');
    divTHCType = $('#divTHCType');
    ddlTHCType = $('#ddlTHCType');


    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [
            { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllManifest', CountTotalLoading) + "</div>", data: "ManifestId", width: 80 },
            { title: 'Document No', data: "ManifestNo" },
            { title: "<div class='clearfix' style='width:100px'> Document Date </div>", data: "ManifestDate" },
            { title: 'Location', data: "LocationCode" },
            { title: 'No of Docket', data: "NoofDocket" },
            { title: 'Packages', data: "Packages" },
            { title: 'Actual Weight', data: "ActualWeight" },
            { title: 'Rate Type', data: "RateType" },
            { title: 'Rate', data: "Rate" },
            { title: 'Amount', data: "Amount" }
        ]);

    dtThcDetails = LoadDataTable('dtThcDetails', false, false, false, null, null, [],
        [
            { title: "<div class='clearfix' style='width:80px'>" + SelectAll.GetChkAll('chkAllManifest', CountTotalLoading) + "</div>", data: "ManifestId", width: 80 },
            { title: 'Document No', data: "ManifestNo" },
            { title: "<div class='clearfix' style='width:100px'> Document Date </div>", data: "ManifestDate" },
            { title: 'Location', data: "LocationCode" },
            { title: 'No of Docket', data: "NoofDocket" },
            { title: 'Charges Type', data: "ChargesType" },
            { title: 'Packages', data: "Packages" },
            { title: 'Actual Weight', data: "ActualWeight" },
            { title: 'Rate Type', data: "RateType" },
            { title: 'Rate', data: "Rate" },
            { title: 'Amount', data: "Amount" }
        ]);
    VendorAutoComplete('txtVendorCode', 'hdnVendorId', '', 9);
    $('#txtVendorCode').blur(function () { IsVendorCodeExist($('#txtVendorCode'), $('#hdnVendorId'), $('#lblVendorName'), '', 9); });

    ddlDocumentType.change(OnDocumentTypeChange).change();
    //ddlTHCType.change(OnTHCTypeChange).change();

});

function OnTHCTypeChange() {

    if (ddlDocumentType.val() == 3) {
        divTHCType.show();
    }
    else {
        divTHCType.hide();
    }

}

function OnDocumentTypeChange() {

    if (ddlDocumentType.val() == 1) {
        lblDocumentName.text("DRS(s)");
        lblDocumentTypeName.text("DRS");
    }
    else if (ddlDocumentType.val() == 2) {
        lblDocumentName.text("PRS(s)");
        lblDocumentTypeName.text("PRS");

    }
    else if (ddlDocumentType.val() == 3) {
        lblDocumentName.text("THC(s)");
        lblDocumentTypeName.text("THC");

    }
    OnTHCTypeChange();
}

function GetManifestList() {
    var requestData = {
        locationId: ddlLocationId.val(),
        fromDate: $.displayDate(drDocketDate.startDate),
        toDate: $.displayDate(drDocketDate.endDate),
        docketList: txtManifestsNo.val(),
        DocumentType: ddlDocumentType.val(),
        THCType: ddlTHCType.val()
    };
    AjaxRequestWithPostAndJson(baseUrl, JSON.stringify(requestData), GetDocketListSuccess, ErrorFunction, false);
    return false;
}

function GetDocketListSuccess(responseData) {
    if (responseData.length === 0) {
        isStepValid = false;
        ShowMessage('No Record Found');
        return false;
    }
    dtThcDetails.fnClearTable();
    dtDocketDetails.fnClearTable();

    if (ddlDocumentType.val() != 3)
    {
        dtThcDetails.hide();

        if (responseData.length > 0) {
            $.each(responseData, function (i, item) {

                item.ManifestId = SelectAll.GetChk('chkAllManifest', 'chkManifest' + i, 'ManifestList[' + i + '].IsChecked', CountTotalLoading) +
                    "<input type='hidden' value='" + item.ManifestId + "' name='ManifestList[" + i + "].ManifestId' id='hdnManifestId" + i + "'/>" +
                    "<input type='hidden' value='" + item.LoadunloadId + "' name='ManifestList[" + i + "].LoadunloadId' id='hdnLoadunloadId" + i + "'/>" +
                    "<label class='label' for='chkManifest" + i + "' id='lblManifestId" + i + "'></label>";

                item.ManifestDate = $.displayDate(item.ManifestDate);

                item.NoofDocket = '<input class="form-control textlabel numeric" name="ManifestList[' + i + '].NoofDocket" id="txtNoofDocket' + i + '" type="text" value=\'' + item.NoofDocket + '\'/>';

                item.Packages = '<input class="form-control textlabel numeric" name="ManifestList[' + i + '].Packages" id="txtPackages' + i + '" type="text" value=\'' + item.Packages + '\'/>';

                item.ActualWeight = '<input class="form-control textlabel numeric" name="ManifestList[' + i + '].ActualWeight" id="txtActualWeight' + i + '" type="text" value=\'' + item.ActualWeight + '\'/>';

                item.Amount = '<input class="form-control textlabel numeric" name="ManifestList[' + i + '].Amount" id="txtAmount' + i + '" type="text" value=\'' + item.Amount + '\'/>';

                item.Rate = '<input class="form-control numeric3" name="ManifestList[' + i + '].Rate" id="txtRate' + i + '" type="text"  value=\'' + item.Rate + '\'/>' +
                    '<span data-valmsg-for="ManifestList[' + i + '].Rate" data-valmsg-replace="true"></span>';

                item.RateType = '<div class="select"> <select class="form-control" name="ManifestList[' + i + '].RateType" id="ddlRateType' + i + '" ><option value="1">Package</option><option value="2">Actual Weight</option><option value="3">Flat</option> </select> <i></i></div>';
            });
            dtDocketDetails.dtAddData(responseData, [], InitDocketTable);


        }
    }
    else
    {
        dtDocketDetails.hide();

        if (responseData.length > 0) {
            $.each(responseData, function (i, item) {

                item.ManifestId = SelectAll.GetChk('chkAllManifest', 'chkManifest' + i, 'ManifestList[' + i + '].IsChecked', CountTotalLoading) +
                    "<input type='hidden' value='" + item.ManifestId + "' name='ManifestList[" + i + "].ManifestId' id='hdnManifestId" + i + "'/>" +
                    "<input type='hidden' value='" + item.LoadunloadId + "' name='ManifestList[" + i + "].LoadunloadId' id='hdnLoadunloadId" + i + "'/>" +
                    "<label class='label' for='chkManifest" + i + "' id='lblManifestId" + i + "'></label>";

                item.ManifestDate = $.displayDate(item.ManifestDate);

                item.NoofDocket = '<input class="form-control textlabel numeric" name="ManifestList[' + i + '].NoofDocket" id="txtNoofDocket' + i + '" type="text" value=\'' + item.NoofDocket + '\'/>';

                item.Packages = '<input class="form-control textlabel numeric" name="ManifestList[' + i + '].Packages" id="txtPackages' + i + '" type="text" value=\'' + item.Packages + '\'/>';

                item.ActualWeight = '<input class="form-control textlabel numeric" name="ManifestList[' + i + '].ActualWeight" id="txtActualWeight' + i + '" type="text" value=\'' + item.ActualWeight + '\'/>';

                item.Amount = '<input class="form-control textlabel numeric" name="ManifestList[' + i + '].Amount" id="txtAmount' + i + '" type="text" value=\'' + item.Amount + '\'/>';

                item.Rate = '<input class="form-control numeric3" name="ManifestList[' + i + '].Rate" id="txtRate' + i + '" type="text"  value=\'' + item.Rate + '\'/>' +
                    '<span data-valmsg-for="ManifestList[' + i + '].Rate" data-valmsg-replace="true"></span>';

                item.RateType = '<div class="select"> <select class="form-control" name="ManifestList[' + i + '].RateType" id="ddlRateType' + i + '" ><option value="1">Package</option><option value="2">Actual Weight</option><option value="3">Flat</option> </select> <i></i></div>';
            });
            dtThcDetails.dtAddData(responseData, [], InitDocketTable);
        }
    }
}

function InitDocketTable() {
    $('[id*="chkManifest"]').each(function () {
        var chkManifest = $(this);
        var txtPackages = $('#' + chkManifest.Id.replace('chkManifest', 'txtPackages'));
        var txtActualWeight = $('#' + chkManifest.Id.replace('chkManifest', 'txtActualWeight'));
        var ddlRateType = $('#' + chkManifest.Id.replace('chkManifest', 'ddlRateType'));
        var txtRate = $('#' + chkManifest.Id.replace('chkManifest', 'txtRate'));
        var txtAmount = $('#' + chkManifest.Id.replace('chkManifest', 'txtAmount'));

        txtRate.blur(function () {
            CalculateAmount(txtPackages, txtActualWeight, ddlRateType, txtRate, txtAmount);
        });

        ddlRateType.change(function () {

            CalculateAmount(txtPackages, txtActualWeight, ddlRateType, txtRate, txtAmount);
        });
    });
}
function CalculateAmount(txtPackages, txtActualWeight, ddlRateType, txtRate, txtAmount) {

    var Packages, ActualWeight, Rate, Amount, Qty;

    if (txtPackages.val() == "")
    {
        Packages = 0
    }
    else
    {
        Packages = parseFloat(txtPackages.val())
    }
    if (txtActualWeight.val() == "") {
        ActualWeight = 0
    }
    else {
        ActualWeight = parseFloat(txtActualWeight.val())
    }

    if (txtRate.val() == "") {
        Rate = 0
    }
    else {
        Rate = parseFloat(txtRate.val())
    }

    if (ddlRateType.val() == "1")
    {
        Qty = Packages;
    }
    else if (ddlRateType.val() == "2")
    {
        Qty = ActualWeight;
    }
    else
    {
        Qty = 1;
    }

    Amount = Rate * Qty;
    txtAmount.val(Amount);

    CountTotalLoading();
}

function OnPackagesChange(obj) {
    var txtLoadPackages = $(obj);
    txtLoadPackages.val(txtLoadPackages.round());
    var hdnPackages = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'hdnPackages'));


    if (hdnPackages.toInt() < txtLoadPackages.toInt())
        txtLoadPackages.val(hdnPackages.val());
    var txtLoadActualWeight = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'txtLoadActualWeight'));
    var txtLoadKartAmount = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'txtLoadKartAmount'));

    var hdnActualWeight = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'hdnActualWeight'));
    var hdnKartAmount = $('#' + txtLoadPackages.attr('id').replace('txtLoadPackages', 'hdnKartAmount'));

    txtLoadActualWeight.val((parseFloat(txtLoadPackages.val()) * parseFloat(hdnActualWeight.val()) / parseFloat(hdnPackages.val())).toFixed(3));
    txtLoadKartAmount.val((parseFloat(txtLoadPackages.val()) * parseFloat(hdnKartAmount.val()) / parseFloat(hdnPackages.val())).toFixed(2));
    CountTotalLoading();
}

function CountTotalLoading() {
    var totalDocket = 0; totalPackages = 0, totalActualWeight = 0.000, totalAmount = 0.00;

   $('[id*="chkManifest"]').each(function () {
        var chkManifest = $(this);
        if (chkManifest.IsChecked) {
            var txtAmount = $('#' + chkManifest.Id.replace('chkManifest', 'txtAmount'));
            totalDocket++;
            totalAmount += parseFloat(txtAmount.val());
        }
    });
   txtTotalAmount.val(totalAmount.toFixed(2));
//txtThcTotalAmount
   txtThcTotalAmount.val(totalAmount.toFixed(2));

}

function ValidateOnStep2() {

    var Rate;
    var Index;
    Index = 0;


    $('[id*="chkManifest"]').each(function () {
        var chkManifest = $(this);
        if (chkManifest.IsChecked) {
            var txtRate = $('#' + chkManifest.Id.replace('chkManifest', 'txtRate'));

            if (txtRate.val() == "") {
                Rate = 0
            }
            else {
                Rate = parseFloat(txtRate.val())
            }

            if (Rate == 0) {
                isStepValid = false;
                ShowMessage('Rate is not valid');
                return false;
            }

            Index = Index + 1;
        }
    });

    if (Index == 0) {
        isStepValid = false;
        ShowMessage('Please select atleast on record');
        return false;
    }

}

function ValidateOnSubmit() {
    //if (!ValidateModuleDateWithPreviousDocumentDate('dtDocketDetails', 'chkDocket', 'hdnDocketDate', 'txtManifestDateTime', manifestNomenclature+' Date')) return false;
}