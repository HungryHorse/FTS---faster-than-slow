using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public int eventIndex;
    public Event[] events;
    

    public void EventText()
    {
        events[eventIndex].SetText();
    }
}
