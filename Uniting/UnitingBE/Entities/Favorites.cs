namespace UnitingBE.Entities
{
    public class Favorites
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser user { get; set; }
        public int PostId { get; set; }
        public Post post { get; set; }
    }
}
