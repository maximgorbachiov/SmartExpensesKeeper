using CommonUtilities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonUtilities.Providers
{
    public interface IDataProvider
    {
        Task SaveWasteAsync(Purchase waste);
        Task<List<Purchase>> GetWastesAsync(string userGuid);
    }
}
