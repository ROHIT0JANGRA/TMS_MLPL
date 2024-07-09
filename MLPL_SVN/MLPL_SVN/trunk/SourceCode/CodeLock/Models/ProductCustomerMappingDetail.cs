//  
// Type: CodeLock.Models.ProductCustomerMappingDetail
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ProductCustomerMappingDetail : BaseModel
  {
    public short ConsignorId { get; set; }

    public int ProductId { get; set; }

    [Required(ErrorMessage = "Please enter Consignor")]
    public string ConsignorCode { get; set; }

    public short ConsigneeId { get; set; }

    [Required(ErrorMessage = "Please enter Consignee")]
    public string ConsigneeCode { get; set; }
  }
}
