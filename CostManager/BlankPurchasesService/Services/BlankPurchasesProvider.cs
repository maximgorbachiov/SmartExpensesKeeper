using CommonUtilities.Models;
using CommonUtilities.Providers;
using CommonUtilities.Serializers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlankPurchasesService
{
    public class BlankPurchasesProvider : BlankPurchaseServer.BlankPurchaseServerBase
    {
        public ISerializer Serializer { get; }
        public IDataProvider DataProvider { get; }

        public BlankPurchasesProvider(ISerializer serializer, IDataProvider dataProvider)
        {
            this.Serializer = serializer;
            this.DataProvider = dataProvider;
        }

        public override async Task<Empty> StoreBlankPurchase(BlankPurchaseRequest request, ServerCallContext context)
        {
            var products = this.Serializer.DeserializeItem<List<Position>>(request.Positions);

            Purchase waste = new Purchase
            {
                UserGuid = request.ClientGuid,
                Positions = products,
                Market = request.Market,
                PurchaseTime = request.Date.ToDateTime()
            };

            await this.DataProvider.SaveWasteAsync(waste);

            return new Empty();
        }

        public override async Task<BlankPurchasesResponse> GetBlankPurchases(ClientGuid clientid, ServerCallContext context)
        {
            List<Purchase> wastes = await this.DataProvider.GetWastesAsync(clientid.Guid);

            BlankPurchasesResponse response = new BlankPurchasesResponse
            {
                BlankPurchases = this.Serializer.SerializeItem(wastes)
            };

            return response;
        }
    }
}
