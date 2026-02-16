using System.ComponentModel.DataAnnotations;

namespace whatsappredirectapi.Models
{
    public class Address
    {
        [Key]
        public int address_id { get; set; }
        public int company_id { get; set; }
        public int? branch_id { get; set; }
        public int? user_id  { get; set; }
        public int? lead_id  { get; set; }
        public int? country_id { get; set; }
        public int? state_id { get; set; }
        public int? city_id { get; set; }
        public int? district_id { get; set; }
        public string address_detail { get; set; }
        public string? postal_code { get; set; }
        public string address_name { get; set; }
        public bool? is_default  { get; set; }
        public int latitude  { get; set; }
        public int longitude  { get; set; }
        public DateTime? deleted_at { get; set; }

    }
}
