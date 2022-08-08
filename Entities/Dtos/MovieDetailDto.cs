using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class MovieDetailDto:IDto
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public List<ActorDto> Actors { get; set; }
        public List<GenreDto> Genres { get; set; }
        public List<DirectorDto> Directors { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal IMDbRating { get; set; }

    }
}
