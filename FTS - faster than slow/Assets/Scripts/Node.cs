using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node : MonoBehaviour
{
    public Location location;
    public Node[] prevNodes;
    public Spaceship ship;


    public void NextNode()
    {
        for(int i = 0; i < prevNodes.Length; i++)
        {
            if(ship.currNode == prevNodes[i])
            {
                ship.PositionUpdate(this);
            }
        }
    }
}
