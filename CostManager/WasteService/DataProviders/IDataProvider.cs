using System.Collections.Generic;
using WasteService.Models;

namespace WasteService.DataProviders
{
    public interface IDataProvider
    {
        void SaveWaste(Waste waste);
        List<Waste> GetWastes(string clientId);
    }
}
