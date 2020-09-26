using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DailyBlogger.Models;
using System.ComponentModel.DataAnnotations;

namespace DailyBlogger.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext _context;
         
        public BlogController(BlogContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            IEnumerable<BlogPost> posts = _context.blogPost.ToList<BlogPost>();
            return View(posts);
        }
        
        public IActionResult New()
        {
            BlogPost blogPost = new BlogPost();
            return View(blogPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public IActionResult Create([Bind("blogTitle,content,blogDate")] BlogPost  blogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogs);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(blogs);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
