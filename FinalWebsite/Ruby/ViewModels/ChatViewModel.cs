using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ruby.Models;

namespace Ruby.ViewModels
{
    public class ChatViewModel
    {
        public Guid? CurrentServerId { get; set; }
        public string CurrentUserId { get; set; }

        public List<Server> Servers { get; set; }
        public List<Chat> Chats { get; set; }
        public List<Friend> Friends { get; set; }
        public List<UserServer> Members { get; set; }
    }
}