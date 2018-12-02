using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpIn : MonoBehaviour {

    public LocationForShipInWorld spaceship;

    private void Awake()
    {
        GetComponent<Animator>().Play("WarpIn");
    }

    public void WarpedIn()
    {
        spaceship.location.EventText();
    }
}
