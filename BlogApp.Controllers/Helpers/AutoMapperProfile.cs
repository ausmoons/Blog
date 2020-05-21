
using AutoMapper;
using BlogApp.Data.Models;
using BlogApp.Services.Models;

namespace BlogApp.Controllers.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<Blog, BlogModel>();
            CreateMap<CreateBlogModel, Blog>();
            CreateMap<UpdateBlogModel, Blog>();
        }
    }
}