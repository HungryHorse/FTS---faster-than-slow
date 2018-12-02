using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpIn : MonoBehaviour {

    public LocationForShipInWorld spaceship;
    public StarMapmanager starmapManager;
    public AudioClip warpInSound;
    public AudioClip warpOutSound;

    private void Awake()
    {
        GetComponent<Animator>().Play("WarpIn");
        
    }

    void Start()
    {
        
    }

    public void WarpInAnimation()
    {
        GetComponent<Animator>().Play("WarpIn");
        GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(warpInSound);
    }

    public void WarpedIn()
    {
        spaceship.EventSpawn();
        GetComponent<Animator>().Play("IdleAnimation");
    }

    public void WarpOutAnimation()
    {
        GetComponent<Animator>().Play("WarpOut");
        GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>().PlaySound(warpOutSound);
    }

    public void WarpedOut()
    {
        starmapManager.TurnStarmapsOn();
    }
}
