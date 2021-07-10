using API.Services;
using CommonUtilities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/blankPurchases")]
    [ApiController]
    public class BlankPurchasesController : ControllerBase
    {
        private readonly IBlankPurchasesProxy blankPurchasesProxy;

        public BlankPurchasesController(IBlankPurchasesProxy blankPurchasesProxy)
        {
            this.blankPurchasesProxy = blankPurchasesProxy;
        }

        // GET api/blankPurchases/{clientGuid}
        [HttpGet("{clientGuid}")]
        public async Task<List<Purchase>> GetBlankPurchases(string clientGuid)
        {
            return await this.blankPurchasesProxy.RetrieveBlankPurchases(clientGuid);
        }
    }
}
