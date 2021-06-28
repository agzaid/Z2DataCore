using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z2DataCore.Models;
using Z2DataCore.Utility;

namespace Z2DataCore.Translator
{
    public static class ProcessTranslator
    {
        public static Process TranslateAsProcess(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Process();
            if (reader.IsColumnExists("Id"))
                item.Id = SqlHelper.GetNullableInt32(reader, "Id");

            if (reader.IsColumnExists("CustomerName"))
                item.CustomerName = SqlHelper.GetNullableString(reader, "CustomerName");
            
            if (reader.IsColumnExists("DateProcess"))
                item.DateProcess = (SqlHelper.GetNullableDate(reader, "DateProcess"));
            
            if (reader.IsColumnExists("ProcessType"))
                item.ProcessType = SqlHelper.GetNullableInt32(reader, "ProcessType");

            return item;
        }

        public static List<Process> TranslateAsProcessList(this SqlDataReader reader)
        {
            var list = new List<Process>();
            while (reader.Read())
            {
                list.Add(TranslateAsProcess(reader, true));
            }
            return list;
        }
    }

}
