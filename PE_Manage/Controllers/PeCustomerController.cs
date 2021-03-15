using IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE_Manage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeCustomerController : ControllerBase
    {
        private readonly IPeCustomerService _peCustomerService;
        public PeCustomerController(IPeCustomerService peCustomerService)
        {
            this._peCustomerService = peCustomerService;
        }
        [HttpGet("Getall")]
        public async Task<ActionResult> Getall()
        {
            var date=await _peCustomerService.Find(1);
            return Ok(date);
        }
    }
}
