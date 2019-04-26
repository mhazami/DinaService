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

        public ActionResult GetSlid()
        {
            return PartialView("PVSlider");
        }

        public ActionResult GetService()
        {
            return PartialView("PVService");
        }

        public ActionResult GetStudy()
        {
            return PartialView("PVStudy");
        }

        public ActionResult GetInfo()
        {
            return PartialView("PVInfo");
        }

        public ActionResult GetRegister()
        {
            return PartialView("PVRegister");
        }

        public ActionResult GetCompanyInfo()
        {
            return PartialView("PVConpanyInfo");
        }
    }
}