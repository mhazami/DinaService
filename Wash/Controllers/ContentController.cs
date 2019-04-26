using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataStructure.Tools.Enums;

namespace Wash.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            var list = new ContentBO().Where(c => c.Place == SliderProject.Wash);
            return PartialView("PVIndex", list);
        }

        public ActionResult Category(int? id, string slug)
        {
            var filter = slug.Replace('-', ' ');
            ViewBag.PageTitle = $"{filter} تعمیرات تخصصی ماشین لباسشویی,تعمیرات تخصصی ماشین ظرفشویی,تعمیر ماشین لباسشویی,تعمیر ماشین ظرفشویی";
            var list = new ContentBO().Where(c => c.Place == SliderProject.Wash && c.Title.Contains(filter));
            return View(list);
        }

        public ActionResult Items(int id, string slug)
        {
            var content = new ContentBO().Get(id);
            ViewBag.KeyWord = content.KeyWords.Split(',').ToList();
            return View(content);
        }
    }
}