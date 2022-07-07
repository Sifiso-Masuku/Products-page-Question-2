using System.Web.Mvc;

namespace Products_page_Question_2.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Bad_Request()
        {
            return View();
        }
        public ActionResult Not_Found()
        {
            return View();
        }
    }
}