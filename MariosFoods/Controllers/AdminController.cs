using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MariosFoods.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BasicAuthentication.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly MariosFoodsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoController(UserManager<ApplicationUser> userManager, MariosFoodsContext db)
        {
            _userManager = userManager;
            _db = db;
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            product.User = currentUser;
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index","Products");
        }
    }
}