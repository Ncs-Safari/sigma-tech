using Dapper;
using PaymentShared.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentShared
{
    public class Common
    {
        public Common()
        {
            
        }

        public IDbConnection DBConnection
        {
            get
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLServer);
                return new SqlConnection(AppMgtSetting.ConnectionString);
            }
        }

        public string GetErrorMessage(string MethodeName, Exception ex)
        {
            string errMessage = ex.Message;
            if (ex.InnerException != null)
            {
                errMessage = ex.InnerException.Message;
                if (ex.InnerException.InnerException != null)
                {
                    errMessage = ex.InnerException.InnerException.Message;
                    if (ex.InnerException.InnerException.InnerException != null)
                    {
                        errMessage = ex.InnerException.InnerException.InnerException.Message;
                    }
                }
            }
            var lineNumber = 0;
            const string lineSearch = ":line ";
            var index = ex.StackTrace.LastIndexOf(lineSearch);
            if (index != -1)
            {
                var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
                if (int.TryParse(lineNumberText, out lineNumber))
                {
                }
            }
            return MethodeName + ", line: " + lineNumber + Environment.NewLine + "Error Message: " + errMessage;
        }
    }
}
