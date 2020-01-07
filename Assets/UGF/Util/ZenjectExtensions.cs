﻿using Zenject;

namespace UGF.Util
{
    public static class ZenjectExtensions
    {
        public static IfNotBoundBinder AsSingleNonLazy(this ScopeConcreteIdArgConditionCopyNonLazyBinder binder)
        {
            return binder.AsSingle().NonLazy();
        }

        public static ConditionCopyNonLazyBinder BindPrefabFactory<TContract, TFactory>(
            this DiContainer diContainer)
            where TFactory : PlaceholderFactory<UnityEngine.Object, TContract>
        {
            return diContainer.BindFactory<UnityEngine.Object, TContract, TFactory>()
                .FromFactory<PrefabFactory<TContract>>();
        }

        public static ConditionCopyNonLazyBinder BindPrefabFactory<TContract, TContract2, TFactory>(
            this DiContainer diContainer)
            where TFactory : PlaceholderFactory<UnityEngine.Object, TContract2, TContract>
        {
            return diContainer.BindFactory<UnityEngine.Object, TContract2, TContract, TFactory>()
                .FromFactory<PrefabFactory<TContract2, TContract>>();
        }
    }
}