$(window).load(function () {
    $(".page_loader").fadeOut();
});
//$(document).ajaxStart(function () {
//    $(".page_loader").fadeIn();
//});
$(document).ajaxStop(function () {
    $(".page_loader").fadeOut();
});
$(document).ajaxError(function () {
    $(".page_loader").fadeOut();
});

function ShowLoader() {
    $('#dvLoader').show();
}

function HideLoader() {
    $('#dvLoader').hide();
}

function SetPageLoad(header, subHeader, firstFieldId, navigation1Text, navigation1Url, navigation2Text, navigation2Url, navigation3Text, navigation3Url, navigation4Text, navigation4Url) {
    SetPageHeader(header, subHeader);

    if (firstFieldId != null && firstFieldId != undefined && firstFieldId != '')
        SetFormFieldFocus(firstFieldId);

    if (navigation1Text != null && navigation1Text != undefined && navigation1Text != '') {
        $('#aNavigation1').append(navigation1Text).attr('href', navigation1Url.replace('&amp;', '&'));
        $('#aNavigation1').parent().parent().parent().removeClass('hide');
    }
    else
        $('#aNavigation1').hide();

    if (navigation2Text != null && navigation2Text != undefined && navigation2Text != '')
        $('#aNavigation2').append(navigation2Text).attr('href', navigation2Url.replace('&amp;', '&'));
    else
        $('#aNavigation2').hide();

    if (navigation3Text != null && navigation3Text != undefined && navigation3Text != '')
        $('#aNavigation3').append(navigation3Text).attr('href', navigation3Url.replace('&amp;', '&'));
    else
        $('#aNavigation3').hide();

    if (navigation4Text != null && navigation4Text != undefined && navigation4Text != '')
        $('#aNavigation4').append(navigation4Text).attr('href', navigation4Url.replace('&amp;', '&'));
    else
        $('#aNavigation4').hide();
}

function SetPageHeader(header, subHeader) {
    $('#lblPageHeader').text(header);
    if (subHeader != null && subHeader != undefined)
        $('#lblPageSubHeader').text(subHeader);
    document.title = header + ' ' + subHeader;
}

function SetFormFieldFocus(objId) {
    $('#' + objId).focus();
}

function SetFieldFocus(container) {
    var elements = container.find(':text,:radio,:checkbox,select,textarea').filter(function () {
        return !this.readOnly &&
            !this.disabled &&
            $(this).parentsUntil('form', 'div.row').css('display') != "none";
    });
    if (elements.length > 0)
        SetFormFieldFocus(elements[0].Id);
}

function ShowMessage(message, objFocus) {
    $.confirm({
        icon: 'fa fa-warning',
        title: 'Alert!',
        content: message,

        closeIcon: true,
        closeIconClass: 'fa fa-close',
        buttons: {
            OK: {
                text: 'OK',
                keys: ['enter', 'esc'],
                action: function () {
                    if (!IsObjectNullOrEmpty(objFocus))
                        objFocus.val('').focus();
                }
            }
        },
        onClose: function () {
            if (!IsObjectNullOrEmpty(objFocus)) {
                objFocus.val('').focus();
            }
        }
    });
    return false;
}

function InitDateTimePicker(objId, allowFutureDateTime, allowPastDateTime, setBlank, defaultDateTime, dateTimeFormat, minDate, maxDate, isValidateFinYear, isDateOnly, isTimeOnly) {
    var currentDateTime = moment(systemDateTime, dateTimeFormat);
    isValidateFinYear = (IsObjectNullOrEmpty(isValidateFinYear)) ? true : isValidateFinYear;
    isDateOnly = (IsObjectNullOrEmpty(isDateOnly)) ? true : isDateOnly;
    isTimeOnly = (IsObjectNullOrEmpty(isTimeOnly)) ? false : isTimeOnly;
    minDate = (IsObjectNullOrEmpty(minDate)) ? currentDateTime : moment(minDate, dateTimeFormat);
    maxDate = (IsObjectNullOrEmpty(maxDate)) ? currentDateTime : moment(maxDate, dateTimeFormat);

    if (isTimeOnly == true)
        minDate = false;
    else {
        if (allowPastDateTime == true && isValidateFinYear == true) {
            minDate = moment(finStartDate, dateTimeFormat);
        }
        else if (allowPastDateTime == true && isValidateFinYear == false) {
            if (minDate.format('DD/MM/YYYY') == currentDateTime.format('DD/MM/YYYY'))
                minDate = false;
            else
                minDate;
        }
        else
            minDate;
    }

    if (isTimeOnly == true)
        maxDate = false;
    else {
        if (allowFutureDateTime == true && isValidateFinYear == true) {
            maxDate = moment(finEndDate, dateTimeFormat);
        }
        else if (allowFutureDateTime == true && isValidateFinYear == false) {
            if (maxDate.format('DD/MM/YYYY') == currentDateTime.format('DD/MM/YYYY'))
                maxDate = false;
            else
                maxDate;
        }
    }


    $('#' + objId).datetimepicker({
        format: dateTimeFormat,
        maxDate: maxDate,
        minDate: minDate,
        widgetPositioning: {
            horizontal: 'right',
            vertical: 'bottom'
        }
    });

    if (setBlank) $('#' + objId).val('');
    else if ((Date.parse(new Date(defaultDateTime)) == Date.parse(new Date(1900, 0, 1))) || (Date.parse(new Date(defaultDateTime)) == Date.parse(new Date(2001, 0, 01)))) {

        $('#' + objId).val('');
    }

    else {

        $('#' + objId).val(defaultDateTime);
    }

};


function InitDateRangePicker(objId, dateRangeOption, isValidateFinYear) {
    var divHtml = '<label class="icon-right"><i class=\'glyphicon glyphicon-calendar fa fa-calendar\'></i></label><span id=\'' + objId + 'lbl\'></span>';
    $('#' + objId).addClass('pull-right form-control').append(divHtml).wrap('<div class="input"></div>');
    isValidateFinYear = (IsObjectNullOrEmpty(isValidateFinYear)) ? true : isValidateFinYear;

    var selected;
    switch (dateRangeOption) {
        case DateRange.Today: selected = DateRangeValue.Today; break;
        case DateRange.Yesterday: selected = DateRangeValue.Yesterday; break;
        case DateRange.LastWeek: selected = DateRangeValue.LastWeek; break;
        case DateRange.Last30Days: selected = DateRangeValue.Last30Days; break;
        case DateRange.ThisMonth: selected = DateRangeValue.ThisMonth; break;
        case DateRange.LastMonth: selected = DateRangeValue.LastMonth; break;
    };

    var obj = $('#' + objId).daterangepicker({
        format: jsDateFormat,
        startDate: selected[0],
        endDate: selected[1],
        minDate: (isValidateFinYear == true ? moment(finStartDate, jsDateTimeFormat) : false),
        maxDate: (isValidateFinYear == true ? moment(finEndDate, jsDateTimeFormat) : false),
        opens: 'right',
        showDropdowns: true,
        showWeekNumbers: false,
        timePicker: false,
        timePickerIncrement: 1,
        timePicker12Hour: true,
        buttonClasses: ['btn', 'btn-sm'],
        applyClass: 'btn-primary',
        cancelClass: 'btn-default',
        separator: ' to ',
        locale: {
            applyLabel: 'Apply',
            cancelLabel: 'Cancel',
            fromLabel: 'From',
            toLabel: 'To',
            customRangeLabel: 'Custom Range',
            daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
            monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
            firstDay: 1
        },
        ranges: {
            'Today': DateRangeValue.Today,
            'Yesterday': DateRangeValue.Yesterday,
            'Last 7 Days': DateRangeValue.LastWeek,
            'Last 30 Days': DateRangeValue.Last30Days,
            'This Month': DateRangeValue.ThisMonth,
            'Last Month': DateRangeValue.LastMonth
        }
    },
        function (start, end) {
            $('#' + objId).find('span').html(start.format(jsDateFormat) + ' - ' + end.format(jsDateFormat));
        });
    $('#' + objId).find('span').html(selected[0].format(jsDateFormat) + ' - ' + selected[1].format(jsDateFormat));
    return $('#' + objId).data('daterangepicker');
}

