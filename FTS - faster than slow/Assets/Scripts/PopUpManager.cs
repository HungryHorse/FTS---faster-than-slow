using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{

    public Location currlocation;

    [SerializeField]
    private GameObject description, optionOneButton, optionTwoButton, response;
    [SerializeField]
    private AudioClip buttonClickSound;

    public void UpdateLocation(Location location)
    {

        response.SetActive(true);
        TurnOnDesc();

        currlocation = location;
    }
    public void onOptionOne()
    {
        TurnOffDesc();
        currlocation.Createresponse(true);
        GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>().PlaySound(buttonClickSound);
    }
    public void onOptionTwo()
    {
        TurnOffDesc();
        currlocation.Createresponse(false);
        GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>().PlaySound(buttonClickSound);
    }

    public void TurnOnDesc()
    {
        description.SetActive(true);
        optionOneButton.SetActive(true);
        optionTwoButton.SetActive(true);
    }

    public void TurnOffDesc()
    {
        description.SetActive(false);
        optionOneButton.SetActive(false);
        optionTwoButton.SetActive(false);
    }
}
