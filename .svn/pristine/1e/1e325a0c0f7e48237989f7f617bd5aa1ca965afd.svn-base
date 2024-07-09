using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Base
  {
    public Base()
    {
      this.EntryBy = SessionUtility.LoginUserId;
      this.UpdateBy = new short?(SessionUtility.LoginUserId);
      this.CompanyId = SessionUtility.CompanyId;
    }

    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }

    [Display(Name = "Entry By")]
    public short EntryBy { get; set; }

    [Display(Name = "Entry Date")]
    public DateTime EntryDate { get; set; }

    [Display(Name = "Update By")]
    public short? UpdateBy { get; set; }

    [Display(Name = "Update Date")]
    public DateTime? UpdateDate { get; set; }

    [Display(Name = "Company Id")]
    public byte CompanyId { get; set; }

    [Display(Name = "Warehouse")]
    public short WarehouseId { get; set; }
  }
}
