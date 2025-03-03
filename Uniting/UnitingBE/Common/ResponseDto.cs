namespace UnitingBE.Common
{
    public class ResponseDto<T> where T : class
    {
        public T data { get; set; }
        public int TotalComments { get; set; }
        public int TotalBookmarks { get; set; }

        public ResponseDto()
        {
            
        }

        public ResponseDto(T data, int totalComments, int totalBookmarks)
        {
            this.data = data;
            TotalComments = totalComments;
            TotalBookmarks = totalBookmarks;
        }
    }
}
