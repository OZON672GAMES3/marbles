using Marbles.Code.Data;

namespace Marbles.Code.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}