using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Npgsql;
using System.Net.Http.Headers;
using System.Text;
using whatsappredirectapi.Models;
using static whatsappredirectapi.Models.ConnexeaseSendMessageModel;

namespace whatsappredirectapi.Controllers
{




    [Route("api/[controller]")]
    [ApiController]
    public class WPMessagesController : ControllerBase
    {
        private readonly WeaseDbContext _context;
        public WPMessagesController(WeaseDbContext context)
        {
            _context = context;
        }

        [HttpPost("sendwhatsappmessageviaconnexease")]
        public async Task<IActionResult> SendWhatsappMessage([FromQuery] string message)
        {
            string BASE_API_URL = "https://api.connexease.com";
            HttpClient httpClient = new HttpClient();
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiIsIngtYWJseS10b2tlbiI6IkV3LWVqdy5LLXFHbVZMbVpwT2dsV0RqVUg5NjVjTFVubWZWR0dyZWZFWXpITzZqdy1OOFk5UEJzRWtOTUkyZXp1UVluWEg0YUR3Q0lRaWtpbDZsZzZEaFU4dzcySDVfUVRIRjludS15ajNDRmlNRU5ULVN3MmZieXhYZlptNXAyZGs5Wm9lc3h5a1phdnE1N3RVRnlPNXJhcGdrdFAzcXZvbDRwaFJxZTlEeW9vRjl5bjJIRFA5S3ZaMmx0UVhNZmZVTl9BQTEwVDY1YzZFcmNSVHhSdFFodF9sdmlTVDZURjJ4Vms4ZC1TRlBSRHFPSXhob19PbjBCdzM2cXlIZjhuN3NIWE0tWmJLSHV4TDBXUTAtLWdvMTZUMUlGWHcifQ.eyJudWxsIjoiMTY2YWI5ODI3OTdjNDBhYTg1YWIwOGU1MDE1ZjQ1MTAiLCJleHAiOjE3NzA4NzgzMzMsImlhdCI6MTc3MDc5MTkzMywidXNlcl9pZCI6NjAxNSwidXNlcm5hbWUiOiJjb25uZXhlYXNlLmFwaS51c2VyQGluZm90ZWNiaWxpc2ltLmNvbSIsImVtYWlsIjoiY29ubmV4ZWFzZS5hcGkudXNlckBpbmZvdGVjYmlsaXNpbS5jb20ifQ.Bso0rOItv6uNekguxQMkzdx1UKwAa58CsonvroDgm1A";


            ConnexeaseSendMessageModelRoot msg1 = new ConnexeaseSendMessageModelRoot()
            {
                messages = new ConnexeaseSendMessageModelMessage[] {
new  ConnexeaseSendMessageModelMessage(){
content=message,
type="text"
}
            },
                uuid = "ebf34d17-f902-471a-8b81-64e3d9ff41c2"
            };


            string data = JsonConvert.SerializeObject(msg1);

            HttpRequestMessage request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{BASE_API_URL}/v2/messages/"),
                Method = HttpMethod.Post,
                Content = new StringContent(data, Encoding.UTF8, "application/json")
            };


            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", token);
            var response = await httpClient.SendAsync(request);

            //string responseContent = await response.Content.ReadAsStringAsync();
            //CxResponse resp = JsonConvert.DeserializeObject<CxResponse>(responseContent);
            return Ok();
        }



        //[HttpPost("webhooksendmessageunofficial")]
        //public async Task<IActionResult> WebhookSendMessageUnofficial([FromQuery] string message)
        //{


        //    using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=wease_dev_localdb;User Id=postgres;Password=Wease@47"))
        //    {


        //        StringBuilder query = new StringBuilder(" INSERT INTO wease.leads(\r\n\t  company_id, user_id, lead_no, lead_status_id, lead_sub_status_id, lead_reference_id, first_name, last_name, gender, dob, country_phone_code, phone_number, email, profile_picture, assigned_at, lost_status_break_down_id, lost_status_break_down_description, language_codes_lead_knows, is_completed, is_active, created_at, deleted_at, starred, lead_type, time_zone_id, meta_ad_id, is_logistic_detail_required)\r\n\tVALUES ( 1, null, 9999, 1, null, 13, 'HAYDAR', 'NAMLI', 1, '1980-01-05', 218, '905054270123', 'turkalp.kucur@gmail.com', null, null,null,null, null, false,true,  NOW(), null,false, 1,null,null,false);  ");
        //        con.Open();
        //        NpgsqlCommand cmd = (NpgsqlCommand)con.CreateCommand();
        //        NpgsqlParameter param = new NpgsqlParameter("@companyId", -1);

