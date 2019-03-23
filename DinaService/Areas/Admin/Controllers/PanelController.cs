using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinaService.AppCode;

namespace DinaService.Areas.Admin.Controllers
{
    public class PanelController : BaseController
    {
        // GET: Admin/Panel
        public ActionResult Index()
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            return View();
        }
    }
}