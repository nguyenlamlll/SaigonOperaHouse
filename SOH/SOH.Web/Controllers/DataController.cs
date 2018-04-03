using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SOH.Web.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SOH.Web.Controllers
{
    [Route("api/data")]
    public class DataController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public DataController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost("seed-default-data")]
        public IActionResult SeedDefaultData()
        {
            // Add superuser. If existed, get the superuser to create other entities.
            var user = new ApplicationUser()
            {
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
            };
            if (!dbContext.Users.Any(u => u.UserName == user.UserName))
            {
                //var password = new PasswordHasher<ApplicationUser>();
                //var hashed = password.HashPassword(user, "admin");
                //user.PasswordHash = hashed;

                userManager.CreateAsync(user, "admin123");
            }
            else
            {
                user = dbContext.Users.Where(u => u.UserName == "admin@admin.com").Single();
            }

            // Add a few posts
            List<Post> postList = new List<Post>
            {
                new Post()
                {
                    Title = "Fulfill your dream: check out our audition calendar",
                    Content = "This is your blog post. Blogs are a great way to connect with your audience and keep them coming back. They can also be a great way to position yourself as an authority in your field. To edit your content, simply click here to open the Blog Manager. From the Blog Manager you can edit posts and also add a brand new post in a breeze.     Great looking images make your blog posts more visually compelling for your audience, so choose images that really wow. Adding fun and compelling videos is another great way to engage your audience and keep them coming back for more. And to organize your posts according to subject-matter, define a ‘Category’ for each post in the Blog Manager.",
                    ApplicationUserId = user.Id,
                    LastAccessed = DateTime.UtcNow
                },
                new Post()
                {
                    Title = "Our most recent production is exactly what you were looking for",
                    Content = "This is your blog post. Blogs are a great way to connect with your audience and keep them coming back. They can also be a great way to position yourself as an authority in your field. To edit your content, simply click here to open the Blog Manager. From the Blog Manager you can edit posts and also add a brand new post in a breeze.     Great looking images make your blog posts more visually compelling for your audience, so choose images that really wow. Adding fun and compelling videos is another great way to engage your audience and keep them coming back for more. And to organize your posts according to subject-matter, define a ‘Category’ for each post in the Blog Manager.",
                    ApplicationUserId = user.Id,
                    LastAccessed = DateTime.UtcNow
                },
                new Post()
                {
                    Title = "A rant or two about my new discoveries",
                    Content = "Nothing is new, everything is borrowed. Who created that first? I don't know. We don't know.",
                    ApplicationUserId = user.Id,
                    LastAccessed = DateTime.UtcNow
                },
                new Post()
                {
                    Title = "The sky is bright and the dirt is tight",
                    Content = "A default post for testing. A default post for testing.",
                    ApplicationUserId = user.Id,
                    LastAccessed = DateTime.UtcNow
                }
            };
            foreach (var post in postList)
            {
                if (!dbContext.Posts.Any(p => p.Title == post.Title))
                {
                    dbContext.Posts.Add(post);
                    dbContext.SaveChanges();
                }
            }

            // Add a few events
            List<Event> eventList = new List<Event>()
            {
                new Event()
                {
                    StartingDate = new DateTime(2018, 4, 10),
                    Title = "Garden sounds",
                    Description = "Viva la the gardeners."
                },
                new Event()
                {
                    StartingDate = new DateTime(2018, 4, 1),
                    EndingDate = new DateTime(2018, 6, 1),
                    Title = "Free tour during weekends!",
                    Description = "We offer free tour and tour guide to help you discover our beautiful house during weekends of this event timeline. Contact us now!"
                }
            };
            foreach (var e in eventList)
            {
                if (!dbContext.Events.Any(ev => ev.Title == e.Title))
                {
                    dbContext.Events.Add(e);
                    dbContext.SaveChanges();
                }
            }

            // Add a few customer

            // Add a few products
            List<Product> productList = new List<Product>()
            {
                new Product()
                {
                    Title = "AA Disc From 1950",
                    Price = 1500000,
                    StockQuantity = 10
                },
                new Product()
                {
                    Title = "Fancy SOH T-Shirt",
                    Price = 250000,
                    StockQuantity = 150
                },
                new Product()
                {
                    Title = "Bests of Schubert 1 CD Disc",
                    Price = 120000,
                    StockQuantity = 80
                },
                new Product()
                {
                    Title = "Bests of Mozart 1 Vinyl",
                    Price = 500000,
                    StockQuantity = 20
                }
            };
            foreach (var product in productList)
            {
                if (!dbContext.Products.Any(prod => prod.Title == product.Title))
                {
                    dbContext.Products.Add(product);
                    dbContext.SaveChanges();
                }
            }

            return RedirectToPage("/Admin");
        }

    }
}
