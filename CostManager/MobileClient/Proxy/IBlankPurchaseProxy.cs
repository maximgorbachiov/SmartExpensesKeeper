using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileClient.Proxy
{
    public interface IBlankPurchaseProxy
    {
        public List<Purchase> RetrieveBlankPurchases(string userGuid);
    }
}