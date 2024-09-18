using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class IHMController : MonoBehaviour
{
    public static IHMController Instance;
    [SerializeField] TextMeshProUGUI wordText;
    [SerializeField] TextMeshProUGUI playedLettersText;
    [SerializeField] Sprite[] spriteArray;
    [SerializeField] Image hangmanImage;


    void Awake()
    {
        Instance = this;
    }

    public void UpdateWord(Game game)
    {

        string wordToDisplay = string.Empty;

        for (int i = 0; i < game.word.Length; i++)
        {
            if (game.playedletters.Contains(game.word[i].ToString()))
            //si la lettre jouée est contenu dans le mot en cours
            {
                wordToDisplay += game.word[i].ToString();
                //ajoute la lettre jouée si elle est contenue dans le mot en cours 

            }

            else
            {
                wordToDisplay += " _";
                //affiche _ si la lettre jouée n'est pas dans le mot en cours
            }

        }

        wordText.text = wordToDisplay;



    }

    public void UpdatePlayedLetters(Game game) 
    {
        //Affichage des lettres jouées
        string result = string.Empty;
        foreach (string letter in game.playedletters)
        {
            result += letter + ">";
        }

        playedLettersText.text = result;

    }

    public void UpdateHangman(Game game)
    {
        int index = game.maxLife - game.life;
        index = Mathf.Clamp(index, 0, game.maxLife); //clamp permet d'éviter que la valeur ne dépasse le minimum ou le maximum
        hangmanImage.sprite = spriteArray [index];

    }
}
