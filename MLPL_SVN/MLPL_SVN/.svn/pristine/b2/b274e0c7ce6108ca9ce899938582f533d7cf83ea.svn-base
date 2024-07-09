//  
// Type: CodeLock.Areas.Master.Repository.RulesRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Repository;
using Dapper;
using System;
using System.Data;

namespace CodeLock.Areas.Master.Repository
{
  public class RulesRepository : BaseRepository, IRulesRepository, IDisposable
  {
    public string GetModuleRuleByIdAndRuleId(byte moduleId, short ruleId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ModuleId", (object) moduleId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@RuleId", (object) ruleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@RuleValue", (object) null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(100));
      DataBaseFactory.QuerySP("Usp_MasterRules_GetModuleRuleByIdAndRuleId", (object) dynamicParameters, "CustomerContract Master - GetModuleRuleByIdAndRuleId");
      return dynamicParameters.Get<string>("@RuleValue");
    }

    public string GetModuleRuleByIdAndRuleIdAndPaybasId(byte moduleId, short ruleId, byte paybasId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ModuleId", (object) moduleId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@RuleId", (object) ruleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PaybasId", (object) paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@RuleValue", (object) null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(100));
      DataBaseFactory.QuerySP("Usp_MasterRules_GetModuleRuleByIdAndRuleIdAndPaybasId", (object) dynamicParameters, "CustomerContract Master - GetModuleRuleByIdAndRuleIdAndPaybasId");
      return dynamicParameters.Get<string>("@RuleValue");
    }
  }
}
