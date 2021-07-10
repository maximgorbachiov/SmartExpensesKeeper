using CommonUtilities.Models;
using CommonUtilities.Serializers;
using System.Collections.Generic;
using WasteService.DataProviders;

namespace WasteService.Utilities
{
    public class JsonDataProviderConverter : IDataConverter
    {
        private readonly IDataProvider dataProvider;
        private readonly ISerializer serializer;

        public JsonDataProviderConverter(IDataProvider dataProvider, ISerializer serializer)
        {
            this.dataProvider = dataProvider;
            this.serializer = serializer;
        }
        
        public WasteResponse GetWastes(string clientId)
        {
            var wastes = this.dataProvider.GetWastes(clientId);
            WasteResponse response = new WasteResponse
            {
                Wastes = this.serializer.SerializeItem(wastes)
            };

            return response;
        }

        public void SaveWaste(WasteRequest request)
        {
            var products = this.serializer.DeserializeItem<List<Position>>(request.Products);

            Purchase waste = new Purchase
            {
                UserGuid = request.ClientId,
                Positions = products,
                Market = request.Market,
                PurchaseTime = request.Date.ToDateTime()
            };

            this.dataProvider.SaveWaste(waste);
        }
    }
}
