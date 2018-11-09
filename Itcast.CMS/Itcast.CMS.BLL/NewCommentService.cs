using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast.CMS.BLL
{
   public class NewCommentService
    {
       DAL.NewCommentDal NewCommentDal = new DAL.NewCommentDal();
       public bool InsertEntityModel(T_NewComment newCommentInfo)
       {
           return NewCommentDal.InsertEntityModel(newCommentInfo) > 0;
       }
       public List<T_NewComment> GetNewCommentList(int newId)
       {
           return NewCommentDal.GetNewCommentList(newId);
       }
    }
}
