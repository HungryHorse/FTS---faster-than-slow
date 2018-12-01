using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour {

    //Starting Values
    [SerializeField]
    int StartingHealth;
    [SerializeField]
    int StartingNutrition;
    [SerializeField]
    int StartingShipHealth;

    //Stat Totals
    public int crewHealth;
    public int crewNutrition;
    public int navigationPoints;
    public int shipHealth;
    public int enginePower;
    public int violence;
    
    //Crew Totals
    public int totalCrew;
    public int medicAmount;
    public int chefAmount;
    public int engineerAmount;
    public int navigatorAmount;
    public int securityAmount;
    

	// Use this for initialization
	void Start () {
        ReadStats();
        CalculateStats();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCrew(string type, int amount)
    {
        switch (type)
        {
            case "Medic":
                medicAmount += amount;
                break;

            case "Chef":
                chefAmount += amount;
                break;

            case "Engineer":
                engineerAmount += amount;
                break;

            case "Navigator":
                navigatorAmount += amount;
                break;

            case "Security":
                securityAmount += amount;
                break;

            default:
                break;
        }
        CalculateStats();
    }

    public void RemoveCrew(string type, int amount)
    {
        switch (type)
        {
            case "Medic":
                medicAmount -= amount;
                break;

            case "Chef":
                chefAmount -= amount;
                break;

            case "Engineer":
                engineerAmount -= amount;
                break;

            case "Navigator":
                navigatorAmount -= amount;
                break;

            case "Security":
                securityAmount -= amount;
                break;

            default:
                break;
        }
        CalculateStats();
    }

    public void CalculateStats()
    {
        totalCrew = medicAmount + chefAmount + engineerAmount + navigatorAmount + securityAmount;
        navigationPoints = navigatorAmount;
        enginePower = engineerAmount;
        violence = securityAmount;
    }

    public void NextTurn()
    {
        //Crew Health
        crewHealth += medicAmount;
        Mathf.Clamp(crewHealth, 0, 100);
        //Crew Nutrition
        crewNutrition -= totalCrew;
        crewNutrition += (chefAmount * 3);
        Mathf.Clamp(crewNutrition, 0, 100);

    }

    public void ReadStats()
    {
        crewHealth = PlayerPrefs.GetInt("crewHealth");
        crewNutrition = PlayerPrefs.GetInt("crewNutrition");
        shipHealth = PlayerPrefs.GetInt("shipHealth");

        medicAmount = PlayerPrefs.GetInt("medicAmount");
        chefAmount = PlayerPrefs.GetInt("chefAmount");
        engineerAmount = PlayerPrefs.GetInt("engineerAmount");
        navigatorAmount = PlayerPrefs.GetInt("navigatorAmount");
        securityAmount = PlayerPrefs.GetInt("securityAmount");
    }

    public void WriteStats()
    {
        PlayerPrefs.SetInt("crewHealth", crewHealth);
        PlayerPrefs.SetInt("crewNutrition", crewNutrition);
        PlayerPrefs.SetInt("shipHealth", shipHealth);

        PlayerPrefs.SetInt("medicAmount", medicAmount);
        PlayerPrefs.SetInt("chefAmount", chefAmount);
        PlayerPrefs.SetInt("engineerAmount", engineerAmount);
        PlayerPrefs.SetInt("navigatorAmount", navigatorAmount);
        PlayerPrefs.SetInt("securityAmount", securityAmount);
    }
}
