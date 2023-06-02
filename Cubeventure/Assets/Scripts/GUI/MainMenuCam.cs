using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MainMenuCam : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(0, -17, 0);
    }
    void Update()
    {
        transform.Translate(new Vector3(0.25f, 0, 0) * Time.unscaledDeltaTime);
    }
}
