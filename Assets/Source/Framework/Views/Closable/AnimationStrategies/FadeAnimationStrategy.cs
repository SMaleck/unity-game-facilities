﻿using System;
using DG.Tweening;
using UnityEngine;

namespace Source.Framework.Views.Closable.AnimationStrategies
{
    public class FadeAnimationStrategy : IIClosableViewAnimationStrategy
    {
        private const float TransitionTimeSeconds = 0.5f;

        private readonly Transform _target;
        private readonly CanvasGroup _canvasGroup;

        public FadeAnimationStrategy(Transform target, CanvasGroup canvasGroup)
        {
            _target = target;
            _canvasGroup = canvasGroup;
        }

        public void Open(Action onComplete)
        {
            _target.gameObject.SetActive(true);
            SetAlpha(0);

            DOTween.To(
                    SetAlpha,
                    0,
                    1,
                    TransitionTimeSeconds)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() => onComplete?.Invoke());
        }

        public void Close(Action onComplete)
        {
            DOTween.To(
                    SetAlpha,
                    1,
                    0,
                    TransitionTimeSeconds)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() =>
                {
                    _target.gameObject.SetActive(false);
                    onComplete?.Invoke();
                });
        }

        private void SetAlpha(float alpha)
        {
            _canvasGroup.alpha = alpha;
        }
    }
}
