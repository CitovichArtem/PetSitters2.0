using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petsitters.Application.Bids.Queries.GetBidList;
using Petsitters.Application.Bids.Commands.CreateBid;
using Microsoft.AspNetCore.Authorization;

using Petsitters.WebApi.Models.Bid; 


namespace Petsitters.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BidController : BaseController
    {
        private readonly IMapper _mapper;

        public BidController(IMapper mapper) => _mapper = mapper;


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<BidListVm>> GetAll()
        {
            var query = new GetBidListQuery
            {
               // MyServiceId //TO DO
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create([FromBody] CreateBidDto createBidDto)
        {
            var command = _mapper.Map<CreateBidCommand>(createBidDto);
            //command.PetId = //TO DO
            var bidId = await Mediator.Send(command);
            return Ok(bidId);
        }


    }
}
