using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Health php;

    private Rigidbody2D body;
    private Transform trans;
    private Animator anim;

    public float attacCD;
    public int damage;

    private bool attackCoolDown = false;
    private float clock = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCoolDown)
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
        Vector2 direction = target.position - trans.position;
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
        if(!attackCoolDown)
        {
            php.TakeDamage(damage);
            attackCoolDown = true;
        }
    }
}
