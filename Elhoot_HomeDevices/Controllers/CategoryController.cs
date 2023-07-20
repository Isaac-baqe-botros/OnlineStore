using Elhoot_HomeDevices.Data;
using Microsoft.AspNetCore.Mvc;

namespace Elhoot_HomeDevices.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Categories.ToList();
            return View(result);
        }
        public IActionResult Creat ()
        {
            //_context.Categories.Add(category);
            //return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
       
        public async Task<IActionResult> Creat(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");   
        }
        public IActionResult Delete(int ID) {
          var item=  _context.Categories.FirstOrDefault(item=>item.Id==ID);
            _context.Categories.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item=_context.Categories.FirstOrDefault(item=>item.Id == ID);
            return View(item);
        }
        [HttpPost]
        public IActionResult Update(Category category )
        {
            if (ModelState.IsValid)
            {
                 _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
