var drTransactionDate, txtCommentCredit, txtCommentDebit, dtChequeIssueDetailsCredit, dtChequeIssueDetailsDebit, selectedChequeList;
var txtlClearDateCredit, txtlClearDateDebit, currentDate, dateTimeFormat, txtBankBookBalance, txtBankBookBalanceDebit, txtBankBookBalanceCredit;
var ddlBankAccount, ddlLocationId, rdAll, rdReconciled, rdNotReconciled, VarBankBookBalance, VarBankBookBalanceDebit, VarBankBookBalanceCredit,VarOpnDrCR;

$(document).ready(function () {
    SetPageLoad('Banking', 'Bank Reconcilation', '', '', '');
    InitObjects();
});

function InitObjects() {
    drTransactionDate = InitDateRange('drTransactionDate', DateRange.LastWeek);
    ddlBankAccount = $("#ddlBankAccount");
    txtBankBookBalance = $("#txtBankBookBalance");
    txtBankBookBalanceDebit = $("#txtBankBookBalanceDebit");
    txtBankBookBalanceCredit = $("#txtBankBookBalanceCredit");
    txtCommentCredit = $('#txtCommentCredit');
    txtCommentDebit = $('#txtCommentDebit');
    txtlClearDateCredit = $('#txtlClearDateCredit');
    txtlClearDateDebit = $('#txtlClearDateDebit');
    ddlLocationId = $("#ddlLocationId");
    rdAll = $("#rdAll");
    rdReconciled = $("#rdReconciled");
    rdNotReconciled = $("#rdNotReconciled");
    VarBankBookBalance=0.00, VarBankBookBalanceDebit=0.00, VarBankBookBalanceCredit=0.00, VarOpnDrCR='';
    BindAccountDropDown(ddlBankAccount, 6, 'Bank');
    
    InitWizard('dvWizard', [
     { StepName: 'Criteria', StepFunction: GetChequeDetails },
     { StepName: 'Bank Reconcilation', StepFunction: CheckStepValid }
    ], 'Bank Reconcilation Done');
}

function BindAccountDropDown(ddl, category, type) {
    AjaxRequestWithPostAndJson(BankUrl, JSON.stringify({ categoryId: category }), function (result) {
        BindDropDownList(ddl.Id, result, 'Value', 'Description', '', type + ' Account');
    }, ErrorFunction, false);
}

