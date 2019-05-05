using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static DataStructure.Tools.Enums;

namespace Wash.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            List<DataStructure.Content> list = new ContentBO().Where(c => c.Place == SliderProject.Wash);
            return PartialView("PVIndex", list);
        }

        public ActionResult Category(int? id, string slug)
        {
            if (id == 1)
            {
                ViewBag.img = "/Content/Images/wm.png";
                ViewBag.des = "تعمیر ماشین لباسشویی خود را به متخصصان حرفه ای دینا سرویس بسپارید";
            }
            if (id == 2)
            {
                ViewBag.img = "/Content/Images/dwm.png";
                ViewBag.des = "تعمیر ماشین ظرفشویی خود را به متخصصان حرفه ای دینا سرویس بسپارید";
            }
            string filter = slug.Replace('-', ' ');
            ViewBag.PageTitle = $"{filter} تعمیرات تخصصی ماشین لباسشویی,تعمیرات تخصصی ماشین ظرفشویی,تعمیر ماشین لباسشویی,تعمیر ماشین ظرفشویی";
            List<DataStructure.Content> list = new List<DataStructure.Content>();
            if (id == 3)
            {
                list = new ContentBO().Where(c => c.Place == SliderProject.Wash);

            }
            else
            {
                list = new ContentBO().Where(c => c.Place == SliderProject.Wash && c.Title.Contains(filter));

            }
            return View(list);
        }

        public ActionResult Items(int id, string slug)
        {
            DataStructure.Content content = new ContentBO().Get(id);
            ViewBag.KeyWord = content.KeyWords.Split(',').ToList();
            return View(content);
        }
    }
}