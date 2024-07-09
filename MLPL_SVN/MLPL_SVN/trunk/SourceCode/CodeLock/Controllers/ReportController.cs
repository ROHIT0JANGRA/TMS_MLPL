using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CodeLock.Controllers
{
  public class ReportController : Controller
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    public JsonResult GetReportId(List<AutoCompleteResult> list)
    {
      return this.Json((object) this.InitReportParam(list));
    }

    private string InitReportParam(List<AutoCompleteResult> list)
    {
      string index = new Guid().ToString();
      this.Session[index] = (object) list;
      return index;
    }

    public ActionResult ViewReport(
      string id,
      string reportName,
      string reportDescription)
    {
      return (ActionResult) this.View((object) new ReportInfo()
      {
        ReportId = id,
        ReportName = reportName,
        ReportDescription = reportDescription
      });
    }

        public ActionResult LinkReport(string documentId, short? documentTypeId)
        {
            ActionResult action;
            documentTypeId = new short?(documentTypeId.ConvertToShort());
            string str = "";
            string str1 = "";
            List<AutoCompleteResult> autoCompleteResults = new List<AutoCompleteResult>();
            short? nullable = documentTypeId;
            if ((nullable.GetValueOrDefault() != 1 ? 0 : Convert.ToInt32(nullable.HasValue)) == 0)
            {
                short valueOrDefault = documentTypeId.GetValueOrDefault();
                if (documentTypeId.HasValue)
                {
                    if (valueOrDefault > 102)
                    {
                        switch (valueOrDefault)
                        {
                            case 151:
                                {
                                    AutoCompleteResult autoCompleteResult = new AutoCompleteResult()
                                    {
                                        Name = "BillId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult);
                                    str = "CustomerBillView";
                                    str1 = "Customer Bill View";
                                    break;
                                }
                            case 152:
                                {
                                    break;
                                }
                            case 153:
                                {
                                    AutoCompleteResult autoCompleteResult1 = new AutoCompleteResult()
                                    {
                                        Name = "VoucherId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult1);
                                    str = "VoucherDetailView";
                                    str1 = "Voucher View";
                                    break;
                                }
                            case 154:
                                {
                                    AutoCompleteResult autoCompleteResult2 = new AutoCompleteResult()
                                    {
                                        Name = "MrId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult2);
                                    str = "MRView";
                                    str1 = "MR View";
                                    break;
                                }
                            case 161:
                            case 164:
                                {
                                    AutoCompleteResult autoCompleteResult = new AutoCompleteResult()
                                    {
                                        Name = "CreditDebitNoteId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult);
                                    str = "CreditDebitNoteView";
                                    str1 = "Credit Note View";
                                    break;
                                }
                            default:
                                {
                                    if (valueOrDefault == 159)
                                    {
                                        AutoCompleteResult autoCompleteResult3 = new AutoCompleteResult()
                                        {
                                            Name = "AdviceId",
                                            Value = documentId
                                        };
                                        autoCompleteResults.Add(autoCompleteResult3);
                                        str = "AdviceView";
                                        str1 = "Advice View";
                                        break;
                                    }
                                    else
                                    {
                                        switch (valueOrDefault)
                                        {
                                            case 227:
                                                {
                                                    AutoCompleteResult autoCompleteResult4 = new AutoCompleteResult()
                                                    {
                                                        Name = "ContractId",
                                                        Value = documentId
                                                    };
                                                    autoCompleteResults.Add(autoCompleteResult4);
                                                    str = "CCMView";
                                                    str1 = "Customer Contract View";
                                                    break;
                                                }
                                            case 228:
                                                {
                                                    AutoCompleteResult autoCompleteResult5 = new AutoCompleteResult()
                                                    {
                                                        Name = "DocketId",
                                                        Value = documentId
                                                    };
                                                    autoCompleteResults.Add(autoCompleteResult5);
                                                    str = "DeliveryMrView";
                                                    str1 = "Delivery Mr Docket View";
                                                    break;
                                                }
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (valueOrDefault)
                        {
                            case 1:
                                {
                                    break;
                                }
                            case 2:
                                {
                                    AutoCompleteResult autoCompleteResult6 = new AutoCompleteResult()
                                    {
                                        Name = "PrsId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult6);
                                    str = "PRSView";
                                    str1 = "PRS View";
                                    break;
                                }
                            case 3:
                                {
                                    AutoCompleteResult autoCompleteResult7 = new AutoCompleteResult()
                                    {
                                        Name = "LoadingSheetId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult7);
                                    str = "LoadingSheetView";
                                    str1 = "Loading Sheet View";
                                    break;
                                }
                            case 4:
                                {
                                    AutoCompleteResult autoCompleteResult8 = new AutoCompleteResult()
                                    {
                                        Name = "ManifestId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult8);
                                    str = "ManifestView";
                                    str1 = "Manifest View";
                                    break;
                                }
                            case 5:
                                {
                                    AutoCompleteResult autoCompleteResult9 = new AutoCompleteResult()
                                    {
                                        Name = "ThcId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult9);
                                    str = "ThcView";
                                    str1 = "THC View";
                                    break;
                                }
                            case 6:
                                {
                                    AutoCompleteResult autoCompleteResult10 = new AutoCompleteResult()
                                    {
                                        Name = "DrsId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult10);
                                    str = "DRSView";
                                    str1 = "DRS View";
                                    break;
                                }
                            case 7:
                                {
                                    break;
                                }
                            case 8:
                                {
                                    AutoCompleteResult autoCompleteResult11 = new AutoCompleteResult()
                                    {
                                        Name = "PfmId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult11);
                                    str = "PfmView";
                                    str1 = "PFM View";
                                    break;
                                }
                            case 9:
                                {
                                    AutoCompleteResult autoCompleteResult12 = new AutoCompleteResult()
                                    {
                                        Name = "VrId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult12);
                                    str = "VrView";
                                    str1 = "Vr View";
                                    break;
                                }
                            case 10:
                                {
                                    AutoCompleteResult autoCompleteResult13 = new AutoCompleteResult()
                                    {
                                        Name = "DocketId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult13);
                                    str = "DepsView";
                                    str1 = "DEPS View";
                                    break;
                                }
                            case 11:
                                {
                                    AutoCompleteResult autoCompleteResult7 = new AutoCompleteResult()
                                    {
                                        Name = "LoadingSheetId",
                                        Value = documentId
                                    };
                                    autoCompleteResults.Add(autoCompleteResult7);
                                    str = "LoadingSheetViewPrintDetail";
                                    str1 = "Loading Sheet View";
                                    break;
                                }
                            default:
                                {
                                    switch (valueOrDefault)
                                    {
                                        case 51:
                                            {
                                                AutoCompleteResult autoCompleteResult14 = new AutoCompleteResult()
                                                {
                                                    Name = "AsnId",
                                                    Value = documentId
                                                };
                                                autoCompleteResults.Add(autoCompleteResult14);
                                                str = "AsnView";
                                                str1 = "ASN View";
                                                break;
                                            }
                                        case 52:
                                            {
                                                AutoCompleteResult autoCompleteResult15 = new AutoCompleteResult()
                                                {
                                                    Name = "GrnId",
                                                    Value = documentId
                                                };
                                                autoCompleteResults.Add(autoCompleteResult15);
                                                str = "GrnView";
                                                str1 = "GRN View";
                                                break;
                                            }
                                        case 53:
                                            {
                                                AutoCompleteResult autoCompleteResult16 = new AutoCompleteResult()
                                                {
                                                    Name = "InspectionId",
                                                    Value = documentId
                                                };
                                                autoCompleteResults.Add(autoCompleteResult16);
                                                str = "InspectionView";
                                                str1 = "Inspection View";
                                                break;
                                            }
                                        case 54:
                                            {
                                                AutoCompleteResult autoCompleteResult17 = new AutoCompleteResult()
                                                {
                                                    Name = "PutAwayId",
                                                    Value = documentId
                                                };
                                                autoCompleteResults.Add(autoCompleteResult17);
                                                str = "PutAwayView";
                                                str1 = "Put Away View";
                                                break;
                                            }
                                        case 55:
                                            {
                                                AutoCompleteResult autoCompleteResult18 = new AutoCompleteResult()
                                                {
                                                    Name = "OrderId",
                                                    Value = documentId
                                                };
                                                autoCompleteResults.Add(autoCompleteResult18);
                                                str = "OrderView";
                                                str1 = "Order View";
                                                break;
                                            }
                                        case 56:
                                            {
                                                AutoCompleteResult autoCompleteResult19 = new AutoCompleteResult()
                                                {
                                                    Name = "PickId",
                                                    Value = documentId
                                                };
                                                autoCompleteResults.Add(autoCompleteResult19);
                                                str = "PickView";
                                                str1 = "Pick View";
                                                break;
                                            }
                                        case 57:
                                            {
                                                AutoCompleteResult autoCompleteResult20 = new AutoCompleteResult()
                                                {
                                                    Name = "DispatchId",
                                                    Value = documentId
                                                };
                                                autoCompleteResults.Add(autoCompleteResult20);
                                                str = "DispatchView";
                                                str1 = "Dispatch View";
                                                break;
                                            }
                                        case 58:
                                            {
                                                AutoCompleteResult autoCompleteResult21 = new AutoCompleteResult()
                                                {
                                                    Name = "RepackingId",
                                                    Value = documentId
                                                };
                                                autoCompleteResults.Add(autoCompleteResult21);
                                                str = "RepackingView";
                                                str1 = "Repacking View";
                                                break;
                                            }
                                        default:
                                            {
                                                switch (valueOrDefault)
                                                {
                                                    case 101:
                                                        {
                                                            AutoCompleteResult autoCompleteResult22 = new AutoCompleteResult()
                                                            {
                                                                Name = "TripsheetId",
                                                                Value = documentId
                                                            };
                                                            autoCompleteResults.Add(autoCompleteResult22);
                                                            str = "TripsheetView";
                                                            str1 = "TripSheet View";
                                                            break;
                                                        }
                                                    case 102:
                                                        {
                                                            AutoCompleteResult autoCompleteResult23 = new AutoCompleteResult()
                                                            {
                                                                Name = "TripSheetId",
                                                                Value = documentId
                                                            };
                                                            autoCompleteResults.Add(autoCompleteResult23);
                                                            str = "DriverSettlementView";
                                                            str1 = "Driver Settlement View";
                                                            break;
                                                        }
                                                }
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }
                    }
                }
                string str2 = this.InitReportParam(autoCompleteResults);
                action = base.RedirectToAction("ViewReport", new { id = str2, reportName = str, reportDescription = str1 });
            }
            else
            {
                action = base.RedirectToAction("View", "Docket", new { Area = "Operation", id = documentId });
            }
            return action;
        }

    }
}
