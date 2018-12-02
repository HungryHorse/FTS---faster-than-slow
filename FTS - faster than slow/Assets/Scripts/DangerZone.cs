using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {

    float shipSpeed;
    float shipTravelDistance;
    float distanceToTravel;
    Vector3 newPos;
    public float stepDistance;

	// Use this for initialization
	void Start () {
        newPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 3f);
    }

    public void UpdatePosition(int distance)
    {
        shipTravelDistance = distance;
        shipSpeed = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().enginePower;
        distanceToTravel = (shipTravelDistance / shipSpeed);
        newPos = transform.position + new Vector3(distanceToTravel * stepDistance, 0, 0);
        //transform.position = Vector3.Lerp(transform.position, newPos, 1f);
        Debug.Log("dong alert!" + distance + " " + shipSpeed + " " + (distance / shipSpeed * stepDistance));
    }
}
