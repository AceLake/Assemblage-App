using ClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace Assemblage.Controllers
{
    public class MessagingController : Controller
    {
        List<ConversationModel> groups = new List<ConversationModel>();

        // Connect the 

        public MessagingController()
        {
            groups.Add(new ConversationModel("Camelback Crusaders"));
            groups.Add(new ConversationModel("Lopes Way Connect Group"));
            groups.Add(new ConversationModel("GCU GYM Bois"));
            groups.Add(new ConversationModel("Montana Group"));

            groups[0].ID = 1;
            groups[1].ID = 2;
            groups[2].ID = 3;
            groups[3].ID = 4;
        }

        public IActionResult Index()
        {
            return View(groups);
        }

        public IActionResult ShowGroupMessage(int ID)
        {
            return PartialView(groups.FirstOrDefault(g => g.ID == ID));
        }
    }
}
