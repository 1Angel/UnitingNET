namespace UnitingBE.Entities
{
    public class Bookmarks
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post post { get; set; }
        public string AppUserId { get; set; }
        public AppUser user { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
       
    }
}
