using AutoMapper;
using LoadDistribution.Core.Helpers;

namespace LoadDistribution.Core.AutoMapperProfiles
{
    public class HelperProfile : Profile
    {
        public HelperProfile()
        {
            CreateMap(typeof(Paged<>), typeof(Paged<>));
        }
    }
}
