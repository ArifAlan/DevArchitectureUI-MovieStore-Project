using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class MovieActorRepository : EfEntityRepositoryBase<MovieActor, ProjectDbContext>, IMovieActorRepository
    {
        public MovieActorRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
