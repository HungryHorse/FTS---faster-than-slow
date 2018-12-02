using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spaceship : MonoBehaviour {
    public Node currNode;
    public LocationForShipInWorld locationForShip;
    public StarMapmanager starmapManager;
    

    public void PositionUpdate(Node node)
    {
        currNode = node;
        transform.position = currNode.gameObject.transform.position;
        locationForShip.location = currNode.location;
        locationForShip.warp.WarpInAnimation();
        locationForShip.location.EnterLocation();

        starmapManager.TurnStarmapsOff();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "DangerZone")
        {
            Debug.Log("Caught by the dong");

        }
    }
}
