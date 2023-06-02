using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterSigns : MonoBehaviour
{
    public AudioClip[] soundArray;
    private AudioSource audio;

    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TeleportSign"))
        {
                // getting the position of the TeleportSign
            Vector3 signPos = collision.transform.position;
                // teleporting player to random position near TeleportSign
            gameObject.transform.position = new Vector3(Random.Range(signPos.x - 4, signPos.x + 4), signPos.y, (Random.Range(signPos.z - 4, signPos.z + 4)));
            // playing a random sound from array
            audio.clip = soundArray[Random.Range(0, soundArray.Length)];
            audio.Play();
        }
 
    }
}
