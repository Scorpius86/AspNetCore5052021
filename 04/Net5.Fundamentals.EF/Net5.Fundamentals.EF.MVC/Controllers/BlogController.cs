using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost([Bind("PostId,Titulo,Resumen,Contenido")] PostViewModel postViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _blogService.InsertPost(postViewModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(postViewModel);
            }
            catch(Exception ex)
            {
                return View(postViewModel);
            }            
        }

        [HttpGet]
        public IActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PostViewModel postViewModel = _blogService.GetPostById(id.Value);
            if (postViewModel == null)
            {
                return NotFound();
            }

            return View(postViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(int id, [Bind("PostId,Titulo,Resumen,Contenido")] PostViewModel postViewModel)
        {
            if (id != postViewModel.PostId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _blogService.UpdatePost(postViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_blogService.PostExists(postViewModel.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(postViewModel);
        }

        [HttpGet]
        public IActionResult DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PostViewModel postViewModel = _blogService.GetPostById(id.Value);
            if (postViewModel == null)
            {
                return NotFound();
            }

            return View(postViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            _blogService.DeletePost(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
