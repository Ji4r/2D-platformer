using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : CharactersHp
{
    [SerializeField] private GameObject panelLose;
    [SerializeField] private Image bar;

    private BoxCollider2D playerCollider;

    protected override void Start()
    {
        base.Start();
        playerCollider = GetComponent<BoxCollider2D>();
        panelLose.SetActive(false);
    }

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        // play anim

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHelthbar();
    }

    public override void Die()
    {
        // play anim 
        UpdateHelthbar();

        playerCollider.enabled = false;
        panelLose.SetActive(true);
        Time.timeScale = 0;
    }

    public void UpdateHelthbar()
    {
        bar.fillAmount = currentHealth / maxHealth;
    }
}
