using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MovieGenre:IEntity
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
