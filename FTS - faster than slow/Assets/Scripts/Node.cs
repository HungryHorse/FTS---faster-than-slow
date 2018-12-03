using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node : MonoBehaviour
{
    public bool first;
    public bool end;
    public Location location;
    public Location[] locationArray;
    public Node[] prevNodes;
    public Spaceship ship;
    public float goodChance;
    public float badChance;
    public int distance;
    public StatManager stat;
    private static bool hasMadeGoodBad;
    [SerializeField]
    private StarMapmanager starmapManager;

    private void Awake()
    {
        stat = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>();
        goodChance = Random.Range(0.1f, 0.35f);
        badChance = 1 - goodChance;
        distance = Random.Range(70, 150);
        int rand = Random.Range(0, locationArray.Length);

        if(!first && !end)
        {
            location = Instantiate(locationArray[rand]);

        }
        if (first)
        {
            location = Instantiate(location);
            ship.PositionUpdate(this, true);
        }
        else if (end)
        {
            location = Instantiate(location);
        }
    }    

    public void NextNode()
    {
        for(int i = 0; i < prevNodes.Length; i++)
        {
            if(ship.currNode == prevNodes[i])
            {
                float makeGood = Random.Range(0.0f, 1.0f);
                if (makeGood < goodChance)
                {
                    location.isGood = true;
                }
                if (ship.canMove)
                {
                    GameObject.FindGameObjectWithTag("DangerZone").GetComponent<DangerZone>().UpdatePosition(distance);
                    GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().NextTurn();
                    ship.PositionUpdate(this, false);
                }
                
                
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

                if (hasMadeGoodBad)
                {
                    SetGoodChance(stat.navigatorAmount);
                    SetBadChance();
                    hasMadeGoodBad = true;
                }
                break;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    public void SetGoodChance(int noOfNav)
    {
        int rand = 0;
        int good = 0;
        good = (int)(goodChance * 100);

        int percentOfNavs = (noOfNav / 15);

        if(percentOfNavs >= 0.8)
        {
            
        }
        else if(percentOfNavs >= 0.7)
        {
            rand = Random.Range(-1, 1);
        }
        else if (percentOfNavs >= 0.6)
        {
            rand = Random.Range(-2, 1);
        }
        else if (percentOfNavs >= 0.5)
        {
            rand = Random.Range(-4, 1);
        }
        else if (percentOfNavs >= 0.4)
        {
            rand = Random.Range(-8, 1);
        }
        else if (percentOfNavs >= 0.3)
        {
            rand = Random.Range(-14, 1);
        }
        else if (percentOfNavs >= 0.2)
        {
            rand = Random.Range(-20, 1);
        }
        else
        {
            good = 0;
        }

        good += rand;
        good = Mathf.Clamp(good, 0, 100);

        goodChance = (float)good / 100f;
    }

    public void SetBadChance()
    {
        badChance = 1 - goodChance;
    }

    public string GetGoodPercentage()
    {
        string percentage = (int)(goodChance * 100) + "%";
        return percentage;
    }

    public string GetBadPercentage()
    {
        string percentage = ((int)(badChance * 100) + 1) + "%";
        return percentage;
    }
}
