using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spaceship : MonoBehaviour {
    public Node currNode;


	// Use this for initialization
	void Start ()
    {
        PositionUpdate(currNode);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PositionUpdate(Node node)
    {
        currNode = node;
        transform.position = currNode.gameObject.transform.position;
    }
}
