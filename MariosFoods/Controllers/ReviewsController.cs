using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MariosFoods.Models;
using MariosFoods.Models.Repositories;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MariosFoods.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo;

        public ReviewsController(IReviewRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = thisRepo;
            }
        }

        // GET: /<controller>/
        public IActionResult Index()
        {


            return View(reviewRepo.Reviews.Include(reviews => reviews.Product).ToList());
        }


        public IActionResult Create(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            
            reviewRepo.Save(review);
            return RedirectToAction("Index", "Products", new { id = review.ProductId });
        }

        public IActionResult Edit(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            ViewBag.ProductId = new SelectList(reviewRepo.Products, "ProductId", "Name");
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            reviewRepo.Edit(review);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            reviewRepo.Remove(thisReview);
            return RedirectToAction("Index");
        }




    }
}
