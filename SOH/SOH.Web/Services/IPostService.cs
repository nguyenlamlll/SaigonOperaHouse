using SOH.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOH.Web.Services
{
    public interface IPostService
    {
        void Create(Post post);

        List<Post> GetAllPost();
    }
}
