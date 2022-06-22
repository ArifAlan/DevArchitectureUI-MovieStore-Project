using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class ActorRepository : EfEntityRepositoryBase<Actor, ProjectDbContext>, IActorRepository
    {
        public ActorRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}