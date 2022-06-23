using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MovieDirector:IEntity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int DirectorId { get; set; }  
    }
}
