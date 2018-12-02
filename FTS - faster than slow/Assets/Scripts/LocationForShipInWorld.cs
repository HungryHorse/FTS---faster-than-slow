using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationForShipInWorld : MonoBehaviour
{
    public Location location;
    public PopUpManager popUpManager;

    
    public void EventSpawn()
    {
        popUpManager.UpdateLocation(location);
        location.EventText();
    }

}
