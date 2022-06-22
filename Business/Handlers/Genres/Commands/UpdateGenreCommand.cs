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
    public class UpdateGenreCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, IResult>
        {
            private readonly IGenreRepository _genreRepository;

            public UpdateGenreCommandHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }

            public async Task<IResult> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyGenre = await _genreRepository.GetAsync(p => p.Id == request.Id);
                isThereAnyGenre.Name = request.Name;

                _genreRepository.Update(isThereAnyGenre);
                await _genreRepository.SaveChangesAsync();
                return new SuccessResult("Genre güncellendi");
                
            }
        }
    }
}
