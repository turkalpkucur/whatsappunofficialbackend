using System.ComponentModel.DataAnnotations;

namespace whatsappredirectapi.Models
{
    public class Lead
    {
        [Key]
        public int lead_id { get; set; }  // primary key varsa

        public int company_id { get; set; }
        public int? user_id { get; set; }
        public int lead_no { get; set; }
        public int lead_status_id { get; set; }
        public int? lead_sub_status_id { get; set; }
        public int lead_reference_id { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }

        public int gender { get; set; }
        public DateTime dob { get; set; }

        public int country_phone_code { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }

        public bool is_completed { get; set; }
        public bool is_active { get; set; }
        public DateTime created_at { get; set; }

        public bool starred { get; set; }
        public int lead_type { get; set; }

        public bool is_logistic_detail_required { get; set; }
    }
}
