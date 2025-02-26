using AutoMapper;
using UnitingBE.Dtos.Bookmarks;
using UnitingBE.Entities;

namespace UnitingBE.Mappers
{
    public class BookmarkMapper: Profile
    {
        public BookmarkMapper()
        {
            CreateMap<Bookmarks, BookmaksDto>();
        }
    }
}
