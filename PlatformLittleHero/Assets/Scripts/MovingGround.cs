using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public float speed;
    public float wait_time;
    public Transform[] aim_positions;

    float timer_wait;
    int index;
    Transform DefPlayerParent;

    void Start()
    {
        timer_wait = wait_time;
        DefPlayerParent = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().parent;
    }

    void Update()
    {
        if(aim_positions[0] != null && aim_positions[1] != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,aim_positions[index].position,speed * Time.deltaTime);
            if(Vector2.Distance(aim_positions[index].position,transform.position) < 0.1f)
            {
                if(timer_wait <= 0.0f)
                {
                    if(index == 0)
                    {
                        index = 1;
                    }
                    else
                    {
                        index = 0;
                    }
                    timer_wait = wait_time;
                }
                else
                {
                    timer_wait -= Time.deltaTime;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.BoxCollider2D"))
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.BoxCollider2D"))
        {
            other.gameObject.transform.parent = DefPlayerParent;
        }
    }
}
