using Microsoft.AspNetCore.Mvc;

namespace DocumentTaskMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
