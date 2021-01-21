using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Localization
{
    public static class Locale
    {
        const string STR_LOCALIZATION_KEY = "locale";
        const string STR_LOCALIZATION_PREFIX = "Localization/";
        static string currentLanguage;
        static bool currentLanguageFileHasBeFound = false;
        public  static bool currentLanguageHasBeenSet = false;
        public static Dictionary<string, string> CurrentLanguageString = new Dictionary<string, string>();
        static TextAsset currentLocalizationText;

        public static string CurrentLanguage
        {
            get
            {
                return currentLanguage;
            }
            set
            {
                if(value != null && value.Trim() != string.Empty)
                {
                    currentLanguage = value;
                    currentLocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;

                    if(currentLocalizationText == null)
                    {
                        Debug.LogWarningFormat("Missing locale '{0}', loading English.", currentLanguage);
                        currentLanguage = SystemLanguage.English.ToString();
                        currentLocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;
                    }
                    if(currentLocalizationText != null)
                    {
                        currentLanguageFileHasBeFound = true;
                        string[] lines = currentLocalizationText.text.Split(new string[] {"\r\n", "\n\r", "\n"}, System.StringSplitOptions.RemoveEmptyEntries);
                        CurrentLanguageString.Clear();

                        for(int i = 0; i < lines.Length; i++)
                        {
                            string[] pairs = lines[i].Split(new char[] {'\t', '=', ' '}, 2);

                            if(pairs.Length == 2)
                            {
                                CurrentLanguageString.Add(pairs[0].Trim(), pairs[1].Trim());
                            }
                        }
                    }
                    else
                    {
                        Debug.LogErrorFormat("Local language '{0}, not found!'", currentLanguage);
                    }
                }
            }
        }

        public static bool CurrentLanguageHasBeenSet
        {
            get
            {
                return currentLanguageHasBeenSet;
            }
        }

        public static SystemLanguage PlayerLanguage
        {
            get
            {
                return (SystemLanguage)PlayerPrefs.GetInt(STR_LOCALIZATION_KEY, (int) Application.systemLanguage);
            }
            set
            {
                PlayerPrefs.SetInt(STR_LOCALIZATION_KEY, (int)value);
                Debug.Log(PlayerPrefs.GetInt(STR_LOCALIZATION_KEY));
                PlayerPrefs.Save();
            }
        }
        }   
}


