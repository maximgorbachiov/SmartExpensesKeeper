using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;

namespace SmsParserService
{
    public class SmsParser : SmsParserServer.SmsParserServerBase
    {
        public override Task<Empty> ParseSms(SmsInfo smsInfo, ServerCallContext context)
        {
            return Task.FromResult(new Empty());
        }
    }
}
