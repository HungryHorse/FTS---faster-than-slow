using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private int score;

    public int GetScore()
    {
        return score;
    }

    public void SetInt(int setScore)
    {
        score = setScore;
    }
}
