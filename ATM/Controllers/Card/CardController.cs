using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Infrastructure.EF;
using ATM.Services;
using ATM.Services.Commands.Card;
using ATM.Services.Dto.Card;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Controllers.Card
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _service;

        public CardController(ICardService service)
        {
            _service = service;
        }

        /*
        [HttpGet("{id}/pin")]
        public async Task<string> Get(Guid id)
        {
            await Task.CompletedTask;
            return _service.GetPINAsync(id).Result.PIN;
        }
        */

        [HttpGet("{id}")]
        public async Task<ActionResult<CardDto>> Get(Guid id)
        {
            return await _service.GetPINAsync(id);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDto>>> Get()
        {
            return Ok(await _service.Get());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]Guid id, [FromBody]ChangePIN command)
        {
            await _service.ChangePIN(command);
            return NoContent();
        }



    }
}