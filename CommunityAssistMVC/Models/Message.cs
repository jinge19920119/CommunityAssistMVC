using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistMVC.Models
{
    public class Message
    {
        public Message() { }

        public Message(String msg)
        {
            messageText = msg;
        }

        public string messageText { set; get; }
    }
}