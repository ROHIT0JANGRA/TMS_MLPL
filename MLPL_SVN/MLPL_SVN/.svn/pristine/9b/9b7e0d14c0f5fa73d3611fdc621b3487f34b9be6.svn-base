var isStepValid = true;
var wizard;
function InitWizard(divId, stepInfo, submitButtonText) {

    submitButtonText = (submitButtonText != undefined && submitButtonText != null) ? submitButtonText : 'Submit';

    $('#' + divId).find('.tab-pane').each(function (i) {
        $(this).attr('id', i + 1);
        if (i == 0) $(this).addClass('active');
    });

    $('#' + divId).find('.panel-body').wrap('<div class="panel bs-wizard bs-wizard-steps-with-progress"/>');

    var headerContent = "";
    $.each(stepInfo, function (i, item) {
        headerContent +=
            '<li class="step' + (i == 0 ? ' active' : '') + '" data-title="' + item.StepName + '">' +
            '<a href="#' + (i + 1) + '" data-toggle="tab" class="btn btn-primary" aria-expanded="true">' + (i + 1) + '</a>' +
            '</li>';
    });

    headerContent =
        '<div class="panel-heading">' +
        '<div class="panel-title text-center">NA</div>' +
        '<div class="steps-centered">' +
        '<div class="progress progress-striped">' +
        '<div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 16.6667%;">' +
        '</div>' +
        '</div>' +
        '<ul class="wizard-steps nav-wizard">' +
        headerContent +
        '</ul>' +
        '</div>' +
        '</div>';

    var footerContent = '<div class="panel-footer">' +
        '<ul class="wizard clearfix">' +
        '<li class="bs-wizard-prev pull-left disabled" style="display: none;"><button class="btn btn-info" type="button">Previous</button></li>' +
        '<li class="bs-wizard-next pull-right"><button class="btn btn-primary" type="button">Next</button></li>' +
        '</ul>' +
        '<input type="hidden" class="bs-wizard-submit-name" value="' + submitButtonText + '" />' +
        '</div>';

    $('#' + divId).find('.panel-body').before(headerContent);
    $('#' + divId).find('.panel-body').after(footerContent);
    FormWizard.init(divId, stepInfo);
}

var FormWizard = {
    manageFormElements: function (tab, navigation, index) {
        try {
            var countSteps = tab.parents('.panel:first').find('.nav-wizard li').length;
            var currentStep = index + 1;

            var nextButton = tab.parents('.panel:first').find('.bs-wizard-next').find('button');
            nextButton.text(countSteps != currentStep ? 'Next' : tab.parents('.panel:first').find('.bs-wizard-submit-name').val());
            nextButton.showHide(nextButton.text() != '');
            
            

            if (currentStep == 1)
                tab.parents('.panel:first').find('.bs-wizard-prev').hide();
            else
                tab.parents('.panel:first').find('.bs-wizard-prev').show();
        }
        catch (e) {
            ShowMessage(e.message);
            return false;
        }
    },
    wizardStepsWithProgress: function (divId, stepFunctions) {
        var $bsWizardStepsWithProgress = $('#' + divId).find('.bs-wizard-steps-with-progress');
        var frm = $('#' + divId).find('form');
        var $frmValidator = frm.validate();
        $frmValidator.settings.ignore = ':not(select:visible, input:visible, textarea:visible, input:disabled)';
        wizard = $bsWizardStepsWithProgress.bootstrapWizard({
            'tabClass': 'nav-wizard',
            'nextSelector': $bsWizardStepsWithProgress.find('.bs-wizard-next'),
            'previousSelector': $bsWizardStepsWithProgress.find('.bs-wizard-prev'),
            'onNext': function (tab, navigation, index) {
                var returnValue = WizardNextStep(tab, navigation, index, frm, $frmValidator, stepFunctions);
                if (!returnValue)
                    HideLoader();
                return returnValue;
            },
            'onPrevious': function (tab, navigation, index) {
                tab.children().removeClass('btn-primary');
                tab.prev().children().removeClass('btn-success').addClass('btn-primary');
            },
            'onTabClick': function (tab, navigation, index, clickedIndex) {
                if (index < clickedIndex)
                    return false;
                tab.children().removeClass('btn-primary');
                tab.prev().children().removeClass('btn-success').addClass('btn-primary');
            },
            onTabShow: function (tab, navigation, index) {
                try {
                    tab.prev().children().removeClass('btn-primary').addClass('btn-success');
                    tab.children().addClass('btn-primary');
                    tab.parents('.panel:first').find('.panel-title').html(tab.data('title'));

                    var $total = navigation.find('li').length;
                    var $current = index + 1;
                    var $percent = ($current / $total) * 100;

                    if ($current != $total)
                        $percent = $percent - (100 / ($total * 2));

                    $bsWizardStepsWithProgress.find('.progress-bar').css({ width: $percent + '%' });

                    FormWizard.manageFormElements(tab, navigation, index);
                    HideLoader();
                    SetFieldFocus($($(".tab-pane")[index]));
                }
                catch (e) {
                    ShowMessage(e.message);
                    return false;
                }
            }
        });
    },
    init: function (divId, stepFunctions) {
        this.wizardStepsWithProgress(divId, stepFunctions);
    }
}

function WizardNextStep(tab, navigation, index, frm, $frmValidator, stepFunctions) {
    try {
        var isValid = true;
        var stepElements = $($(".tab-pane")[index - 1]).find("input:enabled,select:enabled,textarea:enabled,input[type=file]");
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
        isStepValid = true;
        if (isValid) {
            if (!CheckValidLoginLocation()) return false;
            var currentStepFunction = stepFunctions[index - 1].StepFunction;
            if (currentStepFunction != null && currentStepFunction != undefined)
                currentStepFunction.call(this, navigation);
        }
        if (!isValid || !isStepValid) {
            $frmValidator.focusInvalid();
            return false;
        }
        if (index == navigation.find('li').length) {
            tab.parents('.panel:first').find('.bs-wizard-next').find('button').hide();
            $(frm).submit();
            $(".panel-footer").hide();
        }
        else {
            tab.next().children().removeClass('btn-white');
            FormWizard.manageFormElements(tab, navigation, index);
        }
    }
    catch (e) {
        ShowMessage(e.message);
        HideLoader();
        return false;
    }
    return true;
}

function ShowHideStep(divId, stepIndex, navigation, showHide) {
    var stepCount = 0;
    stepIndex = stepIndex - 1;
    navigation.find('li:eq(' + stepIndex + ')').showHide(showHide);
    $('#' + divId).find('.step').each(function (i, item) {
        if ($(this).is(":visible")) {
            stepCount = stepCount + 1;
            $(this).find('a').text(stepCount);
        }
    });
    $($(".tab-pane")[stepIndex]).showHide(showHide);
    if (!showHide)
        $($(".tab-pane")[stepIndex]).addClass('hideStep');
    else
        $($(".tab-pane")[stepIndex]).removeClass('hideStep');
}