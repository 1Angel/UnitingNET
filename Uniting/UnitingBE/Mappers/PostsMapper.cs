﻿using AutoMapper;
using UnitingBE.Dtos.Posts;
using UnitingBE.Entities;

namespace UnitingBE.Mappers
{
    public class PostsMapper: Profile
    {
        public PostsMapper()
        {
            CreateMap<Post, PostResponseDto>();
        }
    }
}
