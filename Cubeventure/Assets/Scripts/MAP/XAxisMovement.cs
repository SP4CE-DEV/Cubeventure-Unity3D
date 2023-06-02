using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XAxisMovement : MonoBehaviour
{
    Rigidbody rigid;
    public int moveX = 0;
    public int endX = 0;
    bool MovingToPoint1 = false;
    bool MovingToPoint2 = true;
    float startX;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        startX = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentX = gameObject.transform.position.x;
    // POINT 1 to POINT 2 moving
        if (MovingToPoint2)
        {
            rigid.AddForce(moveX, 0, 0);
            if (currentX > endX)
            {
                MovingToPoint1 = true;
                MovingToPoint2 = false;
            }
        }
    // POINT 2 to POINT 1 moving
        if (MovingToPoint1)
        {
            rigid.AddForce(-moveX, 0, 0);
            if (currentX < startX)
            {
                MovingToPoint1 = false;
                MovingToPoint2 = true;
            }
        }
    }
}
