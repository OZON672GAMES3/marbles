using UnityEngine;
using UnityEngine.UI;

namespace Marbles.Code.Gameplay.Windows.View
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private Image _marbleView;

        public void SetSprite(Sprite sprite)
        {
            _marbleView.sprite = sprite;

            Color color = _marbleView.color;
            color.a = 1f;
            _marbleView.color = color;
        }

        public void Clear()
        {
            _marbleView.sprite = null;

            Color color = _marbleView.color;
            color.a = 0f;
            _marbleView.color = color;
        }
    }
}