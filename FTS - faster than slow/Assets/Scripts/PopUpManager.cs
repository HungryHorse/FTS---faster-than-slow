using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour {

    public Location currlocation;

    [SerializeField]
    private GameObject description, optionOneButton, optionTwoButton, response;
    
    public void UpdateLocation(Location location)
    {
        if (!description.activeInHierarchy)
        {
            ToggleDescAndButtons();
            response.SetActive(true);
        }

        currlocation = location;
    }
    public void onOptionOne()
    {
        ToggleDescAndButtons();
        currlocation.Createresponse(true);

    }
    public void onOptionTwo()
    {
        ToggleDescAndButtons();
        currlocation.Createresponse(false);
    }

    public void ToggleDescAndButtons()
    {
        response.SetActive(!response.activeInHierarchy);
        description.SetActive(!description.activeInHierarchy);
        optionOneButton.SetActive(!optionOneButton.activeInHierarchy);
        optionTwoButton.SetActive(!optionTwoButton.activeInHierarchy);
    }
}
