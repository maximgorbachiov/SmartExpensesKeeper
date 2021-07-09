using System.Threading.Tasks;
using CommonUtilities.Models;

namespace API.Services
{
    public interface ISmsParserProxy
    {
        Task ParseSms(SmsInfo smsInfo)
    }
}
