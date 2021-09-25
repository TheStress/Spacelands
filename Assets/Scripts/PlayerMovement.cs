using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 5.0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontalInput, verticalInput) * (playerSpeed + Time.deltaTime);
    }
}
