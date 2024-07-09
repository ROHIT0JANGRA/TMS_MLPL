//  
// Type: CodeLock.Areas.Master.Repository.IProductRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IProductRepository : IDisposable
  {
    IEnumerable<MasterProduct> GetAll();

    int Insert(MasterProduct objMasterproduct);

    int Update(MasterProduct objMasterproduct);

    MasterProduct GetById(byte companyId, int productId);

    bool IsProductNameAvailable(string productName, int productId);

    IEnumerable<AutoCompleteResult> GetPartAutoCompleteList(
      string productName,
      short consignorId,
      short consigneeId,
      byte companyId);

    MasterProduct IsPartCodeExist(
      string productName,
      short consignorId,
      short consigneeId,
      byte companyId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteProductList(
      byte companyId,
      string productCode);

    MasterProduct IsProductCodeExist(byte companyId, string productCode);

    IEnumerable<ProductCustomerMappingDetail> GetCustomerMappingList(
      int productId);

    ProductCustomerMapping GetProductCodeAndNameById(int productId);

    Response Mapping(ProductCustomerMapping objProductCustomerMapping);
    MasterProductPartExist IsPartCodeExistByPart(
     string productName,
     short consignorId,
     short consigneeId,
     byte companyId);

    MasterProductPartExist IsPartCodeExistByPartName(
     string productName,
     short consignorId,
     short consigneeId,
     byte companyId);
    }
}
