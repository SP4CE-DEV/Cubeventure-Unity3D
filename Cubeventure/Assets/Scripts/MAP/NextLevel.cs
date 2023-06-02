using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
// VARS
    public string SceneName;
    public Color finish_color;
    public Color start_color;
    private Renderer renderer;
    private Renderer renderer_beam;

    public GameObject beam, next_level_text;

    private AudioSource audio;

    public Animator transition;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
        renderer_beam = beam.GetComponent<Renderer>();
        renderer.material.color = start_color;
        renderer_beam.material.color = start_color;
    }
    // WAIT
    IEnumerator Wait()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneName);
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            audio.Play();
            renderer.material.color = finish_color;
            renderer_beam.material.color = finish_color;
            Destroy(beam); Destroy(next_level_text);
            StartCoroutine(Wait());
        }
    }
}


