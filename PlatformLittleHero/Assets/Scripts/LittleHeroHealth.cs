using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LittleHeroHealth : MonoBehaviour
{
    public int max_health;
    public int current_health;
    public GameObject blood_effect;
    public GameObject heal_effect;
    public float flash_time;
    public float invincible_time;

    SpriteRenderer render;
    Color original_color;
    float timer_invincible;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        original_color = render.color;
        current_health = max_health;
        GameController.alive = true;
    }

    void Update()
    {
        if(timer_invincible > 0.0f)
        {
            timer_invincible -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        if(timer_invincible <= 0.0f && current_health > 0)
        {
            current_health = Mathf.Clamp(current_health - damage, 0, max_health);
            if(damage > 0.0f)
            {
                SoundController.HurtClip();
                GetComponent<Animator>().SetTrigger("IsHit");
                Flash();
                Instantiate(blood_effect, transform.position, Quaternion.identity);
                GameController.camera_shake.Shake();
            }
            else
            {
                SoundController.HealClip();
                Instantiate(heal_effect, transform.position, Quaternion.identity);
            }
            
            if (current_health <= 0)
            {
                GameController.alive = false;
                GetComponent<Animator>().SetTrigger("Die");
                //Invoke("Kill",1.1f);
                Invoke("BackToMainMenu",2.0f);
            }
        timer_invincible = invincible_time;
        }   
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
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
