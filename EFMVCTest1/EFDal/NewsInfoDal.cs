using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EFModel;
namespace EFDal
{
    public partial class NewsInfoDal : BaseDal<NewsInfo>
    {
        public override Expression<Func<NewsInfo, int>> GetKey()
        {
            return u => u.NewsId;
        }

        public override Expression<Func<NewsInfo, bool>> GetWhere(int id)
        {
            return u => u.NewsId == id;
        }
    }
}
