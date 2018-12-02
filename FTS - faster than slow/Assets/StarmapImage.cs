using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarmapImage : MonoBehaviour {

    public GameObject starMap;
    public GameObject starMapImage;
	// Update is called once per frame
	void Update ()
    {
        starMapImage.SetActive(starMap.activeInHierarchy);
	}
}
