using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using WebApplicationTask.Models.Models;
using WebApplicationTask.Models.Repository;

namespace WebApplicationTask.Controllers
{
	[Authorize]
	public class ProductController : Controller
    {
        private readonly IBaseRepository<Product> _ProductRepository;
        private readonly IToastNotification _ToastNotification;
        public ProductController( IBaseRepository<Product> ProductRepository, IToastNotification ToastNotification)
        {
            _ProductRepository = ProductRepository;
            _ToastNotification = ToastNotification;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_ProductRepository.GetAll());
        }


        //GET: ProductController/Create
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
                _ProductRepository.Add( prod );
                _ProductRepository.SaveChanges();
                _ToastNotification.AddSuccessToastMessage("Product created Successfully");
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
            Product? data = _ProductRepository.Find(e => e.Id == id);
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
               _ProductRepository.Update( prod );
               _ProductRepository.SaveChanges();
				_ToastNotification.AddSuccessToastMessage("Product Edited Successfully");
				return RedirectToAction("Index");
			}
			else 
            {
               return View();
            }
        }


        // ProductController/Delete/5
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteBYid(int Id )
        {
            Product resualt = _ProductRepository.Find(e=> e.Id == Id);
            _ProductRepository.Remove(resualt);
            _ProductRepository.SaveChanges();
			//_ToastNotification.AddSuccessToastMessage("Product Deleted Successfully");
			return RedirectToAction("Index");
		}
    }
}
