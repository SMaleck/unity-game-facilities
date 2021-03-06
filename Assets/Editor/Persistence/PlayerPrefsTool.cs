﻿using Source.Framework;
using Source.ServicesStatic.LocalPlayerPrefs;
using UnityEditor;

namespace Assets.Editor.Persistence
{
    public static class PlayerPrefsTool
    {
        [MenuItem(Constants.MenuRoot + "PlayerPrefs - Clear")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefsService.Clear();
        }

        [MenuItem(Constants.MenuRoot + "PlayerPrefs - Log")]
        public static void LogPlayerPrefs()
        {
            PlayerPrefsService.LogAll();
        }
    }
}
