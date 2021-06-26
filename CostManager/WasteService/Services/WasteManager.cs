using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;
using WasteService.Utilities;

namespace WasteService
{
    public class WasteManager : WasteServer.WasteServerBase
    {
        private readonly IDataConverter dataConverter;

        public WasteManager(IDataConverter dataConverter)
        {
            this.dataConverter = dataConverter;
        }

        public override Task<Empty> SaveWaste(WasteRequest request, ServerCallContext context)
        {
            this.dataConverter.SaveWaste(request);
            return Task.FromResult(new Empty());
        }

        public override Task<WasteResponse> GetWastes(ClientId clientid, ServerCallContext context)
        {
            WasteResponse response = this.dataConverter.GetWastes(clientid.Id);
            return Task.FromResult(response);
        }
    }
}
