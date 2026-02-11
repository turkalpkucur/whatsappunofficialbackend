namespace whatsappredirectapi.Models
{
    public class ConnexeaseSendMessageModel
    {
        public class ConnexeaseSendMessageModelRoot
        {
            public string uuid { get; set; }
            public ConnexeaseSendMessageModelMessage[] messages { get; set; }
        }

        public class ConnexeaseSendMessageModelMessage
        {
            public string type { get; set; }
            public string content { get; set; }
        }
    }
}
