//  
// Type: CodeLock.Models.MasterSku
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterSku : BaseModel
  {
    public int SkuId { get; set; }

    [Remote("IsSkuCodeAvailable", "Sku", AdditionalFields = "SkuId,_SkuIdToken", ErrorMessage = "Sku Code already exists.", HttpMethod = "POST")]
    [Required(ErrorMessage = "Please enter Sku Code")]
    [Display(Name = "Sku Code")]
    public string SkuCode { get; set; }

    [Display(Name = "Sku Name")]
    [Required(ErrorMessage = "Please enter Sku Name")]
    public string SkuName { get; set; }

    //[Display(Name = "Sku Description")]
    //[StringLength(100, ErrorMessage = "Sku Description must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    //public string SkuDescription { get; set; }

    [Required(ErrorMessage = "Please select Units Of Measurement")]
    [Display(Name = "Units Of Measurement")]
    public byte UomId { get; set; }

    //[Display(Name = "Units Of Measurement")]
    //public string UnitsOfMeasurement { get; set; }

    [Display(Name = "Manufacture")]
    public string Manufacture { get; set; }

    //[Display(Name = "UOM Quantity")]
    //[Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
    //public Decimal UomQuantity { get; set; }

    //[Display(Name = "Unit Price")]
    //public Decimal UnitPrice { get; set; }

    //[Display(Name = "Available Quantity")]
    //[Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
    //public Decimal AvailableQuantity { get; set; }


    //[Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
    //[Display(Name = "Length(cm)")]
    //public Decimal Length { get; set; }

    //[Display(Name = "Breadth(cm)")]
    //[Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
    //public Decimal Breadth { get; set; }

    //[Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
    //[Display(Name = "Height(cm)")]
    //public Decimal Height { get; set; }

    //[Display(Name = "Area(sq.ft.)")]
    //public Decimal Area { get; set; }

    //[Display(Name = "Actual Weight")]
    //[Range(1, 999999999, ErrorMessage = "Actual Weight must be greater than zero")]
    //public Decimal ActualWeight { get; set; }

    //[Range(1, 999999999, ErrorMessage = "Charge Weight must be greater than zero")]
    //[Display(Name = "Charge Weight")]
    //public Decimal ChargeWeight { get; set; }

    //[Display(Name = "Manufacturing Date")]
    //public DateTime? ManufacturingDate { get; set; }

    //[Display(Name = "Expiry Date")]
    //public DateTime? ExpiryDate { get; set; }

    //[Display(Name = "Process Type")]
    //public string ProcessType { get; set; }


    [Required(ErrorMessage = "Please select material category")]
    [Display(Name = "Material Category")]
    public string MaterialCategoryId { get; set; }

    [Required(ErrorMessage = "Please select sku size")]
    [Display(Name = "Sku Size")]
    public string SkuSize { get; set; }

    [Required(ErrorMessage = "Please select sku size")]
    [Display(Name = "Sku Type")]
    public string SkuType { get; set; }

    [Display(Name = "Sku Size")]
    public string Size { get; set; }

    [Display(Name = "Sku Type")]
    public string Type { get; set; }

    [Display(Name = "Material Category")]
    public string MaterialCategory { get; set; }

    [Display(Name = "Units Of Measurement")]
    public string Uom { get; set; }

    [Display(Name = "Remark")]
    public string Remark { get; set; }

        //        

    }
}
