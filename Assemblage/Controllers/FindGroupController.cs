using ClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace Assemblage.Controllers
{
    public class FindGroupController : Controller
    {
        List<ConversationModel> groups = new List<ConversationModel>();
        public IActionResult Index()
        {
            return View();
        }
    }
}
