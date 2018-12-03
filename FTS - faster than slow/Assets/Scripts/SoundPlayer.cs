using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    AudioSource player;
    float volume;

	// Use this for initialization
	void Start () {
        player = GetComponent<AudioSource>();
        PlayBGM();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void PlaySound(AudioClip clip)
    {
        player.PlayOneShot(clip);
    }

    public void PlayBGM()
    {
        player.Play();
    }

    public void SetVolume(float v)
    {
        volume = v;
        player.volume = volume;
    }
}
