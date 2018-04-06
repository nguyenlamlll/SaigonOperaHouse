using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOH.Web.Data;

namespace SOH.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Data.Event> Events { get; set; }

        public IList<Data.Post> Posts { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events
                .Include(e => e.Images)
                .OrderByDescending(e => e.StartingDate)
                .ToListAsync();
            if (Events.Count >= 4)
            {
                Events = Events.Take(4).ToList();
            }
            
            Posts = await _context.Posts
                .Include(p => p.Image)
                .OrderByDescending(p => p.Created)
                .ToListAsync();
            if (Posts.Count >= 4)
            {
                Posts = Posts.Take(4).ToList();
            }
        }


    }
}
