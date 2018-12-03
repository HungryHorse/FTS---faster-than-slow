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
    int distance;
    public bool castOnLeft;
    NodeButton button;

    void Start()
    {
        button = GetComponent<NodeButton>();
    }

    // spawns a ui tool tip that tells the user what the upgrade does
    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < button.thisNode.prevNodes.Length; i++)
        {
            if (button.thisNode.ship.currNode == button.thisNode.prevNodes[i])
            {
                currentToolTip = Instantiate(tooltipObject, canvas.transform);
                if (castOnLeft)
                {
                    currentToolTip.transform.position = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y - 2f);
                }
                else
                {
                    currentToolTip.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1.5f);
                }

                goodPercent = GetComponent<NodeButton>().thisNode.GetComponent<Node>().GetGoodPercentage();
                badPercent = GetComponent<NodeButton>().thisNode.GetComponent<Node>().GetBadPercentage();
                distance = GetComponent<NodeButton>().thisNode.GetComponent<Node>().distance;

                currentToolTip.transform.GetChild(1).GetComponent<Text>().text = "Distance: " + distance.ToString();
                currentToolTip.transform.GetChild(2).GetComponent<Text>().text = "Good Event: " + goodPercent;
                currentToolTip.transform.GetChild(3).GetComponent<Text>().text = "Bad Event: " + badPercent;
            }
        }

        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(currentToolTip);
    }

    void Update()
    {
        if (!gameObject.transform.parent.gameObject.active)
        {
            Destroy(currentToolTip);
        }
    }
}