var DateRange = { Today: 1, Yesterday: 2, LastWeek: 3, Last30Days: 4, ThisMonth: 5, LastMonth: 6 };
var DateRangeValue = {
    Today: [moment(), moment()], Yesterday: [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
    LastWeek: [moment().subtract(6, 'days'), moment()],
    Last30Days: [moment().subtract(29, 'days'), moment()],
    ThisMonth: [moment().startOf('month'), moment().endOf('month')],
    LastMonth: [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
};


function BindDropDownList(ddlId, jsonData, valueField, textField, defaultValue, defaultText, defaultSelectedValue) {
    $('#' + ddlId + '').empty();
    if (jsonData.length > 1) {
        if (!IsObjectNullOrEmpty(defaultText) && !IsObjectNullOrEmpty(defaultText))
            $('#' + ddlId + '').append($('<option></option>').val(defaultValue).html(defaultText));
    }
    if (!IsObjectNullOrEmpty(jsonData)) {
        $.each(jsonData, function (i, item) {
            $('#' + ddlId + '').append($('<option></option>').val(item[valueField]).html(item[textField]));
        });
    }

    if ($('#' + ddlId + '').length == 1)
        $('#' + ddlId + '').val($("#" + ddlId + " option:first").val());

    if (!IsObjectNullOrEmpty(defaultSelectedValue))
        $('#' + ddlId + '').val(defaultSelectedValue);
    else
        $('#' + ddlId + '').change();
}

function ClearDropDownList(ddlId, defaultValue, defaultText) {
    $('#' + ddlId + '').empty();
    if (!IsObjectNullOrEmpty(defaultText) && !IsObjectNullOrEmpty(defaultText))
        $('#' + ddlId + '').append($('<option></option>').val(defaultValue).html(defaultText));
}

function ResetDropDownValue(ddl, oldValue, newValue) {
    $('#' + ddl.attr('id') + ' option[value=\'' + oldValue + '\']').val(newValue).refresh();
}

function SetDropDownValue(ddl, value) {
    ddl.removeClass('select2');
    ddl.val(value).refresh();
    ddl.addClass('select2');
}

function ShowHideDropDownValue(ddl, isHide) {
    if (isHide)
        ddl.closest('.select').hide();
    else
        ddl.closest('.select').show();
}

function AddItemDropDownList(ddl, index, value, text) {
    $(ddl).find('option').eq(index).after($("<option></option>").val(value).text(text));
}

function AddFirstItemDropDownList(ddl, value, text, isReset) {
    if (IsObjectNullOrEmpty(isReset)) isReset = true;
    if (isReset)
        ddl.prepend('<option value=\'' + value + '\'>' + text + '</option>').val(value);
    else
        ddl.prepend('<option value=\'' + value + '\'>' + text + '</option>');
}


/*
Function    : Ajax Request
Parameter   : 
            url -> Request Url
            type -> GET / POST
            contentType -> application/json
            dataType -> Json
            data : Request Data
            successFunction :  Success Function
            errorFunction : Error Function
            async -> Setting async to false means that the statement you are calling has to complete before the next statement in your function can be called.
                     If you set async: true then that statement will begin it's execution and the next statement will be called regardless of whether the async 
                     statement has completed yet.
*/
function AjaxRequest(url, type, contentType, dataType, data, successFunction, errorFunction, async) {
    $.ajax({
        url: url,
        type: type,
        contentType: contentType,
        dataType: dataType,
        data: data,
        success: successFunction,
        error: errorFunction,
        async: async
    });
}

/*
Function    :   Ajax Request With POST and Json
                Extension of AjaxRequest (http POST method with Json datatype)
*/
function AjaxRequestWithPostAndJson(url, data, successFunction, errorFunction, async) {
    AjaxRequest(url, 'POST', 'application/json; charset=utf-8', 'json', data, successFunction, errorFunction, async);
}
function AjaxRequestWithPostAndHtml(url, data, successFunction, errorFunction, async) {
    AjaxRequest(url, 'POST', 'application/json; charset=utf-8', 'html', data, successFunction, errorFunction, async);
}
function ErrorFunction(request, status, error) {
    try {
        ShowMessage(error.message);
    }
    catch (e) { ShowMessage(error); }
}

function GetAutoCompleteRequestData(request, prefixText, additionalFilterFunction) {
    var requestData = {};
    requestData[prefixText] = request.term.split(':')[0].trim();
    if (!IsObjectNullOrEmpty(additionalFilterFunction)) {
        var additionalFilter = additionalFilterFunction();
        for (var i = 0; i < additionalFilter.length; i++) {
            requestData[additionalFilter[i].Key] = additionalFilter[i].Value;
        }
    }
    return JSON.stringify(requestData)
}

function AutoComplete(eleId, url, prefixText, focus, select, s1, s2, s3, eleValId, eleDescriptionId, alertMsg, useValidate, additionalFilterFunction) {
    try {
        $('#' + eleId).attr("autocomplete", "new-password");
        $('#' + eleId).autocomplete({
            minLength: 3,
            source: function (request, response) {
                $.ajax({
                    type: 'POST',
                    contentType: 'application/json',
                    dataType: 'json',
                    url: url,
                    data: GetAutoCompleteRequestData(request, prefixText, additionalFilterFunction),
                    aysnc: false,
                    success: function (data) {
                        try {
                            var retOut;
                            if (data.d != null && data.d != undefined && data.d.length != 0)
                                retOut = jQuery.parseJSON(data.d);
                            else
                                retOut = data;
                        }
                        catch (e) { retOut = data.d; }
                        if (retOut.length != 0) {
                            response($.map(retOut, function (item) {
                                return {
                                    label: item.Name,
                                    value: item.Value,
                                    description: item.Description
                                }
                            }));
                        } else {
                            //$('#' + eleId).val('');
                            if (IsObjectNullOrEmpty(useValidate)) useValidate = true;
                            if (useValidate)
                                if (alertMsg != '') {
                                    ShowMessage('Invalid ' + alertMsg);
                                    $('#' + eleId).val('');
                                    $('#' + eleValId).val(0);
                                }
                                else {
                                    $('#' + eleId).val('');
                                    $('#' + eleValId).val(0);
                                }
                            return false;

                        }
                    },
                    error: function (errormessage) {
                        if (errormessage.message) ShowMessage(errormessage.message);
                    }
                })
            },
            open: function (event, ui) { disableACblur = true; return false; },
            close: function (event, ui) { disableACblur = false; return false; },
            focus: function (event, ui) {
                //return false;
                if (focus == 'v') $(this).val(ui.item.value);
                else if (focus == 'l') $(this).val(ui.item.label);
                else if (focus == 'd') $(this).val(ui.item.description);
                else if (focus == 'ld') $(this).val(ui.item.label + ' : ' + ui.item.description);
                else $(this).val(ui.item.label + ' : ' + ui.item.value);
                $('#' + eleValId).val(ui.item.value);
                return false;
            },
            select: function (event, ui) {
                $('#' + eleValId).val(ui.item.value);
                if (!IsObjectNullOrEmpty(eleDescriptionId)) {
                    if (eleDescriptionId.substring(0, 3) == 'lbl')
                        $('#' + eleDescriptionId).text(ui.item.description);
                    else
                        $('#' + eleDescriptionId).val(ui.item.description);
                }

                if (select == 'l') $(this).val(ui.item.label);
                else if (select == 'v') $(this).val(ui.item.value);
                else if (select == 'd') $(this).val(ui.item.description);
                else $(this).val(ui.item.label + ' : ' + ui.item.value);
                $(this).focus();
                return false;
            }
        }).data('ui-autocomplete')._renderItem = function (ul, item) {
            var rs1, rs2, rs3;
            if (s1 == 'v') { rs1 = item.value; }
            else if (s1 == 'l') { rs1 = item.label; }
            else if (s1 == 'd') { rs1 = item.description; }
            if (s2 == 'v') { rs2 = item.value; }
            else if (s2 == 'l') { rs2 = item.label; }
            else if (s2 == 'd') { rs2 = item.description; }
            if (!IsObjectNullOrEmpty(s3)) {
                if (s3 == 'v') { rs3 = item.value; }
                else if (s3 == 'l') { rs3 = item.label; }
                else if (s3 == 'd') { rs3 = item.description; }
            }
            var rs2String = (rs2 == undefined || rs2 == null || rs2 == '') ? '' : ' : ' + rs2;
            var rs3String = (rs3 == undefined || rs3 == null || rs2 == '') ? '' : ' : ' + rs3;

            return $('<li>')
                .append('<div>' + rs1 + rs2String + rs3String + '</div></li>')
                .appendTo(ul);
        };
    } catch (e) {
        ShowMessage(e.message);
    }
}

function ShowConfirm(message, doneFunction, failFunction, okText, cancelext) {
    if (okText == null || okText == undefined)
        okText = 'Yes';
    if (cancelext == null || cancelext == undefined)
        cancelext = 'No';

    //bootbox.confirm(message);
    //bootbox.confirm({
    //    buttonDone: okText,
    //    buttonFail: cancelext,
    //    message: message
    //}).done(function () {
    //    if (doneFunction == null || doneFunction == undefined)
    //        return false;
    //    else
    //        doneFunction.call();
    //}).fail(function () {
    //    if (failFunction == null || failFunction == undefined)
    //        return false;
    //    else
    //        failFunction.call();
    //})

    bootbox.dialog({
        message: message,
        buttons: {
            success: {
                label: okText,
                className: "btn-success",
                callback: function () {
                    if (doneFunction == null || doneFunction == undefined)
                        return false;
                    else
                        doneFunction.call();
                }
            },
            danger: {
                label: cancelext,
                className: "btn-danger",
                callback: function () {
                    if (failFunction == null || failFunction == undefined)
                        return false;
                    else
                        failFunction.call();
                }
            }
        }
    });
}

function AddRequired(obj, errorMessage) {
    obj.rules('add', { required: true, messages: { required: errorMessage } });
}

function RemoveRequired(obj) {
    obj.rules('remove', 'required');
    Unhighlight(obj);
}

function AddRange(obj, errorMessage, min, max) {
    if (max == null)
        max = 9999999999;
    obj.rules('add', { range: [min, max], messages: { range: errorMessage } });
}

function AddLength(obj, errorMessage, min) {
    obj.rules('add', { minlength: min, messages: { minlength: errorMessage } });
}

function AddMaxLength(obj, errorMessage, min) {
    obj.rules('add', { maxlength: min, messages: { maxlength: errorMessage } });
}

function RemoveRange(obj) {
    obj.rules('remove', 'range');
}

function Highlight(obj) {
    $(obj).closest('.input').removeClass('success-view').addClass('error-view');
    $(obj).closest('.select').removeClass('success-view').addClass('error-view');
    if ($(obj).is(':checkbox') || $(obj).is(':radio')) {
        $(obj).closest('.check').removeClass('success-view').addClass('error-view');
    }
    $(obj).closest('div').next('span').removeClass('field-validation-valid').addClass('field-validation-error');
}

function Unhighlight(obj) {
    $(obj).closest('.input').removeClass('error-view').addClass('success-view');
    $(obj).closest('.select').removeClass('error-view').addClass('success-view');
    if ($(obj).is(':checkbox') || $(obj).is(':radio')) {
        $(obj).closest('.check').removeClass('error-view').addClass('success-view');
    }
    $(obj).closest('div').next('span').removeClass('field-validation-error').addClass('field-validation-valid');
}

function ShowError(obj, errorMessage) {
    var name = obj[0].name;
    errorObj = {};
    errorObj[name] = errorMessage;
    $('#' + obj.get(0).form.id).validate().showErrors(errorObj);
}

function ReplaceUrl(controllerName, actionName, area) {
    if (IsObjectNullOrEmpty(area)) area = 'Master';
    return appUrl.replace('Master', area).replace('Controller', controllerName).replace('Action', actionName);
}

function GetFieldCaptionByName(objJson, fieldName) {
    var fieldCaption = '';
    objJson.forEach(
        function (field) {
            if (field["FieldName"] == fieldName) {
                fieldCaption = field["FieldCaption"];
                return false;
            }
        });
    return fieldCaption;
}

function LoadDataTable(objId, exportAllowed, pagingAllowed, searchAllowed, columnReorderAllowed, pageSizeArray, data, columns, sortAllowed, sizeArr) {

    if (pagingAllowed) {
        if (pageSizeArray == null || pageSizeArray == undefined || pageSizeArray.length == 0)
            pageSizeArray = [10, 25, 50, 100, 500];
    }
    else
        pageSizeArray = [];
    exportAllowed = (exportAllowed == null || exportAllowed == undefined) ? true : exportAllowed;
    pagingAllowed = (pagingAllowed == null || pagingAllowed == undefined) ? true : pagingAllowed;
    searchAllowed = (searchAllowed == null || searchAllowed == undefined) ? true : searchAllowed;
    sortAllowed = (sortAllowed == null || sortAllowed == undefined) ? true : sortAllowed;
    columnReorderAllowed = (columnReorderAllowed == null || columnReorderAllowed == undefined) ? true : columnReorderAllowed;

    data = (data == undefined) ? null : data;
    columns = (columns == undefined) ? null : columns;

    var domString = '<"row" ';

    if (pagingAllowed)
        domString += '<"col-sm-3"l>';
    else
        domString += '<"col-sm-3">';

    if (exportAllowed)
        domString += '<"col-sm-4"T><"col-sm-1"C>';
    else
        domString += '<"col-sm-5">';

    if (searchAllowed)
        domString += '<"col-sm-4"f>';

    domString = domString + '>';

    if (pagingAllowed)
        domString += '<"row" <"col-sm-12"<"td-content"rt>>><"row" <"col-sm-6"i><"col-sm-6"p>>';

    if (columnReorderAllowed)
        domString += 'R';


    $('#' + objId).addClass('table table-striped data-tbl dataTable no-footer dtr-inline');

    var dt = $('#' + objId).dataTable({
        data: data,
        columns: columns,
        responsive: true,
        'bSort': sortAllowed,
        'bFilter': searchAllowed,
        'iDisplayLength': pageSizeArray.length > 0 ? pageSizeArray[0] : 9999,
        'bPaginate': (pagingAllowed),//Paging
        //"columnDefs": [{ "targets": [1, 2], "orderable": false }],
        "oLanguage": {
            "sLengthMenu": '<select class="tbl-data-select">' +
                '<option value="5">5</option>' +
                '<option value="10">10</option>' +
                '<option value="20">20</option>' +
                '<option value="30">30</option>' +
                '<option value="40">40</option>' +
                '<option value="50">50</option>' +
                '<option value="-1">All</option>' +
                '</select>' + '<span class="r-label">Entries</span>'
        },
        "dom": domString,
        buttons: [
            {
                extend: 'excel'
            },
            {
                extend: 'csv'
            },
        ]
    });

    if ($.fn.select2) { $('.tbl-data-select').select2({ minimumResultsForSearch: -1 }); }
    $('.ColVis_MasterButton').addClass("btn btn-primary");
    $('.ColVis_MasterButton span').html('<i class="fa fa-th-list"></i>');
    $('.DTTT_button_print').click(function () { window.print(); });

    if (sizeArr !== undefined && sizeArr !== null) {
        $.each(sizeArr, function (i, item) {
            $('#' + objId + ' thead tr th:eq(' + item[0] + ')').css('min-width', item[1]).css('max-width', item[1]);
        });
    }
    dt.removeClass('dataTable');
    dt.wrap('<div class="table-responsive"></div>');
    return dt;
}

function InitGrid(objId, allowDeleteAllRow, actionColumnIndex, rowEventFunction, useDeleteOnly, sizeArr) {

    if (IsObjectNullOrEmpty(useDeleteOnly)) useDeleteOnly = false;

    $('#' + objId).addClass('table table-striped data-tbl dataTable no-footer dtr-inline');
    //$('#' + objId + ' > tbody > tr:last').attr('data-row-id', '0');
    $('#' + objId + ' > thead > th').css("tabindex", "-1");

    if (sizeArr !== undefined && sizeArr !== null) {
        $.each(sizeArr, function (i, item) {
            $('#' + objId + ' thead tr th:eq(' + item[0] + ')').css('min-width', item[1]).css('max-width', item[1]);
        });
    }

    $('#' + objId).removeClass('dataTable');
    $('#' + objId).wrap('<div class="table-responsive"></div>');
    var fnName = arguments[3].name;

    var buttons = (useDeleteOnly ? '' : '<button type="button" id="btnAdd" onclick="return AddGridRow(\'' + objId + '\',' + allowDeleteAllRow + ',' + fnName + ')" class="btn btn-primary"><i class="fa fa-plus" aria-hidden="true"></i></button>') +
        '<button type="button" id="btnRemove" onclick="return RemoveGridRow($(this),\'' + objId + '\',' + allowDeleteAllRow + ',' + fnName + ')" class="btn btn-danger" style="margin-left: 3px;"><i class="fa fa-times" aria-hidden="true"></i></button>';

    $('#' + objId + ' > tbody > tr').each(function () {
        $(this).find('td:eq(' + actionColumnIndex + ')').html(buttons).css("min-width", "75px");

    });

    ManageTableAddRemove(objId, allowDeleteAllRow);

    if (rowEventFunction != null && rowEventFunction != '' && rowEventFunction != undefined)
        rowEventFunction.call(this, objId);
}

function RenameCloneIdsAndNames(objClone, removeData) {
    var isChildTable = false;
    if (objClone.find("table").length > 0)
        isChildTable = true;
    var dataRowId = 0;
    if (!objClone.attr('data-row-id')) {
        console.error('Cloned object must have \'data-row-id\' attribute.');
    }
    dataRowId = objClone.attr('data-row-id')
    if (removeData)
        dataRowId = parseInt(dataRowId) + 1;
    if (objClone.attr('id')) {
        objClone.attr('id', objClone.attr('id').replace(/\d+$/, function (strId) { return dataRowId; }));
    }

    objClone.attr('data-row-id', objClone.attr('data-row-id').replace(/\d+$/, function (strId) { return dataRowId; }));

    objClone.find('[data-id]').each(function () {
        var strNewId = $(this).attr('data-id').replace(/\d+$/, function (strId) { return dataRowId; });
        $(this).attr('data-id', strNewId);
    });

    objClone.find('[id]').each(function () {
        var obj = $(this);
        var dotCount = 0;
        var strNewName;
        var strFunction;
        if (obj.attr('name')) {
            dotCount = obj.attr('name').count('.');
            if (dotCount >= 2) {
                var arr = obj.attr('name').split('.');
                var left = "", right = "";
                for (var i = 0; i < arr.length; i++) {
                    if (i < dotCount - 1)
                        left += arr[i] + '.';
                    else
                        right = (right == "" ? arr[i] : (right + '.' + arr[i]));
                }
                if (isChildTable)
                    strNewName = (left.replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return '[' + intNumber + ']'
                    })) + right;
                else
                    strNewName = left + (right.replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return '[' + intNumber + ']'
                    }));
            }
            else {
                strNewName = obj.attr('name').replace(/[\d[\]']+/g, function (strName) {
                    strName = strName.replace(/[\[\]']+/g, '');
                    var intNumber = dataRowId;
                    return '[' + intNumber + ']'
                });
            }
            obj.attr('name', strNewName);
        }


        if (obj.attr('id')) {
            if (obj.hasClass('select2-selection__rendered'))
                dotCount = obj.attr('id').count('-');
            if (dotCount >= 2) {
                var arr = [];
                if (obj.hasClass('select2-selection__rendered'))
                    arr = obj.attr('id').split('-');
                else
                    arr = obj.attr('id').split('_');
                var a = obj.closest('table').Id;
                var left = "", right = "";

                if (obj.hasClass('select2-selection__rendered')) {
                    for (var i = 0; i < arr.length; i++) {
                        if (i < dotCount)
                            left += arr[i] + '-';
                        else
                            right = (right == "" ? arr[i] : (right + '-' + arr[i]));
                    }
                }
                else {
                    for (var i = 0; i < arr.length; i++) {
                        if (i < dotCount)
                            left += arr[i] + '_';
                        else
                            right = (right == "" ? arr[i] : (right + '_' + arr[i]));
                    }
                }

                if (isChildTable)
                    strNewName = (left.replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return intNumber
                    })) + right;
                else
                    strNewName = left + (right.replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return intNumber
                    }));

                strNewName = strNewName.replace(/\./g, '_').replace(/\[/g, '').replace(/\]/g, '');
            }
            else {
                strNewName = obj.attr('id').replace(/\d+$/, function (strId) { return dataRowId; })
                if (obj.attr('type') == 'file')
                    strFunction = obj.attr('onchange').replace(/\d+/, function (strId) { return dataRowId; })
            }
            obj.attr('id', strNewName);
            if (obj.attr('type') == 'file')
                obj.attr('onchange', strFunction);

            if (removeData) {

                if (!obj.hasClass('static'))
                    if (obj.attr('id').substring(0, 3) == 'ddl' && obj.IsEnabled) {
                        if (obj.hasClass('select2')) {
                            obj.next('span').remove();
                            obj.val('');
                            obj.select2();
                        }
                        obj.val('');
                    }
                    else if (obj.attr('id').substring(0, 3) == 'ddl' && !obj.IsEnabled)
                        obj.val(obj.val());
                    else if (obj.hasClasses(['numeric', 'numeric2', 'numeric3']))
                        obj.val(0);
                    else if (obj.attr('id').substring(0, 3) == 'lbl')
                        obj.text('');
                    else if (obj.attr('id').substring(0, 3) == 'chk')
                        obj.check(false);
                    else if (!obj.hasClass('hidden-datetime'))
                        obj.val('');

            }
        }

        if (obj.attr('for')) {
            obj.attr('for', obj.attr('name'));
        }

        var span = obj.nextAll('span');

        if (span) {
            if (span.length == 0)
                span = obj.nextAll('div').find('span').first();
            if (span.length == 0)
                span = obj.closest('div').nextAll('span').first();
            if (span.hasAttr('data-valmsg-for')) {
                var strNewName;
                var dotCount = span.attr('data-valmsg-for').count('.');
                if (dotCount >= 2) {
                    var arr = span.attr('data-valmsg-for').split('.');
                    var left = "", right = "";
                    for (var i = 0; i < arr.length; i++) {
                        if (i < dotCount - 1)
                            left += arr[i] + '.';
                        else
                            right = (right == "" ? arr[i] : (right + '.' + arr[i]));
                    }
                    if (isChildTable)
                        strNewName = (left.replace(/[\d[\]']+/g, function (strName) {
                            strName = strName.replace(/[\[\]']+/g, '');
                            var intNumber = dataRowId;
                            return '[' + intNumber + ']'
                        })) + right;
                    else
                        strNewName = left + (right.replace(/[\d[\]']+/g, function (strName) {
                            strName = strName.replace(/[\[\]']+/g, '');
                            var intNumber = dataRowId;
                            return '[' + intNumber + ']'
                        }));
                }
                else {
                    strNewName = span.attr('data-valmsg-for').replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return '[' + intNumber + ']'
                    });
                }
                span.attr('data-valmsg-for', strNewName);
                if (removeData)
                    span.html('');
            }
        }
    });
    return objClone;
}

