using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
