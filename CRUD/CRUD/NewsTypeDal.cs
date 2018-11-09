using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CRUD
{
  public  class NewsTypeDal
    {
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public List<TypeInfo> GetNewsList()
        {
            string Sql = "select * from Typeinfo";
            DataTable table = SqlHeper.GetEntityList(Sql, CommandType.Text);
            List<TypeInfo> list = null;
            if (table.Rows.Count > 0)
            {
                list = new List<TypeInfo>();
                TypeInfo newsINfo = null;
                foreach (DataRow row in table.Rows)
                {
                    newsINfo = new TypeInfo();
                    LoadEntity(row, newsINfo);
                    list.Add(newsINfo);
                }
            }
            return list;
        }

        private void LoadEntity(DataRow row, TypeInfo typeInfo)
        {
            typeInfo.TypeId = Convert.ToInt32(row["TypeId"]);
            typeInfo.TypeConent = row["TypeConent"].ToString();
        }
    }
}
