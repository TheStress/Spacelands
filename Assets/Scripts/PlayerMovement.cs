using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    enum Direction {Left, Right, Up, Down};

    private Direction playerDirection = Direction.Right;
    private float playerSpeed = 5.0f;
    public float dashDistance = 1500f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float dashAnimationDelayTime = 0.2f;
    private float lastDash = 0.0f;
    private float dashCooldown = 0.0f;

    public Transform firePoint;

    private Camera mainCam;

    public GameObject bulletToFire;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (rb == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
        mainCam = Camera.main;
    }

    private void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.LeftShift) && Time.time - lastDash > dashCooldown)
        {
            dashCooldown = 0.75f;
            Dash();
        }

        Vector3 mouse = Input.mousePosition;

        Vector3 player = mainCam.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - player.x, mouse.y - player.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, transform.rotation);
        }
    }
    private void Move()
    {

        var horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput < 0)
        {
            playerDirection = Direction.Left;
        }
        if(horizontalInput > 0)
        {
            playerDirection = Direction.Right;
        }
        var verticalInput = Input.GetAxisRaw("Vertical");
        if(verticalInput < 0)
        {
            playerDirection = Direction.Down;
        }
        if(verticalInput > 0)
        {
            playerDirection = Direction.Up;
        }
        rb.velocity = new Vector2(horizontalInput, verticalInput) * playerSpeed;
    }

    private void Dash()
    {
        lastDash = Time.time;
        switch(playerDirection)
        {
            case Direction.Left:
                rb.AddForce(Vector2.left * dashDistance);
                break;
            case Direction.Right:
                rb.AddForce(Vector2.right * dashDistance);
                break;
            case Direction.Up:
                rb.AddForce(Vector2.up * dashDistance);
                break;
            case Direction.Down:
                rb.AddForce(Vector2.down * dashDistance);
                break;
            default:
                Debug.Log("player is not facing any direction");
                break;
        }
    }

}
