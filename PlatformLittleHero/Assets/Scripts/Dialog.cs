using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    Image dialog_box;
    Text dialog_text; 
    public string dialog;

    void Start()
    {
        dialog_box = GameObject.FindGameObjectWithTag("DialogBox").GetComponent<Image>();
        dialog_text = GameObject.FindGameObjectWithTag("DialogText").GetComponent<Text>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
        {
            dialog_box.enabled = true;
            dialog_text.text = dialog;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
        {
            dialog_box.enabled = false;
            dialog_text.text = null;
        }
    }
}
