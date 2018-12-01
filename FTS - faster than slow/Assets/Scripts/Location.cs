using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string name;
    public Event[] events;

    private void Start()
    {
        events[0].SetText();
    }
}
