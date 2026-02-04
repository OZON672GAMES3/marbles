using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Marbles.Code.Gameplay.Windows.View
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private Image _marbleView;
        private Vector2 _initialAnchoredPosition;
        private Tween _activeTween;

        private void Awake()
        {
            if (_marbleView == null)
                return;

            _initialAnchoredPosition = _marbleView.rectTransform.anchoredPosition;
        }

        public void SetSprite(Sprite sprite)
        {
            KillTween();
            ResetMarbleViewTransform();
            _marbleView.sprite = sprite;

            Color color = _marbleView.color;
            color.a = 1f;
            _marbleView.color = color;
        }

        public void Clear()
        {
            KillTween();
            ResetMarbleViewTransform();
            _marbleView.sprite = null;

            Color color = _marbleView.color;
            color.a = 0f;
            _marbleView.color = color;
        }
        
        public void AnimateMergeTo(SlotView target, float moveDuration, float fadeDuration, float startDelay, Action onComplete)
        {
            if (_marbleView == null || _marbleView.sprite == null)
            {
                onComplete?.Invoke();
                return;
            }

            KillTween();

            Sequence sequence = DOTween.Sequence();
            if (target != null && target != this && target._marbleView != null)
            {
                sequence.Append(_marbleView.rectTransform.DOMove(target._marbleView.rectTransform.position, moveDuration)
                    .SetEase(Ease.InQuad));
            }

            if (startDelay > 0f)
                sequence.AppendInterval(startDelay);
            sequence.Append(_marbleView.DOFade(0f, fadeDuration));
            _activeTween = sequence;
            sequence.OnComplete(() =>
            {
                ResetMarbleViewTransform();
                onComplete?.Invoke();
            });
        }

        private void ResetMarbleViewTransform()
        {
            if (_marbleView == null)
                return;

            _marbleView.rectTransform.anchoredPosition = _initialAnchoredPosition;
        }

        private void KillTween()
        {
            if (_activeTween == null)
                return;

            _activeTween.Kill();
            _activeTween = null;
        }
    }
}