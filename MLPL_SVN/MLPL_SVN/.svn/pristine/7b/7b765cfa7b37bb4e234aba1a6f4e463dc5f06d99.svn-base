//  
// Type: CodeLock.Models.Stock
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Stock
  {
    public byte CompanyId { get; set; }

    public short WarehouseId { get; set; }

    public int ProductId { get; set; }

    public string ProductCode { get; set; }

    public short BinId { get; set; }

    public string BinName { get; set; }

        [Display(Name = "Sku Code")]
        public string SkuCode { get; set; }

        [Display(Name = "Sku Description")]
        public string SkuDescription { get; set; }

        [Display(Name = "UOM")]
        public string UOM { get; set; }

        [Display(Name = "Packing")]
        public string Packing { get; set; }

        [Display(Name = "Quantity")]
        public Decimal? AvailableQuantity { get; set; }

        public Decimal? UnderPickQuantity { get; set; }

        [Display(Name = "Volume")]
        public Decimal? Volume { get; set; }

    public Decimal? TotalQuantity { get; set; }


  }
}
