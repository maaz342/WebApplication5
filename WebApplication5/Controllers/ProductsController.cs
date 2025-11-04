using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication5.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products=await _context.Products.ToListAsync();
            return View(products);
        }
        public async Task <IActionResult> Details(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.id == id);
            if (product == null)
            {
                return NotFound();
            }
           
            return View(product);
        }
    }
}
