﻿using System;
using UnityEngine;

namespace Source.Framework.Views.Closable.AnimationStrategies
{
    public class DefaultAnimationStrategy : IIClosableViewAnimationStrategy
    {
        private readonly GameObject _target;

        public DefaultAnimationStrategy(GameObject target)
        {
            _target = target;
        }

        public void Open(Action onComplete)
        {
            _target.gameObject.SetActive(true);
            onComplete?.Invoke();
        }

        public void Close(Action onComplete)
        {
            _target.gameObject.SetActive(false);
            onComplete?.Invoke();
        }
    }
}