function GetChequeDetails() {
    VarBankBookBalance = 0.00;
    VarBankBookBalanceDebit = 0.00;
    VarBankBookBalanceCredit = 0.00;
    VarOpnDrCR = '';
    selectedChequeList = [];
    var ReconcileStatusVal = "";
    var Icnt = 0;
    if (rdAll.prop("checked") == true)
        ReconcileStatusVal = rdAll.val();
    if (rdReconciled.prop("checked") == true)
        ReconcileStatusVal = rdReconciled.val();
    if (rdNotReconciled.prop("checked") == true)
        ReconcileStatusVal = rdNotReconciled.val();
    /*Bank Opening Balance*/
    
    var request = {
        LocationId: ddlLocationId.val(), FromDate: drTransactionDate.startDate,
        ToDate: drTransactionDate.endDate, BankAccountId: ddlBankAccount.val()
    };
    AjaxRequestWithPostAndJson(BankReconciliationUrl + '/GetOpeningBal', JSON.stringify(request), function (result) {
        txtBankBookBalance.val(result.OpengValue +'~'+ result.OpengDRCR)
        VarBankBookBalance = result.OpengValue;
        VarOpnDrCR = result.OpengDRCR;
    }, ErrorFunction, false);
    /*End Opening Balance */

    /*Debit process Start here*/
    var requestDataDebit = {
        LocationId: ddlLocationId.val(), FromDate: drTransactionDate.startDate,
        ToDate: drTransactionDate.endDate, BankAccountId: ddlBankAccount.val(),
        ReconcileStatus: ReconcileStatusVal, AmountConsederation: "Debit"
    };
    AjaxRequestWithPostAndJson(BankReconciliationUrl + '/GetChequeDetailsForBankReconciliation', JSON.stringify(requestDataDebit), function (resultDebit) {

        
        
        if (dtChequeIssueDetailsDebit == null)
            dtChequeIssueDetailsDebit = LoadDataTable('dtChequeIssueDetailsDebit', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllChequeDebit', SelectChecque), data: "ChequeId" },
                  { title: 'Cheque No', data: 'ChequeNo' },
                  { title: 'Cheque Date', data: 'ChequeDate' },
                  { title: 'Party', data: 'Party' },
                  { title: 'Voucher No', data: 'VoucherNo' },
                  { title: 'Transaction Date', data: 'VoucherDate' },
                  { title: 'Amount', data: 'Debit' },
                  { title: 'Clear Date', data: 'ClearDate', width: 200 },
                  { title: 'Comment', data: 'ClearRemarks', width: 200 },
                  { title: 'Voucher Type', data: 'VoucherType' },
                  { title: 'Narration', data: 'Narration' }
              ]);

        dtChequeIssueDetailsDebit.fnClearTable();

        if (resultDebit.length == 0) {
            isStepValid = true;
            //ShowMessage('No Record Found');
            //return false;
        }
        else {
            $.each(resultDebit, function (i, item) {
                
                Icnt = i;
                item.ChequeId = SelectAll.GetChk('chkAllChequeDebit', 'chkChequeDebit' + i, 'ChequeDetails[' + i + '].IsChecked', SelectChecque) +
                                "<input type='hidden' value='" + item.ChequeId + "' name='ChequeDetails[" + i + "].ChequeId' id='hdnChequeId" + i + "'/>" +
                                "<label class='label' for='chkChequeDebit" + i + "' id='lblChequeId" + i + "'></label>";
                item.ChequeDate = $.displayDate(item.ChequeDate);
                item.VoucherDate = $.displayDate(item.VoucherDate);
                item.Debit = '<input type=\'text\' name="ChequeDetails[' + i + '].Debit" id="txtTotalAmountDebit' + i + '" value=' + item.Debit + ' class="form-control textlabel numeric2" style="width: 100px;"/>';
                if (IsObjectNullOrEmpty(item.ClearRemarks))
                {
                    item.ClearRemarks = '<input type=\'text\' name="ChequeDetails[' + i + '].ClearRemarks" id="txtCommentDebit' + i + '"   class=" form-control" disabled/>' +
              '<span data-valmsg-for="ChequeDetails[' + i + '].ClearRemarks" value=" " data-valmsg-replace="true"></span>';
                }
                else
                {
                    item.ClearRemarks = '<input type=\'text\' name="ChequeDetails[' + i + '].ClearRemarks" id="txtCommentDebit' + i + '" value="' + item.ClearRemarks + '"  class=" form-control" disabled/>' +
              '<span data-valmsg-for="ChequeDetails[' + i + '].ClearRemarks" value=" " data-valmsg-replace="true"></span>';
                }
               
                item.ClearDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='ChequeDetails[" + i + "].ClearDate'  value='" + $.entryDate(item.ClearDate) + "'  id='txtlClearDateDebit" + i + "'class='form-control text-datetime disabled' />" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="ChequeDetails[' + i + '].ClearDate" data-valmsg-replace="true"></span></div>';

            });

            dtChequeIssueDetailsDebit.dtAddData(resultDebit);

            
            $('[id*="txtlClearDateDebit"]').each(function () {
                var txtlClearDateDebit = $(this);
                dateTimeFormat = 'DD/MM/YYYY';
                InitDateTimePicker(txtlClearDateDebit.Id, false, true, false, txtlClearDateDebit.val(), dateTimeFormat, '', '');
                //InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });
            
            $('[id*="chkChequeDebit"]').change(function () {
                var chkChequeDebit = $(this);
                var chkChequeDebit = $(this);
                var chktf = chkChequeDebit.is(":checked");
                chkChequeDebit.val(chktf);
                var txtReasonDebit = $('#' + chkChequeDebit.Id.replace('chkChequeDebit', 'txtCommentDebit'));
                var txtlClearDateDebit = $('#' + chkChequeDebit.Id.replace('chkChequeDebit', 'txtlClearDateDebit'));
                txtReasonDebit.enable(chkChequeDebit.IsChecked).val('');
                txtlClearDateDebit.enable(chkChequeDebit.IsChecked).val('');
                if (chkChequeDebit.IsChecked) {
                    AddRequired(txtReasonDebit, 'Enter Comment');
                    txtReasonDebit.val(txtCommentDebit.val());
                    AddRequired(txtlClearDateDebit, 'Enter Clear Date');
                    txtlClearDateDebit.val(txtCommentDebit.val());
                }
                else
                    RemoveRequired(txtReasonDebit);
                RemoveRequired(txtlClearDateDebit);
            });
            txtCommentDebit.blur(OnClearRemarksChange);
        
        }
    }, ErrorFunction, false);
    /*Debit process End here*/
    AllSelectChecqueDebit();

    /*Credit process start here*/
    var requestDataCredit = {
        LocationId: ddlLocationId.val(), FromDate: drTransactionDate.startDate,
        ToDate: drTransactionDate.endDate, BankAccountId: ddlBankAccount.val(),
        ReconcileStatus: ReconcileStatusVal, AmountConsederation: "credit"
    };
    AjaxRequestWithPostAndJson(BankReconciliationUrl + '/GetChequeDetailsForBankReconciliation', JSON.stringify(requestDataCredit), function (result) {

        

        if (dtChequeIssueDetailsCredit == null)
            dtChequeIssueDetailsCredit = LoadDataTable('dtChequeIssueDetailsCredit', false, false, false, null, null, [],
              [
                  { title: SelectAll.GetChkAll('chkAllChequeCredit', SelectChecque), data: "ChequeId" },
                  { title: 'Cheque No', data: 'ChequeNo' },
                  { title: 'Cheque Date', data: 'ChequeDate' },
                  { title: 'Party', data: 'Party' },
                  { title: 'Voucher No', data: 'VoucherNo' },
                  { title: 'Transaction Date', data: 'VoucherDate' },
                  { title: 'Amount', data: 'Credit' },
                  { title: 'Clear Date', data: 'ClearDate', width: 200 },
                  { title: 'Comment', data: 'ClearRemarks', width: 200 },
                  { title: 'Voucher Type', data: 'VoucherType' },
                  { title: 'Narration', data: 'Narration' }
              ]);

        dtChequeIssueDetailsCredit.fnClearTable();

        if (result.length == 0) {
            isStepValid = true;
            //ShowMessage('No Record Found');
            //return false;
        }
        else {
            $.each(result, function (i, item) {
                if (parseFloat(Icnt) == 0)
                {
                    Icnt = i;
                }
                else
                {
                    Icnt = Icnt + 1;
                }
                
                
                item.ChequeId = SelectAll.GetChk('chkAllChequeCredit', 'chkChequeCredit' + Icnt, 'ChequeDetails[' + Icnt + '].IsChecked', SelectChecque) +
                                "<input type='hidden' value='" + item.ChequeId + "' name='ChequeDetails[" + Icnt + "].ChequeId' id='hdnChequeId" + Icnt + "'/>" +
                                "<label class='label' for='chkChequeCredit" + Icnt + "' id='lblChequeId" + Icnt + "'></label>";
                item.ChequeDate = $.displayDate(item.ChequeDate);
                item.VoucherDate = $.displayDate(item.VoucherDate);
                item.Credit = '<input type=\'text\' name="ChequeDetails[' + Icnt + '].Credit" id="txtTotalAmountCredit' + Icnt + '" value=' + item.Credit + ' class="form-control textlabel numeric2" style="width: 100px;"/>';
                if (IsObjectNullOrEmpty(item.ClearRemarks))
                {
                    item.ClearRemarks = '<input type=\'text\' name="ChequeDetails[' + Icnt + '].ClearRemarks" id="txtCommentCredit' + Icnt + '"    class=" form-control" disabled/>' +
                         '<span data-valmsg-for="ChequeDetails[' + Icnt + '].ClearRemarks" value=" " data-valmsg-replace="true"></span>';
                }
                else
                {
                    item.ClearRemarks = '<input type=\'text\' name="ChequeDetails[' + Icnt + '].ClearRemarks" id="txtCommentCredit' + Icnt + '" value="' + item.ClearRemarks + '"   class=" form-control" disabled/>' +
                         '<span data-valmsg-for="ChequeDetails[' + Icnt + '].ClearRemarks" value=" " data-valmsg-replace="true"></span>';
                };
                
               
                item.ClearDate = "<div class='input'>" +
                                    '<label class="icon-right"><i class="zmdi zmdi-calendar"></i></label>' +
                                        "<input type='text' name='ChequeDetails[" + Icnt + "].ClearDate'  value='" + $.entryDate(item.ClearDate) + "'  id='txtlClearDateCredit" + Icnt + "'class='form-control text-datetime disabled' />" +
                                  '</div>' +
                                  '<div><span data-valmsg-for="ChequeDetails[' + Icnt + '].ClearDate" data-valmsg-replace="true"></span></div>';
               

            });
            
            dtChequeIssueDetailsCredit.dtAddData(result);

            $('[id*="txtlClearDateCredit"]').each(function () {
                var txtlClearDateCredit = $(this);
                dateTimeFormat='DD/MM/YYYY';
                InitDateTimePicker(txtlClearDateCredit.Id, false, true, false, txtlClearDateCredit.val(), dateTimeFormat, '', '');
                //InitDateTimePicker(txtCancelDate.Id, false, true, true, currentDate, dateTimeFormat, '', '');
            });

            

            $('[id*="chkChequeCredit"]').change(function () {
                var chkChequeCredit = $(this);
                var chkChequeCredit = $(this);
                var chktf = chkChequeCredit.is(":checked");
                chkChequeCredit.val(chktf);
                
                var txtReasonCredit = $('#' + chkChequeCredit.Id.replace('chkChequeCredit', 'txtCommentCredit'));
                var txtlClearDateCredit = $('#' + chkChequeCredit.Id.replace('chkChequeCredit', 'txtlClearDateCredit'));
                txtReasonCredit.enable(chkChequeCredit.IsChecked).val('');
                txtlClearDateCredit.enable(chkChequeCredit.IsChecked).val('');
                if (chkChequeCredit.IsChecked) {
                    
                    AddRequired(txtReasonCredit, 'Enter Comment');
                    txtReasonCredit.val(txtCommentCredit.val());
                    AddRequired(txtlClearDateCredit, 'Enter Clear Date');
                    txtlClearDateCredit.val(txtCommentCredit.val());
                }
                else
                    
                    RemoveRequired(txtReasonCredit);
                    RemoveRequired(txtlClearDateCredit);
            });
            txtCommentCredit.blur(OnClearRemarksChange);
           
            

        }
    }, ErrorFunction, false);
    /*Credit process End  here*/

    AllSelectChecqueCredit();
    
    
    return false;


}



function OnClearRemarksChange() {
    $('[id*="chkChequeCredit"]').each(function () {
        var chkChequeCredit = $(this);
        var txtReasonCredit = $('#' + chkChequeCredit.Id.replace('chkChequeCredit', 'txtCommentCredit'));
        if (chkChequeCredit.IsChecked)
            txtReasonCredit.val(txtCommentCredit.val());
    });
}

function OnClearRemarksChangeDebit() {
    $('[id*="chkChequeDebit"]').each(function () {
        var chkChequeDebit = $(this);
        var txtReasonDebit = $('#' + chkChequeDebit.Id.replace('chkChequeDebit', 'txtCommentDebit'));
        if (chkChequeDebit.IsChecked)
            txtReasonDebit.val(txtCommentDebit.val());
    });
}



function SelectChecque() {
    selectedChequeList = [];
    var totalDebit = 0;
     VarBankBookBalanceDebit = 0;
    $('#txtBankBookBalanceDebit').val(0);

     VarBankBookBalanceCredit = 0;
    $('#txtBankBookBalanceCredit').val(0);


    $('[id*="chkChequeDebit"]').each(function () {
        var chkChequeDebit = $(this);
        var chktf = chkChequeDebit.is(":checked");
        chkChequeDebit.val(chktf);
        var txtTotalAmountDebit = $('#' + chkChequeDebit.Id.replace('chkChequeDebit', 'txtTotalAmountDebit'));

        if (chkChequeDebit.IsChecked) {

            selectedChequeList.push($('#' + chkChequeDebit.Id.replace('chkChequeDebit', 'hdnChequeId')).val());
            totalDebit = totalDebit + parseFloat(txtTotalAmountDebit.val());

        }
    });

    totalDebit = totalDebit.toFixed(2);
    $('#txtTotalChequeAmountDebit').val(totalDebit);
    if (VarOpnDrCR == "DR")
    {
        
        VarBankBookBalanceDebit = parseFloat(totalDebit) + parseFloat(VarBankBookBalance);
        VarBankBookBalanceDebit = VarBankBookBalanceDebit.toFixed(2);
        $('#txtBankBookBalanceDebit').val(VarBankBookBalanceDebit + '~' + VarOpnDrCR);
        
        
    }
    else
    {
        if (parseFloat(totalDebit) > parseFloat(VarBankBookBalance))
        {
            
            VarBankBookBalanceDebit = parseFloat(totalDebit) - parseFloat(VarBankBookBalance);
            VarBankBookBalanceDebit = Math.abs(VarBankBookBalanceDebit.toFixed(2));
            $('#txtBankBookBalanceDebit').val(VarBankBookBalanceDebit + '~' + VarOpnDrCR);
            
        }
        else
        {
            
            VarBankBookBalanceDebit = parseFloat(VarBankBookBalance) - parseFloat(totalDebit);
            VarBankBookBalanceDebit = Math.abs(VarBankBookBalanceDebit.toFixed(2));
            $('#txtBankBookBalanceDebit').val(VarBankBookBalanceDebit + '~' + VarOpnDrCR);
            
        }
        
    }
    

    var totalCredit = 0;
    $('[id*="chkChequeCredit"]').each(function () {
        var chkChequeCredit = $(this);
        var chktf = chkChequeCredit.is(":checked");
        chkChequeCredit.val(chktf);
        var txtTotalAmountCredit = $('#' + chkChequeCredit.Id.replace('chkChequeCredit', 'txtTotalAmountCredit'));

        if (chkChequeCredit.IsChecked) {

            selectedChequeList.push($('#' + chkChequeCredit.Id.replace('chkChequeCredit', 'hdnChequeId')).val());
            totalCredit = totalCredit + parseFloat(txtTotalAmountCredit.val());

        }
    });

    totalCredit = totalCredit.toFixed(2);
    $('#txtTotalChequeAmountCredit').val(totalCredit);

    if (VarOpnDrCR == "DR") {
        
        if (parseFloat(totalCredit) > parseFloat(VarBankBookBalanceDebit)) {
            
            VarBankBookBalanceCredit = parseFloat(totalCredit) - parseFloat(VarBankBookBalanceDebit);
            VarBankBookBalanceCredit = Math.abs(VarBankBookBalanceCredit.toFixed(2));
            $('#txtBankBookBalanceCredit').val(VarBankBookBalanceCredit + '~' + 'CR');
            
        }
        else {
            
            VarBankBookBalanceCredit = parseFloat(VarBankBookBalanceDebit) - parseFloat(totalCredit);
            VarBankBookBalanceCredit = Math.abs(VarBankBookBalanceCredit.toFixed(2));
            $('#txtBankBookBalanceCredit').val(VarBankBookBalanceCredit + '~' + 'DR');
            
        }

    }
    else {
        if (parseFloat(totalCredit) > parseFloat(VarBankBookBalanceDebit)) {
            
            VarBankBookBalanceCredit = parseFloat(totalCredit) - parseFloat(VarBankBookBalanceDebit);
            VarBankBookBalanceCredit = Math.abs(VarBankBookBalanceCredit.toFixed(2));
            $('#txtBankBookBalanceCredit').val(VarBankBookBalanceCredit + '~' + VarOpnDrCR);
            
        }
        else {
            
            VarBankBookBalanceCredit = parseFloat(VarBankBookBalanceDebit) - parseFloat(totalCredit);
            VarBankBookBalanceCredit = Math.abs(VarBankBookBalanceCredit.toFixed(2));
            $('#txtBankBookBalanceCredit').val(VarBankBookBalanceCredit + '~' + VarOpnDrCR);
            
        }

    }

    
}


function CheckStepValid() {
        
    if (selectedChequeList.length == 0) {
        isStepValid = false;
        ShowMessage('Please select at least one Record');
        return false;
    }
 
}


function AllSelectChecqueCredit() {
    //selectedChequeList = [];
    
    VarBankBookBalanceCredit = 0;
    $('#txtBankBookBalanceCredit').val(0);
    var totalCredit = 0;
    $('[id*="chkChequeCredit"]').each(function () {
        
        var chkChequeCredit = $(this);
        var txtTotalAmountCredit = $('#' + chkChequeCredit.Id.replace('chkChequeCredit', 'txtTotalAmountCredit'));
        selectedChequeList.push($('#' + chkChequeCredit.Id.replace('chkChequeCredit', 'hdnChequeId')).val());
        totalCredit = totalCredit + parseFloat(txtTotalAmountCredit.val());
        $(chkChequeCredit).prop("checked", true);
        //$('#chkAllDocket').disable();
        $('#chkAllChequeCredit').prop("checked", true);
        var txtReasonCredit = $('#' + chkChequeCredit.Id.replace('chkChequeCredit', 'txtCommentCredit'));
        var txtlClearDateCredit = $('#' + chkChequeCredit.Id.replace('chkChequeCredit', 'txtlClearDateCredit'));
        txtReasonCredit.enable(chkChequeCredit.IsChecked);
        txtlClearDateCredit.enable(chkChequeCredit.IsChecked);
        AddRequired(txtReasonCredit, 'Enter Comment');
        AddRequired(txtlClearDateCredit, 'Enter Clear Date');
    });
    
    totalCredit = totalCredit.toFixed(2);
    $('#txtTotalChequeAmountCredit').val(totalCredit);

    if (VarOpnDrCR == "DR") {
        
        if (parseFloat(totalCredit) > parseFloat(VarBankBookBalanceDebit)) {
            
            
            
            VarBankBookBalanceCredit = parseFloat(totalCredit) - parseFloat(VarBankBookBalanceDebit);
            VarBankBookBalanceCredit = Math.abs(VarBankBookBalanceCredit.toFixed(2));
            $('#txtBankBookBalanceCredit').val(VarBankBookBalanceCredit + '~' + 'CR');
            
        }
        else {
            
            VarBankBookBalanceCredit = parseFloat(VarBankBookBalanceDebit)-parseFloat(totalCredit) ;
            VarBankBookBalanceCredit = Math.abs(VarBankBookBalanceCredit.toFixed(2));
            $('#txtBankBookBalanceCredit').val(VarBankBookBalanceCredit + '~' + 'DR');
            
        }

    }
    else {
        if (parseFloat(totalCredit) > parseFloat(VarBankBookBalanceDebit)) {
            
            VarBankBookBalanceCredit = parseFloat(totalCredit) - parseFloat(VarBankBookBalanceDebit);
            VarBankBookBalanceCredit = Math.abs(VarBankBookBalanceCredit.toFixed(2));
            $('#txtBankBookBalanceCredit').val(VarBankBookBalanceCredit + '~' + VarOpnDrCR);
            
        }
        else {
            
            VarBankBookBalanceCredit = parseFloat(VarBankBookBalanceDebit) - parseFloat(totalCredit);
            VarBankBookBalanceCredit = Math.abs(VarBankBookBalanceCredit.toFixed(2));
            $('#txtBankBookBalanceCredit').val(VarBankBookBalanceCredit + '~' + VarOpnDrCR);
            
        }

    }
    
}

function AllSelectChecqueDebit() {
    //selectedChequeList = [];
   
    var totalDebit = 0;
     VarBankBookBalanceDebit = 0;
    var totalDebit = 0;
    $('[id*="chkChequeDebit"]').each(function () {

        var chkChequeDebit = $(this);
        var txtTotalAmountDebit = $('#' + chkChequeDebit.Id.replace('chkChequeDebit', 'txtTotalAmountDebit'));
        selectedChequeList.push($('#' + chkChequeDebit.Id.replace('chkChequeDebit', 'hdnChequeId')).val());
        totalDebit = totalDebit + parseFloat(txtTotalAmountDebit.val());
        $(chkChequeDebit).prop("checked", true);
        //$('#chkAllDocket').disable();
        $('#chkAllChequeDebit').prop("checked", true);
        var txtReasonDebit = $('#' + chkChequeDebit.Id.replace('chkChequeDebit', 'txtCommentDebit'));
        var txtlClearDateDebit = $('#' + chkChequeDebit.Id.replace('chkChequeDebit', 'txtlClearDateDebit'));
        txtReasonDebit.enable(chkChequeDebit.IsChecked);
        txtlClearDateDebit.enable(chkChequeDebit.IsChecked);
        AddRequired(txtReasonDebit, 'Enter Comment');
        AddRequired(txtlClearDateDebit, 'Enter Clear Date');
    });
    
    totalDebit = totalDebit.toFixed(2);
    $('#txtTotalChequeAmountDebit').val(totalDebit);

    if (VarOpnDrCR == "DR") {
        
        VarBankBookBalanceDebit = parseFloat(totalDebit) + parseFloat(VarBankBookBalance);
        VarBankBookBalanceDebit = VarBankBookBalanceDebit.toFixed(2);
        $('#txtBankBookBalanceDebit').val(VarBankBookBalanceDebit + '~' + VarOpnDrCR);
        

    }
    else {
        if (parseFloat(totalDebit) > parseFloat(VarBankBookBalance)) {
            
            VarBankBookBalanceDebit = parseFloat(totalDebit) - parseFloat(VarBankBookBalance);
            VarBankBookBalanceDebit = Math.abs(VarBankBookBalanceDebit.toFixed(2));
            $('#txtBankBookBalanceDebit').val(VarBankBookBalanceDebit + '~' + VarOpnDrCR);
            
        }
        else {
            
            VarBankBookBalanceDebit = parseFloat(VarBankBookBalance) - parseFloat(totalDebit);
            VarBankBookBalanceDebit = Math.abs(VarBankBookBalanceDebit.toFixed(2));
            $('#txtBankBookBalanceDebit').val(VarBankBookBalanceDebit + '~' + VarOpnDrCR);
            
        }

    }

    
}