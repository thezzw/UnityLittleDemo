using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaytime : MonoBehaviour
{
    public float play_time;

    void Start()
    {
        Destroy(gameObject, play_time);
    }
}
