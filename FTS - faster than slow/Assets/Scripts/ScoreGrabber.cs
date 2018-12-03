using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGrabber : MonoBehaviour {

    int score;
    public Text scoreText;
    public Text highScoreText;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score").GetComponent<ScoreManager>().GetScore();
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
