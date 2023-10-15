using AutoMapper;
using ActivityEntity = Domain.Activity;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ActivityEntity, ActivityEntity>();
        }
    }
}