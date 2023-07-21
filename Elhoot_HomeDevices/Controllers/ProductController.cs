using Elhoot_HomeDevices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Elhoot_HomeDevices.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
           var Prods= _context.Products.Include(p => p.Category).ToList();
            return View(Prods);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Catogeryname = _context.Categories.ToList();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                // Add the new product to the database
                _context.Products.Add(product);

                // Find the corresponding Category with the matching CategoryId
                var category = await _context.Categories.FindAsync(product.CategoryId);

                if (category != null)
                {
                    // Increment the Count property in Category
                    if (category.Count == 0)
                    {
                        category.Count++;

                        _context.Entry(category).State = EntityState.Modified;
                    }


                    // Save changes to the database
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
             }  }
            ViewBag.Catogeryname = _context.Categories.ToList();
           
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Log or debug the error message
                    Debug.WriteLine(error.ErrorMessage);
                }
            }

                return View(product);
        }

    

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Catogeryname = _context.Categories.ToList();
            var pro = _context.Products.FirstOrDefault(or => or.Id == id);
            return View(pro);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product prod)
        {
            ViewBag.Catogeryname = _context.Categories.ToList();
            try
            {
                var pro = _context.Products.FirstOrDefault(or => or.Id == id);
                if (pro != null)
                {   pro.Price = prod.Price;
                    pro.Description = prod.Description;
                    pro.CategoryId = prod.CategoryId;
                    pro.Description= prod.Description;
                    pro.Name= prod.Name;    
                    pro.ImageUrl= prod.ImageUrl;
                  
                    
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
     

        // POST: ProductController/Delete/5
        
        public ActionResult Delete(int id )
        {
            try
            {
              var prod=_context.Products.FirstOrDefault(pro=>pro.Id == id);
                _context.Products.Remove(prod);
                var category = _context.Categories.Find(prod.CategoryId);
                if (category != null)
                {
                    category.Count--;
                    _context.Entry(category).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
