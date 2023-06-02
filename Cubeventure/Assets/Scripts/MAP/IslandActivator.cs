using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class IslandActivator : MonoBehaviour
{
    private Rigidbody rigid;
    private AudioSource aud;
    public AudioClip[] audioClips;

    private bool descending = false;

    public GameObject[] coils = new GameObject[16];

    public PostProcessVolume pp;
    private ColorGrading colorGrading;

// START
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        pp.profile.TryGetSettings(out colorGrading);
        aud = GetComponent<AudioSource>();
    }

// UPDATE
    void Update()
    {
        if (descending)
        {
            transform.Translate(Vector3.down * 0.6f * Time.deltaTime);
            if (gameObject.transform.position.y < 0)
            {
                descending = false;
                Destroy(gameObject);
            }
        }
    }

// VFX with timers
    IEnumerator PP_effects()
    {
        // STAGE 1
        colorGrading.hueShift.value = -180;
        colorGrading.postExposure.value = -4;
        gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        aud.clip = audioClips[0];
        aud.Play();

        // STAGE 2
        yield return new WaitForSeconds(1);
        descending = true;
        colorGrading.hueShift.value = 180;
        colorGrading.contrast.value = 100;
        colorGrading.postExposure.value = 3;
        transform.Translate(Vector3.up * 0.1f);
        aud.clip = audioClips[1];
        aud.Play();
        for (int i = 0; i < 16; i++)
        {
            Destroy(coils[i]);
        }

        // STAGE 3
        yield return new WaitForSeconds(2);
        descending = true;
        colorGrading.hueShift.value = 0;
        colorGrading.contrast.value = 0;
        colorGrading.postExposure.value = 0;
        Debug.Log("Effect finished");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!descending)
        {
            if (collider.gameObject.tag == "Player")
            {
                StartCoroutine(PP_effects());
            }
        }
    }
}
