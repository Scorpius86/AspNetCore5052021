using Microsoft.AspNetCore.Mvc;
using Net5.Fundamentals.EF.MVC.Models;
using Net5.Fundamentals.EF.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Fundamentals.EF.MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {            
            return View(_blogService.ListPosts());
        }

        public IActionResult PostDetails(int id)
        {
            return View(_blogService.GetPostById(id));
        }
        [HttpGet]
        public IActionResult EditPost (int? id)
        {
            if (id == null) {
                return NotFound();
            }

            PostViewModel postViewModel = _blogService.GetPostById(id.Value);
            if(postViewModel == null)
            {
                return NotFound();
            }

            return View(postViewModel);
        }
    }
}
