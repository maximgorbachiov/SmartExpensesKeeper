using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using WasteService;
using WasteService.Utilities;

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

        public async Task<List<APIWaste>> GetWastes(int clientId)
        {
            using var channel = GrpcChannel.ForAddress(this.adress);

            var client = new WasteServer.WasteServerClient(channel);
            
            var reply = await client.GetWastesAsync(new ClientId { Id = $"{clientId}" });

            List<APIWaste> wastes = this.serializer.DeserializeItem<List<APIWaste>>(reply.Wastes);

            return wastes;
        }

        public async Task SaveWaste(APIWaste waste)
        {
            using var channel = GrpcChannel.ForAddress(this.adress);

            var client = new WasteServer.WasteServerClient(channel);

            WasteRequest wasteRequest = new WasteRequest
            {
                ClientId = waste.ClientId,
                Market = waste.Market,
                Date = Timestamp.FromDateTime(waste.BuyTime),
                Products = this.serializer.SerializeItem<List<Product>>(waste.Products)
            };

            await client.SaveWasteAsync(wasteRequest);
        }
    }
}
