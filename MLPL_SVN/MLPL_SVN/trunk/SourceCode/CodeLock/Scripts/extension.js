var originalVal = $.fn.val;
$.fn.val = function () {
    var prev;
    if (arguments.length > 0) {
        prev = originalVal.apply(this, []);
    }
    var result = originalVal.apply(this, arguments);
    if (arguments.length > 0 && prev != originalVal.apply(this, []))
        $(this).focusout();
    return result;
};

Object.defineProperty(Object.prototype, "IsNullOrEmpty", {
    get: function () {
        return (this === undefined || this === null || this === "");
    }
});

Object.defineProperty(Object.prototype, "IsChecked", {
    get: function () {
        return this.is(':checked');
    }
});

Object.defineProperty(Object.prototype, "IsEnabled", {
    get: function () {
        return !$(this).prop('disabled');
    }
});

Object.defineProperty(Object.prototype, "Id", {
    get: function () {
        return $(this).attr('id');
    }
});

String.prototype.toBool = function () {
    return (/^(true|1|Yes|Y|yes|TRUE|True)$/i).test(this);
};

$.setDate = function (value) {
    return moment(value, jsDateFormat);
};

$.setTime = function (value) {
    return moment(value, jsTimeFormat);
};

$.setDateTime = function (value) {
    return moment(value, jsDateTimeFormat);
};

$.entryDate = function (value) {
    return moment(value).format(jsDateFormat);
};

$.entryDateTime = function (value) {
    return moment(value).format(jsDateTimeFormat);
};

$.displayDate = function (value) {
    return moment(value).format(jsDisplayDateFormat);
};

$.displayTime = function (value) {
    return moment(value).format(jsDisplayTimeFormat);
};

$.displayDateTime = function (value) {
    return moment(value).format(jsDisplayDateTimeFormat);
};

$.displayDateTimeToDate = function (value) {
    return moment(value, jsDisplayDateTimeFormat);
};

$.wait = function (duration, completeCallback, target) {
    $target = $(target || '<queue />');
    return $target.delay(duration).queue(function (next) { completeCallback.call($target); next(); });
}

$.fn.wait = function (duration, completeCallback) {
    return $.wait.call(this, duration, completeCallback, this);
};

$.fn.check = function (isChecked) {
    if (isChecked === undefined || isChecked === null) isChecked = true;
    this.prop('checked', isChecked);
    return this;
};

$.fn.uncheck = function () {
    this.prop('checked', false);
    return this;
};

$.fn.enable = function (isEnable) {
    if (isEnable === undefined || isEnable === null) isEnable = true;

    if (this.attr('id').substring(0, 3) == 'chk')
        if (isEnable)
            this.closest('.checkbox').removeClass("disabled-view");
        else
            this.closest('.checkbox').addClass("disabled-view");
    else if (this.attr('id').substring(0, 3) == 'rd')
        if (isEnable)
            this.closest('.radio').removeClass("disabled-view");
        else
            this.closest('.radio').addClass("disabled-view");
    else if (this.attr('id').substring(0, 3) == 'ddl')
        if (isEnable)
            this.closest('select').removeClass("disabled-view");
        else
            this.closest('select').addClass("disabled-view");

    this.prop('disabled', !isEnable);
    return this;
};

$.fn.disable = function () {
    if (this.attr('id').substring(0, 3) == 'chk')
        this.closest('.checkbox').addClass("disabled-view");
    else if (this.attr('id').substring(0, 3) == 'rd')
        this.closest('.radio').addClass("disabled-view");
    else if (this.attr('id').substring(0, 3) == 'ddl')
        this.closest('select').addClass("disabled-view");

    this.prop('disabled', true);
    return this;
};

$.fn.pointerEvent = function (isEnable) {
    if (isEnable === undefined || isEnable === null) isEnable = true;
    if (isEnable)
        $(this).css('pointer-events', '');
    else
        $(this).css('pointer-events', 'none');
    isEnable
    return this;
};

$.fn.multiVal = function () {
    var selected = this.val();
    if ($.inArray('', selected) != -1)
        return 'All';
    else
        return trim(this.val().join(','), ',');
};

$.fn.readOnly = function (isReadOnly) {
    if (isReadOnly === undefined || isReadOnly === null) isReadOnly = true;
    if (isReadOnly)
        $(this).attr('readOnly', 'readOnly').attr('tabindex', '-1');
    else
        $(this).removeAttr('readOnly').removeAttr('tabindex');
    return this;
};

$.fn.showHide = function (isShow) {
    if (isShow) this.show(); else this.hide();
    return this;
};

$.fn.trim = function () {
    $.trim(this.val());
    return this;
};

$.fn.hasAttr = function (name) {
    return this.attr(name) !== undefined;
}

$.fn.cellData = function (cellIndex) {
    return $(this).find('td:eq(' + cellIndex + ')').html().trim();
};

$.fn.rowCount = function () {
    return $('#' + $(this).attr('id') + ' > tbody > tr').length;
};

$.fn.refresh = function () {
    $(this).trigger("chosen:updated");
    return this;
};

