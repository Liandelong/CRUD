using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast.CMS.Model
{
   public class T_NewComment
    {
       public int Id { get; set; }
       public int NewId { get; set; }
       public string Msg { get; set; }
       public DateTime CreateDateTime { get; set; }
    }
}
