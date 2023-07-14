using AutoMapper;
using CourseMicroSerivce.Domain;
using CourseMicroSerivce.Domain.AuthenticationModels;
using CourseMicroSerivce.Models.AutoMapperDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseMicroSerivce.Helper
{
    public class ConfigureDTOS : Profile
    {
        public ConfigureDTOS()
        {
            CreateMap<Person, PersonDTOS>().ReverseMap();
            CreateMap<Courses, CoursesDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Students, StudentDTOS>().ReverseMap();
            CreateMap<Teachers, TeacherDTOS>().ReverseMap();
            CreateMap<Tags, TagsDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            CreateMap<CourseContent, CourseCotentDTOS>();
        }
    }
}
