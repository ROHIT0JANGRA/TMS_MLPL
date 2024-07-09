//  
// Type: CodeLock.Models.WarehouseStock
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class WarehouseStock
  {
    [Display(Name = "Product")]
    public string ProductCode { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public string Uom { get; set; }

    [Required(ErrorMessage = "Please select warehouse")]
    [Display(Name = "Warehouse")]
    public string WarehouseId { get; set; }

    [Display(Name = "Bin")]
    public short BindId { get; set; }

    public string BinCode { get; set; }

    public string BinName { get; set; }

    [Display(Name = "Company")]
    [Required(ErrorMessage = "Please select company")]
    public string CompanyId { get; set; }
  }
}
