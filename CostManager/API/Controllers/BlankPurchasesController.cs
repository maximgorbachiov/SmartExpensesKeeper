using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace API.Controllers
{
    [Route("api/blankPurchases")]
    [ApiController]
    public class BlankPurchasesController : ControllerBase
    {
        // GET api/blankPurchases/{clientGuid}
        [HttpGet("{clientGuid}")]
        public async Task<JsonResult<APIWaste[]>> Get(int clientGuid)
        {
            //return await ;
        }
    }
}
