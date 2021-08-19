using fromProduct.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fromProduct.Controllers
{
    public class ProductController : Controller
    {
        WareHouseDBContext wareHouseDB = new WareHouseDBContext();

        
        public IActionResult Index()
        {
            var list = wareHouseDB.ProductsTbls.Include(c => c.Category);
            return View(list);
        }

        
        public IActionResult InShow()
        {
            ViewData["CategoryId"] = new SelectList(wareHouseDB.CategoriesTbls, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InShow(ProductsTbl products)
        {
            if(ModelState.IsValid)
            {
                wareHouseDB.Add(products);
                await wareHouseDB.SaveChangesAsync();
                return RedirectToAction(nameof(InShow));
                
            }
            return View();
        }
    }
}
