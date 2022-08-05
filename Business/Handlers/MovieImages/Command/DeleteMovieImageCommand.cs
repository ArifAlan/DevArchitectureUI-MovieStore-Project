using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieImages.Command
{
    public class DeleteMovieImageCommand:IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteMovieImageCommandHandler : IRequestHandler<DeleteMovieImageCommand, IResult>
        {
            private readonly IMovieImageRepository _movieImageRepository;

            public DeleteMovieImageCommandHandler(IMovieImageRepository movieImageRepository)
            {
                _movieImageRepository = movieImageRepository;
            }
            public async Task<IResult> Handle(DeleteMovieImageCommand request, CancellationToken cancellationToken)
            {
                var deleteMovieImage =_movieImageRepository.Get(x => x.Id ==request.Id);

                _movieImageRepository.Delete(deleteMovieImage);
                await _movieImageRepository.SaveChangesAsync();
                return new SuccessResult("MovieImage deleted");
            }
        }
    }
}