function AddGridRow(objId, allowDeleteAllRow, rowEventFunction, asFirstRow) {

    if (IsObjectNullOrEmpty(asFirstRow)) asFirstRow = false;
    AddTableRow(objId, allowDeleteAllRow, asFirstRow);
    rowEventFunction.call(this, objId);
}

function RemoveGridRow(btn, objId, allowDeleteAllRow, rowEventFunction) {
    RemoveTableRow($(btn), allowDeleteAllRow, rowEventFunction);
    ManageTableAddRemove(objId, allowDeleteAllRow);
}

function ManageTableAddRemove(tableId, allowDeleteAll) {

    allowDeleteAll = (allowDeleteAll != undefined && allowDeleteAll != null) ? allowDeleteAll : false;
    var rowCount = $('#' + tableId).rowCount();
    var rowIndex = 0;
    $('#' + tableId + ' > tbody > tr').each(function () {
        if ($(this).attr('data-row-id') != '0') {
            $(this).attr('data-row-id', rowIndex);
            RenameCloneIdsAndNames($(this), false);
        }
        $(this).find('[id=btnAdd]').hide();
        if (!allowDeleteAll)
            $(this).find('[id=btnRemove]').show();
        rowIndex++;
    });
    if (rowCount == 1) {
        $('#' + tableId + ' > tbody > tr:last').find('[id=btnAdd]').show();
        if (!allowDeleteAll)
            $('#' + tableId + ' > tbody > tr:last').find('[id=btnRemove]').hide();
    }
    $('#' + tableId + ' > tbody > tr:last').find('[id=btnAdd]').show();

}

