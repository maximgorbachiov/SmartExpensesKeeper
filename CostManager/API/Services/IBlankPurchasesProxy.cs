using CommonUtilities.Models;
using System.Collections.Generic;

namespace API.Services
{
    public interface IBlankPurchasesProxy
    {
        List<Purchase> RetrieveBlankPurchases(string userGuid);
    }
}
