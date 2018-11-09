using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
   public class NewsInfo
    {
        //NewsId, NewsConent, RegTime, TypeId
        public int NewsId { get; set; }
        public string NewsConent { get; set; }
        public DateTime RegTime { get; set; }
        public int TypeId { get; set; }
    }
}
