using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlton <T>: MonoBehaviour where T: MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();
                DontDestroyOnLoad(FindObjectOfType<T>());
            }
            else if(instance != FindObjectOfType<T>())
            {
                Destroy(FindObjectOfType<T>());
            }

            

            return instance;
        }
    }
}
