using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinaService.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(int? id,string slug)
        {
            var brand = new BrandsBO().Get(id.Value);
            return View(brand);
        }

        public ActionResult Article()
        {
            return View();
        }

        public ActionResult ArticleList()
        {
            return View();
        }
    }
}