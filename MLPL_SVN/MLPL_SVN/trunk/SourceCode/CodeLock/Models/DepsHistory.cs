//  
// Type: CodeLock.Models.DepsHistory
//  
//  
//  

namespace CodeLock.Models
{
  public class DepsHistory : Base
  {
    public long HistoryId { get; set; }

    public long DepsDocketId { get; set; }

    public short LocationId { get; set; }

    public byte FoundPackages { get; set; }

    public string Remark { get; set; }

    public int Packages { get; set; }
        public string UnloadingPersonName { get; set; }

    }
}
