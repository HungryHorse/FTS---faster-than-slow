using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Event
{
    public TextAsset text;
    public string[] voiceLines;
    private float option1DC;
    private string response;
    private float option2DC;
    private string option1Effected;
    private string option2Effected;
    private StatManager stats;
    Text description;
    Text option1;
    Text option2;

    public void SetText()
    {

        stats = GameObject.Find("Spaceship").GetComponent<StatManager>();

        description = GameObject.Find("Description").GetComponent<Text>();
        option1 = GameObject.Find("Option1").GetComponent<Text>();
        option2 = GameObject.Find("Option2").GetComponent<Text>();

        if (text != null)
        {
            voiceLines = (text.text.Split('\n'));
            description.text = voiceLines[0];
            option1.text = voiceLines[1];
            option1Effected = voiceLines[2];
            option1DC = float.Parse(voiceLines[3]);
            option2.text = voiceLines[5];
            option2Effected = voiceLines[6];
            option2DC = float.Parse(voiceLines[7]);
        }
    }

    public void Option1(string effected)
    {
        response = voiceLines[4];
        int noOfPass;
        int crewKilled = 0;
        int passengersKilled = 0;
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
                        crewKilled++;
                    }
                    if(noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Security", crewKilled);
                response += " " + crewKilled + " members of your sercurity team died.";
                break;

            case "M":
                noOfPass = 0;
                for (int i = 0; i < stats.medicAmount; i++)
                {
                    if (doDCCheck(option1DC))
                    {
                        noOfPass++;
                    }
                    else
                    {
                        crewKilled++;
                    }
                    if (noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Medic", crewKilled);
                response += " " + crewKilled + " members of your medical team died.";
                break;

            case "E":
                noOfPass = 0;
                for (int i = 0; i < stats.engineerAmount; i++)
                {
                    if (doDCCheck(option1DC))
                    {
                        noOfPass++;
                    }
                    else
                    {
                        crewKilled++;
                    }
                    if (noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Engineer", crewKilled);
                response += " " + crewKilled + " members of your engineering team died.";
                break;

            case "C":
                noOfPass = 0;
                for (int i = 0; i < stats.chefAmount; i++)
                {
                    if (doDCCheck(option1DC))
                    {
                        noOfPass++;
                    }
                    else
                    {
                        crewKilled++;
                    }
                    if (noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Chef", crewKilled);
                response += " " + crewKilled + " members of your culinary team died.";
                break;

            case "N":
                noOfPass = 0;
                for (int i = 0; i < stats.navigatorAmount; i++)
                {
                    if (doDCCheck(option1DC))
                    {
                        noOfPass++;
                    }
                    else
                    {
                        crewKilled++;
                    }
                    if (noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Navigator", crewKilled);
                response += " " + crewKilled + " members of your navigation team died.";
                break;

            case "P":
                stats.RemoveStat("Passengers", (int)(option1DC * 100));
                response += " " + (int)(option1DC * 100) + " passengers died.";
                break;

            case "SH":
                stats.RemoveStat("Ship Health", (int)(option1DC * 100));
                response += " Your ship lost " + (int)(option1DC * 100) + " health.";
                break;

            case "CH":
                stats.RemoveStat("Crew Health", (int)(option1DC * 100));
                response += " Your crew has lost " + (int)(option1DC * 100) + " health.";
                break;

            case "NU":
                stats.RemoveStat("Nutrition", (int)(option1DC * stats.crewNutrition));
                response += " Your crew has lost " + (int)(option1DC * stats.crewNutrition) + " food.";
                break;

            default:
                break;
        }
    }	

    public void Option2(string effected)
    {
        response = voiceLines[8];
        int noOfPass;
        int crewKilled = 0;
        int passengersKilled = 0;
        switch (effected)
        {
            case "S":
                noOfPass = 0;
                for (int i = 0; i < stats.securityAmount; i++)
                {
                    if (doDCCheck(option2DC))
                    {
                        noOfPass++;
                    }
                    else
                    {
                        crewKilled++;
                    }
                    if (noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Security", crewKilled);
                response += " " + crewKilled + " members of your sercurity team died.";
                break;

            case "M":
                noOfPass = 0;
                for (int i = 0; i < stats.medicAmount; i++)
                {
                    if (doDCCheck(option2DC))
                    {
                        noOfPass++;
                    }
                    else
                    {
                        crewKilled++;
                    }
                    if (noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Medic", crewKilled);
                response += " " + crewKilled + " members of your medical team died.";
                break;

            case "E":
                noOfPass = 0;
                for (int i = 0; i < stats.engineerAmount; i++)
                {
                    if (doDCCheck(option2DC))
                    {
                        noOfPass++;
                    }
                    else
                    {
                        crewKilled++;
                    }
                    if (noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Engineer", crewKilled);
                response += " " + crewKilled + " members of your engineering team died.";
                break;

            case "C":
                noOfPass = 0;
                for (int i = 0; i < stats.chefAmount; i++)
                {
                    if (doDCCheck(option2DC))
                    {
                        noOfPass++;
                    }
                    else
                    {
                        crewKilled++;
                    }
                    if (noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Chef", crewKilled);
                response += " " + crewKilled + " members of your culinary team died.";
                break;

            case "N":
                noOfPass = 0;
                for (int i = 0; i < stats.navigatorAmount; i++)
                {
                    if (doDCCheck(option2DC))
                    {
                        noOfPass++;
                    }
                    else
                    {
                        crewKilled++;
                    }
                    if (noOfPass > 3)
                    {
                        break;
                    }
                }
                stats.RemoveStat("Navigator", crewKilled);
                response += " " + crewKilled + " members of your navigation team died.";
                break;

            case "P":
                stats.RemoveStat("Passengers", (int)option2DC);
                response += " Your crew has lost " + (int)(option2DC * 100) + " food.";
                break;

            case "SH":
                stats.RemoveStat("Ship Health", (int)option2DC);
                response += " Your crew has lost " + (int)(option2DC * 100) + " food.";
                break;

            case "CH":
                stats.RemoveStat("Crew Health", (int)option2DC);
                response += " Your crew has lost " + (int)(option2DC * 100) + " food.";
                break;

            case "NU":
                stats.RemoveStat("Nutrition", (int)(option2DC * stats.crewNutrition));
                response += " Your crew has lost " + (int)(option2DC * stats.crewNutrition) + " food.";
                break;

            default:
                break;
        }

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
