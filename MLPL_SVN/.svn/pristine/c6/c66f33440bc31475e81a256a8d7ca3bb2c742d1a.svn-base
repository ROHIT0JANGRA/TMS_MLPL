var documentType = 'DKT', documentNos = '';
$(document).ready(function () {
    SetPageLoad('Tracking', 'Consignment', 'txtDocumentNo');
    documentType = GetUrlValue()["documentType"];
    documentNos = GetUrlValue()["documentNos"];
    rdDocketNo = $('#rdDocketNo');
    //rdManualDocketNo = $('#rdManualDocketNo');
    txtDocumentNos = $('#txtDocumentNos');
    dtDocketDetails = $('#dtDocketDetails');
    dtTransitDetails = $('#dtTransitDetails');
    btntrack = $('#btntrack');
    txtDocumentNos.val(documentNos);
    rdDocketNo.check();
    //rdManualDocketNo.check(documentType != 'DKT');
    btnBackToSummary = $('#btnBackToSummary');
    btntrack.click(GetDocketDetails);
    btnBackToSummary.click(GoBackToSummary);

    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [
            { title: 'Docket No', data: "DocketNo" },
            { title: 'Referance No', data: "ReferanceNo" },
            { title: 'Status', data: "DocketStatus" },
            { title: 'Undelivered Reason', data: "UndeliveredReason" },
            { title: 'Booking Date & Time', data: "DocketDateTime" },
            { title: 'Current Location', data: "CurrentLocation" },
            { title: 'Destination', data: "ToLocation" },
            { title: 'Receiver Name', data: "ReceiverName" },
            { title: 'View POD', data: "POD" }
        ]);


    dtTransitDetails = LoadDataTable('dtTransitDetails', false, false, false, null, null, [],
        [
            { title: ' ', data: "Row" },
            { title: 'Transit Location', data: "TransitLocation" },
            { title: 'Activity at Location', data: "ActivityAtLocation" },
            { title: 'Date & Time', data: "ActivityDateTime" }
        ]);
});

function GetDocketDetails() {
    if (txtDocumentNos.val() != '') {
        $('#dvBackToSummary').hide();
        $('#dvTransitSummary').hide();
        $('#dvShipmentHistory').hide();
        $('#dvTransitDetail').hide();
        var requestData = {
            documentNos: txtDocumentNos.val(),
            documentType: rdDocketNo.IsChecked
        };
        AjaxRequestWithPostAndJson(baseUrl + '/GetConsignmentDetailsList', JSON.stringify(requestData), GetDocketDetailsSuccess, ErrorFunction, false);
        return false;
    }
    else {
        ShowMessage("Please enter Document No.");
        return false;
    }
}

function GetDocketDetailsSuccess(responseData) {
    dtDocketDetails.showHide(!responseData.length == 0);
    if (responseData.length == 0) {
        $('#dvDocketDetail').hide();
        ShowMessage('No Record Found');
        return false;
    }
    dtDocketDetails.fnClearTable();
    if (responseData.length > 0) {
        $('#dvDocketDetail').show();
        $.each(responseData, function (i, item) {
            var podBtnClass = '';
            var podSpanClass = '';
            item.DocketNo = "<input type='hidden' value='" + item.DocketId + "'  id='hdnDocketId" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketSuffix + "'  id='hdnDocketSuffix" + i + "'/>" +
                '<a href="#" id ="lnk' + i + '"  onclick="return ViewTransitDetail(this.id)">' + item.DocketNo + " " + item.DocketSuffix + '</a>';
            item.DocketDateTime = $.displayDateTime(item.DocketDateTime);
            item.podSpanClass = IsObjectNullOrEmpty(item.PodDocumentName) ? 'glyphicon glyphicon-eye-close' : 'glyphicon glyphicon-eye-open';
            item.podBtnClass = IsObjectNullOrEmpty(item.PodDocumentName) ? 'btn btn-primary btn-sm disabled' : 'btn btn-primary btn-sm';
            item.POD = '<button type="button" id="btnPodView' + i + '" onclick="return ViewPod(\'' + item.PodDocumentName + '\')" class="' + item.podBtnClass + '">' +
                '<span class="' + item.podSpanClass + '"></span>' +
                '</button>';
        });
        dtDocketDetails.dtAddData(responseData);
    }

}

