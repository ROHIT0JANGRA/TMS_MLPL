var docketModuleId, prsModuleId, lsModuleId, mfModuleId, thcModuleId, drsModuleId, pfmModuleId, tripsheetModuleId, vrModuleId, docketNomenclature,isLocalStorage, localStoragePath, cloudStoragePath;

var ddlDocumentTypeId, drDocumentDate, ddlLocationId, txtDocumentNo, txtManualDocumentNo, dtDocketDetails, dtThcDetails, trackingUrl, dvDocketDetails, dvThcDetails, dtDrsDetails, dvDrsDetails,
    dtPrsDetails, dvPrsDetails, dvLoadingSheetDetails, dtLoadingSheetDetails, dvTripheetDetails, dtTripsheetDetails, dvManifestDetails, dtManifestDetails, dvPfmDetails, dtPfmDetails,
    dvVrDetails, dtVrDetails, dvDocketTalkDetails, dtDocketTalkDetails;

$(document).ready(function () {
    SetPageLoad('Tracking', 'Document Tracking', '', '', '');
    InitObjects();

    
});

function InitObjects() {
    ddlDocumentTypeId = $('#ddlDocumentTypeId');
    drDocumentDate = InitDateRange('drDocumentDate', DateRange.LastWeek, false);
    ddlLocationId = $('#ddlLocationId');
    txtDocumentNo = $('#txtDocumentNo');
    txtManualDocumentNo = $('#txtManualDocumentNo');
    dvDocketDetails = $('#dvDocketDetails');
    dvThcDetails = $('#dvThcDetails');
    dvDrsDetails = $('#dvDrsDetails');
    dvPrsDetails = $('#dvPrsDetails');
    dvLoadingSheetDetails = $('#dvLoadingSheetDetails');
    dvTripheetDetails = $('#dvTripheetDetails');
    dvManifestDetails = $('#dvManifestDetails');
    dvPfmDetails = $('#dvPfmDetails');
    dvVrDetails = $('#dvVrDetails');
    dvDocketTalkDetails = $('#dvDocketTalkDetails');

    ddlDocumentTypeId.append(new Option("Docket Talk", "257", false, false));

    InitWizard('dvWizard', [
        { StepName: 'Criteria', StepFunction: GetDocumentList },
        { StepName: 'Document List' }
    ], '');
}

function OpenDocketPrint(docketId) {
    var prmList = [{ Name: "DocketId", Value: docketId }];
    var reportInfo = { PrmList: prmList, Name: 'DocketView', Description: 'Docket View' };
    return ShowReport(reportInfo);
}

function OpenDocketOfficePrint(docketId) {
    var prmList = [{ Name: "DocketId", Value: docketId }];
    var reportInfo = { PrmList: prmList, Name: 'DocketView2', Description: 'Docket View' };
    return ShowReport(reportInfo);
}

