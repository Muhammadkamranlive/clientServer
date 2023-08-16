using AutoMapper;
using CourseMicroSerivce.Domain;
using CourseMicroSerivce.Domain.AuthenticationModels;
using CourseMicroSerivce.Domain.TeacherPortal;
using CourseMicroSerivce.Models.AutoMapperDTOS;
using CourseMicroSerivce.Models.TeacherPortal;
using System;
using System.Collections.Generic;

namespace CourseMicroSerivce.Helper
{
    public class ConfigureDTOS : Profile
    {
        public ConfigureDTOS()
        {
            CreateMap<ClassesSessions, ClassSessionModel>().ReverseMap();
            CreateMap<CoursePosts, CoursePostsModel>().ReverseMap();
            CreateMap<QuizPosts, QuizPostsModel>().ReverseMap();
            CreateMap<SchoolChapters, SchoolChaptersModel>().ReverseMap();
            CreateMap<SchoolClasses, SchoolClassesModel>().ReverseMap();
            CreateMap<SchoolCourses, SchoolCoursesModel>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            CreateMap<SchoolQuiz, SchoolQuizModel>().ReverseMap();
            CreateMap<SchoolSubjects, SchoolSubjectsModel>().ReverseMap();
            CreateMap<SchoolThemes, SchoolThemesModel>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Admin, AdminDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<PermissionManagment, PermissionModel>().ReverseMap();
        }
    }
}
