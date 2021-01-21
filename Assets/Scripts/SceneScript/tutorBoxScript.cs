using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorBoxScript : MonoBehaviour
{
    public bool open;
    
    [TextArea(3, 10)]
    public string tutorText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.OpenTutor && open)
        {
            GameManager.Instance.TutorPanel.GetComponentInChildren<Text>().text = tutorText;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            open = true;
            GameManager.Instance.OpenTutor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            open = false;
            GameManager.Instance.OpenTutor = false;
        }
    }
}
