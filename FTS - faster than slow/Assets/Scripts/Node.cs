using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node : MonoBehaviour
{
    public Location location;
    public Location[] locationArray;
    public Node[] prevNodes;
    public Spaceship ship;

    private void Start()
    {
        int rand = Random.Range(0, locationArray.Length);
        location = Instantiate(locationArray[rand]);
    }

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

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < prevNodes.Length; i++)
        {
            if (ship.currNode == prevNodes[i])
            {
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
