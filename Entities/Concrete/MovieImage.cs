using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MovieImage:IEntity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string ImagePath { get; set; } //resim adı
        public DateTime DateTime { get; set; } // resim yüklendiği tarih
    }
}
