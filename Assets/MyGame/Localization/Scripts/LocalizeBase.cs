using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Localization
{
    public abstract class LocalizeBase : MonoBehaviour
    {
        public string localizationKey;

        public abstract void UpdateLocale();

        protected virtual void Start()
        {
            if(!Locale.currentLanguageHasBeenSet)
            {
                Locale.currentLanguageHasBeenSet = true;
                SetCurrentLanguage(Locale.PlayerLanguage);
            }
            UpdateLocale();
        }

        public static string GetLocalozedString(string key)
        {
            if(Locale.CurrentLanguageString.ContainsKey(key))
            {
                return Locale.CurrentLanguageString[key];
            }
            else
            {
                return string.Empty;
            }
        }

        public static void SetCurrentLanguage(SystemLanguage language)
        {
            Locale.CurrentLanguage = language.ToString();
            Locale.PlayerLanguage = language;
            Localize[] allTexts = GameObject.FindObjectsOfType<Localize>();
            //LocalizeTM[] allTextsTM = GameObject.FindObjectsOfType<LocalizeTM>();

            for(int i = 0; i < allTexts.Length; i++)
            {
                allTexts[i].UpdateLocale();
            }
            /*for(int i = 0; i < allTextsTM.Length; i++)
            {
                allTextsTM[i].UpdateLocale();
            }*/
        }
    }
}


