using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.MovieGenres.Commands
{
    public class UpdateMovieCommand: IRequest<IResult>
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }



    }
}
