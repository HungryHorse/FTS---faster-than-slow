using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Event
{
    public TextAsset text;
    public string[] voiceLines = new string[10];
    private float option1DC;
    private string response;
    private float option2DC;
    private string option1Effected;
    private string option2Effected;
    private StatManager stats;
    Text description;
    Text option1Text;
    Text option2Text;
    Text responseText;
    bool failedATest;

    public void SetText()
    {
        stats = GameObject.Find("Stats").GetComponent<StatManager>();

        description = GameObject.Find("Description").GetComponent<Text>();
        option1Text = GameObject.Find("Option1").GetComponent<Text>();
        option2Text = GameObject.Find("Option2").GetComponent<Text>();
        try
        {
            responseText = GameObject.Find("Response").GetComponent<Text>();
            responseText.gameObject.SetActive(false);
        }
        catch { }

        

        if (text != null)
        {
            voiceLines = (text.text.Split('\n'));
            description.text = voiceLines[0];
            option1Text.text = voiceLines[1];
            option1Effected = voiceLines[2];
            option1DC = float.Parse(voiceLines[3]);
            option2Text.text = voiceLines[5];
            option2Effected = voiceLines[6];
            option2DC = float.Parse(voiceLines[7]);
        }
    }

    public void SetResponse(bool option1)
    {
        if (option1)
        {
            try
            {
                responseText.text = Option1();
                failedATest = false;
            }
            catch(System.Exception ex)
            {
                if (!failedATest)
                {
                    responseText.gameObject.SetActive(false);
                    description.gameObject.SetActive(true);
                    description.text += ex.Message;
                    option2Text.gameObject.transform.parent.gameObject.SetActive(true);
                }
                else
                {
                    //GameOverState
                    Debug.Log("You lost");
                }
                failedATest = true;
            }
        }
        else
        {
            try
            {
                responseText.text = Option2();
                failedATest = false;
            }
            catch(System.Exception ex)
            {
                if (!failedATest)
                {
                    responseText.gameObject.SetActive(false);
                    description.gameObject.SetActive(true);
                    description.text += ex.Message;
                    option1Text.gameObject.transform.parent.gameObject.SetActive(true);
                }
                else
                {
                    //GameOverState
                    Debug.Log("You lost");
                }
                failedATest = true;
            }
        }
    }

    public string Option1()
    {
        response = voiceLines[4];
        int crewKilled = 0;
        switch (option1Effected)
        {
            case "S\r":
                crewKilled = CalculateCrewLoss(stats.securityAmount, option1DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Security", stats.securityAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Security", crewKilled);
                response += " " + crewKilled + " members of your sercurity team died.";
                break;

            case "M\r":
                crewKilled = CalculateCrewLoss(stats.medicAmount, option1DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Medic", stats.medicAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Medic", crewKilled);
                response += " " + crewKilled + " members of your medical team died.";
                break;

            case "E\r":
                crewKilled = CalculateCrewLoss(stats.engineerAmount, option1DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Engineer", stats.engineerAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Engineer", crewKilled);
                response += " " + crewKilled + " members of your engineering team died.";
                break;

            case "C\r":
                crewKilled = CalculateCrewLoss(stats.chefAmount, option1DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Chef", stats.chefAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Chef", crewKilled);
                response += " " + crewKilled + " members of your culinary team died.";
                break;

            case "N\r":
                crewKilled = CalculateCrewLoss(stats.navigatorAmount, option1DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Navigator", stats.navigatorAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Navigator", crewKilled);
                response += " " + crewKilled + " members of your navigation team died.";
                break;

            case "P\r":
                stats.RemoveStat("Passengers", (int)(option1DC * 100));
                response += " " + (int)(option1DC * 100) + " passengers died.";
                break;

            case "SH\r":
                stats.RemoveStat("Ship Health", (int)(option1DC * 100));
                response += " Your ship lost " + (int)(option1DC * 100) + " health.";
                break;

            case "CH\r":
                stats.RemoveStat("Crew Health", (int)(option1DC * 100));
                response += " Your crew has lost " + (int)(option1DC * 100) + " health.";
                break;

            case "NU\r":
                stats.RemoveStat("Nutrition", (int)(option1DC * stats.crewNutrition));
                response += " Your crew has lost " + (int)(option1DC * stats.crewNutrition) + " food.";
                break;

            default:
                break;
        }
        return response;
    }	

    public string Option2()
    {
        response = voiceLines[8];
        int crewKilled = 0;

        switch (option2Effected)
        {
            case "S\r":
                crewKilled = CalculateCrewLoss(stats.securityAmount, option2DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Security", stats.securityAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Security", crewKilled);
                response += " " + crewKilled + " members of your sercurity team died.";
                break;

            case "M\r":
                crewKilled = CalculateCrewLoss(stats.medicAmount, option2DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Medic", stats.medicAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Medic", crewKilled);
                response += " " + crewKilled + " members of your medical team died.";
                break;

            case "E\r":
                crewKilled = CalculateCrewLoss(stats.engineerAmount, option2DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Engineer", stats.engineerAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Engineer", crewKilled);
                response += " " + crewKilled + " members of your engineering team died.";
                break;

            case "C\r":
                crewKilled = CalculateCrewLoss(stats.chefAmount, option2DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Chef", stats.chefAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Chef", crewKilled);
                response += " " + crewKilled + " members of your culinary team died.";
                break;

            case "N\r":
                crewKilled = CalculateCrewLoss(stats.navigatorAmount, option2DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Navigator", stats.navigatorAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Navigator", crewKilled);
                response += " " + crewKilled + " members of your navigation team died.";
                break;

            case "P\r":
                stats.RemoveStat("Passengers", (int)option2DC);
                response += " Your crew has lost " + (int)(option2DC * 100) + " food.";
                break;

            case "SH\r":
                stats.RemoveStat("Ship Health", (int)option2DC);
                response += " Your crew has lost " + (int)(option2DC * 100) + " food.";
                break;

            case "CH\r":
                stats.RemoveStat("Crew Health", (int)option2DC);
                response += " Your crew has lost " + (int)(option2DC * 100) + " food.";
                break;

            case "NU\r":
                stats.RemoveStat("Nutrition", (int)(option2DC * stats.crewNutrition));
                response += " Your crew has lost " + (int)(option2DC * stats.crewNutrition) + " food.";
                break;

            default:
                break;
        }
        return response;

    }

    private int CalculateCrewLoss(int crewNum, float DC)
    {
        if(crewNum <= 3)
        {
            throw new System.Exception("\n\nYou did not have enough crew members to attempt that task.");
        }

        int noOfPass = 0;
        int crewKilled = 0;
        for (int i = 0; i < crewNum; i++)
        {
            if (doDCCheck(DC))
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
            if(crewKilled == crewNum)
            {
                crewKilled = -1;
                break;
            }
        }

        return crewKilled;
    }

    private bool didCrewDie(int crewKilled)
    {
        if(crewKilled == -1)
        {
            return true;
        }
        return false;
    }

    private bool doDCCheck(float DC)
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
