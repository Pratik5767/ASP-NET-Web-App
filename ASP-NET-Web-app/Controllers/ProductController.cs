using ASP_NET_Web_app.Data;
using ASP_NET_Web_app.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ASP_NET_Web_app.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db = new AppDbContext();

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (page < 1) page = 1;

            var totalCount = _db.Products.Count();

            var items = _db.Products
                           .OrderBy(p => p.ProductId)
                           .Include(p => p.Category)
                           .Skip((page - 1) * pageSize)
                           .Take(pageSize)
                           .Select(p => new ProductListItemVm
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               CategoryId = p.CategoryId,
                               CategoryName = p.Category.CategoryName
                           })
                           .ToList();

            var vm = new PagedResult<ProductListItemVm>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };

            return View(vm);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories.OrderBy(c => c.CategoryName), "CategoryId", "CategoryName");
            return View(new Product());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "CategoryName", model.CategoryId);
                return View(model);
            }
            _db.Products.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var prod = _db.Products.Find(id);
            if (prod == null) return HttpNotFound();
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "CategoryName", prod.CategoryId);
            return View(prod);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "CategoryName", model.CategoryId);
                return View(model);
            }
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var prod = _db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (prod == null) return HttpNotFound();
            return View(prod);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var prod = _db.Products.Find(id);
            if (prod != null)
            {
                _db.Products.Remove(prod);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

    // View models
    public class ProductListItemVm
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class PagedResult<T>
    {
        public IList<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)System.Math.Ceiling((double)TotalCount / PageSize);
    }
}