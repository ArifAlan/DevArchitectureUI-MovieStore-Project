using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class MovieRepository: EfEntityRepositoryBase<Movie,ProjectDbContext>,IMovieRepository
    {
        public MovieRepository(ProjectDbContext context)
           : base(context)
        {
        }
    }
}
