var hdnJobOrderId, hdnVehicleId, txtVehicleNo, ddlJobCardType, ddlServiceCenterType, ddlServiceCenterId, txtCurrentKmReading, txtLabourCostPerHour, txtTotalEstimatedLabourHours, txtTotalEstimatedLabourCost, txtTotalEstimatedCost;
var dvServiceCenter, lblServiceCenter, locationList, vendorList, taskMasterUrl, vehicleMasterUrl, validateVehicleNoFromMaster;
var baseUrl;

$(document).ready(function () {
    if ($('#hdnJobOrderId').val() > 0)
        SetPageLoad('Job Order', 'Update', 'txtVehicleNo', '', '');
    else
        SetPageLoad('Prepare Job Order', '', 'txtVehicleNo', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    hdnJobOrderId = $('#hdnJobOrderId');
    hdnVehicleId = $('#hdnVehicleId');
    txtVehicleNo = $('#txtVehicleNo');
    ddlJobCardType = $('#ddlJobCardType');
    ddlServiceCenterType = $('#ddlServiceCenterType');
    ddlServiceCenterId = $('#ddlServiceCenterId');
    txtCurrentKmReading = $('#txtCurrentKmReading');
    txtLabourCostPerHour = $('#txtLabourCostPerHour');
    txtTotalEstimatedLabourHours = $('#txtTotalEstimatedLabourHours');
    txtTotalEstimatedLabourCost = $('#txtTotalEstimatedLabourCost');
    txtTotalEstimatedCost = $('#txtTotalEstimatedCost');
    dvServiceCenter = $('#dvServiceCenter');
    lblServiceCenter = $('#lblServiceCenter');

    InitGrid('dtTaskDetail', false, 6, InitTaskDetail);
    InitGrid('dtSparePartDetail', false, 6, InitSparePartDetail);

    InitWizard('dvWizard', [
     { StepName: 'Prepare Job Order' },
     { StepName: 'Task Details', StepFunction: CalculateTotalRequestedQuantityAndCost },
     { StepName: 'Spare Part Details' },
    ], hdnJobOrderId.val() > 0 ? 'Update Job Order' : 'Prepare Job Order');
}

function AttachEvents() {
    VehicleAutoCompleteListForJobOrder('txtVehicleNo', 'hdnVehicleId');
    txtVehicleNo.blur(function () {
        if (hdnJobOrderId.val() == 0) {
            //var vehicleNo = GetValidVehicleNoFormat(txtVehicleNo.val());
            //txtVehicleNo.val(vehicleNo);
            var vehicleNo = txtVehicleNo.val();
            if (hdnVehicleId.val() > 1) {
                CheckValidVehicleNoForJobOrder(txtVehicleNo, hdnVehicleId);
            }
            else if (vehicleNo != '') {
                var requestData = { vehicleNo: vehicleNo };
                AjaxRequestWithPostAndJson(baseUrl + '/CheckValidVehicleNoForJobOrder', JSON.stringify(requestData), function (result) {
                    if (result.Value > 0) {
                        txtVehicleNo.val(result.Name);
                        hdnVehicleId.val(result.Value);
                    }
                    else {
                        ShowMessage(result.Description);
                        txtVehicleNo.val('');
                        hdnVehicleId.val(0);
                        txtCurrentKmReading.val(0);
                        txtVehicleNo.focus();
                    }
                }, ErrorFunction, false);
            }
        }
    });

    ddlServiceCenterType.change(OnServiceCenterTypeChange);
    OnServiceCenterTypeChange();
    txtLabourCostPerHour.blur(OnLabourCostChange);
    txtCurrentKmReading.readOnly(hdnJobOrderId.val() > 0);
    $('#dvDisplayJobOrderNo').showHide(hdnJobOrderId.val() > 0);
    $('#dvJobOrderNo').showHide(hdnJobOrderId.val() == 0);
    $('#dvDisplayVehicleNo').showHide(hdnJobOrderId.val() > 0);
    $('#dvVehicleNo').showHide(hdnJobOrderId.val() == 0);
    $('#dvDisplayJobOrderDate').showHide(hdnJobOrderId.val() > 0);
    $('#dvJobOrderDate').showHide(hdnJobOrderId.val() == 0);
    $('#dvDisplayJobCardType').showHide(hdnJobOrderId.val() > 0);
    $('#dvJobCardType').showHide(hdnJobOrderId.val() == 0);
    $('#dvDisplayServiceCenterType').showHide(hdnJobOrderId.val() > 0);
    $('#dvServiceCenterType').showHide(hdnJobOrderId.val() == 0);
    $('#dvDisplayServiceCenter').showHide(hdnJobOrderId.val() > 0);
    $('#dvDisplaySendDate').showHide(hdnJobOrderId.val() > 0);
    $('#dvSendDate').showHide(hdnJobOrderId.val() == 0);
    $('#dvDisplayEstimatedReturnDate').showHide(hdnJobOrderId.val() > 0);
    $('#dvEstimatedReturnDate').showHide(hdnJobOrderId.val() == 0);
    $('[id*="txtRequestedQuantity"]').blur();
    if (ddlServiceCenterType.val() == 1) {
        $('#lblServiceCenterType').text("Workshop");
        BindDropDownList('ddlServiceCenterId', locationList, 'Value', 'Text', '', 'Select');
    }
    else if (ddlServiceCenterType.val() == 2) {
        $('#lblServiceCenterType').text("Vendor");
        BindDropDownList('ddlServiceCenterId', vendorList, 'Value', 'Text', '', 'Select');
    }
    if (hdnJobOrderId.val() > 0)
        ddlServiceCenterId.val($('#hdnJobServiceCenterId').val());
}

function CheckValidVehicleNoForJobOrder(objVehicleNo, objHdnVehicleId) {
    if (objVehicleNo.val() != "" && hdnJobOrderId.val() == 0) {
        var requestData = { vehicleNo: objVehicleNo.val(), locationId: loginLocationId };
        AjaxRequestWithPostAndJson(vehicleMasterUrl + '/CheckValidVehicleNoForJobOrder', JSON.stringify(requestData), function (result) {
            if (result.Value > 0) {
                objVehicleNo.val(result.Name);
                objHdnVehicleId.val(result.Value);
            }
            else {
                ShowMessage(result.Description);
                objVehicleNo.val('');
                objHdnVehicleId.val(0);
                txtCurrentKmReading.val(0);
                objVehicleNo.focus();
            }
        }, ErrorFunction, false);
        if (objHdnVehicleId.val() == 1)
            txtCurrentKmReading.val(0);
        else if (objHdnVehicleId.val() != 0 && objHdnVehicleId.val() != '') {
            requestData = { vehicleId: objHdnVehicleId.val() };
            AjaxRequestWithPostAndJson(vehicleMasterUrl + '/GetStartKm', JSON.stringify(requestData), function (result) {
                txtCurrentKmReading.val(result);
            }, ErrorFunction, false);
        }
    }
}

function OnServiceCenterTypeChange() {
    dvServiceCenter.showHide(ddlServiceCenterType.val() != "" && hdnJobOrderId.val() == 0);
    $('#thTaskType').showHide(ddlServiceCenterType.val() == 2);
    $('#thUnit').showHide(ddlServiceCenterType.val() == 2);
    $('#thCost').showHide(ddlServiceCenterType.val() == 2);
    $('[id*="tdTaskType"]').showHide(ddlServiceCenterType.val() == 2);
    $('[id*="tdCostPerUnit"]').showHide(ddlServiceCenterType.val() == 2);
    $('[id*="tdCost"]').showHide(ddlServiceCenterType.val() == 2);
    $('#tf2').showHide(ddlServiceCenterType.val() == 2);
    $('#tf4').showHide(ddlServiceCenterType.val() == 2);
    $('#thTotalCost').showHide(ddlServiceCenterType.val() == 2);
    if (ddlServiceCenterType.val() == 1) {
        lblServiceCenter.text("Workshop");
        BindDropDownList('ddlServiceCenterId', locationList, 'Value', 'Name', '', 'Select');
        AddRequired(ddlServiceCenterId, "Please select Workshop");
        $('[id*="ddlPartTaskTypeId"]').val('');
        $('[id*="txtCostPerUnit"]').val(0);
        $('[id*="txtCost"]').val(0);
        $('#txtTotalCost').val(0);
    }
    else if (ddlServiceCenterType.val() == 2) {
        lblServiceCenter.text("Vendor");
        BindDropDownList('ddlServiceCenterId', vendorList, 'Value', 'Name', '', 'Select');
        AddRequired(ddlServiceCenterId, "Please select Vendor");
    }
    else {
        ddlServiceCenterId.empty();
        ddlServiceCenterId.append($("<option></option>").val('').html('Select'));
        ddlServiceCenterId.val('');
        RemoveRequired(ddlServiceCenterId);
    }
    InitSparePartDetail();
}

function InitTaskDetail() {
    $('[id*="ddlWorkGroupId"]').each(function () {
        var ddlWorkGroupId = $(this);
        var ddlTaskTypeId = $('#' + this.id.replace('ddlWorkGroupId', 'ddlTaskTypeId'));
        var ddlTaskId = $('#' + this.id.replace('ddlWorkGroupId', 'ddlTaskId'));
        var hdnTask = $('#' + this.id.replace('ddlWorkGroupId', 'hdnTask'));
        var txtEstimatedLabourHours = $('#' + this.id.replace('ddlWorkGroupId', 'txtEstimatedLabourHours'));
        var hdnLabourHours = $('#' + this.id.replace('ddlWorkGroupId', 'hdnLabourHours'));
        var txtEstimatedLabourCost = $('#' + this.id.replace('ddlWorkGroupId', 'txtEstimatedLabourCost'));
        var hdnLabourCost = $('#' + this.id.replace('ddlWorkGroupId', 'hdnLabourCost'));
        var txtRemarks = $('#' + this.id.replace('ddlWorkGroupId', 'txtRemarks'));
        //txtEstimatedLabourHours.val(0);
        //hdnLabourCost.val(0);
        ddlWorkGroupId.change(GetTaskDescription);
        ddlTaskTypeId.change(GetTaskDescription);
        GetTaskDescription();
        ddlTaskId.change(GetEstimatedLabourHours);
        txtEstimatedLabourHours.blur(GetEstimatedLabourCost);

        function GetTaskDescription() {
            if (ddlWorkGroupId.val() != '' && ddlTaskTypeId.val() != '') {
                var requestData = { workGroupId: ddlWorkGroupId.val(), taskTypeId: ddlTaskTypeId.val() };
                AjaxRequestWithPostAndJson(taskMasterUrl + '/GetTaskDescriptionListByWorkGroupIdAndTaskTypeId', JSON.stringify(requestData), GetTaskDescriptionListSuccess, ErrorFunction, false);
            }
            else {
                ddlTaskId.empty();
                ddlTaskId.append($("<option></option>").val('').html('Select'));
                ddlTaskId.val('');
            }
            if (hdnJobOrderId.val() > 0) {
                ddlTaskId.val(hdnTask.val());
                //hdnTask.val(0);
                txtEstimatedLabourHours.val(hdnLabourHours.val());
                txtEstimatedLabourCost.val(hdnLabourCost.val());
            }
            else {
                hdnTask.val(ddlTaskId.val());
                hdnLabourHours.val(txtEstimatedLabourHours.val());
                hdnLabourCost.val(txtEstimatedLabourCost.val());
            }
            if (txtLabourCostPerHour.val() != 0 && txtEstimatedLabourHours.val() != 0)
                txtEstimatedLabourCost.val(parseFloat(txtLabourCostPerHour.val()) * parseFloat(txtEstimatedLabourHours.val()));
            else
                txtEstimatedLabourCost.val(0);
            CalculateTotalEstimatedLabourHoursAndLabourCost();
        }

        function GetTaskDescriptionListSuccess(responseData) {
            BindDropDownList(ddlTaskId.Id, responseData, 'Value', 'Name', '', 'Select');
        }

        function GetEstimatedLabourHours() {
            if (ddlTaskId.val() != '') {
                hdnTask.val(ddlTaskId.val());
                var requestData = { taskId: ddlTaskId.val() };
                AjaxRequestWithPostAndJson(taskMasterUrl + '/GetEstimatedLabourHoursByTaskId', JSON.stringify(requestData), function (result) {
                    txtEstimatedLabourHours.val(result);
                }, ErrorFunction, false);
            }
            else {
                txtEstimatedLabourHours.val(0);
                txtEstimatedLabourCost.val(0);
            }
            GetEstimatedLabourCost();
        }

        function GetEstimatedLabourCost() {
            if (txtLabourCostPerHour.val() != 0 && txtEstimatedLabourHours.val() != 0)
                txtEstimatedLabourCost.val(parseFloat(txtLabourCostPerHour.val()) * parseFloat(txtEstimatedLabourHours.val()));
            else
                txtEstimatedLabourCost.val(0);
            CalculateTotalEstimatedLabourHoursAndLabourCost();
            if (parseFloat($('#txtTotalLabourCost').val()) != 0 && parseFloat($('#txtTotalLabourHours').val()) != 0)
                txtLabourCostPerHour.val(parseFloat($('#txtTotalLabourCost').val()) / parseFloat($('#txtTotalLabourHours').val()));
        }

        txtEstimatedLabourCost.blur(function () {
            CalculateTotalEstimatedLabourHoursAndLabourCost();
            if ($('#txtTotalLabourCost').val() != 0 && $('#txtTotalLabourHours').val() != 0)
                txtLabourCostPerHour.val(parseFloat($('#txtTotalLabourCost').val()) / parseFloat($('#txtTotalLabourHours').val()));
        });

        ddlWorkGroupId.change(function () {
            try {
                IsTaskExist($(this));
            }
            catch (e) {
                $(this).val('');
                SetFormFieldFocus($(this).attr('id'));
            }
        });

        ddlTaskTypeId.change(function () {
            try {
                IsTaskExist($(this));
            }
            catch (e) {
                $(this).val('');
                SetFormFieldFocus($(this).attr('id'));
            }
        });

        ddlTaskId.change(function () {
            try {
                IsTaskExist($(this));
            }
            catch (e) {
                $(this).val('');
                SetFormFieldFocus($(this).attr('id'));
            }
        });
    });
}

function CalculateTotalEstimatedLabourHoursAndLabourCost() {
    var totalEstimatedLabourHours = 0, totalEstimatedLabourCost = 0;
    $('[id*="txtEstimatedLabourHours"]').each(function () {
        var txtEstimatedLabourHours = $(this);
        var txtEstimatedLabourCost = $('#' + this.id.replace('txtEstimatedLabourHours', 'txtEstimatedLabourCost'));
        if (txtEstimatedLabourHours.val() != '')
            totalEstimatedLabourHours = totalEstimatedLabourHours + parseFloat(txtEstimatedLabourHours.val());
        if (txtEstimatedLabourCost.val() != '')
            totalEstimatedLabourCost = totalEstimatedLabourCost + parseFloat(txtEstimatedLabourCost.val());
    });
    $('#txtTotalLabourHours').val(totalEstimatedLabourHours);
    $('#txtTotalLabourCost').val(totalEstimatedLabourCost);
    txtTotalEstimatedLabourHours.val(totalEstimatedLabourHours);
    txtTotalEstimatedLabourCost.val(totalEstimatedLabourCost);
}

function OnLabourCostChange() {
    $('[id*="txtEstimatedLabourHours"]').each(function () {
        var txtEstimatedLabourHours = $(this);
        var txtEstimatedLabourCost = $('#' + this.id.replace('txtEstimatedLabourHours', 'txtEstimatedLabourCost'));
        txtEstimatedLabourCost.val(parseFloat(txtLabourCostPerHour.val()) * parseFloat(txtEstimatedLabourHours.val()));
    });
    CalculateTotalEstimatedLabourHoursAndLabourCost();
}

function IsTaskExist(obj) {
    if (obj.val() != '') {
        var outertr = obj.closest('tr');
        var outerddlWorkGroupId = outertr.find('[id*="ddlWorkGroupId"]');
        var outerddlTaskTypeId = outertr.find('[id*="ddlTaskTypeId"]');
        var outerddlTaskId = outertr.find('[id*="ddlTaskId"]');

        $('#dtTaskDetail tr:not(:first)').each(function () {
            var innertr = $(this);
            var innerddlWorkGroupId = innertr.find('[id*="ddlWorkGroupId"]');
            var innerddlTaskTypeId = innertr.find('[id*="ddlTaskTypeId"]');
            var innerddlTaskId = innertr.find('[id*="ddlTaskId"]');

            if (innerddlWorkGroupId.attr('id') != outerddlWorkGroupId.attr('id') && outerddlWorkGroupId.val() != '' && outerddlTaskTypeId.val() != '' && outerddlTaskId.val() != '' &&
                innerddlWorkGroupId.val() == outerddlWorkGroupId.val() &&
                innerddlTaskTypeId.val() == outerddlTaskTypeId.val() &&
                innerddlTaskId.val() == outerddlTaskId.val()) {
                ShowMessage("Task is already exist");
                throw (true);
            }
        });
    }
}

function InitSparePartDetail() {
    $('[id*="ddlPartTaskTypeId"]').each(function () {
        var ddlPartTaskTypeId = $(this);
        var ddlSkuId = $('#' + this.id.replace('ddlPartTaskTypeId', 'ddlSkuId'));
        var txtRequestedQuantity = $('#' + this.id.replace('ddlPartTaskTypeId', 'txtRequestedQuantity'));
        var txtCostPerUnit = $('#' + this.id.replace('ddlPartTaskTypeId', 'txtCostPerUnit'));
        var txtCost = $('#' + this.id.replace('ddlPartTaskTypeId', 'txtCost'));
        var txtRemark = $('#' + this.id.replace('ddlPartTaskTypeId', 'txtRemark'));
        CalculateTotalRequestedQuantityAndCost();
        txtRequestedQuantity.blur(CalculateTotalRequestedQuantityAndCost);
        txtCostPerUnit.blur(CalculateTotalRequestedQuantityAndCost);
        txtCostPerUnit.enable(ddlServiceCenterType.val() == 2);
        ddlPartTaskTypeId.enable(ddlServiceCenterType.val() == 2);
        if (ddlServiceCenterType.val() == 1) {
            RemoveRange(txtCostPerUnit);
            RemoveRequired(txtCostPerUnit);
            RemoveRequired(ddlPartTaskTypeId);
            txtCostPerUnit.val(0);
        }
        else {
            AddRange(txtCostPerUnit, 'Unit Cost must be greater than 0', 1);
            AddRequired(txtCostPerUnit, 'Please enter Unit Cost');
            AddRequired(ddlPartTaskTypeId, 'Please select Task Type');
        }

        ddlSkuId.change(function () {
            try {
                IsSparePartDetailExist($(this));
            }
            catch (e) {
                $(this).val('');
                SetFormFieldFocus($(this).attr('id'));
            }
        });

        ddlPartTaskTypeId.change(function () {
            try {
                IsSparePartDetailExist($(this));
            }
            catch (e) {
                $(this).val('');
                SetFormFieldFocus($(this).attr('id'));
            }
        });
    });
}

function CalculateTotalRequestedQuantityAndCost() {
    var totalRequestedQuantity = 0, totalCost = 0;
    $('[id*="txtRequestedQuantity"]').each(function () {
        var txtRequestedQuantity = $(this);
        var txtCost = $('#' + this.id.replace('txtRequestedQuantity', 'txtCost'));
        var txtCostPerUnit = $('#' + this.id.replace('txtRequestedQuantity', 'txtCostPerUnit'));
        if (txtRequestedQuantity.val() != '' && parseFloat(txtRequestedQuantity.val()) != 0 && txtCostPerUnit.val() != '' && parseFloat(txtCostPerUnit.val()) != 0)
            txtCost.val(parseFloat(txtRequestedQuantity.val()) * parseFloat(txtCostPerUnit.val()));
        else
            txtCost.val(0);
        if (txtRequestedQuantity.val() != '' && txtRequestedQuantity.val() != 0)
            totalRequestedQuantity = totalRequestedQuantity + parseFloat(txtRequestedQuantity.val());
        if (txtCostPerUnit.val() != '' && txtCostPerUnit.val() != 0)
            totalCost = totalCost + parseFloat(txtCost.val());
    });
    $('#txtTotalRequestedQuantity').val(totalRequestedQuantity);
    $('#txtTotalCost').val(totalCost);
    txtTotalEstimatedCost.val(parseFloat(txtTotalEstimatedLabourCost.val()) + totalCost);
}

function IsSparePartDetailExist(obj) {
    if (obj.val() != '') {
        var outertr = obj.closest('tr');
        var outerddlSkuId = outertr.find('[id*="ddlSkuId"]');
        var outerddlPartTaskTypeId = outertr.find('[id*="ddlPartTaskTypeId"]');

        $('#dtSparePartDetail tr:not(:first)').each(function () {
            var innertr = $(this);
            var innerddlSkuId = innertr.find('[id*="ddlSkuId"]');
            var innerddlPartTaskTypeId = innertr.find('[id*="ddlPartTaskTypeId"]');
            if (ddlServiceCenterType.val() == 2) {
                if (innerddlSkuId.attr('id') != outerddlSkuId.attr('id') && outerddlSkuId.val() != '' && outerddlPartTaskTypeId.val() != '' &&
                    innerddlSkuId.val() == outerddlSkuId.val() &&
                    innerddlPartTaskTypeId.val() == outerddlPartTaskTypeId.val()) {
                    ShowMessage("Part Detail is already exist");
                    throw (true);
                }
            }
            else if (ddlServiceCenterType.val() == 1) {
                if (innerddlSkuId.attr('id') != outerddlSkuId.attr('id') && outerddlSkuId.val() != '' &&
                innerddlSkuId.val() == outerddlSkuId.val()) {
                    ShowMessage("Part Detail is already exist");
                    throw (true);
                }
            }
        });
    }
}