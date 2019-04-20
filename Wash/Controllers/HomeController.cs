using BLL;
using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wash.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowImage(int id)
        {
            var model = new FileBO().Get(id);
            return File(model.Context, "image/jpg"); ;
        }

        public ActionResult GenerateMenu()
        {
            var list = new BrandsBO().GetAll();
            return PartialView("PVMenu", list);
        }
    }
}