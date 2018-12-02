using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMapmanager : MonoBehaviour {

    [SerializeField]
    private GameObject starmapVisual, starmapButtons;

    public void TurnStarmapsOff()
    {
        starmapVisual.SetActive(false);
        starmapButtons.SetActive(false);
    }

    public void TurnStarmapsOn()
    {
        starmapVisual.SetActive(true);
        starmapButtons.SetActive(true);
    }
}
