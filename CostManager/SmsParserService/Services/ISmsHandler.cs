using CommonUtilities.Models;
using System.Threading.Tasks;

namespace SmsParserService.Services
{
    public interface ISmsHandler
    {
        Task<Purchase> ParseSms(SmsInfo smsInfo);
    }
}
