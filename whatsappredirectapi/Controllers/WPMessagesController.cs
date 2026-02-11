using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static whatsappredirectapi.Models.ConnexeaseSendMessageModel;

namespace whatsappredirectapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WPMessagesController : ControllerBase
    {

        [HttpPost("sendwhatsappmessage")]
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
    }
}
