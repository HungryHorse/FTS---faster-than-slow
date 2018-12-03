using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private int score;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int setScore)
    {
        score = setScore;
    }
}
