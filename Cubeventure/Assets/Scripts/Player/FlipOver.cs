using System;
using UnityEngine;

public class FlipOver : MonoBehaviour
{
    public float Angle_flip = 0.5f;

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Math.Abs(gameObject.transform.rotation.x) > Angle_flip || Math.Abs(gameObject.transform.rotation.z) > Angle_flip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
