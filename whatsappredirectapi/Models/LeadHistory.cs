using System.ComponentModel.DataAnnotations;
using static whatsappredirectapi.Enums.Enums;

namespace whatsappredirectapi.Models
{
    public class LeadHistory
    {
        [Key]
        public int lead_history_id { get; set; }
        public int lead_id  { get; set; }
        public int user_id { get; set; }
        public LeadHistoryTypeEnums lead_history_event_type { get; set; }
        public string history { get; set; }
        public DateTime created_at{ get; set; }
        public DateTime? deleted_at { get; set; }
        public int company_id  { get; set; }

    }
}
