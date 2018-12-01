using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public TextAsset text;
    public string[] voiceLines;
    Text description;
    Text option1;
    Text option2;

	// Use this for initialization
	void Start ()
    {
        description = GameObject.Find("Description").GetComponent<Text>();
        option1 = GameObject.Find("Option1").GetComponent<Text>();
        option2 = GameObject.Find("Option2").GetComponent<Text>();

        SetText();
    }

    void SetText()
    {
        if (text != null)
        {
            voiceLines = (text.text.Split('\n'));
        }
        description.text = voiceLines[0];
        option1.text = voiceLines[1];
        option2.text = voiceLines[2];
    }
	
}
