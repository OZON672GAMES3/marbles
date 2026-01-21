using Marbles.Code.Data;
using Marbles.Code.Data.MarbleConfig;

namespace Marbles.Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        MarbleConfig GetMarbleConfigByType(MarbleType type);
        void LoadAll();
        GameConfig GameConfig { get; }
    }
}