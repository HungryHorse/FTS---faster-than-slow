using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGrabber : MonoBehaviour {

    int score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score").GetComponent<ScoreManager>().GetScore();
        scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
