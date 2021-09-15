using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    Text tips;
    public string tips_text;
    public float show_time;
    public bool destroy = false;
    public bool flash = true;

    void Start()
    {
        tips = GameObject.FindGameObjectWithTag("Tips").GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
        {
            tips.enabled = true;
            tips.text = tips_text;
        }
        if(destroy)
        {
            Invoke("Kill",show_time);
        }
        if(flash)
        {
            Invoke("Close",show_time);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D") && !flash)
        {
            tips.enabled = false;
            tips.text = null;
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    void Close()
    {
        tips.enabled = false;
        tips.text = null;
    }
}
