using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public int coin_amount;
    public int heal_amount;
    public float flash_time;
    public float emission_speed;
    public Color show_color;
    public GameObject blood_effect;
    public GameObject coin_demo;
    public GameObject heal_demo;
    public GameObject show_damage_demo;
    
    LittleHeroHealth little_hero_health;
    SpriteRenderer render;
    Color original_color;

    public void Start()
    {
        little_hero_health = GameObject.FindWithTag("Player").GetComponent<LittleHeroHealth>();
        render = GetComponent<SpriteRenderer>();
        original_color = render.color;
    }

    public void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Flash();
        Instantiate(blood_effect, transform.position, Quaternion.identity);
        GameController.camera_shake.Shake();
        HitNumber show_damage = Instantiate(show_damage_demo, transform.position, Quaternion.identity).GetComponent<HitNumber>();
        show_damage.SetString(damage.ToString());
        show_damage.SetColor(show_color);
        if(health <= 0)
        {
            for(int i = 0; i <coin_amount;i++)
            {
                Vector2 born_position = new Vector2(Random.Range(transform.position.x - 0.1f, transform.position.x + 0.1f), transform.position.y + 0.1f);
                GameObject coin = Instantiate(coin_demo, born_position, Quaternion.identity) as GameObject;
                coin.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.3f*emission_speed,0.3f*emission_speed),emission_speed);
            }
            for(int i = 0; i <heal_amount;i++)
            {
                Vector2 born_position = new Vector2(Random.Range(transform.position.x - 0.1f, transform.position.x + 0.1f), transform.position.y + 0.1f);
                GameObject heal = Instantiate(heal_demo, born_position, Quaternion.identity) as GameObject;
                heal.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.3f*emission_speed,0.3f*emission_speed),emission_speed);
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
        {
            little_hero_health.TakeDamage(damage);
        }
    }

    void Flash()
    {
        render.color = Color.red;
        Invoke("ResetColor",flash_time);
    }

    void ResetColor()
    {
        render.color = original_color;
    }
}
