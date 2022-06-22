using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Genres.Commands
{
    public class CreateGenreCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, IResult>
        {
            private readonly IGenreRepository _genreRepository;

            public CreateGenreCommandHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }

            public async Task<IResult> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
            {
                var genre = new Genre
                {
                    Name = request.Name,
                };
                _genreRepository.Add(genre);
                await _genreRepository.SaveChangesAsync();
                return new SuccessResult("Genre Eklendi");
            }
        }
    }
}