function ViewPod(documentName) {
    window.open(filePath + documentName, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=100,left=500,width=400,height=300");
    return false;
}

function ViewTransitDetail(lnkId) {
    var lnk = $('#' + lnkId);
    var hdnDocketId = $('#' + lnk.Id.replace('lnk', 'hdnDocketId'));
    var hdnDocketSuffix = $('#' + lnk.Id.replace('lnk', 'hdnDocketSuffix'));
    if (hdnDocketId.val() != '') {
        $('#dvDocketDetail').hide();
        var requestData = {
            docketId: hdnDocketId.val(),
            docketSuffix: hdnDocketSuffix.val()
        };
        AjaxRequestWithPostAndJson(baseUrl + '/GetConsignmentTransitDetails', JSON.stringify(requestData), GetConsignmentTransitDetailsSuccess, ErrorFunction, false);
        AjaxRequestWithPostAndJson(baseUrl + '/GetConsignmentTransitList', JSON.stringify(requestData), GetConsignmentTransitListSuccess, ErrorFunction, false);
    }
    else {
        ShowMessage("Transit Summary Not Found");
        return false;
    }
}

function GetConsignmentTransitDetailsSuccess(responseData) {
    if (IsObjectNullOrEmpty(responseData)) {
        $('#dvTransitSummary').hide();
    }
    else {
        $('#dvTransitSummary').show();
        $('#dvBackToSummary').show();
        $('#lblDocket').text(responseData.DocketNo + " " + responseData.DocketSuffix);
        $('#lblReferenceNumber').text(responseData.ReferanceNo);
        $('#lblOrigin').text(responseData.Origin);
        $('#lblFromCity').text(responseData.FromCityName);
        $('#lblBookingDateTime').text($.displayDateTime(responseData.DocketDateTime));
        $('#lblDeliveryDateTime').text($.displayDateTime(responseData.DeliveryDateTime));
        $('#lblStatus').text(responseData.DocketStatus);
        $('#lblDestination').text(responseData.Destination);
        $('#lblToCity').text(responseData.ToCityName);
        $('#lblCurrentDateTime').text($.displayDateTime(responseData.CurrentStatusDateTime));
        $('#lblPackages').text(responseData.Packages);
    }
}

function GetConsignmentTransitListSuccess(responseData) {
    $('#dvShipmentHistory').show();
    $('#dvTransitDetail').show();
    dtTransitDetails.fnClearTable();
    $.each(responseData, function (i, item) {
        item.Row = "<input type='hidden' value='" + item.RowNumber + "' />" +
            '<input class="form-control textlabel"  type="text" style="width: 50px;" />';
        item.ActivityDateTime = "<input type='hidden' value='" + item.TransitDateTime + "'id='hdnTransitDateTime" + i + "'  />" +
            $.displayDateTime(item.ActivityDateTime);
    });
    dtTransitDetails.dtAddData(responseData);
    dtTransitDetails.find('tr td:eq(0)').css('max-width', '280px');

    var nextDocketDate = systemDateTime, currentDocketDate = systemDateTime;
    dtTransitDetails.find('tbody > tr').each(function () {
        var tr = $(this);
        var trHtml = tr.html();
        var hdnTransitDateTime = tr.find('[id*="hdnTransitDateTime"]');
        currentDocketDate = hdnTransitDateTime.val();
        if (currentDocketDate != nextDocketDate) {
            var trNewHtml = '<tr><td data-title="Status" colspan="13"><b class="label-bold">' + $.displayDate(hdnTransitDateTime.val()) + '</b></td><tr>';
            var trNew = $(trNewHtml);
            tr.before(trNew);
            nextDocketDate = currentDocketDate;
        }
    });
}

function GoBackToSummary() {
    $('#dvBackToSummary').hide();
    $('#dvDocketDetail').show();
    $('#dvTransitSummary').hide();
    $('#dvShipmentHistory').hide();
    $('#dvTransitDetail').hide();
}