using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {

    StatManager stats;
    ScoreManager scoreManager;

    public Text totalCrew;
    public Text passengers;
    public Text medic;
    public Text chef;
    public Text engineer;
    public Text navigator;
    public Text security;    
    public Text crewNutrition;
    public Image crewHealth;
    public Image shipHealth;
    public Text crewHealthText;
    public Text shipHealthText;

    public bool isIniti;

	// Use this for initialization
	void Start () {
        //stats = GetComponent<StatManager>();
        UpdateUI();
	}

    void Awake()
    {
        stats = GetComponent<StatManager>();
        stats.ResetValues();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateUI()
    {
        totalCrew.text = (stats.totalCrew + stats.passengerAmount).ToString();
        passengers.text = stats.passengerAmount.ToString();
        medic.text = stats.medicAmount.ToString();
        chef.text = stats.chefAmount.ToString();
        engineer.text = stats.engineerAmount.ToString();
        navigator.text = stats.navigatorAmount.ToString();
        security.text = stats.securityAmount.ToString();
        crewHealth.fillAmount = (float)stats.crewHealth / 100f;
        crewNutrition.text = stats.crewNutrition.ToString();
        shipHealth.fillAmount = (float)stats.shipHealth / 100f;
        crewHealthText.text = stats.crewHealth.ToString();
        shipHealthText.text = stats.shipHealth.ToString();
    }
}
