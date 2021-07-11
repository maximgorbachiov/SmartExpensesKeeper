using BlankPurchasesService;
using CommonUtilities.Models;
using CommonUtilities.Serializers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace SmsParserService.Proxy
{
    public class BlankPurchasesProxy : IBlankPurchasesProxy
    {
        private string address = string.Empty;

        public ISerializer Serializer { get; }

        public BlankPurchasesProxy(IConfiguration configuration, ISerializer serializer)
        {
            this.address = configuration.GetConnectionString("BlankPurchasesServiceAdress");
            this.Serializer = serializer;
        }

        public async Task StoreBlankPurchase(Purchase purchase)
        {
            using var channel = GrpcChannel.ForAddress(this.address);

            var client = new BlankPurchaseServer.BlankPurchaseServerClient(channel);

            BlankPurchaseRequest blankPurchaseRequest = new BlankPurchaseRequest
            {
                ClientGuid = purchase.UserGuid,
                Market = purchase.Market,
                Positions = this.Serializer.SerializeItem(purchase.Positions),
                Date = Timestamp.FromDateTime(purchase.PurchaseTime),
            };

            await client.StoreBlankPurchaseAsync(blankPurchaseRequest);
        }
    }
}
