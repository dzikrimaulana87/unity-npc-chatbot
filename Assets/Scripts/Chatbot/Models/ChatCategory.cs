using System;
using System.Collections.Generic;

namespace Chatbot.Models
{
    [Serializable]
    public class ChatCategory
    {
        public string tag;
        public List<string> patterns;
        public List<string> responses;
    }
}
