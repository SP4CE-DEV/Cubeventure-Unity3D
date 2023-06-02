using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalAnimation : MonoBehaviour
{
    [SerializeField] public int RotateSpeed = 5;
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, RotateSpeed * Time.deltaTime);
    }
}
