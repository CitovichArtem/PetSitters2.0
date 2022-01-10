using System;
using AutoMapper;
using Petsitters.Domain;
using Petsitters.Application.Common.Mappings;

namespace Petsitters.Application.Feedbacks.Queries.GetFeedbackList
{
    public class FeedbackLookupDto : IMapWith<Feedback>
    {
        public Guid Id { get; set; }
        public short Mark { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Feedback, FeedbackLookupDto>()
                .ForMember(feedbackDto => feedbackDto.Id,
                    opt => opt.MapFrom(feedback => feedback.Id))
                .ForMember(feedbackDto => feedbackDto.Mark,
                    opt => opt.MapFrom(feedback => feedback.Mark))
                .ForMember(feedbackDto => feedbackDto.Text,
                    opt => opt.MapFrom(feedback => feedback.Text));
        }
    }
}
