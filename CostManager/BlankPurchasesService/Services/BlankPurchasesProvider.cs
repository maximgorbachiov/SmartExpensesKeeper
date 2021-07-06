using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlankPurchasesService
{
    public class BlankPurchasesProvider : BlankPurchaseServer.BlankPurchaseServerBase
    {
        public override Task<Empty> StoreBlankPurchase(BlankPurchaseRequest request, ServerCallContext context)
        {
            //this.dataConverter.SaveWaste(request);
            return Task.FromResult(new Empty());
        }

        public override Task<BlankPurchasesResponse> GetBlankPurchases(ClientGuid clientid, ServerCallContext context)
        {
            //BlankPurchasesResponse response = this.dataConverter.GetWastes(clientid.Id);
            //return Task.FromResult(response);
            return Task.FromResult(new BlankPurchasesResponse());
        }
    }
}
