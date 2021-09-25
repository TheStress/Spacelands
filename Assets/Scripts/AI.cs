using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Health php;

    private Rigidbody2D body;
    private Transform trans;
    private Animator anim;

    private float attacCD = 1.0f;
    private int damage = 10;

    private bool attackCoolDown = false;
    private float clock = 0.0f;

    private AudioSource audio;

    // Start is called before the first frame update
    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        target = GameObject.Find("sword_man").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        php = GameObject.Find("sword_man").GetComponent<Health>();
        audio = GetComponent<AudioSource>();
        audio.volume = 0.05f;
        audio.loop = true;
        audio.Play();
    }

    // Update is called once per frame
    public void Update()
    {
        if (attackCoolDown)
        {
            clock += Time.deltaTime;
            if(clock > attacCD)
            {
                attackCoolDown = false;
                clock = 0.0f;
            }
        }
    }

    private void FixedUpdate()
    {
        body.rotation = 0.0f;
        Vector2 direction = target.position - this.transform.position;
        if (direction.sqrMagnitude > 1.0f)
        {
            Vector2 velocity = direction.normalized * speed * Time.deltaTime;
            body.velocity = velocity;
            if(Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
            {
                if(velocity.x < 0)
                {
                    anim.Play("Left");
                } else
                {
                    anim.Play("Right");
                }
            }
            else
            {
                if (velocity.y < 0)
                {
                    anim.Play("Down");
                }
                else
                {
                    anim.Play("Up");
                }
            }
        }
        else
        {
            body.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            anim.Play("Idle");
            attack();
        }
    }

    private void attack()
    {
        if (!attackCoolDown)
        {
            php.TakeDamage(damage);
            attackCoolDown = true;
        }
    }
}
