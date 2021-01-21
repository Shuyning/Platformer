using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;

    Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }


    void Update()
    {
    
    }

    public void StartDialog(Dialog  dialog)
    {
        nameText.text = dialog.namePerson;

        sentences.Clear();
        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentense)
    {
        dialogText.text = "";

        foreach(char letter in sentense.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }

    }
    public void EndDialog()
    {
        gameObject.SetActive(false);
        Debug.Log("End");
    }
}
