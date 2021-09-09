using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimeMove : MonoBehaviour
{

    public GameObject boomEffect;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] positions;

    private int index;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index])
        {
            if (index == positions.Length -1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(boomEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
