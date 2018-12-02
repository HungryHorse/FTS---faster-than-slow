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

    public void WarpInAnimation()
    {
        GetComponent<Animator>().Play("WarpIn");
    }

    public void WarpedIn()
    {
        spaceship.location.EventText();
        GetComponent<Animator>().Play("IdleAnimation");
    }

    public void WarpOutAnimation()
    {
        GetComponent<Animator>().Play("WarpOut");
    }

    public void WarpedOut()
    {
        spaceship.ActivateStarMap();
        Debug.Log("HI");
    }
}
