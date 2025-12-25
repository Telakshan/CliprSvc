using AutoMapper;
using Clipr.Modules.Upload.Application.Features.Queries.GetUser;
using Clipr.Modules.Upload.Domain.Entities;

namespace Clipr.Modules.Upload.Application.Mappings;

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