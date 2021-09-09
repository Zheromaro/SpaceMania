using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public float damegTime = 1;
    public int Damag;

    public string clipName;
    public Animator animator;

    [SerializeField]
    public bool isMove;
        
    bool isEnd;

    private void Start()
    {
        isEnd = false;
        isMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Dameg());
        }
    }

    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            animator.Play(clipName);

            PlayerHealth health = hitInfo.GetComponent<PlayerHealth>();

            if (health != null && isEnd == true)
            {
                health.TakeDamage(Damag);
                isEnd = false;
            }
        }
    }

    IEnumerator Dameg()
    {
        yield return new WaitForSeconds(damegTime);

        isEnd = true;

        isMove = false;
    }
}
