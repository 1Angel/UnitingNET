namespace UnitingBE.Common
{
    public class ResponseDto<T> where T : class
    {
        public T PostInfo { get; set; }
        public int TotalFavorites { get; set; }
        public int TotalComments { get; set; }
        public int TotalBookmarks { get; set; }

        public ResponseDto()
        {
            
        }

        public ResponseDto(T data, int totalFavorites, int totalComments, int totalBookmarks)
        {
            this.PostInfo = data;
            TotalFavorites = totalFavorites;
            TotalComments = totalComments;
            TotalBookmarks = totalBookmarks;
        }
    }
}
