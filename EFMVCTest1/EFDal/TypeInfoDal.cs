using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EFModel;
namespace EFDal
{
    public partial class TypeInfoDal : BaseDal<TypeInfo>
    {
        public override Expression<Func<TypeInfo, int>> GetKey()
        {
            return u => u.TypeId;
        }

        public override Expression<Func<TypeInfo, bool>> GetWhere(int id)
        {
            return u => u.TypeId == id;
        }
    }
}
