using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerDestroy : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            animator.Play("healing", 0, 1f);
            Destroy(gameObject);
        }
    }

}
