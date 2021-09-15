using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static AudioSource audio_source;
    public static AudioClip pick_coin;
    public static AudioClip attack;
    public static AudioClip hurt;
    public static AudioClip heal;
    public static AudioClip boomerang;
    public static AudioClip jump0;
    public static AudioClip jump1;

    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        pick_coin = Resources.Load<AudioClip>("PickCoin");
        attack = Resources.Load<AudioClip>("Attack");
        hurt = Resources.Load<AudioClip>("Hurt");
        heal = Resources.Load<AudioClip>("Heal");
        boomerang = Resources.Load<AudioClip>("Boomerang");
        jump0 = Resources.Load<AudioClip>("Jump0");
        jump1 = Resources.Load<AudioClip>("Jump1");
    }

    public static void PickCoinClip()
    {
        audio_source.PlayOneShot(pick_coin);
    }

    public static void AttackClip()
    {
        audio_source.PlayOneShot(attack);
    }

    public static void HurtClip()
    {
        audio_source.PlayOneShot(hurt);
    }

    public static void HealClip()
    {
        audio_source.PlayOneShot(heal);
    }

    public static void BoomerangClip()
    {
        audio_source.PlayOneShot(boomerang);
    }

    public static void Jump0Clip()
    {
        audio_source.PlayOneShot(jump0);
    }

    public static void Jump1Clip()
    {
        audio_source.PlayOneShot(jump1);
    }
}
