using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spaceship : MonoBehaviour
{
    public Node currNode;
    public LocationForShipInWorld locationForShip;
    public StarMapmanager starmapManager;
    public bool canMove;

    private void Start()
    {
        canMove = true;
    }

    public void PositionUpdate(Node node, bool first)
    {

        
        
        if (first)
        {
            currNode = node;
            transform.position = currNode.gameObject.transform.position;
            locationForShip.location = currNode.location;
            locationForShip.warp.WarpInAnimation();
            locationForShip.location.EnterLocation();

            starmapManager.TurnStarmapsOff();
        }
        else
        {
            if (canMove)
            {
                canMove = false;

                currNode = node;
                transform.position = currNode.gameObject.transform.position;
                Invoke("DelayedUpdate", 1.5f);
            }
            

        }


    }

    void DelayedUpdate()
    {
        locationForShip.location = currNode.location;
        locationForShip.warp.WarpInAnimation();
        locationForShip.location.EnterLocation();
        canMove = true;
        starmapManager.TurnStarmapsOff();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "DangerZone")
        {
            Debug.Log("Caught by the dong");
            GameObject.Find("GameOver").GetComponent<GameOver>().gameOver();
        }
    }
}
