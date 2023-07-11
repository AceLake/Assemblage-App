using Assemblage.Services;
using ClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace Assemblage.Controllers
{
    public class FindGroupController : Controller
    {
        ConversationDAO conversationDAO = new ConversationDAO();
        public IActionResult Index()
        {
            return View(conversationDAO.GetAll());
        }
    }
}
