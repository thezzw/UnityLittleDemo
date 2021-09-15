using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public float change_y;
    public float change_x;
    public bool limit;
    public Vector2 max_position;
    public Vector2 min_position;

    Vector3 changed_position;

    void Start()
    {
        GameController.camera_shake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    void LateUpdate()
    {
        if(target != null)
        {
            changed_position = target.position;
            changed_position.x += change_x;
            changed_position.y += change_y;
            if(limit)
            {
                changed_position.x = Mathf.Clamp(changed_position.x, min_position.x, max_position.x);
                changed_position.y = Mathf.Clamp(changed_position.y, min_position.y, max_position.y);
            }
            if(transform.position != changed_position)
            {
                transform.position = Vector3.Lerp(transform.position, changed_position, smoothing);
            }
        }
    }

    public void SetArea(Vector2 min, Vector2 max)
    {
        min_position = min;
        max_position = max;
    }
}
