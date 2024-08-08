namespace CodeLock.Models
{
  public class AutoCompleteResult
  {
    public AutoCompleteResult()
    {
      this.Name = string.Empty;
      this.Value = string.Empty;
            this.Text = string.Empty;
    }

    public string Name { get; set; }

    public string Value { get; set; }
        public string Text { get; set; }   // This is the text that will be displayed in the dropdown

        public string Description { get; set; }
     
        public bool IsActive { get; set; }
  }
}
