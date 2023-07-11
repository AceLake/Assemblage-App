using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assemblage.Services
{
    interface IConversationDAO
    {
        public void CreateConversation(ConversationModel conversation);
        List<ConversationModel> GetAll();
        public ConversationModel GetConversationByID(int conversationId);
        public ConversationModel GetConversationByTitle(string conversationTitle);
        public void UpdateConversation(ConversationModel conversation);
        public void DeleteConversation(int conversationId);
    }
}
