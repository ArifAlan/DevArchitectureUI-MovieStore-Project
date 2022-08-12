using Core.Entities;

namespace Entities.Dtos
{
    public class ActorDto:IDto
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
    }
}
