using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleComand : MonoBehaviour
{
    public Animator animator;
    public Animator circleAnimator;

    [SerializeField]
    public bool shielded;

    [SerializeField]
    public bool shieldTime;

    [SerializeField]
    private GameObject shield;


    private void Start()
    {
        shieldTime = false;
        shielded = false;
    }

    private void Update()
    {
        CheckShield();
    }

    void CheckShield()
    {
        if (Input.GetKey(KeyCode.E) && shieldTime == false)
        {
            animator.Play("Shield Empte");
            shield.SetActive(true);  
            shielded = true;
            shieldTime = true;
            //Turn Off    
            Invoke("NoShield", 3);
        }
    }

    void NoShield()
    {
        shield.SetActive(false);
        shielded = false;
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        shieldTime = false;
    }
}