function AddTableRow(tableId, allowDeleteAll, asFirstRow) {
    if (IsObjectNullOrEmpty(asFirstRow)) asFirstRow = false;
    var trFirst = $('#' + tableId + ' > tbody > tr:first');
    var trLast = $('#' + tableId + ' > tbody > tr:last');
    var trNew = trFirst.clone();

    if (asFirstRow) {
        trFirst.before(trNew);
        trNew.attr('data-row-id', '-1');
    }
    else {
        RenameCloneIdsAndNames(trNew, true);
        if (trNew.attr('data-row-id'))
            trLast.after(trNew);
    }

    ManageTableAddRemove(tableId, allowDeleteAll);

    RegisterValidation();
    trLast = $('#' + tableId + ' > tbody > tr:last');
    var elements = trLast.find(':text,:radio,:checkbox,select,textarea').filter(function () {
        return !this.readOnly &&
            !this.disabled &&
            $(this).parentsUntil('form', 'div').css('display') != "none";
    });
    if (elements.length > 0)
        elements[0].focus();

    trLast.find('input:first(:visible,not:disabled)').focus();
    $('#' + tableId + ' > tbody > tr:last').find('[id*=chk]').val('true');
    return false;
}

function RemoveTableRow(object, allowDeleteAll, fnInitTable) {

    allowDeleteAll = (allowDeleteAll != undefined && allowDeleteAll != null) ? allowDeleteAll : false;

    var tr = object.closest('tr');
    var table = tr.closest('table');
    var rowCount = table.rowCount();

    if (rowCount == 1) {
        if (allowDeleteAll) {
            if (!confirm('Are you sure that you want to remove last record?'))
                return false;
        }
        else {
            ShowMessage('You cannot remove last record');
            return false;
        }
    }
    tr.remove();
    rowCount = table.rowCount();

    if (fnInitTable == null || fnInitTable == '' || fnInitTable == undefined)
        InitTable();
    else
        fnInitTable.call(this, table.Id);
    trLast = $('#' + table.Id + ' > tbody > tr:last');
    trLast.find('input:first').focus();

    return false;
}

