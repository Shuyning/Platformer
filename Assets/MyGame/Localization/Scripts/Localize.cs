using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.Localization
{
    [RequireComponent(typeof(Text))]

    public class Localize : LocalizeBase
    {
        Text text;

        public override void UpdateLocale()
        {
            if(!text)
            {
                return;
            }
            if(!System.String.IsNullOrEmpty(localizationKey) && Locale.CurrentLanguageString.ContainsKey(localizationKey))
            {
                text.text = Locale.CurrentLanguageString[localizationKey].Replace(@"\n", "" + '\n');
            }
        }

        protected override void Start()
        {
            text = GetComponent<Text>();
            base.Start();
        }
    }
}


