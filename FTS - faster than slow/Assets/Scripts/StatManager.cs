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

    public GameOver gameOver;

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
        gameOver = GameObject.Find("GameOver").GetComponent<GameOver>();
        ReadStats();
        CalculateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (passengerAmount <= 0 || shipHealth <= 0 || crewHealth <= 0)
        {
            gameOver.gameOver();
        }
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
        medicAmount = (int)Mathf.Clamp(medicAmount, 0, Mathf.Infinity);
        engineerAmount = (int)Mathf.Clamp(engineerAmount, 0, Mathf.Infinity);
        securityAmount = (int)Mathf.Clamp(securityAmount, 0, Mathf.Infinity);
        navigatorAmount = (int)Mathf.Clamp(navigatorAmount, 0, Mathf.Infinity);
        chefAmount = (int)Mathf.Clamp(chefAmount, 0, Mathf.Infinity);
        totalCrew = medicAmount + chefAmount + engineerAmount + navigatorAmount + securityAmount;
        navigationPoints = navigatorAmount;
        enginePower = (30 + (engineerAmount * 2) + (shipHealth / 100 * 30));
        crewHealth = Mathf.Clamp(crewHealth, 0, 100);
        shipHealth = Mathf.Clamp(shipHealth, 0, 100);
        GetComponent<StatsUI>().UpdateUI();
    }

    public void NextTurn()
    {

        //Crew Health
        //Crew Nutrition
        crewNutrition -= (totalCrew + passengerAmount);
        crewNutrition += (chefAmount * 10);

        if (crewNutrition < 0)
        {
            int deficit = Mathf.Abs(crewNutrition);
            for (int i = 0; i < deficit; i++)
            {
                killRandomCrew();
            }
            crewNutrition = 0;
        }
        //Ship Health
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
        crewHealth = crewHealth;
        crewNutrition = crewNutrition;
        navigationPoints = navigationPoints;
        shipHealth = shipHealth;
        enginePower = enginePower;

        //Crew Totals
        totalCrew = 0;
        medicAmount = medicAmount;
        chefAmount = chefAmount;
        engineerAmount = engineerAmount;
        navigatorAmount = navigatorAmount;
        securityAmount = securityAmount;
        passengerAmount = passengerAmount;
        WriteStats();
        CalculateStats();
    }

    void killRandomCrew()
    {
        int total = totalCrew + passengerAmount;
        int rand = Random.Range(0, passengerAmount);
        if (rand <= medicAmount)
        {
            RemoveStat("Medic", 1);
        }
        else if (rand <= medicAmount + chefAmount)
        {
            RemoveStat("Chef", 1);
        }
        else if (rand <= medicAmount + chefAmount + engineerAmount)
        {
            RemoveStat("Engineer", 1);
        }
        else if (rand <= medicAmount + chefAmount + engineerAmount + navigatorAmount)
        {
            RemoveStat("Navigator", 1);
        }
        else if (rand <= totalCrew)
        {
            RemoveStat("Security", 1);
        }
        else
        {
            RemoveStat("Passengers", 1);
        }
    }

    public int CalculateScore()
    {
        int score = 0;
        score = ((passengerAmount * 5) + (totalCrew * 2) + shipHealth * 2 + crewHealth * 3 / 2);

        return score;
    }


}
