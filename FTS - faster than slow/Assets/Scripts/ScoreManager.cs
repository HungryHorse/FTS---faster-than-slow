using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private int score;
    [SerializeField]
    private int highScore;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        highScore = PlayerPrefs.GetInt("highScore");
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int setScore)
    {
        score = setScore;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }
}
