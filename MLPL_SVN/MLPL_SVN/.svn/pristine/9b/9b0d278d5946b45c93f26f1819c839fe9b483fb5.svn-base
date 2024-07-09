var hdnJobOrderId, hdnServiceCenterType, txtTotalEstimatedLabourCost, lblServiceCenter, txtCloseKmReading;

$(document).ready(function () {
    SetPageLoad('Job Order', 'Close', 'txtCloseKmReading', '', '');
    InitObjects();
    OnPageLoad();
});

function InitObjects() {
    hdnJobOrderId = $('#hdnJobOrderId');
    hdnServiceCenterType = $('#hdnServiceCenterType');
    txtTotalEstimatedLabourCost = $('#txtTotalEstimatedLabourCost');
    lblServiceCenter = $('#lblServiceCenter');
    txtCloseKmReading = $('#txtCloseKmReading');

    InitGrid('dtTaskDetail', false, 9, InitTaskDetail);
    InitGrid('dtSparePartDetail', false, 9, InitSparePartDetail);

    InitWizard('dvWizard', [
     { StepName: 'Prepare Job Order' },
     { StepName: 'Task Details', StepFunction: CalculateTotalActualSparePartCost },
     { StepName: 'Spare Part Details' },
    ], 'Close');
}

function OnPageLoad() {
    lblServiceCenter.text(hdnServiceCenterType.val() == 1 ? "Workshop" : "Vendor");
    $('#lblCurrentKmReading').text("Start KM Reading");
    $('#txtTotalLabourCost').val(txtTotalEstimatedLabourCost.val());
    $('[id*="txtRequestedQuantity"]').blur();
    $('#thTaskType').showHide(hdnServiceCenterType.val() == 2);
    $('#thUnit').showHide(hdnServiceCenterType.val() == 2);
    $('#thCost').showHide(hdnServiceCenterType.val() == 2);
    $('[id*="tdTaskType"]').showHide(hdnServiceCenterType.val() == 2);
    $('[id*="tdCostPerUnit"]').showHide(hdnServiceCenterType.val() == 2);
    $('[id*="tdCost"]').showHide(hdnServiceCenterType.val() == 2);
    $('#tf2').showHide(hdnServiceCenterType.val() == 2);
    $('#tf4').showHide(hdnServiceCenterType.val() == 2);
    $('#thTotalCost').showHide(hdnServiceCenterType.val() == 2);
}

function InitTaskDetail() {
    $('[id*="chkAmcType"]').each(function () {
        var chkAmcType = $(this);
        var txtLabourCost = $('#' + this.id.replace('chkAmcType', 'txtLabourCost'));
        OnAmcTypeChange();
        chkAmcType.click(OnAmcTypeChange);
        txtLabourCost.blur(CalculateTotalActualLabourCost);
        CalculateTotalActualLabourCost();

        function OnAmcTypeChange() {
            txtLabourCost.val(0);
            if (!chkAmcType.IsChecked) {
                AddRange(txtLabourCost, 'Actual Labour Cost must be greater than 0', 1);
                txtLabourCost.enable();
            }
            else {
                RemoveRange(txtLabourCost);
                txtLabourCost.disable();
            }
            txtLabourCost.blur();
        }
    });
}

function CalculateTotalActualLabourCost() {
    var totalActualLabourCost = 0;
    $('[id*="txtLabourCost"]').each(function () {
        var txtLabourCost = $(this);
        if (parseFloat(txtLabourCost.val()) != 0)
            totalActualLabourCost = totalActualLabourCost + parseFloat(txtLabourCost.val());
    });
    $('#txtTotalActualLabourCost').val(totalActualLabourCost);
    $('#txtActualLabourCost').val(totalActualLabourCost);
}

function InitSparePartDetail() {
    $('[id*="txtActualQuantity"]').each(function () {
        var txtActualQuantity = $(this);
        var txtActualCostPerUnit = $('#' + this.id.replace('txtActualQuantity', 'txtActualCostPerUnit'));
        var txtQuantityActualCost = $('#' + this.id.replace('txtActualQuantity', 'txtQuantityActualCost'));
        CalculateTotalRequestedQuantityAndCost();
        txtActualQuantity.blur(CalculateTotalActualSparePartCost);
        txtActualCostPerUnit.blur(CalculateTotalActualSparePartCost);
    });
}

function CalculateTotalRequestedQuantityAndCost() {
    var totalRequestedQuantity = 0, totalCost = 0;
    $('[id*="txtRequestedQuantity"]').each(function () {
        var txtRequestedQuantity = $(this);
        var txtCost = $('#' + this.id.replace('txtRequestedQuantity', 'txtCost'));
        var txtCostPerUnit = $('#' + this.id.replace('txtRequestedQuantity', 'txtCostPerUnit'));
        if (parseFloat(txtRequestedQuantity.val()) != 0 && parseFloat(txtCostPerUnit.val()) != 0)
            txtCost.val(parseFloat(txtRequestedQuantity.val()) * parseFloat(txtCostPerUnit.val()));
        else
            txtCost.val(0);
        if (txtRequestedQuantity.val() != 0)
            totalRequestedQuantity = totalRequestedQuantity + parseFloat(txtRequestedQuantity.val());
        if (txtCostPerUnit.val() != 0)
            totalCost = totalCost + parseFloat(txtCost.val());
    });
    $('#txtTotalRequestedQuantity').val(totalRequestedQuantity);
    $('#txtTotalCost').val(totalCost);
}

function CalculateTotalActualSparePartCost() {
    var totalActualSparePartCost = 0;
    $('[id*="txtActualQuantity"]').each(function () {
        var txtActualQuantity = $(this);
        var txtQuantityActualCost = $('#' + this.id.replace('txtActualQuantity', 'txtQuantityActualCost'));
        var txtActualCostPerUnit = $('#' + this.id.replace('txtActualQuantity', 'txtActualCostPerUnit'));
        if (parseFloat(txtActualQuantity.val()) != 0 && parseFloat(txtActualCostPerUnit.val()) != 0)
            txtQuantityActualCost.val(parseFloat(txtActualQuantity.val()) * parseFloat(txtActualCostPerUnit.val()));
        else
            txtQuantityActualCost.val(0);
        totalActualSparePartCost = totalActualSparePartCost + parseFloat(txtQuantityActualCost.val());
    });
    $('#txtActualCost').val(totalActualSparePartCost);
    $('#txtTotalActualSparePartCost').val(totalActualSparePartCost);
    $('#txtTotalActualCost').val(totalActualSparePartCost + parseFloat($('#txtTotalActualLabourCost').val()));
}