using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CRUD
{
  public  class NewsInfoDal
    {
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public List<NewsInfo> GetNewsList()
        {
            string Sql = "select * from NewsInfo";
            DataTable table = SqlHeper.GetEntityList(Sql,CommandType.Text);
            List<NewsInfo> list=null;
            if (table.Rows.Count>0)
            {
                list = new List<NewsInfo>();
                NewsInfo newsINfo = null;
                foreach (DataRow row in table.Rows)
                {
                    newsINfo = new NewsInfo();
                    LoadEntity(row,newsINfo);
                    list.Add(newsINfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 添加一条新闻数据
        /// </summary>
        /// <param name="newsInfo">新闻对象</param>
        /// <returns></returns>
        public int InsertNews(NewsInfo newsInfo)
        {
            //NewsId, NewsConent, RegTime, TypeId
            string sql = "Insert into NewsInfo values(@NewsConent, @RegTime, @TypeId)";
            SqlParameter[] pars =
            {
                new SqlParameter("@NewsConent",SqlDbType.NVarChar),
                new SqlParameter("@RegTime",SqlDbType.DateTime),
                new SqlParameter("@TypeId",SqlDbType.Int)
            };
            pars[0].Value = newsInfo.NewsConent;
            pars[1].Value = newsInfo.RegTime;
            pars[2].Value = newsInfo.TypeId;
            return SqlHeper.EntityNunQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="row">DataTable行</param>
        /// <param name="newsINfo">新闻对象</param>
        private void LoadEntity(DataRow row, NewsInfo newsINfo)
        {
            newsINfo.NewsId = Convert.ToInt32(row["NewsId"]);
            newsINfo.NewsConent = row["NewsConent"].ToString();
            newsINfo.RegTime = Convert.ToDateTime(row["RegTime"]);
            newsINfo.TypeId =Convert.ToInt32(row["TypeId"]);
        }
    }
}
