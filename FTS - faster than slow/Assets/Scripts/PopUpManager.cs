using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour {

    public Location currlocation;
    
    public void UpdateLocation(Location location)
    {
        currlocation = location;
    }
    public void onOptionOne()
    {
        currlocation.Createresponse(true);
    }
    public void onOptionTwo()
    {
        currlocation.Createresponse(false);
    }
}
