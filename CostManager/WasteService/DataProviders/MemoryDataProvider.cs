using System.Collections.Generic;
using System.Linq;
using WasteService.Models;

namespace WasteService.DataProviders
{
    public class MemoryDataProvider : IDataProvider
    {
        private List<Waste> wastes = new List<Waste>();

        public List<Waste> GetWastes(string clientId)
        {
            var clientWastes = this.wastes.Where(w => w.ClientId == clientId).ToList();
            return clientWastes;
        }

        public void SaveWaste(Waste waste)
        {
            waste.WasteId = $"{ this.wastes.Count }";
            this.wastes.Add(waste);
        }
    }
}
