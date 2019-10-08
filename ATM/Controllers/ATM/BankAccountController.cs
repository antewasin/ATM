using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Infrastructure.Filters;
using ATM.Infrastructure.Settings;
using ATM.Services;
using ATM.Services.Commands.Transaction;
using ATM.Services.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace ATM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionHandler]
    public class BankAccountController : ControllerBase
    {
        private readonly IATMService _service;
        private AppSettings _options;
        //private readonly IMemoryCache _cache; 

        public BankAccountController(IATMService service, IOptions<AppSettings> options)
        {
            _service = service;
           // _cache = cache;
            _options = options.Value;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccountDto>>> Get()
        {
            //throw new Exception("Opss");
            return Ok(await _service.BrowseAnyc());
        }

        [HttpGet("{id}")]
        public  IActionResult Get([FromRoute] Guid id)
            => Ok(_service.GetAsync(id));

        [HttpGet("test")]
        public ActionResult GetCustomOptions()
        {
            return Content(_options.test);
        }
            

    }
}