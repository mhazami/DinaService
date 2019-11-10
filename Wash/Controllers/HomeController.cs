using BLL;
using DataStructure;
using DinaService.AppCode;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static DataStructure.Tools.Enums;

namespace Wash.Controllers
{
    public class HomeController : BaseController
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
            return PartialView("PVSearch", new Request());
        }

        [HttpPost]
        public ActionResult RegisterRequest(Request request)
        {
            try
            {
                if (!new RequestBO().Insert(request))
                {
                    ShowMessage("خطا در ثبت درخواست مشاروه ، لطفا مجدداٌ تلاش نمایید", MessageType.Error);
                    return Redirect(Request.UrlReferrer.ToString());
                }
                ShowMessage("درخواست مشاوره ی شما با موفقیت ثبت شد ،کارشناسان ما در اسرع وقت با شما تماس خواهد گرفت/ با تشکر از حسن اعتماد شما", MessageType.Success);
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}