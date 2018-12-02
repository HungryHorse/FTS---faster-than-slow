using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpIn : MonoBehaviour {

    public LocationForShipInWorld spaceship;
    public AudioClip warpSound;

    private void Awake()
    {
        GetComponent<Animator>().Play("WarpIn");
        
    }

    void Start()
    {
        GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(warpSound);
    }

    public void WarpedIn()
    {
        spaceship.location.EventText();
    }
}
