var drDrsDate, txtDrsNo, txtVehicleNo, ddlArrivalLocation, dtDrsDetails, drsUrl, selectedDrsId, dtDocketDetails, currentDate, dateTimeFormat, lateDeliveryReasonList, partDeliveryReasonList, unDeliveryReasonList, docketNomenclature;

$(document).ready(function () {
    SetPageLoad('DRS', 'Close', '', '', '');
    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDrsList },
        { StepName: 'THC Details', StepFunction: LoadStep3 },
        { StepName: 'Basic Details', StepFunction: ValidateOnSubmit }
    ], 'Close DRS');
    InitObjects();
});

function InitObjects() {
    drDrsDate = InitDateRange('drDrsDate', DateRange.LastWeek);
    txtDrsNo = $('#txtDrsNo');
    dtDrsDetails = $('#dtDrsDetails');
    ddlHeaderLateDeliveryReasonId = $('#ddlHeaderLateDeliveryReasonId');
    ddlHeaderPartDeliveryReasonId = $('#ddlHeaderPartDeliveryReasonId');
    ddlHeaderUnDeliveryReasonId = $('#ddlHeaderUnDeliveryReasonId');

    AjaxRequestWithPostAndJson(drsUrl + '/GetReasonList', JSON.stringify([]), function (result) {
        lateDeliveryReasonList = result.Late;
        partDeliveryReasonList = result.Part;
        unDeliveryReasonList = result.Un;
    }, ErrorFunction, false);

    BindDeliveryReason(ddlHeaderLateDeliveryReasonId, lateDeliveryReasonList, 'Late');
    BindDeliveryReason(ddlHeaderPartDeliveryReasonId, partDeliveryReasonList, 'Part');
    BindDeliveryReason(ddlHeaderUnDeliveryReasonId, unDeliveryReasonList, 'Un');

    dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
        [
            { data: 'DocketNoDatePayBasEdd' },
            { data: 'ConsignorConsignee' },
            { data: 'Packages' },
            { data: 'DeliveryDatePersonRemark' },
            { data: 'DeliveryReason' }
        ]);
}

function GetDrsList() {

    var drsNo = txtDrsNo.val();

    var requestData = { drsNos: drsNo, fromDate: drDrsDate.startDate, toDate: drDrsDate.endDate };

    AjaxRequestWithPostAndJson(drsUrl + '/GetDrsListForDrsUpdate', JSON.stringify(requestData), function (result) {
        if (result.length == 0) {
            isStepValid = false;
            ShowMessage('No Record Found');
            return false;
        }
        else {
            selectedThc = [];
            dtDrsDetails = LoadDataTable('dtDrsDetails', false, false, false, null, null, [],
                [
                    { title: 'DRS No', data: 'DrsNo' },
                    { title: 'Vehicle No', data: 'VehicleNo' },
                    { title: 'DRS Date', data: 'DrsDate' },
                    { title: 'Total ' + docketNomenclature + '(s)', data: 'TotalDocket' }
                ]);

            dtDrsDetails.fnClearTable();
            $.each(result, function (i, item) {
                item.DrsNo = '<div class="clearfix">' +
                    '<label class="radio">' +
                    '<input type="radio" name=\'Drs\' value=\'' + item.DrsId + '\' onclick="GetDrsDetail(this)" tabindex="0" id="chkDrsNo' + i + '"/><i></i>' +
                    '<label for="chkDrsNo' + i + '">' + item.DrsNo + '</label>' +
                    '</label>' +
                    '</div>';
                item.DrsDate = $.displayDateTime(item.DrsDate);
            });
            dtDrsDetails.dtAddData(result);
            selectedDrsId = 0;
        }
    }, ErrorFunction, false);
    return false;
}

function GetDrsDetail(rd) {
    selectedDrsId = rd.value;
}

