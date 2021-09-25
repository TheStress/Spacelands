using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Rigidbody2D body;
    private Transform trans;
    private Animator anim;

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
        }
    }
}
