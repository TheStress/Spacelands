using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Rigidbody2D body;
    private Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
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
            body.velocity = direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            body.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
