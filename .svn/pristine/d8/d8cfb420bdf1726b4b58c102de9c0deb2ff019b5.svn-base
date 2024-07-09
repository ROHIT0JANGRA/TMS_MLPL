//  
// Type: CodeLock.Models.MasterAsset
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterAsset : BaseModel
  {
    public string UnitsOfMeasurement { get; set; }

    public short AssetId { get; set; }

    [Display(Name = "Asset Code")]
    public string AssetCode { get; set; }

    [Display(Name = "Asset Name")]
    [Required(ErrorMessage = "Please enter Asset Name")]
    //[NameAnnotation]
    [StringLength(100, ErrorMessage = "Asset Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Remote("IsAssetNameAvailable", "Asset", AdditionalFields = "AssetId,_AssetIdToken", ErrorMessage = "Asset Name already exists.", HttpMethod = "POST")]
    public string AssetName { get; set; }

    [Required(ErrorMessage = "Please enter Asset Prefix")]
    [Display(Name = "Asset Prefix")]
    [StringLength(100, ErrorMessage = "Asset Prefix must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    public string AssetPrefix { get; set; }

    [Required(ErrorMessage = "Please select Asset Group")]
    [Display(Name = "Asset Group")]
    public short AssetGroupId { get; set; }

    [Required(ErrorMessage = "Please select Units Of Measurement")]
    [Display(Name = "Units Of Measurement")]
    public byte UomId { get; set; }

    [Required(ErrorMessage = "Please select Asset Category")]
    [Display(Name = "Asset Category")]
    public byte AssetCategory { get; set; }

    [Display(Name = "Asset Category")]
    public string Category { get; set; }

    [Display(Name = "Depreciation Method")]
    [Required(ErrorMessage = "Please select Depreciation Method")]
    public byte DepreciationMethod { get; set; }

    [Display(Name = "Depreciation Method")]
    public string Method { get; set; }

    [Required(ErrorMessage = "Please enter Depreciation Rate")]
    [Display(Name = "Depreciation Rate (%)")]
    [Range(0, 2147483647, ErrorMessage = "Depreciation Rate must be a positive number")]
    public Decimal DepreciationRate { get; set; }

    [Display(Name = "Asset Group")]
    public string AssetGroup { get; set; }
  }
}
