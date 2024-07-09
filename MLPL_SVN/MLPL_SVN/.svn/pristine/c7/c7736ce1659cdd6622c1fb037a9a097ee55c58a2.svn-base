using ClosedXML.Excel;
using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Reports.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Linq;

namespace CodeLock.Areas.Reports.Controllers
{
    public class FinanceController : Controller
    {
        private readonly IOperationRepository operationRepository;
        private readonly IAccountCategoryRepository accountCategoryRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IStateRepository stateRepository;
        private readonly ISacRepository sacRepository;
        private readonly IAccountGroupRepository accountGroupRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IVendorRepository vendorRepository;
        private readonly IUserRepository userRepository;
        private readonly IDriverRepository driverRepository;
        private readonly IRulesRepository rulesRepository;
        private readonly IFinanceRepository financeRepository;

        public FinanceController()
        {
        }

        public FinanceController(IOperationRepository _operationRepository, IAccountCategoryRepository _accountCategoryRepository, IAccountRepository _accountRepository,
            ILocationRepository _locationRepository, ICompanyRepository _companyRepository, IGeneralRepository _generalRepository,
            IStateRepository _stateRepository, ISacRepository _sacRepository,
            ICustomerRepository _customerRepository, IVendorRepository _vendorRepository,
            IUserRepository _userRepository, IDriverRepository _driverRepository,
             IAccountGroupRepository _accountGroupRepository, IRulesRepository _rulesRepository, 
             IFinanceRepository _financeRepository)
        {
            this.operationRepository = _operationRepository;
            this.accountCategoryRepository = _accountCategoryRepository;
            this.accountRepository = _accountRepository;
            this.locationRepository = _locationRepository;
            this.companyRepository = _companyRepository;
            this.generalRepository = _generalRepository;
            this.stateRepository = _stateRepository;
            this.sacRepository = _sacRepository;
            this.customerRepository = _customerRepository;
            this.vendorRepository = _vendorRepository;
            this.userRepository = _userRepository;
            this.driverRepository = _driverRepository;
            this.accountGroupRepository = _accountGroupRepository;
            this.rulesRepository = _rulesRepository;
            this.financeRepository = _financeRepository;
        }
        public ActionResult AdvanceTrialBalanceReport()
        {
            AdvanceTrialBalance objAdvanceTrialBalance = new AdvanceTrialBalance();
            objAdvanceTrialBalance.CompanyId = SessionUtility.CompanyId;
            objAdvanceTrialBalance.FinYear = SessionUtility.FinYear;
            IEnumerable<AutoCompleteResult> accountList = this.accountRepository.GetAllAccountCodeList();
            foreach (var item in accountList)
            {
                item.Name = item.Name + " : " + item.Description;
            }

            ViewBag.AccountCategoryList = JsonConvert.SerializeObject(accountCategoryRepository.GetAccountCategoryList());
            ViewBag.AccountGroupList = JsonConvert.SerializeObject(accountGroupRepository.GetAccountGroupList());
            ViewBag.AccountList = JsonConvert.SerializeObject(accountList);
            ViewBag.LocationList = locationRepository.GetLocationList();
            ViewBag.CustomerList = JsonConvert.SerializeObject(customerRepository.GetCustomerList());
            ViewBag.VendorList = JsonConvert.SerializeObject(vendorRepository.GetVendorNameList());
            ViewBag.EmployeeList = JsonConvert.SerializeObject(userRepository.GetUserList());
            ViewBag.DriverList = JsonConvert.SerializeObject(driverRepository.GetDriverList());
            return View(objAdvanceTrialBalance);
        }
        public ActionResult ExpenseRegister()
        {
            ExpenseRegister ExpenseRegister = new ExpenseRegister();
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            return base.View(ExpenseRegister);
        }
        public ActionResult BillRegister()
        {
            return base.View(new BillRegister());
        }

        public ActionResult CashBankStatementRegister()
        {
            GeneralLedger generalLedger = new GeneralLedger();
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).AccountCategoryList = this.accountCategoryRepository.GetAccountCategoryList();
            ((dynamic)base.ViewBag).AccountList = this.accountRepository.GetAccountListByAccountCategoryId(6);
            return base.View(generalLedger);
        }

        public ActionResult CustomerContractManagement()
        {
            CustomerContractManagement customerContractManagement = new CustomerContractManagement();
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            return base.View(customerContractManagement);
        }

        public ActionResult CustomerOutstandingLocationWiseSummary()
        {
            CustomerOutstanding customerOutstanding = new CustomerOutstanding();
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            return base.View(customerOutstanding);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.operationRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.generalRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.accountRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.accountCategoryRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.companyRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.locationRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.stateRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GeneralLedger()
        {
            GeneralLedger generalLedger = new GeneralLedger()
            {
                CompanyId = SessionUtility.CompanyId,
                FinYear = SessionUtility.FinYear
            };
            ((dynamic)base.ViewBag).AccountCategoryList = this.accountCategoryRepository.GetAccountCategoryList();
            IEnumerable<AutoCompleteResult> accountList = this.accountRepository.GetAllAccountCodeList();
            foreach (var item in accountList)
            {
                item.Name = item.Name + " : " + item.Description;
            }
            ViewBag.AccountList = JsonConvert.SerializeObject(accountList);
            return base.View(generalLedger);
        }

        public ActionResult GstBillRegister()
        {
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).BillTypeList = this.generalRepository.GetByIdList(68);
            ((dynamic)base.ViewBag).SacList = this.sacRepository.GetSacList();
            ((dynamic)base.ViewBag).GstRateList = this.sacRepository.GetGstRateList();
            return base.View(new GstBillRegister());
        }

        public ActionResult InvoiceCollectionRegister()
        {
            InvoiceCollectionRegister invoiceCollectionRegister = new InvoiceCollectionRegister()
            {
                Document = true
            };
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(invoiceCollectionRegister);
        }

