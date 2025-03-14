using AutoMapper;
using UnitingBE.Dtos.Favorites;
using UnitingBE.Entities;

namespace UnitingBE.Mappers
{
    public class FavoritesMapper: Profile
    {
        public FavoritesMapper()
        {
            CreateMap<Favorites, FavoritesDto>();
        }
    }
}
