using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitNumber : MonoBehaviour
{
    public float lifetime;
    public Text hit_number;


    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetString(string to_show)
    {
        hit_number.text = to_show;
    }

    public void SetColor(Color color)
    {
        hit_number.color = color;
    }
}
