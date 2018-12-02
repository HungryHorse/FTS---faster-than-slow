using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {

    float shipSpeed;
    float shipTravelDistance;
    float distanceToTravel;
    public float stepDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdatePosition(int distance)
    {
        shipTravelDistance = distance;
        shipSpeed = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().enginePower;
        distanceToTravel = (shipTravelDistance / shipSpeed);
        transform.position += new Vector3(distanceToTravel * stepDistance, 0, 0);
        Debug.Log("dong alert!" + distance + " " + shipSpeed + " " + (distance / shipSpeed * stepDistance));
    }
}
