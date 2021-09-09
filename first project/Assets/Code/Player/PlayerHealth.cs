using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private ColoredFlash flashEffect;
    [SerializeField] private Color[] colors ;

    public int maxHealth = 100;
    public int currentHealth = 100;

    public Animator animator;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enime") || collision.CompareTag("Ground") || collision.CompareTag("Spider Boss"))
        {
            TakeDamage(10);
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            if (currentHealth <= 0)
            {
                StartCoroutine("Die");
            }
        }

        if (collision.CompareTag("Spike"))
        {
            TakeDamage(1000);
            if (currentHealth <= 0)
            {
                StartCoroutine("Die");
            }
        }

        if (collision.CompareTag("Healer"))
        {
            Healing(35);
        }

    }

    public void TakeDamage(int damage)
    {
        Color red = colors[0];
        flashEffect.Flash(red);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Healing(int Heal)
    {
        Color green = colors[1];
        flashEffect.Flash(green);
        currentHealth += Heal;
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator Die()
    {
        animator.Play("Death Effect");

        FindObjectOfType<AudioManager>().Play("PlayerDie");

        FindObjectOfType<GameManager>().EndGame();

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

}
