//  
// Type: CodeLock.Areas.Master.Repository.IAssetRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IAssetRepository : IDisposable
  {
    IEnumerable<MasterAsset> GetAll();

    MasterAsset GetById(byte id);

    byte Insert(MasterAsset objMasterAsset);

    byte Update(MasterAsset objMasterAsset);

    bool IsAssetNameAvailable(string assetName, short assetId);
  }
}
