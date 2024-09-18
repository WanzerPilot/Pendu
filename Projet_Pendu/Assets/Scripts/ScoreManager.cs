using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score
    {
        get { return UserHolder.Instance.currentProfile.currentScore; }
        set { UserHolder.Instance.SetUserScore(value); }
    } //encapsulation de données

    public int bestScore
    {
        get { return UserHolder.Instance.currentProfile.bestScore; }
        set { UserHolder.Instance.SetUserBestScore(value); }
    } //encapsulation de données

    public TMP_Text scoreText;
    public TMP_Text bestScoreText;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        scoreText.text = "" + score;
        bestScoreText.text = "HIGHSCORE " + bestScore;

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "" + score;
        if (bestScore < score) //Permet d'enregistrer le dernier highscore atteint
            bestScore = score;

    }
}
