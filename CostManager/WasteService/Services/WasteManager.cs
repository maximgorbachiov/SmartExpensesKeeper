using CommonUtilities.Models;
using CommonUtilities.Providers;
using CommonUtilities.Serializers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WasteService
{
    public class WasteManager : WasteServer.WasteServerBase
    {
        public ISerializer Serializer { get; }
        public IDataProvider DataProvider { get; }

        public WasteManager(ISerializer serializer, IDataProvider dataProvider)
        {
            this.Serializer = serializer;
            this.DataProvider = dataProvider;
        }

        public override async Task<Empty> SaveWaste(WasteRequest request, ServerCallContext context)
        {
            var products = this.Serializer.DeserializeItem<List<Position>>(request.Products);

            Purchase waste = new Purchase
            {
                UserGuid = request.ClientId,
                Positions = products,
                Market = request.Market,
                PurchaseTime = request.Date.ToDateTime()
            };

            await this.DataProvider.SaveWasteAsync(waste);

            return new Empty();
        }

        public override async Task<WasteResponse> GetWastes(ClientId clientid, ServerCallContext context)
        {
            List<Purchase> wastes = await this.DataProvider.GetWastesAsync(clientid.Id);

            WasteResponse response = new WasteResponse
            {
                Wastes = this.Serializer.SerializeItem(wastes)
            };

            return response;
        }
    }
}
