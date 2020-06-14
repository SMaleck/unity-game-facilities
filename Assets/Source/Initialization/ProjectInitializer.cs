﻿using System.Linq;
using Source.Framework.Initialization;
using Source.Framework.Services.SceneManagement.Config;
using Source.Framework.Services.SceneManagement.LoadingScreen;
using Zenject;

namespace Source.Initialization
{
    public class ProjectInitializer : ISceneInitializer
    {
        [Inject] private DiContainer _container;

        [Inject] private SceneManagementConfig _sceneManagementConfig;
        [Inject] private LoadingScreenView.Factory _loadingScreenViewFactory;

        public void Initialize()
        {
            var loadingScreenView = _loadingScreenViewFactory.Create(
                _sceneManagementConfig.LoadingScreenViewPrefab);

            SetupLoadingScreenView(loadingScreenView);
            _container.BindInstance(loadingScreenView);
        }

        protected void SetupLoadingScreenView(LoadingScreenView view)
        {
            var listOfInits = view.GetComponents<IInitializable>()
                .Where(viewItem => viewItem.GetType() != typeof(LoadingScreenView))
                .ToList();

            listOfInits.ForEach(component => component.Initialize());

            view.GetComponentsInChildren<IInitializable>()
                .ToList()
                .ForEach(component => component.Initialize());
        }
    }
}
