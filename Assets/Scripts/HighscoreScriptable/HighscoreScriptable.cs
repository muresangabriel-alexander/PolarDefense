using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HighscoreScriptable : ScriptableObject
{
    [SerializeField]
    private int highscore;
    private int currentScore; 

    public int Highscore
    {
        get { return highscore; }
        set { highscore = value; }
    }
    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }

}
