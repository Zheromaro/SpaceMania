using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeHealth : MonoBehaviour
{
    public int health = 60;

    public Range range;

    public GameObject deathEffect;

    [SerializeField] private SimpalFlash flashEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamege(20);
    }
    public void TakeDamege(int damage)
    {
        health -= damage;

        flashEffect.Flash();

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
