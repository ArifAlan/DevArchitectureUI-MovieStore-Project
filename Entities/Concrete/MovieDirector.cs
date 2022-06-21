using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MovieDirector:IEntity
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Director Director { get; set; }  
    }
}
