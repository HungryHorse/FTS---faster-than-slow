using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Node thisNode;
    LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entered");
        line.SetVertexCount(2);
        Vector3[] vectors = new Vector3[]{thisNode.transform.position, thisNode.ship.transform.position};
        line.SetPositions(vectors);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        line.SetVertexCount(0);
    }

    public void SetLineToNull()
    {
        line.SetVertexCount(0);
    }
}
