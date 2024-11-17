using UnityEngine;

public abstract class CharactersHp : MonoBehaviour
{
    public float maxHealth = 100f;
    protected float currentHealth;

    public abstract void TakeDamage(float damage);

    public abstract void Die();

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
}
