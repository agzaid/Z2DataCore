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
    public class UserDbClient
    {
        public List<Good> GetGoods(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<Good>>(connString, "GetGoods", r => r.TranslateAsUsersList());
        }
        
        public string SaveGood(Good model,string connString)
        {
            //var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            //{
            //    Direction = ParameterDirection.Output
            //};
            SqlParameter[] param =
            {
                new SqlParameter("@Id", model.Id),
                new SqlParameter("@Name", model.Name)
                //,outParam
            };
           return SqlHelper.ExecuteProcedureReturnString(connString, "SaveGoods", param);
          //  return (string)outParam.Value;
        }
        
        public string DeleteGood(int id,string connString)
        {
            //var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            //{
            //    Direction = ParameterDirection.Output
            //};
            SqlParameter[] param =
            {
                new SqlParameter("@Id", id),
                //,outParam
            };
           return SqlHelper.ExecuteProcedureReturnString(connString, "DeleteGood", param);
          //  return (string)outParam.Value;
        }
        public string UpdateGood(Good model,string connString)
        {
            //var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            //{
            //    Direction = ParameterDirection.Output
            //};
            SqlParameter[] param =
            {
                new SqlParameter("@Id", model.Id),
                new SqlParameter("@Name", model.Name),
                //,outParam
            };
           return SqlHelper.ExecuteProcedureReturnString(connString, "UpdateGood", param);
          //  return (string)outParam.Value;
        }

    }
}
