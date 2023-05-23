using Microsoft.AspNetCore.Mvc;

namespace Assemblage.Controllers
{
    public class MessagingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
