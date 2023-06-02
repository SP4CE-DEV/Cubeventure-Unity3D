using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip[] audioClips;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = audioClips[0];
        audio.Play();

    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            Debug.Log("Music 2 Started");
            audio.clip = audioClips[1];
            audio.Play();
        }
    }
}
