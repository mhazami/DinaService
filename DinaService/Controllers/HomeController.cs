using BLL;
using DataStructure;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DinaService.Controllers
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

        public ActionResult RegisterRequest()
        {
            Request obj = new Request();
            return View(obj);
        }
        [HttpPost]
        public ActionResult RegisterRequest(Request request)
        {
            try
            {
                if (!new RequestBO().Insert(request))
                {
                    throw new Exception("خطایی در ثبت درخواست شما رخ داده است لطفا مجددا تلاش کنید");
                }
                ViewBag.Message = "درخواست شما با موفقیت صبت شد، همکاران ما در اسرع وقت با شما تماس خواهند گرفت";
                ViewBag.Status = "green";
                return View(request);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "red";
                return View(request);
            }
        }
    }
}