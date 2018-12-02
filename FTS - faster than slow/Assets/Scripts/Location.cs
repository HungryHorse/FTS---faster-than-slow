using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public int eventIndex;
    public bool isGood;
    public Event[] goodEvents;
    public Event[] badEvents;

    public void EventText()
    {

        if (isGood)
        {
            eventIndex = Random.Range(0, goodEvents.Length);
        }
        else
        {
            eventIndex = Random.Range(0, badEvents.Length);
        }

        if (isGood)
        {
            goodEvents[eventIndex].SetText();
        }
        else
        {
            badEvents[eventIndex].SetText();
        }
    }

    public void Createresponse(bool option1)
    {
        if (isGood)
        {
            goodEvents[eventIndex].SetResponse(option1);
        }
        else
        {
            badEvents[eventIndex].SetResponse(option1);
        }
    }
}
