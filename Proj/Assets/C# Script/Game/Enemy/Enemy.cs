using UnityEngine;
using UnityEngine.UI;

public class Enemy : CharactersHp
{
    [SerializeField] private HelphBarEnemy helthBar;

    protected override void Start()
    {
        base.Start();
        helthBar.SetHealthValue(currentHealth, maxHealth);
    }

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        helthBar.SetHealthValue(currentHealth, maxHealth);
        if (currentHealth <= 0)
            Die();
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
