using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Directors.Commands
{
    public class DeleteDirectorCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, IResult>
        {
            private readonly IDirectorRepository _directorRepository;
            public DeleteDirectorCommandHandler(IDirectorRepository directorRepository)
            {
                _directorRepository = directorRepository;
            }

            public async Task<IResult> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
            {
                var directorDelete = _directorRepository.Get(x => x.Id == request.Id);

                _directorRepository.Delete(directorDelete);
                await _directorRepository.SaveChangesAsync();

                return new SuccessResult("deleted director");
            }
        }
    }
}
