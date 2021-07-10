using BlankPurchasesService;
using CommonUtilities.Models;
using CommonUtilities.Serializers;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class BlankPurchasesProxy : IBlankPurchasesProxy
    {
        private readonly string address;
        private readonly ISerializer serializer;

        public BlankPurchasesProxy(IConfiguration configuration, ISerializer serializer)
        {
            this.address = configuration.GetConnectionString("BlankPurchasesServiceAdress");
            this.serializer = serializer;
        }

        public async Task<List<Purchase>> RetrieveBlankPurchases(string userGuid)
        {
            using var channel = GrpcChannel.ForAddress(this.address);

            var client = new BlankPurchaseServer.BlankPurchaseServerClient(channel);

            var reply = await client.GetBlankPurchasesAsync(new ClientGuid { Guid = userGuid });

            List<Purchase> wastes = this.serializer.DeserializeItem<List<Purchase>>(reply.BlankPurchases);

            return wastes;
        }
    }
}
