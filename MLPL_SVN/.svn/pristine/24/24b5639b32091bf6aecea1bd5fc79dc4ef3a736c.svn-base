//  
// Type: CodeLock.Models.OrderDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class OrderDetail
  {
    public byte CompanyId { get; set; }

    public short WarehouseId { get; set; }

    public long OrderId { get; set; }

   public DateTime OrderDate { get; set; }


    [Required(ErrorMessage = "Please select Sku")]
    [Display(Name = "Sku")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string SkuCode { get; set; }

    public string SkuName { get; set; }

    public int SkuId { get; set; }

    public string SkuDescription { get; set; }

        public Decimal? AvailableQuantity { get; set; }
        public Decimal? OrderQty { get; set; }
        public Decimal? ChargeableQty { get; set; }
        public Decimal? FreeQty { get; set; }

        [Required(ErrorMessage = "Please enter Unit Price")]
        [Range(0.001, 9999999999.0, ErrorMessage = "Please enter a value between 1 to 9999999999")]
        [Display(Name = "Unit Price")]
        public Decimal? UnitPrice { get; set; }
        public Decimal? SubTotal { get; set; }
        public Decimal? GST { get; set; }
        public Decimal? GSTAmount { get; set; }
        public Decimal? Discount { get; set; }
        public Decimal? DiscountAmount { get; set; }
        public Decimal? GrandTotal { get; set; }

        public Decimal? Amount { get; set; }

    [Required(ErrorMessage = "Please select Product")]
    [Display(Name = "Product")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string ProductCode { get; set; }

    public string ProductName { get; set; }

    public int ProductId { get; set; }

    public string Uom { get; set; }



    [Required(ErrorMessage = "Please enter Quantity")]
    [Range(0.001, 999999999.0, ErrorMessage = "Please enter value  between 1 to 999999999")]

    public bool? IsSingle { get; set; }

    public string FirstSerialNo { get; set; }

    public string SecondSerialNo { get; set; }
  }
}
