
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class BillCollectionDetail
  {
    public long BillId { get; set; }

    public bool IsChecked { get; set; }

    [Display(Name = "Bill Amount")]
    public Decimal BillAmount { get; set; }

    [AssertThat("BillAmount >= CollectionAmount", ErrorMessage = "CollectionAmount must be less less than or equal to BillAmount")]
    [Display(Name = "Collection Amount")]
    public Decimal CollectionAmount { get; set; }

    [Display(Name = "Tds")]
    [AssertThat("CollectionAmount >= Tds", ErrorMessage = "Tds must be less less than or equal to CollectionAmount")]
    public Decimal Tds { get; set; }

    public short CollectionUserId { get; set; }

    public short CollectionLocationId { get; set; }
  }
}
