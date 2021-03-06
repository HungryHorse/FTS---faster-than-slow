﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject tooltipObject;
    public Canvas canvas;
    GameObject currentToolTip;
    public string toolTipDescription;
    public string toolTipTitle;
    public bool castOnLeft;

    // spawns a ui tool tip that tells the user what the upgrade does
    public void OnPointerEnter(PointerEventData eventData)
    {
        currentToolTip = Instantiate(tooltipObject, canvas.transform);
        if (castOnLeft)
        {
            currentToolTip.transform.position = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y - 1.7f);
        }
        else
        {
            currentToolTip.transform.position = new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y - 1.7f);
        }

        currentToolTip.transform.GetChild(1).GetComponent<Text>().text = toolTipDescription;
        currentToolTip.transform.GetChild(2).GetComponent<Text>().text = toolTipTitle;        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(currentToolTip);
    }

    
}
