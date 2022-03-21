using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;

namespace LoadDistribution.Core.AutoMapperProfiles
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<Activity, ActivityDTO>().ReverseMap();
            CreateMap<Discipline, DisciplineDTO>().ReverseMap();
            CreateMap<Lecturer, LecturerDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<University, UniversityDTO>().ReverseMap();
            CreateMap<LecturerDisciplineActivityMap, LecturerDisciplineActivityMapDTO>().ReverseMap();
            CreateMap<Log, LogDTO>().ReverseMap();
            CreateMap<UniversityLecturerMap, UniversityLecturerMapDTO>().ReverseMap();
        }
    }
}
