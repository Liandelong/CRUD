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
   public class NewCommentDal
    {
       public int InsertEntityModel(T_NewComment newCommentInfo)
       {
           string sql = "insert into T_NewComments(NewId,Msg,CreateDateTime) values(@NewId,@Msg,@CreateDateTime)";
           SqlParameter[] pars = { 
                                 new SqlParameter("@NewId",SqlDbType.Int,4),
                                 new SqlParameter("@Msg",SqlDbType.NVarChar),
                                 
                                   new SqlParameter("@CreateDateTime",SqlDbType.DateTime)
                                   
                                 };
           pars[0].Value = newCommentInfo.NewId;
           pars[1].Value = newCommentInfo.Msg;
           pars[2].Value = newCommentInfo.CreateDateTime;
           return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
       }
       public List<T_NewComment> GetNewCommentList(int newId)
       {
           string sql = "select * from T_NewComments where NewId=@NewId";
           DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@NewId",newId));
           List<T_NewComment> CommentList = null;
           if (da.Rows.Count > 0)
           {
               CommentList = new List<T_NewComment>();
               T_NewComment Comment = null;
               foreach (DataRow row in da.Rows)
               {
                   Comment = new T_NewComment();
                   LoadEntity(row, Comment);
                   CommentList.Add(Comment);
               }
           }
           return CommentList;
       }
       public void LoadEntity(DataRow row, T_NewComment commentInfo)
       {
           commentInfo.Id = Convert.ToInt32(row["Id"]);
           commentInfo.NewId = Convert.ToInt32(row["Id"]);
           commentInfo.Msg = row["Msg"] != DBNull.Value ? row["Msg"].ToString() : string.Empty;
           commentInfo.CreateDateTime = Convert.ToDateTime(row["CreateDateTime"]);
       }
    }
}
