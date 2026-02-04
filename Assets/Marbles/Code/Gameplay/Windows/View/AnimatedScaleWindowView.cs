using DG.Tweening;
using UnityEngine;

namespace Marbles.Code.Gameplay.Windows.View
{
    public class AnimatedScaleWindowView : Window
    {
        [SerializeField] private float animationDuration = 0.5f;

        private Vector3 initialScale;
        private Tween scaleTween;

        protected override void OnAwake()
        {
            initialScale = transform.localScale;
        }

        protected override void Initialize()
        {
            gameObject.SetActive(true);
            PlayScaleAnimation();
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            StopAnimation();
            transform.localScale = initialScale;
            gameObject.SetActive(false);
        }

        private void PlayScaleAnimation()
        {
            StopAnimation();
            transform.localScale = Vector3.zero;
            scaleTween = transform
                .DOScale(initialScale, animationDuration)
                .SetEase(Ease.OutQuad)
                .SetUpdate(UpdateType.Normal);
        }

        private void StopAnimation()
        {
            if (scaleTween != null && scaleTween.IsActive())
            {
                scaleTween.Kill();
                scaleTween = null;
            }
        }
    }
}