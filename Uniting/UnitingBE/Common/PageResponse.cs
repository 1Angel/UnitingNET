namespace UnitingBE.Common
{
    public class PageResponse<T> where T : class
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public int totalCount { get; set; }
        public T Data { get; set; }

        public PageResponse()
        {
            
        }

        public PageResponse(int pageNumber, int pageSize, int totalCount,  T Data)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
            this.totalCount = totalCount;
            this.Data = Data;
        }
    }
}
