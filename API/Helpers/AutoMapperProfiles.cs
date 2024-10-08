﻿using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // Mapping profile
        CreateMap<AppUser, MemberDto>()
            .ForMember(destination => destination.Age, o => o.MapFrom(source => source.DateOfBirth.CalculateAge()))
            .ForMember(destination => destination.PhotoUrl,
                options => options.MapFrom(source => source.Photos.FirstOrDefault(photo => photo.IsMain)!.Url));
        CreateMap<Photo, PhotoDto>();
        CreateMap<MemberUpdateDto, AppUser>();
        CreateMap<RegisterDto, AppUser>();
        CreateMap<string, DateOnly>().ConvertUsing(s => DateOnly.Parse(s));
    }
}
