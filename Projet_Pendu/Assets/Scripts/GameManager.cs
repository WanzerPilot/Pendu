using JetBrains.Annotations;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public Game currentGame;


    [SerializeField]
    RandomWordGenerator randomWordGenerator;

    public AudioSource oneLastChance;
    public AudioSource hangmanSound;
    public AudioSource gameOver;
    public AudioSource gameBGM;
    //public AudioSource goodGuess;


    void Start()
    {
        StartNewGame();
    }

    void StartNewGame()
    {
        currentGame = new Game();
        currentGame.word = randomWordGenerator.GetRandomWord(); //Au démarrage, prend un mot au hasard dans le RandomWordGenerator, puis affiche les emplacements de lettres dissimulées du mot à trouver
        IHMController.Instance.UpdateWord(currentGame);
        IHMController.Instance.UpdatePlayedLetters(currentGame);
        IHMController.Instance.UpdateHangman(currentGame);

        GetComponent<AudioSource>();
        gameBGM.Play();


    }

    public void OnLetterPlayed(string letter)
    {

        if (letter == "") return;


        if (!IsGoodMove(letter))//enlève une vie si la lettre jouée n'est pas dans le mot, ou si elle a déjà été joué
        {
            currentGame.life--; // -- permet de décrémenter de 1
            IHMController.Instance.UpdateHangman(currentGame);
            GetComponent<AudioSource>();
            hangmanSound.Play();
        }

        currentGame.AddLetter(letter);


        if (currentGame.life == 1)
        {
            //lance audio loop quand il ne reste qu'une vie
            GetComponent<AudioSource>();
            oneLastChance.Play(0);
        }



        if (currentGame.IsLost)
        {
            OnGameLost();
        }

        else if (currentGame.IsWon)
        {
            OnGameWon();
        }


        IHMController.Instance.UpdateWord(currentGame);
        IHMController.Instance.UpdatePlayedLetters(currentGame);


    }

    void AddPlayedWords(string playedWord)
    {
        UserHolder.Instance.currentProfile.playedWords.Add(playedWord);
    }

    /// <summary>
    /// Appeler quand la partie est perdue
    /// </summary>
    async void OnGameLost()
    {
        UserHolder.Instance.SetUserScore(0);

        UserHolder.Instance.SaveCurrentProfileOnDisk();

        GetComponent<AudioSource>();
        gameOver.Play();

        GetComponent<AudioSource>(); //Arrête le son onLastChance, et l'empêche d'overlap sur le gameover
        oneLastChance.Stop();

        await Task.Delay(3000); //Ajoute un délai entre le son joué et le menu à afficher
        GetComponent<AudioSource>(); //Arrête la musique de fond après le délai souhaité
        gameBGM.Stop();
        GameOverMenuController.Instance.SetActive(true); //GameOver instancié si partie perdue
    }

    async void OnGameWon()
    {
        AddPlayedWords(currentGame.word);
        randomWordGenerator.RemoveWord(currentGame.word);
        ScoreManager.Instance.UpdateScore(1);
        UserHolder.Instance.SaveCurrentProfileOnDisk();
        await Task.Delay(1000);
        GameWonMenuController.Instance.SetActive(true); //GameWon instancié si partie gagnée
    }

    bool IsGoodMove(string letter)
    {
        if (!currentGame.WordContainsLetter(letter)) return false;
        if (currentGame.LetterAlreadyPlayed(letter)) return false;
        return true;
    }

}
