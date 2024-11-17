using UnityEngine;

public class FlightFireBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage = 34;

    private Transform player;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float Horizontal;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();

        if (player.localScale.x < 0)
        {
            sprite.flipX = true;
            Horizontal = -1;
        }
        else if (player.localScale.x > 0)
        {
            sprite.flipX = false;
            Horizontal = 1;
        }
    }

    private void Update()
    {
        moving();
    }

    private void moving()
    {
        transform.position += new Vector3(Horizontal * speed, 0, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
