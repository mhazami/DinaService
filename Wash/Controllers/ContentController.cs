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
    }
}