using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage;

    LittleHeroHealth little_hero_health;

    void Start()
    {
        little_hero_health = GameObject.FindWithTag("Player").GetComponent<LittleHeroHealth>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
        {
            little_hero_health.TakeDamage(damage);
        }
    }
}
