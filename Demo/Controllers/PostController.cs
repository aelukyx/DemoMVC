using System.Collections.Generic;
using System.Linq;
using Demo.Interfaces.Services;
using System.Web.Mvc;
using Demo.Models.Models;
using Demo.Services.Services;

namespace Demo.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService service;
        public PostController(IPostService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View("Index", service.All());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            return View("Details",service.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Post post)
        { 
            // Guardar

            // si validacion no pasa retornamos el mismo formulario
            if (ValidationPass(post))
            {
                service.Insert(post);
                return RedirectToAction("Index");
            }
            return View("create", post);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           var model = service.GetById(id);
           return View("edit",model);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ValidationPass(post))
            {
                service.Update(post);
                return RedirectToAction("Index");
            }
            return View("Edit", post);
        }



        private bool ValidationPass(Post post)
        {
            if (string.IsNullOrEmpty(post.Title))
                return false;
            return true;

        }
        
        
    }
}
