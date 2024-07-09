var dtPutAwayList, selectedPutAwayId = 0, lblLabourName;
function GetPutAwayListForUpdate() {
    var requestData = { CompanyId: companyId, WarehouseId: warehouseId, FromDate: drPutAwayDate.startDate, ToDate: drPutAwayDate.endDate, PutAwayNo: $('#txtPutAwayNoHdr').val(), GrnNo: $('#txtGrnNo').val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetPutAwayListForUpdate', JSON.stringify(requestData), function (result) {
        if (dtPutAwayList == null)
            dtPutAwayList = LoadDataTable('dtPutAwayList', false, false, false, null, null, [],
              [
                  { title: 'Put Away No', data: 'PutAway' },
                  { title: 'Put Away Date', data: 'PutAwayDate' },
                  { title: 'Labour', data: 'Labour' },
              ]);
        dtPutAwayList.fnClearTable();
        isStepValid = result.length > 0;
        if (result.length == 0) {
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.PutAway = '<div class="clearfix">' +
            '<label class="radio">' +
            '<input type="radio" name=\'Document\' value=\'' + item.PutAwayId + '\' onclick="SetPutAwayDetail(this);" tabindex="0" id="rdPutAwayNo' + i + '"/><i></i>' +
            '<label for="rdPutAwayNo' + i + '">' + item.PutAwayNo + '</label>' +
            "<input type='hidden' value='" + item.PutAwayNo + "' id='hdnPutAwayNo" + i + "'/>" +
            '</label>' +
            '</div>';
                item.PutAwayDate = $.displayDate(item.PutAwayDate);
                item.Labour = "<input type='hidden' value='" + item.LabourId + "' name='LabourId' id='hdnLabourId" + i + "'/>" +
                               "<label id='lblLabourName" + i + "'>" + item.LabourName + "</label>";
            });
            dtPutAwayList.dtAddData(result);
            selectedPutAwayId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

function SetPutAwayDetail(rd) {
    selectedPutAwayId = rd.value;
    $('#hdnPutAwayId').val(rd.value);
    $('#hdnLabourId').val($('#' + rd.id.replace('rdPutAwayNo', 'hdnLabourId')).val());
    $('#txtLabourName').val($('#' + rd.id.replace('rdPutAwayNo', 'lblLabourName')).text());
    $('#txtPutAwayNo').val($('#' + rd.id.replace('rdPutAwayNo', 'hdnPutAwayNo')).val());
}

var dtPutAwayDetails;
function GetPutAwayDetailsForUpdate() {
    isStepValid = selectedPutAwayId != 0;
    if (selectedPutAwayId == 0) {
        ShowMessage('Please select Put Away');
        return false;
    }
    var requestData = { CompanyId: companyId, WarehouseId: warehouseId, PutAwayId: selectedPutAwayId };
    AjaxRequestWithPostAndJson(baseUrl + '/GetPutAwayDetailsForUpdate', JSON.stringify(requestData), function (result) {
        if (dtPutAwayDetails == null)
            dtPutAwayDetails = LoadDataTable('dtPutAwayDetails', false, false, false, null, null, [],
              [
                  { title: 'GRN No', data: 'GrnId' },
                  { title: 'Sku Code', data: 'SkuCode' },
                  { title: 'Sku Name', data: 'SkuName' },
                  { title: 'GRN Quantity', data: 'GrnQuantity' },
                  { title: 'Location Detail', data: 'LocationDetail' },
                  { title: 'Put Away Quantity', data: 'Quantity' }
              ]);
        dtPutAwayDetails.fnClearTable();
        isStepValid = result.length > 0;
        if (result.length == 0) {
            ShowMessage('No Record Found');
            return false;
        }
        else {
            $.each(result, function (i, item) {
                item.GrnQuantity = item.GrnQuantity.toFixed(3);
                item.GrnId = "<input type='hidden' value='" + item.GrnId + "' name='Details[" + i + "].GrnId' id='hdnGrnId" + i + "'/>" +
                             "<input type='hidden' value='" + item.SkuId + "' name='Details[" + i + "].SkuId' id='hdnProductId" + i + "'/>" +
                             "<input type='hidden' value='" + item.Quantity + "' name='Details[" + i + "].Quantity' id='hdnQuantityId" + i + "'/>" +
                             "<input type='hidden' value='" + item.GrnQuantity + "' name='Details[" + i + "].GrnQuantity' id='hdnGrnQuantity" + i + "'/>" +
                             "<input type='hidden' value='" + (item.IsSingle == null ? false : true) + "' name='Details[" + i + "].IsSingle' id='hdnIsSingle" + i + "'/>" +
                             "<span>" + item.GrnNo + "</span>";
                item.Quantity = '<input type="text" name="Details[' + i + '].TotalQuantity" id="txtTotalQuantity' + i + '" value=' + item.GrnQuantity + ' class="textlabel" disabled/>';
                item.LocationDetail =
                                '<table id="tblBin' + i + '" class="innerTable">' +
                    '<thead class="display-none"><th>Bin Code</th><th>Quantity</th><th></th><th></th></thead>' +
                    '<tbody>' +
                        '<tr class="innerRow">' +
                            '<td>' +
                                '<input type="text" placeholder="Bin Code" name="Details[' + i + '].BinDetails[0].BinCode" id="txtBinCode_dtBin' + i + '_0" class="form-control form-control-grid"/>' +
                                '<span data-valmsg-for="Details[' + i + '].BinDetails[0].BinCode" data-valmsg-replace="true"></span>' +
                                '<input type="hidden" name="Details[' + i + '].BinDetails[0].BinId" id="hdnBinId_dtBin' + i + '_0" class="form-control" />' +
                            '</td>' +
                            '<td>' +
                                '<input type="text" name="Details[' + i + '].BinDetails[0].Quantity" id="txtQuantity_dtBin' + i + '_0" class="form-control numeric3 form-control-grid"/>' +
                                '<span data-valmsg-for="Details[' + i + '].BinDetails[0].Quantity" data-valmsg-replace="true"></span>' +
                            '</td>' +
                            '<td id="tdSerialNo' + i + '">' +
                                '<input type=\'hidden\' name="Details[' + i + '].BinDetails[0].FirstSerialNo" id="hdnFirstSerialNo_dtBin' + i + '_0" />' +
                                '<input type=\'hidden\' name="Details[' + i + '].BinDetails[0].SecondSerialNo" id="hdnSecondSerialNo_dtBin' + i + '_0" />' +
                                '<button id = "btnPopUp_dtBin' + i + '_0" onclick="OnPopUpClick(this.id)" class="btn btn-primary btn-xs dt-edit"/>' +
                                '<span class="glyphicon glyphicon-search"></span>' +
                                '</button>' +
                            '</td>' +
                            '<td width="70px"></td>' +
                            '</tr></tbody>' +
                '</table>'
                +
                                 '<span data-valmsg-for="Details[' + i + '].TotalQuantity" data-valmsg-replace="true"></span>';
            });
            dtPutAwayDetails.dtAddData(result);
            CheckIsSerialNumber();

            dtPutAwayDetails.find('[id*="txtTotalQuantity"]').each(function () {
                var hdnGrnQuantity = $('#' + this.id.replace('txtTotalQuantity', 'hdnGrnQuantity'));
                var txtTotalQuantity = $('#' + this.id.replace('txtTotalQuantity', 'txtTotalQuantity'));
                var grnQuantity = parseFloat(hdnGrnQuantity.val());
                AddRange(txtTotalQuantity, 'Total Quantity must be ' + grnQuantity.toFixed(3), grnQuantity, grnQuantity)
            });

            $('[id*="tblBin"]').each(function () {
                var tblId = $(this).Id;
                InitGrid(tblId, false, 3, InitBinTable);
            });
        }
    }, ErrorFunction, false);
    return false;
}

function ValidateTotalQuantity(txtQuantity) {
    var tbl = $(txtQuantity).closest('table');
    var txtTotalQuantity = tbl.closest('tr').find('[id *= "txtTotalQuantity"]');
    var totalQuantity = 0;
    $('#' + tbl.Id).find('[id*="txtQuantity"]').each(function () {
        totalQuantity += $(this).round(3);
    });
    txtTotalQuantity.val(totalQuantity.toFixed(3));
}

function InitBinTable(tblId) {
    $('#' + tblId).find('[id*="txtBinCode"]').each(function () {
        var txtBinCode = $(this);
        var hdnBinId = $('#' + this.id.replace('txtBinCode', 'hdnBinId'));
        var txtQuantity = $('#' + this.id.replace('txtBinCode', 'txtQuantity'));
        txtBinCode.blur(function () {
            if (!CheckDuplicateInTable($(this).closest('table').Id, 'txtBinCode', 'Bin Code', txtBinCode)) return false;
            IsBinCodeExist(txtBinCode, hdnBinId);
        });
        BinAutoComplete(txtBinCode.Id, hdnBinId.Id);
        AddRequired(txtBinCode, 'Please enter Bin Code');

        var tbl = txtQuantity.closest('table');
        var hdnGrnQuantity = tbl.closest('tr').find('[id *= "hdnGrnQuantity"]');
        RemoveRange(txtQuantity);
        AddRange(txtQuantity, 'Please enter Quantity less than or equal to ' + hdnGrnQuantity.val(), 1, hdnGrnQuantity.toFloat());

        txtQuantity.blur(function () { ValidateTotalQuantity($(this)) });
    });
}

function CheckIsSerialNumber() {
    $('[id*="tdSerialNo"]').each(function () {
        var hdnIsSingle = $('#' + this.id.replace('tdSerialNo', 'hdnIsSingle'));
        var tblBin = $('#' + this.id.replace('tdSerialNo', 'tblBin'));
        if (hdnIsSingle.val() == 'false')
            $(this).hide();
        tblBin.find('[id*="txtQuantity"]').each(function () {
            var txtQuantity = $(this);
            if (hdnIsSingle.val() == 'false')
                $(this).attr('readOnly', false);
            else
                $(this).attr('readOnly', true);
        });
    });
}

function OnPopUpClick(btnPopUp) {
    var btnPopUp = $('#' + btnPopUp);
    var tbl = btnPopUp.closest('table');
    var hdnProductId = tbl.closest('tr').find('[id *= "hdnProductId"]');
    var hdnGrnId = tbl.closest('tr').find('[id *= "hdnGrnId"]');
    var hdnIsSingle = tbl.closest('tr').find('[id *= "hdnIsSingle"]');
    var txtQuantity = $('#' + btnPopUp.attr('id').replace('btnPopUp', 'txtQuantity'));
    var popup = window.open("../../WMS/Grn/PopUpMenu?productId=" + hdnProductId.val() + "&rowId=" + btnPopUp.Id + "&isSingle=" + hdnIsSingle.val() + "&grnId=" + hdnGrnId.val(), "Popup", "toolbar=yes,scrollbars=yes,resizable=yes,top=500,left=600,width=1300,height=650");
    popup.focus();
    return false;
}

function ValidateOnSubmit() {
    var returnStatus = true;
    $("[id*='tblBin']").each(function () {
        if (returnStatus) {
            var tblBin = $(this);
            var hdnGrnQuantity = $('#' + this.id.replace('tblBin', 'hdnGrnQuantity'));
            var totalQuantity = 0;
            var txtQunatity = null;
            tblBin.find('[id*="txtQuantity"]').each(function () {
                if (txtQunatity == null) txtQunatity = $(this);
                totalQuantity += $(this).round(3);
            });
            if (totalQuantity != hdnGrnQuantity.toFloat()) {
                ShowMessage('Total Quantity must be ' + hdnGrnQuantity.val());
                txtQunatity.focus();
                returnStatus = false;
                return false;
            }
        }
    });
    isStepValid = returnStatus;
    return returnStatus;
}