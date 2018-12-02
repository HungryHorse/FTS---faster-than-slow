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
        locationForShip.EventSpawn();

        locationForShip.location.EnterLocation();

        starmapManager.TurnStarmapsOff();
    }
}