/*
function GetDocumentList() {
    dvDocketDetails.hide();
    dvPrsDetails.hide();
    dvLoadingSheetDetails.hide();
    dvManifestDetails.hide();
    dvThcDetails.hide();
    dvDrsDetails.hide();
    dvPfmDetails.hide();
    dvTripheetDetails.hide();
    dvVrDetails.hide();
    dvDocketTalkDetails.hide();

    var requestData = { locationId: ddlLocationId.val(), fromDate: drDocumentDate.startDate, toDate: drDocumentDate.endDate, documentNo: txtDocumentNo.val(), manualDocumentNo: txtManualDocumentNo.val() };
    if (ddlDocumentTypeId.val() == docketModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetDocketList', JSON.stringify(requestData), function (result) {

            if (dtDocketDetails == null)
                dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
                    [
                        { title: docketNomenclature, data: 'DocketNo' },
                        { title: 'Booking Date', data: 'DocketDate' },
                        { title: 'EDD', data: 'Edd' },
                        { title: 'Origin', data: 'FromLocation' },
                        { title: 'Destination', data: 'ToLocation' },
                        { title: 'From', data: 'FromCity' },
                        { title: 'To', data: 'ToCity' },
                        { title: 'Mode', data: 'TransportMode' },
                        { title: 'Paybas', data: 'Paybas' },
                        { title: 'Consignor Name', data: 'ConsignorName' },
                        { title: 'Consignee Name', data: 'ConsigneeName' },
                        { title: 'Track ' + docketNomenclature.slice(0, -2), data: 'Track' },
                        { title: 'View Print', data: 'View' }
                    ]);

            dtDocketDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvDocketDetails.show();
                $.each(result, function (i, item) {
                    item.DocketNo = "<input type='hidden' value='" + item.DocketId + "' id='hdnDocketId" + i + "'/>" + item.DocketNo
                    item.DocketStatus = item.DocketStatus + (item.VehicleStatus == null || item.VehicleNo == '' || item.VehicleStatus == '' ? '' : ("<br/> <b>Transit Status :</b> In Vehicle " + item.VehicleNo + " @ " + item.VehicleStatus));
                    item.DocketDate = $.displayDate(item.DocketDate) +
                        "<input type='hidden' value='" + item.DocketStatus + "' id='hdnDocketStatus" + i + "'/>";
                    item.Edd = $.displayDate(item.Edd);
                    item.View = '<button id = "btnView' + i + '" onclick="return ViewReport(' + item.DocketId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span> ' +
                        '</button> <button id = "btnPrint' + i + '" onclick="return OpenDocketPrint(' + item.DocketId + ')" class="btn btn-primary btn-xs dt-edit" title="consignor/consignee Copy">' +
                        '<span class="glyphicon glyphicon-print"></span>' +
                        '</button><button id = "btnOfficePODCopy' + i + '" onclick="return OpenDocketOfficePrint(' + item.DocketId + ')" class="btn btn-primary btn-xs dt-edit" title="Office Copy">' +
                        '<span class="glyphicon glyphicon-print"></span>' +
                        '</button>';
                    item.Track = '<div class="btn-group-ex-container">' +
                        '<div class="btn-group btn-group-xs" >' +
                        '<a href="#" class="btn btn-primary dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-view-list"></i></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a onclick="return ViewPodPfm(' + item.DocketId + ')">PFM / POD</a></li>' +
                        '<li><a onclick="return ViewOperationLifeCycle(' + item.DocketId + ')">Operation Life Cycle</a></li>' +
                        '<li><a onclick="return ViewFinanceLifeCycle(' + item.DocketId + ',\'' + item.DocketSuffix + '\')">Finance Life Cycle</a></li>' +
                        //'<li class="divider"></li>'+
                        //'<li><a href="#">Separated link</a></li>'+
                        '</ul>' +
                        '</div></div>';
                });
                dtDocketDetails.dtAddData(result, null, null, [[12, '10%']]);
                dtDocketDetails.find('tr td:eq(0)').css('max-width', '280px');

                dtDocketDetails.find('tbody > tr').each(function () {
                    var tr = $(this);
                    var trHtml = tr.html();
                    var hdnDocketStatus = tr.find('[id*="hdnDocketStatus"]');
                    var trNewHtml = '<tr><td data-title="Status" colspan="13"><b class="label-bold">Status : </b>' + hdnDocketStatus.val() + '</td><tr>';
                    var trNew = $(trNewHtml);
                    tr.before(trNew);

                    var btnOfficePODCopy = tr.find('[id*="btnOfficePODCopy"]');
                    var request = { moduleId: 1, ruleId: 68 };
                    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(request), function (result) {
                        if (result == "Y") { $("#btnOfficePODCopy").css('display', 'block'); }
                        else { btnOfficePODCopy.css('display', 'none'); }
                    }, ErrorFunction, false);
                });

                //var count = 0;
                //dtDocketDetails.find('tbody > tr').each(function () {
                //    if (count == 0) {
                //        var tr = $(this);
                //        var trNext = tr.next();
                //        var trHtml = tr.html();
                //        var trNextHtml = trNext.html();
                //        tr.html(trNextHtml);
                //        trNext.html(trHtml);
                //        count++;
                //    }
                //    else
                //        count--;
                //});
            }
        }, ErrorFunction, false);

    }
    else if (ddlDocumentTypeId.val() == thcModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetThcList', JSON.stringify(requestData), function (result) {

            if (dtThcDetails == null)
                dtThcDetails = LoadDataTable('dtThcDetails', false, false, false, null, null, [],
                    [
                        { title: 'THC No', data: 'ThcNo' },
                        { title: 'Booking Date', data: 'ThcDate' },
                        { title: 'Manual THC No', data: 'ThcNos' },
                        { title: 'Origin', data: 'FromLocationCode' },
                        { title: 'Destination', data: 'ToLocationCode' },
                        { title: 'Vehicle No', data: 'VehicleNo' },
                        { title: 'THC Status', data: 'ThcStatus' },
                        { title: 'Track ' + docketNomenclature.slice(0, -2), data: 'Track' },
                        { title: 'View', data: 'View' }
                    ]);

            dtThcDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvThcDetails.show();
                $.each(result, function (i, item) {
                    item.ThcNo = "<input type='hidden' value='" + item.ThcId + "' id='hdnThcId" + i + "'/>" + item.ThcNo;
                    item.ThcDate = $.displayDate(item.ThcDate);
                    item.View = '<button id = "btnThcView' + i + '" onclick="return ViewReport(' + item.ThcId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                    item.Track = '<div class="btn-group-ex-container">' +
                        '<div class="btn-group btn-group-xs" >' +
                        '<a href="#" class="btn btn-primary dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-view-list"></i></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a onclick="return ViewOperationalDocumentLifeCycle(' + item.ThcId + ',\'' + 2 + '\')">Finance Life Cycle</a></li>' +
                        //'<li class="divider"></li>'+
                        //'<li><a href="#">Separated link</a></li>'+
                        '</ul>' +
                        '</div></div>';
                });
                dtThcDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == drsModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetDrsList', JSON.stringify(requestData), function (result) {

            if (dtDrsDetails == null)
                dtDrsDetails = LoadDataTable('dtDrsDetails', false, false, false, null, null, [],
                    [
                        { title: 'DRS No', data: 'DrsNo' },
                        { title: 'Manual DRS No', data: 'ManualDrsNo' },
                        { title: 'Location', data: 'LocationCode' },
                        { title: 'DRS Date', data: 'DrsDate' },
                        { title: 'Vehicle No', data: 'VehicleNo' },
                        { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                        { title: 'DRS Status', data: 'DrsStatus' },
                        { title: 'Track ' + docketNomenclature.slice(0, -2), data: 'Track' },
                        { title: 'View', data: 'View' }
                    ]);

            dtDrsDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvDrsDetails.show();
                $.each(result, function (i, item) {
                    item.DrsNo = "<input type='hidden' value='" + item.DrsId + "' id='hdnDrsId" + i + "'/>" + item.DrsNo;
                    item.DrsDate = $.displayDate(item.DrsDate);
                    item.View = '<button id = "btnDrsView' + i + '" onclick="return ViewReport(' + item.DrsId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                    item.Track = '<div class="btn-group-ex-container">' +
                        '<div class="btn-group btn-group-xs" >' +
                        '<a href="#" class="btn btn-primary dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-view-list"></i></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a onclick="return ViewOperationalDocumentLifeCycle(' + item.DrsId + ',\'' + 3 + '\')">Finance Life Cycle</a></li>' +
                        //'<li class="divider"></li>'+
                        //'<li><a href="#">Separated link</a></li>'+
                        '</ul>' +
                        '</div></div>';
                });
                dtDrsDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == prsModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetPrsList', JSON.stringify(requestData), function (result) {

            if (dtPrsDetails == null)
                dtPrsDetails = LoadDataTable('dtPrsDetails', false, false, false, null, null, [],
                    [
                        { title: 'PRS No', data: 'PrsNo' },
                        { title: 'Manual PRS No', data: 'ManualPrsNo' },
                        { title: 'Location', data: 'LocationCode' },
                        { title: 'PRS Date', data: 'PrsDate' },
                        { title: 'Vehicle No', data: 'VehicleNo' },
                        { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                        { title: 'PRS Status', data: 'PrsStatus' },
                        { title: 'Track ' + docketNomenclature.slice(0, -2), data: 'Track' },
                        { title: 'View', data: 'View' }
                    ]);

            dtPrsDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvPrsDetails.show();
                $.each(result, function (i, item) {
                    item.PrsNo = "<input type='hidden' value='" + item.PrsId + "' id='hdnPrsId" + i + "'/>" + item.PrsNo;
                    item.PrsDate = $.displayDate(item.PrsDate);
                    item.View = '<button id = "btnPrsView' + i + '" onclick="return ViewReport(' + item.PrsId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                    item.Track = '<div class="btn-group-ex-container">' +
                        '<div class="btn-group btn-group-xs" >' +
                        '<a href="#" class="btn btn-primary dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-view-list"></i></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a onclick="return ViewOperationalDocumentLifeCycle(' + item.PrsId + ',\'' + 1 + '\')">Finance Life Cycle</a></li>' +
                        //'<li class="divider"></li>'+
                        //'<li><a href="#">Separated link</a></li>'+
                        '</ul>' +
                        '</div></div>';
                });
                dtPrsDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == lsModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetLoadingSheetList', JSON.stringify(requestData), function (result) {

            if (dtLoadingSheetDetails == null)
                dtLoadingSheetDetails = LoadDataTable('dtLoadingSheetDetails', false, false, false, null, null, [],
                    [
                        { title: 'LS No', data: 'LoadingSheetNo' },
                        { title: 'Manual LS No', data: 'ManualLoadingSheetNo' },
                        { title: 'LS Date', data: 'LoadingSheetDate' },
                        { title: 'Origin', data: 'LocationCode' },
                        { title: 'Destination', data: 'NextLocationCode' },
                        { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                        { title: 'LS Status', data: 'LoadingSheetStatus' },
                        { title: 'View', data: 'View' }
                    ]);

            dtLoadingSheetDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvLoadingSheetDetails.show();
                $.each(result, function (i, item) {
                    item.LoadingSheetNo = "<input type='hidden' value='" + item.LoadingSheetId + "' id='hdnLoadingSheetId" + i + "'/>" + item.LoadingSheetNo;
                    item.LoadingSheetDate = $.displayDate(item.LoadingSheetDate);
                    item.View = '<button id = "btnLoadingSheetView' + i + '" onclick="return ViewReport(' + item.LoadingSheetId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtLoadingSheetDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == tripsheetModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetTripsheetList', JSON.stringify(requestData), function (result) {

            if (dtTripsheetDetails == null)
                dtTripsheetDetails = LoadDataTable('dtTripsheetDetails', false, false, false, null, null, [],
                    [
                        { title: 'Tripsheet No', data: 'TripsheetNo' },
                        { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                        { title: 'Tripsheet Date & Time', data: 'TripsheetDateTime' },
                        { title: 'Origin', data: 'StartLocation' },
                        { title: 'Destination', data: 'EndLocation' },
                        { title: 'Category', data: 'Category' },
                        { title: 'Sub Category', data: 'SubCategory' },
                        { title: 'Vehicle No', data: 'VehicleNo' },
                        { title: 'View', data: 'View' }
                    ]);

            dtTripsheetDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvTripheetDetails.show();
                $.each(result, function (i, item) {
                    item.TripsheetNo = "<input type='hidden' value='" + item.TripsheetId + "' id='hdnTripsheetId" + i + "'/>" + item.TripsheetNo;
                    item.TripsheetDateTime = $.displayDateTime(item.TripsheetDateTime);
                    item.SubCategory = item.Category != 2 ? item.SubCategory == 1 ? "Long Haul" : "Milk Run" : item.Category == 2 ? "Own" : "";
                    item.Category = item.Category == 1 ? "External" : item.Category == 2 ? "Internal" : "Leg wise";
                    item.View = '<button id = "btnTripsheetView' + i + '" onclick="return ViewReport(' + item.TripsheetId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtTripsheetDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == mfModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetManifestList', JSON.stringify(requestData), function (result) {

            if (dtManifestDetails == null)
                dtManifestDetails = LoadDataTable('dtManifestDetails', false, false, false, null, null, [],
                    [
                        { title: 'MF No', data: 'ManifestNo' },
                        { title: 'Manual MF No', data: 'ManualManifestNo' },
                        { title: 'MF Date', data: 'ManifestDate' },
                        { title: 'Origin', data: 'LocationCode' },
                        { title: 'Destination', data: 'NextLocationCode' },
                        { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                        { title: 'MF Status', data: 'ManifestStatus' },
                        { title: 'View', data: 'View' }
                    ]);

            dtManifestDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvManifestDetails.show();
                $.each(result, function (i, item) {
                    item.ManifestNo = "<input type='hidden' value='" + item.ManifestId + "' id='hdnManifestId" + i + "'/>" + item.ManifestNo;
                    item.ManifestDate = $.displayDate(item.ManifestDate);
                    item.View = '<button id = "btnManifestView' + i + '" onclick="return ViewReport(' + item.ManifestId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtManifestDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == pfmModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetPfmList', JSON.stringify(requestData), function (result) {

            if (dtPfmDetails == null)
                dtPfmDetails = LoadDataTable('dtPfmDetails', false, false, false, null, null, [],
                    [
                        { title: 'PFM No', data: 'PfmNo' },
                        { title: 'Manual PFM No', data: 'ManualPfmNo' },
                        { title: 'PFM Date', data: 'PfmDate' },
                        { title: 'Location', data: 'LocationCode' },
                        { title: 'Forward To', data: 'ForwardTypeName' },
                        { title: 'Customer/Location', data: 'ForwardTo' },
                        { title: 'View', data: 'View' }
                    ]);

            dtPfmDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvPfmDetails.show();
                $.each(result, function (i, item) {
                    item.PfmNo = "<input type='hidden' value='" + item.PfmId + "' id='hdnPfmId" + i + "'/>" + item.PfmNo;
                    item.PfmDate = $.displayDate(item.PfmDate);
                    item.View = '<button id = "btnPfmView' + i + '" onclick="return ViewReport(' + item.PfmId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtPfmDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == vrModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetVrList', JSON.stringify(requestData), function (result) {

            if (dtVrDetails == null)
                dtVrDetails = LoadDataTable('dtVrDetails', false, false, false, null, null, [],
                    [
                        { title: 'VR No', data: 'VrNo' },
                        { title: 'VR Date', data: 'VrDate' },
                        { title: 'Location', data: 'LocationCode' },
                        { title: 'Customer', data: 'CustomerCode' },
                        { title: 'Status', data: 'UpdateBy' },
                        { title: 'View', data: 'View' }
                    ]);

            dtVrDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvVrDetails.show();
                $.each(result, function (i, item) {
                    item.VrNo = "<input type='hidden' value='" + item.VrId + "' id='hdnVrId" + i + "'/>" + item.VrNo;
                    item.VrDate = $.displayDate(item.VrDate);
                    if (item.IsClose == true) {
                        item.UpdateBy = "Closed";
                    }
                    else if (item.UpdateBy != null) {
                        item.UpdateBy = "Edited";
                    }
                    else {
                        item.UpdateBy = "Pending";
                    };
                    item.View = '<button id = "btnVrView' + i + '" onclick="return ViewReport(' + item.VrId + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtVrDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == docketTalkModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetDocketTalkList', JSON.stringify(requestData), function (result) {

            if (dtDocketTalkDetails == null)
                dtDocketTalkDetails = LoadDataTable('dtDocketTalkDetails', false, false, false, null, null, [],
                    [
                        { title: 'Docket No', data: 'DocketNo' },
                        { title: 'Remarks', data: 'Remarks' },
                        { title: 'Date', data: "EntryDate" },
                        { title: 'Uploded Document', data: 'View' }

                    ]);

            dtDocketTalkDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvDocketTalkDetails.show();
                $.each(result, function (i, item) {
                    item.View = '<a href="#" onclick="return ViewDocketTalkAttachment(\'hdnDocumentName' + i + '\');" class="btckn btn-default btn-sm">' +
                                '<span class="fa fa-download"></span>' +
                            '</a>' +
                    "<input type='hidden' value='" + item.DocumentName + "' id='hdnDocumentName" + i + "'/>";
                    item.EntryDate = item.DocumentName == null ? '' : $.displayDateTime(item.EntryDate);
                });
                dtDocketTalkDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    return false;
}
*/
function GetDocumentList() {
    dvDocketDetails.hide();
    dvPrsDetails.hide();
    dvLoadingSheetDetails.hide();
    dvManifestDetails.hide();
    dvThcDetails.hide();
    dvDrsDetails.hide();
    dvPfmDetails.hide();
    dvTripheetDetails.hide();
    dvVrDetails.hide();
    dvDocketTalkDetails.hide();

    var requestData = { locationId: ddlLocationId.val(), fromDate: drDocumentDate.startDate, toDate: drDocumentDate.endDate, documentNo: txtDocumentNo.val(), manualDocumentNo: txtManualDocumentNo.val() };
    if (ddlDocumentTypeId.val() == docketModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetDocketList', JSON.stringify(requestData), function (result) {

            if (dtDocketDetails == null)
                dtDocketDetails = LoadDataTable('dtDocketDetails', false, false, false, null, null, [],
                    [
                        { title: docketNomenclature, data: 'DocketNo' },
                        { title: 'Booking Date', data: 'DocketDate' },
                        { title: 'EDD', data: 'Edd' },
                        { title: 'Origin', data: 'FromLocation' },
                        { title: 'Destination', data: 'ToLocation' },
                        { title: 'From', data: 'FromCity' },
                        { title: 'To', data: 'ToCity' },
                        { title: 'Mode', data: 'TransportMode' },
                        { title: 'Paybas', data: 'Paybas' },
                        { title: 'Consignor Name', data: 'ConsignorName' },
                        { title: 'Consignee Name', data: 'ConsigneeName' },
                        { title: 'Track ' + docketNomenclature.slice(0, -2), data: 'Track' },
                        { title: 'View Print', data: 'View' }
                    ]);

            dtDocketDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvDocketDetails.show();
                $.each(result, function (i, item) {
                    item.DocketNo = "<input type='hidden' value='" + item.DocketId + "' id='hdnDocketId" + i + "'/>" + item.DocketNo
                    item.DocketStatus = item.DocketStatus + (item.VehicleStatus == null || item.VehicleNo == '' || item.VehicleStatus == '' ? '' : ("<br/> <b>Transit Status :</b> In Vehicle " + item.VehicleNo + " @ " + item.VehicleStatus));
                    item.DocketDate = $.displayDate(item.DocketDate) +
                        "<input type='hidden' value='" + item.DocketStatus + "' id='hdnDocketStatus" + i + "'/>";
                    item.Edd = $.displayDate(item.Edd);
                    item.View = '<button id = "btnView' + i + '" onclick="return ViewReport(' + item.DocketId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span> ' +
                        '</button> <button id = "btnPrint' + i + '" onclick="return OpenDocketPrint(' + item.DocketId + ')" class="btn btn-primary btn-xs dt-edit" title="consignor/consignee Copy">' +
                        '<span class="glyphicon glyphicon-print"></span>' +
                        '</button> <button id = "btnPrint' + i + '" onclick="return OpenDocketMyntraPrint(' + item.DocketId + ')" class="btn btn-primary btn-xs dt-edit" title="For Myntra Only">' +
                        '<span class="glyphicon glyphicon-hand-up"></span>' +
                        '</button><button id = "btnOfficePODCopy' + i + '" onclick="return OpenDocketOfficePrint(' + item.DocketId + ')" class="btn btn-primary btn-xs dt-edit" title="Office Copy">' +
                        '<span class="glyphicon glyphicon-print"></span>' +
                        '</button> &nbsp; <a href="#" onclick="javascript:ViewHistory(' + item.DocketId + ');">DEPS</a>';
                    item.Track = '<div class="btn-group-ex-container">' +
                        '<div class="btn-group btn-group-xs" >' +
                        '<a href="#" class="btn btn-primary dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-view-list"></i></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a onclick="return ViewPodPfm(' + item.DocketId + ')">PFM / POD</a></li>' +
                        '<li><a onclick="return ViewOperationLifeCycle(' + item.DocketId + ')">Operation Life Cycle</a></li>' +
                        '<li><a onclick="return ViewFinanceLifeCycle(' + item.DocketId + ',\'' + item.DocketSuffix + '\')">Finance Life Cycle</a></li>' +
                        //'<li class="divider"></li>'+
                        //'<li><a href="#">Separated link</a></li>'+
                        '</ul>' +
                        '</div></div>';
                });
                dtDocketDetails.dtAddData(result, null, null, [[12, '10%']]);
                dtDocketDetails.find('tr td:eq(0)').css('max-width', '280px');

                dtDocketDetails.find('tbody > tr').each(function () {
                    var tr = $(this);
                    var trHtml = tr.html();
                    var hdnDocketStatus = tr.find('[id*="hdnDocketStatus"]');
                    var trNewHtml = '<tr><td data-title="Status" colspan="13"><b class="label-bold">Status : </b>' + hdnDocketStatus.val() + '</td><tr>';
                    var trNew = $(trNewHtml);
                    tr.before(trNew);

                    var btnOfficePODCopy = tr.find('[id*="btnOfficePODCopy"]');
                    var request = { moduleId: 1, ruleId: 68 };
                    AjaxRequestWithPostAndJson(ruleMasterUrl + '/GetModuleRuleByIdAndRuleId', JSON.stringify(request), function (result) {
                        if (result == "Y") { $("#btnOfficePODCopy").css('display', 'block'); }
                        else { btnOfficePODCopy.css('display', 'none'); }
                    }, ErrorFunction, false);
                });

                //var count = 0;
                //dtDocketDetails.find('tbody > tr').each(function () {
                //    if (count == 0) {
                //        var tr = $(this);
                //        var trNext = tr.next();
                //        var trHtml = tr.html();
                //        var trNextHtml = trNext.html();
                //        tr.html(trNextHtml);
                //        trNext.html(trHtml);
                //        count++;
                //    }
                //    else
                //        count--;
                //});
            }
        }, ErrorFunction, false);

    }
    else if (ddlDocumentTypeId.val() == thcModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetThcList', JSON.stringify(requestData), function (result) {

            if (dtThcDetails == null)
                dtThcDetails = LoadDataTable('dtThcDetails', false, false, false, null, null, [],
                    [
                        { title: 'THC No', data: 'ThcNo' },
                        { title: 'Booking Date', data: 'ThcDate' },
                        { title: 'Manual THC No', data: 'ThcNos' },
                        { title: 'Origin', data: 'FromLocationCode' },
                        { title: 'Destination', data: 'ToLocationCode' },
                        { title: 'Vehicle No', data: 'VehicleNo' },
                        { title: 'THC Status', data: 'ThcStatus' },
                        { title: 'Track ' + docketNomenclature.slice(0, -2), data: 'Track' },
                        { title: 'View', data: 'View' }
                    ]);

            dtThcDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvThcDetails.show();
                $.each(result, function (i, item) {
                    item.ThcNo = "<input type='hidden' value='" + item.ThcId + "' id='hdnThcId" + i + "'/>" + item.ThcNo;
                    item.ThcDate = $.displayDate(item.ThcDate);
                    item.View = '<button id = "btnThcView' + i + '" onclick="return ViewReport(' + item.ThcId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                    item.Track = '<div class="btn-group-ex-container">' +
                        '<div class="btn-group btn-group-xs" >' +
                        '<a href="#" class="btn btn-primary dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-view-list"></i></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a onclick="return ViewOperationalDocumentLifeCycle(' + item.ThcId + ',\'' + 2 + '\')">Finance Life Cycle</a></li>' +
                        //'<li class="divider"></li>'+
                        //'<li><a href="#">Separated link</a></li>'+
                        '</ul>' +
                        '</div></div>';
                });
                dtThcDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == drsModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetDrsList', JSON.stringify(requestData), function (result) {

            if (dtDrsDetails == null)
                dtDrsDetails = LoadDataTable('dtDrsDetails', false, false, false, null, null, [],
                    [
                        { title: 'DRS No', data: 'DrsNo' },
                        { title: 'Manual DRS No', data: 'ManualDrsNo' },
                        { title: 'Location', data: 'LocationCode' },
                        { title: 'DRS Date', data: 'DrsDate' },
                        { title: 'Vehicle No', data: 'VehicleNo' },
                        { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                        { title: 'DRS Status', data: 'DrsStatus' },
                        { title: 'Track ' + docketNomenclature.slice(0, -2), data: 'Track' },
                        { title: 'View', data: 'View' }
                    ]);

            dtDrsDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvDrsDetails.show();
                $.each(result, function (i, item) {
                    item.DrsNo = "<input type='hidden' value='" + item.DrsId + "' id='hdnDrsId" + i + "'/>" + item.DrsNo;
                    item.DrsDate = $.displayDate(item.DrsDate);
                    item.View = '<button id = "btnDrsView' + i + '" onclick="return ViewReport(' + item.DrsId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                    item.Track = '<div class="btn-group-ex-container">' +
                        '<div class="btn-group btn-group-xs" >' +
                        '<a href="#" class="btn btn-primary dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-view-list"></i></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a onclick="return ViewOperationalDocumentLifeCycle(' + item.DrsId + ',\'' + 3 + '\')">Finance Life Cycle</a></li>' +
                        //'<li class="divider"></li>'+
                        //'<li><a href="#">Separated link</a></li>'+
                        '</ul>' +
                        '</div></div>';
                });
                dtDrsDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == prsModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetPrsList', JSON.stringify(requestData), function (result) {

            if (dtPrsDetails == null)
                dtPrsDetails = LoadDataTable('dtPrsDetails', false, false, false, null, null, [],
                    [
                        { title: 'PRS No', data: 'PrsNo' },
                        { title: 'Manual PRS No', data: 'ManualPrsNo' },
                        { title: 'Location', data: 'LocationCode' },
                        { title: 'PRS Date', data: 'PrsDate' },
                        { title: 'Vehicle No', data: 'VehicleNo' },
                        { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                        { title: 'PRS Status', data: 'PrsStatus' },
                        { title: 'Track ' + docketNomenclature.slice(0, -2), data: 'Track' },
                        { title: 'View', data: 'View' }
                    ]);

            dtPrsDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvPrsDetails.show();
                $.each(result, function (i, item) {
                    item.PrsNo = "<input type='hidden' value='" + item.PrsId + "' id='hdnPrsId" + i + "'/>" + item.PrsNo;
                    item.PrsDate = $.displayDate(item.PrsDate);
                    item.View = '<button id = "btnPrsView' + i + '" onclick="return ViewReport(' + item.PrsId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                    item.Track = '<div class="btn-group-ex-container">' +
                        '<div class="btn-group btn-group-xs" >' +
                        '<a href="#" class="btn btn-primary dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-view-list"></i></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a onclick="return ViewOperationalDocumentLifeCycle(' + item.PrsId + ',\'' + 1 + '\')">Finance Life Cycle</a></li>' +
                        //'<li class="divider"></li>'+
                        //'<li><a href="#">Separated link</a></li>'+
                        '</ul>' +
                        '</div></div>';
                });
                dtPrsDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == lsModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetLoadingSheetList', JSON.stringify(requestData), function (result) {

            if (dtLoadingSheetDetails == null)
                dtLoadingSheetDetails = LoadDataTable('dtLoadingSheetDetails', false, false, false, null, null, [],
                    [
                        { title: 'LS No', data: 'LoadingSheetNo' },
                        { title: 'Manual LS No', data: 'ManualLoadingSheetNo' },
                        { title: 'LS Date', data: 'LoadingSheetDate' },
                        { title: 'Origin', data: 'LocationCode' },
                        { title: 'Destination', data: 'NextLocationCode' },
                        { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                        { title: 'LS Status', data: 'LoadingSheetStatus' },
                        { title: 'View', data: 'View' }
                    ]);

            dtLoadingSheetDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvLoadingSheetDetails.show();
                $.each(result, function (i, item) {
                    item.LoadingSheetNo = "<input type='hidden' value='" + item.LoadingSheetId + "' id='hdnLoadingSheetId" + i + "'/>" + item.LoadingSheetNo;
                    item.LoadingSheetDate = $.displayDate(item.LoadingSheetDate);
                    item.View = '<button id = "btnLoadingSheetView' + i + '" onclick="return ViewReport(' + item.LoadingSheetId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtLoadingSheetDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == tripsheetModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetTripsheetList', JSON.stringify(requestData), function (result) {

            if (dtTripsheetDetails == null)
                dtTripsheetDetails = LoadDataTable('dtTripsheetDetails', false, false, false, null, null, [],
                    [
                        { title: 'Tripsheet No', data: 'TripsheetNo' },
                        { title: 'Manual Tripsheet No', data: 'ManualTripsheetNo' },
                        { title: 'Tripsheet Date & Time', data: 'TripsheetDateTime' },
                        { title: 'Origin', data: 'StartLocation' },
                        { title: 'Destination', data: 'EndLocation' },
                        { title: 'Category', data: 'Category' },
                        { title: 'Sub Category', data: 'SubCategory' },
                        { title: 'Vehicle No', data: 'VehicleNo' },
                        { title: 'View', data: 'View' }
                    ]);

            dtTripsheetDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvTripheetDetails.show();
                $.each(result, function (i, item) {
                    item.TripsheetNo = "<input type='hidden' value='" + item.TripsheetId + "' id='hdnTripsheetId" + i + "'/>" + item.TripsheetNo;
                    item.TripsheetDateTime = $.displayDateTime(item.TripsheetDateTime);
                    item.SubCategory = item.Category != 2 ? item.SubCategory == 1 ? "Long Haul" : "Milk Run" : item.Category == 2 ? "Own" : "";
                    item.Category = item.Category == 1 ? "External" : item.Category == 2 ? "Internal" : "Leg wise";
                    item.View = '<button id = "btnTripsheetView' + i + '" onclick="return ViewReport(' + item.TripsheetId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtTripsheetDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == mfModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetManifestList', JSON.stringify(requestData), function (result) {

            if (dtManifestDetails == null)
                dtManifestDetails = LoadDataTable('dtManifestDetails', false, false, false, null, null, [],
                    [
                        { title: 'MF No', data: 'ManifestNo' },
                        { title: 'Manual MF No', data: 'ManualManifestNo' },
                        { title: 'MF Date', data: 'ManifestDate' },
                        { title: 'Origin', data: 'LocationCode' },
                        { title: 'Destination', data: 'NextLocationCode' },
                        { title: 'Total ' + docketNomenclature + 's', data: 'TotalDocket' },
                        { title: 'MF Status', data: 'ManifestStatus' },
                        { title: 'View', data: 'View' }
                    ]);

            dtManifestDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvManifestDetails.show();
                $.each(result, function (i, item) {
                    item.ManifestNo = "<input type='hidden' value='" + item.ManifestId + "' id='hdnManifestId" + i + "'/>" + item.ManifestNo;
                    item.ManifestDate = $.displayDate(item.ManifestDate);
                    item.View = '<button id = "btnManifestView' + i + '" onclick="return ViewReport(' + item.ManifestId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtManifestDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == pfmModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetPfmList', JSON.stringify(requestData), function (result) {

            if (dtPfmDetails == null)
                dtPfmDetails = LoadDataTable('dtPfmDetails', false, false, false, null, null, [],
                    [
                        { title: 'PFM No', data: 'PfmNo' },
                        { title: 'Manual PFM No', data: 'ManualPfmNo' },
                        { title: 'PFM Date', data: 'PfmDate' },
                        { title: 'Location', data: 'LocationCode' },
                        { title: 'Forward To', data: 'ForwardTypeName' },
                        { title: 'Customer/Location', data: 'ForwardTo' },
                        { title: 'View', data: 'View' }
                    ]);

            dtPfmDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvPfmDetails.show();
                $.each(result, function (i, item) {
                    item.PfmNo = "<input type='hidden' value='" + item.PfmId + "' id='hdnPfmId" + i + "'/>" + item.PfmNo;
                    item.PfmDate = $.displayDate(item.PfmDate);
                    item.View = '<button id = "btnPfmView' + i + '" onclick="return ViewReport(' + item.PfmId + ',' + ddlDocumentTypeId.val() + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtPfmDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == vrModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetVrList', JSON.stringify(requestData), function (result) {

            if (dtVrDetails == null)
                dtVrDetails = LoadDataTable('dtVrDetails', false, false, false, null, null, [],
                    [
                        { title: 'VR No', data: 'VrNo' },
                        { title: 'VR Date', data: 'VrDate' },
                        { title: 'Location', data: 'LocationCode' },
                        { title: 'Customer', data: 'CustomerCode' },
                        { title: 'Status', data: 'UpdateBy' },
                        { title: 'View', data: 'View' }
                    ]);

            dtVrDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvVrDetails.show();
                $.each(result, function (i, item) {
                    item.VrNo = "<input type='hidden' value='" + item.VrId + "' id='hdnVrId" + i + "'/>" + item.VrNo;
                    item.VrDate = $.displayDate(item.VrDate);
                    if (item.IsClose == true) {
                        item.UpdateBy = "Closed";
                    }
                    else if (item.UpdateBy != null) {
                        item.UpdateBy = "Edited";
                    }
                    else {
                        item.UpdateBy = "Pending";
                    };
                    item.View = '<button id = "btnVrView' + i + '" onclick="return ViewReport(' + item.VrId + ')" class="btn btn-primary btn-xs dt-edit">' +
                        '<span class="glyphicon glyphicon-eye-open"></span>' +
                        '</button>';
                });
                dtVrDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    else if (ddlDocumentTypeId.val() == docketTalkModuleId) {
        AjaxRequestWithPostAndJson(trackingUrl + '/GetDocketTalkList', JSON.stringify(requestData), function (result) {

            if (dtDocketTalkDetails == null)
                dtDocketTalkDetails = LoadDataTable('dtDocketTalkDetails', false, false, false, null, null, [],
                    [
                        { title: 'Docket No', data: 'DocketNo' },
                        { title: 'Remarks', data: 'Remarks' },
                        { title: 'Date', data: "EntryDate" },
                        { title: 'Uploded Document', data: 'View' }

                    ]);

            dtDocketTalkDetails.fnClearTable();

            if (result.length == 0) {
                isStepValid = false;
                ShowMessage('No Record Found');
                return false;
            }
            else {
                dvDocketTalkDetails.show();
                $.each(result, function (i, item) {
                    item.View = '<a href="#" onclick="return ViewDocketTalkAttachment(\'hdnDocumentName' + i + '\');" class="btckn btn-default btn-sm">' +
                                '<span class="fa fa-download"></span>' +
                            '</a>' +
                    "<input type='hidden' value='" + item.DocumentName + "' id='hdnDocumentName" + i + "'/>";
                    item.EntryDate = item.DocumentName == null ? '' : $.displayDateTime(item.EntryDate);
                });
                dtDocketTalkDetails.dtAddData(result);
            }
        }, ErrorFunction, false);
    }
    return false;
}

function OpenDocketMyntraPrint(docketId) {
    var prmList = [{ Name: "DocketId", Value: docketId }];
    var reportInfo = { PrmList: prmList, Name: 'DocketViewTrispeedMyntra', Description: 'Docket View' };
    return ShowReport(reportInfo);
}

function ViewReport(value, type) {
    ShowViewPrint(type, value);
    return false;
}

function ViewPodPfm(value) {
    var prmList = [{ Name: "DocketId", Value: value }];
    var reportInfo = { PrmList: prmList, Name: 'TrackPodPfm', Description: 'Track POD/PFM' };
    return ShowReport(reportInfo);
}

function ViewOperationLifeCycle(value) {
    var prmList = [{ Name: "DocketId", Value: value }];
    var reportInfo = { PrmList: prmList, Name: 'OperationLifeCycleDocket', Description: 'Operation Life Cycle' };
    return ShowReport(reportInfo);
}

function ViewFinanceLifeCycle(docketId, docketsuffix) {
    var prmList = [{ Name: "DocketId", Value: docketId }, { Name: "DocketSuffix", Value: docketsuffix }];
    var reportInfo = { PrmList: prmList, Name: 'FinanceLifeCycle_ViewPrint', Description: 'Finance Life Cycle' };
    return ShowReport(reportInfo);
}

function ViewOperationalDocumentLifeCycle(documentId, documentType) {
    var prmList = [{ Name: "DocumentId", Value: documentId }, { Name: "DocumentType", Value: documentType }];
    var reportInfo = { PrmList: prmList, Name: 'OperationalDocumentLifeCycle_ViewPrint', Description: 'Operational Document Life Cycle' };
    return ShowReport(reportInfo);
}
function ViewDocketTalkAttachment(obj) {
    var hdnDocumentName = $('#' + obj);
    var filePath = '';
    if (isLocalStorage == 'True')
        filePath = localStoragePath + "DocketTalk/";
    else
        filePath = cloudStoragePath;
    window.open(filePath + hdnDocumentName.val(), "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=100,left=500,width=400,height=300");
    return false;
}


function ViewHistory(value) {
    $.ajax({
        type: "POST",
        url: sepdUrl + '/GetDepsDocketHistory',
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
