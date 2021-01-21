using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.Localization;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    Text textLabel;
    string value;

    private void Awake()
    {
        textLabel = GameObject.Find("/Canvas/Setting/Dropdown/Label").GetComponent<Text>();
    }

    private void Update() {
        if(textLabel == null)
        {
            textLabel = GameObject.Find("/Canvas/Setting/Dropdown/Label").GetComponent<Text>();
        }
    }

    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
        Debug.Log("English on");
    }

    public void SetRussian()
    {
        Localize.SetCurrentLanguage(SystemLanguage.Russian);
        Debug.Log("Russian on");
    }

    public void EventChangeLanguage()
    {
        Debug.Log((textLabel == null) + " Test");
        switch(textLabel.text)
        {
            case "English": SetEnglish();
                break;
            case "Русский": SetRussian();
                break;
            default:
                break;
        }
    }
}
