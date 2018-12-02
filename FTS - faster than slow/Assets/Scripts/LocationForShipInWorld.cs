﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationForShipInWorld : MonoBehaviour
{
    public Location location;
    public PopUpManager popUpManager;
    public GameObject[] starmaps;

    private void Awake()
    {
        starmaps = GameObject.FindGameObjectsWithTag("Starmap");
    }

    public void ActivateStarMap()
    {
        starmaps[0].SetActive(true);
        starmaps[1].SetActive(true);
    }

    public void EventSpawn()
    {
        popUpManager.UpdateLocation(location);
        location.EventText();
    }

}
