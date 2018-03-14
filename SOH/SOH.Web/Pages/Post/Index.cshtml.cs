using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOH.Web.Data;

namespace SOH.Web.Pages.Post
{
    public class IndexModel : PageModel
    {
        private readonly SOH.Web.Data.ApplicationDbContext _context;

        public IndexModel(SOH.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Data.Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Posts
                .Include(p => p.Image).ToListAsync();
        }
    }
}
