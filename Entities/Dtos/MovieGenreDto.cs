using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class MovieGenreDto:IDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
    }
}
