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
        //create object wareHouseDB มาทำหน้าที่แทน WareHouseDB คือ Database


        public IActionResult Index()
        {
            var list = wareHouseDB.ProductsTbls.Include(c => c.Category);
            // create var list และเรียกใช้ object wareHouseDB และตามด้วย properties ProductsTbls และใช้ Method Include ในการ joinTable Category
            return View(list);//ให้ไปแสดงผลที่ Index.cshtml โดย Method Index เป็นผู้สั่งการ
        }

        
        public IActionResult InShow()
        {
            ViewData["CategoryId"] = new SelectList(wareHouseDB.CategoriesTbls, "CategoryId", "CategoryName");// ทำการ Query ข้อมูลออกมาจากตาราง CategoriesTbls ออกมาเป็นแบบรายการ(SelectList) แล้วเก็บข้อมูลไว้ใน ViewData โดยตั้งชื่อข้อมูลว่า["CategoryId"] โดยเอาข้อมูล ประเภทอาหาร ออกมาให้เลือก
            return View();
        }

        [HttpPost]//รับข้อมูลที่มีการกรอกเข้ามา
        [ValidateAntiForgeryToken]//ปกกันการถูกโจตีจากเว็บอื่น
        public async Task<IActionResult> InShow(ProductsTbl products)//ทำการเขียบทับ method หรือ Override Method
        {
            if(ModelState.IsValid)
            {
                wareHouseDB.Add(products);//save data in method Add โดยข้อมูลมาจาก products in Parameter 
                await wareHouseDB.SaveChangesAsync();//บันทึกลง Database ด้วย Method SaveChangesAsync();
                return RedirectToAction(nameof(InShow));
            }
            return View();
        }
    }
}
