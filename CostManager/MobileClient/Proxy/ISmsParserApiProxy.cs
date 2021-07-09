using CommonUtilities.Models;

namespace MobileClient.Proxy
{
    public interface ISmsParserApiProxy
    {
        void SendSmsInfo(SmsInfo smsInfo);
    }
}