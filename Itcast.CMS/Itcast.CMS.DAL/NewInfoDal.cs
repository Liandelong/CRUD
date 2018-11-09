using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Itcast.CMS.Model;
namespace Itcast.CMS.DAL
{
    public class NewInfoDal
    {
        public List<T_New> GetEntityList()
        {
            string sql = "select * from T_News";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<T_New> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<T_New>();
                T_New newInfo = null;
                foreach (DataRow row in da.Rows)
                {
                    newInfo = new T_New();
                    LoadEntity(row, newInfo);
                    list.Add(newInfo);
                }
            }
            return list;
        }

        public List<T_New> GetPageEntityList(int start, int end)
        {
            string sql = "select * from (select row_number() over(order by id) as num, * from T_News) as t where t.num>=@start and t.num<=@end";
            SqlParameter[] pars = { 
                                   new SqlParameter("@start",start),
                                   new SqlParameter("@end",end)
                                  };
            DataTable da = SqlHelper.GetTable(sql,CommandType.Text,pars);
            List<T_New> newInfoList = null;
            if (da.Rows.Count > 0)
            {
                newInfoList = new List<T_New>();
                T_New newInfo = null;
                foreach (DataRow row in da.Rows)
                {
                    newInfo = new T_New();
                    LoadEntity(row, newInfo);
                    newInfoList.Add(newInfo);
                }
            }
            return newInfoList;
        }

        public void LoadEntity(DataRow row, T_New newInfo)
        {
            newInfo.Id = Convert.ToInt32(row["Id"]);
            newInfo.Title = row["Title"] != DBNull.Value ? row["Title"].ToString() : string.Empty;
            newInfo.Msg = row["Msg"] != DBNull.Value ? row["Msg"].ToString() : string.Empty;
            newInfo.ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : string.Empty;
            newInfo.SubDateTime = Convert.ToDateTime(row["SubDateTime"]);
            newInfo.Author = row["Author"] != DBNull.Value ? row["Author"].ToString() : string.Empty;
        }
        public T_New GetEntityModel(int id)
        {
            string sql = "select * from T_News where Id=@Id";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@Id", id));
            T_New newInfo = null;
            if (da.Rows.Count > 0)
            {
                newInfo = new T_New();
                LoadEntity(da.Rows[0], newInfo);
            }
            return newInfo;
        }

        public int DeleteEntityModel(int id)
        {
            string sql = "delete from T_News where Id=@Id";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@Id", id));
        }
        public int InsertEntityModel(T_New newInfo)
        {
            string sql = "insert into T_News(Title,Msg,Author,SubDateTime,ImagePath) values(@Title,@Msg,@Author,@SubDateTime,@ImagePath)";
            SqlParameter[] pars = { 
                                 new SqlParameter("@Title",SqlDbType.NVarChar,32),
                                 new SqlParameter("@Msg",SqlDbType.NVarChar),
                                   new SqlParameter("@Author",SqlDbType.NVarChar,32),
                                   new SqlParameter("@SubDateTime",SqlDbType.DateTime),
                                   new SqlParameter("@ImagePath",SqlDbType.NVarChar,100)
                                 };
            pars[0].Value = newInfo.Title;
            pars[1].Value = newInfo.Msg;
            pars[2].Value = newInfo.Author;
            pars[3].Value = newInfo.SubDateTime;
            pars[4].Value = newInfo.ImagePath;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }
        public int UpdateEntityModel(T_New newInfo)
        {
            string sql = "update T_News set Title=@Title,Msg=@Msg,Author=@Author,SubDateTime=@SubDateTime,ImagePath=@ImagePath where Id=@Id";
            SqlParameter[] pars = { 
                                 new SqlParameter("@Title",SqlDbType.NVarChar,32),
                                  new SqlParameter("@Author",SqlDbType.NVarChar,32),
                                 new SqlParameter("@Msg",SqlDbType.NVarChar),
                                   new SqlParameter("@SubDateTime",SqlDbType.DateTime),
                                   new SqlParameter("@ImagePath",SqlDbType.NVarChar,100),
                                     new SqlParameter("@Id",SqlDbType.Int,4)
                                 };
            pars[0].Value = newInfo.Title;
            pars[1].Value = newInfo.Author;
            pars[2].Value = newInfo.Msg;
            pars[3].Value = newInfo.SubDateTime;
            pars[4].Value = newInfo.ImagePath;
            pars[5].Value = newInfo.Id;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        public int GetRecordCount()
        {
            string sql = "select count(*) from T_News";
            int count =Convert.ToInt32(SqlHelper.ExecuteScalar(sql, CommandType.Text));
            return count;
        }
    }
}
