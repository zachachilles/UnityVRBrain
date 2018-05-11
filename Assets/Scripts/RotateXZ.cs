using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateXZ : MonoBehaviour
{

    void Start()
    {

    }
    void Update()
    {

        float x = Input.GetAxis("RightJoyStickHor");
        float y = Input.GetAxis("RightJoyStickVer");
        if (((x < 0.1 && x > -0.1) && (y < 0.1 && y > -0.1)))
        {

        }
        else if ((x < 0.1 && x > -0.1))
        {
            Vector3 rot = new Vector3(0, 0, 1);
            transform.RotateAround(transform.position, rot, y * Time.deltaTime * 90);
        }
        else if (y < 0.1 && y > -0.1)
        {
            Vector3 rot = new Vector3(1, 0, 0);
            transform.RotateAround(transform.position, rot, x * Time.deltaTime * 90);
        }

        else
        {
            Vector3 xRot = new Vector3(1, 0, 0);
            Vector3 yRot = new Vector3(0, 0, 1);
            transform.RotateAround(transform.position, xRot, x * Time.deltaTime * 90);
            transform.RotateAround(transform.position, yRot, y * Time.deltaTime * 90);

        }

    }
}