function LoadStep3() {
    isStepValid = selectedDrsId != 0;
    if (selectedDrsId == 0) {
        ShowMessage('Please select DRS');
        return false;
    }
    var requestData = { drsId: selectedDrsId };
    //AjaxRequestWithPostAndJson(drsUrl + '/GetDRSDetailsById', JSON.stringify(requestData), OnDrsDetailSuccess, ErrorFunction, false);
    AjaxRequestWithPostAndJson(drsUrl + '/GetDrsDocketListById', JSON.stringify(requestData), function (result) {
        if (IsObjectNullOrEmpty(result)) {
            ShowMessage('Something Wrong. Please try again');
            return false;
        }
        $('#hdnDrsId').val(selectedDrsId);
        $('#lblDrsNo').text(result.DrsNo);
        $('#hdnDrsNo').val(result.DrsNo);
        $('#lblDrsDate').text($.displayDateTime(result.DrsDate));
        $('#lblDriverName').text(result.FirstDriverName);
        $('#lblStartKm').text(result.StartKm);
        $('#lblVehicleNo').text(result.VehicleNo);
        $('#hdnStartKm').val(result.StartKm);

      

        dtDocketDetails.fnClearTable();
        $.each(result.DrsDocketList, function (i, item) {
            item.BookedPackages = "<input type='text' value='" + item.BookedPackages + "' name='DocketDetails[" + i + "].BookedPackages' id='txtBookedPackages" + i + "'class='textlabel' style='text-align: right'/>";
            item.ArrivedPackages = "<input type='text' value='" + item.ArrivedPackages + "' name='DocketDetails[" + i + "].ArrivedPackages' id='txtArrivedPackages" + i + "'class='textlabel' style='text-align: right'/>";
            item.DocketDate = $.displayDate(item.DocketDate);
            item.EDD = "<input type='hidden' value='" + item.DocketId + "' name='DocketDetails[" + i + "].DocketId' id='hdnDocketId" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketNo + "' name='DocketDetails[" + i + "].DocketNo' id='hdnDocketNo" + i + "'/>" +
                "<input type='hidden' value='" + item.DocketSuffix + "' name='DocketDetails[" + i + "].DocketSuffix' id='hdnDocketSuffix" + i + "'/>" +
                "<input type='text' value='" + $.displayDate(item.EDD) + "' name='DocketDetails[" + i + "].EDD' id='txtEDD" + i + "'class='from-control textlabel' style='margin-left:0;'/>";
            item.DeliveredPackages = "<div class='input'><input type='text' value='" + item.PendingPackages + "' name='DocketDetails[" + i + "].DeliveredPackages'  placeholder='Delievered Packages' id='txtDeliveredPackages" + i + "'class='form-control numeric'/></div>" +
                '<div><span data-valmsg-for="DocketDetails[' + i + '].DeliveredPackages" data-valmsg-replace="true"></span></div>';
            item.PendingPackages = "<input type='text' value='" + item.PendingPackages + "' name='DocketDetails[" + i + "].PendingPackages' id='txtPendingPackages" + i + "'class='textlabel' style='text-align: right'/>" +
                "<input type='hidden' value='" + item.PendingPackages + "' name='DocketDetails[" + i + "].PendingPackages' id='hdnPendingPackages" + i + "'/>";
            item.Remark = "<div class='input'><input type='text' name='DocketDetails[" + i + "].Remark'  placeholder='Remarks' id='txtRemark" + i + "'class='form-control'/></div>" +
                '<div><span data-valmsg-for="DocketDetails[' + i + '].Remark" data-valmsg-replace="true"></span></div>';
            item.DeliveryDate = "<div class='input'><label class='icon-right' for='txtDeliveryDate" + i + "'><i class='fa fa-calendar'></i> </label>" +
                                            "<input type='text' name='DocketDetails[" + i + "].DeliveryDateTime' placeholder='Delivery Date' id='txtDeliveryDate" + i + "' class='form-control datepicker' /></div>" +
            '<div><span data-valmsg-for="DocketDetails[' + i + '].DeliveryDateTime" data-valmsg-replace="true"></span></div>';
            item.PersonName = "<div class='input'><input type='text' name='DocketDetails[" + i + "].PersonName' placeholder='Person' id='txtPersonName" + i + "'class='form-control'/></div>" +
                '<div><span data-valmsg-for="DocketDetails[' + i + '].PersonName" data-valmsg-replace="true"></span></div>';
            item.LateDeliveryReason = "<div class='select' id='dvLateDeliveryReason" + i + "'>" +
                "<select class='form-control' name='DocketDetails[" + i + "].LateDeliveryReasonId' id='ddlLateDeliveryReasonId" + i + "' > " + "</select><i></i>" +
                "</div>" +
                '<span data-valmsg-for="DocketDetails[' + i + '].LateDeliveryReasonId" data-valmsg-replace="true"></span>';
            item.UnDeliveryReason = "<div class='select' id='dvUnDeliveryReason" + i + "'>" +
                "<select class='form-control' name='DocketDetails[" + i + "].UndeliveredReasonId' id='ddlUndeliveredReasonId" + i + "' > " + "</select><i></i>" +
                "</div>" +
                '<span data-valmsg-for="DocketDetails[' + i + '].UndeliveredReasonId" data-valmsg-replace="true"></span>';
            item.PartDeliveryReason = "<div class='select' id='dvPartDeliveryReason" + i + "'>" +
                "<select class='form-control' name='DocketDetails[" + i + "].PartDeliveryReasonId' id='ddlPartDeliveryReasonId" + i + "' > " + "</select><i></i>" +
                "</div>" +
                '<span data-valmsg-for="DocketDetails[' + i + '].PartDeliveryReasonId" data-valmsg-replace="true"></span>';

            item.DocketNoDatePayBasEdd = item.DocketNo + ' <br/> ' + item.DocketDate + '<br/>' + item.Paybas + '  <br/>  ' + item.EDD + '  <br/>  ' + item.FromLocationCode;
            item.ConsignorConsignee = item.ConsignorName + ' <br/> ' + item.ConsigneeName;
            item.Packages = item.BookedPackages + ' <br/> ' + item.ArrivedPackages + ' <br/> ' + item.PendingPackages + ' <br/> ' + item.DeliveredPackages;
            item.DeliveryDatePersonRemark = item.PersonName + ' <br/> ' + item.Remark + ' <br/> ' + item.DeliveryDate
            item.DeliveryReason = item.LateDeliveryReason + ' ' + item.UnDeliveryReason + ' ' + item.PartDeliveryReason;
        });
        dtDocketDetails.dtAddData(result.DrsDocketList);
        var $span = $('#spnDocketDetails');
        $span.find('th').wrapInner('<td />').contents().unwrap();

        var txtHeaderDeliveryDateTime = dtDocketDetails.find('[id*="txtHeaderDeliveryDateTime"]');
        var txtHeaderPersonName = dtDocketDetails.find('[id*="txtHeaderPersonName"]');
        var txtHeaderRemarks = dtDocketDetails.find('[id*="txtHeaderRemarks"]');
        InitDateTimePicker(txtHeaderDeliveryDateTime.Id, false, true, false, currentDate, dateTimeFormat, '', '');

        txtHeaderPersonName.blur(function () {
            $('[id*="txtPersonName"]').val($(this).val())
        });

        txtHeaderRemarks.blur(function () {
            $('[id*="txtRemark"]').val($(this).val())
        });

        txtHeaderDeliveryDateTime.blur(function () {
            $('[id*="txtDeliveryDate"]').val($(this).val())
        });

        ddlHeaderLateDeliveryReasonId.change(function () {
            $('[id*="ddlLateDeliveryReasonId"]').val($(this).val())
        });

        ddlHeaderPartDeliveryReasonId.change(function () {
            $('[id*="ddlPartDeliveryReasonId"]').val($(this).val())
        });

        ddlHeaderUnDeliveryReasonId.change(function () {
            $('[id*="ddlUndeliveredReasonId"]').val($(this).val())
        });


        $("#dtDocketDetails tr:not(:first)").each(function () {
            var ddlLateDeliveryReasonId = $(this).find('[id*="ddlLateDeliveryReasonId"]');
            var ddlPartDeliveryReasonId = $(this).find('[id*="ddlPartDeliveryReasonId"]');
            var ddlUndeliveredReasonId = $(this).find('[id*="ddlUndeliveredReasonId"]');
            var txtDeliveryDate = $(this).find('[id*="txtDeliveryDate"]');
            var txtPersonName = $(this).find('[id*="txtPersonName"]');
            var txtDeliveredPackages = $(this).find('[id*="txtDeliveredPackages"]');
            var txtRemark = $(this).find('[id*="txtRemark"]');
            var hdnPendingPackages = $(this).find('[id*="hdnPendingPackages"]');
            var dvLateDeliveryReason = $(this).find('[id*="dvLateDeliveryReason"]');

            InitDateTimePicker(txtDeliveryDate.Id, false, true, false, currentDate, dateTimeFormat, '', '');

            BindDeliveryReason(ddlLateDeliveryReasonId, lateDeliveryReasonList, 'Late');
            BindDeliveryReason(ddlPartDeliveryReasonId, partDeliveryReasonList, 'Part');
            BindDeliveryReason(ddlUndeliveredReasonId, unDeliveryReasonList, 'Un');
            CountPendingPackages(txtDeliveredPackages);
            AddRange(txtDeliveredPackages, 'Deliver Packages must be less than to Pending Packages', 0, parseInt(hdnPendingPackages.val()));
            txtDeliveredPackages.blur(function () { CountPendingPackages(txtDeliveredPackages) });
            txtDeliveryDate.blur(function () { CountPendingPackages(txtDeliveredPackages) });
            AddRequired(txtPersonName, 'Please enter Person Name');
            AddRequired(txtDeliveredPackages, 'Please enter Delivered Packages');
            AddRequired(txtRemark, 'Please enter Remark');
            AddRequired(txtDeliveryDate, 'Please select Delivery Date');
        });
    }, ErrorFunction, false);
    return false;
}

