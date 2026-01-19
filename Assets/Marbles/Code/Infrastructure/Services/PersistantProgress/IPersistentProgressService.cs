using Marbles.Code.Data;

namespace Marbles.Code.Infrastructure.Services.PersistantProgress
{
    public interface IPersistentProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}