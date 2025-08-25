using ASP_NET_Web_app.Data;
using ASP_NET_Web_app.Models;
using ASP_NET_Web_app.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Web_app.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db = new AppDbContext();
        private readonly IRepository<Category> _repo;

        public CategoryController() 
        { 
            _repo = new EfRepository<Category>(_db); 
        }

        public ActionResult Index()
        {
            var categories = _repo.All().OrderBy(c => c.CategoryName).ToList();
            return View(categories);
        }

        public ActionResult Create() => View(new Category());

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            if (!ModelState.IsValid) return View(model);
            _repo.Add(model); _repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var cat = _repo.Get(id.Value);
            if (cat == null) return HttpNotFound();
            return View(cat);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (!ModelState.IsValid) return View(model);
            _repo.Update(model); _repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var cat = _repo.Get(id.Value);
            if (cat == null) return HttpNotFound();
            return View(cat);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cat = _repo.Get(id);
            if (cat != null) { _repo.Remove(cat); _repo.Save(); }
            return RedirectToAction("Index");
        }
    }
}