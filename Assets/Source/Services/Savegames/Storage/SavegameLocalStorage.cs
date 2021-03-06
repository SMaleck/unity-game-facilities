﻿using Source.Framework.Logging;
using Source.Framework.Util.Json;
using Source.Services.Savegames.Config;
using Source.Services.Savegames.Models;
using System.IO;

namespace Source.Services.Savegames.Storage
{
    public class SavegameLocalStorage : ISavegameReader, ISavegameWriter
    {
        private readonly ILogger _logger;
        private readonly string _fullFilePath;

        public SavegameLocalStorage(
            ILogger logger,
            ISavegameConfig savegameConfig)
        {
            _logger = logger;
            var basePath = UnityEngine.Application.persistentDataPath;
            _fullFilePath = Path.Combine(basePath, savegameConfig.Filename);
        }

        public SavegameData Read()
        {
            _logger.Log($"Loading savegame from {_fullFilePath}");
            var savegameData = JsonStorage.Read<SavegameData>(_fullFilePath);

            return savegameData;
        }

        public void Write(SavegameData savegameData)
        {
            _logger.Log($"Saving savegame to {_fullFilePath}");
            JsonStorage.Write(_fullFilePath, savegameData);
        }
    }
}
