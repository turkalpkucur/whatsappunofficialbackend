using System.ComponentModel.DataAnnotations;
using static whatsappredirectapi.Enums.Enums;

namespace whatsappredirectapi.Models
{
    public class LeadLatestMessage
    {
        [Key]
        public int lead_id { get; set; }
        public int latest_message_channel_id { get; set; }
        public LatestMessageOwnerEnums latest_message_owner { get; set; }
        public string latest_message  { get; set; }
        public DateTime latest_message_sent_at { get; set; }
        public DateTime? latest_respons_at { get; set; }
        public int unread_message_count { get; set; }
        public DateTime? reminder_at  { get; set; }
    }
}
