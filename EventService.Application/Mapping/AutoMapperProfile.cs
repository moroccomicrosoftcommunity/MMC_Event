using AutoMapper;
using EventServices.Application.Features.EventFeature.Commands;
using EventService.Domain.DTOs;
using EventService.Domain.Entities;
using EventServices.Application.Features.SliderFeature.Commands.CreateSlider;
using EventServices.Domain.Entities;
using EventServices.Domain.DTOs;
using EventServices.Application.Features.SliderFeature.Commands.UpdateSlider;

namespace EventServices.Application.Mapping
{

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Event Mapping
            CreateMap<Event, EventGetDTO>();
            CreateMap<Event, EventOnlyGetDTO>();
            CreateMap<EventPostDTO, Event>();
            CreateMap<EventCreateCmd, Event>();
            CreateMap<EventUpdateCmd, Event>();
            CreateMap<EventPutDTO, Event>();
            //Session Mapping
            CreateMap<Session, SessionGetDTO>();
            CreateMap<Session, SessionOnlyGetDTO>();
            CreateMap<SessionPostDTO, Session>();
            CreateMap<SessionPutDTO, Session>();
            //Program Mapping
            CreateMap<Program, ProgramGetDTO>();
            CreateMap<Program, ProgramOnlyGetDTO>();
            CreateMap<ProgramPostDTO, Program>();
            CreateMap<ProgramPutDTO, Program>();
            //SliderMapping
            CreateMap<Slider, SliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderCommand>().ReverseMap();
            CreateMap<Slider, CreateSliderCommand>().ReverseMap();
        }
    }
}
