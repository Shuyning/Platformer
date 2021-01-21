using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{    
    [SerializeField] Dialog dialog;
    public GameObject dialogPanel;
    DialogSystem dialogSystem;

    private void Start() 
    {

    }
    private void Update() 
    {
        if(dialogSystem == null)
        {
            dialogSystem = GameObject.Find("/Canvas/DialogPanel").GetComponent<DialogSystem>();
        }
    }

    public void TriggerDialog()
    {
        dialogPanel.SetActive(true);
        Invoke("ActiveDialog", 0.1f);
    }

    public void ActiveDialog()
    {
        dialogSystem.StartDialog(dialog);
    }
}
