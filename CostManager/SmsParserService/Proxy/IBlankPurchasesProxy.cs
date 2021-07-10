using CommonUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsParserService.Proxy
{
    public interface IBlankPurchasesProxy
    {
        Task StoreBlankPurchase(Purchase purchase);
    }
}
