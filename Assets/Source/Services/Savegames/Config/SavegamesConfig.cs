﻿using Source.Framework;
using UnityEngine;

namespace Source.Services.Savegames.Config
{
    [CreateAssetMenu(fileName = nameof(SavegamesConfig), menuName = Constants.MenuRoot + nameof(SavegamesConfig))]
    public class SavegamesConfig : ScriptableObject
    {
        [SerializeField] private string _savegameFilename = "player.sav";
        public string SavegameFilename => _savegameFilename;

        [Range(0.1f, 2f)]
        [SerializeField] private double _requestSaveTimeoutSeconds = 1d;
        public double RequestSaveTimeoutSeconds => _requestSaveTimeoutSeconds;
    }
}
