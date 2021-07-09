using CommonUtilities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileClient.Proxy
{
    public interface IBlankPurchaseApiProxy
    {
        public Task<List<Purchase>> RetrieveBlankPurchases(string userGuid);
    }
}