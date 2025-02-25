using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using UnitingBE.Features.Communities;

namespace UnitingBE.Entities
{
    [Table("posts")]
    public class Post
    {
        public int Id {  get; set; }
        public required string description { get;set; }  
        public int CommunityId { get; set; }
        public Community Community { get; set; }
        public string AppUserId { get; set; }
        public AppUser user { get; set; }
        public List<Comment> comments { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
    }
}
