using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using System.Net.Http.Headers;
using System.Text;
using static whatsappredirectapi.Models.ConnexeaseSendMessageModel;

namespace whatsappredirectapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WPMessagesController : ControllerBase
    {

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



        [HttpPost("webhooksendmessageunofficial")]
        public async Task<IActionResult> WebhookSendMessageUnofficial([FromQuery] string message)
        {



            //using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=wease_dev_localdb;User Id=postgres;Password=Wease@47"))
            //{
            //    StringBuilder query = new StringBuilder(" INSERT INTO wease.leads(\r\n\t  company_id, user_id, lead_no, lead_status_id, lead_sub_status_id, lead_reference_id, first_name, last_name, gender, dob, country_phone_code, phone_number, email, profile_picture, assigned_at, lost_status_break_down_id, lost_status_break_down_description, language_codes_lead_knows, is_completed, is_active, created_at, deleted_at, starred, lead_type, time_zone_id, meta_ad_id, is_logistic_detail_required)\r\n\tVALUES ( 1, null, 9999, 1, null, 13, 'HAYDAR', 'NAMLI', 1, '1980-01-05', 218, '905054270123', 'turkalp.kucur@gmail.com', null, null,null,null, null, false,true,  NOW(), null,false, 1,null,null,false);  ");
            //    con.Open();
            //    NpgsqlCommand cmd = (NpgsqlCommand)con.CreateCommand();
            //    NpgsqlParameter param = new NpgsqlParameter("@companyId", -1);

            //    cmd.Parameters.Add(param);
            //    cmd.CommandText = query.ToString();

            //    NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            //    while (reader.Read())
            //    {
            //        InsurancePlanPrice item = new InsurancePlanPrice();
            //        if (reader["insurance_plan_price_id"] != DBNull.Value)
            //            item.Id = Convert.ToInt32(reader["insurance_plan_price_id"]);

            //        result.Add(item);
            //    }
            //}








            return Ok();
        }
    }
}

//