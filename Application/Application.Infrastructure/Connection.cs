using Microsoft.Data.SqlClient;
using MyApplication.Domain.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Infrastructure
{
    internal static class Connection
    {
        internal static SqlConnection GetConnection()
        {
            try
            {
                //Wrong Database Connection for testing
                //SqlConnection conn = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi499768_i499768;User Id=dbi499768_i499768;Password=originalDB01;Encrypt=False;");
                
                //Right Database Connection
                SqlConnection conn = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi499768;User Id=dbi499768;Password=Kudripseugo6;Encrypt=False;");
                
                conn.Open();
                return conn;
            }
            catch
            {
                throw new ConnectionException("Connection to database failed");
            }
        }
    }
}
