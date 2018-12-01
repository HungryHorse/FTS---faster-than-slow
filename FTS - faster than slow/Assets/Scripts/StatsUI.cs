using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {

    StatManager stats;

    public Text totalCrew;
    public Text passengers;
    public Text medic;
    public Text chef;
    public Text engineer;
    public Text navigator;
    public Text security;    
    public Text crewNutrition;
    public Slider crewHealth;
    public Slider shipHealth;
    public Text crewHealthText;
    public Text shipHealthText;

	// Use this for initialization
	void Start () {
        stats = GetComponent<StatManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateUI()
    {
        totalCrew.text = stats.totalCrew.ToString();
        passengers.text = stats.passengerAmount.ToString();
        medic.text = stats.medicAmount.ToString();
        chef.text = stats.chefAmount.ToString();
        engineer.text = stats.engineerAmount.ToString();
        navigator.text = stats.navigatorAmount.ToString();
        security.text = stats.securityAmount.ToString();
        crewHealth.value = stats.crewHealth;
        crewNutrition.text = stats.crewNutrition.ToString();
        shipHealth.value = stats.shipHealth;
        crewHealthText.text = stats.crewHealth.ToString();
        shipHealthText.text = stats.shipHealth.ToString();
    }
}
