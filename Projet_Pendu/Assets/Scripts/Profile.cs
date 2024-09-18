using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Profile
{

    public string name;
    public int bestScore, currentScore;
    public List<string> playedWords;


    public Profile(string userName)
    {
        name = userName;
        bestScore = 0;
        currentScore = 0;
        playedWords = new List<string>();
    }
}
