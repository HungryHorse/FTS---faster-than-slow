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
    private float option1Reward;
    private string option1DCReward;
    private string response;
    private float option2DC;
    private float option2Reward;
    private string option2DCReward;
    private string option1Effected;
    private string option1RewardIdentifer;
    private string option2Effected;
    private string option2RewardIdentifer;
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
            option1DCReward = voiceLines[3];
            option2Text.text = voiceLines[5];
            option2Effected = voiceLines[6];
            option2DCReward = voiceLines[7];
        }

        Debug.Log(option1DCReward);
        Debug.Log(option2DCReward);

        if (option1DCReward.Length > 5)
        {
            option1DC =  float.Parse(option1DCReward.Substring(0,4));
            option1Reward = float.Parse(option1DCReward.Substring(4, 4));
            option1RewardIdentifer = voiceLines[9];
        }
        else
        {
            option1DC = float.Parse(option1DCReward);
        }
        if (option2DCReward.Length > 5)
        {
            option2DC = float.Parse(option2DCReward.Substring(0, 4));
            option2Reward = float.Parse(option2DCReward.Substring(4, 4));
            option2RewardIdentifer = voiceLines[10];
        }
        else
        {
            option2DC = float.Parse(option2DCReward);
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
                responseText.gameObject.SetActive(true);
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
                responseText.gameObject.SetActive(true);
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
                if(option1Reward >= 0)
                {
                    stats.AddStat("Security", (int)option1Reward);
                    response += "";
                }
                response += "\n\n" + crewKilled + " members of your sercurity team died.";
                break;

            case "M\r":
                crewKilled = CalculateCrewLoss(stats.medicAmount, option1DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Medic", stats.medicAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Medic", crewKilled);
                response += "\n\n" + crewKilled + " members of your medical team died.";
                break;

            case "E\r":
                crewKilled = CalculateCrewLoss(stats.engineerAmount, option1DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Engineer", stats.engineerAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Engineer", crewKilled);
                response += "\n\n" + crewKilled + " members of your engineering team died.";
                break;

            case "C\r":
                crewKilled = CalculateCrewLoss(stats.chefAmount, option1DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Chef", stats.chefAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Chef", crewKilled);
                response += "\n\n" + crewKilled + " members of your culinary team died.";
                break;

            case "N\r":
                crewKilled = CalculateCrewLoss(stats.navigatorAmount, option1DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Navigator", stats.navigatorAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Navigator", crewKilled);
                response += "\n\n" + crewKilled + " members of your navigation team died.";
                break;

            case "P\r":
                stats.RemoveStat("Passengers", (int)(option1DC * 100));
                response += "\n\n" + (int)(option1DC * 100) + " passengers died.";
                break;

            case "SH\r":
                stats.RemoveStat("Ship Health", (int)(option1DC * 100));
                response += "\n\nYour ship lost " + (int)(option1DC * 100) + " health.";
                break;

            case "CH\r":
                stats.RemoveStat("Crew Health", (int)(option1DC * 100));
                response += "\n\nYour crew has lost " + (int)(option1DC * 100) + " health.";
                break;

            case "NU\r":
                stats.RemoveStat("Nutrition", (int)(option1DC * stats.crewNutrition));
                response += "\n\nYour crew has lost " + (int)(option1DC * stats.crewNutrition) + " food.";
                break;

            default:
                break;
        }
        if (option1Reward >= 0)
        {
            response += Option1Reward();
        }
        return response;
    }	

    public string Option1Reward()
    {
        string text = "\n\n";
        switch (option1RewardIdentifer)
        {
            case "S\r":
                stats.AddStat("Security", (int)(option1Reward * 100));
                text += "Your crew expands adding " + option1Reward * 100 + " talented security officers to your ranks";
                break;

            case "M\r":
                stats.AddStat("Medic", (int)(option1Reward * 100));
                text += "Your crew feels much more spry now that " + option1Reward * 100 + " medical personnel have joined the ship";
                break;

            case "E\r":
                stats.AddStat("Engineer", (int)(option1Reward * 100));
                text += "Your engines aren't going to fail anytime soon with " + option1Reward * 100 + " more engineers on the ship";
                break;

            case "C\r":
                stats.AddStat("Chef", (int)(option1Reward * 100));
                text += "Your crew won't be going hungry with these " + option1Reward * 100 + " new gourmet chefs";
                break;

            case "N\r":
                stats.AddStat("Navigator", (int)(option1Reward * 100));
                text += "These " + option1Reward * 100 + " new navigators promise they won't get you lost anytime soon";
                break;

            case "P\r":
                stats.AddStat("Passengers", (int)(option1Reward * 100));
                text += "You gain " + option1Reward * 100 + " passengers";
                break;

            case "SH\r":
                stats.AddStat("Ship Health", (int)(option1Reward * 100));
                text += "You manage to repair " + option1Reward * 100 + "% of your hull";
                break;

            case "CH\r":
                stats.AddStat("Crew Health", (int)(option1Reward * 100));
                text += "Your crew gains " + option1Reward * 100 + " health";
                break;

            case "NU\r":
                stats.AddStat("Nutrition", (int)(option1Reward * 100));
                text += "You manage to salvage " + option1Reward * 100 + " units of food";
                break;

            default:
                break;
        }
        return text;
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
                response += "\n\n" + crewKilled + " members of your sercurity team died.";
                break;

            case "M\r":
                crewKilled = CalculateCrewLoss(stats.medicAmount, option2DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Medic", stats.medicAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Medic", crewKilled);
                response += "\n\n" + crewKilled + " members of your medical team died.";
                break;

            case "E\r":
                crewKilled = CalculateCrewLoss(stats.engineerAmount, option2DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Engineer", stats.engineerAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Engineer", crewKilled);
                response += "\n\n" + crewKilled + " members of your engineering team died.";
                break;

            case "C\r":
                crewKilled = CalculateCrewLoss(stats.chefAmount, option2DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Chef", stats.chefAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Chef", crewKilled);
                response += "\n\n" + crewKilled + " members of your culinary team died.";
                break;

            case "N\r":
                crewKilled = CalculateCrewLoss(stats.navigatorAmount, option2DC);
                if (didCrewDie(crewKilled))
                {
                    stats.RemoveStat("Navigator", stats.navigatorAmount);
                    throw new System.Exception("\n\nAll of your crew members died attempting this task.");
                }
                stats.RemoveStat("Navigator", crewKilled);
                response += "\n\n" + crewKilled + " members of your navigation team died.";
                break;

            case "P\r":
                stats.RemoveStat("Passengers", (int)(option2DC * 100));
                response += "\n\n" + (int)(option2DC * 100) + " passengers died.";
                break;

            case "SH\r":
                stats.RemoveStat("Ship Health", (int)(option2DC * 100));
                response += "\n\nYour ship has lost " + (int)(option2DC * 100) + " health.";
                break;

            case "CH\r":
                stats.RemoveStat("Crew Health", (int)(option2DC * 100));
                response += "\n\nYour crew has lost " + (int)(option2DC * 100) + " health.";
                break;

            case "NU\r":
                stats.RemoveStat("Nutrition", (int)(option2DC * stats.crewNutrition));
                response += "\n\nYour crew has lost " + (int)(option2DC * stats.crewNutrition) + " food.";
                break;

            default:
                break;
        }
        if (option2Reward >= 0)
        {
            response += Option2Reward();
        }
        return response;

    }

    public string Option2Reward()
    {
        string text = "\n\n";
        switch (option2RewardIdentifer)
        {
            case "S\r":
                stats.AddStat("Security", (int)(option2Reward * 100));
                text += "Your crew expands adding " + option2Reward * 100 + " talented security officers to your ranks";
                break;

            case "M\r":
                stats.AddStat("Medic", (int)(option2Reward * 100));
                text += "Your crew feels much more spry now that " + option2Reward * 100 + " medical personnel have joined the ship";
                break;

            case "E\r":
                stats.AddStat("Engineer", (int)(option2Reward * 100));
                text += "Your engines aren't going to fail anytime soon with " + option2Reward * 100 + " more engineers on the ship";
                break;

            case "C\r":
                stats.AddStat("Chef", (int)(option2Reward * 100));
                text += "Your crew won't be going hungry with these " + option2Reward * 100 + " new gourmet chefs";
                break;

            case "N\r":
                stats.AddStat("Navigator", (int)(option2Reward * 100));
                text += "These " + option2Reward * 100 + " new navigators promise they won't get you lost anytime soon";
                break;

            case "P\r":
                stats.AddStat("Passengers", (int)(option2Reward * 100));
                text += "You gain " + option2Reward + " passengers";
                break;

            case "SH\r":
                stats.AddStat("Ship Health", (int)(option2Reward * 100));
                text += "You manage to repair " + option2Reward * 100 + "% of your hull";
                break;

            case "CH\r":
                stats.AddStat("Crew Health", (int)(option2Reward * 100));
                text += "Your crew gains " + option2Reward * 100 + " health";
                break;

            case "NU\r":
                stats.AddStat("Nutrition", (int)(option2Reward * 100));
                text += "You manage to salvage " + option2Reward * 100 + " units of food";
                break;

            default:
                break;
        }
        return text;
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
        float rand = Random.Range(0f, 1f);

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
