using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Demo.DB;
using Demo.Models;
using System.Data.Entity;

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
        public ActionResult Index(string buscar)
        {
            var query = entities.Posts.Include(x => x.Category);

            query = !String.IsNullOrEmpty(buscar) ? query.Where(x => x.Title.Contains(buscar)) : query;

            return View(query.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categorias = entities.Categories.ToList();
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
            ViewBag.Categorias = entities.Categories.ToList();
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Categorias = entities.Categories.ToList();
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
