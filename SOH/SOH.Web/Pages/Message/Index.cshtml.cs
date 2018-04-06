using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOH.Web.Data;

namespace SOH.Web.Pages.Message
{
    public class IndexModel : PageModel
    {
        private readonly SOH.Web.Data.ApplicationDbContext _context;

        public IndexModel(SOH.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Data.Message> Message { get;set; }

        public async Task OnGetAsync()
        {
            Message = await _context.Messages.ToListAsync();
        }
    }
}
