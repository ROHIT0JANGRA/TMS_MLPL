//  
// Type: CodeLock.Models.DocketStep5
//  
//  
//  

using System;
using System.Collections.Generic;

namespace CodeLock.Models
{
  public class DocketStep5 : Response
  {
    public DocketStep5()
    {
      this.InvoiceList = (IEnumerable<DocketInvoice>) new List<DocketInvoice>();
    }

    public Decimal CftRatio { get; set; }

    public Decimal TotalCubic { get; set; }

    public string CftMeasurementType { get; set; }

    public string VolumetricWeightType { get; set; }

    public Decimal CftDimension { get; set; }

    public bool IsUseEwayBill { get; set; }

    public bool IsUsePartDetail { get; set; }

    public bool IsBillAllowOnlyOnHqtr { get; set; }

    public int EwayBillRequiredAmount { get; set; }

    public IEnumerable<MasterPackagingMeasurement> TypeOfPackageList { get; set; }

    public IEnumerable<DocketInvoice> InvoiceList { get; set; }

        public Decimal DividerCftMeasurement { get; set; }
        public string DividerCftMeasurementType { get; set; }

        public IEnumerable<AutoCompleteResult> ContractSlabList { get; set; }
    }
}
