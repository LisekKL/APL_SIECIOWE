using System;

namespace WPF_Chat.Model
{
    public class ChatMessage
    {
        public string Text { get; set; }
        public string LoginReceiver { get; set; }
        public string LoginSender { get; set; }
        public DateTime? SendDateTime { get; set; }
    }
}
