using API.Services;
using CommonUtilities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/sms")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsParserProxy smsParserProxy;

        public SmsController(ISmsParserProxy smsParserProxy)
        {
            this.smsParserProxy = smsParserProxy;
        }

        // POST api/sms/parse
        [HttpPost("parse")]
        public async Task ParseSms(SmsInfo smsInfo)
        {
            await this.smsParserProxy.ParseSms(smsInfo);
        }
    }
}
