using AutoMapper;
using Clipr.Application.Features.Queries.GetUser;
using Clipr.Domain.Entities;

namespace Clipr.Application.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}


///*///*public class MappingProfile: Profile
////{
////    public MappingProfile()
////    {
////        CreateMap<Video, UploadVideoCommand>()
////         .ForMember(x => x.VideoCategory, opt => opt.MapFrom(src => src.VideoCategory.ToString()));

////        CreateMap<UploadVideoCommand, Video>()
////      .ForMember(destination => destination.VideoCategory,
////                 opt => opt.MapFrom(source => Enum.GetName(typeof(VideoType), source.VideoCategory))).ReverseMap();
////    }
////}
////*/*/