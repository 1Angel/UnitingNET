﻿using Microsoft.AspNetCore.Identity;
using UnitingBE.Features.Communities;

namespace UnitingBE.Entities
{
    public class AppUser: IdentityUser
    {
        public List<Community> communities { get; set; }
        public List<Post> posts { get; set; }
        public List<Comment> comments { get; set; }
    }
}
