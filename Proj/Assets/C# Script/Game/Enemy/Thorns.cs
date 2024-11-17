using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    public PlayerHp hpPlayer;

    private int thornsDamage = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            hpPlayer.TakeDamage(thornsDamage);
            Rigidbody2D rbPlayer = collision.collider.gameObject.GetComponent<Rigidbody2D>();
            rbPlayer.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
    }
}
