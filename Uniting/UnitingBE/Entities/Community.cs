using System.ComponentModel.DataAnnotations.Schema;
using UnitingBE.Entities;

namespace UnitingBE.Features.Communities
{
    [Table("communities")]
    public class Community
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<Post> posts { get; set; }
        public List<CommunitiesFollowed> followed { get; set; }
        public string AppUserId { get; set; }
        public AppUser user { get; set; }

        public DateTime createdDate { get; set; } = DateTime.Now;
    }
}