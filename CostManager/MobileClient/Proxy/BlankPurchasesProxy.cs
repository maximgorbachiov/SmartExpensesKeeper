using CommonUtilities.Models;
using CommonUtilities.Serializers;
using MobileClient.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MobileClient.Proxy
{
    public class BlankPurchasesProxy : IBlankPurchaseProxy
    {
        private HttpClient client = new HttpClient();
        private ISerializer serializer;

        public BlankPurchasesProxy()
        {
            this.client.BaseAddress = new Uri(ConfigurationManager.Host);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.serializer = new JsonSerializer();
        }

        public async Task<List<Purchase>> RetrieveBlankPurchases(string userGuid)
        {
            string path = $"api/blankPurchases/{userGuid}";
            List<Purchase> purchases = null;
            HttpResponseMessage response = await this.client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                purchases = this.serializer.DeserializeItem<List<Purchase>>(responseString);
            }
            return purchases;
        }
    }
}