using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeMove : MonoBehaviour
{
    public Range range;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] positions;

    private int index;

    void Update()
    {
        if (range.isMove == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

            if (transform.position == positions[index])
            {
                if (index == positions.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
        }
    }
}
