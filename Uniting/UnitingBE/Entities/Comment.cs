using System.ComponentModel.DataAnnotations.Schema;

namespace UnitingBE.Entities
{
    [Table("comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string body { get; set; }
        //post
        public int PostId { get; set; }
        public Post post { get; set; }
        //user
        public string AppUserId { get; set; }
        public AppUser user { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
    }
}
