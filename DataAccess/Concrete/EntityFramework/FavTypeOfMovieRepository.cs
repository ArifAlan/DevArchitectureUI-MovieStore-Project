using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class FavTypeOfMovieRepository : EfEntityRepositoryBase<FavTypeOfMovie, ProjectDbContext>, IFavTypeOfMovieRepository
    {
        public FavTypeOfMovieRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
