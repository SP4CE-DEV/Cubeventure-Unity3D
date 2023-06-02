using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private AudioSource audio;
    public AudioClip[] jumpSounds;

    [SerializeField] private float moveSpeed = 1;
    [SerializeField] public float turnSpeed = 10;

    public int RespawnX = 15;
    public int RespawnY = 3;
    public int RespawnZ = 17;
    public int RespawnAngle = 0;
    private bool jumpLocked = false;
    
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   // MOVEMENT
        var dir = new Vector3(0, 0, Input.GetAxis("Vertical"));
        transform.Translate(dir * moveSpeed * Time.deltaTime);
        var rot = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        transform.Rotate(rot * turnSpeed * Time.deltaTime);

    // JUMP

        if (Input.GetKeyDown(KeyCode.Space) && jumpLocked == false) {
            audio.clip = jumpSounds[Random.Range(0, jumpSounds.Length)];
            rb.AddForce(0,300,0);
            jumpLocked = true;
        }

        //if fall off map
        if (gameObject.transform.position.y < -2)
        {
            gameObject.transform.position = new Vector3(RespawnX, RespawnY, RespawnZ);
            gameObject.transform.rotation = Quaternion.Euler(0, RespawnAngle, 0);
        }
    }
    void OnCollisionEnter(Collision collision)
    {   // Ground Jump Reset
        if (collision.gameObject.tag == "Ground")
        {
            audio.Play();
            jumpLocked = false;
        }

    // NEXT LEVEL
        if (collision.gameObject.name == "FINISH")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

