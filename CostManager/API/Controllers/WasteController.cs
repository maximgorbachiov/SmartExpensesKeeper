using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("apiv1/waste")]
    public class WasteController : ControllerBase
    {
        private readonly IWasteServiceProxy wasteServiceProxy;

        public WasteController(IWasteServiceProxy wasteServiceProxy)
        {
            this.wasteServiceProxy = wasteServiceProxy;
        }

        // GET apiv1/waste/byclient/{id}
        [HttpGet("byclient/{id}")]
        public async Task<ActionResult<List<APIWaste>>> Get(int clientId)
        {
            return await this.wasteServiceProxy.GetWastes(clientId);
        }

        // POST apiv1/waste/save
        [HttpPost("save")]
        public async Task SaveWaste(APIWaste waste)
        {
            await this.wasteServiceProxy.SaveWaste(waste);
        }
    }
}
