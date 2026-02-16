using System.ComponentModel.DataAnnotations;

namespace whatsappredirectapi.Models
{
    public class LeadConversation
    {
        [Key]
        public int lead_conversation_id { get; set; }
        public int lead_id { get; set; }
        public int channel_id { get; set; }
        public Guid cx_conversation_id { get; set; }
        public bool is_archived { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
