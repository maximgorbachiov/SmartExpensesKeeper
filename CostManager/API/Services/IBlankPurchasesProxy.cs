using CommonUtilities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IBlankPurchasesProxy
    {
        Task<List<Purchase>> RetrieveBlankPurchases(string userGuid);
    }
}