function BindDeliveryReason(ddl, list, caption) {
    BindDropDownList(ddl.Id, list, 'Value', 'Name', '', caption + ' Delivery Reason')
    ddl.val('');
}



function CountPendingPackages(obj) {
    txtDeliveredPackages = obj;
    var txtPendingPackages = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'txtPendingPackages'));
    var hdnPendingPackages = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'hdnPendingPackages'));
    var ddlPartDeliveryReasonId = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'ddlPartDeliveryReasonId'));
    var ddlUndeliveredReasonId = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'ddlUndeliveredReasonId'));
    var txtEDD = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'txtEDD'));
    var txtDeliveryDate = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'txtDeliveryDate'));
    var ddlLateDeliveryReasonId = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'ddlLateDeliveryReasonId'));
    var dvLateDeliveryReason = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'dvLateDeliveryReason'));
    var dvPartDeliveryReason = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'dvPartDeliveryReason'));
    var dvUnDeliveryReason = $('#' + txtDeliveredPackages.Id.replace('txtDeliveredPackages', 'dvUnDeliveryReason'));

    var arrivedPackages = parseInt(hdnPendingPackages.val());
    var deliveredPackages = parseInt(txtDeliveredPackages.val());

    if (deliveredPackages > arrivedPackages) {
        txtDeliveredPackages.val(arrivedPackages);
        ShowMessage('Delivered Packages cannot be more than Pending Packages');
        txtDeliveredPackages.focus();
        return false;
    }
    var pendingPackages = arrivedPackages - deliveredPackages;

    var isPartDelivery = false;
    if (deliveredPackages > 0 && pendingPackages > 0)
        isPartDelivery = true;

    ddlPartDeliveryReasonId.val('').enable(isPartDelivery);
    dvPartDeliveryReason.showHide(isPartDelivery);

    ddlUndeliveredReasonId.val('').enable(deliveredPackages == 0);
    dvUnDeliveryReason.showHide(deliveredPackages == 0);

    if (pendingPackages > 0)
        AddRequired(ddlPartDeliveryReasonId, 'Please select Part Delivery Reason');
    else
        RemoveRequired(ddlPartDeliveryReasonId);

    if (deliveredPackages == 0)
        AddRequired(ddlUndeliveredReasonId, 'Please select Un Delivery Reason');
    else
        RemoveRequired(ddlUndeliveredReasonId);

    var isLateDelivery = false;
    if (txtDeliveryDate.val() != '')
        isLateDelivery = $.displayDateToDate(txtEDD.val()) < txtDeliveryDate.toDate();

    dvLateDeliveryReason.showHide(isLateDelivery);

    if (isLateDelivery)
        AddRequired(ddlLateDeliveryReasonId, 'Please select Late Delivery Reason');
    else
        RemoveRequired(ddlLateDeliveryReasonId);

    ddlLateDeliveryReasonId.enable(isLateDelivery);
    ddlLateDeliveryReasonId.val('');

    txtPendingPackages.val(pendingPackages);
}

function ValidateOnSubmit() {
    $('[id*="txtDeliveryDate"]').each(function () {
        var txtDeliveryDate = $(this);
        if (ValidateModuleDateWithPreviousModuleDate('lblDrsDate', txtDeliveryDate.Id, 'Delivery Date')) {
            txtDeliveryDate.val('');
            txtDeliveryDate.focus();
            isStepValid = false;
            return false;
        }
    });

 
}

