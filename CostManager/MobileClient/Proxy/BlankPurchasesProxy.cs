using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileClient.Configuration;
using MobileClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileClient.Proxy
{
    public class BlankPurchasesProxy : IBlankPurchaseProxy
    {
        private HttpClient client = new HttpClient();

        public BlankPurchasesProxy()
        {
            this.client.BaseAddress = new Uri(ConfigurationManager.Host);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Purchase>> RetrieveBlankPurchases(string userGuid)
        {
            string path = $"api/blankPurchases/{userGuid}";
            Purchase[] purchases = null;
            HttpResponseMessage response = await this.client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                purchases = await response.Content.ReadAsStreamAsync<Purchase[]>();
            }
            return product;
        }
    }
}