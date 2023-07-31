using Elhoot_HomeDevices.Data;
using Microsoft.AspNetCore.Mvc;

namespace Elhoot_HomeDevices.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Custom = _context.Customers.OrderBy(c => c.Name).ToList();
            return View(Custom);
        }
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            { 
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        public IActionResult Edit(int id)
        {
            var result = _context.Customers.FirstOrDefault(c => c.Id == id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer, int id)
        {
            if (ModelState.IsValid) {
                var custm = _context.Customers.FirstOrDefault(c => c.Id == id);
                custm.Name = customer.Name;
                custm.Address = customer.Address;
                custm.Phone = customer.Phone;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int id)
        {
            var cust = _context.Customers.Find(id);
            if (cust == null)
            {
                // Customer with the specified ID was not found, handle the error accordingly
                return NotFound();
            }

            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConvermid(int id)
        {
            var cust = _context.Customers.Find(id);
            if (cust == null)
            {
                // Customer with the specified ID was not found, handle the error accordingly
                return NotFound();
            }

            _context.Customers.Remove(cust);
            _context.SaveChanges();

            // Redirect to a relevant action after successful deletion, e.g., back to the customer list
            return RedirectToAction("Index", "Customer");
        }

    }
}
