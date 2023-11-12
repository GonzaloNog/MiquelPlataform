using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        bool hasGroundInDirection = Physics2D.Raycast(groundCheck.position, isFacingRight ? Vector2.right : Vector2.left, 0.1f, groundLayer);

        if (!hasGroundInDirection && isGrounded)
            ChangeDirection();

        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2((isFacingRight ? 1 : -1) * moveSpeed, rb.velocity.y);
    }

    void ChangeDirection()
    {
        isFacingRight = !isFacingRight;

        // Cambiar la dirección del sprite sin cambiar la escala
        spriteRenderer.flipX = !isFacingRight;
    }
}
