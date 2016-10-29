using System.Linq;
using DataAccessTutorial.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DataAccessTutorial.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsDbContext _productsDb;
        public HomeController(ProductsDbContext productsDb)
        {
            _productsDb = productsDb;
        }


        public IActionResult Index()
        {
            return View(_productsDb.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _productsDb.Products.Add(product);
            _productsDb.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {               
            return View(_productsDb.Products.Single(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _productsDb.Entry(product).State = EntityState.Modified;
            _productsDb.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {            
            _productsDb.Entry(new Product { Id = id}).State = EntityState.Deleted;
            _productsDb.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
