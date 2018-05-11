using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAround : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
        bool rightDown = Input.GetButton("RightJoyClick");
        bool leftDown = Input.GetButton("LeftJoyClick");
        if (rightDown)
        {
            transform.RotateAround(transform.position, transform.up, 1 * Time.deltaTime * 90);
        }
        else if (leftDown)
        {
            transform.RotateAround(transform.position, transform.up, 1 * Time.deltaTime * 90);
        }

   /*/     else if (1 == 0)
        {

            Vector3 xRot = new Vector3(1, 0, 0);
            Vector3 yRot = new Vector3(0, 1, 0);
            transform.RotateAround(transform.position, yRot, 1 * Time.deltaTime * 90);
            transform.RotateAround(transform.position, yRot, 1 * Time.deltaTime * 90);

        } /*/

    }
}
