using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource randomSound;
    public AudioClip[] audioSources;

    // Use this for initialization
    void Start () {
        audioSources = Resources.LoadAll<AudioClip>("Audio");
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
    }
}
