using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [Header("Player Skils")]
    public float moveSpeed = 1f;
    public float jumpForce = 5f;
    [Header("Layer")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    [Header("Fisicas")]
    private Rigidbody2D rb;
    private bool isGrounded;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput, 0).normalized;

        rb.velocity = new Vector2(movement.x * moveSpeed,rb.velocity.y);

        Debug.Log(isGrounded);
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else 
            spriteRenderer.flipX = false;
    }
}
