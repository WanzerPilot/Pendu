using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[System.Serializable]
public class Game
{/// <summary>
/// mot à deviner 
/// </summary>
    public string word;
    public int life;
    public int maxLife;
    public List<string> playedletters = new List<string>();

    public bool IsLost
    {
        get { return life <= 0; }
    }

    public bool IsWon //on cherche une lettre qui n'a pas été trouvé, dans ce cas on arrête la boucle avec le return false
    {
        get
        {
            foreach (char letter in word)
            {
                if (!playedletters.Contains(letter.ToString())) return false;
            }
            return true;
        }
    }

    public Game()
    {
        maxLife = 10;
        life = maxLife;
    }

    public bool WordContainsLetter(string letter)
    {
        return word.Contains(letter);
    }

    public bool LetterAlreadyPlayed(string letter)
    {
        return playedletters.Contains(letter);
    }

    public void AddLetter(string letter)
    {
        if (playedletters.Contains(letter)) return;
        playedletters.Add(letter);
    }
}
