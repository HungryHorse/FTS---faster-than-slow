using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public int eventIndex;
    public Event[] events;

    private void Start()
    {
        eventIndex = Random.Range(0, events.Length);
    }

    public void EventText()
    {
        events[eventIndex].SetText();
    }

    public void Createresponse(bool option1)
    {
        events[eventIndex].SetResponse(option1);
    }
}
