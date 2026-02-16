using System.ComponentModel.DataAnnotations;
using static whatsappredirectapi.Enums.Enums;

namespace whatsappredirectapi.Models
{
    public class Channel
    {
        [Key]
        public int channel_id { get; set; }
        public int company_id { get; set; }
        public ChannelEnums channel_enum { get; set; }
        public string cx_name { get; set; }
        public string?[]? cx_backend { get; set; }
        public Guid? gs_app_id { get; set; }
        public string? gs_app_token { get; set; }
        public string screen_name { get; set; }
        public string description { get; set; }
        public DateTime? deleted_at{ get; set; }
    }
}
