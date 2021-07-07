using CommonUtilities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IWasteServiceProxy
    {
        Task<List<Purchase>> GetWastes(int clientId);
        Task SaveWaste(Purchase waste);
    }
}
