using UnityEngine;

public class PatrollerEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask obstaclesMask;
    [SerializeField] private Transform atteckPos;
    [SerializeField] private Transform jumpPos;

    [SerializeField] private int damage = 5;
    [SerializeField] private float atteckRange = 0.5f;
    [SerializeField] private float speed = 4;
    [SerializeField] private float jumpForce;
    [SerializeField] private float stoppingDistance = 7f;
    [SerializeField]private float timer = 2f;

    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private float basicSpeed;
    private float slowSpeed;
    private float basicValueTimer;
    private bool mayAtteck = false;
    private bool moveingRight = true;
    private bool chill = false;
    private bool angry = false;
    //private bool goBack = false;
    private RaycastHit2D hit;
    private RaycastHit2D playerHit;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        basicSpeed = speed;
        slowSpeed = speed / 2;
        basicValueTimer = timer;
    }

    void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 0.5f, obstaclesMask);

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            chill = true;
            angry = false;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
        }

        if (chill)
            Chill();
        if (angry)
            Angry();

        if (timer <= 0)
        {
            mayAtteck = true;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        animator.SetFloat("speed", speed);
    }

    void Chill()
    {
        if (hit)
            moveingRight = !moveingRight;

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + (speed - slowSpeed) * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - (speed - slowSpeed) * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }


    private void Angry()
    {
        playerHit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 0.5f, playerMask);

        var cachedHeight = transform.position.y;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, cachedHeight, transform.position.z);

        if (transform.position.x > player.position.x)
            transform.localScale = new Vector3(-1, 1, 0);
        else
            transform.localScale = new Vector3(1, 1, 0);

        if (hit || playerHit)
        {
            speed = 0;
        }
        else
            speed = basicSpeed;
        // play anim

        Jump();

        if (Vector2.Distance(transform.position, player.position) <= 1.5f)
        {
            if (mayAtteck)
            {
                animator.SetTrigger("Atteck");
                mayAtteck = false;
                timer = basicValueTimer; 
            }
        }
    }

    //private void Goback()
    //{

    //}

    private void Jump()
    {
        RaycastHit2D hitForJump = Physics2D.Raycast(jumpPos.position, Vector2.right * transform.localScale.x, 0.6f, obstaclesMask);

        if (hit && !hitForJump)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void AtteckPlayer()
    {
        Collider2D playerColidder = Physics2D.OverlapCircle(atteckPos.position, atteckRange, playerMask);

        if (playerColidder != null)
        {
            player.GetComponent<PlayerHp>().TakeDamage(damage);
        }
    }

    public void KickFromPlayer(float repulsion, float stunningTime)
    {
        rb.velocity = new Vector2(0f, 0f);


        if (transform.position.x > player.position.x)
            rb.AddForce(transform.position * repulsion);
        else
            rb.AddForce(transform.position * -repulsion);

        speed = 0f;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(atteckPos.position, atteckRange);
    }
}
