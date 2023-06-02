using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTextOnCollision : MonoBehaviour
{

    public string ObjectName;
    public GameObject Text;

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ObjectName)
        {
            Destroy(Text);
        }
    }
}
