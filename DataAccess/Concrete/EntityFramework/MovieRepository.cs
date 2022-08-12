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
    public class MovieRepository : EfEntityRepositoryBase<Movie, ProjectDbContext>, IMovieRepository
    {
        public MovieRepository(ProjectDbContext context)
           : base(context)
        {
        }

        public async Task<List<MovieDetailDto>> GetActionMoviesDetails()
        {
            var result = await (from m in Context.Movies
                                join moviegenree in Context.MovieGenres
                                on m.Id equals moviegenree.MovieId
                                where moviegenree.GenreId == 1 //Aksiyon fimleri Id si
                                select new MovieDetailDto
                                {
                                    Id = m.Id,
                                    MovieName = m.MovieName,
                                    Price = m.Price,
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description,
                                    IMDbRating = m.IMDbRating,
                                    VideoLink = m.VideoLink,
                                    TotalTime = m.TotalTime,
                                    UploadDate = m.UploadDate,
                                    ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                  ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                     DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                  GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                              }).ToList(),
                                }).Take(12).ToListAsync();
            return result;
        }

        public async Task<List<MovieDetailDto>> GetComedyMoviesDetails()
        {
            var result = await (from m in Context.Movies
                                join moviegenree in Context.MovieGenres
                                on m.Id equals moviegenree.MovieId
                                where moviegenree.GenreId == 2 //Komedi fimleri Id si
                                select new MovieDetailDto
                                {
                                    Id = m.Id,
                                    MovieName = m.MovieName,
                                    Price = m.Price,
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description,
                                    IMDbRating = m.IMDbRating,
                                    VideoLink = m.VideoLink,
                                    TotalTime = m.TotalTime,
                                    UploadDate = m.UploadDate,
                                    ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                  ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                     DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                  GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                              }).ToList(),
                                }).Take(12).ToListAsync();
            return result;
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
                                    VideoLink = m.VideoLink,
                                    TotalTime = m.TotalTime,
                                    UploadDate = m.UploadDate,
                                    ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                  ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                     DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                  GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                              }).ToList(),

                                }).FirstOrDefaultAsync();
            return result;

        }

        public async Task<List<MovieDetailDto>> GetMoviesDetails()
        {
            var result = await (from m in Context.Movies
                                select new MovieDetailDto
                                {
                                    Id = m.Id,
                                    MovieName = m.MovieName,
                                    Price = m.Price,
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description,
                                    IMDbRating = m.IMDbRating,
                                    VideoLink = m.VideoLink,
                                    TotalTime = m.TotalTime,
                                    UploadDate = m.UploadDate,
                                    ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                  ActorId = (from actor in Context.Actors where actor.Id==a.ActorId select actor.Id).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                     DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                  GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                              }).ToList(),
                                }).ToListAsync();
            return result;
        }

        public async Task<List<MovieDetailDto>> GetMoviesDetailsByActorId(int actorId)
        {
            var result = await(from m in Context.Movies
                               join movieActor in Context.MovieActors
                               on m.Id equals movieActor.MovieId
                               where movieActor.ActorId == actorId
                               select new MovieDetailDto
                               {
                                   Id = m.Id,
                                   MovieName = m.MovieName,
                                   Price = m.Price,
                                   ReleaseDate = m.ReleaseDate,
                                   Description = m.Description,
                                   IMDbRating = m.IMDbRating,
                                   VideoLink = m.VideoLink,
                                   TotalTime = m.TotalTime,
                                   UploadDate = m.UploadDate,
                                   ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                   Actors = (from a in Context.MovieActors
                                             where a.MovieId == m.Id
                                             select new ActorDto
                                             {
                                                 ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                 ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                             }).ToList(),
                                   Directors = (from di in Context.MovieDirectors
                                                where di.MovieId == m.Id
                                                select new DirectorDto
                                                {
                                                    DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                    DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                }).ToList(),
                                   Genres = (from g in Context.MovieGenres
                                             where g.MovieId == m.Id
                                             select new GenreDto
                                             {
                                                 GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                 GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                             }).ToList(),
                               }).ToListAsync();
            return result;
        }

        public async Task<List<MovieDetailDto>> GetMoviesDetailsByGenreId(int genreId)
        {
            var result = await (from m in Context.Movies
                                join movieGenre in Context.MovieGenres
                                on m.Id equals movieGenre.MovieId
                                where movieGenre.GenreId == genreId
                                select new MovieDetailDto
                                {
                                    Id = m.Id,
                                    MovieName = m.MovieName,
                                    Price = m.Price,
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description,
                                    IMDbRating = m.IMDbRating,
                                    VideoLink = m.VideoLink,
                                    TotalTime = m.TotalTime,
                                    UploadDate = m.UploadDate,
                                    ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                  ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                     DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                  GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                              }).ToList(),
                                }).ToListAsync();
            return result;
        }

        public async Task<List<MovieDetailDto>> GetMoviesDetailsWithPagination(int limit, int skip)
        {
            var result = await (from m in Context.Movies
                                select new MovieDetailDto
                                {
                                    Id = m.Id,
                                    MovieName = m.MovieName,
                                    Price = m.Price,
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description,
                                    IMDbRating = m.IMDbRating,
                                    VideoLink = m.VideoLink,
                                    TotalTime = m.TotalTime,
                                    UploadDate = m.UploadDate,
                                    ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                  ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name+" "+ director.Surname ).FirstOrDefault(),
                                                     DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                  GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                              }).ToList(),
                                }).Skip(skip).Take(limit).ToListAsync();
            return result;
        }

        public async Task<List<MovieDetailDto>> GetMoviesDetailsWithPaginationByActorId(int limit, int skip, int actorId)
        {
            var result = await(from m in Context.Movies
                               join movieActor in Context.MovieActors
                               on m.Id equals movieActor.MovieId
                               where movieActor.ActorId == actorId
                               select new MovieDetailDto
                               {
                                   Id = m.Id,
                                   MovieName = m.MovieName,
                                   Price = m.Price,
                                   ReleaseDate = m.ReleaseDate,
                                   Description = m.Description,
                                   IMDbRating = m.IMDbRating,
                                   VideoLink = m.VideoLink,
                                   TotalTime = m.TotalTime,
                                   UploadDate = m.UploadDate,
                                   ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                   Actors = (from a in Context.MovieActors
                                             where a.MovieId == m.Id
                                             select new ActorDto
                                             {
                                                 ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                 ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                             }).ToList(),
                                   Directors = (from di in Context.MovieDirectors
                                                where di.MovieId == m.Id
                                                select new DirectorDto
                                                {
                                                    DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                    DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                }).ToList(),
                                   Genres = (from g in Context.MovieGenres
                                             where g.MovieId == m.Id
                                             select new GenreDto
                                             {
                                                 GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                 GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                             }).ToList(),
                               }).Skip(skip).Take(limit).ToListAsync();
            return result;
        }

        public async Task<List<MovieDetailDto>> GetMoviesDetailsWithPaginationByGenreId(int limit, int skip, int genreId)
        {
            var result = await (from m in Context.Movies
                                join movieGenre in Context.MovieGenres
                                on m.Id equals movieGenre.MovieId
                                where movieGenre.GenreId == genreId
                                select new MovieDetailDto
                                {
                                    Id = m.Id,
                                    MovieName = m.MovieName,
                                    Price = m.Price,
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description,
                                    IMDbRating = m.IMDbRating,
                                    VideoLink = m.VideoLink,
                                    TotalTime = m.TotalTime,
                                    UploadDate = m.UploadDate,
                                    ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                  ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                     DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                  GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                              }).ToList(),
                                }).Skip(skip).Take(limit).ToListAsync();
            return result;
        }

        public async Task<List<MovieDetailDto>> GetNewsMoviesDetails()
        {
            var result = await (from m in Context.Movies

                                select new MovieDetailDto
                                {
                                    Id = m.Id,
                                    MovieName = m.MovieName,
                                    Price = m.Price,
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description,
                                    IMDbRating = m.IMDbRating,
                                    VideoLink = m.VideoLink,
                                    TotalTime = m.TotalTime,
                                    UploadDate = m.UploadDate,
                                    ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                  ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                     DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                  GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                              }).ToList(),
                                }).OrderByDescending(x => x.UploadDate).Take(12).ToListAsync();
            return result;
        }

        public async Task<List<MovieDetailDto>> GetTopMoviesDetails()
        {
            var result = await (from m in Context.Movies

                                select new MovieDetailDto
                                {
                                    Id = m.Id,
                                    MovieName = m.MovieName,
                                    Price = m.Price,
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description,
                                    IMDbRating = m.IMDbRating,
                                    VideoLink = m.VideoLink,
                                    TotalTime = m.TotalTime,
                                    UploadDate = m.UploadDate,
                                    ImagePath = (from mi in Context.MovieImages where mi.MovieId == m.Id select mi.ImagePath).FirstOrDefault(),
                                    Actors = (from a in Context.MovieActors
                                              where a.MovieId == m.Id
                                              select new ActorDto
                                              {
                                                  ActorName = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Name + " " + actor.Surname).FirstOrDefault(),
                                                  ActorId = (from actor in Context.Actors where actor.Id == a.ActorId select actor.Id).FirstOrDefault()
                                              }).ToList(),
                                    Directors = (from di in Context.MovieDirectors
                                                 where di.MovieId == m.Id
                                                 select new DirectorDto
                                                 {
                                                     DirectorName = (from director in Context.Directors where director.Id == di.DirectorId select director.Name + " " + director.Surname).FirstOrDefault(),
                                                     DirectorId = (from director in Context.Directors where director.Id == di.DirectorId select director.Id).FirstOrDefault()
                                                 }).ToList(),
                                    Genres = (from g in Context.MovieGenres
                                              where g.MovieId == m.Id
                                              select new GenreDto
                                              {
                                                  GenreName = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Name).FirstOrDefault(),
                                                  GenreId = (from genre in Context.Genres where genre.Id == g.GenreId select genre.Id).FirstOrDefault()
                                              }).ToList(),
                                }).OrderByDescending(i => i.IMDbRating).Take(12).ToListAsync();


            return result;
        }
    }
}
