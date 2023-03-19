using AutoMapper;

namespace module33
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
            .ConstructUsing(v => new UserViewModel(v));
        }
    }
}