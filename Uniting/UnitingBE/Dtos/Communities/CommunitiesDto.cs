﻿using UnitingBE.Dtos.Auth;
using UnitingBE.Dtos.Posts;

namespace UnitingBE.Dtos.Communities
{
    public class CommunitiesDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime createdDate { get; set; }
    }
}
