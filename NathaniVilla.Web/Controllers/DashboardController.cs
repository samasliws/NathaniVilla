using Microsoft.AspNetCore.Mvc;

namespace NathaniVilla.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
