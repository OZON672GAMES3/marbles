using Marbles.Code.Data;

namespace Marbles.Code.Infrastructure.Services.PersistantProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}