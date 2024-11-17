using UnityEngine;

public class PlayerAtteck : MonoBehaviour
{
    [SerializeField] private Transform atteckPos;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int damage = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackRate = 3f;
    private float nextAtteckTime;
    private bool ateck;

    private void Update()
    {
        if (Time.time >= nextAtteckTime) //для pc atteck
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetTrigger("Atteck");
                nextAtteckTime = Time.time + 1.1f / attackRate;
            }
        }

        //if (Time.time >= nextAtteckTime) //для mobile atteck
        //{
        //    ateck = true;
        //}
    }

    public void OnAtteckButoonDown()
    {
        if (ateck)
        {
            animator.SetTrigger("Atteck");
            nextAtteckTime = Time.time + 1.5f / attackRate;
            ateck = false;
        }
    }

    private void Atteck ()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(atteckPos.position, attackRange, enemyLayerMask);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
            enemy.GetComponent<PatrollerEnemy>().KickFromPlayer(10f, 2f);
        }
    }
}