        public ActionResult ProfitLoss()
        {
            ProfitLoss profitLoss = new ProfitLoss()
            {
                CompanyId = SessionUtility.CompanyId,
                FinYear = SessionUtility.FinYear
            };
            return base.View(profitLoss);
        }

        public ActionResult TrialBalance()
        {
            TrialBalance trialBalance = new TrialBalance()
            {
                CompanyId = SessionUtility.CompanyId,
                FinYear = SessionUtility.FinYear
            };
            ((dynamic)base.ViewBag).AccountCategoryList = this.accountCategoryRepository.GetAccountCategoryList();
            return base.View(trialBalance);
        }

        public ActionResult VendorOutstanding()
        {
            VendorOutstanding vendorOutstanding = new VendorOutstanding();
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).BillTypeList = this.generalRepository.GetByIdList(28);
            return base.View(vendorOutstanding);
        }

        public ActionResult VoucherRegister()
        {
            VoucherRegister voucherRegister = new VoucherRegister();
            ((dynamic)base.ViewBag).VoucherTypeList = this.generalRepository.GetByIdList(67);
            return base.View(voucherRegister);
        }

        public ActionResult BankReconciliationRegister()
        {
            return (ActionResult)this.View((object)new BankReconcilation());
        }

        public ActionResult AdviceRegister()
        {
            return base.View(new Advice());
        }

        public ActionResult ChequeRegister()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(new ChequeRegister());
        }
        public ActionResult FinanceDayWiseReport()
        {
            FinanceDayWiseReport financeDayWiseReport = new FinanceDayWiseReport();
            ((dynamic)base.ViewBag).PartyTypeList = this.generalRepository.GetByIdList(11);
            ((dynamic)base.ViewBag).UseTransportModeFTL = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3);
            ((dynamic)base.ViewBag).ModuleTypeList = this.generalRepository.GetByIdList(101);
            return base.View(financeDayWiseReport);
        }

        public ActionResult DownloadReport()
        {
            DownloadFinanceReport downloadFinanceReport = new DownloadFinanceReport();
            ((dynamic)base.ViewBag).ReportList = this.generalRepository.GetByIdList(302);
            return base.View(downloadFinanceReport);
        }

        [HttpGet]
        public FileResult DownloadExcel(DateTime fromDate, DateTime toDate, short reportTypeId, short locationId, bool isCumulative, long CustomerId)
        {
            DataTable dt = new DataTable();
            string ReportName = string.Empty;

            if (reportTypeId == 1)
            {
                ReportName = "SalesRegisterReport.xlsx";
                dt = SalesRegisterReport(fromDate, toDate, locationId, isCumulative, CustomerId);
            }

            if (reportTypeId == 2)
            {
                ReportName = "ExpenseRegisterReport.xlsx";
                dt = ExpenseRegisterReport(fromDate, toDate, locationId, isCumulative, CustomerId);
            }

            if (reportTypeId == 3)
            {
                ReportName = "CustomerUnbilledRegisterReport.xlsx";
                dt = CustomerUnbilledRegisterReport(fromDate, toDate, locationId, isCumulative, CustomerId);
            }

            if (reportTypeId == 4)
            {
                ReportName = "VendorUnbilledRegisterReport.xlsx";
                dt = VendorUnbilledRegisterReport(fromDate, toDate, locationId, isCumulative, CustomerId);
            }
            if (reportTypeId == 6)
            {
                ReportName = "SalesInvoiceRegisterReport.xlsx";
                dt = SalesInvoiceRegisterReport(fromDate, toDate, locationId, isCumulative, CustomerId);
            }
            if (reportTypeId == 7)
            {
                ReportName = "AutorenewalEwayBill.xlsx";
                dt = AutorenewalEwayBill(fromDate, toDate, locationId, isCumulative, CustomerId);
            }
            if (reportTypeId == 8)
            {
                ReportName = "AutorenewalEwayBillError.xlsx";
                dt = AutorenewalEwayBillError(fromDate, toDate, locationId, isCumulative, CustomerId);
            }

            if (reportTypeId == 9)
            {
                ReportName = "SalesRegisterReportWithPartDetails.xlsx";
                dt = SalesRegisterReportWithPartDetails(fromDate, toDate, locationId, isCumulative, CustomerId);
            }

            //
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ReportName);
                }
            }
        }


        protected DataTable SalesRegisterReport(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DataColumn dt;

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("SalesRegister");

            IEnumerable<SalesRegisterExcelData> salesRegisterReport = this.financeRepository.GetSalesRegisterReportData(fromDate, toDate, locationId, isCumulative, CustomerId);

            dt = new DataColumn();
            dt.Caption = "Sr No.";
            dt.ColumnName = "SrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "LR No.";
            dt.ColumnName = "LRNo";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Pickup ID";
            //dt.ColumnName = "PickupID";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Docket Date";
            dt.ColumnName = "DocketDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Origin";
            dt.ColumnName = "Origin";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "From City";
            dt.ColumnName = "FromCity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "To City";
            dt.ColumnName = "ToCity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Transport Mode";
            dt.ColumnName = "TransportMode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Booking Type";
            dt.ColumnName = "BookingType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Business Type";
            dt.ColumnName = "BusinessType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignor Name";
            dt.ColumnName = "ConsignorName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignee Name";
            dt.ColumnName = "ConsigneeName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Billing Party Name";
            dt.ColumnName = "BillingPartyName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Ftl Type";
            dt.ColumnName = "FtlType";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Tripsheet No";
            //dt.ColumnName = "TripsheetNo";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Packages";
            dt.ColumnName = "Packages";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Actual Weight";
            dt.ColumnName = "ActualWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Charged Weight";
            dt.ColumnName = "ChargedWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Sub Total";
            dt.ColumnName = "SubTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Tax Total";
            dt.ColumnName = "TaxTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Grand Total";
            dt.ColumnName = "GrandTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Bill No";
            dt.ColumnName = "BillNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Bill Date";
            dt.ColumnName = "BillDate";
            dsExport.Tables[0].Columns.Add(dt);

            int i = 0;

            foreach (var item in salesRegisterReport)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                dr["SrNo"] = (i + 1).ToString();
                dr["LRNo"] = item.LRNo;
                dr["DocketDate"] = item.DocketDate;
                //dr["PickupID"] = item.PickupID;
                dr["Origin"] = item.Origin;
                dr["FromCity"] = item.FromCity;
                dr["ToCity"] = item.ToCity;
                dr["TransportMode"] = item.TransportMode;
                dr["BookingType"] = item.BookingType;
                dr["BusinessType"] = item.BusinessType;
                dr["ConsignorName"] = item.ConsignorName;
                dr["ConsigneeName"] = item.ConsigneeName;
                dr["BillingPartyName"] = item.BillingPartyName;
                dr["FtlType"] = item.FtlType;
                //dr["TripsheetNo"] = item.TripsheetNo;
                dr["Packages"] = item.Packages;
                dr["ActualWeight"] = item.ActualWeight;
                dr["ChargedWeight"] = item.ChargedWeight;
                dr["SubTotal"] = item.SubTotal;
                dr["TaxTotal"] = item.TaxTotal;
                dr["GrandTotal"] = item.GrandTotal;
                dr["BillNo"] = item.BillNo;
                dr["BillDate"] = item.BillDate;
                dsExport.Tables[0].Rows.Add(dr);
                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        protected DataTable ExpenseRegisterReport(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DataColumn dt;

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("ExpenseRegisterReport");

            IEnumerable<ExpenseRegisterExcelData> expenseRegisterReport = this.financeRepository.GetExpenseRegisterReportData(fromDate, toDate, locationId, isCumulative, CustomerId);

            dt = new DataColumn();
            dt.Caption = "Sr No.";
            dt.ColumnName = "SrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Thc No.";
            dt.ColumnName = "ThcNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Thc Date";
            dt.ColumnName = "ThcDate";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Pickup ID";
            //dt.ColumnName = "PickupID";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Branch Name";
            dt.ColumnName = "Origin";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "FromCity";
            dt.ColumnName = "FromCity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "ToCity";
            dt.ColumnName = "ToCity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Transport Mode";
            dt.ColumnName = "TransportMode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Booking Type";
            dt.ColumnName = "BookingType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Business Type";
            dt.ColumnName = "BusinessType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignor Name";
            dt.ColumnName = "ConsignorName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignee Name";
            dt.ColumnName = "ConsigneeName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "THC VendorName";
            dt.ColumnName = "ThcVendorName";
            dsExport.Tables[0].Columns.Add(dt);


            dt = new DataColumn();
            dt.Caption = "Vendor LR";
            dt.ColumnName = "VendorLR";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Tripsheet No";
            //dt.ColumnName = "TripsheetNo";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "FTL Type";
            dt.ColumnName = "FtlType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "THC VehicleNo";
            dt.ColumnName = "ThcVehicleNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Packages";
            dt.ColumnName = "Packages";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Actual Weight";
            dt.ColumnName = "ActualWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Charged Weight";
            dt.ColumnName = "ChargedWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Thc Amount";
            dt.ColumnName = "ThcAmount";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor Manual Bill No.";
            dt.ColumnName = "VendorManualBillNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor  Bill No.";
            dt.ColumnName = "VendorBillNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor  Bill Date";
            dt.ColumnName = "VendorBillDate";
            dsExport.Tables[0].Columns.Add(dt);


            int i = 0;

            foreach (var item in expenseRegisterReport)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                dr["SrNo"] = (i + 1).ToString();
                dr["ThcNo"] = item.ThcNo;
                dr["ThcDate"] = item.ThcDate;
                //dr["PickupID"] = item.PickupID;
                dr["Origin"] = item.Origin;
                dr["FromCity"] = item.FromCity;
                dr["ToCity"] = item.ToCity;
                dr["TransportMode"] = item.TransportMode;
                dr["BookingType"] = item.BookingType;
                dr["BusinessType"] = item.BusinessType;
                dr["ConsignorName"] = item.ConsignorName;
                dr["ConsigneeName"] = item.ConsigneeName;
                dr["ThcVendorName"] = item.ThcVendorName;
                dr["VendorLR"] = item.VendorLR;
                //dr["TripsheetNo"] = item.TripsheetNo;
                dr["FtlType"] = item.FtlType;
                dr["ThcVehicleNo"] = item.ThcVehicleNo;
                dr["Packages"] = item.Packages;
                dr["ActualWeight"] = item.ActualWeight;
                dr["ChargedWeight"] = item.ChargedWeight;
                dr["ThcAmount"] = item.ThcAmount;
                dr["VendorManualBillNo"] = item.VendorManualBillNo;
                dr["VendorBillNo"] = item.VendorBillNo;
                dr["VendorBillDate"] = item.VendorBillDate;
                dsExport.Tables[0].Rows.Add(dr);
                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        protected DataTable CustomerUnbilledRegisterReport(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DataColumn dt;

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("CustomerUnbilledRegisterReport");

            IEnumerable<SalesRegisterExcelData> salesRegisterReport = this.financeRepository.GetCustomerUnbilledRegisterReportData(fromDate, toDate, locationId, isCumulative, CustomerId);

            dt = new DataColumn();
            dt.Caption = "Sr No.";
            dt.ColumnName = "SrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Docket No.";
            dt.ColumnName = "LRNo";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Pickup ID";
            //dt.ColumnName = "PickupID";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor LR";
            dt.ColumnName = "VendorLR";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Docket Date";
            dt.ColumnName = "DocketDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Branch Name";
            dt.ColumnName = "Origin";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Transport Mode";
            dt.ColumnName = "TransportMode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Booking Type";
            dt.ColumnName = "BookingType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Business Type";
            dt.ColumnName = "BusinessType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignor Name";
            dt.ColumnName = "ConsignorName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignee Name";
            dt.ColumnName = "ConsigneeName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Billing Party Name";
            dt.ColumnName = "BillingPartyName";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Trip No";
            //dt.ColumnName = "TripsheetNo";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Ftl Type";
            dt.ColumnName = "FtlType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vehicle No";
            dt.ColumnName = "VehicleNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor Name";
            dt.ColumnName = "VendorName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice No";
            dt.ColumnName = "InvoiceNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice Amount";
            dt.ColumnName = "InvoiceAmount";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Cft Ratio";
            dt.ColumnName = "CftRatio";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Freight Rate";
            dt.ColumnName = "FreightRate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Rate Type";
            dt.ColumnName = "RateType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Packages";
            dt.ColumnName = "Packages";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Actual Weight";
            dt.ColumnName = "ActualWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Charged Weight";
            dt.ColumnName = "ChargedWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Freight Amount";
            dt.ColumnName = "FreightAmount";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Docket Charges";
            dt.ColumnName = "DocketCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Fuel Surcharge";
            dt.ColumnName = "FuelSurchargeCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Unloading Charges";
            dt.ColumnName = "UnloadingCharges";
            dsExport.Tables[0].Columns.Add(dt);


            dt = new DataColumn();
            dt.Caption = "Pickup Charges";
            dt.ColumnName = "PickupCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Door Delivery Charges";
            dt.ColumnName = "DoorDeliveryCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Loading Charges";
            dt.ColumnName = "LoadingCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "FOV Charges";
            dt.ColumnName = "FOVCharges";
            dsExport.Tables[0].Columns.Add(dt);


            dt = new DataColumn();
            dt.Caption = "Other Charges";
            dt.ColumnName = "OtherCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Detention Charges";
            dt.ColumnName = "DetentionCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Handling Charges";
            dt.ColumnName = "HandlingCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Parking Charges";
            dt.ColumnName = "ParkingCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Toll Charges";
            dt.ColumnName = "TollCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Halting Charges";
            dt.ColumnName = "HaltingCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Green Tax Charges";
            dt.ColumnName = "GreenTaxCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Hamali Charges";
            dt.ColumnName = "HamaliCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "ODA Charges";
            dt.ColumnName = "ODACharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Sub Total";
            dt.ColumnName = "SubTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Tax Total";
            dt.ColumnName = "TaxTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Grand Total";
            dt.ColumnName = "GrandTotal";
            dsExport.Tables[0].Columns.Add(dt);



            int i = 0;

            foreach (var item in salesRegisterReport)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                dr["SrNo"] = (i + 1).ToString();
                dr["LRNo"] = item.LRNo;
                dr["DocketDate"] = item.DocketDate;
                //dr["PickupID"] = item.PickupID;
                dr["VendorLR"] = item.VendorLR;

                //
                dr["Origin"] = item.Origin;


                dr["TransportMode"] = item.TransportMode;
                dr["BookingType"] = item.BookingType;
                dr["BusinessType"] = item.BusinessType;
                dr["ConsignorName"] = item.ConsignorName;
                dr["ConsigneeName"] = item.ConsigneeName;
                dr["BillingPartyName"] = item.BillingPartyName;
                //dr["TripsheetNo"] = item.TripsheetNo;
                dr["FtlType"] = item.FtlType;
                dr["VehicleNo"] = item.VehicleNo;
                dr["VendorName"] = item.VendorName;
                dr["InvoiceNo"] = item.InvoiceNo;
                dr["InvoiceAmount"] = item.InvoiceAmount;
                dr["CftRatio"] = item.CftRatio;
                dr["FreightRate"] = item.FreightRate;

                dr["RateType"] = item.RateType;

                dr["Packages"] = item.Packages;
                dr["ActualWeight"] = item.ActualWeight;
                dr["ChargedWeight"] = item.ChargedWeight;
                dr["FreightAmount"] = item.FreightAmount;

                dr["DocketCharges"] = item.DocketCharges;
                dr["FuelSurchargeCharges"] = item.FuelSurchargeCharges;
                dr["UnloadingCharges"] = item.UnloadingCharges;
                dr["PickupCharges"] = item.PickupCharges;
                dr["DoorDeliveryCharges"] = item.DoorDeliveryCharges;
                dr["LoadingCharges"] = item.LoadingCharges;
                dr["FOVCharges"] = item.FOVCharges;
                dr["OtherCharges"] = item.OtherCharges;
                dr["DetentionCharges"] = item.DetentionCharges;

                dr["HandlingCharges"] = item.HandlingCharges;
                dr["ParkingCharges"] = item.ParkingCharges;
                dr["TollCharges"] = item.TollCharges;
                dr["HaltingCharges"] = item.HaltingCharges;
                dr["GreenTaxCharges"] = item.GreenTaxCharges;
                dr["HamaliCharges"] = item.HamaliCharges;
                dr["ODACharges"] = item.ODACharges;
                dr["SubTotal"] = item.SubTotal;
                dr["TaxTotal"] = item.TaxTotal;
                dr["GrandTotal"] = item.GrandTotal;
                dsExport.Tables[0].Rows.Add(dr);
                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        protected DataTable VendorUnbilledRegisterReport(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DataColumn dt;

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("VendorUnbilledRegisterReport");

            IEnumerable<SalesRegisterExcelData> expenseRegisterReport = this.financeRepository.GetVendorUnbilledRegisterReportData(fromDate, toDate, locationId, isCumulative, CustomerId);

            dt = new DataColumn();
            dt.Caption = "Sr No.";
            dt.ColumnName = "SrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "THC No.";
            dt.ColumnName = "LRNo";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Pickup ID";
            //dt.ColumnName = "PickupID";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor LR";
            dt.ColumnName = "VendorLR";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "THC Date";
            dt.ColumnName = "DocketDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Branch Name";
            dt.ColumnName = "Origin";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Transport Mode";
            dt.ColumnName = "TransportMode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Booking Type";
            dt.ColumnName = "BookingType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Business Type";
            dt.ColumnName = "BusinessType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignor Name";
            dt.ColumnName = "ConsignorName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignee Name";
            dt.ColumnName = "ConsigneeName";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Trip No";
            //dt.ColumnName = "TripsheetNo";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Ftl Type";
            dt.ColumnName = "FtlType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vehicle No";
            dt.ColumnName = "VehicleNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor Name";
            dt.ColumnName = "VendorName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice No";
            dt.ColumnName = "InvoiceNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice Amount";
            dt.ColumnName = "InvoiceAmount";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Cft Ratio";
            dt.ColumnName = "CftRatio";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Freight Rate";
            dt.ColumnName = "FreightRate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Rate Type";
            dt.ColumnName = "RateType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Packages";
            dt.ColumnName = "Packages";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Actual Weight";
            dt.ColumnName = "ActualWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Charged Weight";
            dt.ColumnName = "ChargedWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Freight Amount";
            dt.ColumnName = "FreightAmount";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Docket Charges";
            dt.ColumnName = "DocketCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Fuel Surcharge";
            dt.ColumnName = "FuelSurchargeCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Unloading Charges";
            dt.ColumnName = "UnloadingCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Pickup Charges";
            dt.ColumnName = "PickupCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Door Delivery Charges";
            dt.ColumnName = "DoorDeliveryCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Loading Charges";
            dt.ColumnName = "LoadingCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "FOV Charges";
            dt.ColumnName = "FOVCharges";
            dsExport.Tables[0].Columns.Add(dt);


            dt = new DataColumn();
            dt.Caption = "Other Charges";
            dt.ColumnName = "OtherCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Detention Charges";
            dt.ColumnName = "DetentionCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Handling Charges";
            dt.ColumnName = "HandlingCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Parking Charges";
            dt.ColumnName = "ParkingCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Toll Charges";
            dt.ColumnName = "TollCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Halting Charges";
            dt.ColumnName = "HaltingCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Green Tax Charges";
            dt.ColumnName = "GreenTaxCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Hamali Charges";
            dt.ColumnName = "HamaliCharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "ODA Charges";
            dt.ColumnName = "ODACharges";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Sub Total";
            dt.ColumnName = "SubTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Tax Total";
            dt.ColumnName = "TaxTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Grand Total";
            dt.ColumnName = "GrandTotal";
            dsExport.Tables[0].Columns.Add(dt);



            int i = 0;

            foreach (var item in expenseRegisterReport)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                dr["SrNo"] = (i + 1).ToString();
                dr["LRNo"] = item.LRNo;
                dr["DocketDate"] = item.DocketDate;
                //dr["PickupID"] = item.PickupID;
                dr["VendorLR"] = item.VendorLR;

                //
                dr["Origin"] = item.Origin;


                dr["TransportMode"] = item.TransportMode;
                dr["BookingType"] = item.BookingType;
                dr["BusinessType"] = item.BusinessType;
                dr["ConsignorName"] = item.ConsignorName;
                dr["ConsigneeName"] = item.ConsigneeName;
                //  dr["BillingPartyName"] = item.BillingPartyName;
                //dr["TripsheetNo"] = item.TripsheetNo;
                dr["FtlType"] = item.FtlType;
                dr["VehicleNo"] = item.VehicleNo;
                dr["VendorName"] = item.VendorName;
                dr["InvoiceNo"] = item.InvoiceNo;
                dr["InvoiceAmount"] = item.InvoiceAmount;
                dr["CftRatio"] = item.CftRatio;
                dr["FreightRate"] = item.FreightRate;

                dr["RateType"] = item.RateType;

                dr["Packages"] = item.Packages;
                dr["ActualWeight"] = item.ActualWeight;
                dr["ChargedWeight"] = item.ChargedWeight;
                dr["FreightAmount"] = item.FreightAmount;

                dr["DocketCharges"] = item.DocketCharges;
                dr["FuelSurchargeCharges"] = item.FuelSurchargeCharges;
                dr["UnloadingCharges"] = item.UnloadingCharges;
                dr["PickupCharges"] = item.PickupCharges;
                dr["DoorDeliveryCharges"] = item.DoorDeliveryCharges;
                dr["LoadingCharges"] = item.LoadingCharges;
                dr["FOVCharges"] = item.FOVCharges;
                dr["OtherCharges"] = item.OtherCharges;
                dr["DetentionCharges"] = item.DetentionCharges;

                dr["HandlingCharges"] = item.HandlingCharges;
                dr["ParkingCharges"] = item.ParkingCharges;
                dr["TollCharges"] = item.TollCharges;
                dr["HaltingCharges"] = item.HaltingCharges;
                dr["GreenTaxCharges"] = item.GreenTaxCharges;
                dr["HamaliCharges"] = item.HamaliCharges;
                dr["ODACharges"] = item.ODACharges;
                dr["SubTotal"] = item.SubTotal;
                dr["TaxTotal"] = item.TaxTotal;
                dr["GrandTotal"] = item.GrandTotal;
                dsExport.Tables[0].Rows.Add(dr);
                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        public JsonResult IsFinanceReportDataExistByReportTypeId(DateTime fromDate, DateTime toDate, short reportTypeId, short locationId, bool isCumulative)
        {
            return Json(financeRepository.IsFinanceReportDataExistByReportTypeId(fromDate, toDate, reportTypeId, locationId, isCumulative));
        }

        //public ActionResult LedgerRegister()
        //{
        //    Ledger ledger = new Ledger();

        //    ViewBag.CompanyList = JsonConvert.SerializeObject(this.companyRepository.GetCompanyList());
        //    ViewBag.LocationList = JsonConvert.SerializeObject(this.locationRepository.GetLocationList());
        //    ViewBag.CustomerList = JsonConvert.SerializeObject(this.customerRepository.GetCustomerList());
        //    var accountList = this.accountRepository.GetAccountListByAccountCategoryId(5).ToList();
        //    accountList.AddRange(this.accountRepository.GetAccountListByAccountCategoryId(6).ToList());
        //    ViewBag.AccountList = JsonConvert.SerializeObject(accountList.AsEnumerable());
        //    return base.View(ledger);
        //}
        public ActionResult LedgerRegister()
        {
            Ledger ledger = new Ledger();

            ViewBag.CompanyList = JsonConvert.SerializeObject(this.companyRepository.GetCompanyList());
            ViewBag.LocationList = JsonConvert.SerializeObject(this.locationRepository.GetLocationList());
            ViewBag.CustomerList = JsonConvert.SerializeObject(this.customerRepository.GetCustomerList());
            ViewBag.VendorList = JsonConvert.SerializeObject(this.vendorRepository.GetVendorNameList());

            var accountList = this.accountRepository.GetAccountListByAccountCategoryId(5)
                                .Concat(this.accountRepository.GetAccountListByAccountCategoryId(6))
                                .GroupBy(account => account.Name)
                                .Select(group => group.First())
                                .ToList();

            ViewBag.AccountList = JsonConvert.SerializeObject(accountList);

            return base.View(ledger);
        }

        protected DataTable SalesInvoiceRegisterReport(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DataColumn dt;

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("SalesInvoiceRegister");

            IEnumerable<SalesInvoiceRegisterExcelData> salesInvoiceRegisterReport = this.financeRepository.GetSalesInvoiceRegisterReportData(fromDate, toDate, locationId, isCumulative, CustomerId);

            dt = new DataColumn();
            dt.Caption = "Sr No.";
            dt.ColumnName = "SrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "LR No.";
            dt.ColumnName = "LRNo";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Pickup ID";
            //dt.ColumnName = "PickupID";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Docket Date";
            dt.ColumnName = "DocketDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Origin";
            dt.ColumnName = "Origin";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "From City";
            dt.ColumnName = "FromCity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "To City";
            dt.ColumnName = "ToCity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Transport Mode";
            dt.ColumnName = "TransportMode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Booking Type";
            dt.ColumnName = "BookingType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Business Type";
            dt.ColumnName = "BusinessType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignor Name";
            dt.ColumnName = "ConsignorName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignee Name";
            dt.ColumnName = "ConsigneeName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Billing Party Name";
            dt.ColumnName = "BillingPartyName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Ftl Type";
            dt.ColumnName = "FtlType";
            dsExport.Tables[0].Columns.Add(dt);

            //dt = new DataColumn();
            //dt.Caption = "Tripsheet No";
            //dt.ColumnName = "TripsheetNo";
            //dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice Date";
            dt.ColumnName = "InvoiceDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice No";
            dt.ColumnName = "InvoiceNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice Amount";
            dt.ColumnName = "InvoiceAmount";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "EwayBill No";
            dt.ColumnName = "EwayBillNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "EwayBill Issue Date";
            dt.ColumnName = "EwayBillIssueDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "EwayBill Expiry Date";
            dt.ColumnName = "EwayBillExpiryDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Referance No.";
            dt.ColumnName = "ReferanceNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Part No.";
            dt.ColumnName = "PartNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Part Name";
            dt.ColumnName = "PartName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Part Quantity";
            dt.ColumnName = "PartQuantity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Part Packing Type";
            dt.ColumnName = "PartPackingType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Packages";
            dt.ColumnName = "Packages";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Lenght";
            dt.ColumnName = "Lenght";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Breadth";
            dt.ColumnName = "Breadth";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Height";
            dt.ColumnName = "Height";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Volumetric Weight";
            dt.ColumnName = "VolumetricWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Actual Weight";
            dt.ColumnName = "ActualWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Charged Weight";
            dt.ColumnName = "ChargedWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Sub Total";
            dt.ColumnName = "SubTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Tax Total";
            dt.ColumnName = "TaxTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Grand Total";
            dt.ColumnName = "GrandTotal";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Bill No";
            dt.ColumnName = "BillNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Bill Date";
            dt.ColumnName = "BillDate";
            dsExport.Tables[0].Columns.Add(dt);

          

            int i = 0;

            foreach (var item in salesInvoiceRegisterReport)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                dr["SrNo"] = (i + 1).ToString();
                dr["LRNo"] = item.LRNo;
                dr["DocketDate"] = item.DocketDate;
                dr["Origin"] = item.Origin;
                dr["FromCity"] = item.FromCity;
                dr["ToCity"] = item.ToCity;
                dr["TransportMode"] = item.TransportMode;
                dr["BookingType"] = item.BookingType;
                dr["BusinessType"] = item.BusinessType;
                dr["ConsignorName"] = item.ConsignorName;
                dr["ConsigneeName"] = item.ConsigneeName;
                dr["BillingPartyName"] = item.BillingPartyName;
                dr["FtlType"] = item.FtlType;
                dr["InvoiceNo"] = item.InvoiceNo;
                dr["InvoiceDate"] = item.InvoiceDate;
                dr["InvoiceAmount"] = item.InvoiceAmount;
                dr["EwayBillNo"] = item.EwayBillNo;
                dr["EwayBillIssueDate"] = item.EwayBillIssueDate;
                dr["EwayBillExpiryDate"] = item.EwayBillExpiryDate;
                dr["ReferanceNo"] = item.ReferanceNo;
                dr["PartNo"] = item.PartNo;
                dr["PartName"] = item.PartName;
                dr["PartQuantity"] = item.PartQuantity;
                dr["PartPackingType"] = item.PartPackingType;
                dr["Lenght"] = item.Lenght;
                dr["Breadth"] = item.Breadth;
                dr["Height"] = item.Height;
                dr["Packages"] = item.Packages;
                dr["VolumetricWeight"] = item.VolumetricWeight;
                dr["ActualWeight"] = item.ActualWeight;
                dr["ChargedWeight"] = item.ChargedWeight;
                dr["SubTotal"] = item.SubTotal;
                dr["TaxTotal"] = item.TaxTotal;
                dr["GrandTotal"] = item.GrandTotal;
                dr["BillNo"] = item.BillNo;
                dr["BillDate"] = item.BillDate;

                dsExport.Tables[0].Rows.Add(dr);

                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        protected DataTable AutorenewalEwayBill(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DataColumn dt;

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("AutorenewalEwayBill");

            IEnumerable<SalesInvoiceRegisterExcelData> salesInvoiceRegisterReport = this.financeRepository.GetAutorenewalEwayBillReportData(fromDate, toDate, locationId, isCumulative, CustomerId);

            dt = new DataColumn();
            dt.Caption = "Sr No.";
            dt.ColumnName = "SrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Eway Bill No.";
            dt.ColumnName = "EwayBillNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "EwayBill Exp Date";
            dt.ColumnName = "EwayBillExpDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice No.";
            dt.ColumnName = "InvoiceNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice Date";
            dt.ColumnName = "InvoiceDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Docket No.";
            dt.ColumnName = "DocketNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Customer Name";
            dt.ColumnName = "CustomerName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Adress";
            dt.ColumnName = "Adress";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "PickUp Branch";
            dt.ColumnName = "PickUpBranch";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "GateWay Branch";
            dt.ColumnName = "GateWayBranch";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Current Location";
            dt.ColumnName = "CurrentLocation";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Current Status";
            dt.ColumnName = "CurrentStatus";
            dsExport.Tables[0].Columns.Add(dt);


            int i = 0;

            foreach (var item in salesInvoiceRegisterReport)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                dr["SrNo"] = (i + 1).ToString();
                dr["EwayBillNo"] = item.EwayBillNo;
                dr["EwayBillExpDate"] = item.EwayBillExpDate;
                dr["InvoiceNo"] = item.InvoiceNo;
                dr["InvoiceDate"] = item.InvoiceDate;
                dr["DocketNo"] = item.DocketNo;
                dr["CustomerName"] = item.CustomerName;
                dr["Adress"] = item.Adress;
                dr["PickUpBranch"] = item.PickUpBranch;
                dr["GateWayBranch"] = item.GateWayBranch;
                dr["CurrentLocation"] = item.CurrentLocation;
                dr["CurrentStatus"] = item.CurrentStatus;

                dsExport.Tables[0].Rows.Add(dr);

                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        protected DataTable AutorenewalEwayBillError(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DataColumn dt;

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("AutorenewalEwayBillError");

            IEnumerable<SalesInvoiceRegisterExcelData> salesInvoiceRegisterReport = this.financeRepository.GetAutorenewalEwayBillErorReportData(fromDate, toDate, locationId, isCumulative, CustomerId);

            dt = new DataColumn();
            dt.Caption = "Sr No.";
            dt.ColumnName = "SrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Eway Bill No.";
            dt.ColumnName = "EwayBillNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Eway Bill Error Message";
            dt.ColumnName = "EwayBillErrorMessage";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Error Date";
            dt.ColumnName = "ErrorDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice No.";
            dt.ColumnName = "InvoiceNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice Date";
            dt.ColumnName = "InvoiceDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Docket No.";
            dt.ColumnName = "DocketNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Customer Name";
            dt.ColumnName = "CustomerName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Adress";
            dt.ColumnName = "Adress";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "PickUp Branch";
            dt.ColumnName = "PickUpBranch";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "GateWay Branch";
            dt.ColumnName = "GateWayBranch";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Current Location";
            dt.ColumnName = "CurrentLocation";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Current Status";
            dt.ColumnName = "CurrentStatus";
            dsExport.Tables[0].Columns.Add(dt);


            int i = 0;

            foreach (var item in salesInvoiceRegisterReport)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                dr["SrNo"] = (i + 1).ToString();
                dr["EwayBillNo"] = item.EwayBillNo;
                dr["EwayBillErrorMessage"] = item.EwayBillErrorMessage;
                dr["ErrorDate"] = item.ErrorDate;
                dr["InvoiceNo"] = item.InvoiceNo;
                dr["InvoiceDate"] = item.InvoiceDate;
                dr["DocketNo"] = item.DocketNo;
                dr["CustomerName"] = item.CustomerName;
                dr["Adress"] = item.Adress;
                dr["PickUpBranch"] = item.PickUpBranch;
                dr["GateWayBranch"] = item.GateWayBranch;
                dr["CurrentLocation"] = item.CurrentLocation;
                dr["CurrentStatus"] = item.CurrentStatus;

                dsExport.Tables[0].Rows.Add(dr);

                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        protected DataTable SalesRegisterReportWithPartDetails(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DataColumn dt;

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("SalesRegisterWithPartDetails");

            IEnumerable<SalesRegisterExcelData> salesRegisterReport = this.financeRepository.GetSalesRegisterReportWithPartDetails(fromDate, toDate, locationId, isCumulative, CustomerId);

            dt = new DataColumn();
            dt.Caption = "Sr No.";
            dt.ColumnName = "SrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "LR No.";
            dt.ColumnName = "LRNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Manual LR No.";
            dt.ColumnName = "ManualLRNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Docket Date";
            dt.ColumnName = "DocketDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Entry Date";
            dt.ColumnName = "EntryDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Delivery Date";
            dt.ColumnName = "DeliveryDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "EDD";
            dt.ColumnName = "Edd";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Arrive Date";
            dt.ColumnName = "ArriveDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Origin";
            dt.ColumnName = "Origin";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Destination";
            dt.ColumnName = "Destination";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Current Location";
            dt.ColumnName = "CurrentLocation";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Next Location";
            dt.ColumnName = "NextLocation";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "From";
            dt.ColumnName = "FromCity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "To";
            dt.ColumnName = "ToCity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Pay Basis";
            dt.ColumnName = "Paybas";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Transport Mode";
            dt.ColumnName = "TransportMode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Booking Type";
            dt.ColumnName = "BookingType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Load Type";
            dt.ColumnName = "LoadType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Business Type";
            dt.ColumnName = "BusinessType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Product Type";
            dt.ColumnName = "ProductType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Risk Type";
            dt.ColumnName = "RiskType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Stock Type";
            dt.ColumnName = "StockType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Delivery Type";
            dt.ColumnName = "DeliveryType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Flow Type";
            dt.ColumnName = "FlowType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Private Mark";
            dt.ColumnName = "PrivateMark";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "DACC";
            dt.ColumnName = "DACC";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "COD";
            dt.ColumnName = "COD";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignor Code";
            dt.ColumnName = "ConsignorCode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignor Name";
            dt.ColumnName = "ConsignorName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignor GSTIN No";
            dt.ColumnName = "ConsignorGstinNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignee Code";
            dt.ColumnName = "ConsigneeCode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignee Name";
            dt.ColumnName = "ConsigneeName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Consignee GSTIN No";
            dt.ColumnName = "ConsigneeGstinNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Billing Party Name";
            dt.ColumnName = "BillingPartyName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Packages";
            dt.ColumnName = "Packages";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Actual Weight";
            dt.ColumnName = "ActualWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Charged Weight";
            dt.ColumnName = "ChargedWeight";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Connectivity Date";
            dt.ColumnName = "ConnectivityDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Bill Location";
            dt.ColumnName = "BillLocation";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice No";
            dt.ColumnName = "InvoiceNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice Date";
            dt.ColumnName = "InvoiceDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Invoice Amount";
            dt.ColumnName = "InvoiceAmount";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Part No";
            dt.ColumnName = "PartNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Part Name";
            dt.ColumnName = "PartName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Part Quantity";
            dt.ColumnName = "PartQuantity";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Status";
            dt.ColumnName = "Status";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Remarks";
            dt.ColumnName = "Remarks";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Customer LR No";
            dt.ColumnName = "CustomerLrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "LR Vehicle No";
            dt.ColumnName = "VehicleNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "FtlType";
            dt.ColumnName = "FtlType";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Booked By";
            dt.ColumnName = "BookedBy";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Booked By Name";
            dt.ColumnName = "BookedByName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vehicle Capacity";
            dt.ColumnName = "VehicleCapacity";
            dsExport.Tables[0].Columns.Add(dt);

            int i = 0;

            foreach (var item in salesRegisterReport)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                dr["SrNo"] = (i + 1).ToString();
                dr["LRNo"] = item.LRNo;
                dr["ManualLRNo"] = item.ManualLRNo;
                dr["DocketDate"] = item.DocketDate;
                dr["EntryDate"] = item.EntryDate;
                dr["DeliveryDate"] = item.DeliveryDate;
                dr["Edd"] = item.Edd;
                dr["ArriveDate"] = item.ArriveDate;
                dr["Origin"] = item.Origin;
                dr["Destination"] = item.Destination;
                dr["CurrentLocation"] = item.CurrentLocation;
                dr["NextLocation"] = item.NextLocation;
                dr["FromCity"] = item.FromCity;
                dr["ToCity"] = item.ToCity;
                dr["Paybas"] = item.Paybas;
                dr["TransportMode"] = item.TransportMode;
                dr["BookingType"] = item.BookingType;
                dr["LoadType"] = item.LoadType;
                dr["BusinessType"] = item.BusinessType;
                dr["ProductType"] = item.ProductType;
                dr["RiskType"] = item.RiskType;
                dr["StockType"] = item.StockType;
                dr["DeliveryType"] = item.DeliveryType;
                dr["FlowType"] = item.FlowType;
                dr["PrivateMark"] = item.PrivateMark;
                dr["DACC"] = item.DACC;
                dr["COD"] = item.COD;
                dr["ConsignorCode"] = item.ConsignorCode;
                dr["ConsignorName"] = item.ConsignorName;
                dr["ConsignorGstinNo"] = item.ConsignorGstinNo;
                dr["ConsigneeCode"] = item.ConsigneeCode;
                dr["ConsigneeName"] = item.ConsigneeName;
                dr["ConsigneeGstinNo"] = item.ConsigneeGstinNo;
                dr["BillingPartyName"] = item.BillingPartyName;
                dr["Packages"] = item.Packages;
                dr["ActualWeight"] = item.ActualWeight;
                dr["ChargedWeight"] = item.ChargedWeight;
                dr["ConnectivityDate"] = item.ConnectivityDate;
                dr["BillLocation"] = item.BillLocation;
                dr["InvoiceNo"] = item.InvoiceNo;
                dr["InvoiceDate"] = item.InvoiceDate;
                dr["InvoiceAmount"] = item.InvoiceAmount;
                dr["PartNo"] = item.PartNo;
                dr["PartName"] = item.PartName;
                dr["PartQuantity"] = item.PartQuantity;
                dr["Status"] = item.Status;
                dr["Remarks"] = item.Remarks;
                dr["CustomerLrNo"] = item.CustomerLrNo;
                dr["VehicleNo"] = item.VehicleNo;
                dr["FtlType"] = item.FtlType;
                dr["BookedBy"] = item.BookedBy;
                dr["BookedByName"] = item.BookedByName;
                dr["VehicleCapacity"] = item.VehicleCapacity;
                dsExport.Tables[0].Rows.Add(dr);
                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        public ActionResult GSTR2APurchaseReport()
        {
            GSTR2APurchaseReport gSTR2APurchaseReport = new GSTR2APurchaseReport();
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).GSTTypeList = this.generalRepository.GetByIdList(201);
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            return base.View(gSTR2APurchaseReport);
        }
        public ActionResult ExpenseRegisterDocumentWise()
        {
            ExpenseRegisterDocumentWise VendorBillWiseOutstandingReport = new ExpenseRegisterDocumentWise();
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(35);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(VendorBillWiseOutstandingReport);
        }
        public ActionResult MrRegister()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(new MrRegister());
        }
        public ActionResult DeliveryBA()
        {
            return base.View(new DeliveryBA());
        }
        public ActionResult BalanceSheetReport()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(new BalanceSheetReport());
        }

        public ActionResult CreditNoteReport()
        {
            return base.View();
        }
        public ActionResult GSTR3BMonthWiseReport()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View();
        }
    }
}
