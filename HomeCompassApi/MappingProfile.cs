using AutoMapper;
using HomeCompassApi.Models.Cases;
using HomeCompassApi.Models.Facilities;
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Services.Cases;
using HomeCompassApi.Services.Facilities;
using HomeCompassApi.Services.Feed;
namespace HomeCompassApi
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Homeless, HomelessDTO>();
            CreateMap<HomelessDTO, Homeless>();

            CreateMap<Missing,MissingDTO>();
            CreateMap<MissingDTO, Missing>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Facility, FacilityDto>();
            CreateMap<FacilityDto, Facility>();

            CreateMap<Resource, ResourceDto>();
            CreateMap<ResourceDto, Resource>();


        }
      
    }
}
