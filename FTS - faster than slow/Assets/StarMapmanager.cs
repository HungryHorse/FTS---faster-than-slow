using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMapmanager : MonoBehaviour {

    [SerializeField]
    private GameObject starmapVisual, starmapButtons;
    public bool isVisible;
    public void TurnStarmapsOff()
    {
        starmapVisual.SetActive(false);
        starmapButtons.SetActive(false);
        isVisible = false;
    }

    public void TurnStarmapsOn()
    {
        starmapVisual.SetActive(true);
        starmapButtons.SetActive(true);
        isVisible = true;
    }
}
