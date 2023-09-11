using Microsoft.AspNetCore.Mvc;

namespace CV.Site.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
