using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text health_percent;
    public GameObject little_hero;

    LittleHeroHealth health;
    Image health_bar;
    float max_health;
    float current_health;

    void Start()
    {
        health = little_hero.GetComponent<LittleHeroHealth>();
        health_bar = GetComponent<Image>();
    }

    void Update()
    {
        max_health = health.max_health;
        current_health = health.current_health;

        health_bar.fillAmount = current_health/max_health;
        health_percent.text = current_health.ToString() + "/" + max_health.ToString();
    }
}
