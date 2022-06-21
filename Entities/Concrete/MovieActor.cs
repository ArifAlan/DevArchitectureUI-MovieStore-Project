using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MovieActor:IEntity
    {
        public int Id { get; set; }
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
