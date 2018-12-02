using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour
{
    public static GameObject eventUI;
    public int eventIndex;
    public bool isGood;
    public Event[] goodEvents;
    public Event[] badEvents;
    public Sprite backgroundSprite;
    public Image background;

    private void Awake()
    {
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Image>();
        eventUI = GameObject.Find("EventUI");
    }

    private void Start()
    {
    }

    public void EnterLocation()
    {
        background.sprite = backgroundSprite;
    }

    public void EventText()
    {
        eventUI.SetActive(true);
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
