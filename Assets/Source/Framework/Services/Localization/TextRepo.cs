﻿using Source.Framework.Services.LocalPlayerPrefs;
using System;
using System.Collections.Generic;

namespace Source.Framework.Services.Localization
{
    public static class TextRepo
    {
        public static Language CurrentLanguage { get; private set; }

        static TextRepo()
        {
            var storedLanguage = PlayerPrefsService.Language;

            var isStoredLanguageValid = Enum.IsDefined(typeof(Language), storedLanguage);
            if (isStoredLanguageValid)
            {
                CurrentLanguage = (Language)storedLanguage;
            }
            else
            {
                SetLanguage(Language.English);
            }
        }

        public static void SetLanguage(Language language)
        {
            PlayerPrefsService.Language = (int)language;
            CurrentLanguage = language;
        }

        public static string GetText(TextKey textKey)
        {
            switch (CurrentLanguage)
            {
                case Language.English:
                    return _textsEN[textKey];

                case Language.German:
                    return _textsDE[textKey];

                default:
                    throw new ArgumentOutOfRangeException(nameof(CurrentLanguage), CurrentLanguage, null);
            }
        }

        public static string GetLanguageText(Language languageKey)
        {
            return _textsLANGUAGE[languageKey];
        }

        private static Dictionary<Language, string> _textsLANGUAGE = new Dictionary<Language, string>
        {
            { Language.English, "English"},
            { Language.German, "Deutsch"}
        };

        private static Dictionary<TextKey, string> _textsEN = new Dictionary<TextKey, string>
        {
            { TextKey.HelloWorld, "Hello World!"}
        };

        private static Dictionary<TextKey, string> _textsDE = new Dictionary<TextKey, string>
        {
            { TextKey.HelloWorld, "Hallo Welt!"}
        };
    }
}
