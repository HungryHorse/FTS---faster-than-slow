using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyToolTip : MonoBehaviour {

    public GameObject mapManager;
    public bool test = false;

	// Use this for initialization
	void Start () {
        mapManager = GameObject.Find("StarMapManager");
	}
	
	// Update is called once per frame
	void Update () {
        if (mapManager.GetComponent<StarMapmanager>().isVisible == false)
        {
            Destroy(gameObject);
            Debug.Log("rip dk");
            test = true;
        }
	}
}
