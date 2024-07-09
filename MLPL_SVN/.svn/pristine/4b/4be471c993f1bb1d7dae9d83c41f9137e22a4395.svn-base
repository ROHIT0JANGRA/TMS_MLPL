var txtDocketNo, chkIsShort, chkIsReject, chkIsPilfer, chkIsDamage, txtShortPackages, txtRejectPackages, txtPilferPackages, txtDamagePackages, ddlShortPackagesReasonId, ddlRejectPackagesReasonId, ddlPilferPackagesReasonId,
    ddlDamagePackagesReasonId, txtShortRemark, txtRejectRemark, txtPilferRemark, txtDamageRemark, fuShortDocumentAttachment, fuRejectDocumentAttachment, fuPilferDocumentAttachment,
    fuDamageDocumentAttachment;
var docketNomenclature, thcUrl;

$(document).ready(function () {
    SetPageLoad('DEPS', 'Generate', '', '', '');
    InitObjects();
    AttachEvents();
});

function InitObjects() {
    txtDocketNo = $('#txtDocketNo');
    chkIsShort = $('#chkIsShort');
    chkIsReject = $('#chkIsReject');
    chkIsPilfer = $('#chkIsPilfer');
    chkIsDamage = $('#chkIsDamage');
    txtShortPackages = $('#txtShortPackages');
    txtRejectPackages = $('#txtRejectPackages');
    txtPilferPackages = $('#txtPilferPackages');
    txtDamagePackages = $('#txtDamagePackages');
    ddlShortPackagesReasonId = $('#ddlShortPackagesReasonId');
    ddlRejectPackagesReasonId = $('#ddlRejectPackagesReasonId');
    ddlPilferPackagesReasonId = $('#ddlPilferPackagesReasonId');
    ddlDamagePackagesReasonId = $('#ddlDamagePackagesReasonId');
    txtShortRemark = $('#txtShortRemark');
    txtRejectRemark = $('#txtRejectRemark');
    txtPilferRemark = $('#txtPilferRemark');
    txtDamageRemark = $('#txtDamageRemark');
    fuShortDocumentAttachment = $('#fuShortDocumentAttachment');
    fuRejectDocumentAttachment = $('#fuRejectDocumentAttachment');
    fuPilferDocumentAttachment = $('#fuPilferDocumentAttachment');
    fuDamageDocumentAttachment = $('#fuDamageDocumentAttachment');
    InitWizard('dvWizard', [
    { StepName: 'Criteria', StepFunction: GetDocketDetails },
    { StepName: docketNomenclature + ' Details', StepFunction: ValidateStep2 }
    ], 'Generate');
}

function AttachEvents() {
    OnDepsPackagesChange(chkIsDamage, ddlDamagePackagesReasonId, txtDamagePackages, txtDamageRemark, fuDamageDocumentAttachment);
    OnDepsPackagesChange(chkIsPilfer, ddlPilferPackagesReasonId, txtPilferPackages, txtPilferRemark, fuPilferDocumentAttachment);
    OnDepsPackagesChange(chkIsShort, ddlShortPackagesReasonId, txtShortPackages, txtShortRemark, fuShortDocumentAttachment);
    OnDepsPackagesChange(chkIsReject, ddlRejectPackagesReasonId, txtRejectPackages, txtRejectRemark, fuRejectDocumentAttachment);

    chkIsDamage.click(function () { OnDepsPackagesChange(chkIsDamage, ddlDamagePackagesReasonId, txtDamagePackages, txtDamageRemark, fuDamageDocumentAttachment); });
    chkIsPilfer.click(function () { OnDepsPackagesChange(chkIsPilfer, ddlPilferPackagesReasonId, txtPilferPackages, txtPilferRemark, fuPilferDocumentAttachment); });
    chkIsShort.click(function () { OnDepsPackagesChange(chkIsShort, ddlShortPackagesReasonId, txtShortPackages, txtShortRemark, fuShortDocumentAttachment); });
    chkIsReject.click(function () { OnDepsPackagesChange(chkIsReject, ddlRejectPackagesReasonId, txtRejectPackages, txtRejectRemark, fuRejectDocumentAttachment); });
    txtDamagePackages.blur(function () {
        if (chkIsShort.IsChecked) {
            var packages = parseInt($('#txtArrivalPackages').val()) - parseInt(txtShortPackages.val())
            if (parseInt(txtDamagePackages.val()) > packages) {
                ShowMessage('Please enter Damage Packages less than or equal to ' + packages);
                txtDamagePackages.val(0);
                return false;
            }
            if (parseInt(txtDamagePackages.val()) > (packages - parseInt(txtPilferPackages.val())))
                txtDamagePackages.val(0);
        }
        else {
            if (parseInt(txtDamagePackages.val()) > parseInt($('#txtArrivalPackages').val())) {
                ShowMessage('Please enter Damage Packages less than or equal to Arrival Packages');
                txtDamagePackages.val(0);
                return false;
            }
        }
    });

    txtPilferPackages.blur(PilferedPackagesChange);
    txtRejectPackages.blur(RejectPackagesChange);
    txtShortPackages.blur(ShortPackagesChange);
}

