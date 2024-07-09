using System;

namespace CodeLock.Models
{
  public class DateTimePicker
  {
    public DateTimePicker()
    {
      this.FieldId = this.FieldName = this.FieldCaption = string.Empty;
      this.AllowFutureDate = this.SetBlank = this.IsRequired = this.IsTimeOnly = false;
      this.AllowPastDate = this.IsDateOnly = this.IsValidateFinYear = this.UseFieldCaption = true;
      this.DefaultDate = new DateTime?(DateTime.Now);
    }

    public string FieldId { get; set; }

    public string FieldName { get; set; }

    public string FieldCaption { get; set; }

    public bool AllowFutureDate { get; set; }

    public bool AllowPastDate { get; set; }

    public bool SetBlank { get; set; }

    public bool IsRequired { get; set; }

    public bool IsDateOnly { get; set; }

    public bool IsValidateFinYear { get; set; }

    public bool IsTimeOnly { get; set; }

    public bool UseFieldCaption { get; set; }

    public DateTime? DefaultDate { get; set; }

    public DateTime? MinDate { get; set; }

    public DateTime? MaxDate { get; set; }
  }
}
