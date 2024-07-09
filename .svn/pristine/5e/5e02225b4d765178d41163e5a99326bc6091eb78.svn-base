using CodeLock.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace CodeLock
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        public List<ReportParameter> reportParameters
        {
            get
            {
                return this.ViewState[nameof(reportParameters)] != null ? this.ViewState[nameof(reportParameters)] as List<ReportParameter> : (List<ReportParameter>)null;
            }
            set
            {
                this.ViewState[nameof(reportParameters)] = (object)value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;

            if (!string.IsNullOrEmpty(this.Request.QueryString.Get("Id")) && this.reportParameters == null)
            {
                List<AutoCompleteResult> autoCompleteResultList = (List<AutoCompleteResult>)this.Session[this.Request.QueryString.Get("Id")];
                if (autoCompleteResultList != null && autoCompleteResultList.Count > 0)
                {
                    this.reportParameters = new List<ReportParameter>();
                    autoCompleteResultList.ForEach((Action<AutoCompleteResult>)(m => this.reportParameters.Add(new ReportParameter(m.Name, m.Value))));
                    this.Session.Remove(this.Request.QueryString.Get("Id"));
                }
            }
            SsrsHelper.LoadReport(this.rv, this.Request["ReportName"].ToString(), this.reportParameters);
        }
    }
}