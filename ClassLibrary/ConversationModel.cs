﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ConversationModel
    {
        public int ID { get; set; }
        public List<UserModel> Participants { get; set; }
        public string Title { get; set; }
        public MessageModel LastMessage { get; set; }
        public DateTime TimeStamp { get; set; }

        public ConversationModel()
        {
        }

        public ConversationModel(string title)
        {
            Title = title;
            TimeStamp = DateTime.Now;
        }
    }
}