function ResetTableRow(dtId, data, fn) {
    var dataCount = data.length;
    var rowCount = $('#' + dtId).rowCount();
    if (dataCount > 0) {
        if (rowCount > dataCount) {
            var deleteRow = rowCount - dataCount;
            if (deleteRow)
                for (var i = 0; i < deleteRow; i++) {
                    $('#' + dtId + ' > tbody > tr:last').find('[id*="btnRemove"]').click();
                }
        }
        else if (dataCount > rowCount) {
            var addRow = dataCount - rowCount;
            for (var i = 0; i < addRow; i++) {
                $('#' + dtId + ' > tbody > tr:last').find('[id*="btnAdd"]').click();
            }
        }
        fn.call(this, data);
    }
}

function GetTableRow(tableId) {
    var trFirst = $('#' + tableId + ' > tbody > tr:first');
    var trNew = trFirst.clone();

    trNew.find('[id*=ddl]').each(function () {
        var div = $(this).next('div');
        if (div.hasClass('select'))
            div.remove();
        $(this).refresh();
    });

    if (trNew.attr('data-row-id')) {
        RenameCloneIdsAndNames(trNew, true);
    }

    return trNew;
}

function CheckDuplicateInTable(tableId, fieldId, fieldName, obj) {
    if (obj.val() != '') {
        var selected = [];
        var duplicateCount = false;
        var fieldData = '';
        $('#' + tableId + ' tr:not(:first)').each(function () {
            var ele = $(this).find('[id*=' + fieldId + ']');
            if (ele.length > 0 && ele != obj && ele.val() != '') {
                //alert(ele.val().toUpperCase());
                fieldData = ele.val().toUpperCase();

                if ($.inArray(fieldData, selected) == -1)
                    selected.push(fieldData);
                else
                    duplicateCount = true;
            }
        });
        if (duplicateCount) {
            ShowMessage('Please remove Duplicate ' + fieldName + ' : ' + fieldData);
            obj.val('');
            obj.focus();
            return false;
        }
    }
    return true;
}

function CheckDuplicateRangeInTable(tableId, fieldId, fieldId2, fieldName, obj, obj2) {

    //alert(obj.val());
    //alert(obj2.val());
    if (obj.val() != '') {
        var selected = [];
        var duplicateCount = false;
        var fieldData = '';
        $('#' + tableId + ' tr:not(:first)').each(function () {
            var ele = $(this).find('[id*=' + fieldId + ']');
            var ele2 = $(this).find('[id*=' + fieldId2 + ']');

            if (ele.length > 0 && ele.val() != obj.val() && ele.val() != '') {

                if (parseInt(obj.val()) >= parseInt(ele.val()) && parseInt(obj.val()) <= (parseInt(ele.val()) + parseInt(ele2.val()) - 1)) {

                    duplicateCount = true;
                }
            }

            // alert(ele.val());
            //alert(ele2.val());


        });
        if (duplicateCount) {
            ShowMessage('Please remove duplicate range of dcr entry ' + fieldName + ' : ' + fieldData);
            obj.val('');
            obj.focus();
            return false;
        }
    }
    return true;
}



function CheckDuplicateDropDownInTable(tableId, fieldId, fieldName, obj) {

    // alert(obj.val());
    //alert($("option:selected", obj).text());
    if (obj.val() != '') {
        var selected = [];
        var duplicateCount = false;
        var fieldData = '';
        $('#' + tableId + ' tr:not(:first)').each(function () {
            var ele = $(this).find('[id*=' + fieldId + ']');
            if (ele.length > 0 && ele != obj && ele.val() != '') {
                //alert(ele.val().toUpperCase());
                //fieldData = ele.val().toUpperCase();
                fieldData = $("option:selected", ele).text()
                if ($.inArray(fieldData, selected) == -1)
                    selected.push(fieldData);
                else
                    duplicateCount = true;
            }
        });
        if (duplicateCount) {
            ShowMessage('Please remove Duplicate ' + fieldName + ' : ' + fieldData);
            //obj.val('');
            obj.focus();
            return false;
        }
    }
    return true;
}

function GetUrlValue() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = decodeURIComponent(hash[1]);
    }
    return vars;
}

function IsObjectNullOrEmpty(obj) {
    try {

        if ((obj != undefined) && (obj != null) && (obj.toString().trim() != '')) {
            return false;
        }
        else {
            return true;
        }
    }
    catch (err) {
        return true;
    }
}

function GetArrayItemByPropery(arr, key, val) {
    var member = null;
    $.each(arr, function (i, item) {
        if (item[key] == val)
            member = item;
    });
    return member;
}

