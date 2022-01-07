using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petsitters.Application.Pets.Queries.GetPetDetails;
using Petsitters.Application.Pets.Queries.GetPetList;
using Petsitters.Application.Pets.Commands.CreatePet;
using Petsitters.Application.Pets.Commands.UpdatePet;
using Petsitters.Application.Pets.Commands.DeletePet;
using Petsitters.WebApi.Models.Pet; 


namespace Petsitters.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PetController : BaseController
    {
        private readonly IMapper _mapper;

        public PetController(IMapper mapper) => _mapper = mapper;


        [HttpGet]
        public async Task<ActionResult<PetListVm>> GetAll()
        {
            var query = new GetPetListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDetailsVm>> Get(int id)
        {
            var query = new GetPetDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePetDto createPetDto)
        {
            var command = _mapper.Map<CreatePetCommand>(createPetDto);
            command.UserId = UserId;
            var petId = await Mediator.Send(command);
            return Ok(petId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePetDto updatePetDto)
        {
            var command = _mapper.Map<UpdatePetCommand>(updatePetDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePetCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