        //        cmd.Parameters.Add(param);
        //        cmd.CommandText = query.ToString();

        //        NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

        //        while (reader.Read())
        //        {
        //            InsurancePlanPrice item = new InsurancePlanPrice();
        //            if (reader["insurance_plan_price_id"] != DBNull.Value)
        //                item.Id = Convert.ToInt32(reader["insurance_plan_price_id"]);

        //            result.Add(item);
        //        }
        //    }

        //    return Ok();
        //}
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<int> GetLeadNo(int companyId)
        {
            int leadNo = await _context.Leads.Where(c => c.company_id.Equals(companyId)).CountAsync();
            leadNo += 1;
            return leadNo;
        }


        [HttpPost("WebhookSendMessageUnofficial")]
        public async Task<IActionResult> WebhookSendMessageUnofficial([FromQuery] string message)
        {

            Channel whatsappChannel = await _context.Channels.Where(g => g.company_id == 1 && g.channel_enum == Enums.Enums.ChannelEnums.WhatsApp && g.gs_app_id==null).FirstOrDefaultAsync();

        


            Guid cxConversationId = Guid.NewGuid();

            #region add lead
            Lead lead = new Lead
            {
                company_id = 1,
                lead_no = await GetLeadNo(1),
                lead_status_id = 1,
                lead_reference_id = 13,
                first_name = "HAYDAR",
                last_name = "NAMLI",
                gender = 1,
                dob = new DateTime(1980, 1, 5),
                country_phone_code = 218,
                phone_number = "905054270123",
                email = "turkalp.kucur@gmail.com",
                is_completed = false,
                is_active = true,
                created_at = DateTime.UtcNow,
                starred = false,
                lead_type = 1,
                is_logistic_detail_required = false,
            };

            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();
            #endregion

            #region add lead conversation
            LeadConversation leadConversation = new LeadConversation
            {
                channel_id = whatsappChannel.channel_id,
                created_at = DateTime.UtcNow,
                deleted_at = null,
                is_archived = false,
                lead_id = lead.lead_id,
                cx_conversation_id = cxConversationId
            };
            await _context.LeadConversations.AddAsync(leadConversation);
            await _context.SaveChangesAsync();
            #endregion

            #region add cx whatsapp messages
            CxWhatsappMessage whatsappMessage = new CxWhatsappMessage()
            {
                created_at = DateTime.UtcNow,
                cx_content = message,
                cx_conversation_id = cxConversationId,
                cx_create_at = DateTime.UtcNow,
                cx_file_path = "",
                cx_sent_at = DateTime.UtcNow,
                lead_id = lead.lead_id,
                user_id = null,
                quoted_cx_message_id = null,
                w_file_path = "",
                deleted_at = null,
                read = false,
                forwarded = false,
                w_message = message,
                quoted_cx_whatsapp_message_id = null,
                cx_message_id = null
            };

            await _context.CxWhatsappMessages.AddAsync(whatsappMessage);
            await _context.SaveChangesAsync();
            #endregion

            #region lead latest message
            LeadLatestMessage leadLatestMessage = new LeadLatestMessage()
            {
                latest_message = message,
                latest_message_channel_id= whatsappChannel.channel_id,
                latest_message_owner=Enums.Enums.LatestMessageOwnerEnums.Lead,
                latest_message_sent_at=DateTime.UtcNow,
                latest_respons_at=null,
                lead_id=lead.lead_id,
                reminder_at=null,
                unread_message_count=0
            };

            await _context.LeadLatestMessages.AddAsync(leadLatestMessage);
            await _context.SaveChangesAsync();
            #endregion

            #region addresses

            #endregion

            #region histories

            #endregion
            return Ok();
        }

    }
}

//