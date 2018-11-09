using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast.CMS.BLL
{
   public class NewInfoService
    {
       DAL.NewInfoDal NewInfoDal = new DAL.NewInfoDal();
       public List<T_New> GetPageEntityList(int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           return NewInfoDal.GetPageEntityList(start, end);
       }
       public int GetPageCount(int pageSize)
       {
           int recordCount = NewInfoDal.GetRecordCount();
           int pageCount =Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public T_New GetModel(int id)
       {
           return NewInfoDal.GetEntityModel(id);
       }
       public bool DeleteEntityModel(int id)
       {
           return NewInfoDal.DeleteEntityModel(id) > 0;
       }
       public bool InsertEntityModel(T_New newInfo)
       {
           return NewInfoDal.InsertEntityModel(newInfo)>0;
       }
       public bool UpdateEntityModel(T_New newInfo)
       {
           return NewInfoDal.UpdateEntityModel(newInfo) > 0;
       }
    }
}
