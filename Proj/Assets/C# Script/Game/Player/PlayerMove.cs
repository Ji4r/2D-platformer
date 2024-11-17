using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private Joystick joystick;
    [SerializeField] private LayerMask checkWallsMask;

    public float speed = 5f;
    public float basicSpeed;
    public Vector3 sizePlayer;

    private float maxWallDistance = 0.05f;
    private Rigidbody2D rb;
    private int lungeImpulse = 100;
    private float dir;
    private Animator animator;
    private RaycastHit2D hitCheckWalls;
    

    private void Start()
    {
        basicSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sizePlayer = new Vector3(1, 1, 1);
    }

    private void Update()
    {
        Walk();
        Sprint();
    }

    private void Walk()
    {
        dir = Input.GetAxis("Horizontal");
        //dir = joystick.Horizontal;

        if (dir > 0 && !CheckedWalls())
        {
            transform.position += new Vector3(dir * speed, 0, 0) * Time.deltaTime;
            gameObject.transform.localScale = sizePlayer;
        }
        if (dir < 0 && !CheckedWalls())
        {
            transform.position += new Vector3(dir * speed, 0, 0) * Time.deltaTime;
            gameObject.transform.localScale = new Vector3(-sizePlayer.x, sizePlayer.y, sizePlayer.z);
        }

        if (!CheckedWalls())
        {
            animator.SetFloat("HorizontalMove", Math.Abs(dir));
        }
        else
        {
            animator.SetFloat("HorizontalMove", 0);
        }
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = basicSpeed + 2.5f;
            animator.SetBool("Sprint", true);
        }
        else
        {
            speed = basicSpeed;
            animator.SetBool("Sprint", false);
        }
    }

    private bool CheckedWalls()
    {
        hitCheckWalls = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.right * dir, maxWallDistance, checkWallsMask);

        return hitCheckWalls;
    }
}
