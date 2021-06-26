using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IWasteServiceProxy
    {
        Task<List<APIWaste>> GetWastes(int clientId);
        Task SaveWaste(APIWaste waste);
    }
}
