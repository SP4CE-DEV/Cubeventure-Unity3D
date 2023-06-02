using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainlyJump : MonoBehaviour
{
    private Rigidbody rigid;
    public ParticleSystem splash;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        splash = splash.GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            splash.Play();
            Debug.Log("Spwash");
        }
    }
}
