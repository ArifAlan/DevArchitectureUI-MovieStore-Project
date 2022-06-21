using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FavTypeOfMovie:IEntity
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public  Movie Movie { get; set; }   
    }
}
