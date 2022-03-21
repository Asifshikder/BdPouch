using BdPouch.Core.Common;

namespace BdPouch.Web.Models
{
    public class Pager
    {
        public string StringUrl { get; set; }
        public string FunctionName { get; set; }
        public PagedList PagedList { get; set; }
    }
}
