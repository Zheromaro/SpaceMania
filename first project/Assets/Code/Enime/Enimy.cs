using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamege(20);
    }
    public void TakeDamege (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
