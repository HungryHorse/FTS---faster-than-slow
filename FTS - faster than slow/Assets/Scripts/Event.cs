using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public TextAsset text;
    public string[] voiceLines;
    private float option1DC;
    private float option2DC;
    private string option1Effected;
    private string option2Effected;
    private StatManager stats;
    Text description;
    Text option1;
    Text option2;

	// Use this for initialization
	void Start ()
    {
        stats = GameObject.Find("Spaceship").GetComponent<StatManager>();

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
            description.text = voiceLines[0];
            option1.text = voiceLines[1];
            option1Effected = voiceLines[2];
            option1DC = float.Parse(voiceLines[3]);
            option2.text = voiceLines[4];
            option2Effected = voiceLines[5];
            option2DC = float.Parse(voiceLines[6]);
        }
    }

    void Option1(string effected, float DC)
    {
        int noOfPass;
        switch (effected)
        {
            case "S":
                noOfPass = 0;
                for(int i = 0; i < stats.securityAmount; i++)
                {
                    if (doDCCheck(option1DC))
                    {
                        noOfPass++;
                    }
                    else
                    {

                    }
                    if(noOfPass > 3)
                    {
                        break;
                    }
                }
                break;
            case "M":

                break;
            case "E":

                break;
            case "C":

                break;
            case "N":

                break;
            case "SH":

                break;
            case "CH":

                break;
            case "NU":

                break;
            
        }
    }	

    void Option2()
    {

    }

    public bool doDCCheck(float DC)
    {
        int rand = Random.Range(0, 1);

        if (rand >= DC)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
