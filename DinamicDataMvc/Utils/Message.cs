using DinamicDataMvc.Interfaces;
using System.Collections.Generic;

namespace DinamicDataMvc.Utils
{
    public class Message : IMessage
    {
        private readonly Dictionary<int, string> defaultMessages;

        public Message()
        {
            defaultMessages = new Dictionary<int, string>();
            SetDefaultMessages();
        }
        

        public void SetDefaultMessages()
        {
            defaultMessages.Add(1, "Branch Collection had already configuration documents.");
            defaultMessages.Add(2, "State Collection had already configuration documents.");
            defaultMessages.Add(3, "Branch Collection was populated with Sucess.");
            defaultMessages.Add(4, "State Collection was populated with Sucess.");
        }


        public string GetMessage(int code)
        {
            return defaultMessages[code];
        }
    }
}
