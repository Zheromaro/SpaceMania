using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public GameObject deathEffect;
    public HealthBar healthBar;
    public GameManager gameManager;

    [SerializeField] private ColoredFlash flashEffect;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamege(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        flashEffect.Flash(Color.red);

        if (currentHealth <= 0)
        {
            Die();
            gameManager.ComleteLevel();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
