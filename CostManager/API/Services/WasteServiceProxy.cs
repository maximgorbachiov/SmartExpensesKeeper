using System.Collections.Generic;
using System.Threading.Tasks;
using CommonUtilities.Models;
using CommonUtilities.Serializers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using WasteService;

namespace API.Services
{
    public class WasteServiceProxy : IWasteServiceProxy
    {
        private readonly string adress;
        private readonly ISerializer serializer;

        public WasteServiceProxy(IConfiguration configuration, ISerializer serializer)
        {
            this.adress = configuration.GetConnectionString("WasteServiceAdress");
            this.serializer = serializer;
        }

        public async Task<List<Purchase>> GetWastes(int clientId)
        {
            using var channel = GrpcChannel.ForAddress(this.adress);

            var client = new WasteServer.WasteServerClient(channel);
            
            var reply = await client.GetWastesAsync(new ClientId { Id = $"{clientId}" });

            List<Purchase> wastes = this.serializer.DeserializeItem<List<Purchase>>(reply.Wastes);

            return wastes;
        }

        public async Task SaveWaste(Purchase waste)
        {
            using var channel = GrpcChannel.ForAddress(this.adress);

            var client = new WasteServer.WasteServerClient(channel);

            WasteRequest wasteRequest = new WasteRequest
            {
                ClientId = waste.UserGuid,
                Market = waste.Market,
                Date = Timestamp.FromDateTime(waste.PurchaseTime),
                Products = this.serializer.SerializeItem(waste.Positions)
            };

            await client.SaveWasteAsync(wasteRequest);
        }
    }
}
