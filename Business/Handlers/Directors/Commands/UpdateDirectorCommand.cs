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
    public class UpdateDirectorCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, IResult>
        {
            private readonly IDirectorRepository _directorRepository;
            public UpdateDirectorCommandHandler(IDirectorRepository directorRepository)
            {
                _directorRepository = directorRepository;
            }

            public async Task<IResult> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyDirector = await _directorRepository.GetAsync(u => u.Id == request.Id);

                isThereAnyDirector.Surname = request.Surname;
                isThereAnyDirector.Name = request.Name;

                _directorRepository.Update(isThereAnyDirector);
                await _directorRepository.SaveChangesAsync();
                return new SuccessResult("Updated director");
            }
        }
    }
}
