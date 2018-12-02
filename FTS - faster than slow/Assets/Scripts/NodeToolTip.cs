using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class NodeToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject tooltipObject;
    public Canvas canvas;
    GameObject currentToolTip;
    public string toolTipTitle;
    string goodPercent;
    string badPercent;
    public bool castOnLeft;

    // spawns a ui tool tip that tells the user what the upgrade does
    public void OnPointerEnter(PointerEventData eventData)
    {
        currentToolTip = Instantiate(tooltipObject, canvas.transform);
        if (castOnLeft)
        {
            currentToolTip.transform.position = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y - 2f);
        }
        else
        {
            currentToolTip.transform.position = new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y - 2f);
        }

        goodPercent = GetComponent<NodeButton>().thisNode.GetComponent<Node>().GetGoodPercentage();
        badPercent = GetComponent<NodeButton>().thisNode.GetComponent<Node>().GetBadPercentage();

        currentToolTip.transform.GetChild(1).GetComponent<Text>().text = "Location";
        currentToolTip.transform.GetChild(2).GetComponent<Text>().text = goodPercent;
        currentToolTip.transform.GetChild(3).GetComponent<Text>().text = badPercent;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(currentToolTip);
    }
}
