using System;
using System.Threading.Tasks;
using CommonUtilities.Models;
using CommonUtilities.Serializers;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using SmsParserService;

namespace API.Services
{
    public class SmsParserProxy : ISmsParserProxy
    {
        private readonly string address;

        public ISerializer Serializer { get; }

        public SmsParserProxy(IConfiguration configuration, ISerializer serializer)
        {
            this.address = configuration.GetConnectionString("SmsParserServiceAdress");
            this.Serializer = serializer;
        }

        public async Task ParseSms(SmsInfo smsInfo)
        {
            using var channel = GrpcChannel.ForAddress(this.address);

            var client = new SmsParserServer.SmsParserServerClient(channel);

            SmsInfoRequest smsInfoRequest = new SmsInfoRequest
            {
                Bank = (Bank)Enum.Parse(typeof(Bank), smsInfo.Bank),
                Body = smsInfo.Body
            };

            await client.ParseSmsAsync(smsInfoRequest);
        }
    }
}
