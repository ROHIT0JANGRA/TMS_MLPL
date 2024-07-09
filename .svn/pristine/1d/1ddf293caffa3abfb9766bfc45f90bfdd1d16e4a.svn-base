var ddlDocumentTypeDetail;
var baseUrl;

$(document).ready(function () {
    InitObjects();
    AttachEvents();
    SetPageLoad('POD', 'Scan', 'txtDocumentNo', '', '');
    InitGrid('dtScanDetailList', false, 6, InitScanDetailTable, false);
});

function InitScanDetailTable() {
    $('[id*="txtDocumentNo"]').each(function () {
        var txtDocumentNo = $(this);
        var hdnDocumentId = $('#' + this.id.replace('txtDocumentNo', 'hdnDocumentId'));
        var ddlDocumentTypeDetail = $('#' + this.id.replace('txtDocumentNo', 'ddlDocumentTypeDetail'));
        var hdnDocumentType = $('#' + this.id.replace('txtDocumentNo', 'hdnDocumentType'));
        var txtManualNo = $('#' + this.id.replace('txtDocumentNo', 'txtManualNo'));
        var lblScanStatus = $('#' + this.id.replace('txtDocumentNo', 'lblScanStatus'));
        var txtScanStatus = $('#' + this.id.replace('txtDocumentNo', 'txtScanStatus'));
        var lnkAttachment = $('#' + this.id.replace('txtDocumentNo', 'lnkAttachment'));
        var lblAttachment = $('#' + this.id.replace('txtDocumentNo', 'lblAttachment'));
        var hdnDocumentName = $('#' + this.id.replace('txtDocumentNo', 'hdnDocumentName'));
        var lblManualNo = $('#' + this.id.replace('txtDocumentNo', 'lblManualNo'));

        if (lblScanStatus.text() != "Scanned")
        {
            lnkAttachment.hide();
            lblManualNo.hide();
        }

        if (lblManualNo.text() == "") {
            lblManualNo.hide();
        }
        //


        if(ddlDocumentTypeHeader.val()!="")
        {
            $('[id*="ddlDocumentTypeDetail"]').val(ddlDocumentTypeHeader.val()).change();
        }


        txtDocumentNo.blur(function () {
            if (!CheckDuplicateInTable('dtScanDetailList', 'txtDocumentNo', 'POD No', txtDocumentNo)) return false;

            if (txtDocumentNo.val() != "" && (ddlDocumentTypeDetail.val() == 1 || ddlDocumentTypeDetail.val() == 8 || ddlDocumentTypeDetail.val() == 2)) {
                var requestData = { DocumentNo: txtDocumentNo.val(), PodTypeId: ddlDocumentTypeDetail.val() };
                AjaxRequestWithPostAndJson(baseUrl + '/CheckPodScanStatus', JSON.stringify(requestData), function (result) {
                    if (!result.IsSuccessfull) {
                        ShowMessage(result.ErrorMessage);
                        hdnDocumentId.val(0);
                        txtDocumentNo.val('');
                    }
                    else {
                        hdnDocumentId.val(result.DocumentId);
                        txtDocumentNo.val(result.DocumentNo);
                        lnkAttachment.showHide(result.ScanStatus);
                        hdnDocumentName.val(result.DocumentName)
                        lblScanStatus.text((result.ScanStatus ? 'Scanned' : 'Pending'));
                    }
                }, ErrorFunction, false);
            }
            return false;
        });



        ddlDocumentTypeDetail.change(function () {
            var manualNoNaArr = ['', '1', '2', '6', '7'];
            var inArray = ($.inArray(ddlDocumentTypeDetail.val(), manualNoNaArr) !== -1);
            lblManualNo.showHide(inArray);
            txtManualNo.showHide(!inArray);
            hdnDocumentType.val($('#' + ddlDocumentTypeDetail.Id + ' option:selected').text());
        });


    });
}

function InitObjects() {
    ddlDocumentTypeHeader = $('#ddlDocumentTypeHeader');
}

function AttachEvents() {
    ddlDocumentTypeHeader.change(function () {
        $('[id*="ddlDocumentTypeDetail"]').val(ddlDocumentTypeHeader.val()).change();
    });
}
