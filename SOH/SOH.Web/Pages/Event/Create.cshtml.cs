using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOH.Web.Data;

namespace SOH.Web.Pages.Event
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
            Images = _context.Images.ToList();
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Id");

            return Page();
        }

        [BindProperty]
        public Data.Event Event { get; set; }

        /// <summary>
        /// Existing images from database
        /// </summary>
        public IList<Data.Image> Images { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(Event);
            //foreach(var image in Event.Images)
            //{
            //    var updatedImage = _context.Images.Find(image.Id);
            //}
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}