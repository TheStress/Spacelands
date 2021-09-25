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
        Vector3 direction = target.position - trans.position;
        body.velocity = direction.normalized * speed * Time.deltaTime;
    }
}