function RegisterValidation() {
    $('form').removeData("validator").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse($('form'));
    // RegisterDynamicValidation(objControl);

    $("[class*='text-datetime']").each(function () {
        var objDatetime = this;
        var dateAttributes = $('#' + objDatetime.Id.replace('txt', 'hdn')).val().split(',');
        if (dateAttributes[1] == 'true')
            AddRequired($(objDatetime), 'Please select ' + dateAttributes[0]);
    });
}

/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />

(function ($) {
    $.validator.unobtrusive.parseDynamicContent = function (selector) {
        //use the normal unobstrusive.parse method
        $.validator.unobtrusive.parse(selector);

        //get the relevant form
        var form = $(selector).first().closest('form');

        //get the collections of unobstrusive validators, and jquery validators
        //and compare the two
        var unobtrusiveValidation = form.data('unobtrusiveValidation');
        var validator = form.validate();

        $.each(unobtrusiveValidation.options.rules, function (elname, elrules) {
            if (validator.settings.rules[elname] == undefined) {
                var args = {};
                $.extend(args, elrules);
                args.messages = unobtrusiveValidation.options.messages[elname];
                //edit:use quoted strings for the name selector
                $("[name='" + elname + "']").rules("add", args);
            } else {
                $.each(elrules, function (rulename, data) {
                    if (validator.settings.rules[elname][rulename] == undefined) {
                        var args = {};
                        args[rulename] = data;
                        args.messages = unobtrusiveValidation.options.messages[elname][rulename];
                        //edit:use quoted strings for the name selector
                        $("[name='" + elname + "']").rules("add", args);
                    }
                });
            }
        });
    }
})($);

function RegisterDynamicValidation(obj) {
    $.validator.unobtrusive.parseDynamicContent(obj);
}

function IsFormValidAll(form, fieldArray) {
    var isValid = true;
    for (var i = 0; i < fieldArray.length; i++) {
        if (!form.validate().element('#' + fieldArray[i].id))
            isValid = false;
    }
    return isValid;
}

function IsFormValid(form, fieldArray) {
    var isValid = true;
    for (var i = 0; i < fieldArray.length; i++) {
        if (!form.validate().element('#' + fieldArray[i]))
            isValid = false;
    }
    return isValid;
}

function IsStepValid(dv) {
    var isValid = true;
    var frm = dv.closest('form');
    var $frmValidator = frm.validate();
    var stepElements = dv.find("input:enabled,select:enabled,textarea:enabled,input[type=file]");

    if (stepElements.length > 0)
        $(stepElements).each(function () {
            var dv = $(this).closest('table');
            if (!this.readOnly && !this.disabled && (dv == null || dv.length == 0 || (dv != null && dv.is(':visible')))) {
                var isFieldValid = frm.validate().element($(this));
                if (!isFieldValid) {
                    $frmValidator.focusInvalid();
                    isValid = false;
                }
            }
        });

    if (!isValid) {
        $frmValidator.focusInvalid();
    }

    return isValid;
}

$(".textlabel").attr("tabindex", "-1");

$(document).on("input", ".numeric,.numeric2,.numeric3", function () {
    this.value = this.value.replace(/[^\d\.\-]/g, '');
    if (this.value == "")
        this.value = 0;
});

$(document).on("focus", ".numeric,.numeric2,.numeric3", function () {
    this.value = this.value.replace(/[^\d\.\-]/g, '');
    if (this.value == 0)
        this.value = "";
});

$(document).on("blur", ".numeric,.numeric2,.numeric3,.numeric4", function () {
    var decimalPlaces = 0;
    if ($(this).hasClass('numeric2')) decimalPlaces = 2;
    if ($(this).hasClass('numeric3')) decimalPlaces = 3;
    if ($(this).hasClass('numeric4')) decimalPlaces = 4;

    if (this.value.trim() === "") {
        this.value = 0;
    } else {
        this.value = this.value.replace(/[^\d.\-]/g, '');
    }
    this.value = (parseFloat(this.value)).toFixed(decimalPlaces);
});

$('.form-control').on("blur", function () {
    var value = $.trim($(this).val());
    $(this).val(value.toUpperCase());
});

$("select").each(function () {
    var dropdown = $(this);
    var dropdownLength = 0;
    var isSelectOption = false;
    dropdownLength = dropdown.find("option").length;

    if (dropdownLength <= 1) {
        if (dropdown.hasClass('select2'))
            dropdown.prop('selectedIndex', 0);
        else
            dropdown.prop('selectedIndex', 1);
        //$("#" + dropdown.attr('id') + " > option").each(function () {
        //    if (this.value == '') {
        //        isSelectOption = true; 
        //        return false;
        //    }
        //});
    }

    //if (isSelectOption) {
    //    $("#" + dropdown.attr('id') + " > option").each(function () {
    //        if (this.value != '') {
    //            dropdown.val(this.value).change();
    //            return false;
    //        }
    //    });
    //}
});

function CloneDropDownListOption(ddlSource, ddlDestination) {
    var $options = $('#' + ddlSource.attr('id') + ' > option').clone();
    ddlDestination.empty();
    ddlDestination.append($options);
    ddlDestination.val(ddlSource.val());
}

function DropDownChange(id, fnOnChange) {
    $('#' + id).change(fnOnChange);
}

var DemoCallBack = (function () {
    var elem,
        hideHandler,
        that = {};

    that.init = function (options) {
        elem = $(options.selector);
    };

    that.show = function (text) {
        clearTimeout(hideHandler);
        elem.find("span").html(text);
        elem.delay(200).fadeIn().delay(3000).fadeOut();
    };

    return that;
}());

DemoCallBack.init({
    "selector": ".bb-alert"
});

function InitDateRange(objId, dateRangeOption, isValidateFinYear) {
    var divHtml = ' <i class=\'glyphicon glyphicon-calendar fa fa-calendar\'></i> ' + '<span id=\'' + objId + 'lbl\'></span>' + ' <b class=\'caret\'></b> ';
    $('#' + objId).addClass('btn btn-success').append(divHtml);
    isValidateFinYear = (IsObjectNullOrEmpty(isValidateFinYear)) ? true : isValidateFinYear;

    var selected;
    switch (dateRangeOption) {
        case DateRange.Today: selected = DateRangeValue.Today; break;
        case DateRange.Yesterday: selected = DateRangeValue.Yesterday; break;
        case DateRange.LastWeek: selected = DateRangeValue.LastWeek; break;
        case DateRange.Last30Days: selected = DateRangeValue.Last30Days; break;
        case DateRange.ThisMonth: selected = DateRangeValue.ThisMonth; break;
        case DateRange.LastMonth: selected = DateRangeValue.LastMonth; break;
    };

    var obj = $('#' + objId).daterangepicker({
        format: jsDateFormat,
        startDate: selected[0],
        endDate: selected[1],
        minDate: (isValidateFinYear == true ? moment(finStartDate, jsDateTimeFormat) : false),
        maxDate: (isValidateFinYear == true ? moment(finEndDate, jsDateTimeFormat) : false),
        opens: 'right',
        showDropdowns: true,
        showWeekNumbers: false,
        timePicker: false,
        timePickerIncrement: 1,
        timePicker12Hour: true,
        ranges: {
            'Today': DateRangeValue.Today,
            'Yesterday': DateRangeValue.Yesterday,
            'Last 7 Days': DateRangeValue.LastWeek,
            'Last 30 Days': DateRangeValue.Last30Days,
            'This Month': DateRangeValue.ThisMonth,
            'Last Month': DateRangeValue.LastMonth
        }
    },
        function (start, end) {
            $('#' + objId).find('span').html(start.format(jsDateFormat) + ' - ' + end.format(jsDateFormat));
        });
    $('#' + objId).find('span').html(selected[0].format(jsDateFormat) + ' - ' + selected[1].format(jsDateFormat));
    return $('#' + objId).data('daterangepicker');
}


