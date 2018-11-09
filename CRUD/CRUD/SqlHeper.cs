using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CRUD
{
  public static  class SqlHeper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;//字符串连接

        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="type">执行方式</param>
        /// <param name="par">参数</param>
        /// <returns></returns>
        public static DataTable GetEntityList(string sql,CommandType type,params SqlParameter[] pars)
        {
            using (SqlConnection con=new SqlConnection(connStr))
            {
                using (SqlDataAdapter adpter=new SqlDataAdapter(sql, con))
                {
                    adpter.SelectCommand.CommandType = type;

                    if (pars != null)
                    {
                        adpter.SelectCommand.Parameters.AddRange(pars);
                    }
                    DataTable table = new DataTable();
                    adpter.Fill(table);
                    return table;
                }
            }
        }

        /// <summary>
        /// 增删改查
        /// </summary>
        /// <param name="sql">SQl语句</param>
        /// <param name="type">执行方式</param>
        /// <param name="pars">参数</param>
        /// <returns></returns>
        public static int EntityNunQuery(string sql,CommandType type,params SqlParameter[] pars)
        {
            using (SqlConnection con=new SqlConnection(connStr))
            {
                using (SqlCommand com=new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    if (pars != null)
                    {
                        com.Parameters.AddRange(pars);
                    }
                    con.Open();
                    try
                    {
                       return com.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        #region
        /// <summary>
        /// 查询一条信息
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static object EntityNonScalar(string sql,CommandType type,params SqlParameter[] pars)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = sql;
                    if (pars != null)
                    {
                        com.Parameters.AddRange(pars);
                    }
                    con.Open();
                    try
                    {
                        return com.ExecuteScalar();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        #endregion
    }
}
