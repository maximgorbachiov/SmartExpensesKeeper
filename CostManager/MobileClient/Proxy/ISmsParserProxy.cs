using MobileClient.Models;

namespace MobileClient.Proxy
{
    public interface ISmsParserProxy
    {
        void SendSmsInfo(SmsInfo smsInfo);
    }
}