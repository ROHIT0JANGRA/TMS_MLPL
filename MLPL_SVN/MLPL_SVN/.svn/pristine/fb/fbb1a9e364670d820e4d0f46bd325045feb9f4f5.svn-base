//  
// Type: CodeLock.Models.MasterProduct
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterProduct : BaseModel
  {
    [Display(Name = "Company Name")]
    public string CompanyName { get; set; }

    public int ProductId { get; set; }

    [Display(Name = "Product Code")]
    public string ProductCode { get; set; }

    [Display(Name = "Product Name")]
    [StringLength(100, ErrorMessage = "Product Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Product Name")]
    [Remote("IsProductNameAvailable", "Product", AdditionalFields = "CompanyId,ProductId,_ProductIdToken", ErrorMessage = "Product Name already exists.", HttpMethod = "POST")]
    public string ProductName { get; set; }

    [Display(Name = "Product Description")]
    [StringLength(100, ErrorMessage = "Product Description must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Product Description")]
    public string ProductDescription { get; set; }

    [Required(ErrorMessage = "Please select Units Of Measurement")]
    [Display(Name = "Units Of Measurement")]
    public byte UomId { get; set; }

    [Display(Name = "Units Of Measurement")]
    public string UnitsOfMeasurement { get; set; }

    [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
    [Display(Name = "UOM Quantity")]
    public Decimal? UomQuantity { get; set; }

    [Display(Name = "Unit Price")]
    public Decimal UnitPrice { get; set; }

    [Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
    [Display(Name = "Length")]
    public Decimal? Length { get; set; }

    [Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
    [Display(Name = "Breadth")]
    public Decimal? Breadth { get; set; }

    [Display(Name = "Height")]
    [Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
    public Decimal? Height { get; set; }

    [Required(ErrorMessage = "Please enter Actual Weight")]
    [Display(Name = "Actual Weight")]
    [Range(1, 999999999, ErrorMessage = "Actual Weight must be greater than zero")]
    public Decimal? ActualWeight { get; set; }

    [Display(Name = "Is Serial Number Required")]
    public bool IsSerialNumber { get; set; }

    [Display(Name = "Is Single")]
    public bool? IsSingle { get; set; }

    [Range(1, 999999999, ErrorMessage = "Charge Weight must be greater than zero")]
    [Display(Name = "Charge Weight")]
    [Required(ErrorMessage = "Please enter Charge Weight")]
    public Decimal ChargeWeight { get; set; }
  }
  public class MasterProductPartExist
    {
        [Display(Name = "Company Name")]
    public string CompanyName { get; set; }

    public int ProductId { get; set; }

    [Display(Name = "Product Code")]
    public string ProductCode { get; set; }

    [Display(Name = "Product Name")]
    [StringLength(100, ErrorMessage = "Product Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Product Name")]
    [Remote("IsProductNameAvailable", "Product", AdditionalFields = "CompanyId,ProductId,_ProductIdToken", ErrorMessage = "Product Name already exists.", HttpMethod = "POST")]
    public string ProductName { get; set; }

    [Display(Name = "Product Description")]
    [StringLength(100, ErrorMessage = "Product Description must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Product Description")]
    public string ProductDescription { get; set; }

    [Required(ErrorMessage = "Please select Units Of Measurement")]
    [Display(Name = "Units Of Measurement")]
    public byte UomId { get; set; }

    [Display(Name = "Units Of Measurement")]
    public string UnitsOfMeasurement { get; set; }

    [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
    [Display(Name = "UOM Quantity")]
    public Decimal? UomQuantity { get; set; }

    [Display(Name = "Unit Price")]
    public Decimal UnitPrice { get; set; }

    [Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
    [Display(Name = "Length")]
    public Decimal? Length { get; set; }

    [Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
    [Display(Name = "Breadth")]
    public Decimal? Breadth { get; set; }

    [Display(Name = "Height")]
    [Range(0.0, 9999.99, ErrorMessage = "Please enter a value between 0 to 9999")]
    public Decimal? Height { get; set; }

    [Required(ErrorMessage = "Please enter Actual Weight")]
    [Display(Name = "Actual Weight")]
    [Range(1, 999999999, ErrorMessage = "Actual Weight must be greater than zero")]
    public Decimal? ActualWeight { get; set; }

    [Display(Name = "Is Serial Number Required")]
    public bool IsSerialNumber { get; set; }

    [Display(Name = "Is Single")]
    public bool? IsSingle { get; set; }

    [Range(1, 999999999, ErrorMessage = "Charge Weight must be greater than zero")]
    [Display(Name = "Charge Weight")]
    [Required(ErrorMessage = "Please enter Charge Weight")]
    public Decimal ChargeWeight { get; set; }
    }
}
