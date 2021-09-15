using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBat : Enemy
{
    public float speed;
    public float wait_time;
    float timer_wait;

    public Transform aim_position;
    public Transform left_position;
    public Transform right_position;

    new void Start()
    {
        base.Start();
        timer_wait = wait_time;
        if(aim_position != null && left_position != null && right_position != null)
        {
            aim_position.position = RandomPosition();
        }
    }
    
    new void Update()
    {
        if(aim_position != null && left_position != null && right_position != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,aim_position.position,speed * Time.deltaTime);
            if(Vector2.Distance(aim_position.position,transform.position) < 0.1f)
            {
                if(timer_wait <= 0.0f)
                {
                    aim_position.position = RandomPosition();
                    timer_wait = wait_time;
                }
                else
                {
                    timer_wait -= Time.deltaTime;
                }
            }
        }
    }

    Vector2 RandomPosition()
    {
        Vector2 random_position = new Vector2(Random.Range(left_position.position.x,right_position.position.x),Random.Range(left_position.position.y,right_position.position.y));
        return random_position;
    }
}
