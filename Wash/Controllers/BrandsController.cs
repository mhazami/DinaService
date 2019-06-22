using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wash.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        [Route("تعمیر-لوازم-خانگی/{id:int}/{slug}")]
        public ActionResult List(int id, string slug)
        {
            var contents = new ContentBO().Where(c => c.BId == id);
            var title = new BrandsBO().FirstOrDefault(c => c.BrandsId == id);
            ViewBag.Brand = title.Title;
            ViewBag.FileId = title.FileId;
            ViewBag.Des = $"نمایندگی تعمیرات {title.Title},نمایندگی تعمیر لوازم خانگی {title.Title},تعمیر لوازم خانگی {title.Title},لوازم خانگی {title.Title}";
            return View(contents);
        }
    }
}