using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneAxisMove : MonoBehaviour
{
    Rigidbody rigid;
    public int Speed = 20;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigid.position.z > 2.8)
        {
            rigid.velocity = Vector3.back * Speed * Time.deltaTime;
        }
        if (rigid.position.z < -6)
        {
            rigid.velocity = Vector3.forward * Speed * Time.deltaTime;
        }
    }
}
