//  
// Type: CodeLock.Repository.BaseRepository
//  
//  
//  

using CodeLock.Helper;
using System;

namespace CodeLock.Repository
{
  public class BaseRepository
  {
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed && disposing)
        DataBaseFactory.ConnString().Dispose();
      this.disposed = true;
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
