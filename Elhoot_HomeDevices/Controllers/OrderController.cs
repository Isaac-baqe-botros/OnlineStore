using Elhoot_HomeDevices.Data;
using Microsoft.AspNetCore.Mvc;

namespace Elhoot_HomeDevices.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int customerId ,string customername)
        {
            TempData["CustomerId"] = customerId;
            var order = _context.Orders.Where(o => o.CustomerId == customerId).OrderBy(o => o.productNmae).ToList();

            TempData["customername"] = customername;
            
            return View(order);
        }
        public IActionResult Create(string customername)
        {
            ViewBag.CustomerName = customername;
            var cust = _context.Customers.Find(TempData["CustomerId"]);
            if (cust == null)
            {
                return NotFound();
            }


            var order = new Order
            {
                CustomerId =(int)TempData["CustomerId"],
                Customer = cust
            };
            return View(order);
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            var custm = _context.Customers.Find(order.CustomerId);
            if (ModelState.IsValid)
            {

                order.RestPrice = (order.AllPrice * order.Total)-order.PayedPrice;
                order.PriceAfterBenfits = (((order.RestPrice * order.Penfits/100)*(order.Peroid))+(order.RestPrice));
                order.Enddate = order.Startdate.AddMonths(10);
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index", "Order", new { customerId =order.CustomerId, customername =custm.Name});
            }
            return View(order);
        }
        
    }
}
