using System.Web.Mvc;
using DataStructure;
using DataStructure.Tools;
using DinaService;
using DinaService.AppCode;


namespace DinaService.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            this.ShowMessage("heloo",Enums.MessageType.Success);
            return View();
        }
    }
}