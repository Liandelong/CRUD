using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDal;
using EFModel;
namespace EFBll
{
    public partial class TypeInfoBll : BaseBll<TypeInfo>
    {
        public override BaseDal<TypeInfo> GetBaseDal()
        {
            return new TypeInfoDal();
        }
    }
}
