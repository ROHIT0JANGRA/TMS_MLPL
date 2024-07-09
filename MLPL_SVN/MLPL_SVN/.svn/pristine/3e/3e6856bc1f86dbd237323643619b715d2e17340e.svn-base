var drThcDate, txtThcNo, txtVehicleNo, ddlArrivalLocation, dtThcDetails, ThcUrl, selectedThcId, dtDocketDetails, shortReasonList, extraReasonList, pilferReasonList, damageReasonList,
    arrivalConditionList, deliveryProcessList, lateDeliveryReasonList, warehouseList, docketNomenclature, currentDate, dateTimeFormat,IsDaccUpdatedFlag;
var deliveryProcess;
var labourVendorList, vendorMasterUrl,useLabourVendor = false;
$(document).ready(function () {
    SetPageLoad('Thc', 'Stock Update', '', '', '');
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetThcList },
        { StepName: 'Thc Details', StepFunction: LoadStep3 },
        { StepName: 'Basic Details', StepFunction: ValidateOnSubmit }
    ], 'Stock Update');
    InitObjects();
    deliveryProcess = "N";
    var request = { moduleId: 1, ruleId: 200 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(request), function (result) {
        deliveryProcess = result;//  if (result == "N") { dvUploadFile.hide(); }
    }, ErrorFunction, false);
    var requestData = { moduleId: 5, ruleId: 6 };
    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(requestData), function (result) {
        useLabourVendor = result == 'Y' ? true : false;
    }, ErrorFunction, false);

});

function InitObjects() {
    drThcDate = InitDateRange('drThcDate', DateRange.LastWeek);
    txtThcNo = $('#txtThcNo');
    txtVehicleNo = $('#txtVehicleNo');
    txtDocketNo = $('#txtDocketNo');
    ddlArrivalLocation = $('#ddlArrivalLocation');
    dtThcDetails = LoadDataTable('dtThcDetails', false, false, false, null, null, [],
        [
            { title: 'Thc No', data: 'ThcNo' },
            { title: 'Thc Date', data: 'ThcDateTime' },
            { title: 'Previous Branch', data: 'FromLocationCode' },
            { title: 'Arrival Date & Time', data: 'ActualArrivalDate' },
            { title: 'Total ' + docketNomenclature + '(s)', data: 'TotalDocket' }
        ]);
    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [   
            { data: 'ManifestId', },
            { data: 'DocketId',},
            { data: 'DocketNo' },
            { data: 'DocketDate' },
            { data: 'FromLocationCode' },
            { data: 'ToLocationCode' },
            { data: 'FromCity' },
            { data: 'ToCity' },
            { data: 'DeliveryDate' },
            { data: 'ArrivalPackages' },
            { data: 'ArrivalWeight' },
            { data: "ArrivalCondition", width: 80 },
            { data: "LabourVendor", width: 80 },
            { data: "Warehouse", width: 80 },
            { data: "DeliveryProcess", width: 80 },
            { data: 'DEPS' }
        ]);
}

