using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour {

    public Location currlocation;
    

    public void onOptionOne()
    {
        currlocation.Createresponse(true);
    }
    public void onOptionTwo()
    {
        currlocation.Createresponse(false);
    }
}
