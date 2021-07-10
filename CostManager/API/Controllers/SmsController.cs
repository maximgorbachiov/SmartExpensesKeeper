using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/sms")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        // GET api/sms/parse
        [HttpPost("parse")]
        public async void ParseSms(string sms)
        {
            //await    
        }
    }
}
