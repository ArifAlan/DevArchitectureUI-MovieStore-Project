using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Genres.Commands
{
    public class DeleteGenreCommand:IRequest<IResult>
    {
        public int Id { get; set; }


        public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, IResult>
        {
            private readonly IGenreRepository _genreRepository;

            public DeleteGenreCommandHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }

            public async Task<IResult> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
            {
                var genreToDelete = _genreRepository.Get(p => p.Id == request.Id);

                _genreRepository.Delete(genreToDelete);
                await _genreRepository.SaveChangesAsync();
                return new SuccessResult("Genre silindi");
            }
        }
    }
}
