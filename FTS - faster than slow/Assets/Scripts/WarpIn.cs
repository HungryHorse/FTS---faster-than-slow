using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpIn : MonoBehaviour {

    public LocationForShipInWorld spaceship;
    public StarMapmanager starmapManager;
    public AudioClip warpInSound;
    public AudioClip warpOutSound;
    public ScoreManager scoreManager;
    int score;

    private void Awake()
    {
        GetComponent<Animator>().Play("WarpIn");
        
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
        if (spaceship.location.isEnd)
        {
            Debug.Log(scoreManager.GetScore());
            score = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().CalculateScore();
            scoreManager.SetScore(score);
            GameObject.Find("GameOver").GetComponent<GameOver>().winGame();
        }
        else
        {
            starmapManager.TurnStarmapsOn();
        }
    }
}
