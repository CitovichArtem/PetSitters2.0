using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petsitters.Application.Feedbacks.Queries.GetFeedbackList;
using Petsitters.Application.Feedbacks.Commands.CreateFeedback;
using Petsitters.WebApi.Models.Feedback; 


namespace Petsitters.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FeedbackController : BaseController
    {
        private readonly IMapper _mapper;

        public FeedbackController(IMapper mapper) => _mapper = mapper;


        [HttpGet]
        public async Task<ActionResult<FeedbackListVm>> GetAll()
        {
            var query = new GetFeedbackListQuery
            {
                WorkerUserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateFeedbackDto createFeedbackDto)
        {
            var command = _mapper.Map<CreateFeedbackCommand>(createFeedbackDto);
            command.OwnerUserId = UserId;
            var feedbackId = await Mediator.Send(command);
            return Ok(feedbackId);
        }

    }
}
