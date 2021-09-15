using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleHeroAttack : MonoBehaviour
{
    public GameObject little_hero;
    public GameObject boomerang;
    public int damage;

    Animator little_animator;
    PolygonCollider2D attack_area;
    float start_time = 0.05f;
    float attack_time = 0.1f;
    float next_attack_time = 0.3f;
    float timer_attack;
    float timer_wait;
    bool start;

    void Start()
    {
        little_animator = little_hero.GetComponent<Animator>();
        attack_area = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        Attack();
        ThrowBoomerang();
    }

    void Attack()//按下攻击键进入攻击模式
    {
        if(Input.GetButtonDown("Attack") && timer_wait <= 0.0f)
        {
            SoundController.AttackClip();
            little_animator.SetTrigger("IsAttack");
            start = true;  
            timer_wait = next_attack_time;
            timer_attack = start_time;
        }
        if(timer_wait > 0.0f && timer_wait > -1.0f)
        {
            timer_wait -= Time.deltaTime;
        }
        if(start)
        {
            timer_attack -= Time.deltaTime;
            if(timer_attack < 0.0f && !attack_area.enabled)
            {
                attack_area.enabled = true;
                timer_attack = attack_time;
            }
            if(timer_attack < 0.0f && attack_area.enabled)
            {
                attack_area.enabled = false;
                start = false;
            }
        }
    }

    void ThrowBoomerang()
    {
        if(Input.GetButtonDown("Throw"))
        {
            SoundController.BoomerangClip();
            Instantiate(boomerang, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
