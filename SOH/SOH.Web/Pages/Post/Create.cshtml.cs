using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOH.Web.Data;

namespace SOH.Web.Pages.Post
{
    public class CreateModel : PageModel
    {
        private readonly SOH.Web.Data.ApplicationDbContext _context;

        public CreateModel(SOH.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Data.Post Post { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}