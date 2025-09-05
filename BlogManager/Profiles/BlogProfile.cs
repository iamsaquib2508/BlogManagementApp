using AutoMapper;
using BlogManager.DTOs;
using BlogManager.Models;

namespace BlogManager.Profiles
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            // Entity -> DTO
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.DateModified));

            // DTO -> Entity
            CreateMap<CreatePostDTO, Post>()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.DateModified, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<UpdatePostDTO, Post>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateModified, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
