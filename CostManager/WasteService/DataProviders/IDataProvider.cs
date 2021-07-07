using CommonUtilities.Models;
using System.Collections.Generic;

namespace WasteService.DataProviders
{
    public interface IDataProvider
    {
        void SaveWaste(Purchase waste);
        List<Purchase> GetWastes(string userGuid);
    }
}
