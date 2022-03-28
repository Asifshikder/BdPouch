using BdPouch.Core.Common;
using BdPouch.Core.Domain.cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.HomeBanners
{
    public interface IHomeBannerService
    {
        Task<Banner> GetHomeBanner();
        Task<Banner> Create(Banner model);
        Task<bool> Update(Banner model);
    }
}
