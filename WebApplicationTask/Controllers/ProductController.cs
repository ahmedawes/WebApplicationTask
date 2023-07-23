using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplicationTask.Data;
using WebApplicationTask.Models;

namespace WebApplicationTask.Controllers
{
	[Authorize]
	public class ProductController : Controller
    {
        private readonly AppDbContext _Context;
        public ProductController(AppDbContext context)
        {
            _Context = context;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            List<Product> ListOfProducts =_Context.Products.ToList();
            return View(ListOfProducts);
        }

      

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod )
        {
            if (ModelState.IsValid)
            {
                _Context.Products.Add( prod );
                _Context.SaveChanges();
			    TempData["success"] = "Category created Successfully";
			    return RedirectToAction("Index");   
            }
            else
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product? data = _Context.Products.FirstOrDefault(e=>e.Id==id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
               _Context.Products.Update(prod);
               _Context.SaveChanges();
			    TempData["Success"] = "Product Edited Successfully";
				return RedirectToAction("Index");
			}
			else 
            {
               return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int Id)
        {
            Product? DataForDelete = _Context.Products.FirstOrDefault(e=>e.Id == Id);
            if (DataForDelete == null)
            {
                return NotFound();
            }
            return View(DataForDelete);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product prod)
        {
            _Context.Products.Remove(prod);
            _Context.SaveChanges();
			TempData["Success"] = "Category Deleted Successfully";
			return RedirectToAction("Index");
        }
    }
}