function InitDateRangeCalYear(objId, dateRangeOption, isValidateFinYear) {
    var divHtml = ' <i class=\'glyphicon glyphicon-calendar fa fa-calendar\'></i> ' + '<span id=\'' + objId + 'lbl\'></span>' + ' <b class=\'caret\'></b> ';
    $('#' + objId).addClass('btn btn-success').append(divHtml);
    isValidateFinYear = (IsObjectNullOrEmpty(isValidateFinYear)) ? true : isValidateFinYear;

    var selected;
    switch (dateRangeOption) {
        case DateRange.Today: selected = DateRangeValue.Today; break;
        case DateRange.Yesterday: selected = DateRangeValue.Yesterday; break;
        case DateRange.LastWeek: selected = DateRangeValue.LastWeek; break;
        case DateRange.Last30Days: selected = DateRangeValue.Last30Days; break;
        case DateRange.ThisMonth: selected = DateRangeValue.ThisMonth; break;
        case DateRange.LastMonth: selected = DateRangeValue.LastMonth; break;
    };

    var obj = $('#' + objId).daterangepicker({
        format: jsDateFormat,
        startDate: selected[0],
        endDate: selected[1],
        minDate: (isValidateFinYear == true ? moment(calYrStartDate, jsDateTimeFormat) : false),
        maxDate: (isValidateFinYear == true ? moment(CalYrEndDate, jsDateTimeFormat) : false),
        opens: 'right',
        showDropdowns: true,
        showWeekNumbers: false,
        timePicker: false,
        timePickerIncrement: 1,
        timePicker12Hour: true,
        ranges: {
            'Today': DateRangeValue.Today,
            'Yesterday': DateRangeValue.Yesterday,
            'Last 7 Days': DateRangeValue.LastWeek,
            'Last 30 Days': DateRangeValue.Last30Days,
            'This Month': DateRangeValue.ThisMonth,
            'Last Month': DateRangeValue.LastMonth
        }
    },
        function (start, end) {
            $('#' + objId).find('span').html(start.format(jsDateFormat) + ' - ' + end.format(jsDateFormat));
        });
    $('#' + objId).find('span').html(selected[0].format(jsDateFormat) + ' - ' + selected[1].format(jsDateFormat));
    return $('#' + objId).data('daterangepicker');
}



var SelectAll = {
    GetChkAll: function (headerChkId, fn) {
        return "<label class='checkbox'><input id='" + headerChkId + "' name='" + headerChkId + "' onchange=\"ManageSelectAll('" + headerChkId + "','H',this," + (arguments[1] != null ? arguments[1].name : null) + ")\" tabindex='0' type='checkbox' value='true'><i></i><input name='" + headerChkId + "' type='hidden' value='false'><label class='label' for='" + headerChkId + "' id='lbl" + headerChkId + "'></label></label>";
    },
    GetChk: function (headerChkId, chkId, chkName, fn, isChecked) {
        if (chkName == null || chkName == undefined) chkName = chkId;
        if (isChecked == null || isChecked == undefined) isChecked = false;
        return "<label class='checkbox'><input type='checkbox' class='selectrow' id='" + chkId + "' name='" + chkName + "' onclick=\"ManageSelectAll('" + headerChkId + "','C',this," + (arguments[3] != null ? arguments[3].name : null) + ")\" value='true' " + (isChecked ? "checked" : "") + "/><i></i> </label> ";
    },
    GetChkBox: function (headerChkId, chkId, chkName, fn, isChecked, hdnValue, lblText) {
        if (chkName == null || chkName == undefined) chkName = chkId;
        if (lblText == null || lblText == undefined || lblText == '') lblText = ' ';
        if (isChecked == null || isChecked == undefined) isChecked = false;
        return "<label class='checkbox'><input type='checkbox' class='selectrow' id='" + chkId + "' name='" + chkName + "' onclick=\"ManageSelectAll('" + headerChkId + "','C',this," + (arguments[3] != null ? arguments[3].name : null) + ")\" value='true' " + (isChecked ? "checked" : "") + "/><i></i> " +
            "<input type='hidden' value='" + hdnValue + "' id='" + chkId.replace('chk', 'hdn') + "' name='" + chkName.replace('chk', 'hdn') + "' />" +
            "<label class='label' id='" + chkId.replace('chk', 'lbl') + "'  for='" + chkName.replace('chk', 'lbl') + "'>" + lblText + "</label></label>";
    }
};

var ManageSelectAll = function (headerChkId, callerType, caller, fn) {
    var tbl = $(caller).closest('table');
    if (callerType == 'H')
        tbl.find(".selectrow").check($(caller).IsChecked).change();
    else
        $('#' + headerChkId).check((tbl.find('.selectrow:checked').length == tbl.find('.selectrow').length));
    if (fn != null && fn != undefined && typeof fn == "function") fn.call();
}

function ValidateMultiCheckBox(partialId, entityName) {
    var selected = false, firstCheckBox = null;
    $('[id*="' + partialId + '"]').each(function () {
        if (firstCheckBox == null)
            firstCheckBox = $(this);
        if ($(this).is(':checked'))
            selected = true;
    });
    if (!selected) {
        ShowMessage("Please select at-least one " + entityName);
        firstCheckBox.focus();
        return false;
    }
    return true;
}

function Comparer(a, b, fieldName) {
    var fieldName = 'ChargeName';
    if (a[fieldName] > b[fieldName])
        return 1;
    else if (a[fieldName] < b[fieldName])
        return -1;
    else return 0;
}

function ComparerCharge(a, b) {
    var fieldName = 'ChargeName';
    return Comparer(a, b, fieldName)
}

function ComparerTax(a, b) {
    var fieldName = 'TaxName';
    return Comparer(a, b, fieldName)
}

function parseFixed(num, dec) {
    var d = Math.pow(10, dec);
    return (Math.round(parseFloat(num) * d) / d).toFixed(dec);
}

function GotoNextStep() {
    var stepWizard = $('#dvWizard').bootstrapWizard({ 'tabClass': 'nav-wizard' });
    stepWizard.bootstrapWizard('next');
}

function EnableStep(stepId) {
    var stepWizard = $('#dvWizard').bootstrapWizard({ 'tabClass': 'nav-wizard' });
    stepWizard.bootstrapWizard('enable', stepId);
}

function DisableStep(stepId) {
    var stepWizard = $('#dvWizard').bootstrapWizard({ 'tabClass': 'nav-wizard' });
    stepWizard.bootstrapWizard('disable', stepId);
}


/* Date Check with Previous Module Date & Validate on Submit */
function ValidateModuleDateWithPreviousDocumentDate(tblId, chkId, hdnDateId, txtModuleDateId, moduleDateName) {
    var documentMaxDate = null;
    $('#' + tblId).find('[id*="' + chkId + '"]').each(function () {
        var chkSelect = $(this);
        if (chkSelect.IsChecked) {
            var hdnDocumentDate = $('#' + chkSelect.Id.replace(chkId, hdnDateId));
            if (documentMaxDate == null || documentMaxDate < moment(hdnDocumentDate.val()))
                documentMaxDate = moment(hdnDocumentDate.val());
        }
    });
    if (!CompareModuleDate(documentMaxDate, $.setDateTime($('#' + txtModuleDateId).val()), moduleDateName))
        return false;
    return true;
}

function CompareModuleDate(previousDate, currentDate, moduleDateName) {
    if (previousDate > currentDate) {
        isStepValid = false;
        ShowMessage('Please select ' + moduleDateName + ' greater than ' + $.displayDateToDateTime(previousDate));
        return false;
    }
    return true;
}


