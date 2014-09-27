using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Demo.DB;
using Demo.Models;

namespace Demo.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/
        private readonly DemoEntities entities;

        public PostController()
        {
            this.entities = new DemoEntities();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = entities.Posts.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                entities.Posts.Add(post);
                entities.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(entities.Posts.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Post model)
        {
            entities.Entry(model).State = EntityState.Modified;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = entities.Posts.Find(id);
            entities.Posts.Remove(model);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
