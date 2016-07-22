using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Illia Miatka";

            return View();
        }
    }
}