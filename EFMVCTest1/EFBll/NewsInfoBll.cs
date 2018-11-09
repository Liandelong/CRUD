using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDal;
using EFModel;
namespace EFBll
{
    public partial class NewsInfoBll : BaseBll<NewsInfo>
    {
        public override BaseDal<NewsInfo> GetBaseDal()
        {
            return new NewsInfoDal();
        }
    }
}
