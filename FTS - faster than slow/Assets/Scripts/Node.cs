using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node : MonoBehaviour
{
    public bool first;
    public Location location;
    public Location[] locationArray;
    public Node[] prevNodes;
    public Spaceship ship;
    public float goodChance;
    public float badChance;
    public StatManager stat;
    public GameObject[] starmaps;

    private void Awake()
    {
        stat = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>();
        goodChance = Random.Range(0, 0.35f);
        badChance = 1 - goodChance;
        int rand = Random.Range(0, locationArray.Length);

        if(!first)
        {
            location = Instantiate(locationArray[rand]);

        }

        if (first)
        {
            location = Instantiate(location);
            ship.PositionUpdate(this);
        }
    }

    private void Start()
    {
        starmaps = GameObject.FindGameObjectsWithTag("Starmap");
        starmaps[0].SetActive(false);
        starmaps[1].SetActive(false);
    }

    public void NextNode()
    {
        for(int i = 0; i < prevNodes.Length; i++)
        {
            if(ship.currNode == prevNodes[i])
            {
                float makeGood = Random.Range(0, 1);
                if (makeGood < goodChance)
                {
                    location.isGood = true;
                }
                ship.PositionUpdate(this);
                starmaps[0].SetActive(false);
                starmaps[1].SetActive(false);
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
                SetGoodChance(stat.navigatorAmount);
                SetBadChance();
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
        int rand;
        int good = 0;
        good = (int)(goodChance * 100);

        int percentOfNavs = (noOfNav / 20);

        if(percentOfNavs >= 0.75)
        {
            
        }
        else if(percentOfNavs < 0.75)
        {
            rand = Random.Range(-10, 1);
        }
        else if (percentOfNavs < 0.5)
        {
            rand = Random.Range(-20, 1);
        }
        else if (percentOfNavs < 0.25)
        {
            rand = Random.Range(-30, 1);
        }
        else
        {
            good = 0;
        }

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
        string percentage = (int)(badChance * 100) + "%";
        return percentage;
    }
}
