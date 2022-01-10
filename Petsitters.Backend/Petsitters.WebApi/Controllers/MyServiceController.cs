using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petsitters.Application.MyServices.Queries.GetMyServiceDetails;
using Petsitters.Application.MyServices.Queries.GetMyServiceList;
using Petsitters.Application.MyServices.Commands.CreateMyService;
using Petsitters.Application.MyServices.Commands.UpdateMyService;
using Petsitters.Application.MyServices.Commands.DeleteMyService;
using Petsitters.WebApi.Models.MyService;
using Microsoft.AspNetCore.Authorization;

namespace Petsitters.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MyServiceController : BaseController
    {
        private readonly IMapper _mapper;

        public MyServiceController(IMapper mapper) => _mapper = mapper;


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<MyServiceListVm>> GetAll()
        {
            var query = new GetMyServiceListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<MyServiceDetailsVm>> Get(Guid id)
        {
            var query = new GetMyServiceDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMyServiceDto createMyServiceDto)
        {
            var command = _mapper.Map<CreateMyServiceCommand>(createMyServiceDto);
            command.UserId = UserId;
            var myserviceId = await Mediator.Send(command);
            return Ok(myserviceId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateMyServiceDto updateMyServiceDto)
        {
            var command = _mapper.Map<UpdateMyServiceCommand>(updateMyServiceDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMyServiceCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
