using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    AudioSource player;
    public AudioClip testClip;

	// Use this for initialization
	void Start () {
        player = GetComponent<AudioSource>();
        PlayBGM();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            PlaySound(testClip);
        }
	}

    public void PlaySound(AudioClip clip)
    {
        player.PlayOneShot(clip);
    }

    public void PlayBGM()
    {
        player.Play();
    }
}
