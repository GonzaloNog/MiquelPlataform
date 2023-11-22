using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public bool isLive = true;

    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;

    Animator anim;
    bool isDead = false;
    bool hasExecutedDeathAnimation = false;  // Nueva variable
    private bool deadChange = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
            bool hasGroundInDirection = Physics2D.Raycast(groundCheck.position, isFacingRight ? Vector2.right : Vector2.left, 0.1f, groundLayer);

            if (!hasGroundInDirection && isGrounded)
                ChangeDirection();

            if (isLive)
                Move();
        }

        SetAnimationState();
    }

    void Move()
    {
        rb.velocity = new Vector2((isFacingRight ? 1 : -1) * moveSpeed, rb.velocity.y);
    }

    void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !isFacingRight;
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            ChangeDirection();
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SuperGirl"))
        {
            if (LevelManager.instance.getCharacterControler().getIsDead())
            {
                if (!deadChange)
                {
                    Debug.Log("Muerto " + isDead);
                    ChangeDirection();  // Cambiar dirección solo si Supergirl está muerta
                    rb.velocity = new Vector2((isFacingRight ? 1 : -1) * moveSpeed, rb.velocity.y);
                    deadChange = true;
                }
            }
            else
            {
                if (isLive)
                {
                    Debug.Log("te has morio");
                    LevelManager.instance.getCharacterControler().CharacterDead();
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (LevelManager.instance.getCharacterControler().getIsDead())
        {
            deadChange = false;
        }
    }
    void SetAnimationState()
    {
        if (!isLive && !hasExecutedDeathAnimation)
        {
            anim.SetBool("isDead", true);
            hasExecutedDeathAnimation = true;  // Marcar que la animación ha sido ejecutada
            Debug.Log("MUERTO");
            return;
        }
    }
}
