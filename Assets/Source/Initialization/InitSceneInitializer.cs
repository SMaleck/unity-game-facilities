﻿using Source.Services.SceneTransition;
using Zenject;

namespace Source.Initialization
{
    public class InitSceneInitializer : ISceneInitializer
    {
        [Inject] private readonly ISceneTransitionService _sceneTransitionService;

        public void Initialize()
        {
            _sceneTransitionService.ToTitle();
        }
    }
}
