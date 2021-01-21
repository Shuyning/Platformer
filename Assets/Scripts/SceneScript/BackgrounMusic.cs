using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounMusic : MonoBehaviour
{
    public AudioSource source;
    public static BackgrounMusic Instance { get; private set; }

    private void Start() 
    {
        source = GetComponent<AudioSource>();
    }

    void Awake()
    {
        if (Instance) {
            Destroy (gameObject);
        }
        else {
            DontDestroyOnLoad (gameObject);
            Instance = this;
        }
    }

    private void Update() 
    {
        source.volume = PlayerPrefs.GetFloat("VolumeSound");
    }
}
