using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BuildServiceTest.Helper
{
    public class SqlHelper
    {
        public static string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        public static DataTable executeDataTable(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    return dt;
                }
            }
        }

        public static int executeNonQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int executeNonQuery(SqlConnection con, SqlTransaction tran, string cmdText, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(cmdText, con))
            {
                cmd.Parameters.AddRange(parameters);
                cmd.Transaction = tran;
                return cmd.ExecuteNonQuery();
            }
        }

        public static object executeScalar(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static object executeScalar(SqlConnection con, SqlTransaction tran, string cmdText, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(cmdText, con))
            {
                cmd.Parameters.AddRange(parameters);
                cmd.Transaction = tran;
                return cmd.ExecuteScalar();
            }
        }
    }
}