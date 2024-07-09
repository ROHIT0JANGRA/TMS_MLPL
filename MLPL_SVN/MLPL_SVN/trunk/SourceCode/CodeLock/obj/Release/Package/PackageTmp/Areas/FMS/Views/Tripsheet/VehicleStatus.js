$(document).ready(function () {
    SetPageLoad("Vehicle", 'Vehicle Update');
    InitObjects();
    AttachEvents();
    VehicleAutoCompleteForStatus('txtVehicleNo', 'hdnVehicleId');
        
});


function InitObjects() {
    txtVehicleNo = $('#txtVehicleNo'); hdnVehicleId = $('#hdnVehicleId'); divStatus = $('#divStatus'); divStatusReason = $('#divStatusReason'); ddlVehicleStatus = $('#ddlVehicleStatus'); ddlStatusReason = $('#ddlStatusReason');
    divLocation = $('#divLocation'); txtVehicleLocation = $('#txtVehicleLocation'); divRemandDate = $('#divRemandDate'); txtVehRemarks = $('#txtVehRemarks'); txtVehStatusDateTime = $('#txtVehStatusDateTime');
    txtDriverName = $('#txtDriverName'); txtDriverMobNo = $('#txtDriverMobNo'); divSupervisor = $('#divSupervisor'); txtSupervisorName = $('#txtSupervisorName'); txtSupervisorMobNo = $('#txtSupervisorMobNo');
  };

function AttachEvents() {
    txtVehicleNo.blur(function () { IsVehicleNoExist(txtVehicleNo, hdnVehicleId); OnVehiclechange() });
    //txtVehicleNo.blur(OnVehiclechange);
    ddlVehicleStatus.change(function () { OnVehicleStatusChange(); });
}
;
function OnVehiclechange() {
    
    if (txtVehicleNo.val() != '') {
        //Now call function to check vehicle status as per tripsheet and current vehicle status table.
        CheckVehicleStatus();
        $("#divStatus").css("display", "block");
        $("#divRemandDate").css("display", "block");
        $("#divSupervisor").css("display", "block");
        if (ddlVehicleStatus.val() == '2') {
            $("#divStatusReason").css("display", "block");
            $("#divLocation").css("display", "block");
                       
        }
        else
        {
            
            /*$("#divStatusReason").css("display", "none");
            $("#divLocation").css("display", "none");
            ddlStatusReason.val('');
            txtVehicleLocation.val('');*/
            $("#divStatusReason").css("display", "block");
            $("#divLocation").css("display", "block");
        }
       
        
    }
    else
    {
        $("#divStatus").css("display", "none");
        $("#divStatusReason").css("display", "none");
        $("#divLocation").css("display", "none");
        $("#divRemandDate").css("display", "none");
        $("#divSupervisor").css("display", "none");
        ddlVehicleStatus.val('');
        ddlStatusReason.val('');
        txtVehicleLocation.val('');
        txtVehRemarks.val('');
        txtDriverName.val('');
        txtDriverMobNo.val('');
        txtSupervisorName.val('');
        txtSupervisorMobNo.val('');
    }
}




function OnVehicleStatusChange() {

    if (txtVehicleNo.val() != '') {
        if (ddlVehicleStatus.val() == '2') {
            $("#divStatusReason").css("display", "block");
            $("#divLocation").css("display", "block");
            var requestData = { VehicleStatus: $('#ddlVehicleStatus').val() };
            AjaxRequestWithPostAndJson(baseUrl + '/GetStatusReason', JSON.stringify(requestData), function (responseData) {
                BindDropDownList('ddlStatusReason', responseData, 'Value', 'Name', '', 'Select');
                }, ErrorFunction, false);
        }
        else {
            
            $("#divStatusReason").css("display", "block");
            $("#divLocation").css("display", "block");
            if (ddlVehicleStatus.val() == '1') {
                var requestData = { VehicleStatus: $('#ddlVehicleStatus').val() };
                AjaxRequestWithPostAndJson(baseUrl + '/GetStatusReason', JSON.stringify(requestData), function (responseData) {
                    BindDropDownList('ddlStatusReason', responseData, 'Value', 'Name', '', 'Select');
                    }, ErrorFunction, false);
            }
            /*$("#divStatusReason").css("display", "none");
            $("#divLocation").css("display", "none");
            ddlStatusReason.val('');
            txtVehicleLocation.val('');*/
            
        }
       
    }
    else {
        $("#divStatus").css("display", "none");
        $("#divStatusReason").css("display", "none");
        $("#divLocation").css("display", "none");
        ddlVehicleStatus.val('');
        ddlStatusReason.val('');
        txtVehicleLocation.val('');
        txtVehRemarks.val('');
        txtDriverName.val('');
        txtDriverMobNo.val('');
        txtSupervisorName.val('');
        txtSupervisorMobNo.val('');
    }
}


function GetStatusReasonSuccess(responseData) {
    BindDropDownList('divStatusReason', responseData, 'Value', 'Name', '', 'Select');
}

function CheckVehicleStatus() {
    var requestData = { VehicleNo: txtVehicleNo.val() };
    AjaxRequestWithPostAndJson(baseUrl + '/GetVehicleStatus', JSON.stringify(requestData), function (result) {
        ddlVehicleStatus.val(result.VehCurStatus);

        var requestData = { VehicleStatus: $('#ddlVehicleStatus').val() };
        AjaxRequestWithPostAndJson(baseUrl + '/GetStatusReason', JSON.stringify(requestData), function (responseData) {
            BindDropDownList('ddlStatusReason', responseData, 'Value', 'Name', '', 'Select');
        }, ErrorFunction, false);


        txtVehicleLocation.val(result.VehLocation);
        txtVehRemarks.val(result.VehRemarks);
        txtVehStatusDateTime.val($.entryDateTime(result.VehStatusDateTime));

        txtDriverName.val(result.DriverName);
        txtDriverMobNo.val(result.DriverMobNo);
        txtSupervisorName.val(result.SupervisorName);
        txtSupervisorMobNo.val(result.SupervisorMobNo);
        ddlStatusReason.val(result.StatusReason);


        //if (result.VehCurStatus == '2') {
        //    ddlStatusReason.val(result.StatusReason)
        //}
        //else {
        //    ddlStatusReason.val('');
        //}
        
    }, ErrorFunction, false);
    return false;
}