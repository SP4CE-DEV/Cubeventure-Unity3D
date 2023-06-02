using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeGenerator : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip[] sounds;

    public GameObject Text;

    public GameObject cube;
    private GameObject[] cubeArray = new GameObject[6];
    private Vector3[] cubePosArray = new Vector3[6];

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider obj)
    {
        // ENTERING BRIDGE GENERATOR
        if (obj.gameObject.tag == "BridgeGen")
        {
            audio.clip = sounds[Random.Range(0, sounds.Length)];
            Destroy(Text);
            audio.Play();

            // deleting all cubes before spawning new ones
            for (int i = 0; i < 6; i++)
            {
                Destroy(cubeArray[i]);
            }

            for (int i = 0; i < 6; i++)
            {
                // generating a random position for the cube
                cubePosArray[0] = new Vector3(0, 0, 0);
                Vector3 RandPos = new Vector3(Random.Range(5, 14), Random.Range(4, 8), Random.Range(-22, -8));
                for (int c = 0; c < 6; c++)
                {
                    // ensure the position is unique
                    while (cubePosArray[i] == RandPos)
                    {
                        RandPos = new Vector3(Random.Range(5, 14), Random.Range(4, 7), Random.Range(-18, -8));
                    }
                }
                // adding to a list, to keep track of it
                cubeArray[i] = Instantiate(cube, RandPos, Quaternion.identity);
            }
        }
        // ENTERING BRIDGE END
        if (obj.gameObject.name == "BridgeEnd")
        {
            for (int d = 0; d < 6; d++)
            {
                Destroy(cubeArray[d]);
            }
        }
    }
}

