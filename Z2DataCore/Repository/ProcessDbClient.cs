using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Z2DataCore.Models;
using Z2DataCore.Translator;
using Z2DataCore.Utility;

namespace Z2DataCore.Repository
{
    public class ProcessDbClient
    {
        public List<Process> GetProcess(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<Process>>(connString, "GetProcess", r => r.TranslateAsProcessList());
        }
        
        public string SaveProcess(Process model,string connString)
        {
            
            SqlParameter[] param =
            {
                //@Date , @Name, @process must be identical to database
                new SqlParameter("@Date", model.DateProcess),
                new SqlParameter("@Name", model.CustomerName),
                new SqlParameter("@process", model.ProcessType)
                
            };
           return SqlHelper.ExecuteProcedureReturnString(connString, "SaveProcess", param);
        }
        
        public string DeleteProcess(int id,string connString)
        {
            
            SqlParameter[] param =
            {
                new SqlParameter("@Id", id),
            };
           return SqlHelper.ExecuteProcedureReturnString(connString, "DeleteProcess", param);
        }
        public string UpdateProcess(Process model,string connString)
        {
            
            SqlParameter[] param =
            {
                new SqlParameter("@Id", model.Id),
                new SqlParameter("@Date", model.DateProcess),
                new SqlParameter("@Name", model.CustomerName),
                new SqlParameter("@process", model.ProcessType)
                //,outParam
            };
           return SqlHelper.ExecuteProcedureReturnString(connString, "UpdateProcess", param);
          //  return (string)outParam.Value;
        }

    }
}
