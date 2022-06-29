using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class MovieDirectorRepository : EfEntityRepositoryBase<MovieDirector, ProjectDbContext>, IMovieDirectorRepository
    {
        public MovieDirectorRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
