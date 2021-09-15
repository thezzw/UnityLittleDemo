using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LittleHeroController : MonoBehaviour
{
    public float run_speed;
    public float climb_speed;
    public float jump_speed;
    public int jump_times = 2;
    int jump_times_count;
    Rigidbody2D little_hero;
    BoxCollider2D  my_feet;
    CapsuleCollider2D my_body;
    Animator little_animator;
    float vertical;
    float original_gravity;
    bool is_run;
    bool is_ground;
    bool is_ladder;

    void Start()
    {
        jump_times_count = jump_times;
        little_hero = GetComponent<Rigidbody2D>();
        original_gravity = GetComponent<Rigidbody2D>().gravityScale;
        little_animator = GetComponent<Animator>();
        my_feet = GetComponent<BoxCollider2D>();
        my_body = GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        if(GameController.alive)
        {
            Flip();
            CheckGround();
            CheckLadder();
            Climb();
            Jump();
            Run();
            Quit();
        } 
    }
    void Flip()//当向左运动时对所有播放的动画进行反转，向右运动则回到初始状态
    {
        if(little_hero.velocity.x < -0.1)
        {
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        if(little_hero.velocity.x > 0.1)
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
    }
    void Run()//根据水平轴设置水平速度，播放跑动动画并关闭站立状态
    {
        float move_direction = Input.GetAxis("Horizontal");
        Vector2 run_velocity = new Vector2(move_direction * run_speed,little_hero.velocity.y);
        little_hero.velocity = run_velocity;
        is_run = Mathf.Abs(little_hero.velocity.x) > Mathf.Epsilon;
        little_animator.SetBool("IsRun",is_run);
        little_animator.SetBool("IsIdle",!is_run);
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && jump_times_count > 0)//按下起跳键且起跳次数不为0时设置起跳速度且播放起跳动画
        {
            if(jump_times_count == 2)
            {
                SoundController.Jump0Clip();
            }
            else if(jump_times_count == 1)
            {
                SoundController.Jump1Clip();
            }
            Vector2 jump_velocity = new Vector2(little_hero.velocity.x, jump_speed);
            little_hero.velocity = jump_velocity;

            little_animator.SetBool("IsJump",true);
            little_animator.SetBool("IsIdle",false);
            jump_times_count--;
        }
        if(little_animator.GetBool("IsJump") && little_hero.velocity.y <= 0.0f)//起跳后竖直速度小于0时播放掉落的动画
        {
            little_animator.SetBool("IsJump",false);
            little_animator.SetBool("IsFall",true);
        }
        if(little_animator.GetBool("IsFall") && is_ground)//如果掉落的时候碰到地面则回到站立状态
        {
            little_animator.SetBool("IsFall",false);
            little_animator.SetBool("IsIdle",true);
            jump_times_count = jump_times;
        }
    }

    void Climb()
    {
        if(is_ladder)
        {
            little_hero.velocity = new Vector2(little_hero.velocity.x, 0.0f);
            little_hero.gravityScale = 0.0f;
            
            little_animator.SetBool("IsClimb",true);

            vertical = Input.GetAxis("Vertical");
            transform.position = new Vector2(transform.position.x, transform.position.y + vertical * climb_speed * Time.deltaTime);

            jump_times_count = jump_times;
        }
        else
        {
            little_hero.gravityScale = original_gravity;
            little_animator.SetBool("IsClimb",false);
        }
    }

    void Quit()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void CheckGround()//检查小英雄是否与地面图层接触，即是否落地
    {
        is_ground = my_feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void CheckLadder()
    {
        is_ladder = my_body.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }
}
