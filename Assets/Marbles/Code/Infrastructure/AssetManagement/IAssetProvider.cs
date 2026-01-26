using UnityEngine;

namespace Marbles.Code.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path);
    }
}