function GetThcList() {

    var thcNo = txtThcNo.val();
    var vehicleNo = txtVehicleNo.val();
    var arrivalLocation = ddlArrivalLocation.val();
    var docketNo = txtDocketNo.val();
    var requestData = { thcNos: thcNo, fromDate: drThcDate.startDate, toDate: drThcDate.endDate, vehicleNos: vehicleNo, arrivalLocations: arrivalLocation, docketNos: docketNo };

    AjaxRequestWithPostAndJson(ThcUrl + '/GetThcListForStockUpdate', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedThc = [];
            dtThcDetails.fnClearTable();
            $.each(result, function (i, item) {
                item.ThcNo = '<div class="clearfix">' +
                    '<label class="radio">' +
                    '<input type="radio" name=\'Thc\' value=\'' + item.ThcId + '\' onclick="GetThcDetail(this)" tabindex="0" id="chkThcNo' + i + '"/><i></i>' +
                    '<label for="chkThcNo' + i + '">' + item.ThcNo + '</label>' +
                    "<input type='hidden' value='" + item.ActualArrivalDate + "'  id='hdnActualArrivalDate" + i + "'/>" +
                    '</label>' +
                    '</div>';
                item.ThcDateTime = $.displayDate(item.ThcDateTime);
                item.ActualArrivalDate = $.displayDateTime(item.ActualArrivalDate);
            });
            dtThcDetails.dtAddData(result);
            selectedThcId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

function GetThcDetail(rd) {
    selectedThcId = rd.value;
}

function LoadStep3() {
    isStepValid = selectedThcId !== 0;
    if (selectedThcId == 0) {
        ShowMessage('Please select Thc');
        return false;
    }
    var requestData = { thcId: selectedThcId };
    AjaxRequestWithPostAndJson(ThcUrl + '/GetThcDetailsForStockUpdate', JSON.stringify(requestData), OnStockUpdateDetailSuccess, ErrorFunction, false);
    AjaxRequestWithPostAndJson(ThcUrl + '/GetThcDocketListForStockUpdate', JSON.stringify(requestData), function (result) {
        dtDocketDetails.showHide(result.length > 0);
        dtDocketDetails.fnClearTable();
        if (result.length > 0) {
            $.each(result, function (i, item) {
                IsDaccUpdatedFlag = item.IsDaccUpdated;
                item.DocketId = item.DocketId;
                item.DocketNo = item.DocketNo + item.DocketSuffix;
                item.DocketDate = $.displayDate(item.DocketDate);

                if (deliveryProcess == "Y")
                {
                    item.DeliveryDate = $.displayDate(item.DeliveryDate) + "<input type='hidden' value='" + item.DeliveryDate + "' id='hdnDeliveryDate" + i + "'/><input type='hidden' value='" + item.PickupDeliveryTypeId + "' id='hdnPickupDeliveryTypeId" + i + "'/>";
                }
                else
                {
                    item.DeliveryDate = $.displayDate(item.DeliveryDate) + "<input type='hidden' value='" + item.DeliveryDate + "' id='hdnDeliveryDate" + i + "'/>";
                }
                item.ArrivalPackages = "<input type='hidden' value='" + item.DocketId + "' name='ManifestList[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                    "<input type='hidden' value='" + item.ToLocationId + "' name='ManifestList[" + i + "].ToLocationId' id='hdnToLocationId" + i + "'/>" +
                    "<input type='hidden' value='" + (item.ManifestDestinationId !== parseInt(loginLocationId) ? 'Y' : loginLocationCode !== item.ToLocationCode ? 'Y' : 'N') + "' id='hdnIsTranshipment" + i + "'/>" +
                    "<input type='hidden' value='" + item.DocketSuffix + "' name='ManifestList[" + i + "].DocketSuffix' id='hdnDocketSuffix" + i + "'/>" +
                     "<input type='hidden' value='" + item.IsDaccUpdated + "' name='ManifestList[" + i + "].IsDaccUpdated' id='hdnIsDaccUpdated" + i + "'/>" +
                    "<input type='hidden' value='" + item.ManifestId + "' name='ManifestList[" + i + "].ManifestId' id='hdnManifestId" + i + "'/>" +
                    "<input type='text' value='" + item.ArrivalPackages + "' name='ManifestList[" + i + "].ArrivalPackages' id='txtArrivalPackages" + i + "'class='textlabel' style='text-align: right'/>";
                item.ArrivalWeight = "<input type='text' value='" + item.ArrivalWeight.toFixed(3) + "' name='ManifestList[" + i + "].ArrivalWeight' id='txtArrivalWeight" + i + "'class='textlabel' style='text-align: right'/>";
                item.ArrivalCondition = "<div class='select'>" +
                    "<select class='form-control' name='ManifestList[" + i + "].ArrivalConditionId' id='ddlArrivalConditionId" + i + "' > " + "</select><i></i>" +
                    "</div>" +
                    '<span data-valmsg-for="ManifestList[' + i + '].ArrivalConditionId" data-valmsg-replace="true"></span>';
                item.LabourVendor = "<div class='select'>" +
                    "<select class='form-control' name='ManifestList[" + i + "].LabourVendorId' id='ddlLabourVendorId" + i + "' > " + "</select><i></i>" +
                    "</div>";
                item.Warehouse = "<div class='select'>" +
                    "<select class='form-control' name='ManifestList[" + i + "].WareHouseId' id='ddlWareHouseId" + i + "' > " + "</select><i></i>" +
                    "</div>" +
                    '<span data-valmsg-for="ManifestList[' + i + '].WareHouseId" data-valmsg-replace="true"></span>';
                item.DeliveryProcess = "<div class='select' id='dvDeliveryProcess'>" +
                    "<select class='form-control' name='ManifestList[" + i + "].DeliveryProcessId' id='ddlDeliveryProcessId" + i + "' > " + "</select><i></i>" +
                    "</div>" +
                    '<span data-valmsg-for="ManifestList[' + i + '].DeliveryProcessId" data-valmsg-replace="true"></span>' +
                    "<div id='dvDeliveryDetails" + i + "' style='display:none'>" +
                    "<input type='text' name='ManifestList[" + i + "].DeliveryDateTime' placeholder='Delivery Date Time' id='txtDeliveryDateTime" + i + "'class='form-control datepicker'/>" +
                    '<div><span data-valmsg-for="ManifestList[' + i + '].DeliveryDateTime" data-valmsg-replace="true"></span></div>' +
                    "<div id='dvLateDeliveryReason" + i + "' style='display:none'>" +
                    "<div class='select'>" +
                    "<select class='form-control' name='ManifestList[" + i + "].LateDeliveryReasonId' id='ddlLateDeliveryReasonId" + i + "' > " + "</select><i></i>" +
                    "</div>" +
                    "</div>" +
                    '<span data-valmsg-for="ManifestList[' + i + '].LateDeliveryReasonId" data-valmsg-replace="true"></span>' +
                    "<input type='text' name='ManifestList[" + i + "].PersonName' placeholder='Person' id='txtPersonName" + i + "'class='form-control'/>" +
                    '<div><span data-valmsg-for="ManifestList[' + i + '].PersonName" data-valmsg-replace="true"></span></div>' +
                    "<input type='text' name='ManifestList[" + i + "].Remarks' placeholder='Remarks' id='txtRemarks" + i + "'class='form-control'/>" +
                    '<div><span data-valmsg-for="ManifestList[' + i + '].Remarks" data-valmsg-replace="true"></span></div>' +
                    "</div>";
                item.DEPS = "<div class='form-group'><label class='checkbox'>" +
                        '<input type="checkbox" name="ManifestList[' + i + '].DepsDetails.IsDEPS" id="chkDEPS' + i + '" value="true"/><i></i>' +
                       '<input type="hidden" name="ManifestList[' + i + '].DepsDetails.IsDEPS" id="hdnDEPS' + i + '" />' +
                        '<label for = "chkDEPS' + i + '" class="label"></label>' +
                         "</label></div><br>";
            });
            dtDocketDetails.dtAddData(result, null, null, [[1, '80px'], [4, '70px']]);
            
            
            dtDocketDetails.fnSort([[0, 'asc'], [1, 'asc']]);
            dtDocketDetails.fnSetColumnVis(0, false, false)
            dtDocketDetails.fnSetColumnVis(1, false, false)
            var trList = dtDocketDetails.find('tbody tr');
            var trArr = [];
            for (var i = 0; i < trList.length; i++) {
                var checkboxTd1 = "<td colspan='3'><div class='clearfix' ><label class='checkbox' >" +
                                       '<input type="checkbox" name="ManifestList[' + i + '].DepsDetails.IsCheckedShort" id="chkShortPackages' + i + '" value="true"/><i></i>' +
                                        '<input type="hidden" name="ManifestList[' + i + '].DepsDetails.IsCheckedShort" id="hdnShortPackages' + i + '" />' +
                                          '<label for = "chkShortPackages' + i + '" class="control-label">Short Packages</label>' +
                                           "</label></div></td>";
                var checkboxTd2 = "<td colspan='3'><div class='clearfix' ><label class='checkbox' >" +
                                        '<input type="checkbox" name="ManifestList[' + i + '].DepsDetails.IsCheckedExtra" id="chkExtraPackages' + i + '" value="true"/><i></i>' +
                                         '<input type="hidden" name="ManifestList[' + i + '].DepsDetails.IsCheckedExtra" id="hdnExtraPackages' + i + '" />' +
                                           '<label for = "chkExtraPackages' + i + '" class="control-label">Extra Packages</label>' +
                                   "</label></div></td>";
                var checkboxTd3 = "<td colspan='3'><div class='clearfix' ><label class='checkbox' >" +
                                        '<input type="checkbox" name="ManifestList[' + i + '].DepsDetails.IsCheckedPilfer" id="chkPilferedPackages' + i + '" value="true"/><i></i>' +
                                         '<input type="hidden" name="ManifestList[' + i + '].DepsDetails.IsCheckedPilfer" id="hdnPilferedPackages' + i + '" />' +
                                           '<label for = "chkPilferedPackages' + i + '" class="control-label">Pilfered Packages</label>' +
                                            "</label></div></td>";

                var checkboxTd4 = "<td colspan='3'><div class='clearfix' ><label class='checkbox' >" +
                                         '<input type="checkbox" name="ManifestList[' + i + '].DepsDetails.IsCheckedDamage" id="chkDamagedPackages' + i + '" value="true"/><i></i>' +
                                          '<input type="hidden" name="ManifestList[' + i + '].DepsDetails.IsCheckedDamage" id="hdnDamagedPackages' + i + '" />' +
                                            '<label for = "chkDamagedPackages' + i + '" class="control-label">Damaged Packages</label>' +
                                    "</label></div></td>";
                var lableTd1 = ''; var lableTd2 = ''; var lableTd3 = ''; var lableTd4 = '';

                var packagesTd1 = '<td colspan="1"><input type="text" name="ManifestList[' + i + '].DepsDetails.ShortPackages"  id="txtShortPackages' + i + '" value="0" class="form-control numeric" disabled />' +
                                  '<div><span data-valmsg-for="ManifestList[' + i + '].DepsDetails.ShortPackages" data-valmsg-replace="true"></span></div></td>';
                var packagesTd2 = '<td colspan="1"><input type="text" name="ManifestList[' + i + '].DepsDetails.ExtraPackages"  id="txtExtraPackages' + i + '" value="0" class="form-control numeric" disabled />' +
                                  '<div><span data-valmsg-for="ManifestList[' + i + '].DepsDetails.ExtraPackages" data-valmsg-replace="true"></span></div></td>';
                var packagesTd3 = '<td colspan="1"><input type="text" name="ManifestList[' + i + '].DepsDetails.PilferPackages"  id="txtPilferedPackages' + i + '" value="0" class="form-control numeric" disabled />' +
                                  '<div><span data-valmsg-for="ManifestList[' + i + '].DepsDetails.PilferPackages" data-valmsg-replace="true"></span></div></td>';
                var packagesTd4 = '<td colspan="1"><input type="text" name="ManifestList[' + i + '].DepsDetails.DamagePackages"  id="txtDamagedPackages' + i + '" value="0" class="form-control numeric" disabled />' +
                                   '<div><span data-valmsg-for="ManifestList[' + i + '].DepsDetails.DamagePackages" data-valmsg-replace="true"></span></div></td>';

                var reasonTd1 = '<td colspan="3"><div class="select"><select class="form-control" name="ManifestList[' + i + '].DepsDetails.ShortPackagesReasonId" id="ddlShortPackagesReasonId' + i + '" class = "form-control" disabled > " + "</select><i></i></div>' +
                                '<div><span data-valmsg-for="ManifestList[' + i + '].DepsDetails.ShortPackagesReasonId" data-valmsg-replace="true"></span></div></td>';
                var reasonTd2 = '<td colspan="3"><div class="select"><select class="form-control" name="ManifestList[' + i + '].DepsDetails.ExtraPackagesReasonId" id="ddlExtraPackagesReasonId' + i + '" class = "form-control" disabled > " + "</select><i></i></div>' +
                                '<div><span data-valmsg-for="ManifestList[' + i + '].DepsDetails.ExtraPackagesReasonId" data-valmsg-replace="true"></span></div></td>';
                var reasonTd3 = '<td colspan="3"><div class="select"><select class="form-control" name="ManifestList[' + i + '].DepsDetails.PilferPackagesReasonId" id="ddlPilferedPackagesReasonId' + i + '" class = "form-control" disabled > " + "</select><i></i></div>' +
                                '<div><span data-valmsg-for="ManifestList[' + i + '].DepsDetails.PilferPackagesReasonId" data-valmsg-replace="true"></span></div></td>';
                var reasonTd4 = '<td colspan="3"><div class="select"><select class="form-control" name="ManifestList[' + i + '].DepsDetails.DamagePackagesReasonId" id="ddlDamagedPackagesReasonId' + i + '" class = "form-control" disabled > " + "</select><i></i></div>' +
                                '<div><span data-valmsg-for="ManifestList[' + i + '].DepsDetails.DamagePackagesReasonId" data-valmsg-replace="true"></span></div></td>';

                var remarkTd1 = '<td><input type="text" name="ManifestList[' + i + '].DepsDetails.ShortRemark"  id="txtShortRemark' + i + '" placeholder="Short Remark" class="form-control" disabled />' +
                                '<span data-valmsg-for="ManifestList[' + i + '].DepsDetails.ShortRemark" data-valmsg-replace="true"></span></td>';
                var remarkTd2 = '<td><input type="text" name="ManifestList[' + i + '].DepsDetails.ExtraRemark"  id="txtExtraRemark' + i + '" placeholder="Extra Remark" class="form-control" disabled />' +
                                '<span data-valmsg-for="ManifestList[' + i + '].DepsDetails.ExtraRemark" data-valmsg-replace="true"></span></td>';
                var remarkTd3 = '<td><input type="text" name="ManifestList[' + i + '].DepsDetails.PilferRemark"  id="txtPilfereRemark' + i + '" placeholder="Pilfer Remark" class="form-control" disabled />' +
                                '<span data-valmsg-for="ManifestList[' + i + '].DepsDetails.PilferRemark" data-valmsg-replace="true"></span></td>';
                var remarkTd4 = '<td><input type="text" name="ManifestList[' + i + '].DepsDetails.DamageRemark"  id="txtDamageRemark' + i + '" placeholder="Damage Remark" class="form-control" disabled />' +
                                '<span data-valmsg-for="ManifestList[' + i + '].DepsDetails.DamageRemark" data-valmsg-replace="true"></span></td>';
                var imageTd1 = '<td colspan="3"><div class="form-group"><div class="input prepend-big-btn"><label class="icon-right" for="prepend-big-btn"><i class="fa fa-download"></i></label>' +
                                '<div class="file-button">Browse' +
                                '<input type="file" name="ManifestList[' + i + '].DepsDetails.ShortDocumentAttachment"  id="ShortPackagesReasonDocumentAttachment' + i + '" class="form-control"/>' +
                                  '</div>' +
                                            '<input class="form-control" type="text" id="prepend-big-btn" readonly="" placeholder="no file selected">' +
                                        '</div>' +
                                    '</div>';
                //var imageTd1 = '<td colspan="3"><input type="file" id="ShortPackagesReasonDocumentAttachment' + i + '" name="ManifestList[' + i + '].DepsDetails.ShortDocumentAttachment" disabled />' +
                //                '<div><span data-valmsg-for="ManifestList[' + i + '].DepsDetails.ShortDocumentAttachment" data-valmsg-replace="true"></span></div></td>';
                var imageTd2 = '<td colspan="3"><div class="form-group"><div class="input prepend-big-btn"><label class="icon-right" for="prepend-big-btn"><i class="fa fa-download"></i></label>' +
                                '<div class="file-button">Browse' +
                                '<input type="file" name="ManifestList[' + i + '].DepsDetails.ExtraDocumentAttachment"  id="ExtraPackagesDocumentAttachment' + i + '" class="form-control"/>' +
                                  '</div>' +
                                            '<input class="form-control" type="text" id="prepend-big-btn" readonly="" placeholder="no file selected">' +
                                        '</div>' +
                                    '</div>';
                //var imageTd2 = '<td colspan="3"><input type="file" id="ExtraPackagesDocumentAttachment' + i + '" name="ManifestList[' + i + '].DepsDetails.ExtraDocumentAttachment" disabled /></td>';
                var imageTd3 = '<td colspan="3"><div class="form-group"><div class="input prepend-big-btn"><label class="icon-right" for="prepend-big-btn"><i class="fa fa-download"></i></label>' +
                                '<div class="file-button">Browse' +
                                '<input type="file" name="ManifestList[' + i + '].DepsDetails.PilferDocumentAttachment"  id="PilferedPackagesReasonDocumentAttachment' + i + '" class="form-control"/>' +
                                  '</div>' +
                                            '<input class="form-control" type="text" id="prepend-big-btn" readonly="" placeholder="no file selected">' +
                                        '</div>' +
                                    '</div>';
                //var imageTd3 = '<td colspan="3"><input type="file" id="PilferedPackagesReasonDocumentAttachment' + i + '" name="ManifestList[' + i + '].DepsDetails.PilferDocumentAttachment" disabled /></td>';
                var imageTd4 = '<td colspan="3"><div class="form-group"><div class="input prepend-big-btn"><label class="icon-right" for="prepend-big-btn"><i class="fa fa-download"></i></label>' +
                                '<div class="file-button">Browse' +
                                '<input type="file" name="ManifestList[' + i + '].DepsDetails.DamageDocumentAttachment"  id="DamagedPackagesReasonDocumentAttachment' + i + '" class="form-control"/>' +
                                  '</div>' +
                                            '<input class="form-control" type="text" id="prepend-big-btn" readonly="" placeholder="no file selected">' +
                                        '</div>' +
                                    '</div>';
                //var imageTd4 = '<td colspan="3"><input type="file" id="DamagedPackagesReasonDocumentAttachment' + i + '" name="ManifestList[' + i + '].DepsDetails.DamageDocumentAttachment" disabled /></td>';

                var trNew1 = $('<tr>' + checkboxTd1 + lableTd1 + packagesTd1 + reasonTd1 + remarkTd1 + imageTd1 + '</tr>');
                var trNew2 = $('<tr>' + checkboxTd2 + lableTd2 + packagesTd2 + reasonTd2 + remarkTd2 + imageTd2 + '</tr>');
                var trNew3 = $('<tr>' + checkboxTd3 + lableTd3 + packagesTd3 + reasonTd3 + remarkTd3 + imageTd3 + '</tr>');
                var trNew4 = $('<tr>' + checkboxTd4 + lableTd4 + packagesTd4 + reasonTd4 + remarkTd4 + imageTd4 + '</tr>');

                trArr.push(trList[i]);
                trArr.push(trNew1[0]);
                trArr.push(trNew2[0]);
                trArr.push(trNew3[0]);
                trArr.push(trNew4[0]);
            }
        }

        dtDocketDetails.find('tbody tr').remove();
        $.each(trArr, function (i, item) {
            dtDocketDetails.append(item);
            
        });

        var ddlHeaderArrivalConditionId = dtDocketDetails.find('[id*="ddlHeaderArrivalConditionId"]');
        var ddlHeaderWareHouseId = dtDocketDetails.find('[id*="ddlHeaderWareHouseId"]');
        var ddlHeaderLabourVendorId = dtDocketDetails.find('[id*="ddlHeaderLabourVendorId"]');
        var ddlHeaderDeliveryProcessId = dtDocketDetails.find('[id*="ddlHeaderDeliveryProcessId"]');
        var txtHeaderDeliveryDateTime = dtDocketDetails.find('[id*="txtHeaderDeliveryDateTime"]');
        var txtHeaderPersonName = dtDocketDetails.find('[id*="txtHeaderPersonName"]');
        var txtHeaderRemarks = dtDocketDetails.find('[id*="txtHeaderRemarks"]');
        InitDateTimePicker(txtHeaderDeliveryDateTime.Id, false, true, false, currentDate, dateTimeFormat, '', '');

        BindDropDownList(ddlHeaderArrivalConditionId.Id, arrivalConditionList, 'Value', 'Name', '', 'Select Arrival Condition');
        BindDropDownList(ddlHeaderWareHouseId.Id, warehouseList, 'Value', 'Name', '', 'Select Warehouse');
        BindDropDownList(ddlHeaderLabourVendorId.Id, labourVendorList, 'Value', 'Name', '', 'Select Vendor');
        BindDropDownList(ddlHeaderDeliveryProcessId.Id, deliveryProcessList, 'Value', 'Name', '', 'Select Delivery Process');

        ddlHeaderArrivalConditionId.change(function () {
            $('[id*="ddlArrivalConditionId"]').val(ddlHeaderArrivalConditionId.val());
        });
        ddlHeaderWareHouseId.change(function () {
            $('[id*="ddlWareHouseId"]').val(ddlHeaderWareHouseId.val());
        });

        ddlHeaderLabourVendorId.change(function () {
            $('[id*="ddlLabourVendorId"]').val(ddlHeaderLabourVendorId.val());
            if (parseInt(ddlHeaderLabourVendorId.val()) > 0) {
                var request = { VendorId: ddlHeaderLabourVendorId.val() };
                AjaxRequestWithPostAndJson(vendorMasterUrl + '/GetWarehouseListByVendorId', JSON.stringify(request), function (result) {
                    if (IsObjectNullOrEmpty(result)) {
                        ddlHeaderWareHouseId.empty();
                        $('[id*="ddlWareHouseId"]').empty();
}
                    else {
                        BindDropDownList(ddlHeaderWareHouseId.Id, result, 'Value', 'Name', '', 'Select Warehouse');
                        $("[id*='ddlWareHouseId']").each(function () {
                            var ddlWareHouseId = $(this);
                            BindDropDownList(ddlWareHouseId.Id, result, 'Value', 'Name', '', 'Select Warehouse');
                        });
                    }
                }, ErrorFunction, false);
            }
        });

        ddlHeaderDeliveryProcessId.change(function () {
            $('[id*="ddlDeliveryProcessId"]').val(ddlHeaderDeliveryProcessId.val());
            $("[id*='dvDeliveryDetails']").each(function () {
                var tr = $(this).closest('tr');
                var dvDeliveryDetails = tr.find('[id*="dvDeliveryDetails"]');
                var hdnIsTranshipment = tr.find('[id*="hdnIsTranshipment"]');
                var isTranshipmentDocket = hdnIsTranshipment.val() == 'Y';
                var txtDeliveryDateTime = tr.find('[id*="txtDeliveryDateTime"]');
                var txtPersonName = tr.find('[id*="txtPersonName"]');
                var txtRemarks = tr.find('[id*="txtRemarks"]');
                var ddlDeliveryProcessId = tr.find('[id*="ddlDeliveryProcessId"]');
                var hdnIsDaccUpdated = tr.find('[id*="hdnIsDaccUpdated"]');

                if (ddlHeaderDeliveryProcessId.val() == 2 && hdnIsDaccUpdated.val() == 'false') {
                    ShowMessage('DACC Update is pending for this Docket');
                    //ddlHeaderDeliveryProcessId.val('');
                    ddlDeliveryProcessId.val('');
                    //return false;
                }
                else {
                    dvDeliveryDetails.showHide(!isTranshipmentDocket && (ddlHeaderDeliveryProcessId.val() == 2 || ddlHeaderDeliveryProcessId.val() == 4));
                    if (!isTranshipmentDocket && (ddlHeaderDeliveryProcessId.val() == 2 || ddlHeaderDeliveryProcessId.val() == 4)) {
                        DeliveryDateTimeChange(txtDeliveryDateTime);
                        AddRequired(txtDeliveryDateTime, 'Please select Delivery Date & Time');
                        AddRequired(txtPersonName, 'Enter Person Name');
                        AddRequired(txtRemarks, 'Enter Remarks');
                    }
                    else {
                        RemoveRequired(txtDeliveryDateTime);
                        RemoveRequired(txtPersonName);
                        RemoveRequired(txtRemarks);
                        txtDeliveryDateTime.val('');
                        txtPersonName.val('');
                        txtRemarks.val('');
                        txtHeaderDeliveryDateTime.val('');
                        txtHeaderPersonName.val('');
                        txtHeaderRemarks.val('');
                    }
                }

            });
            $('#dvDeliveryDetail').showHide(ddlHeaderDeliveryProcessId.val() == 2);
        });

        txtHeaderDeliveryDateTime.blur(function () {
            $("[id*='dvDeliveryDetails']").each(function () {
                var tr = $(this).closest('tr');
                var dvDeliveryDetails = tr.find('[id*="dvDeliveryDetails"]');
                var hdnIsTranshipment = tr.find('[id*="hdnIsTranshipment"]');
                var isTranshipmentDocket = hdnIsTranshipment.val() == 'Y';
                var txtDeliveryDateTime = tr.find('[id*="txtDeliveryDateTime"]');
                dvDeliveryDetails.showHide(!isTranshipmentDocket && (ddlHeaderDeliveryProcessId.val() == 2 || ddlHeaderDeliveryProcessId.val() == 4));
                if (!isTranshipmentDocket && (ddlHeaderDeliveryProcessId.val() == 2 || ddlHeaderDeliveryProcessId.val() == 4)) {
                    DeliveryDateTimeChange(txtDeliveryDateTime);
                    txtDeliveryDateTime.val(txtHeaderDeliveryDateTime.val());
                }
            });

        });
        txtHeaderPersonName.blur(function () {
            $("[id*='dvDeliveryDetails']").each(function () {
                var tr = $(this).closest('tr');
                var dvDeliveryDetails = tr.find('[id*="dvDeliveryDetails"]');
                var hdnIsTranshipment = tr.find('[id*="hdnIsTranshipment"]');
                var isTranshipmentDocket = hdnIsTranshipment.val() == 'Y';
                var txtPersonName = tr.find('[id*="txtPersonName"]');
                dvDeliveryDetails.showHide(!isTranshipmentDocket && (ddlHeaderDeliveryProcessId.val() == 2 || ddlHeaderDeliveryProcessId.val() == 4));
                if (!isTranshipmentDocket && (ddlHeaderDeliveryProcessId.val() == 2 || ddlHeaderDeliveryProcessId.val() == 4)) {
                    txtPersonName.val(txtHeaderPersonName.val());
                }
            });
        });

        txtHeaderRemarks.blur(function () {
            $("[id*='dvDeliveryDetails']").each(function () {
                var tr = $(this).closest('tr');
                var dvDeliveryDetails = tr.find('[id*="dvDeliveryDetails"]');
                var hdnIsTranshipment = tr.find('[id*="hdnIsTranshipment"]');
                var isTranshipmentDocket = hdnIsTranshipment.val() == 'Y';
                var txtRemarks = tr.find('[id*="txtRemarks"]');
                dvDeliveryDetails.showHide(!isTranshipmentDocket && (ddlHeaderDeliveryProcessId.val() == 2 || ddlHeaderDeliveryProcessId.val() == 4));
                if (!isTranshipmentDocket && (ddlHeaderDeliveryProcessId.val() == 2 || ddlHeaderDeliveryProcessId.val() == 4)) {
                    txtRemarks.val(txtHeaderRemarks.val());
                }
            });
        });

        $("[id*='ddlArrivalConditionId']").each(function () {
            var tr = $(this).closest('tr');
            var dvDeliveryProcess = tr.find('[id*="dvDeliveryProcess"]');
            var hdnIsTranshipment = tr.find('[id*="hdnIsTranshipment"]');
            var txtDeliveryDateTime = tr.find('[id*="txtDeliveryDateTime"]');
            var isTranshipmentDocket = hdnIsTranshipment.val() == 'Y';
            dvDeliveryProcess.showHide(!isTranshipmentDocket);
            txtDeliveryDateTime.blur(function () { DeliveryDateTimeChange(txtDeliveryDateTime); });
            var ddlArrivalConditionId = tr.find('[id*="ddlArrivalConditionId"]');
            var ddlWareHouseId = tr.find('[id*="ddlWareHouseId"]');
            var ddlLabourVendorId = tr.find('[id*="ddlLabourVendorId"]');
            var ddlDeliveryProcessId = tr.find('[id*="ddlDeliveryProcessId"]');
            var ddlLateDeliveryReasonId = tr.find('[id*="ddlLateDeliveryReasonId"]');
            var txtPersonName = tr.find('[id*="txtPersonName"]');
            var txtRemarks = tr.find('[id*="txtRemarks"]');
            var chkDEPS = tr.find('[id*="chkDEPS"]');
            var txtArrivalPackages = tr.find('[id*="txtArrivalPackages"]');

            var dvDeliveryDetails = tr.find('[id*="dvDeliveryDetails"]');
            var hdnIsDaccUpdated = tr.find('[id*="hdnIsDaccUpdated"]');
            var trNext1 = tr.next('tr');
            var trNext2 = trNext1.next('tr');
            var trNext3 = trNext2.next('tr');
            var trNext4 = trNext3.next('tr');

            ddlLabourVendorId.change(function () {
                if (parseInt(ddlLabourVendorId.val()) > 0) {
                    var request = { VendorId: ddlLabourVendorId.val() };
                    AjaxRequestWithPostAndJson(vendorMasterUrl + '/GetWarehouseListByVendorId', JSON.stringify(request), function (result) {
                        if (IsObjectNullOrEmpty(result)) {
                            ddlLabourVendorId.empty();
                        }
                        else {
                            BindDropDownList(ddlLabourVendorId.Id, result, 'Value', 'Name', '', 'Select Warehouse');
                        }
                    }, ErrorFunction, false);
                }
            });

            chkDEPS.change(function () {
                trNext1.showHide($(this).IsChecked);
                trNext2.showHide($(this).IsChecked);
                trNext3.showHide($(this).IsChecked);
                trNext4.showHide($(this).IsChecked);
                if ($(this).IsChecked)
                    SetFieldFocus(trNext1);
            }).change();

            var ddlDamagedPackagesReasonId = trNext4.find('[id*="ddlDamagedPackagesReasonId"]');
            var ddlPilferedPackagesReasonId = trNext3.find('[id*="ddlPilferedPackagesReasonId"]');
            var ddlShortPackagesReasonId = trNext1.find('[id*="ddlShortPackagesReasonId"]');
            var ddlExtraPackagesReasonId = trNext2.find('[id*="ddlExtraPackagesReasonId"]');
            var chkDamagedPackages = trNext4.find('[id*="chkDamagedPackages"]');
            var chkPilferedPackages = trNext3.find('[id*="chkPilferedPackages"]');
            var chkShortPackages = trNext1.find('[id*="chkShortPackages"]');
            var chkExtraPackages = trNext2.find('[id*="chkExtraPackages"]');
            var txtDamagedPackages = trNext4.find('[id*="txtDamagedPackages"]');
            var txtPilferedPackages = trNext3.find('[id*="txtPilferedPackages"]');
            var txtShortPackages = trNext1.find('[id*="txtShortPackages"]');
            var txtExtraPackages = trNext2.find('[id*="txtExtraPackages"]');
            var txtDamageRemark = trNext4.find('[id*="txtDamageRemark"]');
            var txtPilfereRemark = trNext3.find('[id*="txtPilfereRemark"]');
            var txtShortRemark = trNext1.find('[id*="txtShortRemark"]');
            var txtExtraRemark = trNext2.find('[id*="txtExtraRemark"]');
            var DamagedPackagesReasonDocumentAttachment = trNext4.find('[id*="DamagedPackagesReasonDocumentAttachment"]');
            var PilferedPackagesReasonDocumentAttachment = trNext3.find('[id*="PilferedPackagesReasonDocumentAttachment"]');
            var ShortPackagesReasonDocumentAttachment = trNext1.find('[id*="ShortPackagesReasonDocumentAttachment"]');
            var ExtraPackagesDocumentAttachment = trNext2.find('[id*="ExtraPackagesDocumentAttachment"]');

            BindDropDownList(ddlArrivalConditionId.Id, arrivalConditionList, 'Value', 'Name', '', 'Select Arrival Condition');
            BindDropDownList(ddlWareHouseId.Id, warehouseList, 'Value', 'Name', '', 'Select Warehouse');
            BindDropDownList(ddlLabourVendorId.Id, labourVendorList, 'Value', 'Name', '', 'Select Vendor');
            InitDateTimePicker(txtDeliveryDateTime.Id, false, true, false, currentDate, dateTimeFormat, '', '');
            BindDropDownList(ddlLateDeliveryReasonId.Id, lateDeliveryReasonList, 'Value', 'Name', '', 'Select Late Delivery Reason');
            BindDropDownList(ddlDamagedPackagesReasonId.Id, damageReasonList, 'Value', 'Name', '', 'Select Package Condition');
            BindDropDownList(ddlPilferedPackagesReasonId.Id, pilferReasonList, 'Value', 'Name', '', 'Select Package Condition');
            BindDropDownList(ddlShortPackagesReasonId.Id, shortReasonList, 'Value', 'Name', '', 'Select Package Condition');
            BindDropDownList(ddlExtraPackagesReasonId.Id, extraReasonList, 'Value', 'Name', '', 'Select Package Condition');

            chkDamagedPackages.click(function () { OnDepsPackagesChange(chkDamagedPackages, ddlDamagedPackagesReasonId, txtDamagedPackages, txtDamageRemark, DamagedPackagesReasonDocumentAttachment); });
            chkPilferedPackages.click(function () { OnDepsPackagesChange(chkPilferedPackages, ddlPilferedPackagesReasonId, txtPilferedPackages, txtPilfereRemark, PilferedPackagesReasonDocumentAttachment); });
            chkShortPackages.click(function () {
                if (chkExtraPackages.IsChecked) {
                    ShowMessage('Please Uncheck Extra Package');
                    return false;
                }
                else {
                    OnDepsPackagesChange(chkShortPackages, ddlShortPackagesReasonId, txtShortPackages, txtShortRemark, ShortPackagesReasonDocumentAttachment);
                }
            });

            chkExtraPackages.click(function () {
                if (chkShortPackages.IsChecked) {
                    ShowMessage('Please Uncheck Short Package');
                    return false;
                }

                else {
                    OnDepsPackagesChange(chkExtraPackages, ddlExtraPackagesReasonId, txtExtraPackages, txtExtraRemark, ExtraPackagesDocumentAttachment);
                }
            });

            txtDamagedPackages.blur(function () {
                if (chkShortPackages.IsChecked) {
                    var packages = parseInt(txtArrivalPackages.val()) - parseInt(txtShortPackages.val())
                    if (parseInt(txtDamagedPackages.val()) > packages) {
                        ShowMessage('Please enter Damage Packages less than or equal to ' + packages);
                        txtDamagedPackages.val(0);
                        return false;
                    }
                    if (parseInt(txtDamagedPackages.val()) > (packages - parseInt(txtPilferedPackages.val())))
                        txtDamagedPackages.val(0);
                }
                else if (chkExtraPackages.IsChecked) {
                    var packages = parseInt(txtArrivalPackages.val()) + parseInt(txtExtraPackages.val())
                    if (parseInt(txtDamagedPackages.val()) > packages) {
                        ShowMessage('Please enter Damage Packages less than or equal to ' + packages);
                        txtDamagedPackages.val(0);
                        return false;
                    }
                    if (parseInt(txtDamagedPackages.val()) > (packages - parseInt(txtPilferedPackages.val())))
                        txtDamagedPackages.val(0);
                }
                else {
                    if (parseInt(txtDamagedPackages.val()) > parseInt(txtArrivalPackages.val())) {
                        ShowMessage('Please enter Damage Packages less than or equal to Arrival Packages');
                        txtDamagedPackages.val(0);
                        return false;
                    }
                }
            });

            txtPilferedPackages.blur(function () {
                if (chkShortPackages.IsChecked) {
                    var packages = parseInt(txtArrivalPackages.val()) - parseInt(txtShortPackages.val())
                    if (parseInt(txtPilferedPackages.val()) > packages) {
                        ShowMessage('Please enter Pilfered Packages less than or equal to ' + packages);
                        txtPilferedPackages.val(0);
                        return false;
                    }
                    if (parseInt(txtPilferedPackages.val()) > (packages - parseInt(txtDamagedPackages.val())))
                        txtPilferedPackages.val(0);
                }
                else if (chkExtraPackages.IsChecked) {
                    var packages = parseInt(txtArrivalPackages.val()) + parseInt(txtExtraPackages.val())
                    if (parseInt(txtPilferedPackages.val()) > packages) {
                        ShowMessage('Please enter Pilfered Packages less than or equal to ' + packages);
                        txtPilferedPackages.val(0);
                        return false;
                    }
                    if (parseInt(txtPilferedPackages.val()) > (packages - parseInt(txtDamagedPackages.val())))
                        txtPilferedPackages.val(0);
                }
                else if (parseInt(txtPilferedPackages.val()) > parseInt(txtArrivalPackages.val())) {
                    ShowMessage('Please enter Pilfered Packages less than or equal to Arrival Packages');
                    txtPilferedPackages.val(0);
                    return false;
                }
            });

            txtExtraPackages.blur(function () {
                if (parseInt(txtDamagedPackages.val()) > (parseInt(txtArrivalPackages.val()) + parseInt(txtExtraPackages.val())))
                    txtDamagedPackages.val(0);
                if (parseInt(txtPilferedPackages.val()) > (parseInt(txtArrivalPackages.val()) + parseInt(txtExtraPackages.val())))
                    txtPilferedPackages.val(0);
                if ((parseInt(txtDamagedPackages.val()) + parseInt(txtPilferedPackages.val())) > (parseInt(txtArrivalPackages.val()) + parseInt(txtExtraPackages.val()))) {
                    txtPilferedPackages.val(0);
                    txtDamagedPackages.val(0);
                }
            });

            txtShortPackages.blur(function () {
                if (parseInt(txtShortPackages.val()) > parseInt(txtArrivalPackages.val())) {
                    ShowMessage('Please enter Short Packages less than Arrival Packages');
                    txtShortPackages.val(0);
                    return false;
                }
                if (parseInt(txtDamagedPackages.val()) > (parseInt(txtArrivalPackages.val()) - parseInt(txtShortPackages.val()))) {
                    txtDamagedPackages.val(0);
                }
                if (parseInt(txtPilferedPackages.val()) > (parseInt(txtArrivalPackages.val()) - parseInt(txtShortPackages.val()))) {
                    txtPilferedPackages.val(0);
                }
                if ((parseInt(txtDamagedPackages.val()) + parseInt(txtPilferedPackages.val())) > (parseInt(txtArrivalPackages.val()) - parseInt(txtShortPackages.val()))) {
                    txtPilferedPackages.val(0);
                    txtDamagedPackages.val(0);
                }
            });

            ddlDeliveryProcessId.change(function () {

                if (ddlDeliveryProcessId.val() == 2 && hdnIsDaccUpdated.val() == "false") {
                    ShowMessage('DACC Update is pending for this Docket');
                    ddlDeliveryProcessId.val('');
                    //return false;
                }
                else {
                    dvDeliveryDetails.showHide(ddlDeliveryProcessId.val() == 2 || ddlDeliveryProcessId.val() == 4 || ddlHeaderDeliveryProcessId.val() == 4);
                    if (ddlDeliveryProcessId.val() == 2 || ddlDeliveryProcessId.val() == 4 || ddlHeaderDeliveryProcessId.val() == 4) {
                        DeliveryDateTimeChange(txtDeliveryDateTime);
                        AddRequired(txtDeliveryDateTime, 'Please select Delivery Date & Time');
                        AddRequired(txtPersonName, 'Enter Person Name');
                        AddRequired(txtRemarks, 'Enter Remarks');
                    }
                    else {
                        RemoveRequired(txtDeliveryDateTime);
                        RemoveRequired(txtPersonName);
                        RemoveRequired(txtRemarks);
                    }
                }
            });

            if (!isTranshipmentDocket)
                BindDropDownList(ddlDeliveryProcessId.Id, deliveryProcessList, 'Value', 'Name', '', 'Select Delivery Process');

            ddlDeliveryProcessId.enable(!isTranshipmentDocket);

            AddRequired(ddlArrivalConditionId, 'Please select Arrival Condition');
            AddRequired(ddlWareHouseId, 'Please select Warehouse');
            AddRequired(ddlDeliveryProcessId, 'Please select Delivery Process');

            var $span = $('#spnDocketDetails');

            $span.find('th').wrapInner('<td />').contents().unwrap();
            // $span.find('tbody').contents().unwrap();
            
        });

        if (deliveryProcess == "Y")
        {
            $("[id*='ddlArrivalConditionId']").each(function () {
                var tr = $(this).closest('tr');
                var hdnPickupDeliveryTypeId = tr.find('[id*="hdnPickupDeliveryTypeId"]');
                var ddlDeliveryProcessId = tr.find('[id*="ddlDeliveryProcessId"]');

                if (hdnPickupDeliveryTypeId.val() == "1" || hdnPickupDeliveryTypeId.val() == "3")
                {
                    ddlDeliveryProcessId.val(3);
                }
                if (hdnPickupDeliveryTypeId.val() == "2" || hdnPickupDeliveryTypeId.val() == "4") {
                    ddlDeliveryProcessId.val(1);
                }
            });
        }


    }, ErrorFunction, false);

    $('#dtDocketDetails td:nth-child(11),th:nth-child(11)').hide();
}

function OnDepsPackagesChange(objCheck, objddlReasonId, objtxtPakage, objtxtRemark, objDocumentAttachment) {
    objddlReasonId.val('');
    objtxtPakage.val(0);
    objtxtRemark.val('');
    objDocumentAttachment.val('');
    if (objCheck.IsChecked) {
        AddRequired(objddlReasonId, "Please select Reason");
        AddRequired(objtxtRemark, "Please enter Remark");
        AddRange(objtxtPakage, "Please enter packages geater than 0", 1);
        //AddRequired(objDocumentAttachment, "Please select File");
    }
    else {
        RemoveRequired(objddlReasonId);
        RemoveRequired(objtxtRemark);
        RemoveRequired(objtxtPakage);
        //RemoveRequired(objDocumentAttachment);
    }
    objddlReasonId.enable(objCheck.IsChecked);
    objtxtPakage.enable(objCheck.IsChecked);
    objtxtRemark.enable(objCheck.IsChecked);
    objDocumentAttachment.enable(objCheck.IsChecked);
}

function DeliveryDateTimeChange(obj) {
    txtDeliveryDateTime = obj;
    var ddlLateDeliveryReasonId = $('#' + txtDeliveryDateTime.Id.replace('txtDeliveryDateTime', 'ddlLateDeliveryReasonId'));
    var hdnDeliveryDate = $('#' + txtDeliveryDateTime.Id.replace('txtDeliveryDateTime', 'hdnDeliveryDate'));
    var dvLateDeliveryReason = $('#' + txtDeliveryDateTime.Id.replace('txtDeliveryDateTime', 'dvLateDeliveryReason'));

    var isLateDelivery = false;
    if (txtDeliveryDateTime.val() != '') {
        isLateDelivery = moment(hdnDeliveryDate.val()) < moment(txtDeliveryDateTime.val(), 'DD/MM/YYYY');
    }

    dvLateDeliveryReason.showHide(isLateDelivery);

    if (isLateDelivery)
        AddRequired(ddlLateDeliveryReasonId, 'Please select Late Delivery Reason');
    else
        RemoveRequired(ddlLateDeliveryReasonId);

    ddlLateDeliveryReasonId.enable(isLateDelivery);
    ddlLateDeliveryReasonId.val('');

}
function OnStockUpdateDetailSuccess(responseData) {
    $('#lblThcNo').text(responseData.ThcNo);
    $('#hdnThcId').val(responseData.ThcId);
    $('#hdnThcNo').val(responseData.ThcNo);
    $('#lblThcDate').text($.displayDate(responseData.ThcDate));
    if (responseData.ActualArrivalDate == null)
        $('#lblActualArrivalDate').text('');
    else
        $('#lblActualArrivalDate').text($.displayDate(responseData.ActualArrivalDate));

    $('#lblToLocationCode').text(responseData.ToLocationCode);
    $('#lblVehicleNo').text(responseData.VehicleNo);
    $('#lblTotalDocket').text(responseData.TotalDocket);
    $('#lblTotalManifest').text(responseData.TotalManifest);
}

function ValidateOnSubmit() {
    if (!ValidateModuleDateWithPreviousDocumentDate('dtThcDetails', 'chkThcNo', 'hdnActualArrivalDate', 'txtStockUpdateDate', 'Stock Update Date')) return false;
}
