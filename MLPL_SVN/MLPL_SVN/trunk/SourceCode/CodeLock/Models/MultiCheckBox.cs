//  
// Type: CodeLock.Models.MultiCheckBox
//  
//  
//  

namespace CodeLock.Models
{
  public class MultiCheckBox
  {
    public MultiCheckBox()
    {
      this.Name = string.Empty;
      this.Value = string.Empty;
      this.IsChecked = false;
    }

    public string Name { get; set; }

    public string Value { get; set; }

    public bool IsChecked { get; set; }
  }
}
