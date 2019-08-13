using BLL;
using System.Web.Mvc;

namespace DinaService.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(int? id, string slug)
        {
            DataStructure.Brands brand = new BrandsBO().Get(id.Value);
            return View(brand);
        }

        //[Route("Article/{id}")]
        public ActionResult Article(string id)
        {
            DataStructure.Article article = new ArticleBO().Get(id);
            return View(article);
        }

    }
}