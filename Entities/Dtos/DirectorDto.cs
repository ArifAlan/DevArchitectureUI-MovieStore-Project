using Core.Entities;

namespace Entities.Dtos
{
    public class DirectorDto:IDto
    {
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
    }
}
