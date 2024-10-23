using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
<<<<<<< HEAD
using EventServices.Domain.Entities;
using EventServices.Domain.DTOs;
using EventServices.Application.Features.EventFeature.Commands;
namespace EventServices.Application.Mapping
=======
using EventService.Application.Features.Slider.Commands.CreateSlider;
using EventService.Application.Features.Slider.Commands.UpdateSlider;
using EventService.Domain.Entities;
using EventService.Domain.DTOs;
namespace EventService.Application.Mapping
>>>>>>> a18fd5604255217c475018b9cb6419b7aaa6a2a1
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
