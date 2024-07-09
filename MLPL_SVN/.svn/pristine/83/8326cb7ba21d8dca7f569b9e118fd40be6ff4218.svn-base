//  
// Type: CodeLock.Models.DispatchDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DispatchDetail
  {
    public byte CompanyId { get; set; }

    public short WarehouseId { get; set; }

    public long DispatchId { get; set; }

    public long Id { get; set; }

    public string DispatchNo { get; set; }

    public DateTime DispatchDate { get; set; }

    [Required(ErrorMessage = "Please select Product")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [Display(Name = "Product")]
    public string ProductCode { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public string Uom { get; set; }

    [Range(0.001, 999999999.0, ErrorMessage = "Please enter Quantity greater than zero")]
    public Decimal Quantity { get; set; }

    public Decimal OrderQuantity { get; set; }

    public Decimal UnitPrice { get; set; }

    public Decimal? Amount { get; set; }

    public string FirstSerialNo { get; set; }

    public string SecondSerialNo { get; set; }
  }
}
