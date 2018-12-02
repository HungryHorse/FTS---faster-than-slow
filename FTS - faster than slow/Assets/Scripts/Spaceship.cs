using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spaceship : MonoBehaviour {
    public Node currNode;
    public PopUpManager popUpManager;


	// Use this for initialization
	void Start ()
    {
        PositionUpdate(currNode);
	}

    public void PositionUpdate(Node node)
    {
        currNode = node;
        transform.position = currNode.gameObject.transform.position;
        popUpManager.UpdateLocation(currNode.location);
        currNode.location.EventText();
    }
}
