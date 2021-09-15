using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed;
    public float rotate_speed;
    public int damage;

    Rigidbody2D body;
    PolygonCollider2D this_collider;
    Transform player_transform;
    Transform boomerang_transform;
    Vector2 start_speed;
    Vector3 mouse_position;
    Vector2 direction;

    bool back = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player_transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boomerang_transform = GetComponent<Transform>();
        this_collider = GetComponent<PolygonCollider2D>();
        Vector3 mouse_position_screen = Input.mousePosition;
        mouse_position = Camera.main.ScreenToWorldPoint(mouse_position_screen);
        direction = (mouse_position - player_transform.position).normalized;
        body.velocity = direction * speed;
        start_speed = body.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotate_speed);
        if(Mathf.Abs(body.velocity.x) > 0.1  && !back)
        {
            body.velocity -= start_speed * Time.deltaTime;
            if(this_collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                back = true;
            }
        }
        else
        {
            back = true;
        }
        if(back)
        {
            transform.position = Vector2.MoveTowards(transform.position,player_transform.position,speed * Time.deltaTime);
            if(Vector2.Distance(player_transform.position, transform.position) < 0.5f)
            {
                Destroy(gameObject);
            }
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