function InitMultiSelect(ddlId, addAll, selectAll, isRequired, isSingleAllSelect) {
    var control = $('#' + ddlId);

    if (selectAll == null || selectAll == undefined) selectAll = false;
    if (isRequired == null || isRequired == undefined) isRequired = false;
    if (isSingleAllSelect == null || isSingleAllSelect == undefined) isSingleAllSelect = false;
    if (addAll) {
        $('#' + ddlId + ' option').eq(0).before($('<option>', { value: '', text: 'All' }));
        control.trigger('change');
    }

    var selectedOption;
    control.on('change', function (evt, params) {
        var currentSelection = [];
        if (selectedOption) {
            var currentValues = $(this).val();
            currentSelection = currentValues.filter(function (el) {
                return selectedOption.indexOf(el) < 0;
            });
        }

        selectedOption = $(this).val();

        if (this.selectedIndex || isSingleAllSelect) {
            if (isSingleAllSelect && currentSelection != 0 && currentSelection.length > 0) {
                control.find('option').eq(0).prop('selected', false);
                control.trigger('change');
                return;
            }
            else if (isSingleAllSelect && currentSelection == '' && currentSelection.length > 0) {
                control.find('option:gt(0)').prop('selected', false);
                control.find('option').eq(0).prop('selected', true);
                control.trigger('change');
                return; //not `Select All`
            }
            else
                return;
        }
        else if (!this.selectedIndex && !isSingleAllSelect && !addAll) return;
        else if (this.selectedIndex) return;
        else {
            control.find('option:gt(0)').prop('selected', true);
            control.find('option').eq(0).prop('selected', false);
            control.trigger('change');
        }
    });

    if (selectAll)
        control.val(['']).change();

    if (isRequired)
        AddLength(control, 'Please select At-least one thing', 1);
}

function ValidateModuleDateWithPreviousModuleDate(hdntxtlblId, txtModuleDateId, moduleDateName) {
    var documentMaxDate = null;
    var objPrefix = hdntxtlblId.substring(0, 3);
    if (objPrefix == 'lbl')
        documentMaxDate = moment($('#' + hdntxtlblId).text());
    else if (objPrefix == 'txt')
        documentMaxDate = $.setDateTime($('#' + hdntxtlblId).val());
    else
        documentMaxDate = moment($('#' + hdntxtlblId).val());

    if (!CompareModuleDate(documentMaxDate, $.setDateTime($('#' + txtModuleDateId).val()), moduleDateName))
        return false;
}

function ValidateContainer(container) {
    var elements = container.find(":text(:visible),select,textarea");
    var isValid = true;
    if (elements.length > 0)
        $(elements).each(function () {
            var dv = $(this).closest('table');
            if (!this.readOnly && !this.disabled && (dv == null || dv.length == 0 || (dv != null && dv.is(':visible')))) {
                var isFieldValid = $('form').validate().element($(this));
                if (!isFieldValid) isValid = false;
            }
        });
    return isValid;
}

function IsValidGstTinNo(gstTinNo) {
    return (new RegExp("([0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]([A-Z]|[0-9]){3})")).test(gstTinNo);
}

//FirstTwo Character, Third Number, Fourth&Fifth AlphaNumeric, LastFourDigit Number
function GetValidVehicleNoFormat(vehicleNo) {
    vehicleNo = vehicleNo.toUpperCase();
    if (vehicleNo.length < 8)
        vehicleNo = '';
    else {
        if (!(new RegExp("([A-Z][A-Z][0-9][A-Z0-9][A-Z0-9])").test(vehicleNo.substring(0, 5))))
            vehicleNo = '';
        if (!(new RegExp("([0-9][0-9][0-9][0-9])").test(vehicleNo.slice(vehicleNo.length - 4, vehicleNo.length))))
            vehicleNo = '';
    }
    return vehicleNo;
}

function trim(str, chr) {
    var rgxtrim = (!chr) ? new RegExp('^\\s+|\\s+$', 'g') : new RegExp('^' + chr + '+|' + chr + '+$', 'g');
    return str.replace(rgxtrim, '');
}
function rtrim(str, chr) {
    var rgxtrim = (!chr) ? new RegExp('\\s+$') : new RegExp(chr + '+$');
    return str.replace(rgxtrim, '');
}
function ltrim(str, chr) {
    var rgxtrim = (!chr) ? new RegExp('^\\s+') : new RegExp('^' + chr + '+');
    return str.replace(rgxtrim, '');
}

/* Date Check with Previous Module Date & Validate on Submit */


/**
     * select2.js
     * select2-bootstrap.css
     *  */
if ($.fn.select2) {
    var placeholder = 'Select';
    var selectDropdownObj = $('.select2, .select2-multiple').select2();
    //selectDropdownObj.each(function () {
    //    $(this).select2();
    //});

    for (var i = 0; i < selectDropdownObj.length; i++) {
        //$(selectDropdownObj[i]).select2();
        $(selectDropdownObj[i]).select2({
            placeholder: {
                id: '-1', // the value of the option
                text: $(selectDropdownObj[i]).attr('placeholder')
            }
        });
    }

    $('button[data-select2-open]').click(function () {
        $('#' + $(this).data('select2-open')).select2('open');
    });
    var select2OpenEventName = "select2-open";
    $(':checkbox').on("click", function () {
        $(this).parent().nextAll('select').select2("enable", this.checked);
    });

    var repo = function formatRepo(repo) {
        if (repo.loading) return repo.text;

        var markup = '<div class="clearfix">' +
            '<div class="col-sm-1">' +
            '<img src="' + repo.owner.avatar_url + '" style="max-width: 100%" />' +
            '</div>' +
            '<div clas="col-sm-10">' +
            '<div class="clearfix">' +
            '<div class="col-sm-6">' + repo.full_name + '</div>' +
            '<div class="col-sm-3"><i class="fa fa-code-fork"></i> ' + repo.forks_count + '</div>' +
            '<div class="col-sm-2"><i class="fa fa-star"></i> ' + repo.stargazers_count + '</div>' +
            '</div>';

        if (repo.description) {
            markup += '<div>' + repo.description + '</div>';
        }

        markup += '</div></div>';

        return markup;
    }

    var repoSelect = function formatRepoSelection(repo) {
        return repo.full_name || repo.text;
    }


    $(".ajax-data").select2({
        ajax: {
            url: "https://api.github.com/search/repositories",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    q: params.term, // search term
                    page: params.page
                };
            },
            processResults: function (data, page) {
                // parse the results into the format expected by Select2.
                // since we are using custom formatting functions we do not need to
                // alter the remote JSON data
                return {
                    results: data.items
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) {
            return markup;
        }, // let our custom formatter work
        minimumInputLength: 1,
        templateResult: repo, // omitted for brevity, see the source of this page
        templateSelection: repoSelect // omitted for brevity, see the source of this page
    });
}

function ResizeTable(tableId, sizeArr) {
    $.each(sizeArr, function (i, item) {
        $('#' + tableId + ' thead tr th:eq(' + item[0] + ')').css('min-width', item[1]).css('max-width', item[1]);
    });
}

function CheckValidLoginLocation() {
    var requestData = { locationId: loginLocationId };
    AjaxRequestWithPostAndJson(ReplaceUrl('Location', 'CheckValidLoginLocation'), JSON.stringify(requestData), function (result) {
        if (!result) {
            ShowMessage('Login on multiple Location. Please select valid Location');
            isStepValid = false;
            return false;
        }
    }, ErrorFunction, false);
    return true;
}

$('[id*="btnStep"]').click(function () {
    if (!CheckValidLoginLocation()) return false;
});

/* SSRS Report Function*/

function GetReportId(prmList) {
    var id = "";
    AjaxRequestWithPostAndJson(reportUrl.replace('ViewReport', 'GetReportId'), JSON.stringify(prmList), function (result) {
        id = result;
    }, ErrorFunction, false);
    return id;
}

function ShowReport(reportInfo) {
    var id = GetReportId(reportInfo.PrmList);
    var url = reportUrl + "/?id=" + id + "&reportName=" + reportInfo.Name + "&reportDescription=" + reportInfo.Description + "&uid=" + Math.random();
    var win = window.open(url, "", "scrollbars=yes,resizable=yes,top=50,left=50,width=1300,height=650");
    win.focus();
    return false;
}

function ShowViewPrint(documentTypeId, documentId) {
    var url = reportUrl.replace('ViewReport', 'LinkReport') + "/?documentTypeId=" + documentTypeId + "&documentId=" + documentId + "&uid=" + Math.random();
    var win = window.open(url, "", "scrollbars=yes,resizable=yes,top=50,left=50,width=1300,height=650");
    win.focus();
    return false;
}

/* SSRS */


