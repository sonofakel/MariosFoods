using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MariosFoods.Models;
using MariosFoods.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MariosFoods.Controllers
{
    public class ProductsController : Controller
    {
        private MariosFoodsContext db = new MariosFoodsContext();
        private IProductRepository productRepo;

        public ProductsController(IProductRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = thisRepo;
            }
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(productRepo.Products.ToList());
        }
        public IActionResult Details(int id)
        {
            
            var thisProduct = productRepo.Products.Include(products => products.Reviews).FirstOrDefault(products => products.ProductId == id);
            ViewBag.Average = Product.AverageRating(thisProduct);
            return View(thisProduct);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productRepo.Save(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisProduct);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            productRepo.Edit(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisProduct);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProduct = productRepo.Products.First(products => products.ProductId == id);
            productRepo.Remove(thisProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
