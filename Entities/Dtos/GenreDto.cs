using Core.Entities;

namespace Entities.Dtos
{
    public class GenreDto:IDto
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