function GetDocketDetails() {
    var requestData = { docketNo: txtDocketNo.val() };
    AjaxRequestWithPostAndJson(thcUrl + '/GetDocketDetailsForDeps', JSON.stringify(requestData), function (result) {
        if (result.DocketId == 0) {
            isStepValid = false;
            ShowMessage(docketNomenclature + ' is not available for DEPS');
            return false;
        }
        else {
            $('#hdnDocketId').val(result.DocketId);
            $('#lblDocketNo').text(result.DocketNo + result.DocketSuffix);
            $('#hdnDocketSuffix').val(result.DocketSuffix);
            $('#lblDocketDate').text($.displayDate(result.DocketDate));
            $('#lblDocketStatus').text(result.DocketStatus);
            $('#lblFromLocation').text(result.FromLocation);
            $('#lblToLocation').text(result.ToLocation);
            $('#txtPackages').val(result.Packages);
            $('#txtActualWeight').val(result.ActualWeight);
            $('#txtArrivalPackages').val(result.ArrivalPackages);
            $('#txtArrivalWeight').val(result.ArrivalWeight);
            $('#hdnThcId').val(result.ThcId);
            $('#hdnManifestId').val(result.ManifestId);
        }
    }, ErrorFunction, false);
    return false;
}

function OnDepsPackagesChange(objCheck, objddlReasonId, objtxtPakage, objtxtRemark, objDocumentAttachment) {
    objddlReasonId.val('');
    objtxtPakage.val(0);
    objtxtRemark.val('');
    objDocumentAttachment.val('');
    if (objCheck.IsChecked) {
        AddRequired(objddlReasonId, "Please select Reason");
        AddRequired(objtxtRemark, "Please enter Remark");
        AddRange(objtxtPakage, "Please enter Packages greater than 0", 1);
    }
    else {
        RemoveRequired(objddlReasonId);
        RemoveRequired(objtxtRemark);
        RemoveRequired(objtxtPakage);
    }
    objddlReasonId.enable(objCheck.IsChecked);
    objtxtPakage.enable(objCheck.IsChecked);
    objtxtRemark.enable(objCheck.IsChecked);
    objDocumentAttachment.enable(objCheck.IsChecked);
}

function RejectPackagesChange() {
    var packages = parseInt($('#txtArrivalPackages').val()) - parseInt(txtShortPackages.val())
    if (chkIsShort.IsChecked) {
        var packages = parseInt($('#txtArrivalPackages').val()) - parseInt(txtShortPackages.val())
        if (parseInt(txtRejectPackages.val()) > packages) {
            ShowMessage('Please enter Reject Packages less than or equal to ' + packages);
            txtRejectPackages.val(0);
            return false;
        }
        if (parseInt(txtRejectPackages.val()) > (packages - parseInt(txtPilferPackages.val())))
            txtRejectPackages.val(0);
    }
    else {
        if (parseInt(txtRejectPackages.val()) > parseInt($('#txtArrivalPackages').val())) {
            ShowMessage('Please enter Reject Packages less than or equal to Arrival Packages');
            txtRejectPackages.val(0);
            return false;
        }
    }
}

function PilferedPackagesChange() {
    if (chkIsShort.IsChecked) {
        var packages = parseInt($('#txtArrivalPackages').val()) - parseInt(txtShortPackages.val())
        if (parseInt(txtPilferPackages.val()) > packages) {
            ShowMessage('Please enter Pilfered Packages less than or equal to ' + packages);
            txtPilferPackages.val(0);
            return false;
        }
        if (parseInt(txtPilferPackages.val()) > (packages - parseInt(txtDamagePackages.val())))
            txtPilferPackages.val(0);
    }
    else if (parseInt(txtPilferPackages.val()) > parseInt($('#txtArrivalPackages').val())) {
        ShowMessage('Please enter Pilfered Packages less than or equal to Arrival Packages');
        txtPilferPackages.val(0);
        return false;
    }
}

function ShortPackagesChange() {
    if (parseInt(txtShortPackages.val()) >= parseInt($('#txtArrivalPackages').val())) {
        ShowMessage('Please enter Short Packages less than Arrival Packages');
        txtShortPackages.val(0);
        return false;
    }
    if (parseInt(txtDamagePackages.val()) > (parseInt($('#txtArrivalPackages').val()) - parseInt(txtShortPackages.val())))
        txtDamagePackages.val(0);
    if (parseInt(txtPilferPackages.val()) > (parseInt($('#txtArrivalPackages').val()) - parseInt(txtShortPackages.val())))
        txtPilferPackages.val(0);
    if ((parseInt(txtDamagePackages.val()) + parseInt(txtPilferPackages.val())) > (parseInt($('#txtArrivalPackages').val()) - parseInt(txtShortPackages.val()))) {
        txtPilferPackages.val(0);
        txtDamagePackages.val(0);
    }
}

function ValidateStep2() {
    if (!chkIsShort.IsChecked && !chkIsPilfer.IsChecked && !chkIsDamage.IsChecked && !chkIsReject.IsChecked) {
        isStepValid = false;
        ShowMessage('Please select at least one SEPD');
        return false;
    }
}