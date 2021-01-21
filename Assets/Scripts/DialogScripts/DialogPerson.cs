using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPerson : MonoBehaviour
{
    [SerializeField] GameObject startDialog;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            startDialog.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            startDialog.SetActive(false);
        }
    }
}
