using LAB1MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAB1MVC.Controllers
{
    public class AboutController : Controller
    {
        // GET: AboutController
        public List<Product> Index()
        {
            //return View();
            //return Redirect("Home/Index");
            List<Product> products = new List<Product>();
            products.Add(new Product());
            products.Add(new Product());
            return products;
        }

        // GET: AboutController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AboutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AboutController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AboutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AboutController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AboutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
