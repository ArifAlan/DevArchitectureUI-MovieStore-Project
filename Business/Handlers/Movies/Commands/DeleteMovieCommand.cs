using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Movies.Commands
{
    public class DeleteMovieCommand:IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, IResult>
        {
            private readonly IMovieRepository _movieRepository;

            public DeleteMovieCommandHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IResult> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
            {
                var movieToDelete = _movieRepository.Get(p => p.Id ==request.Id);
                
                _movieRepository.Delete(movieToDelete);
                await _movieRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}
