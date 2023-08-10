using Elhoot_HomeDevices.Data;
using Elhoot_HomeDevices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Elhoot_HomeDevices.Controllers
{
    public class DayenaaatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DayenaaatController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var madunaates = _context.dayeenateys.ToList();
            decimal totalMoney = madunaates.Sum(m => m.Money);

            var viewModel = new EldunaateViewModel
            {
                  dayeenateys = madunaates,
                TotalMoney = totalMoney
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dayeenatey madunaate)
        {
            if (ModelState.IsValid)
            {
                _context.dayeenateys.Add(madunaate);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(madunaate);
        }

        public IActionResult Delete(int id)
        {
            var madunaate = _context.dayeenateys.FirstOrDefault(m => m.Id == id);

            if (madunaate != null)
            {
                // Get the money value before deleting
                decimal moneyBeforeDeletion = madunaate.Money;

                // Remove the record
                _context.dayeenateys.Remove(madunaate);
                _context.SaveChanges();

                // Update the total money by subtracting the deleted record's money
               


                return RedirectToAction("Index");
            }

            return NotFound();
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var madunaate = _context.dayeenateys.Find(id);
            if (madunaate == null)
            {
                return NotFound();
            }

            return View(madunaate);
        }

        [HttpPost]
        public IActionResult Edit(int id, Dayeenatey editedMadunaate)
        {
            if (id != editedMadunaate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var originalMadunaate = _context.dayeenateys.Find(id);
                if (originalMadunaate != null)
                {
                    // Get the money value before editing
                   

                    // Update the properties
                    originalMadunaate.Name = editedMadunaate.Name;
                    originalMadunaate.Money = editedMadunaate.Money;
                    originalMadunaate.date = editedMadunaate.date;
                    originalMadunaate.Pienfits = editedMadunaate.Pienfits;
                    _context.SaveChanges();


                    return RedirectToAction("Index");
                }
            }

            return View(editedMadunaate);
        }




    }
}

