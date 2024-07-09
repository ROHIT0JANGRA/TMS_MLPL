var dtDepsDetails, drDepsDate, txtDocketNo, txtDepsNo, sepdUrl, ddlselectDate, txtFoundPackages, rdUpdate, rdClose, docketNomenClature, selectedDepsList;

$(document).ready(function () {
    SetPageLoad('DEPS', 'Update', '', '', '');
    InitObjects();
});

function InitObjects() {
    hdnLocationId = $('#hdnLocationId');
    txtDocketNo = $('#txtDocketNo');
    txtDepsNo = $('#txtDepsNo');
    txtFoundPackages = $('#txtFoundPackages');
    ddlselectDate = $('#ddlselectDate');
    rdUpdate = $('#rdUpdate');
    rdClose = $('#rdClose');
    drDepsDate = InitDateRange('drDepsDate', DateRange.LastWeek);
    InitWizard('dvWizard', [
    { StepName: 'Criteria', StepFunction: GetDepsList },
    { StepName: 'DEPS List', StepFunction: MoveToNextAction }
    ], 'Done');

    dtDepsDetails = LoadDataTable('dtDepsDetails', false, false, false, null, null, [],
              [
                  { title: "<div class='clearfix' style='width:80px'><div class='checkboxer'>" + SelectAll.GetChkAll('chkAllDeps', CheckValidation) + "</div></div>", data: "DepsDocketId", width: 80 },
                  { title: 'DEPS No', data: 'DepsNo' },
                  { title: docketNomenClature + ' No', data: 'DocketNo' },
                  { title: 'DEPS Type', data: 'Type' },
                  { title: 'Entry By', data: 'EntryByName' },
                  { title: 'Status', data: 'Status' },
                  { title: 'Packages', data: 'NoOfPackages' },
                  { title: 'Found Packages', data: 'FoundPackages' },
                  { title: 'Remark', data: 'Remark' },
                  { title: 'History', data: 'History' }
              ]);
}

function GetDepsList() {

    var requestData = { fromDate: drDepsDate.startDate, toDate: drDepsDate.endDate, docketNo: txtDocketNo.val(), depsNo: txtDepsNo.val(), dateType: ddlselectDate.val(), isUpdate: rdUpdate.IsChecked };

    AjaxRequestWithPostAndJson(sepdUrl + '/GetDepsListForStockUpdate', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedDepsList = [];
            dtDepsDetails.fnClearTable();
            $.each(result, function (i, item) {
                item.History = '<a href="#" onclick="javascript:ViewHistory(' + item.DepsDocketId + ');">DEPS History</a>';
                item.DepsDocketId = "<div class='checkboxer'>" + SelectAll.GetChk('chkAllDeps', 'chkDeps' + i, 'ManifestList[' + i + '].IsChecked', CheckValidation) +
                               "<input type='hidden' value='" + item.DepsDocketId + "' name='ManifestList[" + i + "].DepsDetails.DepsDocketId' id='hdnDepsDocketId" + i + "'/>" +
                               "<label class='control-label' for='chkDeps" + i + "' id='lblDepsDocketId" + i + "'></label>" +
                               "<input type='hidden' value='" + item.DocketId + "' name='ManifestList[" + i + "].DepsDetails.DocketId' id='hdnDocketId" + i + "'/>" +
                               "<input type='hidden' value='" + item.DocketSuffix + "' name='ManifestList[" + i + "].DepsDetails.DocketSuffix' id='hdnDocketSuffix" + i + "'/>" +
                               "<input type='hidden' value='" + item.DepsNo + "' name='ManifestList[" + i + "].DepsDetails.DepsNo' id='hdnDepsNo" + i + "'/>" +
                               "<input type='hidden' value='" + item.DepsType + "' name='ManifestList[" + i + "].DepsDetails.DepsType' id='hdnDepsType" + i + "'/>" +
                           "</div>"
                item.FoundPackages = '<input type="text" name="ManifestList[' + i + '].DepsDetails.FoundPackages"  id="txtFoundPackages' + i + '" class="form-control numeric" disabled value="0"/>';
                item.DocketNo = item.DocketNo + " " + item.DocketSuffix;
                if (item.DepsType == 1)
                    item.Type = "Shortage";
                else if (item.DepsType == 2)
                    item.Type = "Extra";
                else if (item.DepsType == 3)
                    item.Type = "Pilefere";
                else
                    item.Type = "Damage";

                item.NoOfPackages = "<input type='text' value='" + item.Packages + "' name='ManifestList[" + i + "].DepsDetails.Packages' id='txtNoOfPackages" + i + "'class='textlabel textlabel-small' style='text-align: right'/>";
                item.Remark = '<input type="text" name="ManifestList[' + i + '].DepsDetails.Remark"  id="txtRemark' + i + '" placeholder="Remark" class="form-control" disabled/>';
                
                //item.History = '<input type="button" id="btnHistoryView' + i + '"onclick="return View(' + item.History + ')"/>';

                if (item.DepsStatus == 1) {
                    item.Status = "Generated";
                }
                else if (item.DepsStatus == 2) {
                    item.Status = "Updated";
                }
                else {
                    item.Status = "Closed";
                };
            });
            dtDepsDetails.dtAddData(result);
            selectedDepsDocketId = 0;

        }
    }, ErrorFunction, false);
}

function CheckValidation() {
    selectedDepsList = [];
    $('[id*="chkDeps"]').each(function () {
        var chkDeps = $(this);
        var txtFoundPackages = $('#' + chkDeps.Id.replace('chkDeps', 'txtFoundPackages'));
        var txtNoOfPackages = $('#' + chkDeps.Id.replace('chkDeps', 'txtNoOfPackages'));
        var hdnDepsDocketId = $('#' + chkDeps.Id.replace('chkDeps', 'hdnDepsDocketId'));
        var txtRemark = $('#' + chkDeps.Id.replace('chkDeps', 'txtRemark'));
        var hdnDepsType = $('#' + chkDeps.Id.replace('chkDeps', 'hdnDepsType'));

        txtFoundPackages.blur(function () {
            if (parseInt(txtFoundPackages.val()) > parseInt(txtNoOfPackages.val())) {
                ShowMessage('Please enter FoundPackages less than or equal to packages');
                txtFoundPackages.val(0);
                return false;
            }
        });
        txtFoundPackages.enable(chkDeps.IsChecked && hdnDepsType.val() == '1');
        txtRemark.enable(chkDeps.IsChecked);
        if (chkDeps.IsChecked) {
            selectedDepsList.push($('#' + chkDeps.Id.replace('chkDeps', 'hdnDepsDocketId')).val());
        }
    });
}

function MoveToNextAction() {
    if (selectedDepsList.length == 0) {
        ShowMessage('Please select at least one Deps Request');
        isStepValid = false;
        return false;
    }
}

function ViewHistory(value) {
    $.ajax({
        type: "POST",
        url: sepdUrl + '/GetDepsHistory',
        data: '{depsDocketId:"' + value + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            bootbox.dialog({
                title: "History",
                message: response,
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