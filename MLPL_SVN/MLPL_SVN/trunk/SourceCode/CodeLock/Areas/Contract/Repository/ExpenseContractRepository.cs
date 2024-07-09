//  
// Type: CodeLock.Areas.Contract.Repository.ExpenseContractRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Contract.Repository
{
  public class ExpenseContractRepository : BaseRepository, IExpenseContractRepository
  {
    public Response InsertExpenseContract(ExpenseContract objExpenseContract)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlExpenseContract", (object) XmlUtility.XmlSerializeToString((object) objExpenseContract), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_ExpenseContract_InsertUpdate", (object) dynamicParameters, "Expense Contract - InsertUpdate").FirstOrDefault<Response>();
    }

    public IEnumerable<ExpenseContract> GetExpenseContractDetailBySearchingCriteria(
      short id,
      string expenseName,
      byte payBasId,
      string payBas,
      byte transportModeId,
      byte matrixType,
      short fromLocation,
      short toLocation)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ExpenseId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PaybasId", (object) payBasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@TransportModeId", (object) transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@MatrixTypeId", (object) matrixType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromLocationId", (object) fromLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToLocationId", (object) toLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<ExpenseContract>("Usp_ExpenseContract_GetExpenseContractDetail", (object) dynamicParameters, "Expense Contract - Insert");
    }
  }
}
