using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            // if audio is finished, goto next scene
            SceneSwitcher switcher = FindObjectOfType<SceneSwitcher>();
            switcher.LoadNextScene();
        }
    }
}
