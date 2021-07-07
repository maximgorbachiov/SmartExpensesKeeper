using CommonUtilities.Models;
using System.Collections.Generic;
using System.Linq;

namespace WasteService.DataProviders
{
    public class MemoryDataProvider : IDataProvider
    {
        private List<Purchase> wastes = new List<Purchase>();

        public List<Purchase> GetWastes(string userGuid)
        {
            var clientWastes = this.wastes.Where(w => w.UserGuid == userGuid).ToList();
            return clientWastes;
        }

        public void SaveWaste(Purchase waste)
        {
            waste.Guid = $"{ this.wastes.Count }";
            this.wastes.Add(waste);
        }
    }
}
