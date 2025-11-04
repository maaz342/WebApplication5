using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class CheckOutController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<ApplicationUser> _userManager; 
        
        public CheckOutController(ApplicationDbContext applicationDbContext,UserManager<ApplicationUser> userManager)
        {
            _context = applicationDbContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);

            var addresses = await _context.Addresses
                .Include(x => x.User)
                .Where(x => x.UserId == currentuser.Id)
                .ToListAsync();

            ViewBag.Addresses = addresses;

            return View();
        }
        public async Task<IActionResult> Confirm(int addressid)
        {
            var address = await _context.Addresses.Where(x => x.Id == addressid).FirstOrDefaultAsync();
            if (address == null)
            {
                return BadRequest();
            }
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            double orderCost = 0;

            var carts = await _context.Carts
                .Include(x => x.Product)
                .Where(x => x.UserId == currentuser.Id).ToListAsync();

            foreach (var cart in carts)
            {
                orderCost += (cart.Product.price * cart.QTY);
            }
            var order = new Order
            {
                AddressId = addressid,
                CreatedAt = DateTime.Now,
                Status = "Order Place",
                UserId = currentuser.Id,
                Amount = orderCost,

            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            foreach (var cart in carts)
            {
                var orderProduct = new OrderProduct
                {
                    ProductId = cart.ProductId,
                    OrderId = order.Id,
                    Price = cart.Product.price,
                    Qty = cart.QTY,
                };
                _context.Add(orderProduct);

            }
            await _context.SaveChangesAsync();

            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        [HttpPost]
            public async Task<IActionResult> Index(Address address)
        {
            if (ModelState.IsValid)
            {
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);
                address.UserId = currentuser.Id;
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction("ThankYou");
            }
            return View(address);

        }
    }
}
