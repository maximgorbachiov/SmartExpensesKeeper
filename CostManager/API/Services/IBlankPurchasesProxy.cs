using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WasteService.Models;

namespace API.Services
{
    public interface IBlankPurchasesProxy
    {
        List<Waste> RetrieveBlankPurchases(string userGuid);
    }
}
