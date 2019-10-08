using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Services.Commands.Transaction;
using ATM.Services.Dto.Transaction;
using ATM.Services.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Controllers.Transction
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<TransactionDto>>> Get()
            => Ok(await _service.GetAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> Get(Guid id)
            => await _service.GetAsync(id);

        [HttpPost]
        public async Task<IActionResult> Post([FromRoute]Guid id,[FromBody]DoTransaction transaction)
        { 
            await _service.AddTransction(transaction);
            return NoContent();
        }

    }
}