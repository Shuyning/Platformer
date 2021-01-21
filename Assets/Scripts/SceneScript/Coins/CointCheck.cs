using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointCheck : MonoBehaviour
{
    public AudioSource source;
    public AudioClip coin;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(coin, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.5f);
    }
}
