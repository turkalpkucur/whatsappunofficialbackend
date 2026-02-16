using System.ComponentModel.DataAnnotations;

namespace whatsappredirectapi.Models
{
    public class CxWhatsappMessage
    {
        [Key]
        public Guid cx_whatsapp_message_id { get; set; }
        public int lead_id { get; set; }
        public int? user_id { get; set; }
        public string w_message { get; set; }
        public Guid cx_conversation_id { get; set; }
        public Guid? cx_message_id { get; set; }
        public string cx_content { get; set; }
        public string cx_file_path { get; set; }
        public DateTime cx_sent_at { get; set; }
        public DateTime cx_create_at { get; set; }
        public string w_file_path { get; set; }
        public DateTime  created_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public bool forwarded { get; set; }
        public bool read { get; set; }
        public Guid? quoted_cx_whatsapp_message_id { get; set; }
        public Guid? quoted_cx_message_id { get; set; }
    }
}