$.fn.dtAddData = function (data, rightAlignColumnIndexes, fnInit, sizeArr, hideColumnIndexes) {
    if (data.length > 0)
        this.fnAddData(data);
    //RegisterValidation();
    var tableId = this.Id;
    $('#' + tableId + ' thead tr th').attr("tabindex", "-1");
    if (rightAlignColumnIndexes !== undefined && rightAlignColumnIndexes !== null)
        $.each(rightAlignColumnIndexes, function (i, item) {
            $('#' + tableId + ' tr td:nth-child(' + (item + 1) + ')').addClass('align-right');
        });

    if (hideColumnIndexes !== undefined && hideColumnIndexes !== null)
        $.each(hideColumnIndexes, function (i, item) {
            $('#' + tableId + ' tr td:nth-child(' + (item) + ')').showHide(false);
        });

    $('#' + tableId).find('.textlabel').each(function () {
        $(this).attr("tabindex", "-1").readOnly();
    });
    if (fnInit != null && fnInit != '' && fnInit != undefined)
        fnInit.call();
    $(this).removeClass('dataTable');
    if (sizeArr !== undefined && sizeArr !== null) {
        $.each(sizeArr, function (i, item) {
            $('#' + tableId + ' thead tr th:eq(' + item[0] + ')').css('min-width', item[1]).css('max-width', item[1]).css('width', item[1]);
        });
    }
    return this;
};

$.fn.toFloat = function () {
    var number = $(this).val().trim();
    if (number == "")
        number = 0;
    else
        number = number.toString().replace(/[^\d\.\-]/g, '');
    return parseFloat(number);
};

$.fn.toInt = function () {
    var number = $(this).val().trim();
    if (number == "")
        number = 0;
    else
        number = number.toString().replace(/[^\d\.\-]/g, '');
    return parseInt(number, 10);
};


$.fn.round = function (decimalPlace) {
    if (decimalPlace !== undefined && decimalPlace !== null) decimalPlace = 0;
    var number = $(this).val().trim();
    if (number == "")
        number = 0;
    else
        number = number.toString().replace(/[^\d\.\-]/g, '');
    number = parseFloat(number);
    return parseFloat(number.toFixed(decimalPlace));
};

$.fn.roundNo = function (decimalPlace) {
    var number = $(this);
    if (number == "")
        number = 0;
    else
        number = number.toString().replace(/[^\d\.\-]/g, '');
    number = parseFloat(number);
    return parseFloat(number.toFixed(decimalPlace));
};

$.toRound = function (number, decimalPlace) {
    if (number == "")
        number = 0;
    else
        number = number.toString().replace(/[^\d\.\-]/g, '');
    number = parseFloat(number);
    return parseFloat(number.toFixed(decimalPlace));
};

$.fn.extend({
    hasClasses: function (selectors) {
        var self = this;
        for (var i in selectors) {
            if ($(self).hasClass(selectors[i]))
                return true;
        }
        return false;
    }
});

String.prototype.count = function (char) {
    var strArr = this.split(char);
    return strArr.length - 1;
}

function setSession(name, value) {
    $.session.set(name, value);
}

$(function () {
    $.validator.addMethod('minlength', function (value, element, param) {
        var length = $.isArray(value) ? value.length : this.getLength($.trim(value), element);

        if (element.nodeName.toLowerCase() === 'select' && this.settings.rules[$(element).attr('name')].required !== false) {
            if (IsObjectNullOrEmpty($("#" + element.Id).val()))
                length = $("#" + element.Id + " option:selected").length - 1;
            return length >= param;
        }

        return this.optional(element) || length >= param;
    }, $.validator.format('Please select at least {0} things.'));
});


/* Date Function */

//return Date in Display Date Format
$.displayDate = function (value) {
    return moment(value).format(jsDisplayDateFormat);
};

//return Time in Display Time Format
$.displayTime = function (value) {
    return moment(value).format(jsDisplayTimeFormat);
};

//return DateTime in Display DateTime Format
$.displayDateTime = function (value) {
    return moment(value).format(jsDisplayDateTimeFormat);
};

$.displayDateToDateTime = function (value) {
    return value.format(jsDisplayDateTimeFormat);
};

//return Date from Display Date Format
$.displayDateToDate = function (value) {
    return moment(value, jsDisplayDateFormat);
};

//return Time from Display Time Format
$.displayTimeToDate = function (value) {
    return moment(value, jsDisplayDateFormat);
};

//return DateTime from Display DateTime Format
$.displayDateTimeToDate = function (value) {
    return moment(value, jsDisplayDateTimeFormat);
};

//return Date from Entry Date Format
$.setDate = function (value) {
    return moment(value, jsDateFormat);
};

//return Time from Entry Time Format
$.setTime = function (value) {
    return moment(value, jsTimeFormat);
};

//return DateTime from Entry DateTime Format
$.setDateTime = function (value) {
    return moment(value, jsDateTimeFormat);
};

//return Date in Entry DateTime Format
$.entryDate = function (value) {
    return moment(value).format(jsDateFormat);
};

//return Time in Entry Time Format
$.entryTime = function (value) {
    return moment(value).format(jsDateFormat);
};

//return DateTime in Entry DateTime Format
$.entryDateTime = function (value) {
    return moment(value).format(jsDateTimeFormat);
};

//Textbox to Date object
$.fn.toDate = function () {
    return moment($(this).val(), jsDateFormat);
};

//Textbox to Time object
$.fn.toTime = function () {
    return moment($(this).val(), jsTimeFormat);
};

//Textbox to DateTime object
$.fn.toDateTime = function () {
    return moment($(this).val(), jsDateTimeFormat);
};

/* End Date Function */