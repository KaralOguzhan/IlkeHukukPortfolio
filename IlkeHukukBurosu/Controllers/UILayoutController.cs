using Microsoft.AspNetCore.Mvc;

namespace IlkeHukukBurosu.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
