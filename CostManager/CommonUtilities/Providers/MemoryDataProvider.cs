using CommonUtilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonUtilities.Providers
{
    public class MemoryDataProvider : IDataProvider
    {
        private List<Purchase> wastes = new List<Purchase>();

        public async Task<List<Purchase>> GetWastesAsync(string userGuid)
        {
            var clientWastes = await Task.Run(() =>
            {
                return this.wastes.Where(w => w.UserGuid == userGuid).ToList();
            });

            return clientWastes;
        }

        public async Task SaveWasteAsync(Purchase waste)
        {
            waste.Guid = $"{ this.wastes.Count }";
            await Task.Run(() =>
            {
                this.wastes.Add(waste);
            });

            return; 
        }
    }
}
