using System.Web.Mvc;

namespace DinaService.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Articles

        [Route("Articles")]
        public ActionResult ArticleList()
        {
            return View();
        }

        [Route("گازهاي-مورد-استفاده-در-یخچال-سازی/تعمیر-یخچال")]
        public ActionResult ArticleOne()
        {
            return View();
        }

        [Route("تعمیر-برد-یخچال/تعمیر-یخچال")]
        public ActionResult ArticleTow()
        {
            return View();
        }

        [Route("عیب-یابی-و-تعمیر-یخچال/تعمیر-یخچال")]
        public ActionResult ArticleThree()
        {
            return View();
        }

        [Route("عیب-یابی-و-تعمیر-لباسشویی/تعمیر-لباسشویی")]
        public ActionResult ArticleFour()
        {
            return View();
        }
    }
}