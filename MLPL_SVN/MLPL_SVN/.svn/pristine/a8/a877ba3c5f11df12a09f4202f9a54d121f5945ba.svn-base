//  
// Type: CodeLock.Areas.Contract.Repository.IExpenseContractRepository
//  
//  
//  

using CodeLock.Models;
using System.Collections.Generic;

namespace CodeLock.Areas.Contract.Repository
{
  public interface IExpenseContractRepository
  {
    Response InsertExpenseContract(ExpenseContract objExpenseContract);

    IEnumerable<ExpenseContract> GetExpenseContractDetailBySearchingCriteria(
      short id,
      string expenseName,
      byte payBasId,
      string payBas,
      byte transportModeId,
      byte matrixType,
      short fromLocation,
      short toLocation);
  }
}
