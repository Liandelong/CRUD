using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelper
{
    public static class SqlHelper
    {
        //连接数据库字符串
        private static readonly string constr = ConfigurationManager.ConnectionStrings["msSql"].ConnectionString;

        //增删改
        public static int ExecuteNonQuery(string str,params SqlParameter[] par)
        {
            using(SqlConnection con=new SqlConnection(constr))
            {
                using(SqlCommand cmd=new SqlCommand(str, con))
                {
                    if (par != null)
                    {
                        cmd.Parameters.AddRange(par);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                  

                }
            }
        }
        //查询，返回一条信息
        public static object ExecuteScalar(string str,params SqlParameter[] par)
        {
            using (SqlConnection con=new SqlConnection(constr))
            {
                using(SqlCommand cmd=new SqlCommand(str, con))
                {
                    if (par != null)
                    {
                        cmd.Parameters.AddRange(par);
                    }
                    con.Open();
                   return cmd.ExecuteScalar();
                }
            }
        }
        //查询，返回多条信息
        public static SqlDataReader ExecuteReader(string str,params SqlParameter[] par)
        {
            SqlConnection con = new SqlConnection(constr);
            using(SqlCommand cmd=new SqlCommand(str, con))
            {
                if (par != null)
                {
                    cmd.Parameters.AddRange(par);
                }
                try
                {
                   con.Open();
                   return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
               
            }
        }
    }
}
