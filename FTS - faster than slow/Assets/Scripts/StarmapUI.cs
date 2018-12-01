using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarmapUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowMap()
    {
        gameObject.SetActive(true);
    }

    public void HideMap()
    {
        gameObject.SetActive(false);
    }

    public void ToggleMap()
    {
        if (gameObject.active)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
