using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Movie:IEntity
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string VideoLink { get; set; }
        public decimal IMDbRating { get; set; }
        public int TotalTime { get; set; }
        public string Description { get; set; }

        public DateTime UploadDate { get; set; }

    }
}
