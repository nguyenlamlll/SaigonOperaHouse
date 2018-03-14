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
    public class DetailsModel : PageModel
    {
        private readonly SOH.Web.Data.ApplicationDbContext _context;

        public DetailsModel(SOH.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Data.Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts
                .Include(p => p.Image).SingleOrDefaultAsync(m => m.Id == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
