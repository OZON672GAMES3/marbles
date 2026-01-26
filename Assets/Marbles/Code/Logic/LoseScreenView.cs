using UnityEngine;

namespace Marbles.Code.Logic
{
    public class LoseScreenView : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}