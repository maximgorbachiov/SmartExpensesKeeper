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
        // GET api/blankPurchases/{clientGuid}
        [HttpGet("{clientGuid}")]
        public async Task<List<Purchase>> GetBlankPurchases(int clientGuid)
        {
            return await Task.FromResult(new List<Purchase>());
        }
    }
}
