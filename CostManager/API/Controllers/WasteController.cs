using API.Services;
using CommonUtilities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/waste")]
    public class WasteController : ControllerBase
    {
        private readonly IWasteServiceProxy wasteServiceProxy;

        public WasteController(IWasteServiceProxy wasteServiceProxy)
        {
            this.wasteServiceProxy = wasteServiceProxy;
        }

        // GET api/waste/byclient/{clientId}
        [HttpGet("byclient/{clientId}")]
        public async Task<ActionResult<List<Purchase>>> Get(int clientId)
        {
            return await this.wasteServiceProxy.GetWastes(clientId);
        }

        // POST api/waste/save
        [HttpPost("save")]
        public async Task SaveWaste(Purchase waste)
        {
            await this.wasteServiceProxy.SaveWaste(waste);
        }
    }
}
