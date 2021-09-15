using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator camera_controller;

    public void Shake()
    {
        camera_controller.SetTrigger("Shake");
    }
}
