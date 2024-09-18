using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class RandomWordGenerator : MonoBehaviour
{
    //Array for the possible words to find
    public string[] wordsDatabase;
    /// <summary>
    /// représente tous les mots que le joueur peut tirer après avoir enlevé ceux qu'il a déjà deviné 
    /// </summary>
    private List<string> availableWords;

    private void Awake()
    {
        InitDatabase();
    }
    public string GetRandomWord()
    {
        int Index = Random.Range(0, wordsDatabase.Length); //Chooses a word from the array

        return availableWords[Index].ToUpper(); //Converts the player inputs in uppercase
    }

    void InitDatabase()
    {

        availableWords = new List<string>();

        foreach (string word in wordsDatabase)
        {
            availableWords.Add(word);
        }
        foreach (string word in UserHolder.Instance.currentProfile.playedWords) //retire tous les mots déjà deviné par le joueur
        {
            RemoveWord(word);
        }

    }

    public void RemoveWord(string wordToRemove)
    {
        availableWords.Remove(wordToRemove);
        Debug.Log(wordToRemove);
    }
}
