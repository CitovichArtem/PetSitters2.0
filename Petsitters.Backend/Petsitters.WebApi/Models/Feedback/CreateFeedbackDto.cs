using AutoMapper;
using Petsitters.Application.Common.Mappings;
using Petsitters.Application.Feedbacks.Commands.CreateFeedback;

namespace Petsitters.WebApi.Models.Feedback
{
    public class CreateFeedbackDto : IMapWith<CreateFeedbackCommand>
    {
        public string Text { get; set; }
        public short Mark { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFeedbackDto, CreateFeedbackCommand>()
                .ForMember(feedbackCommand => feedbackCommand.Text,
                    opt => opt.MapFrom(feedbackDto => feedbackDto.Text))
                .ForMember(feedbackCommand => feedbackCommand.Mark,
                    opt => opt.MapFrom(feedbackDto => feedbackDto.Mark));
        }
    }
}
