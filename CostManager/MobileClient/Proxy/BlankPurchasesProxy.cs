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

namespace MobileClient.Proxy
{
    public class BlankPurchasesProxy : IBlankPurchaseProxy
    {
        private HttpClient client = new HttpClient();

        public BlankPurchasesProxy()
        {
            client.BaseAddress = new Uri(ConfigurationManager.Host);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Purchase> RetrieveBlankPurchases(string userGuid)
        {
            /*Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
            */
        }
    }
}