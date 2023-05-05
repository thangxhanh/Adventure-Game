using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;
    
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private bool doubleJumped = false;
    
    private enum MovementState { idle, running, jumping, falling, doubleJumping }  
    [SerializeField] private MovementState state = MovementState.idle;

    [SerializeField] private AudioSource jumpSourceEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) {
            if (IsGrounded()) {
                doubleJumped = false;
                jumpSourceEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            } else if (!doubleJumped) {
                {
                    doubleJumped = true;
                    jumpSourceEffect.Play();
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f) {
            state = MovementState.running;
            sprite.flipX = false;
        } else if (dirX < 0f) {
            state = MovementState.running;
            sprite.flipX = true;
        } else {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) {
            if (doubleJumped) {
                state = MovementState.doubleJumping;
            } else {
                
                state = MovementState.jumping;
            }
        } else if (rb.velocity.y < -.1f) {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        if (rb.velocity.y != 0) return false;
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
