using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SOH.Web.Services;

namespace SOH.Web.Pages
{
    public class BlogModel : PageModel
    {
        private readonly IPostService postService;
        public BlogModel(IPostService postService)
        {
            this.postService = postService;
        }

        public List<Data.Post> Posts { get; set; }

        public void OnGet()
        {
            Posts = postService.GetAllPost();
        }
    }
}