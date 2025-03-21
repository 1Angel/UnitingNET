﻿using UnitingBE.Dtos.Auth;
using UnitingBE.Dtos.Comments;
using UnitingBE.Features.Communities;

namespace UnitingBE.Dtos.Posts
{
    public class PostResponseDto
    {
        public int Id { get; set; }
        public required string description { get; set; }
        public required UserDto user { get; set; }
        public List<CommentDto> comments { get; set; }
        public DateTime createdDate { get; set; }
    }
}
