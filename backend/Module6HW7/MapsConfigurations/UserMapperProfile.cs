using AutoMapper;
using Module6HW7.DB;
using Module6HW7.Interfaces;
using Module6HW7.Models;
using Module6HW7.ResponseModels;
using Module6HW7.Services;
using Module6HW7.ViewModels;
using System;
using System.Linq;

namespace Module6HW7.MapsConfigurations
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(destination => destination.HashPassword, options => options.MapFrom(source => PasswordHashService.HashPassword(source.Pass)))
                .ForMember(destination => destination.Birthday, options => options.MapFrom(source => DateTime.Parse(source.Birthday)))
                .AfterMap<DbSetRoleMappingAction>();

            CreateMap<User, UserResponse>()
                .ForMember(destination => destination.Birthday, options => options.MapFrom(source => source.Birthday.ToString("yyyy-MM-dd")));

            CreateMap<ProfileViewModel, User>()
                .ForMember(destination => destination.Birthday, options => options.MapFrom(source => DateTime.Parse(source.Birthday)));
        }
    }

    public class DbSetRoleMappingAction : IMappingAction<RegisterViewModel, User>
    {
        private readonly ApplicationDbContext _dbContext;

        public DbSetRoleMappingAction(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Process(RegisterViewModel source, User destination, ResolutionContext context)
        {
            destination.Role = _dbContext.Roles.FirstOrDefault(r => r.Title == "Client");
        }
    }
}
