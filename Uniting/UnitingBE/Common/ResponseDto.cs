namespace UnitingBE.Common
{
    public class ResponseDto<T> where T : class
    {
        public T PostInfo { get; set; }
        public bool? isFavoriteByUser { get; set; }
        public int TotalFavorites { get; set; }
        public int TotalComments { get; set; }
        public int TotalBookmarks { get; set; }

        public ResponseDto()
        {
            
        }

        public ResponseDto(T postInfo, bool? isFavoriteByUser, int totalFavorites, int totalComments, int totalBookmarks)
        {
            PostInfo = postInfo;
            this.isFavoriteByUser = isFavoriteByUser;
            TotalFavorites = totalFavorites;
            TotalComments = totalComments;
            TotalBookmarks = totalBookmarks;
        }


    }
}
