using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterOpening : MonoBehaviour {

    public Sprite titleScreen;
    public Image curImage;
    public GameObject button1;
    public GameObject button2;

    private void Awake()
    {
        button1.SetActive(false);
        button2.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            GetComponent<Animator>().Play("NoAnimTitle");

            button1.SetActive(true);
            button2.SetActive(true);
        }
    }

    public void AfterOpeningMethod()
    {
        Debug.Log("Hit");
        button1.SetActive(true);
        button2.SetActive(true);
    }
}
