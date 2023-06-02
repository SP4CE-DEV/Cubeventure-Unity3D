using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_n_Respawn : MonoBehaviour
{
    public GameObject checkPointPlane;
    public GameObject checkPointPlane2;
    public float checkPoint1RotY = 0;
    public float checkPoint2RotY = 0;
    Vector3 respawnCords;
    float respawnRotY = 0;

    public GameObject textCheckpoint;

    private AudioSource audio;
    public AudioClip audioClip;

    private ParticleSystem particles;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //if fall off map
        if (gameObject.transform.position.y < -1)
        {
            Respawn();
        }
    }
    void OnTriggerEnter(Collider obj)
    {   // Checkpoint 1
        if (obj.CompareTag("CheckPoint"))
        {
            CheckpointCollided();
            Debug.Log("CheckPoint 1 saved");
            respawnCords = checkPointPlane.transform.position;
            respawnRotY = checkPoint1RotY;
        }
        // Checkpoint 2
        if (obj.CompareTag("CheckPoint2"))
        {
            CheckpointCollided();
            Debug.Log("CheckPoint 2 saved");
            respawnCords = checkPointPlane2.transform.position;
            respawnRotY = checkPoint2RotY;
            Destroy(textCheckpoint);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Respawn();
        }
    }
    // SPECIFIC METHODS
    void CheckpointCollided()
    {
        audio.clip = audioClip;
        audio.Play();
    }

    void Respawn()
    {
        gameObject.transform.position = respawnCords;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        particles.Play();
    }
}
