using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.EntityLayer.Concrete
{
    public class BlogPuan
    {
        public int BlogPuanID { get; set; }
        public int BlogID { get; set; }
        public int BlogTotalPuan { get; set; }
        public int BlogPuanCount { get; set; }

    }
}
