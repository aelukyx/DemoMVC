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
        
        
    }
}
