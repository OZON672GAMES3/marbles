using Marbles.Code.Data.MarbleConfig;

namespace Marbles.Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        MarbleConfig GetMarbleConfigByType(MarbleType type);
        void LoadAll();
    }
}