using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health_amount;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
        {
            other.gameObject.GetComponent<LittleHeroHealth>().TakeDamage(-health_amount);
            Destroy(gameObject);
        }
    }
}
