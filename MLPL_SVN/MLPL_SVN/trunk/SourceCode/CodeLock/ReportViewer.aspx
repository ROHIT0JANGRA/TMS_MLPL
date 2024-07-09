<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="CodeLock.ReportViewer" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="<%=ResolveClientUrl("~/Scripts/jquery-3.2.1.js") %>"></script>
    <style>
        .print-hover {
            border: 1px solid transparent;
            background-color: transparent;
        }

        .print-hover:hover {
            border: 1px solid rgb(51,102,153);
            background-color: rgb(221,238,247);
        }
    </style>
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="sm" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="rv" runat="server" ShowParameterPrompts="false" ShowPrintButton="false" Width="100%" Height="100%" AsyncRendering="false" ZoomMode="Percent" KeepSessionAlive="true" SizeToReportContent="true">
            </rsweb:ReportViewer>
        </div>
        <div class="pdf">
        </div>
         <script type="text/javascript" lang="javascript">

             $(document).ready(function () {
                 try {

                     ShowPrintButton();
                     $('#PrintButton').click(function (e) {
                         e.preventDefault();
                         PrintReport();
                     })
                 }

                 catch (e) { alert(e); }
             });



             function ShowPrintButton() {
                 var table = $("table[title='Refresh']");
                 var parentTable = $(table).parents('table');
                 var parentDiv = $(parentTable).parents('div').parents('div').first();
                 parentDiv.append('<input id="PrintButton" class="print-hover" title="Print" style="width: 16px;height: 16px;padding: 5px 5px 5px 5px !important;" type="image" alt="Print" runat="server" src="~/Reserved.ReportViewerWebControl.axd?OpType=Resource&amp;Version=11.0.3442.2&amp;Name=Microsoft.Reporting.WebForms.Icons.Print.gif" />');
             }
             // Print Report function

             function PrintReport() {



                 //get the ReportViewer Id

                 var rv1 = $('#rv_ctl09');

                 var iDoc = rv1.parents('html');



                 // Reading the report styles

                 var styles = iDoc.find("head style[id$='ReportControl_styles']").html();

                 if ((styles == undefined) || (styles == '')) {

                     iDoc.find('head script').each(function () {

                         var cnt = $(this).html();

                         var p1 = cnt.indexOf('ReportStyles":"');

                         if (p1 > 0) {

                             p1 += 15;

                             var p2 = cnt.indexOf('"', p1);

                             styles = cnt.substr(p1, p2 - p1);

                         }

                     });

                 }

                 if (styles == '') { alert("Cannot generate styles, Displaying without styles.."); }

                 styles = '<style type="text/css">' + styles + "</style>";



                 // Reading the report html

                 var table = rv1.find("div[id$='_oReportDiv']");

                 if (table == undefined) {

                     alert("Report source not found.");

                     return;

                 }



                 // Generating a copy of the report in a new window

                 var docType = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd">';

                 var docCnt = styles + table.parent().html();

                 var docHead = '<head><style>body{margin:5;padding:0;}</style></head>';

                 var winAttr = "location=yes, statusbar=no, directories=no, menubar=no, titlebar=no, toolbar=no, dependent=no, width=720, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";;

                 var newWin = window.open("", "_blank", winAttr);

                 writeDoc = newWin.document;

                 writeDoc.open();

                 writeDoc.write(docType + '<html>' + docHead + '<body onload="window.print();">' + docCnt + '</body></html>');

                 writeDoc.close();

                 newWin.focus();

                 // uncomment to autoclose the preview window when printing is confirmed or canceled.

                 // newWin.close();

             };

    </script>
    </form>
</body>
</html>