using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOH.Web.Data;

namespace SOH.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Messages")]
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody]Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            _context.Messages.Add(message);
            _context.SaveChanges();

            return Ok();
        }
    }
}