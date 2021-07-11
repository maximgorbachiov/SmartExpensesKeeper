using CommonUtilities.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SmsParserService.Proxy;
using SmsParserService.Services;
using System.Threading.Tasks;
using static SmsParserService.Startup;

namespace SmsParserService
{
    public class SmsParser : SmsParserServer.SmsParserServerBase
    {
        private ServiceResolver bankResolver;

        public SmsParser(IBlankPurchasesProxy blankPurchasesProxy, ServiceResolver bankResolver)
        {
            this.BlankPurchasesProxy = blankPurchasesProxy;
            this.bankResolver = bankResolver;
        }

        public IBlankPurchasesProxy BlankPurchasesProxy { get; }

        public override async Task<Empty> ParseSms(SmsInfo smsInfo, ServerCallContext context)
        {
            ISmsHandler smsHandler = this.bankResolver(smsInfo.Bank);

            Purchase purchase = await smsHandler.ParseSms(smsInfo);

            await this.BlankPurchasesProxy.StoreBlankPurchase(purchase);

            return await Task.FromResult(new Empty());
        }
    }
}
