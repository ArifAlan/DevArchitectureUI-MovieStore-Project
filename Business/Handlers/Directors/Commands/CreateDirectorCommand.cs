using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Directors.Commands
{
    public class CreateDirectorCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, IResult>
        {
            private readonly IDirectorRepository _directorRepository;

            public CreateDirectorCommandHandler(IDirectorRepository directorRepository)
            {
                _directorRepository = directorRepository;
            }

            public async Task<IResult> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
            {
                var director = new Director
                {
                    Name = request.Name,
                    Surname = request.Surname
                };

                _directorRepository.Add(director);
                await _directorRepository.SaveChangesAsync();
                return new SuccessResult("Added new director");
            }
        }
    }
}
