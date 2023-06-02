using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisMovement : MonoBehaviour
{
    Rigidbody rigid;
    public int moveYspeed = 0;
    public int endY = 0;
    bool ToPoint1 = false;
    bool ToPoint2 = true;
    float StartY;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        StartY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   // MOVE TO POINT 2
        if (ToPoint2)
        {
            rigid.AddForce(0, moveYspeed, 0);
            if (gameObject.transform.position.y > endY)
            {
                ToPoint2 = false;
                ToPoint1 = true;
            }
        }
        // MOVE TO POINT 2
        if (ToPoint1)
        {
            rigid.AddForce(0, -moveYspeed, 0);
            if (gameObject.transform.position.y < StartY)
            {
                ToPoint2 = true;
                ToPoint1 = false;
            }
        }
;   }
}
