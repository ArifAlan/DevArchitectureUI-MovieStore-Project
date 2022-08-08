using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class MovieRepository: EfEntityRepositoryBase<Movie,ProjectDbContext>,IMovieRepository
    {
        public MovieRepository(ProjectDbContext context)
           : base(context)
        {
        }

        public async Task<MovieDetailDto> GetMovieDetails(int movieId)
        {
            var result = await (from m in Context.Movies
                                where m.Id == movieId
                                select new MovieDetailDto
                                {
                                    Id = m.Id,
                                    MovieName = m.MovieName,
                                    Price = m.Price,
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description,
                                    IMDbRating = m.IMDbRating,
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault()
                                              }).ToList(),

                                }).FirstOrDefaultAsync();
            return result;
                                 
        }

        public async Task<List<MovieDetailDto>> GetMoviesDetails()
        {
            var result = await ( from m in Context.Movies
                         select new MovieDetailDto
                         {
                             Id = m.Id,
                             MovieName = m.MovieName,
                             Price = m.Price,
                             ReleaseDate=m.ReleaseDate,
                             Description = m.Description,
                             IMDbRating = m.IMDbRating,
                             Actors = (from a in Context.MovieActors
                                       where a.MovieId == m.Id
                                       select new ActorDto
                                       {
                                           ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault()
                                       }).ToList(),
                             Directors = (from di in Context.MovieDirectors
                                          where di.MovieId == m.Id
                                          select new DirectorDto
                                          {
                                              DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name).FirstOrDefault()
                                          }).ToList(),
                             Genres = (from g in Context.MovieGenres
                                       where g.MovieId == m.Id
                                       select new GenreDto
                                       {
                                           GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault()
                                       }).ToList(),
                         }).ToListAsync();
            return result;
        }
    }
}
