using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public float max = 8;
    public float min = 3;


    void Start()
    {
            Camera.main.orthographicSize = 6;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + 1 * Time.deltaTime;

            if (Camera.main.orthographicSize > max)
            {
                Camera.main.orthographicSize = max;
            }
        }

        if (Camera.main.transform.position.x == 50 )
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize - 1 * Time.deltaTime;

            if (Camera.main.orthographicSize < min)
            {
                Camera.main.orthographicSize = min;
            }
        }
    }
}
