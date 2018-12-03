using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public GameObject optionsMenu;
    public Slider volSlider;
    public GameObject starvingMenu;
    public StatManager statManager;
    public GameObject StarMap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.active)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }

        if(starvingMenu.activeInHierarchy && !StarMap.activeInHierarchy)
        {
            starvingMenu.SetActive(false);
        }

	}

    public void HideStarvingMenu()
    {
        starvingMenu.SetActive(false);
    }

    public void ShowMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void HideMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void UpdateVolume()
    {
        GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>().SetVolume(volSlider.value);
    }
}
