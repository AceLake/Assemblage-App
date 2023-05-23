using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assemblage.Services
{
    interface IMessageDAO
    {
        public void CreateMessage(MessageModel message);
        public MessageModel GetMessageByUserID(int userID);
        public List<MessageModel> GetMessageByConversationID(int conversatioID);
        public void UpdateMessage(MessageModel message);
        public void DeleteMessage(int id);
    }
}
