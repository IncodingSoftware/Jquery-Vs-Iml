namespace JqueryVsIML.Controllers
{
    using System.Web.Mvc;

    public class HomeController:Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index_Jquery()
        {
            return View();
        }


        public ActionResult Index_Iml()
        {
            return View();
        }
    }
}