using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{

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

    //Crew Totals
    public int totalCrew;
    public int medicAmount;
    public int chefAmount;
    public int engineerAmount;
    public int navigatorAmount;
    public int securityAmount;
    public int passengerAmount;


    // Use this for initialization
    void Start()
    {
        ReadStats();
        CalculateStats();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddStat(string type, int amount)
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

            case "Crew Health":
                crewHealth += amount;
                break;

            case "Nutrition":
                crewNutrition += amount;
                break;

            case "Ship Health":
                shipHealth += amount;
                break;

            case "Passengers":
                passengerAmount += amount;
                break;

            default:
                break;
        }
        WriteStats();
        CalculateStats();
    }

    public void RemoveStat(string type, int amount)
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

            case "Crew Health":
                crewHealth -= amount;
                break;

            case "Nutrition":
                crewNutrition -= amount;
                break;

            case "Ship Health":
                shipHealth -= amount;
                break;

            case "Passengers":
                passengerAmount -= amount;
                break;

            default:
                break;
        }
        WriteStats();
        CalculateStats();
    }

    public void CalculateStats()
    {
        totalCrew = medicAmount + chefAmount + engineerAmount + navigatorAmount + securityAmount;
        navigationPoints = navigatorAmount;
        enginePower = engineerAmount;
        GetComponent<StatsUI>().UpdateUI();
    }

    public void NextTurn()
    {

        //Crew Health
        crewHealth += medicAmount;
        crewHealth = Mathf.Clamp(crewHealth, 0, 100);
        //Crew Nutrition
        crewNutrition -= (totalCrew + passengerAmount);
        crewNutrition += (chefAmount * 30);
        //Ship Health
        shipHealth += Mathf.FloorToInt(engineerAmount / 2);
        shipHealth = Mathf.Clamp(shipHealth, 0, 100);
        WriteStats();
        CalculateStats();
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
        passengerAmount = PlayerPrefs.GetInt("passengerAmount");
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
        PlayerPrefs.SetInt("passengerAmount", passengerAmount);
    }

    public void AddDemoValues()
    {
        AddStat("Security", 7);
        AddStat("Medic", 5);
        AddStat("Engineer", 8);
        AddStat("Chef", 15);
        AddStat("Navigator", 3);

        AddStat("Crew Health", 75);
        AddStat("Ship Health", 69);
        AddStat("Passengers", 300);
    }

    public void ResetValues()
    {
        crewHealth = 0;
        crewNutrition = 0;
        navigationPoints = 0;
        shipHealth = 0;
        enginePower = 0;

        //Crew Totals
        totalCrew = 0;
        medicAmount = 0;
        chefAmount = 0;
        engineerAmount = 0;
        navigatorAmount = 0;
        securityAmount = 0;
        passengerAmount = 0;
        WriteStats();
        CalculateStats();
    }


}
