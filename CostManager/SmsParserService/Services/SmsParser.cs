using CommonUtilities.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SmsParserService.Proxy;
using SmsParserService.Services;
using System.Threading.Tasks;

namespace SmsParserService
{
    public class SmsParser : SmsParserServer.SmsParserServerBase
    {
        IBlankPurchasesProxy blankPurchasesProxy = new BlankPurchasesProxy();

        public override async Task<Empty> ParseSms(SmsInfo smsInfo, ServerCallContext context)
        {
            ISmsHandler smsHandler;

            switch (smsInfo.Bank)
            {
                case "IdeaBank" :
                    smsHandler = new IdeaBankSmsHandler();
                    break;
                default:
                    smsHandler = new DefaulSmsHandler();
                    break;
            }

            Purchase purchase = await smsHandler.ParseSms(smsInfo);

            await this.blankPurchasesProxy.StoreBlankPurchase(purchase);

            return await Task.FromResult(new Empty());
        }
    }
}
