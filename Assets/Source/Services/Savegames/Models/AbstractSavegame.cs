﻿using System;
using Source.Framework.Util.UniRx;
using UniRx;

namespace Source.Services.Savegames.Models
{
    [Serializable]
    public class AbstractSavegameData
    {
    }

    public class AbstractSavegame : AbstractDisposable
    {
        protected static ReactiveProperty<T> CreateBoundProperty<T>(
            T initialValue,
            Action<T> setter,
            CompositeDisposable disposer)
        {
            var rxProperty = new ReactiveProperty<T>(initialValue).AddTo(disposer);
            rxProperty.Subscribe(setter).AddTo(disposer);

            return rxProperty;
        }
    }
}
