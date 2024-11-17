using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private int theNumberOfJumpsMade;

    public float jumpForce = 5f;

    private int countMaxJump;
    private float maxGroundDistance = 0.15f;
    private Rigidbody2D rb;
    private Animator animator;
    private RaycastHit2D hitCheckGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        countMaxJump = theNumberOfJumpsMade;
    }

    private void Update()
    {
        IsFlying();

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (CheckGround() || theNumberOfJumpsMade > 0))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            JumpingOffThePlatform();
        }
    }

    public void OnJumpButoonDown()
    {

        if (CheckGround() || theNumberOfJumpsMade > 0)
        {
            Jump();
        }
    }

    private void Jump()
    {
        animator.SetBool("Jumping", true);
        rb.velocity = Vector2.up * jumpForce;
        theNumberOfJumpsMade--;
    }

    private void IsFlying()
    {
        if (rb.velocity.y < 0 && !CheckGround())
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("IsFall", true);
        }
        else
            animator.SetBool("IsFall", false);
    }

    private void JumpingOffThePlatform()
    {
        Physics2D.IgnoreLayerCollision(3, 10, true);
        Invoke("IgnoreLayerPletformOff", 0.5f);
    }

    private void IgnoreLayerPletformOff()
    {
        Physics2D.IgnoreLayerCollision(3, 10, false);
    }

    private bool CheckGround()
    {
        hitCheckGround = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, maxGroundDistance, groundMask);

        if (hitCheckGround)
            theNumberOfJumpsMade = countMaxJump;

        return hitCheckGround;
    }
}
