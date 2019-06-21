using BLL;
using DataStructure;
using System.Collections.Generic;
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
            File model = new FileBO().Get(id);
            return File(model.Context, "image/jpg"); ;
        }

        public ActionResult GenerateMenu()
        {
            List<Brands> list = new BrandsBO().GetAll();
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

        public ActionResult ContactUs(int? id, string slug)
        {
            return View();
        }

        public ActionResult AboutUs(int? id, string slug)
        {
            return View();
        }

        public ActionResult Search()
        {
            return PartialView("PVSearch");
        }
    }
}