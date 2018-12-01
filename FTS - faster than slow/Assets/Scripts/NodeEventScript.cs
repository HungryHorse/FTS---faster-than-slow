using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeEventScript : MonoBehaviour
{
    public NodeButton nodeButton;

    public void Click()
    {
        gameObject.GetComponent<Node>().NextNode();
        Debug.Log("Pointer click");
        nodeButton.SetLineToNull();
    }
}
