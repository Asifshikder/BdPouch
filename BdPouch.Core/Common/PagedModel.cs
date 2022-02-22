using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Core.Common
{
    public class PagedModel<T>
    {
        public IEnumerable<T> Models { get; set; }
        public PagedList PagedList { get; set; }
        public int TotalEntity { get; set; }
        public int FirstSerialNumber { get; set; }
    }
}
