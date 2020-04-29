using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess
{
    public class Functions
    {
        public static string GetDatabaseConnectionString(string myCon = "")
        {
            //string ConString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+"\"C:\\Users\\SAIRAM\\Documents\\Visual Studio 2013\\Projects\\GST_InvoiceApplication\\GST_InvoiceApplication\\GST.mdb\""+";Persist Security Info=True";
            string ConString;
            if (string.IsNullOrEmpty(myCon))
                ConString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString() + ";Persist Security Info=True";
            else
                ConString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + myCon + ";Persist Security Info=True";
            return ConString;
        }

        public static DataSet RunSelectSql(string sql)
        {
            return RunSelectSql( sql,GetDatabaseConnectionString());
        }

        public static DataSet RunSelectSqlWithCon(string sql,string con)
        {
            return RunSelectSql(sql, GetDatabaseConnectionString(con));
        }

        public static void RunExecuteNonQuery(string sql)
        {
            using (var con = new OleDbConnection(GetDatabaseConnectionString()))
            {
                con.Open();
                try
                {
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }


        public static void LogException(Exception ex)
        {
 
        }

        public static int RunExecuteScalarSql_getIdentity(string sql)
        {
            int identity = 0;
            using (var con = new OleDbConnection(GetDatabaseConnectionString()))
            {
                con.Open();
                try
                {
                    OleDbCommand cmd = new OleDbCommand(sql, con);

                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT @@IDENTITY";

                    object ss = cmd.ExecuteScalar();
                    identity = Convert.ToInt32(ss);
                    con.Close();
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }
                finally
                {
                    con.Close();
                }
            }
            return identity;
        }

        public static DataSet RunSelectSql( String sql,String dbConnStr)
        {
            DataSet ds = new DataSet();
            using (var con = new OleDbConnection(dbConnStr))
            {
                con.Open();
                try
                {
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                    da.Fill(ds);
                    da.Dispose();
                    da = null;
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }
                finally
                {
                    con.Close();
                }
            }
            return ds;
        }

        


    }
}
