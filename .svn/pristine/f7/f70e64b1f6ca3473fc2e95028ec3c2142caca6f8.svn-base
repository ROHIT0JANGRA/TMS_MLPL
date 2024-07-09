//  
// Type: CodeLock.Areas.Master.Repository.IProductCustomerRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IProductCustomerRepository : IDisposable
  {
    IEnumerable<ProductCustomerMappingDetail> GetCustomerMappingList(
      int productId);

    Response Mapping(ProductCustomerMapping objProductCustomerMapping);
  }
}
