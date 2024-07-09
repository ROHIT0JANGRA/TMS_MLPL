//  
// Type: SsrsHelper
//  
//  
//  

using CodeLock.Helper;
using CodeLock;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.UI.WebControls;

public static class SsrsHelper
{
    public static ReportViewer LoadReport(
      ReportViewer rv,
      string reportName,
      List<ReportParameter> listReportParameters)
    {
        rv.ProcessingMode = ProcessingMode.Remote;
        rv.Width = (Unit)900;
        rv.Height = (Unit)600;
        rv.ServerReport.ReportServerUrl = new Uri(ConfigHelper.ReportServerUrl);
        rv.ServerReport.ReportServerCredentials = (IReportServerCredentials)new ReportCredentials(ConfigHelper.ReportServerUser, ConfigHelper.ReportServerPassword, ConfigHelper.ReportServer);
        rv.ServerReport.ReportPath = ConfigHelper.ReportServerPath + "/" + reportName;
        if (listReportParameters != null && listReportParameters.Count > 0)
            rv.ServerReport.SetParameters((IEnumerable<ReportParameter>)listReportParameters);
        rv.ServerReport.Refresh();
        return rv;
    }

    public static ReportViewer LoadReport(ReportViewer rv, string reportName)
    {
        return SsrsHelper.LoadReport(rv, reportName, new List<ReportParameter>());
    }

    public static bool ExportReportToPdf(string reportName, string filePath, List<ReportParameter> reportParameters)
    {
        try
        {

            // Create an instance of the ReportViewer control
            ReportViewer reportViewer = new ReportViewer();
            reportViewer = LoadReport(reportViewer, reportName, reportParameters);

            // Render the report as PDF
            string mimeType, encoding, fileNameExtension;
            string[] streams;
            Warning[] warnings;
            byte[] pdfBytes = reportViewer.ServerReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            // Save the PDF to a file
            //string filePath = Path.Combine(ConfigHelper.LocalStoragePath, "Reports", attachmentName + ".pdf");
            if (System.IO.Directory.Exists(Directory.GetParent(filePath).FullName)) { }
            else
            {
                System.IO.Directory.CreateDirectory(filePath);
            }

            System.IO.File.WriteAllBytes(filePath, pdfBytes);

            // Delete the temporary PDF file
            //System.IO.File.Delete(filePath);
            return true;
        }
        catch (Exception ex)
        {
            ExceptionUtility.LogException(ex, "Export Report To Pdf", SessionUtility.LoginUserId, nameof(ExportReportToPdf));
            return false;
        }
    }

}
